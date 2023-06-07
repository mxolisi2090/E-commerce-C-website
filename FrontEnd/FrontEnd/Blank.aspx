<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Blank.aspx.cs" Inherits="_218010450_FrontEndMini.Blank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin /</span> Manage Components Categories</h4>     

    <!-- Bootstrap Dark Table -->

       <div class="row">
                <div class="col-md-12">
                  <ul class="nav nav-pills flex-column flex-md-row mb-3">
                    <li class="nav-item">
                      <a class="nav-link active" href="Blank.aspx"><i class="bx bx-user me-1"></i> Manage Categories</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="FeaturesList.aspx"
                        ><i class="bx bx-bell me-1"></i> Manage Features</a
                      >
                    </li>
                  </ul>


              <div class="card">
                <h5 class="card-header">Sound Electronics Categories</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table table-dark">
                    <thead>
                      <tr>
                        <th>Image</th>
                        <th>Name</th>
                        <th>View Components</th>
                        <th>Action</th>

                       
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">

                         <div class="row" id="Div1" runat="server"></div>
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

            </div>
        </div>


</asp:Content>
