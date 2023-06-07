using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class FeaturesController : ApiController
    {

        DataClassesDataContext db = new DataClassesDataContext();

        //--------------Features--------------
        [HttpGet]
        public int addFeature(string name, string compname, string image, string description, double price)
        {

            var check = (from a in db.Features
                         where a.Name.Equals(name) && a.CompName.Equals(compname)
                         select a).FirstOrDefault();

            if (check == null)
            {
                Feature stock = new Feature
                {

                    Name = name,
                    CompName = compname,
                    Image = image,
                    Description = description,
                    Price = (decimal)price,

                };



                db.Features.InsertOnSubmit(stock);

                try
                {
                    db.SubmitChanges();
                    return stock.FeatureId;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -1;
                }

            }
            return -3;
        }

        [HttpGet]
        public int addFeatureStock(int itemId, string name, string description, double price, string supplier, int avaiblestock, int soldstock, int onspecial, string image, string Status)
        {
            FeatureStock stock = new FeatureStock
            {
                ItemId = itemId,
                Name = name,
                Description = description,
                Price = (decimal)price,
                Supplier = supplier,
                AvaibleStock = avaiblestock,
                Sold = soldstock,
                onSpecial = onspecial,
                Image = image,
                Status = Status,

            };

            if (stock == null) return -1;

            db.FeatureStocks.InsertOnSubmit(stock);

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

        [HttpGet]
        public Feature getFeature(int featureId)
        {

            var CartItem = (from b in db.Features
                            where b.FeatureId.Equals(featureId)
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public List<Feature> getAllFeatures()
        {

            var allitems = (from U in db.Features

                            select U);
            List<Feature> ports = new List<Feature>();

            foreach (Feature comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }
    }
}