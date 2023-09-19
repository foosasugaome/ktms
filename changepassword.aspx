<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="ktms.changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Change Password</h1>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-6 offset-3">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title mb-3">Change Password</div>

                        <div class="row">


                            <div class="col-md-12 form-group mb-3">
                                <asp:Label AssociatedControlID="txtCurrentPassword" Text="Current Password" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtCurrentPassword" CssClass="form-control" placeholder="Type your current password" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter current password." ControlToValidate="txtCurrentPassword" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-12 form-group mb-3">
                                <asp:Label AssociatedControlID="txtNewPassword" Text="New Password" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtNewPassword" CssClass="form-control" placeholder="Type your new password" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter your new password." ControlToValidate="txtNewPassword" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-12 form-group mb-3">
                                <asp:Label AssociatedControlID="txtConfirmPassword" Text="Confirm Password" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" placeholder="Confirm your new password" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please confirm new password." ControlToValidate="txtConfirmPassword" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>



                            <div class="col-md-6 form-group mb-3">
                            </div>
                            <div class="col-md-12">
                                <asp:LinkButton ID="lnkCancel" CssClass="btn btn-dark float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/default.aspx" CausesValidation="false" />
                                <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="lnkSubmit_Click" />
                            </div>
                            <div class="col-md-12">
                                <asp:Label ID="lblResult" runat="server" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
