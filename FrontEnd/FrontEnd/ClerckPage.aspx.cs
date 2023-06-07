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
    public partial class ClerckPage : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpResponseMessage order = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders").Result;
            var omp = order.Content.ReadAsAsync<List<Order>>().Result;

            QueryString();

            string display = "";
            foreach (var a in omp)
            {

                HttpResponseMessage userdet = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userId=" + a.OrderUserId).Result;
                var clien = userdet.Content.ReadAsAsync<User>().Result;

                display += "<tr class='table-default'>";   
                         
                display += "<td><strong>"+ clien.Name+ "</strong></td>";        
                          
                display += "<td><strong>"+a.OrderId+"</strong></td>";       
                        
               display += "<td><strong>"+a.Date+"</strong></td>";        
                          
               display += "<td><strong>R"+a.OrederPrice+"</strong></td>";

                if (a.Status == "Waiting")
                {
                    display += "<td><span class='badge bg-label-primary me-1'>" + a.Status + "</span></td>";

                }else if(a.Status == "InProgress")
                {
                    display += "<td><span class='badge bg-label-info me-1'>" + a.Status + "</span></td>";
                }else if (a.Status == "Completed")
                {
                    display += "<td><span class='badge bg-label-success me-1'>" + a.Status + "</span></td>";
                }
                      
                          
               display += "<td>";
                
                display += "<a type='button' class='btn rounded-pill btn-success' href='ClerckPage.aspx?OrderId="+a.OrderId+"&status="+a.Status+ "'>Process</a>";
               display += "</td>";         
               display += "</tr>";       
            }
            treport.InnerHtml = display;
        }

        public void QueryString()
        {
            string orderStatus = Request.QueryString["status"];
            int QueryOrderId = Convert.ToInt32(Request.QueryString["OrderId"]);
            string display = "";
            switch (orderStatus)
            {
                case "Completed":
                    display += "<button type = 'button' class='btn mr-2 mb-2 btn-primary' data-toggle='modal' data-target='.bd-example-modal-sm'>Small modal</button>";
                    QueryString();

                    break;

                case "InProgress":
                    {


                        HttpResponseMessage countBooking = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?status=Completed&orderId=" + QueryOrderId + "&val=1" ).Result;
                        if (countBooking.IsSuccessStatusCode)
                        {
                            var booking = countBooking.Content.ReadAsAsync<int>().Result;
                        }
                    }
                    break;

                case "Waiting":
                    {
                        HttpResponseMessage countBooking = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?status=InProgress&orderId=" + QueryOrderId + "&val=1").Result;
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