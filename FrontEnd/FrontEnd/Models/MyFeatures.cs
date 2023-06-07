using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _218010450_FrontEndMini.Models
{
    public class MyFeatures
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductID { get; set; }
        public string FeatureName { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
    }
}