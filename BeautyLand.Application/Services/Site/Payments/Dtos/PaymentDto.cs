﻿using System;

namespace BeautyLand.Application.Services.Site.Payments
{

    public class PaymentDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }


    }
}

