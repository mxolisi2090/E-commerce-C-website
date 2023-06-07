using _218010450_FrontEndMini.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class AddCategory : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand").Result;
            var Comp = feature.Content.ReadAsAsync<List<Brand>>().Result;
        }

        protected void addCompClicked(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (ext == ".png" || ext==".jpg")
                {
                    string path = Server.MapPath("assets//images//shop//");
                    FileUpload1.SaveAs(path + FileUpload1.FileName);
                    HttpResponseMessage comp = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Brand?categoryName=" + name.Value + "&image=/assets/images/shop/" + FileUpload1.FileName + "&rating=2").Result;
                                                               
                    var omp = comp.Content.ReadAsAsync<int>().Result;

                    if (omp == 1)
                    {
                        error.Attributes.Add("style", "color:green;");
                        error.Text = "Component Added.";
                        error.Visible = true;
                    }
                    else if (omp == -1)
                    {
                        error.Attributes.Add("style", "color:red;");
                        error.Text = "Somthing went wrong";
                        error.Visible = true;
                    }
                    else if (omp == -3)
                    {
                        error.Attributes.Add("style", "color:red;");
                        error.Text = "Category already exist in the system";
                        error.Visible = true;
                    }
                }
            }
        }


    }
}