using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    public class ComponentFeaturesController : ApiController
    {
        DataClassesDataContext db = new DataClassesDataContext();

        [HttpGet]
        public int addFeature(int featureId,int compId)
        {

            var check = (from a in db.ComponentFeatures
                         where a.FeatureId.Equals(featureId) && a.ComponentId.Equals(compId)
                         select a).FirstOrDefault();

            if (check == null)
            {
                ComponentFeature feature = new ComponentFeature
                {

                    FeatureId= featureId,       
                    ComponentId= compId,
                };



                db.ComponentFeatures.InsertOnSubmit(feature);

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

        [HttpGet]
        public bool removeFromFeatures(int featureid, int compId, int val)
        {
            var ItemExists = (from book in db.ComponentFeatures
                              where book.FeatureId.Equals(featureid) && book.ComponentId.Equals(compId)
                              select book).FirstOrDefault();

            if (ItemExists == null)
            {
                return false;
            }

            db.ComponentFeatures.DeleteOnSubmit(ItemExists);

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
        public List<ComponentFeature> getAllFeatures()
        {

            var allitems = (from U in db.ComponentFeatures

                            select U);
            List<ComponentFeature> ports = new List<ComponentFeature>();

            foreach (ComponentFeature comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

        [HttpGet]
        public ComponentFeature getFeatureInfo(int featureId,int compId,string me)
        {
            var CartItem = (from b in db.ComponentFeatures
                            where b.FeatureId.Equals(featureId) && b.ComponentId.Equals(compId)
                            select b).FirstOrDefault();

            return CartItem;
        }

        [HttpGet]
        public List<ComponentFeature> getAllFeatures(int compId)
        {

            var allitems = (from U in db.ComponentFeatures
                            where U.ComponentId.Equals(compId) 
                            select U);
            List<ComponentFeature> ports = new List<ComponentFeature>();

            foreach (ComponentFeature comp in allitems)
            {
                ports.Add(comp);
            }
            return ports;
        }

    }
}