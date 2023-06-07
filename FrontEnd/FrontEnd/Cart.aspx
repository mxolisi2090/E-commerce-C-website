<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="_218010450_FrontEndMini.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <section class="module" runat="server">
    <div class="container">
          <div class="container">
            <div class="row">
              <div class="col-sm-6 col-sm-offset-3">
                <h1 class="module-title font-alt">Checkout</h1>
              </div>
            </div>
            <hr class="divider-w pt-20">
            <div class="row">
              <div class="col-sm-12">
                <table class="table table-striped table-border checkout-table">
                  <tbody>
                    <tr>
                      <th class="hidden-xs">Item</th>
                      <th>Description</th>
                      <th class="hidden-xs">Features</th>
                      <th>Quantity</th>
                      <th>Total</th>
                      <th>Remove</th>
                    </tr>
                      <form
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
                        <input class="form-control" type="number" name="" value="1" max="50" min="1"/>
                      </td>
                      <td>
                        <h5 class="product-title font-alt">£20.00</h5>
                      </td>
                      <td class="pr-remove"><a href="#" title="Remove"><i class="fa fa-times"></i></a></td>
                    </tr>
                   --%>
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
                 <div class="row" id="dis" runat="server"></div>
                </div>
              </div>
            </div>--%>
            <hr class="divider-w">
            <div class="row mt-70">
              <div class="col-sm-5 col-sm-offset-7">
                <div class="shop-Cart-totalbox">
                  <h4 class="font-alt">Cart Totals</h4>
                  <table class="table table-striped table-border checkout-table">
                    <tbody>
                        <div class="row" id="checkout" runat="server"></div>
                      <%--<tr>
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
                      </tr>--%>
                    </tbody>
                  </table>

                    <div class="row" id="order" runat="server"></div>
                  <%--<button class="btn btn-lg btn-block btn-round btn-d" type="submit">Proceed to Checkout</button>--%>
                     <asp:Label ID="error" runat="server" Visible="false"></asp:Label>
                </div>
              </div>
            </div>
          </div>
        </div>
        </section>

</asp:Content>
