using BeautyLand.Application.Services.Databases.IdentitySQLDatabase;
using BeautyLand.Application.Services.Databases.SQLDatabase;
using BeautyLand.Domain.Order;
using BeautyLand.Domain.Payments;
using BeautyLand.Subscription.ExceptionExtentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BeautyLand.Application.Services.Site.Payments
{
    public  class PaymentService : IPaymentService
    {
        private readonly ISQLDatabaseService _context;
        private readonly IIdentitySQLDatabase _identityContext;
        public PaymentService(ISQLDatabaseService context, IIdentitySQLDatabase identityContext)
        {
            _context = context;
            _identityContext = identityContext;
        }

        public PaymentDto CreateGetPaymentOrder(Guid paymentId)
        {
            var payment = _context.Payments
                .Include(p => p.Order)
                  .ThenInclude(p => p.OrderItems)
                   .Include(p => p.Order)
                  .ThenInclude(p => p.Discount)
                .SingleOrDefault(p => p.Id == paymentId);

            if (payment == null)
            {
                throw new NotFoundExceptionExtention<Payment, Guid>(payment, paymentId);
            }
            var user = _identityContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);
            string description = $"پرداخت شماره سفارش{payment.OrderId}" + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach (var item in payment.Order.OrderItems.Select(p=> p.Name))
            {
                description += $"-{item}";
            }

            return new PaymentDto
            {
                Id = payment.Id,
                Amount = payment.Order.AppliedDiscountonTotalPrice(),
                Description = description,
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

        }

        public bool CreatePaymentVerification(Guid paymentId, string authority, long refId)
        {
            var payment = _context.Payments
                 .Include(p => p.Order)
                 .SingleOrDefault(p => p.Id == paymentId);


            if (payment == null)
            {
                throw new NotFoundExceptionExtention<Payment, Guid>(payment, paymentId);
            }

            payment.Order.PaymentStatusPaid();
            payment.Paid(authority, refId);
            _context.SaveChanges();
            return true;
        }

        public PaymentOrderDto CreateSetPaymentOrder(int orderId)
        {
            var order = _context.Orders
               .Include(p => p.Discount)
              .Include(p => p.OrderItems)
              .SingleOrDefault(p => p.Id == orderId);


            if (order == null)
            {
                throw new NotFoundExceptionExtention<Order, int>(order, orderId);
            }

            var payment = _context.Payments.SingleOrDefault(p => p.OrderId == order.Id);

            if (payment == null)
            {
                payment = new Payment(order.AppliedDiscountonTotalPrice(), order.Id);
                _context.Payments.Add(payment);
                _context.SaveChanges();

                return new PaymentOrderDto()
                {
                    Id = payment.Id,
                    Amount = payment.Amount,
                    PaymentMethod = order.PaymentMethod
                };
            }
            else
            {
                return new PaymentOrderDto()
                {
                    Id = payment.Id,
                    Amount = payment.Amount,
                    PaymentMethod = order.PaymentMethod
                };
            }
        }
    }
}
        