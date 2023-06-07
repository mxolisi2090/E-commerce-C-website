using _218010450_FrontEndMini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _218010450_FrontEndMini
{
    public partial class CustomizeProduct : System.Web.UI.Page
    {
        private readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            var UserID = Session["LoggedInUserID"];
            //var brand = Session["BrandName"];

            var CompId = Request.QueryString["compId"];
            var CompIdName = Request.QueryString["compName"];
            string name = Request.QueryString["brand"];
            double price =Convert.ToDouble(Request.QueryString["compPrice"]);
            

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ComponentFeatures?compId=" + CompId).Result;
            var Comp = respond.Content.ReadAsAsync<List<CompFeature>>().Result;


            string display = "";
            string play = "";
            string btn = "";
            string feature = "";

            double featureTotal = 0;

                var val = Session["ReturnValue"];


                play += "<div class='container'>";
                play += "<div class='row'>";
                play += "<div class='col-sm-6 col-sm-offset-3'>";
                play += "<h1 class='module-title font-alt'>" + CompIdName + "</h1>";
                play += "</div>";
                play += "</div>";
                foreach (var z in Comp)
                {

                HttpResponseMessage info = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/Features?featureId=" + z.FeatureId).Result;
                var omp = info.Content.ReadAsAsync<feature>().Result;

                display += "</tr>";
                    display += "<tr>";
                    display += "<td class='hidden-xs'><a href ='#' ><img src='" + omp.Image + "' alt='Accessories Pack'/></a></td>";
                    display += "<td>";
                    display += "<h5 class='product-title font-alt'>" + omp.Name + "</h5>";
                    display += "</td>";
                    display += " <td class='hidden-xs'>";
                    display += "<h5 class='product-title font-alt'>R" + omp.Price + "</h5>";
                    display += "</td>";
                    display += "<td>";
                    display += "<a class='btn btn-border-d btn-circle' id='customize' runat='server' href='ClientProduct.aspx?featureName="+ omp.Name+"&compName=" + CompIdName + "&compId="+ CompId +"&featurePrice="+omp.Price+"'>Add</a>";
                    //display += "<a class='btn btn-border-d btn-circle'  href='#'>Reject</a>";
                    display += "</td>";
                    display += "</tr>";


                }


            HttpResponseMessage res = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&prodId=" + CompId).Result;
            var fea = res.Content.ReadAsAsync<List<MyFeatures>>().Result;
            foreach (var a in fea)
            {
                feature += "<tr>";
                feature += "<td>";
                feature += "<h5>"+a.FeatureName+"</h5>";
                feature += "</td>";

                feature += "<td class='pr-remove'>";
                feature += "<a href ='RemoveFeature.aspx?featureName="+a.FeatureName+ "&compName=" + CompIdName + "&compId="+ CompId +"' title='Remove'><i class='fa fa-times'></i></a>";
                feature += "</td>";

                feature += "</tr>";

               
            }
           



            btn += "<a class='btn btn-block btn-round btn-d pull-right'id='customize' runat='server' href='AddToCart.aspx?compId="+ CompId + "&compName=" + name+ "&total="+"&Price="+ featureTotal + "' type='submit'>Add To Cart</a>";
                nav.InnerHtml = play;
                treport.InnerHtml = display;
                dis.InnerHtml = btn;
            ture.InnerHtml = feature;
            //QueryString();
        }
        public void QueryString()
        {
            var UserID = Session["LoggedInUserID"];

            //Component details
            string compName = Request.QueryString["compName"];
            double compprice = Convert.ToDouble(Request.QueryString["compPrice"]);



            int compId = Convert.ToInt32(Request.QueryString["compId"]);


            //feature details
            string featureName = Request.QueryString["featureName"];
            double feeatureprice = Convert.ToDouble(Request.QueryString["featurePrice"]);

            HttpResponseMessage respond = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&compName=" + compName + "&price=" + compprice).Result;

            //var user = respond.Content.ReadAsAsync<int>().Result;
            var Comp = respond.Content.ReadAsAsync<int>().Result;
            if (Comp != -1 && Comp != 0)
            {

                HttpResponseMessage feature = client.GetAsync("https://webapiminiproject218010450.azurewebsites.net/api/ProductParts?userId=" + UserID + "&proId=" + Comp + "&featureName=" + featureName + "&price=" + feeatureprice + "&status=Active").Result;
                var fea = feature.Content.ReadAsAsync<int>().Result;

                if (fea == 1)
                {
                    Response.Redirect("CustomizeProduct.aspx?compId=" + compId);
                }



            }
            else if (Comp == -1)
            {
                Response.Redirect("ProductList.aspx?compId=" + compId);
            }
            else if (Comp == -3)
            {
                Response.Redirect("ProductList.aspx");
            }



        }
    }
 }


            
           
            

            
            

            

        
