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
    public partial class Features : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            var UserID = Session["LoggedInUserID"];

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userId=" + UserID).Result;
            var user = respond.Content.ReadAsAsync<User>().Result;

            name.Value = user.Name;
            surname.Value = user.Surname;
            email.Value = user.Email;
            number.Value = user.Number;
            address.Value = user.Address;
            gender.Value = user.Gender;
            //email.Value=user.

        }

        protected void UpdateUser(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?userid="+ UserID + "&name="+ name.Value + "&surname="+ surname.Value + "&email="+ email.Value + "&number="+ number.Value + "&address="+ address.Value).Result;
            var user = respond.Content.ReadAsAsync<int>().Result;

            if (user==1)
            {
                errorcode.Attributes.Add("style", "color:green; text-align:center; font-weight:400");
                errorcode.Text = "User Updated!";
                errorcode.Visible = true;
            }
            else if (user == -2)
            {
                errorcode.Attributes.Add("style", "color:red; text-align:center; font-weight:400");
                errorcode.Text = "Something went wrong!";
                errorcode.Visible = true;
            }
            else
            {
                errorcode.Attributes.Add("style", "color:red; text-align:center; font-weight:400");
                errorcode.Text = "User was not found";
                errorcode.Visible = true;
            }

        }
    }
}