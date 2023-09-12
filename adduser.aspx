<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="ktms.adduser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ID="activePage" hidden>userlist</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Users</h1>
        </div>
        <div class="breadcrumb">
            <ul>
                <li><a href="userlist.aspx">User List</a></li>
                <li>Add User</li>
            </ul>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title mb-3">Add User</div>

                        <div class="row" id="formAddUser" runat="server">
                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtFirstName" Text="First name" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Enter first name" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter first name." ControlToValidate="txtFirstName" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtLastName" Text="Last name" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Enter last name" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter last name." ControlToValidate="txtLastName" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtEmail" Text="Email" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter email" TextMode="Email" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter email address." ControlToValidate="txtEmail" CssClass="invalid-feedback" Display="Dynamic" />
                                <!-- <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small> -->
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtPassword" Text="Password" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter password" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter a password." ControlToValidate="txtPassword" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtPhone" Text="Phone number" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtPhone" CssClass="form-control" placeholder="Enter phone" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter phone number." ControlToValidate="txtPhone" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlUserType" Text="User type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="" />
                                    <asp:ListItem Value="Admin" Text="Admin" />
                                    <asp:ListItem Value="Normal User" Text="Normal User" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select a user type." ControlToValidate="ddluserType" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label Text="User Picture" runat="server" CssClass="form-label" />
                                <div class="custom-file">
                                    <asp:FileUpload ID="fuUserPicture" CssClass="form-control form-control" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="fuUserPicture" runat="server" ErrorMessage="Please upload picture" CssClass="invalid-feedback" Display="Dynamic" />
                                </div>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                            </div>
                            <div class="col-md-12">
                                <asp:LinkButton ID="lnkCancel" CssClass="btn btn-danger float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/userlist.aspx" CausesValidation="false" />
                                <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="lnkSubmit_Click" />
                                <asp:Label Text ="" ID="lblResult" CssClass="alert-success" runat="server" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
