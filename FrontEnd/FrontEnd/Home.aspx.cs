using System;
using System.Net.Http;


namespace _218010450_FrontEndMini
{
    public partial class Home : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Book_Clicked(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri("https://localhost:44311/api/");

            if (password.Value != repassword.Value)
            {
                lblStatus.Text = "Password don't match please try again!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
            HttpResponseMessage response = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/User?type=client&name=" + name.Value + "&surname=" + surname.Value + "&email=" + email.Value + "&password=" + password.Value + "&gender=" + gender.Value + "&number=" + number.Value + "&address=" + address.Value).Result;
            var user = response.Content.ReadAsAsync<int>().Result;
            if (user == 1)
            {
                Response.Redirect("Login.aspx");

                return;
            }
            else if (user == -1)
            {
                lblStatus.Text = "Error occured!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;

            }
            else if (user == 0)
            {
                lblStatus.Text = "Account already exist!!!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
    }
}