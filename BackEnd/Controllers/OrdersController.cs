using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{

    public class OrdersController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public double? countAverageRating(int count,int stylistID,string status)
        {
            double percen=0;
            var countBooking = (from c in db.Orders
                                where c.Status.Equals(status)
                                select c).Count();

            var total = (from c in db.Orders
                         select c).Count();

            percen = countBooking/total*100 ;


            return percen;
        }

        [HttpGet]
        public List<Order> GetCartItems(int userId)
        {
            var items = (from i in db.Orders
                         where i.OrderUserId.Equals(userId) && i.Status.Equals("Waiting") ||i.Status.Equals("InProgress")
                         select i);

            List<Order> listComp = new List<Order>();

            foreach (Order wear in items)
            {
                listComp.Add(wear);
            }

            return listComp;
        }

        [HttpGet]
        public List<Order> getSock(int userId, string status)
        {

            var allorder = (from U in db.Orders
                            where U.OrderUserId.Equals(userId) && U.Status.Equals("Completed")
                            select U);

            List<Order> reports = new List<Order>();

            foreach (Order item in allorder)
            {
                reports.Add(item);
            }
            return reports;
        }


        [HttpGet]
        public bool removeFromCart(int userId,int val,int val2)
        {
            var ItemExists = (from book in db.Carts
                              where book.UserId.Equals(userId)
                              select book);

            List<Cart> reports = new List<Cart>();

            if (ItemExists == null)
            {
                return false;
            }

            foreach (Cart item in ItemExists)
            {
                reports.Add(item);
            }

           // db.Carts.DeleteOnSubmit();
             
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return false;
            }
        }

        [HttpGet]
        public int PlaceOrder(int userID, double price, string status, string itemname)
        {

            var check = (from u in db.Orders
                         where u.OrderUserId.Equals(userID) && u.Status.Equals(status)
                         select u).FirstOrDefault();



            string[] strings = new string[1];
            strings = itemname.Split();

            var AddOrder = new Order
            {
                OrederPrice = (decimal)price,
                Date = DateTime.Today,
                OrderUserId = userID,
                Status = status,//
                ItemNames = strings.FirstOrDefault(),
                ItemsIds=1,
            };
            db.Orders.InsertOnSubmit(AddOrder);

            try
            {
                db.SubmitChanges();
               // removeFromCart();
                return AddOrder.OrderId;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -1;
            }
        }

        [HttpGet]
        public List<Order> getAllUsers()
        {
            List<Order> ord = new List<Order>();

            dynamic test = from u in db.Orders select u;

           
                foreach (Order u in test)
                {
                    ord.Add(u);
                }
            
            return ord;
        }

        [HttpGet]
        public Order getCompInfo(int itemID)
        {
            var CartItem = (from b in db.Orders
                            where b.OrderId.Equals(itemID)
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public int editStatus(string status, int orderId,int val)
        {
            var user = (from b in db.Orders
                        where b.OrderId.Equals(orderId)
                        select b).FirstOrDefault();

            user.Status = status;
            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (IndexOutOfRangeException ex)
            {
                ex.GetBaseException();
                return -1;
            }
        }
    }
}