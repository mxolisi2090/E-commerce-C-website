using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class CartController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public int AddToCart(int userID,double price, int ItemID)
        {
            var checkFeature = (from a in db.MyProdFeatures
                                where a.UserId.Equals(userID) 
                                select a).FirstOrDefault();

            if (checkFeature == null)
            {
                var check = (from u in db.Carts
                             where u.UserId.Equals(userID) && u.ItemId.Equals(ItemID)
                             select u).FirstOrDefault();


                if (check == null)
                {

                    var Additem = new Cart
                    {
                        Amount = (decimal)price,
                        Date = DateTime.Today,
                        UserId = userID,
                        ItemId = ItemID,//
                        Quality = 1,

                    };
                    db.Carts.InsertOnSubmit(Additem);

                    try
                    {
                        db.SubmitChanges();
                        return 2;
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
            else if(checkFeature != null)
            {
                var Additem = new Cart
                {
                    Amount = (decimal)price,
                    Date = DateTime.Today,
                    UserId = userID,
                    ItemId = ItemID,//
                    Quality = 1,

                };
                db.Carts.InsertOnSubmit(Additem);

                try
                {
                    db.SubmitChanges();
                    return Additem.Id;
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

        [HttpGet]
        public bool removeFromCart(int ItemCartID, int userId)
        {
            var ItemExists = (from book in db.Carts
                              where book.ItemId.Equals(ItemCartID) && book.UserId.Equals(userId)
                              select book).FirstOrDefault();

            if (ItemExists == null)
            {
                return false;
            }

            db.Carts.DeleteOnSubmit(ItemExists);

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

        public int updateQuality(int quality, int itemIdentity, int userCartId)
        {

            var getAppoint = (from u in db.Carts
                              where u.ItemId.Equals(itemIdentity) && u.UserId.Equals(userCartId)
                              select u).FirstOrDefault();

            //If user does not exist
            if (getAppoint == null)
                return -1;


            getAppoint.Quality = quality;

            try
            {
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return -2;
            }

        }

        [HttpGet]
        public List<Cart> GetCartItems(int userId)
        {
            var items = (from i in db.Carts
                         where i.UserId.Equals(userId)
                         select i);

            List<Cart> listComp = new List<Cart>();

            foreach (Cart wear in items)
            {
                listComp.Add(wear);
            }

            return listComp;
        }

        [HttpGet]
        public Cart getCompInfo(int itemID,int userId)
        {
            var CartItem = (from b in db.Carts
                            where b.ItemId.Equals(itemID) && b.UserId.Equals(userId)        
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public int countCartItems(int value1, int value2, int UserID)
        {
            var countBooking = (from c in db.Carts
                                where c.UserId.Equals(UserID)
                                select c).Select(c => c.UserId).Count();

            return countBooking;
        }
    }
}