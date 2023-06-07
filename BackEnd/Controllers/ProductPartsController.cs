using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class ProductPartsController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public List<Feature> GetItemByCartegory(string compName)
        {
            var items = (from i in db.Features
                         where i.CompName.Equals(compName)
                         select i);

            List<Feature> listParts = new List<Feature>();

            foreach (Feature sound in items)
            {
                listParts.Add(sound);
            }

            return listParts;
        }

       
        [HttpGet]
        public bool removeFromFeatures(int userId, string featureName)
        {
            var ItemExists = (from book in db.MyProdFeatures
                              where book.UserId.Equals(userId) && book.FeatureName.Equals(featureName)
                              select book).FirstOrDefault();

            if (ItemExists == null)
            {
                return false;
            }

            db.MyProdFeatures.DeleteOnSubmit(ItemExists);

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
        public Feature getCompInfo(string itemName)
        {
            var CartItem = (from b in db.Features
                            where b.Name.Equals(itemName)
                            select b).FirstOrDefault();

            return CartItem;
        }



        [HttpGet]
        public int AddMyProductFeature(int userId, int proId,string featureName,string status,double Price)
        {
            var checkFeature = (from u in db.MyProdFeatures
                                where u.UserId.Equals(userId) && u.ProductID.Equals(proId) && u.FeatureName.Equals(featureName) 
                                select u).FirstOrDefault();


            if (checkFeature == null)
            {
                MyProdFeature newItem = new MyProdFeature
                {

                    UserId = userId,
                    ProductID = proId,
                    FeatureName = featureName,
                    Status = status,
                    Price=Convert.ToDecimal(Price),

                };
                db.MyProdFeatures.InsertOnSubmit(newItem);

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
                return 0;
            }
        }

        [HttpGet]
        public List<MyProdFeature> GetItemByCartegory(int userId, int prodId)
        {
            var items = (from i in db.MyProdFeatures
                         where i.UserId.Equals(userId) && i.ProductID.Equals(prodId) 
                         select i);

            List<MyProdFeature> listParts = new List<MyProdFeature>();

            foreach (MyProdFeature sound in items)
            {
                listParts.Add(sound);
            }

            return listParts;
        }


       


        [HttpGet]
        public List<CartFeature> GetItem(int cartId)
        {
            var items = (from i in db.CartFeatures
                         where i.refId.Equals(cartId)
                         select i);

            List<CartFeature> listParts = new List<CartFeature>();

            foreach (CartFeature sound in items)
            {
                listParts.Add(sound);
            }

            return listParts;
        }



        [HttpGet]
        public int AddFeature(int cartId, string featureName, Double price)
        {
            
                CartFeature newItem = new CartFeature
                {
                    refId = cartId,
                    FeatureName = featureName,
                    Price = (decimal)price,

                };
                db.CartFeatures.InsertOnSubmit(newItem);

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
           
        }


    }

