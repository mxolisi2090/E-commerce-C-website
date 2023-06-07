<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UpdateComponent.aspx.cs" Inherits="_218010450_FrontEndMini.UpdateComponent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server">
    <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Account Settings /</span> Account</h4>

              <div class="row">
                <div class="col-md-12">
                  <ul class="nav nav-pills flex-column flex-md-row mb-3">
                    <li class="nav-item">
                      <a class="nav-link active" href="javascript:void(0);"><i class="bx bx-user me-1"></i> Admin</a>
                    </li>
                    
                  </ul>
                  <div class="card mb-4">
                    <h5 class="card-header">Update Component</h5>
                    <!-- Account -->
                    <div class="card-body">
                      <div class="d-flex align-items-start align-items-sm-center gap-4">

                          <div class="row" id="treport" runat="server"></div>
                      
                          
                        
                        
                      </div>
                    </div>
                    <hr class="my-0" />
                    <div class="card-body">
                      <form id="formAccountSettings" method="POST" onsubmit="return false">
                        <div class="row">
                          <div class="mb-3 col-md-6">
                            <label for="firstName" class="form-label">Component Name</label>
                            <input
                              class="form-control"
                              type="text"
                              runat="server"
                              id="firstName"
                              name="firstName"
                              value=""
                              autofocus
                            />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="lastName" class="form-label">Description</label>
                            <input class="form-control" runat="server" type="text" name="lastName" id="descri" value="Doe" />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="Price" class="form-label">Price</label>
                            <input
                              class="form-control"
                              type="text"
                              runat="server"
                              id="price"
                              name="email"
                              value=""
                              placeholder="R0,00"
                            />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label class="form-label" for="country">status</label>
                            <select id="stat" runat="server" class="select2 form-select">
                              <option value="">Select</option>
                              <option value="Available">Available</option>
                              <option value="Not-Available">Not-Available</option>
                                                     
                            </select>
                          </div>

                          <div class="mb-3 col-md-6">
                            <label class="form-label" for="country">Brand</label>
                            <select id="branddd" runat="server" class="select2 form-select">
                              <option value="">Select</option>
                              <option value="Australia">Australia</option>
                              <option value="Bangladesh">Bangladesh</option>
                                                           
                            </select>
                          </div>

                        <div class="mb-3 col-md-6"">
                          <label class="form-label" for="basic-default-image">Component Image</label>
                          <%--<input type="file"  runat="server" class="form-control" id="image" placeholder="" />--%>
                              
                             <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
                             
                        </div>
                          
                           

                          

                          
                        <div class="mt-2">
                          
                        </div>


                            


                         </div>
                          <button type="submit" runat="server" onserverclick="updateComp" class="btn btn-primary me-2">Save changes</button>
                          <%--<button type="reset" class="btn btn-outline-secondary">Cancel</button>--%>
                            <asp:Label ID="error" runat="server" Visible="false"></asp:Label>
                      </form>
                    </div>
                       <!-- /Account -->
                  </div>
                  <div class="card">
                    <h5 class="card-header">Delete Account</h5>
                    <div class="card-body">
                      <div class="mb-3 col-12 mb-0">
                        <div class="alert alert-warning">
                          <h6 class="alert-heading fw-bold mb-1">Are you sure you want to delete your account?</h6>
                          <p class="mb-0">Once you delete your account, there is no going back. Please be certain.</p>
                        </div>
                      </div>
                      <form id="formAccountDeactivation" onsubmit="return false">
                        <div class="form-check mb-3">
                          <input
                            class="form-check-input"
                            type="checkbox"
                            name="accountActivation"
                            id="accountActivation"
                          />
                          <label class="form-check-label" for="accountActivation"
                            >I confirm my account deactivation</label
                          >
                        </div>
                        <button type="submit" class="btn btn-danger deactivate-account">Deactivate Account</button>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
         </form>

</asp:Content>
