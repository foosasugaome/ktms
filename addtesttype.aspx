<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addtesttype.aspx.cs" Inherits="ktms.addtesttype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>testtypelist</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Add Test Type</h1>
        </div>

        <div class="breadcrumb">
            <ul>
                <li><a href="testtypelist.aspx">Test Type</a></li>
                <li>Add Test Type</li>
            </ul>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">

                <div class="card mb-4">

                    <div class="card-body">

                        <div class="card-title mb-3">Add Test Type</div>

                        <div class="row">
                            <div class="col-md-12">
                                <asp:Label Text="" ID="lblResult" CssClass="alert-success" runat="server" />
                            </div>
                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlClassType" Text="Test Type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlClassType" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="" Text="Select" />
                                    <asp:ListItem Value="Class 5" Text="Class 5" />
                                    <asp:ListItem Value="Class 7" Text="Class 7" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select test type." ControlToValidate="ddlClassType" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlLanguage" Text="Language" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="Select" />
                                    <asp:ListItem Value="English" Text="English" />
                                    <asp:ListItem Value="French" Text="French" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="0" runat="server" ErrorMessage="Please select language" ControlToValidate="ddlLanguage" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>


                            <div class="col-md-6 form-group mb-3">
                            </div>

                            <div class="col-md-12">
                                <asp:LinkButton ID="lnkCancel" CssClass="btn btn-danger float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/testtypelist.aspx" CausesValidation="false" />
                                <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="lnkSubmit_Click" />
                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>
    </div>
</asp:Content>
