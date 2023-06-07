<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddFeature.aspx.cs" Inherits="_218010450_FrontEndMini.AddFeature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server">
    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Manager /</span> Manage Stock</h4>


                <div class="col-md-6">
                  <div class="card mb-4">
                    <h5 class="card-header">Add Component Feature</h5>
                    <div class="card-body">

                      <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Feature Name</label>
                        <input
                            runat="server"
                          type="text"
                          class="form-control"
                          id="name"
                          placeholder=""
                        />
                      </div>
                         
                      <div class="mb-3">
                        <label for="exampleFormControlReadOnlyInput1" class="form-label">Component Name</label>
                          <div class="row" id="treport" runat="server"></div>

                         

                          <%-- <select id="country" runat="server" class="select2 form-select">
                             
                           <option value="">Select</option>
                              <option value="Australia">Australia</option>
                            </select>--%>
                      </div>
                      <div class="mb-3">
                        <label for="exampleFormControlReadOnlyInputPlain1" class="form-label">image</label>
                       
                      </div>

                        <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />

                        <div class="mb-3">
                        <label for="exampleFormControlReadOnlyInputPlain1" class="form-label">Price</label>
                        <input
                          runat="server"
                          class="form-control"
                          id="price"
                          type="text"
                        />
                      </div>
                      
                      
                    </div>
                      <a type="button" runat="server" onserverclick="addFeatureClicked" class="btn rounded-pill btn-success">Add Feature</a>
                      <asp:Label ID="error" runat="server" Visible="false"></asp:Label>
                  </div>
                </div>

                </div>
        </div>
        </form>


</asp:Content>
