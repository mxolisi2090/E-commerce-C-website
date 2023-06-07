using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace _218010450_FrontEndMini
{
    public partial class Shop : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];


            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand").Result;
            var brand = respond.Content.ReadAsAsync<List<Brand>>().Result;

            string display = "";

            foreach (var x in brand)
            {

                //display += "<div class='row multi-columns'>";
                display += "<div class='col-sm-8 col-md-4 col-lg-4'>";
                display += "<div class='shop-item'>";
                display += "<div class='shop-item-image'><img src='" + x.Image + "'width='150' height='150' alt='Accessories Pack'/>";
                display += "<div class='shop-item-detail'><a class='btn btn-round btn-b' href='ProductList.aspx?BrandName=" + x.Name+"&Image="+x.Image+ "&BandID="+x.BrandId+ "'><span class='icon-basket'>My Product</span></a></div>";
                display += "</div>";
                display += "<h4 class='shop-item-title font-alt'><a href ='#'><strong>" + x.Name + "</strong></a></h4>";
                display += "</div>";
                display += "</div>";
                //display += "</div>";

            }

            treport.InnerHtml = display;
        }
    }
}