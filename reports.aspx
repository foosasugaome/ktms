﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="ktms.reports1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Report</h1>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">

                <div class="card mb-4">

                    <div class="card-body">

                        <div class="card-title mb-3">Report</div>

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
                                        <th scope="col">#</th>
                                        <th scope="col">Name</th>
                                        <th scope="col">Test Type</th>
                                        <th scope="col">Correct Answers</th>
                                        <th scope="col">Total Questions</th>
                                        <th scope="col">Result</th>
                                        <th scope="col">Created On</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>2</td>
                                        <td>George Benson</td>
                                        <td>Class 5 - English</td>
                                        <td>5</td>
                                        <td>10</td>
                                        <td>Pass</td>
                                        <td>August 23, 2023
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>5</td>
                                        <td>Bill Withers</td>
                                        <td>Class 5 - French</td>
                                        <td>9</td>
                                        <td>10</td>
                                        <td>Pass</td>
                                        <td>August 23, 2023
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

</asp:Content>
