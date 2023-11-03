﻿using Database.Entities;
using Database.JoinTables;

namespace Database.Dtos.Admin.Get
{
    public class PackageGetDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public double PackagePriceValue { get; set; }
        public double PackageDiscountValue { get; set; }
    }
}
