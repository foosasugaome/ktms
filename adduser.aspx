<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adduser.aspx.cs" Inherits="ktms.adduser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Users</h1>
            <ul>
                <li><a href="#">Form</a></li>
                <li>Add Users</li>
            </ul>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title mb-3">Add User</div>

                        <div class="row">
                            <div class="col-md-6 form-group mb-3">
                                <label for="txtFirstName">First name</label>                                
                                <asp:TextBox ID="txtFirstName" CssClass="form-control" placeholder="Enter first name" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label for="txtLastName">Last name</label>                                
                                <asp:TextBox ID="txtLastName" CssClass="form-control" placeholder="Enter last name" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label for="txtEmail">Email address</label>                                
                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Enter email" TextMode="Email" runat="server"></asp:TextBox>
                                <!-- <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small> -->
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label for="txtPassword">Password</label>                                
                                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Enter password" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label for="txtPhone">Phone</label>                                
                                <asp:TextBox ID="txtPhone" CssClass="form-control" placeholder="Enter phone" runat="server"></asp:TextBox>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label for="ddluserType">User Type</label>
                                <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value=""></asp:ListItem>
                                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                                    <asp:ListItem Value="Normal User">Normal User</asp:ListItem>                                    
                                </asp:DropDownList>                                
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <label>User Picture</label>
                                <div class="custom-file">
                                <label for="fuAvatar" class="custom-file-label">Upload Picture</label>
                                <asp:FileUpload ID="fuAvatar" CssClass="form-control custom-file-input" runat="server" />                                
                                </div>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                            </div>
                            <div class="col-md-12">
                                <asp:LinkButton CssClass="btn btn-dark ripple float-right m-1" ID="lnkCancel" text="Cancel" PostBackUrl="~/userlist.aspx" runat="server" />
                                <asp:LinkButton CssClass="btn btn-primary float-right m-1" ID="lnkSubmit" text="Submit" runat="server" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
