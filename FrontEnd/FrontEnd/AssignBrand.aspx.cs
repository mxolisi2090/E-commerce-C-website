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
    public partial class AssignBrand : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //var compId = Request.QueryString["compId"];
            string display = "";
            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Features").Result;
            var Comp = feature.Content.ReadAsAsync<List<feature>>().Result;
            var compid = Request.QueryString["compId"];

            //name.Value = Comp.Name;

            foreach (var a in Comp)
            {
                display += "<tr>";
                display += "<td><strong> "+a.Name+" </strong></td>";
                display += "<td>"+a.Description+" </td>";
                display += "<td>";
                display += "<ul class='list-unstyled users-list m-0 avatar-group d-flex align-items-center'>";
                display += "<li";
                display += "data-bs-toggle='tooltip' ";
                display += "data-popup='tooltip-custom' ";
                display += "data-bs-placement='top' ";
                display += "class='avatar avatar-xs pull-up' ";
                display += "title='Lilian Fuller'";
                display += ">";
                display += "<img src='" + a.Image + "' style='width:55px;height:auto;' alt='image' class='' />";
                display += "</li>";
                display += "</ul>";
                display += "</td>";

                HttpResponseMessage info = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ComponentFeatures?featureId="+ a.FeatureId + "&compId="+ compid + "&me=me").Result;
                var omp = info.Content.ReadAsAsync<CompFeature>().Result;

                if (omp != null)
                {
                    display += "<td>";
                    display += "<a type='button' href='DeleteAssign.aspx?compId="+ compid +"&featureId="+ a.FeatureId + "' class='btn rounded-pill btn-danger'>Disable Feature</a>";
                    display += "</td>";
                }
                else if(omp==null){
                    display += "<td>";
                    display += "<a type='button'href='NotAssigList.aspx?compId="+ compid + "&featureId="+a.FeatureId+"' class='btn rounded-pill btn-info'>Assgn Feature</a>";
                    display += "</td>";
                }

               

                
                display += "</tr>";
            }

                   

            treport.InnerHtml = display;
        }
        protected void assignClick(object sender, EventArgs e)
        {

   
        }   
    }
}