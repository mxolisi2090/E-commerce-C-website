<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="FeaturesList.aspx.cs" Inherits="_218010450_FrontEndMini.FeaturesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin /</span> Manage Features</h4>

                <div class="row">
                <div class="col-md-12">
                  <ul class="nav nav-pills flex-column flex-md-row mb-3">
                    <li class="nav-item">
                      <a class="nav-link " href="Blank.aspx"><i class="bx bx-user me-1"></i> Manage Categories</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link active" href="FeaturesList.aspx"
                        ><i class="bx bx-bell me-1"></i> Manage Features</a
                      >
                    </li>
                  </ul>

                    <!-----CODE HERE PLEASE---->


                    <div class="card">
                <h5 class="card-header">Sound Electronics Features</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table">
                    <thead class="table-dark">
                      <tr>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Price</th>
                        <th>Actions</th>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                         <div class="row" id="treport" runat="server"></div>
                      <%--<tr>

                          <td>
                              <ul>
                                   <li
                                   data-bs-toggle="tooltip"
                                    data-popup="tooltip-custom"
                                    data-bs-placement="top"
                               class="avatar avatar-xs pull-up"
                              title="Christina Parker"
                            >
                              <img src="../assets/img/avatars/7.png" style="width:55px;height:auto;" alt="image" class="" />
                            </li>
                              </ul>
                          </td>
                        <td> <strong>Angular Project</strong></td>
                        <td>Albert Cook</td>
                        
                        

                          <td>Price</td>
                        <td>
                          <div class="dropdown">
                            <button type="button" class="btn p-0 dropdown-toggle hide-arrow" data-bs-toggle="dropdown">
                              <i class="bx bx-dots-vertical-rounded"></i>
                            </button>
                            <div class="dropdown-menu">
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-edit-alt me-1"></i> Edit</a
                              >
                              <a class="dropdown-item" href="javascript:void(0);"
                                ><i class="bx bx-trash me-1"></i> Delete</a
                              >
                            </div>
                          </div>
                        </td>
                      </tr>--%>
                     
                    </tbody>
                  </table>
                </div>
              </div>


                    <!------CODE ENDS HERE------>

                    </div>

              </div>
           </div>
    </div>
</asp:Content>
