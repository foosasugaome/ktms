<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edittesttype.aspx.cs" Inherits="ktms.edittesttype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Edit Test Type</h1>
        </div>
        <div class="breadcrumb">
            <ul>
                <li><a href="testtypelist.aspx">Test Type</a></li>
                <li>Edit Test Type</li>
            </ul>
        </div>
        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title mb-3">Edit Test Type</div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label Text="" ID="lblResult" CssClass="alert-success" runat="server" />
                            </div>
                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtClassType" Text="" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtClassType" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvClassType" InitialValue="0" runat="server" ErrorMessage="Please select test type." ControlToValidate="txtClassType" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtLanguage" Text="Language" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtLanguage" Text="" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvLanguage" InitialValue="0" runat="server" ErrorMessage="Please select language" ControlToValidate="txtLanguage" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                            </div>

                            <div class="col-md-12">
                                <asp:LinkButton ID="btnCancel" CssClass="btn btn-danger float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/testtypelist.aspx" CausesValidation="false" />
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
