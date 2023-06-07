using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace _218010450_FrontEndMini
{
    public partial class AddComponents : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var category = Request.QueryString["CategoryName"];

            
        }
        protected  void addCompClicked(object sender, EventArgs e)
        {
            var UserID = Session["LoggedInUserID"];
            var total = Request.QueryString["Total"];
            var status = Request.QueryString["status"];
            var category = Request.QueryString["CategoryName"];

            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (ext == ".png")
                {
                    string path = Server.MapPath("assets//images//shop//");
                    FileUpload1.SaveAs(path + FileUpload1.FileName);

                   
                    HttpResponseMessage comp = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?compName=" + name.Value+"&brandname="+ category + "&image=/assets/images/shop/"+ FileUpload1.FileName +"&price="+ price.Value+"&status=Not-Avaialble&description="+ descri.Value).Result;
                    var omp = comp.Content.ReadAsAsync<int>().Result;
                    if (omp != -3 && omp!= -1)
                    {
                        HttpResponseMessage compinfo = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?itemID=" + omp).Result;
                        var details = compinfo.Content.ReadAsAsync<Component>().Result;

                        HttpResponseMessage addStock = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Stock?itemId=" + details.PartId+ "&name="+ details.Name+ "&description="+ details.Description+ "&price="+ details.Price+ "&supplier=Null&avaiblestock=0&soldstock=0&onspecial=0&image="+ details.Image+ "&Status=Not-Available&capacity=0&stockPrice=0" ).Result;
                        var stock = addStock.Content.ReadAsAsync<int>().Result;
                        if (stock == 1)
                        {
                            error.Attributes.Add("style", "color:green;");
                            error.Text = "Component Added.";
                            error.Visible = true;
                        }

                        
                    }
                    else if(omp==-3)
                    {
                        error.Attributes.Add("style", "color:green;");
                        error.Text = "Component Not Added.";
                        error.Visible = true;
                    }
                }
                else
                {
                    error.Attributes.Add("style", "color:red;");
                    error.Text = "You can only upload png file";
                    error.Visible = true;
                }
            }

           

        }
    }   
}