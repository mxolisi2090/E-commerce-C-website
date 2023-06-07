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
    public partial class ViewStock : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock").Result;
            var Comp = feature.Content.ReadAsAsync<List<Stock>>().Result;
            string display="";

            foreach(var a in Comp)
            {
                display += "<tr>";
                display += "<td><i class='fab fa-angular fa-lg text-danger me-3'></i> <strong>"+a.Name+"</strong></td>"; 
                display += "<td>"+a.Description+"</td>";        
                display += "<td>";        
                display += "<ul class='list-unstyled users-list m-0 avatar-group d-flex align-items-center'>";          
                display += "<li";
                //display += "data-bs-toggle='tooltip' ";
                //display += "data-popup='tooltip-custom' ";
                //display += "data-bs-placement='top' ";
                //display += "class='image image-xs pull-up' ";
                //display += " title=''";
                display += ">";
                display += "<img src='"+a.Image+ "' style='width:75px;height:auto;'  alt='image' class='' />";              
                display += "</li>";
                
                display += "</ul>";           
               display += "</td>";        
               display += "<td><span class='badge bg-label-primary me-1'>R"+a.Price+"</span></td>";         
               display += "<td>";         
               display += "<span class='badge bg-primary'>"+a.AvaibleStock.ToString()+"</span>";           
               display += "</td>";         
               display += "<td>";         
               display += "<span class='badge bg-success'>"+a.Sold+"</span>";            
               display += "</td>";         
               //display += "<td>";
               // display += "<a type='button' class='btn btn-outline-primary'>";
               // display += " Max ";
               // display += "<span class='badge bg-secondary rounded-pill'> " + a.maxAmountStock + "</span>";
               // display += "</a>";
               // display += "</td>";         
               display += " <td>";
                ///Action
                display += "<div class='dropdown'>";             
                 display += "<button type ='button' class='btn p-0 dropdown-toggle hide-arrow' data-bs-toggle='dropdown'>";           
                 display += "<i class='bx bx-dots-vertical-rounded'></i>";             
                 display += " </button>";          
                 display += "<div class='dropdown-menu'>";           
                 display += "<a class='dropdown-item' href='AddStock.aspx?stockId="+a.StockId+"'";             
                 display += "><i class='bx bx-edit-alt me-2'></i>Add Stock</a";               
                 display += ">";             
                 display += "<a class='dropdown-item' href='javascript:void(0);'";            
                 display += "><i class='bx bx-trash me-2'></i>Update stock</a";               
                 display += ">";             
                 display += "</div>";           
                 display +="</div>";        
                display += "</td>";
                display += "</tr>";
            }

            treport.InnerHtml=display;


        }
    }
}