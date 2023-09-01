<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="allocatetest.aspx.cs" Inherits="ktms.allocatetest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>allocatetest</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Allocate Test</h1>            
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">

                <div class="card mb-4">

                    <div class="card-body">

                        <div class="card-title mb-3">Allocate Test Type</div>

                        <div class="row">

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlTestType" Text="User" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="Select" />
                                    <asp:ListItem Value="1" Text="George Benson" />
                                    <asp:ListItem Value="2" Text="Erykah Badu" />
                                    <asp:ListItem Value="3" Text="Nina Simone" />
                                    <asp:ListItem Value="4" Text="Bill Withers" />
                                    <asp:ListItem Value="5" Text="George Jackson" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select test type." ControlToValidate="ddlTestType" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlLanguage" Text="Test Type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="Select" />
                                    <asp:ListItem Value="1" Text="Class 5 - English" />
                                    <asp:ListItem Value="1" Text="Class 7 - English" />
                                    <asp:ListItem Value="1" Text="Class 5 - French" />
                                    <asp:ListItem Value="1" Text="Class 7 - French" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="0" runat="server" ErrorMessage="Please select language" ControlToValidate="ddlLanguage" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>


                            <div class="col-md-6 form-group mb-3">
                            </div>

                            <div class="col-md-12">
                                <%--<asp:LinkButton ID="lnkCancel" CssClass="btn btn-dark float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/testtypelist.aspx" CausesValidation="false" />--%>
                                <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" />
                            </div>

                        </div>

                        <div class="col-md-6 form-group mb-3"> </div> <!-- Spacer -->

                        <div class="col-sm-12 table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">ID</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">Test Type</th>
                                        <th scope="col">Created On</th>                                        
                                        <th scope="col">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>12</td>
                                        <td>George Benson</td>
                                        <td>Class 5 - English</td>
                                        <td>Aug 20, 2023</td>                                        
                                        <td>                                            
                                            <a href="#" onclick="javascript:return ConfirmDelete()" class="text-danger mr-2">
                                                <i class="nav-icon i-Close-Window font-weight-bold"></i>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Bill Withers</td>
                                        <td>Class 7 - French</td>
                                        <td>Aug 13, 2023</td>                                        
                                        <td>                                            
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



    <script>
        function ConfirmDelete() {
            confirm('This action will delete the data');
        }
    </script>
</asp:Content>
