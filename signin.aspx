<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="ktms.signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auth-content">
        <div class="card o-hidden">
            <div class="row">
                <div class="col-md-12">
                    <div class="p-4">
                        <div class="auth-logo text-center mb-4">
                            <%--<img src="assets/images/logo.png" alt="">--%>
                        </div>
                        <h1 class="mb-3 text-18">Sign In</h1>
                        
                            <div class="form-group">
                                <label for="txtEmail">Email address</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-rounded" TextMode="Email" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field." Display="Dynamic" ControlToValidate="txtEmail" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="txtPassword">Password</label>
                                <asp:TextBox textmode="password" runat="server" ID="txtPassword" CssClass="form-control form-control-rounded" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required field." Display="Dynamic" ControlToValidate="txtPassword" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Button CssClass="btn btn-rounded btn-primary btn-block mt-2" runat="server" Text="Sign In" ID="btnSignIn" OnClick="btnSignIn_Click" />

                            <div class="mt-3 text-center">
                                <asp:Label ID="pageMessage" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="mt-3 text-center">
                                <a href="signup.aspx" class="text-muted"><u>Create an account</u></a> | <a href="forgot.aspx" class="text-muted"><u>Forgot Password?</u></a>
                            </div>                        

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
