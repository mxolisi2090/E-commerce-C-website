using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _218010450_FrontEndMini.Models
{
    public class feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public string CompName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}