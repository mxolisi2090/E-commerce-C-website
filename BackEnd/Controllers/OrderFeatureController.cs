using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class OrderFeatureController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public List<OrderFeature> GetItem(int orderId)
        {
            var items = (from i in db.OrderFeatures
                         where i.OrderId.Equals(orderId)
                         select i);

            List<OrderFeature> listParts = new List<OrderFeature>();

            foreach (OrderFeature sound in items)
            {
                listParts.Add(sound);
            }

            return listParts;
        }
    }
}