﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="edittestmaster.aspx.cs" Inherits="ktms.edittestmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>testmasterlist</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Edit Test Master</h1>
        </div>
        <div class="breadcrumb">
            <ul>
                <li><a href="testmasterlist.aspx">Test Master</a></li>
                <li>Edit Test Master</li>
            </ul>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <div class="col-md-12">
                <div class="card mb-4">
                    <div class="card-body">
                        <div class="card-title mb-3">Edit Test Master</div>

                        <div class="row">

                            <div class="col-md-12">
                                <asp:Label Text="" ID="lblResult" CssClass="alert-success" runat="server" /><asp:HyperLink ID="hlSignin" Text="" runat="server" Visible="false" NavigateUrl="~/signin.aspx" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlTestType" Text="Test Type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select language" ControlToValidate="ddlTestType" CssClass="invalid-feedback" Display="Dynamic" />

                                <%--<asp:Label AssociatedControlID="ddlTestType" Text="Test type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control">
                                    <asp:ListItem Selected="True" Value="0" Text="Select" />
                                    <asp:ListItem Value="1" Text="Class 5 - English" />
                                    <asp:ListItem Value="1" Text="Class 5 - French" />
                                    <asp:ListItem Value="1" Text="Class 7 - English" />
                                    <asp:ListItem Value="1" Text="Class 7 - French" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select a test type." ControlToValidate="ddlTestType" CssClass="invalid-feedback" Display="Dynamic" />--%>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtQuestion" Text="Question" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtQuestion" CssClass="form-control" placeholder="Enter your question" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter question." ControlToValidate="txtQuestion" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label Text="Question image" runat="server" CssClass="form-label" AssociatedControlID="fuQuestionImage" />
                                <div class="custom-file">
                                    <asp:FileUpload ID="fuQuestionImage" CssClass="form-control form-control" runat="server" />
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="fuQuestionImage" runat="server" ErrorMessage="Please upload picture" CssClass="invalid-feedback" Display="Dynamic" />--%>
                                </div>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtAnswerA" Text="Answer (A)" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtAnswerA" CssClass="form-control" placeholder="Enter Answer (A)" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter Answer (A)" ControlToValidate="txtAnswerA" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtAnswerB" Text="Answer (B)" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtAnswerB" CssClass="form-control" placeholder="Enter Answer (B)" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter Answer (B)" ControlToValidate="txtAnswerB" CssClass="invalid-feedback" Display="Dynamic" />
                                <!-- <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small> -->
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtAnswerC" Text="Answer (C)" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtAnswerC" CssClass="form-control" placeholder="Enter Answer (C)" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter Answer (C)" ControlToValidate="txtAnswerC" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="txtAnswerD" Text="Answer (D)" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtAnswerD" CssClass="form-control" placeholder="Enter Answer (D)" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter Answer (D)" ControlToValidate="txtAnswerD" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label ID="lblCorrectAnswer" Text="Correct Answer" AssociatedControlID="ddlCorrectAnswer" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlCorrectAnswer" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="A" Value="A" />
                                    <asp:ListItem Text="B" Value="B" />
                                    <asp:ListItem Text="C" Value="C" />
                                    <asp:ListItem Text="D" Value="D" />
                                </asp:DropDownList>


                                <%--<asp:Label AssociatedControlID="txtCorrectAnswer" Text="Correct Answer" runat="server" CssClass="form-label" />
                                <asp:TextBox ID="txtCorrectAnswer" CssClass="form-control" placeholder="Enter correct answer" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter correct answer." ControlToValidate="txtCorrectAnswer" CssClass="invalid-feedback" Display="Dynamic" />--%>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="imgQuestion" Text="Question Image" runat="server" CssClass="form-label" />
                            </div>

                            <div class="col-md-6 form-group mb-3">
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Image ID="imgQuestion" runat="server" Height="150px" />
                            </div>

                            <div class="col-md-12">
                                <asp:LinkButton ID="lnkCancel" CssClass="btn btn-dark float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/testmasterlist.aspx" CausesValidation="false" />
                                <asp:LinkButton ID="lnkSubmit" CommandArgument='<%#Eval("ID") %>' CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="lnkSubmit_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
