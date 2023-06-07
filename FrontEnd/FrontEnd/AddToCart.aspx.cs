using _218010450_FrontEndMini.Models;
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
    public partial class AddToCart : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            //var brand = Session["BrandName"];

            int compId = Convert.ToInt32(Request.QueryString["compId"]);
            var compname = Request.QueryString["compName"];
            var brandname = Request.QueryString["BrandName"];
            // var itemid = Request.QueryString["compId"];
            double price = Convert.ToDouble(Request.QueryString["Price"]);
            //var itemID = Request.QueryString["itemID"];

            int cartId = 0;

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?userID="+ UserID + "&price="+ price + "&ItemID="+ compId).Result;
            var count = respond.Content.ReadAsAsync<int>().Result;
            if (count != -1 && count != -3 && count!= 2)
            {
                cartId = count;
                HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&prodId="+ compId).Result;
                var fea = res.Content.ReadAsAsync<List<MyFeatures>>().Result;
                foreach (var a in fea)
                {
                    HttpResponseMessage cartfea = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?cartId=" + cartId + "&featureName="+a.FeatureName+"&price="+a.Price).Result;
                    var well = cartfea.Content.ReadAsAsync<int>().Result;

                    HttpResponseMessage remove = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&featureName=" + a.FeatureName).Result;
                    var refback = remove.Content.ReadAsAsync<Boolean>().Result;

                }

                Response.Redirect("CustomizeProduct.aspx?compId=" + compId+ "&compName="+ compname);
            }
            if(count == 2)
            {
                Response.Redirect("ProductList.aspx?BrandName=" + brandname + "&compName="+ compname);
            }
            if (count == -3)
            {
                Response.Redirect("ProductList.aspx?BrandName=" + brandname + "&compName="+ compname);
            }
        }
    }
}