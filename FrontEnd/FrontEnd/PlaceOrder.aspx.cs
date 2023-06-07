using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class PlaceOrder : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var total = Request.QueryString["Total"];
            var status = Request.QueryString["status"];
            List<string> itemId = (List<string>)Session["List"];



            //HttpResponseMessage feature = client.GetAsync("https://localhost:44311/api/Components?userId=" + UserID).Result;
            //var Comp = feature.Content.ReadAsAsync<List<CartItem>>().Result;

            string cartItems;
            //var names = new List<string>();
            //foreach (var a in itemId)
            //{








            //    names.Add(itemDetails.Name.ToString() + ",");
            //}

            cartItems = itemId.Aggregate((acc, next) => acc + next);

            HttpResponseMessage order = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Orders?userID=" + UserID + "&price=" + total + "&status=" + status + "&itemname=" + cartItems).Result;
            var omp = order.Content.ReadAsAsync<int>().Result;

            if (omp == 1)
            {
                basicModal.Visible=true;
                //Response.Redirect("Cart.aspx?respo=" + omp);
            }
        }
    }
}