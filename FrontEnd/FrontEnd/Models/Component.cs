using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _218010450_FrontEndMini.Models
{
    public class Component
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}