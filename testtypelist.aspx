<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testtypelist.aspx.cs" Inherits="ktms.testtypelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Test Type List</h1>
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
                        <%--<p>Use <code>.table-striped</code> to add zebra-striping to any table rowwithin the <code>&lt;tbody&gt;</code>.</p>--%>
                        <div>

                            <div class="row">
                                <div class="col-sm-2">
                                    <asp:TextBox placeholder="Search" ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary" runat="server" Text="Submit"></asp:LinkButton>
                                </div>
                                <div class="col-sm-8">
                                    <asp:LinkButton ID="lnkAddUser" CssClass="btn btn-primary ripple m-1 float-right" runat="server" Text="Add Test Type" PostBackUrl="~/addtesttype.aspx" />
                                </div>

                            </div>
                            <div class="col-sm-12 table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th scope="col">#</th>
                                            <th scope="col">Test Type</th>
                                            <th scope="col">Language</th>
                                            <th scope="col">Created On</th>
                                            <th scope="col">Status</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Class 5</td>
                                            <td>English</td>
                                            <td>Aug 24, 2023</td>
                                            <td><span class="badge badge-success">Active</span>
                                                <%--<span class="badge badge-danger">Not Active</span>--%>
                                            </td>
                                            <td>
                                                <a href="edittestype.aspx" class="text-success mr-2">
                                                    <i class="nav-icon i-Pen-2 font-weight-bold"></i>
                                                </a>
                                                <a href="#" onclick="javascript:return ConfirmDelete()" class="text-danger mr-2">
                                                    <i class="nav-icon i-Close-Window font-weight-bold"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Class 5</td>
                                            <td>French</td>
                                            <td>Aug 24, 2023</td>
                                            <td><span class="badge badge-success">Active</span>
                                                <%--<span class="badge badge-danger">Not Active</span>--%>
                                            </td>
                                            <td>
                                                <a href="edittestype.aspx" class="text-success mr-2">
                                                    <i class="nav-icon i-Pen-2 font-weight-bold"></i>
                                                </a>
                                                <a href="#" onclick="javascript:return ConfirmDelete()" class="text-danger mr-2">
                                                    <i class="nav-icon i-Close-Window font-weight-bold"></i>
                                                </a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of col-->
    </div>

    <script>
        function ConfirmDelete() {
            confirm('This action will delete the data');
        }
    </script>
</asp:Content>
