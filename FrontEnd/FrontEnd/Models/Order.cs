using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _218010450_FrontEndMini.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double OrederPrice { get; set; }
        public int OrderUserId { get; set; }
        public string ItemNames { get; set; }

        public int ItemsIds { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}