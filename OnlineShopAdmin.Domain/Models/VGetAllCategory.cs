﻿ 
#nullable disable
using System;
using System.Collections.Generic;

namespace  OnlineShopAdmin.Domain.Models
{
    public partial class VGetAllCategory
    {
        public string ParentProductCategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}