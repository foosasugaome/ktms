<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateGetDashboardSP.aspx.cs" Inherits="ktms.CreateGetDashboardSP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>testtypelist</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Initialize</h1>
            <%--<ul>
             <li><a href="#">Componets</a></li>
             <li>Table</li>
         </ul>--%>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row mb-4">


            <div class="col-md-12 mb-3">
                <div class="card text-left">

                    <div class="card-body">
                        <h4 class="card-title mb-3">Test Type List</h4>

                        <div>

                            <div class="row">
                                <div class="col-sm-2">
                                    <asp:Label ID="lblCreateSPGetDashboard" runat="server" Text="Create GetDashboard Stored Proc" CssClass="form-control"></asp:Label>
                                    </div>
                                    <div class="col-sm-2">
                                    <asp:LinkButton ID="lnkCreateSP" runat="server" CssClass="btn btn-primary" OnClick="lnkCreateSP_Click">Create SP</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
