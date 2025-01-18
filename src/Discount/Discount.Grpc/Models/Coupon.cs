﻿using System;

namespace Discount.Grpc.Models
{
    public class Coupon
    {
        public Int32 Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string Description { get; set; }  = default!;
        public string Discount { get; set; } = default!;
    }
}
