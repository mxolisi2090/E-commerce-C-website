using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _218010450_FrontEndMini.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Supplier { get; set; }
        public int AvaibleStock { get; set; }
        public int Sold { get; set; }
        public int onSpecial { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public int maxAmountStock { get; set; }
        public double Stockprice { get; set; }
    }
}