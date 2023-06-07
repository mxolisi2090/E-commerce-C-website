<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AssignBrand.aspx.cs" Inherits="_218010450_FrontEndMini.AssignBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form runat="server">
    

    <div class="content-wrapper">
            <!-- Content -->

            <div class="container-xxl flex-grow-1 container-p-y">
              <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Admin /</span> Assign Component Feature</h4>

             <div class="card">
                <h5 class="card-header">Table Dark</h5>
                <div class="table-responsive text-nowrap">
                  <table class="table table-dark">
                    <thead>
                      <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>image</th>
                        <th>Action</th>
                        <%--<th>Actions</th>--%>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">

                                               <div class="row" id="treport" runat="server"></div>


                      <%--<tr>
                        <td> <strong>Angular Project</strong></td>
                        <td>Albert Cook</td>
                        <td>
                          <ul class="list-unstyled users-list m-0 avatar-group d-flex align-items-center">
                            <li
                              data-bs-toggle="tooltip"
                              data-popup="tooltip-custom"
                              data-bs-placement="top"
                              class="avatar avatar-xs pull-up"
                              title="Lilian Fuller"
                            >
                              <img src="../assets/img/avatars/5.png" alt="Avatar" class="rounded-circle" />
                            </li>
                          </ul>
                        </td>
                        
                     
                        <td>
                          <a type="button" class="btn rounded-pill btn-info">Info</a>

                        </td>
                       </tr>--%>
                    </tbody>
                  </table>
                </div>
              </div>

                </div>
        </div>

</form>

</asp:Content>
