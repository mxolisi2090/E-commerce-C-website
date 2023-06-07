using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _218010450_FrontEndMini
{
    public partial class OrderProgress : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];

            string display = "";
            int[] val ;

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderReport").Result;
            var available = feature.Content.ReadAsAsync<double>().Result;

            HttpResponseMessage inpro = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderReport?val=1").Result;
            var inprogress = inpro.Content.ReadAsAsync<double>().Result;

            HttpResponseMessage comple = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/OrderReport?name=completed").Result;
            var completed = comple.Content.ReadAsAsync<double>().Result;

            // waiting.

            display += "<script>";
            display += "const ctx = document.getElementById('myChart').getContext('2d');";  
            display += "const myChart = new Chart(ctx, {"; 
            display += "type: 'pie',"; 
            display += "data:{"; 
            display += "labels: ['Waiting', 'InProgress', 'Completed'],"; 
            display += "datasets:[{";
            display += "label: 'Order Percentage',";
            
            display += "data: ["+ available + ", "+ inprogress + ", "+ completed + "],"; 
            display += "backgroundColor: ["; 
            display += "'rgba(255, 99, 132, 0.2)',";
            display += "'rgba(54, 162, 235, 0.2)',";
            display += "'rgba(255, 206, 86, 0.2)',";            
            display += "],"; 
            display += "borderColor: ["; 
            display += "'rgba(255, 99, 132, 1)',";
            display += "'rgba(54, 162, 235, 1)',";
            display += "'rgba(255, 206, 86, 1)',";
            display += "],"; 
                       
            display += "borderWidth: 1";        
            display += "}]"; 
            display += "},"; 
                       
            display += "options:{";        
            display += "scales: {"; 
            display += "y:{";
                
           display += "beginAtZero: true";
           
           display += "}"; 
            
           display += "}"; 
           display += "}";
               
           display += "});"; 
                    
           display += "</script>";


            grade.InnerHtml = display;
        }
    }
}