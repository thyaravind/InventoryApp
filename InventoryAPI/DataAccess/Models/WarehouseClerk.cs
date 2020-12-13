﻿using System;
using System.Collections.Generic;

#nullable disable

namespace modelscaffold.Model
{
    public partial class WarehouseClerk
    {
        public byte WarehouseId { get; set; }
        public string EmployeeId { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}