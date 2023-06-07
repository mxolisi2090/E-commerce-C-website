<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="_218010450_FrontEndMini.MyOrders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="module">
          <div class="container">
            <div class="row">
              <div class="col-sm-6 col-sm-offset-3">
                <h1 class="module-title font-alt">My Orders</h1>
              </div>
            </div>
            <hr class="divider-w pt-20">
            <div class="row">
              <div class="col-sm-12">
                <table class="table table-striped table-border checkout-table">
                  <tbody>
                    <tr>
                      <th>Order</th>
                      <th>Items</th>
                      <th class="hidden-xs">Price</th>
                      <th>Date</th>
                      <th>Status</th>
                      <th>Remove</th>
                    </tr>
                      
                           <div class="row" id="treport" runat="server"></div>
                      
                      
                      <%--<td> 
                    <tr>

                        
                         <h5 class="product-title font-alt">order Number</h5>
                          </td>
                      <td>
                       
                          <h5 class="product-title font-alt">Items</h5>

                      </td>
                      <td class="hidden-xs">
                        <h5 class="product-title font-alt">Price</h5>
                      </td>
                      <td>
                        
                           <h5 class="product-title font-alt">Date</h5>
                      </td>
                      <td>
                        <h5 class="product-title font-alt">Status</h5>
                      </td>
                      <td class="pr-remove"><a href="#" title="Remove"><i class="fa fa-times"></i></a></td>
                    </tr>--%>

                  </tbody>
                </table>
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
              </div>
              <div class="col-sm-3 col-sm-offset-3">
                <div class="form-group">
                  <button class="btn btn-block btn-round btn-d pull-right" type="submit">Update Cart</button>
                </div>
              </div>
            </div>--%>
            <hr class="divider-w">
            <%--<div class="row mt-70">
              <div class="col-sm-5 col-sm-offset-7">
                <div class="shop-Cart-totalbox">
                  <h4 class="font-alt">Cart Totals</h4>
                  <table class="table table-striped table-border checkout-table">
                    <tbody>
                      <tr>
                        <th>Cart Subtotal :</th>
                        <td>£40.00</td>
                      </tr>
                      <tr>
                        <th>Shipping Total :</th>
                        <td>£2.00</td>
                      </tr>
                      <tr class="shop-Cart-totalprice">
                        <th>Total :</th>
                        <td>£42.00</td>
                      </tr>
                    </tbody>
                  </table>
                  <button class="btn btn-lg btn-block btn-round btn-d" type="submit">Proceed to Checkout</button>
                </div>
              </div>
            </div>--%>
          </div>
        </section>
    
</asp:Content>
