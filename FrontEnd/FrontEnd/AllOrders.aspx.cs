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
    public partial class AllOrders : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            var UserID = Session["LoggedInUserID"];
            var total = Request.QueryString["Total"];
            var status = Request.QueryString["status"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?userId=" + UserID + "&status=Active").Result;
            var Comp = feature.Content.ReadAsAsync<List<Order>>().Result;

            string display = "";

            UpdateOrderStatus();

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
                display += "<a class='btn btn-border-d btn-circle'  href='MyOrders.aspx?status=" + a.Status + "&id=" + a.OrderId + "'>Update</a></td>";
                display += "</tr>";

            }
            // treport.InnerHtml = display;

        }
        public void UpdateOrderStatus()
        {
            string QueryStatus = Request.QueryString["status"];
            int QueryBookingId = Convert.ToInt32(Request.QueryString["id"]);
            string display = "";
            switch (QueryStatus)
            {
                case "Completed":
                    display += "<button type = 'button' class='btn mr-2 mb-2 btn-primary' data-toggle='modal' data-target='.bd-example-modal-sm'>Small modal</button>";
                    UpdateOrderStatus();

                    break;

                case "InProgress":
                    {


                        HttpResponseMessage countBooking = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?orderId=" + QueryBookingId + "&status=Completed").Result;
                        if (countBooking.IsSuccessStatusCode)
                        {
                            var booking = countBooking.Content.ReadAsAsync<int>().Result;
                        }
                    }
                    break;

                case "Waiting":
                    {
                        HttpResponseMessage countBooking = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?orderId=" + QueryBookingId + "&status=Inprogress").Result;
                        if (countBooking.IsSuccessStatusCode)
                        {
                            var booking = countBooking.Content.ReadAsAsync<int>().Result;
                        }
                    }
                    break;
            }
        }
    }

}