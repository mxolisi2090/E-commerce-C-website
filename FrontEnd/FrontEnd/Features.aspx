<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Features.aspx.cs" Inherits="_218010450_FrontEndMini.Features" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <form id="form1" runat="server"> 
    <section class="module">
          <div class="container">
            <div class="row">
              <div class="col-sm-8 col-sm-offset-2">
                <h4 class="font-alt mb-0">My Profile</h4>
                <hr class="divider-w mt-10 mb-20">
                <form class="form" role="form">

                  <div class="form-group">
                    <input class="form-control input-lg" type="text" runat="server" id="name" placeholder=""/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" type="text" runat="server" id="surname" placeholder=""/>
                  </div>
                  <div class="form-group">
                    <input class="form-control input-sm" runat="server" id="email" type="text" placeholder=""/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" type="text" runat="server" id="number" placeholder="" />
                  </div>
                  <div class="form-group">
                    <input class="form-control" type="text" runat="server" id="address" placeholder="" />
                  </div>
                  <div class="form-group">
                    <input class="form-control" type="text" runat="server" id="gender" placeholder="" />
                  </div>
                    <asp:Label class="text-center" runat="server" id="errorcode">
				</asp:Label>

                   <button class="btn btn-lg btn-block btn-round btn-d" runat="server" onserverclick="UpdateUser" type="submit">Update User Info</button>
                </form>


              </div>
            </div>
          </div>
        </section>

        </form>


</asp:Content>
