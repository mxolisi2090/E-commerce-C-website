using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.PeerToPeer.Collaboration;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _218010450_FrontEndMini
{
    public partial class ProductList : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            string BrandName = Request.QueryString["BrandName"];
            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?brandName=" + BrandName + "&val=1").Result;
            var parts = respond.Content.ReadAsAsync<List<Component>>().Result;

            string display = "";
           

           

            string image = Request.QueryString["Image"];

            Session["image"] = image;

            foreach (var z in parts)
            {
                
                
                display += "<div class='row'>";


                display += "<div class='col-sm-6'>";

                display += "<div class='owl-item'>";
                display += "<div class='col-sm-50'>";
                display += "<div class='work-item'><a href='#'>";
                display += "<div class='work-image'><img src='"+z.Image+"'alt='Portfolio Item'/></div>";
                display += "<h4 class='shop-item-title font-alt'><a ><strong>"+z.Name+"</strong></a></h4>";
                display += "<h4 class='shop-item-title font-alt'><a >R" + z.Price + "</a></h4>";
                //display += "<h5 class='shop-item-title font-alt'><a >"+ name + "</a></h5>";
                display += "</a></div>";
                display += "</div>";
                display += "</div>";

                display += "</div>";
                display += "<div class='col-sm-5'>";
                display += "<div class='row'>";
                display += "<form class='form rqst-form' id='requestACall' role='form' method='post' action='php/request_call.php'>";

                display += "<div class='text-center'>";
                display += "<div class='btn-group mt-30'>";
                display += "<a class='btn btn-border-d btn-circle' id='customize' runat='server' href='AddToCart.aspx?compId=" + z.PartId + "&Price=" + z.Price+"&BrandName="+ BrandName + "&compName="+z.Name+"'><i class='fa fa-android'></i> Add to Cart</a>";
                //Session["CompName"] = z.Name;
                display += "<a class='btn btn-border-d btn-circle'  href='CustomizeProduct.aspx?compId="+z.PartId+"&compName="+z.Name+"&brand="+ BrandName + "&compPrice="+z.Price+"'><i class='fa fa-windows'></i> Customize</a></div>";
                display += "</div>";


                display += "</form>";
                display += "</div>";
                display += "</div>";
                display += "</div>";

            }
           


            treport.InnerHtml = display;
        }
     }
}