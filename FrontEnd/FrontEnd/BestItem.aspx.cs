using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class BestItem : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {


            var UserID = Session["LoggedInUserID"];

            HttpResponseMessage getUser = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?val=1&val1=1").Result;
            var userDetails = getUser.Content.ReadAsAsync<List<int>>().Result;

            int a= userDetails.ElementAt(0);
            int b= userDetails.ElementAt(1);
            int c= userDetails.ElementAt(2);
            int d = userDetails.ElementAt(3);
            int z = userDetails.ElementAt(4);

            HttpResponseMessage getitem = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?sold=1&val=e&val1=e").Result;
            var itemDetails = getitem.Content.ReadAsAsync<List<string>>().Result;

            var aa = itemDetails.ElementAt(0);
            var bb = itemDetails.ElementAt(1);
            var cc = itemDetails.ElementAt(2);
            var dd = itemDetails.ElementAt(3);
            var zz = itemDetails.ElementAt(4);


            string display = "";
            string me = "Hello";

            display += "<script>";
            display += "const ctx = document.getElementById('myChart').getContext('2d');";
            display += "const myChart = new Chart(ctx, {";
            display += "type: 'bar',";
            display += "data:{";
            display += "labels: ['"+ aa + "','"+ bb + "','"+ cc + "','"+ dd + "','"+ zz + "'],";
            display += "datasets:[{";
            display += "label: '5 most sold Items',";

            display += "data: [" +a +"," + b+"," +c +"," +d+ "," +z+ "],";
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