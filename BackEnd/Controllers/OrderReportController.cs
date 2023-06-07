using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class OrderReportController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public double getWaitingPerc()
        {
            double total = 0;
            double perc = 0;
            var countWaiting = (from c in db.Orders
                                where c.Status.Equals("Waiting")
                                select c).Count();

            var countInProgress = (from c in db.Orders
                                where c.Status.Equals("InProgress")
                                select c).Count();

            var countCompleted = (from c in db.Orders
                                where c.Status.Equals("Completed")
                                select c).Count();

            total = countWaiting + countInProgress + countCompleted;

            perc = (countWaiting / total) * 100;

            return perc;
        }

        [HttpGet]
        public double getInProgressPerc(int val)
        {
            double total = 0;
            double perc = 0;
            var countWaiting = (from c in db.Orders
                                where c.Status.Equals("Waiting")
                                select c).Count();

            var countInProgress = (from c in db.Orders
                                   where c.Status.Equals("InProgress")
                                   select c).Count();

            var countCompleted = (from c in db.Orders
                                  where c.Status.Equals("Completed")
                                  select c).Count();

            total = countWaiting + countInProgress + countCompleted;

            perc = (countInProgress / total) * 100;

            return perc;
        }

        [HttpGet]
        public double getCompletedPerc(string name)
        {
            double total = 0;
            double perc = 0;
            var countWaiting = (from c in db.Orders
                                where c.Status.Equals("Waiting")
                                select c).Count();

            var countInProgress = (from c in db.Orders
                                   where c.Status.Equals("InProgress")
                                   select c).Count();

            var countCompleted = (from c in db.Orders
                                  where c.Status.Equals("Completed")
                                  select c).Count();

            total = countWaiting + countInProgress + countCompleted;

            perc = (countCompleted / total) * 100;

            return perc;
        }

        [HttpGet]
        public List<OrderFeature> getAllFeatures(string val,string val2)
        {

            var allitems = (from U in db.OrderFeatures

                            select U);
            List<OrderFeature> ports = new List<OrderFeature>();

            foreach (OrderFeature comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

        [HttpGet]
        public List<CartFeature> getAllFeaInfo(string val, string val2,int num)
        {

            var allitems = (from U in db.CartFeatures
                            where U.refId.Equals(num)
                            select U);
            List<CartFeature> ports = new List<CartFeature>();

            foreach (CartFeature comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

        [HttpGet]
        public int addFeature(int orderId,int cartId)
        {

            var check = (from a in db.OrderFeatures
                         where a.CartId.Equals(cartId) && a.OrderId.Equals(orderId)
                         select a).FirstOrDefault();

            if (check == null)
            {
                OrderFeature stock = new OrderFeature
                {
                    OrderId = orderId,
                    CartId = cartId,
                    

                };



                db.OrderFeatures.InsertOnSubmit(stock);

                try
                {
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -1;
                }

            }
            return -3;
        }
    }
}