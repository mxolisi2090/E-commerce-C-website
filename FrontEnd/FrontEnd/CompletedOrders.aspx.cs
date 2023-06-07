using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class CompletedOrders : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            var UserID = Session["LoggedInUserID"]; 

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?userId=" + UserID + "&status=q").Result;
            var Comp = feature.Content.ReadAsAsync<List<Order>>().Result;

            string display = "";

            foreach (var a in Comp)
            {

                display += "<tr>";
                display += "<td class='hidden-xs'>";
                display += "<h5 class='product-title font-alt'>#</h5>";
                display += "</td>";
                display += "<td>";
                display += "<h5 class='product-title font-alt'>" + a.ItemNames + "</h5>";
                display += "</td>";

                display += "<td class='hidden-xs'>";
                display += "<h5 class='product-title font-alt'>R" + a.OrederPrice + "</h5>";
                display += "</td>";
                display += " <td>";
                display += "<h5 class='product-title font-alt'>" + a.Date + "</h5>";

                display += "</td>";
                display += "<td>";
                display += "<h5 class='product-title font-alt'>" + a.Status + "</h5>";
                display += "</td>";
                display += "<td>";
                display += "<a class='btn btn-border-d btn-circle'  href='Invoice.aspx?orderId=" + a.OrderId + "&Total=" + a.OrederPrice + "'>View Invoice</a></td>";
                display += "</tr>";

            }
            treport.InnerHtml = display;
        }
    }
}