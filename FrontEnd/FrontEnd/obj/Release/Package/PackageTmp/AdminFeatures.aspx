<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminFeatures.aspx.cs" Inherits="_218010450_FrontEndMini.AdminFeatures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin/</span> Add Features</h4>

              <!-- Basic Layout -->
              <div class="row">
                <div class="col-xl">
                  <div class="card mb-4">
                    <div class="card-header d-flex justify-content-between align-items-center">
                      <h5 class="mb-0">Features</h5>
                      <small class="text-muted float-end">Default label</small>
                    </div>
                    <div class="card-body">
                      <form>
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-fullname">Feature Name</label>
                          <input type="text" runat="server" class="form-control" id="name" placeholder="connect Ox" />
                        </div>
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-company">Component Name</label>
                          <input type="text" runat="server" class="form-control" id="brand" placeholder="Speaker" />
                        </div>
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-price">Price</label>
                          <div class="input-group input-group-merge">
                            <input
                              type="text"
                              id="price"
                              class="form-control"
                                runat="server"
                              placeholder="R100"
                              aria-label="john.doe"
                              aria-describedby="basic-default-email2"
                            />
                            <span class="input-group-text" id="basic-default-price"></span>
                          </div>
                         
                        </div>
                          <div class="mb-3">
                          <label class="form-label" for="basic-default-image">Component Image</label>
                          <%--<input type="file"  runat="server" class="form-control" id="image" placeholder="" />--%>
                              
                             
                             
                        </div>
                          
                           <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />

                        <div class="mb-3">
                          <label class="form-label" for="basic-default-fullname">Descripstion</label>
                          <input type="text" runat="server" class="form-control" id="descri" placeholder="Head Phones" />
                        </div>

                        
                        <button type="submit" runat="server" onserverclick="addClicked" class="btn btn-primary">Add</button>
                           <asp:Label ID="error" runat="server" Visible="false"></asp:Label>
                      </form>
                    </div>
                  </div>
                </div>
                  </div>
                </div>
        </div>
        </form>


</asp:Content>
