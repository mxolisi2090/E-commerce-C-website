using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class DeleteAssign : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int compId = Convert.ToInt32(Request.QueryString["compId"]);
            int featureId = Convert.ToInt32(Request.QueryString["featureId"]);

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ComponentFeatures?featureid=" + featureId + "&compId="+ compId + "&val=1" ).Result;
            var Comp = feature.Content.ReadAsAsync<bool>().Result;

            if (Comp == true)
            {
                Response.Redirect("AssignBrand.aspx?compId=" + compId);
            }
            else if (Comp == false)
            {
                Response.Redirect("AssignBrand.aspx?compId=" + compId); ;
            }
        }
    }
}