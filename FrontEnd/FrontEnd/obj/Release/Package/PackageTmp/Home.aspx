<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_218010450_FrontEndMini.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form class="form" runat="server"> 

  <div class="module">
          <div class="container">
            <div class="row">

                
                <h4 class="font-alt">Sign-Up</h4>

              <div class="col-sm-5 col-sm-offset-1 mb-sm-40"> 
                <hr class="divider-w mb-10">
                <%--<form class="form" >--%>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="name" type="text" name="username" placeholder="Name"/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="surname" type="text" name="surname" placeholder="Surname"/>
                  </div>
                    <div class="form-group">
                    <input class="form-control" runat="server" id="email" type="text" name="email" placeholder="Email"/>
                  </div>
                    <div class="form-group">
                    <input class="form-control" runat="server"  id="number" type="text" name="number" placeholder="Phone number"/>
                  </div>
                <%--</form>--%>
              </div>


              <div class="col-sm-5">
                <%--<h4 class="font-alt">Register</h4>--%>
                <hr class="divider-w mb-10">
                <%--<form class="form" >--%>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="address" type="text" name="address" placeholder="Address"/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="gender" type="text" name="gender" placeholder="Gender"/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="password" type="password" name="password" placeholder="Password"/>
                  </div>
                  <div class="form-group">
                    <input class="form-control" runat="server" id="repassword" type="password" name="re-password" placeholder="Confirm Password"/>
                  </div>
                  
                <%--</form>--%>
              </div>
                
                <form class="form" >
                <div class="form-group">
                    <button runat="server" onserverclick="Book_Clicked" type="submit" class="btn btn-block btn-round btn-b">Register</button>
                     </div>
                      <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </form>
            </div>
        
      </div>  
  </div>
    
     </form>



</asp:Content>
