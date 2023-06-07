using _218010450_FrontEndMini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class MyOrders : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var total = Request.QueryString["Total"];
            var status = Request.QueryString["status"];

            HttpResponseMessage order = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?userId=" + UserID).Result;
            var Comp = order.Content.ReadAsAsync<List<Order>>().Result;

            string display="";

            ArrayList names = new ArrayList();

            names = (ArrayList)Session["SessionNames"];

            //int val = 0;
            List<string> cartItems = new List<string>();
           

            UpdateOrderStatus();

            foreach (var a in Comp)
            {
                
              display += "<tr>";
              display += "<td class='hidden-xs'>";
              display += "<h5 class='product-title font-alt'>#</h5>";        
              display += "</td>";         
              display += "<td>";

                HttpResponseMessage orderitem = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderItems?UserId="+ UserID + "&orderId="+ a.OrderId).Result;
                var OrderItem = orderitem.Content.ReadAsAsync<List<OrderItem>>().Result;

                foreach (var d in OrderItem)
                {
                    

                    HttpResponseMessage item = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?itemID=" +d.ItemId ).Result;
                    var itemDetails = item.Content.ReadAsAsync<Component>().Result;

                    display += "<h4 class='product-title font-alt'>" + itemDetails.Name+ "</h4>";




                    HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderFeature?orderId=" + a.OrderId).Result;
                    var fea = feature.Content.ReadAsAsync<List<OrderFeature>>().Result;
                    foreach (var b in fea)
                    {

                        HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?cartId=" + b.CartId).Result;
                        var cartInfo = res.Content.ReadAsAsync<List<cartfeature>>().Result;

                        foreach (var c in cartInfo)
                        {
                            display += "<h5 class='product-title font-alt'>"+">> " + c.FeatureName + "</h5>";
                        }
                    }

                }

                    display += "</td>";            

              display += "<td class='hidden-xs'>";      
              display += "<h5 class='product-title font-alt'>R"+a.OrederPrice+"</h5>";        
              display += "</td>";          
              display += " <td>";        
              display += "<h5 class='product-title font-alt'>"+a.Date+"</h5>";       
                        
             display += "</td>";              
             display += "<td>";         
             display += "<h5 class='product-title font-alt'>"+a.Status+"</h5>";         
             display += "</td>";
             display += "<td>";
             display += "<a class='btn btn-border-d btn-circle'  href='Invoice.aspx?orderId="+a.OrderId +"&Total="+a.OrederPrice+"'>View Invoice</a></td>";
             display += "</tr>";
               
            }
            treport.InnerHtml = display;
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
                        HttpResponseMessage countBooking = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?orderId=" + QueryBookingId + "&status=Inprogress" ).Result;
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