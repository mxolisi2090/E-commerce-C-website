using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class RemoveCart : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            //var brand = Session["BrandName"];

            var itemid = Request.QueryString["itemId"];
            //var itemID = Request.QueryString["itemID"];

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?ItemCartID=" + itemid + "&userId=" + UserID).Result;
            var count = respond.Content.ReadAsAsync<Boolean>().Result;
            if (count == true)
            {
                Response.Redirect("cart.aspx");
            }

        }
    }
}