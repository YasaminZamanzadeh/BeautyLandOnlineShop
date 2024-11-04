using BeautyLand.Domain.Attributes;
using BeautyLand.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Domain.Order
{
    [AudiTable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public Address Address { get; private set; }
        public int Quantity { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();
        public int? DiscountAmount { get; private set; } = null;
        public Discount? Discount { get; private set; }= null;
        public int? DiscountId { get; set; } = null;

        public Order(string userId, Address address, int quantity, List<OrderItem> orderItems, PaymentMethod paymentMethod, Discount discount)
        {
            UserId = userId;
            Address = address;
            Quantity = quantity;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
            if (discount != null)
            {
                    DiscountAmount = discount.DiscountAmount;
                    Discount = discount;
                    DiscountId = discount.Id;
                }

        }
         public void AddQuantity(int quantity)
        {
            if (quantity ==0)
            {
                quantity += 1;
                Quantity += quantity;
            }
            else
            Quantity += quantity;
        }
        public int AppliedDiscountonTotalPrice()
        {
            int totalPrice = _orderItems.Sum(p => p.Price * p.Quantity);
            if (totalPrice == null)
            {
                totalPrice -= Discount.GetDiscountAmount(totalPrice);
            }
            return totalPrice;
        }
        public int NotAppliedDiscountonTotalPrice()
        {
            int totalPrice = _orderItems.Sum(p => p.Price * p.Quantity);
            return totalPrice;
        }

        public void ApplyDiscount(Discount discount)
        {
            Discount = discount;
            DiscountId = discount?.Id;
            DiscountAmount = discount?.GetDiscountAmount(NotAppliedDiscountonTotalPrice());

        }


        public Order()
        {

        }
        public void PaymentStatusPaid()
        {
            PaymentStatus = PaymentStatus.Paid;
        }

        public void PaymentStatusUnpaid()
        {
            PaymentStatus = PaymentStatus.Unpaid;
        }

        public void OrderStatusCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public void OrderStatusReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }

        public void OrderStatusDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }
        public void OrderStatusProcessing()
        {
            OrderStatus = OrderStatus.Processing;
        }


    }

    public class Address
    {
        public string Name { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }

        public Address(string name, string city, string state, string postalCode, string postalAddress)
        {
            Name = name;
            City = city;
            State = state;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
        }
        public Address()
        {

        }
    }

    public enum PaymentMethod
    {
        /// <summary>
        /// پرداخت انلاین
        /// </summary>
        OnlinePayment = 0,
        /// <summary>
        /// پرداخت  درب محل
        /// </summary>
        PhysicalPayment = 1,
    }

    public enum PaymentStatus
    {
        /// <summary>
        /// پرداخت نشده
        /// </summary>
        [Description("پرداخت نشده")]
        Unpaid = 0,
        /// <summary>
        /// پرداخت شده
        /// </summary>
        [Description("پرداخت شده")]
        Paid = 1,
    }

    public enum OrderStatus
    {
        /// <summary>
        ///در انتطار پرداخت
        /// </summary>
       [Description("در انتطار پرداخت")]
        WaitingforPayment = 0,
        /// <summary>
        /// در حال پردازش
        /// </summary>
        [Description("در حال پردازش")]
        Processing = 1,
        /// <summary>
        /// تحویل داده شده 
        /// </summary>
        [Description("تحویل داده شده")]
        Delivered = 2,
        /// <summary>
        /// مرجوعی 
        /// </summary>
        [Description("مرجوعی ")]
        Returned = 3,
        /// <summary>
        ///لغو شده 
        /// </summary>
        [Description("لغو شده")]
        Cancelled = 4
       
    }
}
