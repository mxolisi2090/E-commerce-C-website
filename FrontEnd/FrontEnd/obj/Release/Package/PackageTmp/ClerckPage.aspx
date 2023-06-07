<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ClerckPage.aspx.cs" Inherits="_218010450_FrontEndMini.ClerckPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    
    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Clercker /</span> Process Orders</h4>           
   

              <!-- Contextual Classes -->

              <div class="card">
                <h5 class="card-header"> Orders</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table">
                    <thead>
                      <tr>
                        <th>Client Name</th>
                        <th>Order No.</th>
                        <th>Date</th>
                        <th>Price</th>
                        <th>Status</th>
                        <th>Actions</th>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">

                        <div class="row" id="treport" runat="server"></div>
                     <%-- <tr class="table-default">
                          <!---------User Name-------->
                        <td><strong>User Name</strong></td>
                          <!---------order number-------->
                        <td><strong>O123</strong></td>
                        <!---------Order Date-------->
                        <td><strong>2022/09/22</strong></td>
                           <!---------Order Price-------->
                          <td><strong>R300</strong></td>
                          <!---------Order Status-------->
                        <td><span class="badge bg-label-primary me-1">Active</span></td>
                          <!---------Order Action-------->
                        <td>
                          <div class="dropdown">
                            <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                              <i class="bx bx-dots-vertical-rounded"></i>
                            </button>
                            <div class="dropdown-menu">
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-edit-alt me-1"></i>Process</a
                              >
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-trash me-1"></i>Delete</a
                              >
                            </div>
                          </div>
                        </td>
                      </tr>--%>
                        </table>
                    </div>
                  </div>
                </div>
        </div>

</asp:Content>
