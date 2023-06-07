using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class ComponentsController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();


        


        [HttpGet]
        public int AddComponent(string compName,string brandname,string image,double price,string status,string description)
        {
            var compExist=(from i in db.Components
                           where i.Name.Equals(compName) && i.BrandName.Equals(brandname)
                           select i).FirstOrDefault();
            

            if (compExist == null)
            {

                var Additem = new Component
                {
                   Name = compName,
                   BrandName= brandname,    
                   Image= image,
                   Price=(decimal)price,
                   Status=status,
                   Description=description

                };
                db.Components.InsertOnSubmit(Additem);

                try
                {
                    db.SubmitChanges();
                    return Additem.PartId;
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
        public List<Component> getComponents(string brandName)
        {

            var allitems = (from U in db.Components
                            where U.BrandName.Equals(brandName)
                            select U);
            List<Component> ports = new List<Component>();

            foreach (Component comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

        [HttpGet]
        public List<Component> getAllComponents()
        {

            var allitems = (from U in db.Components
                           
                            select U);
            List<Component> ports = new List<Component>();

            foreach (Component comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }


        [HttpGet]
        public List<Component> GetComponents(int BrandId)
        {
            var items = (from i in db.Components
                         where i.BrandName.Equals(BrandId)
                         select i);

            List<Component> listComp = new List<Component>();

            foreach (Component wear in items)
            {
                listComp.Add(wear);
            }

            return listComp;
        }


        public List<Component> getComp(string brandName,int val)
        {

            var allitems = (from U in db.Components
                            where U.BrandName.Equals(brandName)
                            select U);
            List<Component> ports = new List<Component>();

            foreach (Component comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }


        [HttpGet]
        public Component getCompInfo(int itemID)
        {
            var CartItem = (from b in db.Components
                            where b.PartId.Equals(itemID) 
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public Component getCompInfoByName(string name,int itemID)
        {
            var CartItem = (from b in db.Components
                            where b.Name.Equals(name)
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public bool removeFromCart(int ItemCartID)
        {
            var ItemExists = (from book in db.Components
                              where book.PartId.Equals(ItemCartID) 
                              select book).FirstOrDefault();

            if (ItemExists == null)
            {
                return false;
            }

            db.Components.DeleteOnSubmit(ItemExists);

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


    }
}