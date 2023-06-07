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
    public partial class DeleteCategory : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var itemId = Request.QueryString["cateId"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?ItemID=" + itemId).Result;
            var Comp = feature.Content.ReadAsAsync<bool>().Result;

            if (Comp == true)
            {
                Response.Redirect("Blank.aspx");
            }else if (Comp == false)
            {
                Response.Redirect("Blank.aspx");
            }
        }
    }
}