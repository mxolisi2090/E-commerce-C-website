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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var userID = Session["LoggedInUserID"].ToString();


            string display = "";

            HttpResponseMessage loggedUser = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userId=" + userID).Result;
            var Details = loggedUser.Content.ReadAsAsync<User>().Result;


            display += "<div class='flex-grow-1'>";
            display += "<span class='fw-semibold d-block'>"+ Details.Name + "</span>";
            display += "<small class='text-muted'>"+ Details.Type + "</small>";        
            display += "</div>";          
                   
          

            treport.InnerHtml = display;

            if (userID != null)
            {
                int ID = Convert.ToInt32(Session["LoggedInUserID"]);
                HttpResponseMessage loggedInUser = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userId=" + ID).Result;

                if (loggedInUser.IsSuccessStatusCode)
                {
                    var userDetails = loggedInUser.Content.ReadAsAsync<User>().Result;
                    if (userDetails.Type == "Admin")
                    {
                        //Admin
                        dashboard.Visible=true;
                        dash.Visible=true;
                       // manaComp.Visible=true;
                        addApp.Visible=true;
                        brands.Visible= true;
                       // manBrands.Visible= true;
                        addbrand.Visible= true;
                        //Manager
                        mana.Visible = false;
                        stock.Visible = false;
                        view.Visible=false;
                        compsto.Visible = false;
                        level.Visible=false;
                        popu.Visible=false;
                        
                        //Clercker
                        clerck.Visible=false;
                        orders.Visible=false;
                        clientOrder.Visible=false;
                        OrderProgress.Visible = false;
                        search.Visible=false;
                        searchButtton.Visible = false;
                    }
                    if (userDetails.Type == "Manager")
                    {
                        //Admin
                        dashboard.Visible = false;
                        dash.Visible = false;
                        //manaComp.Visible = false;
                        addApp.Visible = false;
                        brands.Visible = false;
                        //manBrands.Visible = false;
                        addbrand.Visible = false;
                        //Manager
                        mana.Visible = true;
                        stock.Visible = true;
                        view.Visible = true;
                        compsto.Visible = false;
                        level.Visible = true;
                        popu.Visible = true;

                        //Clercker
                        clerck.Visible = false;
                        orders.Visible = false;
                        clientOrder.Visible = false;
                        OrderProgress.Visible = false;
                        search.Visible = false;
                        searchButtton.Visible=false;

                        if (view.ViewStateMode.Equals(true))
                        {
                           
                            search.Visible = true;
                            searchButtton.Visible = true;
                        }
                    }
                    if(userDetails.Type == "Clerck")
                    {
                        //Admin
                        dashboard.Visible = false;
                        dash.Visible = false;
                        //manaComp.Visible = false;
                        addApp.Visible = false;
                        brands.Visible = false;
                        //manBrands.Visible = false;
                        addbrand.Visible = false;
                        //Manager
                        mana.Visible = false;
                        stock.Visible = false;
                        view.Visible = false;
                        compsto.Visible = false;
                        level.Visible = false;
                        popu.Visible = false;

                        //Clercker
                        clerck.Visible = true;
                        orders.Visible = true;
                        clientOrder.Visible = true;
                        OrderProgress.Visible = true;
                        search.Visible = true;
                    }
                }


            }    }
    }
}