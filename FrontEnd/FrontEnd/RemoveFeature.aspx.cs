using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class RemoveFeature : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            //var brand = Session["BrandName"];

            var name = Request.QueryString["featureName"];


            int compId = Convert.ToInt32(Request.QueryString["compId"]);
            var compname = Request.QueryString["compName"];

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&featureName=" + name).Result;
            var count = respond.Content.ReadAsAsync<Boolean>().Result;
            if (count == true)
            {
                Response.Redirect("CustomizeProduct.aspx?compId=" + compId+ "&compName="+ compname);
            }
        }
    }
}