using BeautyLand.Domain.Order;
using System;

namespace BeautyLand.Application.Services.Site.Payments
{

    public class PaymentOrderDto
        {
            public Guid Id { get; set; }
            public int Amount { get; set; }
            public PaymentMethod PaymentMethod { get; set; }
    }
}

