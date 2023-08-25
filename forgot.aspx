<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="ktms.forgot" %>

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
                        <h1 class="mb-3 text-18">Forgot Password</h1>

                        <div class="form-group">
                            <label for="email">Email address</label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-rounded" TextMode="Email" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required field." Display="Dynamic" ControlToValidate="txtEmail" CssClass="invalid-feedback"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Button CssClass="btn btn-rounded btn-primary btn-block mt-2" runat="server" Text="Reset Password" ID="btn_Reset" OnClick="btn_Reset_Click" />

                        <div class="mt-3 text-center">
                            <asp:Label ID="pageMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                        </div>
                        <div class="mt-3 text-center">
                            <a href="signin.aspx" class="text-muted"><u>Sign in</u></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
