using System;
using _218010450_FrontEndMini.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Xml.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace _218010450_FrontEndMini
{
    public partial class UpdateComponent : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            var CompId = Request.QueryString["compId"];
            string display = "";

            HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Components?itemID=" + CompId).Result;
            var Comp = feature.Content.ReadAsAsync<Component>().Result;

            ////firstName.Value = Comp.Name;
            ////descri.Value = Comp.Description;
            ////price.Value = Comp.Price.ToString();
            ////stat.Value = Comp.Status;
            ////branddd.Value = Comp.BrandName;



            display += "<img ";
            display += "src='" + Comp.Image + "'";
            //display += "  
            display += "alt='user-avatar'";
            display += "class='d-block rounded'";
            display += "height='100'";
            display += "width='100'";
            display += "id='uploadedAvatar'";
            display += "/>";




            treport.InnerHtml = display;
            //display += "src='"++"'";

        }

        protected void updateComp(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                var CompId = Request.QueryString["compId"];
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (ext == ".png")
                {
                    string path = Server.MapPath("assets//images//shop//");
                    FileUpload1.SaveAs(path + FileUpload1.FileName);

                    HttpResponseMessage comp = client.GetAsync("https://localhost:44311/api/Components?compId="+ CompId + "&compName=" + firstName.Value + "&brandname=" + branddd.Value + "&image=/assets/images/shop/" + FileUpload1.FileName + "&price="+ price.Value + "&status="+ stat.Value + "&description=" + descri.Value).Result;
                    //"https://webapiminiproject218010450.azurewebsites.net/api/Components?compName={compName}&brandname={brandname}&image={image}&price={price}&status={status}&description={description}";
                    //HttpResponseMessage comp = client.GetAsync("https://localhost:44311/api/Components?compName=" + firstName.Value + "&brandname=" + branddd.Value + "&image=/assets/images/shop/" + FileUpload1.FileName + "&price=" + price.Value + "&status=" + stat.Value + "&description=" + descri.Value).Result;
                    var omp = comp.Content.ReadAsAsync<int>().Result;
                    if (omp == 1)
                    {
                        error.Attributes.Add("style", "color:green;");
                        error.Text = "Component Updated.";
                        error.Visible = true;
                    }else if (omp == -1)
                    {
                        error.Attributes.Add("style", "color:green;");
                        error.Text = "Component you're trying to update don't exist.";
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