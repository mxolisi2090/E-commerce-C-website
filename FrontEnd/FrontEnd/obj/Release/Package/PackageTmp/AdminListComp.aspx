<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminListComp.aspx.cs" Inherits="_218010450_FrontEndMini.AdminListComp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin /</span> Manage Components</h4>     

    <!-- Bootstrap Dark Table -->
              <div class="card">
                <h5 class="card-header">Sound Electronic Components</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table table-dark">
                    <thead>
                      <tr>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Category Name</th>
                        <th>Price</th>
                        <th>status</th>
                        <th>Actions</th>
                        <th>View Feature</th> 

                       
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                      <%--<tr>

                        <td>
                          <ul class="list-unstyled users-list m-0 avatar-group d-flex align-items-center">
                            <li
                              data-bs-toggle="tooltip"
                              data-popup="tooltip-custom"
                              data-bs-placement="top"
                              class="avatar avatar-xs pull-up"
                              title="Lilian Fuller"
                            >
                              <img src="../assets/images/shop/Bluetooth.png" alt="Avatar" class="" />
                            </li>                                                 
                          </ul>
                        </td>

                        <td><strong>Emplifier</strong></td>

                        <td>Emplifier</td>
                       
                        <td>R200</td>

                        <td><span class="badge bg-label-primary me-1">Active</span></td>
                       
                        <td>
                           <button type="button" class="btn btn-info">Update</button>
                           <button type="button" class="btn btn-info">Delete</button>
                        </td>
                      </tr>--%>
                       <div class="row" id="treport" runat="server"></div>
                        
                     
                    </tbody>
                  </table>
                </div>
              </div>

            </div>
        </div>

</asp:Content>
