using System;
using System.Collections.Generic;
using System.Net.Http;

namespace _218010450_FrontEndMini
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string cartIcon = "";
            var UserID = Session["LoggedInUserID"];

            if (UserID != null)
            {
                HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?value1=1&value2=1&UserID=" + UserID).Result;
                var Comp = feature.Content.ReadAsAsync<int>().Result;
                cartIcon += "<span class='cart-basket d-flex align-items-center justify-content-center' id='lblCartCount'>" + Comp + "</span>";
            }
            else
            {
                HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?value1=1&value2=1&UserID=" + 0).Result;
                var Comp = feature.Content.ReadAsAsync<int>().Result;
                custom.Visible=false;
            }
            


            treport.InnerHtml= cartIcon;
        }
    }
}