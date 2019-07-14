﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class ItemViewModel
    {
        public Items Item { get; set; }
        public IEnumerable<VendorOrders> VendorOrders { get; set; }
        public IEnumerable<ClientOrders> ClientOrders { get; set; }
    }
}