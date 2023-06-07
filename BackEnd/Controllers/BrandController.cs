using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class BrandController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();


        [HttpGet]
        public bool removeFromCart(int ItemID)
        {
            var ItemExists = (from book in db.Brands
                              where book.BrandId.Equals(ItemID)
                              select book).FirstOrDefault();

            if (ItemExists == null)
            {
                return false;
            }

            db.Brands.DeleteOnSubmit(ItemExists);

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
        public int AddCategory(string categoryName, string image,string rating)
        {
            var compExist = (from i in db.Brands
                             where i.Name.Equals(categoryName)
                             select i).FirstOrDefault();


            if (compExist == null)
            {

                var Additem = new Brand
                {
                    Name = categoryName,
                    Image = image,
                    Rating=rating,
                };
                db.Brands.InsertOnSubmit(Additem);

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




        [HttpGet]
        public List<Brand> GetAllBrands()
        {
            var items = (from i in db.Brands

                         select i);

            List<Brand> listBrand = new List<Brand>();

            foreach (Brand wear in items)
            {
                listBrand.Add(wear);
            }

            return listBrand;
        }

        [HttpGet]
        public Brand getBrandInfo(string BrandName, int val)
        {
            var CartItem = (from b in db.Brands
                            where b.Name.Equals(BrandName)
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public Brand getBrandInfoById( int val)
        {
            var CartItem = (from b in db.Brands
                            where b.BrandId.Equals(val)
                            select b).FirstOrDefault();

            return CartItem;
        }






    }
}