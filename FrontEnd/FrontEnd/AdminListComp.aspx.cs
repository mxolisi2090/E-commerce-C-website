using System;
using _218010450_FrontEndMini.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class AdminListComp : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            var name = Request.QueryString["compName"];

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?brandName=" + name).Result;
            var Comp = feature.Content.ReadAsAsync<List<Component>>().Result;

            string display = "";
            foreach(var a in Comp)
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
                display += "<img src='"+a.Image+ "' style='width:55px;height:auto;' alt='image' class='' />";              
                display += "</li>";                                                             
                display += "</ul>";          
                display += "</td>";       

                display += "<td><strong>"+a.Name+"</strong></td>";        

                display += "<td>"+a.BrandName+"</td>";        

                display += "<td>R"+a.Price+"</td>";

                HttpResponseMessage stok = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?ItemId="+ a.PartId + "&val=1" ).Result;
                var omp = stok.Content.ReadAsAsync<Stock>().Result;
                
                if (omp.AvaibleStock<=0)
                {
                    
                    display += "<td><span class='badge bg-label-primary me-1'>Not Available</span></td>";
                }else if (omp.AvaibleStock>=1)
                {
                    
                        display += "<td><span class='badge bg-label-success me-1'>Available</span></td>";
                }
                        
                       
               display += "<td>";         
               display += "<a type='button' runat='server' href='UpdateComponent.aspx?compId="+a.PartId+"'class='btn btn-info'>Update</a>";            
               display += "<a type='button' runat='server' href='SingleItem.aspx?compId="+a.PartId+"&status="+a.Status+"' class='btn btn-info'>Delete</a>";            
               display += " </td>";
               display += "<td>";
               display += "<a type='button' runat='server' href='AssignBrand.aspx?compId=" + a.PartId + "'class='btn rounded-pill btn-success'>View Features</a>";
               display += " </td>";
               display += "</tr>";       
            }
            treport.InnerHtml=display;
        }

    }
}
