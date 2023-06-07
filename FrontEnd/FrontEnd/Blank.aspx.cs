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
    public partial class Blank : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand").Result;
            var Comp = feature.Content.ReadAsAsync<List<Brand>>().Result;

            string display = "";
            foreach (var a in Comp)
            {
                display += "<tr>";
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

                display += "<td><strong>" + a.Name + "</strong></td>";

                display += "<td>";
                display += "<a type='button' runat='server' href='AdminListComp.aspx?compName=" + a.Name + "'class='btn rounded-pill btn-success'>View Components</a>";
                display += " </td>";

                display += "<td>"; 
                display += "<div class='dropdown'>";           
                display += "<button type = 'button' class='btn p-0 dropdown-toggle hide-arrow' data-bs-toggle='dropdown'>";            
                 display += "<i class='bx bx-dots-vertical-rounded'></i>";             
                 display += "</button>";           
                 display += "<div class='dropdown-menu'>";           
                 display += "<a class='dropdown-item' href='AddComponents.aspx?CategoryName="+a.Name+"'";             
                 display += "><i class='bx bx-edit-alt me-1'></i>Add Component</a";               
                 display += ">";             
                 display += "<a class='dropdown-item' href='DeleteCategory.aspx?cateId="+a.BrandId+"'";             
                 display += "><i class='bx bx-trash me-1'></i> Delete</a";               
                 display += ">";            
                 display += "</div>";           
                 display += "</div>";         
                 display += "</td>";       

                 display += "";display += "</tr>";
            }
            treport.InnerHtml = display;
        }
    }
}