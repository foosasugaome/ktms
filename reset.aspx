<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="reset.aspx.cs" Inherits="ktms.reset" %>

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
                        <h1 class="mb-3 text-18">Reset Password</h1>

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtPassword" Text="Current Password" runat="server" CssClass="form-label" />
                            <asp:TextBox ID="txtPassword" CssClass="form-control form-control-rounder" placeholder="Enter new password" runat="server" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter new password." ControlToValidate="txtPassword" CssClass="invalid-feedback" Display="Dynamic" />
                        </div> 

                        <div class="form-group">
                            <asp:Label AssociatedControlID="txtConfirmPassword" Text="Confirm Password" runat="server" CssClass="form-label" />
                            <asp:TextBox ID="txtConfirmPassword" CssClass="form-control form-control-rounder" placeholder="Enter new password" runat="server" TextMode="Password" />
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
