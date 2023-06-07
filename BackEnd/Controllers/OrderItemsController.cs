using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class OrderItemsController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public bool checkStock( int ItemID,int quality)
        {
            var checkstock = (from a in db.Stocks
                              where a.ItemId.Equals(ItemID)
                              select a).FirstOrDefault();

            if (checkstock != null)
            {
                if (checkstock.AvaibleStock >= 1)
                {
                    checkstock.AvaibleStock = checkstock.AvaibleStock - quality;

                    checkstock.Sold += quality;
                    return true;
                }
            }
            return false;
        }


        [HttpGet]
        public int AddOrderItem(int orderid, int itemId, int userId, int quality)
        {
            var compExist = (from i in db.OrderItems
                             where i.OrderId.Equals(orderid) && i.ItemId.Equals(itemId)
                             select i).FirstOrDefault();


            var checkstock = (from a in db.Stocks
                              where a.ItemId.Equals(itemId)
                              select a).FirstOrDefault();


            if (compExist == null)
            {


                if (checkstock!=null && checkstock.AvaibleStock>=0) {

                    var Additem = new OrderItem
                    {
                        OrderId = orderid,
                        ItemId = itemId,
                        UserId = userId,
                        Quality = quality,
                    };

                    checkstock.AvaibleStock = checkstock.AvaibleStock - quality;
                    checkstock.Sold += quality;

                    db.OrderItems.InsertOnSubmit(Additem);

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
                else
                {
                    return -3;
                }
            }
            else
            {
                return -4;
            }


        }

        [HttpGet]
        public List<OrderItem> getComponents(int UserId, int orderId)
        {

            var allitems = (from U in db.OrderItems
                            where U.OrderId.Equals(orderId)
                            select U);
            List<OrderItem> ports = new List<OrderItem>();

            foreach (OrderItem comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

        //[HttpGet]
        //public List<OrderItem> GetAllBrands()
        //{
        //    var items = (from i in db.OrderItems

        //                 select i);

        //    List<OrderItem> listBrand = new List<OrderItem>();

        //    foreach (OrderItem wear in items)
        //    {
        //        listBrand.Add(wear);
        //    }

        //    return listBrand;
        //}
    }
}