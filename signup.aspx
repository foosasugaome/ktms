<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="ktms.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auth-content">
        <div class="card o-hidden">
            <div class="row">
                <div class="col-md-12">
                    <div class="p-4">
                        <h1 class="mb-3 text-18">Sign Up</h1>
                        <div class="form-group">
                            <label for="txtFirstName">First Name</label>
                            <asp:TextBox ID="txtFirstName" CssClass="form-control form-control-rounded" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter first name" ControlToValidate="txtFirstName" Display="Dynamic" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtLastName">Last Name</label>
                            <asp:TextBox ID="txtLastName" CssClass="form-control form-control-rounded" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="invalid-feedback" ErrorMessage="Please enter last name" ControlToValidate="txtLastName" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtEmail">Email address</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control form-control-rounded" runat="server" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a valid email address" ControlToValidate="txtEmail" CssClass="invalid-feedback" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtPassword">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-rounded"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please create a password" CssClass="invalid-feedback" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtRePassword">Password</label>
                            <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" CssClass="form-control form-control-rounded"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRePassword" ErrorMessage="Please enter password" CssClass="invalid-feedback" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label for="txtPhone">Phone</label>
                            <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" CssClass="form-control form-control-rounded"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please enter phone number" CssClass="invalid-feedback" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                       <asp:Button CssClass="btn btn-rounded btn-primary btn-block mt-2" runat="server" Text="Sign Up" ID="btn_SignUp" OnClick="btn_SignUp_Click"/>
                        <asp:Label ID="pageMessage" runat="server" Text=""></asp:Label>
                        <div class="mt-3 text-center">
                            <a href="signin.aspx" class="text-muted"><u>Already have an account? Sign in</u></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
