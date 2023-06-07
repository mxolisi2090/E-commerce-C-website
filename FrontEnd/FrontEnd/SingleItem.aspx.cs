using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class ClothCart : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var total = Request.QueryString["compId"];

            HttpResponseMessage cartItem = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?ItemCartID=" + total).Result;
            var qual = cartItem.Content.ReadAsAsync<bool>().Result;

            if (qual == true)
            {
                Response.Redirect("AdminListComp.aspx");
            }
            else
            {
                Response.Redirect("AdminListComp.aspx");
            }
        }
    }
}