using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class NotAssigList : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int compId =Convert.ToInt32(Request.QueryString["compId"]);
            int featureId = Convert.ToInt32(Request.QueryString["featureId"]);

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ComponentFeatures?featureId=" + featureId + "&compId="+ compId).Result;
            var Comp = feature.Content.ReadAsAsync<int>().Result;

            if (Comp == 1)
            {
                Response.Redirect("AssignBrand.aspx?compId="+ compId);
            }
            else if (Comp == -3)
            {
                Response.Redirect("AssignBrand.aspx?compId=" + compId); ;
            }
        }
    }
}