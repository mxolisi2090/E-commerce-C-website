using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class AddFeature : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        string me = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpResponseMessage comp = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components").Result;
            var omp = comp.Content.ReadAsAsync<List<Component>>().Result;
            string display = "";
            string well = "";


            //display += "<select id='country' runat='server' class='select2 form-select'>";
            //foreach (var a in omp)
            //{
                
            //    display += "<option onclick='sendQuant" + a.PartId + "()' runat='server'  value='" + a.PartId+"'>" + a.Name + "</option>";

            //    well += "<script type='text/javascript'>";
            //    well += "function sendQuant" + a.PartId + "(){";
            //    well += "var quant = document.getElementById('country').value;";
            //    well += "document.getElementById('country').href='AddFeature.aspx?QItem='+ quant '; ";
            //    well += "}";
            //    well += "</script>";
            //}
            // display += "</select>";


            display += "<div class='divider'></div>";
            display += "<select class='mb-2 form-control-lg form-control'>";
            foreach (var r in omp)
            {
                

                    display += "<option>" + r.Name + "</option>";
                well = r.Name;
                

            }
            display += "  </select>";



            var total = well;

            treport.InnerHtml = display;
        }

        protected void addFeatureClicked(object sender, EventArgs e)
        {
            me = me;
        }
    }
}