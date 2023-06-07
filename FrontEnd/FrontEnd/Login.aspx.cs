using _218010450_FrontEndMini.Models;
using System;
using System.Drawing;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;


namespace _218010450_FrontEndMini
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginClicked(object sender, EventArgs e)
        {
            //webapiminiproject.azurewebsites.net/api/User?password=123&email=MXO@11
            //client.BaseAddress = new Uri("https://localhost:44311/api/");

            HttpResponseMessage response = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?password="+ pass.Value + "&email=" +  email.Value).Result;
            HttpResponseMessage getUser = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?email=" + email.Value + "&val=1").Result;

            if (response.IsSuccessStatusCode)
            {
                var user = response.Content.ReadAsAsync<int>().Result;
                var userDetails = getUser.Content.ReadAsAsync<User>().Result;
                Session["LoggedInUserID"] = userDetails.Id;

                if (user == -1)
                {
                    
                    errorcode.Attributes.Add("style", "color:red; text-align:center; font-weight:400");
                    errorcode.Text = "Emial or Password does'nt Exist!!!";
                    errorcode.Visible = true;
                }else if (user== userDetails.Id)
                {
                    if (userDetails.Type.Equals("Admin"))
                    {
                        Response.Redirect("Blank.aspx");
                    }
                    else if (userDetails.Type.Equals("Client") || userDetails.Type.Equals("client"))
                    {
                        Response.Redirect("Shop.aspx");
                    }
                    else if (userDetails.Type.Equals("Manager"))
                    {
                        Response.Redirect("ViewStock.aspx");
                    }
                    else if (userDetails.Type.Equals("Clerck"))
                    {
                        Response.Redirect("ClerckPage.aspx");
                    }
                }
                else if(user != 1 && user!= -1)
                {
                    errorcode.Attributes.Add("style", "color:red;");
                    errorcode.Text = "Something went wrong please try again!!!";
                    errorcode.Visible = true;
                }

                
               // Session["LoggedInAdmin"] = userDetails.Type;

                

                   

            }
          

        }
    }
}