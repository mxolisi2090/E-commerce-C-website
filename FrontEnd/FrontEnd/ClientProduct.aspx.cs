using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _218010450_FrontEndMini
{
    public partial class ClientProduct : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];

            //Component details
            //string compName = Request.QueryString["compName"];
            //double compprice = Convert.ToDouble(Request.QueryString["compPrice"]);
           
           

            int compId= Convert.ToInt32(Request.QueryString["compId"]);
            var compname = Request.QueryString["compName"];

            //feature details
            string featureName = Request.QueryString["featureName"];
            double feeatureprice = Convert.ToDouble(Request.QueryString["featurePrice"]);
            string compoId = Request.QueryString["compId"];
            //HttpResponseMessage respond = client.GetAsync("https://localhost:44311/api/ProductParts?userId="+ UserID + "&compName="+ compName + "&price="+ compprice).Result;

            //var user = respond.Content.ReadAsAsync<int>().Result;
            //var Comp = respond.Content.ReadAsAsync<int>().Result;


            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&proId="+ compoId + "&featureName="+ featureName + "&status=Active&Price="+ feeatureprice).Result;
                var fea = feature.Content.ReadAsAsync<int>().Result;

                if (fea == 1)
                {
                    Response.Redirect("CustomizeProduct.aspx?compId=" + compId+ "&compName="+ compname);
                }

            if (fea == 0)
            {
                Response.Redirect("CustomizeProduct.aspx?compId=" + compId + "&compName=" + compname);
            }

        }
    }
}