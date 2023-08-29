<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testmasterlist.aspx.cs" Inherits="ktms.testmasterlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Test Master List</h1>
            <%--<ul>
             <li><a href="#">Users</a></li>
             <li>User List</li>
         </ul>--%>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row mb-4">


            <div class="col-md-12 mb-3">
                <div class="card text-left">

                    <div class="card-body">
                        <h4 class="card-title mb-3">Test Master List</h4>
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
                                    <asp:LinkButton ID="lnkAddUser" CssClass="btn btn-primary ripple m-1 float-right" runat="server" Text="Add Test Master" PostBackUrl="~/addtestmaster.aspx" />
                                </div>

                            </div>
                            <div class="col-sm-12 table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                        <tr>
                                            <th scope="col">#</th>
                                            <th scope="col">Test Type</th>
                                            <th scope="col">Question</th>
                                            <th scope="col">Question Image</th>
                                            <th scope="col">Answer (A)</th>
                                            <th scope="col">Answer (B)</th>
                                            <th scope="col">Answer (C)</th>
                                            <th scope="col">Answer (D)</th>
                                            <th scope="col">Correct Answer</th>
                                            <th scope="col">Created On</th>
                                            <th scope="col">Created By</th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Class 5 - English</td>
                                            <td>Question 4</td>
                                            <td>
                                                <img src="Files/TestMaster/2.gif" width="50px"/></td>
                                            <td>Ans A</td>
                                            <td>Ans B</td>
                                            <td>Ans C</td>
                                            <td>Ans D</td>
                                            <td>B</td>
                                            <td>Aug 24, 2023</td>
                                            <td>Norman Teodoro</td>
                                            <td>
                                                <a href="edittestmaster.aspx" class="text-success mr-2">
                                                    <i class="nav-icon i-Pen-2 font-weight-bold"></i>
                                                </a>
                                                <a href="#" onclick="javascript:return ConfirmDelete()" class="text-danger mr-2">
                                                    <i class="nav-icon i-Close-Window font-weight-bold"></i>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Class 5 - French</td>
                                            <td>Question 3</td>
                                            <td>
                                                <img src="Files/TestMaster/3.gif" width="50px" /></td>
                                            <td>Ans A</td>
                                            <td>Ans B</td>
                                            <td>Ans C</td>
                                            <td>Ans D</td>
                                            <td>D</td>
                                            <td>Aug 28, 2023</td>
                                            <td>Norman Teodoro</td>
                                            <td>
                                                <a href="edittestmaster.aspx" class="text-success mr-2">
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
