using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BeautyLand.Application.Services.Site.Payments.PaymentService;

namespace BeautyLand.Application.Services.Site.Payments
{
    public interface IPaymentService
    {
        PaymentOrderDto CreateSetPaymentOrder(int orderId);
        PaymentDto CreateGetPaymentOrder(Guid paymentId);
        bool CreatePaymentVerification(Guid paymentId, string authority, long refId);
    }
}
        