<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="_218010450_FrontEndMini.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin/</span> Add Category</h4>

              <!-- Basic Layout -->
              <div class="row">
                <div class="col-xl">
                  <div class="card mb-4">
                    <div class="card-header d-flex justify-content-between align-items-center">
                      <h5 class="mb-0">Category</h5>
                      <small class="text-muted float-end">Default label</small>
                    </div>
                    <div class="card-body">
                      <form>
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-fullname">Category Name</label>
                          <input type="text" runat="server" class="form-control" id="name" placeholder="Head Phones" />
                        </div>
                        
                          <div class="mb-3">
                          <label class="form-label" for="basic-default-image">Component Image</label>
                          <%--<input type="file"  runat="server" class="form-control" id="image" placeholder="" />--%>
                              
                             
                             
                        </div>
                          
                           <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />

                           <div class="mb-3">
                        <button type="submit" runat="server" onserverclick="addCompClicked" class="btn btn-primary">Add</button>
                           
                               </div>
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
