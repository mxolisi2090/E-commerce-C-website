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
    public partial class Checkout : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var UserID = Session["LoggedInUserID"];
            var total = Request.QueryString["Total"];
            var status = Request.QueryString["status"];
            List<string> itemId = (List<string>)Session["List"];
            // var itemIds = (List<string>)Session["SessionList"];

           
            ArrayList names = new ArrayList();
            ArrayList itemIds = new ArrayList();
            ArrayList orderInfo = new ArrayList();
            ArrayList cartIds = new ArrayList();

            names =(ArrayList)Session["SessionNames"];
            itemIds = (ArrayList)Session["SessionList"];
            orderInfo = (ArrayList)Session["SessionList"];
            cartIds = (ArrayList)Session["SessionCartIds"];
            //int val = 0;
            List<string> cartItems=new List<string>();
           
            string val = "";
           
            foreach (var a in names)
            {
                
                cartItems.Add(a.ToString()+",");
                //names.Add(val);
                //a.Aggregate(out cartItems, (a1, a2) =>
                //names.Add(a.ToString());
                //val = a.Aggregate((acc, next) => (char)(acc + next));
                //names.Add(itemDetails.Name.ToString() + ",");
            }
            val = cartItems.Aggregate((acc,next)=>acc+next);

           

            HttpResponseMessage order = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?userID=" + UserID + "&price="+ total + "&status="+ status + "&itemname="+ val).Result;
            var omp = order.Content.ReadAsAsync<int>().Result;
           
            if (order.IsSuccessStatusCode)
            {

               

                    foreach (var b in itemIds)
                    {
                    HttpResponseMessage cartItem = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?itemID=" + b+"&userId=" + UserID).Result;
                    var qual = cartItem.Content.ReadAsAsync<CartItem>().Result;


                    HttpResponseMessage orderItem = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderItems?orderId=" + omp + "&ItemID="+ b + "&userId="+ UserID +"&quality="+ qual.Quality).Result;
                    var mark = orderItem.Content.ReadAsAsync<int>().Result; //"https://webapiminiproject218010450.azurewebsites.net/api/OrderItems?orderid=1&itemId=1&userId=1&quality=1"                   

                    HttpResponseMessage deleCart = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Cart?ItemCartID=" + b + "&userId=" + UserID).Result;
                    var ans = deleCart.Content.ReadAsAsync<bool>().Result;
                    }

                    foreach (var a in cartIds)
                    {
                        HttpResponseMessage orderfeature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderReport?orderId=" + omp + "&cartId=" + a).Result;
                        var info = orderfeature.Content.ReadAsAsync<int>().Result;
                    }


                Response.Redirect("Cart.aspx?respo=" + omp);

            }
            else
            {
                Response.Redirect("Cart.aspx?respo=" + omp);
            }
        }
    }
}