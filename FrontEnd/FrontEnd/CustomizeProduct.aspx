<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomizeProduct.aspx.cs" Inherits="_218010450_FrontEndMini.CustomizeProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <section class="module">
          <div class="container">
           <%-- <div class="row">
              <div class="col-sm-6 col-sm-offset-3">
                <h1 class="module-title font-alt">Customize</h1>
              </div>
            </div>--%>
                <div class="row" id="nav" runat="server"></div>

            <hr class="divider-w pt-20">
            <div class="row">
              <div class="col-sm-8">
                <table class="table table-striped table-border checkout-table">
                  <tbody>
                    <tr>
                      <th class="hidden-xs">Item</th>
                      <th class="hidden-xs">Feature Name</th>
                      <th class="hidden-xs">Price</th>                    
                      <th class="hidden-xs">Action</th>
                    </tr>
                        <div class="row" id="treport" runat="server"></div>
                   <%-- <tr>
                      <td class="hidden-xs"><a href="#"><img src="assets/images/shop/product-14.jpg" alt="Accessories Pack"/></a></td>
                      <td>
                        <h5 class="product-title font-alt">Accessories Pack</h5>
                      </td>
                      <td class="hidden-xs">
                        <h5 class="product-title font-alt">£20.00</h5>
                      </td>
                      <td>
                            
                            <a class="btn btn-border-d btn-circle" id="customize" runat="server" href="CustomizeProduct.aspx"> Customize</a>
                            <a class="btn btn-border-d btn-circle"  href="#">Apply</a>
                         

                      </td>
                     
                     
                    </tr>--%>
                    
                  </tbody>
                </table>
              </div>



               
              <div class="col-sm-4">
                  
                <table class="table table-striped table-border checkout-table">
                  <tbody>                     
                    <tr>
                      <th>My Feature</th>
                      <th>Action</th>  
                    </tr>

                      <div class="row" id="ture" runat="server"></div>

                      <%--<tr>
                      <td>
                        <h5 >Accessories Pack</h5>
                      </td>

                      <td class="pr-remove">
                        <a href ="RemoveCart.aspx" title="Remove"><i class="fa fa-times"></i></a>
                      </td>

                      </tr>--%>
                      
                      
                   <%-- <tr>
                      <td class="hidden-xs"><a href="#"><img src="assets/images/shop/product-14.jpg" alt="Accessories Pack"/></a></td>
                      <td>
                        <h5 class="product-title font-alt">Accessories Pack</h5>
                      </td>
                      <td class="hidden-xs">
                        <h5 class="product-title font-alt">£20.00</h5>
                      </td>
                      <td>
                            
                            <a class="btn btn-border-d btn-circle" id="customize" runat="server" href="CustomizeProduct.aspx"> Customize</a>
                            <a class="btn btn-border-d btn-circle"  href="#">Apply</a>
                         

                      </td>
                     
                     
                    </tr>--%>
                    
                  </tbody>
                </table>

                  
                    <div class="form-group">
                      <div class="row" id="dis" runat="server"></div>
                    </div>
                 

              </div>
            





            </div>


              


            <%--<div class="row">
              <div class="col-sm-3">
                <div class="form-group">
                  <input class="form-control" type="text" id="" name="" placeholder="Coupon code"/>
                </div>
              </div>
              <div class="col-sm-3">
                <div class="form-group">
                  <button class="btn btn-round btn-g" type="submit">Apply</button>
                </div>
              </div>--%>
              
            </div>

           
             
           </section>
</asp:Content>
