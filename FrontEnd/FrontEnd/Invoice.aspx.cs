using _218010450_FrontEndMini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class Invoice : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var oderId = Request.QueryString["orderId"];
            var OrderTotal = Request.QueryString["Total"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?itemID=" + oderId).Result;
            var Comp = feature.Content.ReadAsAsync<Order>().Result;
            
            HttpResponseMessage user = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userId=" + Comp.OrderUserId).Result;
            var omp = user.Content.ReadAsAsync<User>().Result;


            HttpResponseMessage comp = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderItems?UserId=" + UserID + "&orderId=" + oderId).Result;
            var zomp = comp.Content.ReadAsAsync<List<OrderItem>>().Result;
            
            ArrayList names = new ArrayList();

            names = (ArrayList)Session["SessionNames"];

            //int val = 0;
            List<string> cartItems = new List<string>();

            string val = "";

            string display = "";

            display += "<div class='container'>";
            display += "";
            display += "<div class='brand-section'>";
            display += "<div class='row'>";
            display += "<div class='col-6'>";    
            display += "<h1 class='text-white'>Stomzy Sound Electronics Invoice</h1>";        
            display += "</div>";    
            display += "<div class='col-6'>";    
            display += "<div class='company-details'>";        
            display += "<p class='text-white'><strong>Stomzy Soound Electronics</strong></p>";            
            display += "<p class='text-white'><strong>Stomzy Soound Electronics@Gmail.com</strong></p>";            
            display += "<p class='text-white'><strong>+27 6207 94750</strong></p>";            
            display += "</div>";        
            display += "</div>";   
            display += "</div>";
            display += "</div>";

            display += "<div class='body-section'>";
            display += "<div class='row'>";
            display += "<div class='col-6'>";    
            display += "<h2 class='heading'><strong>Invoice No. : " + Comp.OrderId+ "</strong></h2>";        
            display += "<p class='sub-heading'><strong>Tracking No.fabcart2025</strong></p>";        
            display += "<p class='sub-heading'><strong>Order Date : " + Comp.Date+ "</strong></p>";        
            display += "<p class='sub-heading'><strong>Email Address : " + omp.Email+ "</strong></p>";        
            display += "</div>";    
            display += "<div class='col-6'>";    
            display += "<p class='sub-heading'><strong>Full Name : " + omp.Name+ "  </strong></p>";        
            display += "<p class='sub-heading'><strong>Address : " + omp.Address+ " </strong></p>";        
            display += "<p class='sub-heading'><strong>Phone Number : " + omp.Number+ "  </strong></p>";        
            //display += "<p class='sub-heading'>City,State,Pincode:  </p>";        
            display += "</div>";    
            display += "</div>";
            display += "</div>";

           display += "<div class='body-section'>";
           display += "<h3 class='heading'>Ordered Items</h3>";  
           display += "<br>"; 
           display += "<table class='table-bordered'>"; 
           display += "<thead>";     
           display += "<tr>";         
           display += "<th>Product</th>";
            //display += "<th class='w-20'>Features</th>";
            display += "<th class='w-20'>Price</th>";             
           display += "<th class='w-20'>Quantity</th>";             
           display += "<th class='w-20'>Grandtotal</th>";             
           display += "</tr>";        
           display += "</thead>";     
           display += "<tbody>";

            double totalGrand = 0;
            double taxedGrand = 0;
            double grandTot = 0;
            double grandRot = 0;
            foreach (var a in zomp)
            {
               
                HttpResponseMessage zoo = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?itemID=" + a.ItemId).Result;
                var world = zoo.Content.ReadAsAsync<Component>().Result;

                HttpResponseMessage orderF = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderReport?val=as&val2=sa").Result;
                var orld = orderF.Content.ReadAsAsync<List<OrderFeature>>().Result;

                String ME = "";
                ME += "( )";
                foreach (var b in orld)
                {

                }
                
                display += "<tr>";

                //-----------------------Product and It Features-------------------------\\
                display += "<td>";
                display += "<h4 class='product-title font-alt'><strong>" + world.Name.ToUpper() + "</strong></h4>";

                HttpResponseMessage orderfeature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderFeature?orderId=" + oderId).Result;
                var fea = orderfeature.Content.ReadAsAsync<List<OrderFeature>>().Result;
                foreach (var b in fea)
                {

                    HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?cartId=" + b.CartId).Result;
                    var cartInfo = res.Content.ReadAsAsync<List<cartfeature>>().Result;

                    foreach (var c in cartInfo)
                    {
                        display += "<h5 class='product-title font-alt'>Feature " + ">> " + c.FeatureName + "</h5>";
                    }
                }
                display += "</td>";


                //-----------------------Price[Product and It Features]-------------------------\\
                display += "<td>";

                display += "<h4 class='product-title font-alt'>R"  + world.Price + "</h4>";
               
                foreach (var b in fea)
                {

                    HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?cartId=" + b.CartId).Result;
                    var cartInfo = res.Content.ReadAsAsync<List<cartfeature>>().Result;

                    foreach (var c in cartInfo)
                    {
                        display += "<h5 class='product-title font-alt'>" + ">> R" + c.Price + "</h5>";
                        totalGrand += c.Price;
                    }

                }
                totalGrand += world.Price;
                display += "</td>";

                display += "</td>";

                //display += "<td>R"+ world.Price + "</td>";


                display += "<td>"+a.Quality+"</td>";
                grandTot = (a.Quality * totalGrand);
                display += "<td>R"+ grandTot + "</td>";
                display += "</tr>";

                
               
               
            }
            taxedGrand = grandTot / 14;
            grandRot += grandTot;

            display += " <tr>";        
           display += "<td colspan='3' class='text-right'>Sub Total</td>";             
           display += "<td> R"+ grandRot + "</td>";             
           display += "</tr>";         
           display += "<tr>";         
           display += "<td colspan ='3' class='text-right'>Tax Total %14X</td>";             
           display += "<td>R"+ taxedGrand.ToString("0,00") + "</td>";             
           display += "</tr>";         
           display += "<tr>"; 
            
           display += "<td colspan='3' class='text-right'>Grand Total</td>";            
           display += "<td>R"+ (grandRot-taxedGrand).ToString("0,00") + "</td>";             
           display += "</tr>";         
           display += "</tbody>";     
           display += "</table>"; 
           display += "<br>"; 
           display += "<h3 class='heading'>Payment Status: Paid</h3>"; 
           display += "<h3 class='heading'>Payment Mode: Cash on Delivery</h3>"; 
           display += "</div>";

           display += "<div class='body-section'>";
           display += "<p>&copy; Copyright 2022 - Fabcart.All rights reserved."; 
           display += "<a href ='https://www.fundaofwebit.com/' class='float-right'></a>";     
           display += "</p>"; 
           display += "</div>";      
           display += "</div>";

            treport.InnerHtml = display;
        }
    }
}