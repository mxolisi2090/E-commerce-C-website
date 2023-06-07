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
    public partial class AddStock : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var stockId = Request.QueryString["stockId"];
            var status = Request.QueryString["status"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?stockId=" + stockId).Result;
            var Comp = feature.Content.ReadAsAsync<Stock>().Result;

            name.Value = Comp.Name;
        }

        protected void addStockClicked(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var stockId = Request.QueryString["stockId"];
            var status = Request.QueryString["status"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?stockId=" + stockId + "&available="+ available.Value+ "&capacity=1").Result;
            var Comp = feature.Content.ReadAsAsync<int>().Result;

            if (Comp == 1)
            {
                error.Attributes.Add("style", "color:green;");
                error.Text = "Stock Added.";
                error.Visible = true;
            }else if (Comp == -1)
            {
                error.Attributes.Add("style", "color:green;");
                error.Text = "Stock Not Found.";
                error.Visible = true;
            }else if (Comp == -2)
            {
                error.Attributes.Add("style", "color:green;");
                error.Text = "Stock Not Added.";
                error.Visible = true;
            }
        }


    }
}