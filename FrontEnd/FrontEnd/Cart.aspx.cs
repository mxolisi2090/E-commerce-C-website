using _218010450_FrontEndMini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace _218010450_FrontEndMini
{
    public partial class Cart : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {


            var UserID = Session["LoggedInUserID"];
            
            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?userId=" + UserID).Result;
            var Comp = feature.Content.ReadAsAsync<List<CartItem>>().Result;


            string display = "";
            string dis = "";
            string ord = "";
            double Total = 0;
            double featurePrice = 0;

            var idList = new List<int>();
            var itemId = new List<string>();

            Session["SessionList"] = new ArrayList();

            ArrayList cart1 = new ArrayList();
            ArrayList items = new ArrayList();
            ArrayList orde = new ArrayList();
            ArrayList cartIds = new ArrayList();

            double total = 0;

            foreach (var a in Comp)
            {
                
                HttpResponseMessage item = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?itemID=" + a.ItemId).Result;
                var itemDetails = item.Content.ReadAsAsync<Component>().Result;

                HttpResponseMessage brand = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?BrandName=" + itemDetails.BrandName+ "&val=1" ).Result;
                var brandDetails = brand.Content.ReadAsAsync<Brand>().Result;

               
                

                display += "<tr>";
                display += "<td class='hidden-xs'><a href ='#' ><img src='"+ itemDetails.Image+ "' alt='Accessories Pack'/></a></td>";
                display += "<td>";
                display += "<h4 class='product-title font-alt'>" + brandDetails.Name + "</h4>";
                display += "<h6 class='product-title font-alt'>" + itemDetails.Name + "</h6>";
                display += " </td>";
                display += "<td class='hidden-xs'>";

                HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?cartId=" + a.Id).Result;
                var fea = res.Content.ReadAsAsync<List<cartfeature>>().Result;
                foreach (var b in fea)
                {

                    
                    display += "<h6 class='product-title font-alt'>"+b.FeatureName+"</h6>";
                    
                    

                    HttpResponseMessage info = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?itemName=" + b.FeatureName).Result;
                    var featureInfo = info.Content.ReadAsAsync<feature>().Result;

                    featurePrice += featureInfo.Price;
                }
                





                display += "</td>";
                display += "<td>";



                display += "<input class='form-control' maxlength='4' size='4' runat='server' id='itemquantity" + a.ItemId + "' type='text' name='qty' value="+a.Quality + " >";

                display += "<a class='btn btn-border-d btn-circle' id='btnid"+a.ItemId+"'  onclick='sendQuant" + a.ItemId + "()' >Update</a>";

                display += "<script type='text/javascript'>";
                display += "function sendQuant" + a.ItemId + "(){";
                display += "var quant = document.getElementById('itemquantity" + a.ItemId + "').value;";
                display += "document.getElementById('btnid" + a.ItemId + "').href='Quality.aspx?QItem='+ quant + '&itemID=" + a.ItemId + "'; ";
                display += "}";
                display += "</script>";

                display += "</td>";

                total = (itemDetails.Price * a.Quality);

                total += featurePrice;

                display += " <td>";
                display += "<h5 class='product-title font-alt'>R" + total + "</h5>";
                display += "</td>";
                display += "<td class='pr-remove'><a href ='RemoveCart.aspx?itemId=" + a.ItemId + "' title='Remove'><i class='fa fa-times'></i></a></td>";
                display += "</tr>";

                Total += total;

                

                
               
                cart1.Add(itemDetails.PartId);
                items.Add(itemDetails.Name);
                cartIds.Add(a.Id);

                Session["SessionList"] = cart1;
                Session["SessionNames"] = items;
                Session["SessionCartIds"] = cartIds;
                //display += "<a class='btn btn-border-d btn-circle' id='btnid" + a.ItemId + "' onclick='sendQuant" + a.ItemId + "()' runat='server' type='submit'>Update</a>";
                Session["SessionOrder"] = orde.Add(a.Quality);
            }
            Session["List"] = itemId.ToList();
            Session["Listid"] = idList.ToList();
            //idList = itemId.Aggregate((acc, next) => acc + next);

            dis += "<tr>";
            dis += "<th>Cart Subtotal:</th>";
            dis += "<td>R"+ Total + "</td>";
            dis += "</tr>";
            dis += "<tr>";
            dis += "<th> Shipping Total:</th>";
            dis += "<td>R2.00 </td>";
            dis += "</tr>";
            dis += "<tr class='shop-Cart-totalprice'>";
            dis += "<th>Total :</th>";
            Total += 2;
            dis += "<td>R"+ Total + "</td>";
            dis += "</tr>";

            ord += "<a class='btn btn-lg btn-block btn-round btn-d' href='Checkout.aspx?Total="+Total+ "&status=Waiting&itemsIds"+ itemId + "' runat='server' type='submit'>Place Order</a>";
            ////ord += "<a class='btn btn-border-d btn-circle'  href='Order.aspx'><i class='fa fa-windows'></i> Customize</a>";

            //int rep = int.Parse(Request.QueryString["respo"]);
            //if (rep != -1)
            //{
            //    error.Attributes.Add("style", "color:green;");
            //    error.Text = "Order Added.";
            //    error.Visible = true;
            //}
            //if (rep == -1)
            //{
            //    error.Attributes.Add("style", "color:green;");
            //    error.Text = "Something went Added.";
            //    error.Visible = true;
            //}

            order.InnerHtml = ord;
            checkout.InnerHtml = dis;
            treport.InnerHtml = display;
        }
    }
}