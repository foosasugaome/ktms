<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usertest.aspx.cs" Inherits="ktms.usertest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>usertest</div>

    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Start Test</h1>

        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row">
            <%--Start divStartTest--%>
            <div class="col-md-6 offset-3" id="divStart" runat="server">
                <div class="card mb-4">
                    <div class="card-body">

                        <div class="card-title mb-3">Start Test</div>

                        <div class="row">

                            <div class="col-md-12 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlTestType" Text="Test Type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" InitialValue="0" runat="server" ErrorMessage="Please select language" ControlToValidate="ddlTestType" CssClass="invalid-feedback" Display="Dynamic" />
                            </div>


                            <div class="col-md-12 form-group mb-3">
                                <asp:Label ID="lblError" Text="" runat="server" />
                            </div>

                            <div class="col-md-12">
                                <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="lnkSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--End divStart--%>

            <%--Start divStartTest--%>
            <div class="col-md-6 offset-3" id="divStartTest" visible="false" runat="server">
                <div class="card mb-4">
                    <div class="card-body">

                        <div class="card-title mb-3">
                            <asp:Label ID="lblQuestion" runat="server" />
                        </div>
                        <div class="card-title mb-3">
                            <asp:Image ID="imgQuestion" Width="200" runat="server" />
                        </div>

                        <div class="row">
                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton Text="" ID="lnkAnswerA" runat="server" CssClass="form-control" OnClick="lnkAnswer_Click" CommandName="A" />
                            </div>
                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton Text="" ID="lnkAnswerB" runat="server" CssClass="form-control" OnClick="lnkAnswer_Click" CommandName="B" />
                            </div>
                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton Text="" ID="lnkAnswerC" runat="server" CssClass="form-control" OnClick="lnkAnswer_Click" CommandName="C" />
                            </div>
                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton Text="" ID="lnkAnswerD" runat="server" CssClass="form-control" OnClick="lnkAnswer_Click" CommandName="D" />
                            </div>
                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton ID="lnkNext" Text="Next" CssClass="btn btn-secondary float-lg-right" runat="server" OnClick="lnkNext_Click" />
                            </div>

                            <div class="col-md-12">
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <%--End divStartTest--%>

            <%--Start div Result --%>
            <div class="col-md-6 offset-3" id="divResult" visible="false" runat="server">
                <div class="card mb-4">
                    <div class="card-body">

                        <div class="card-title mb-3">
                            <h1 class="col-md-12 text-center"><asp:Label ID="lblResult" Text="" CssClass="alert-success" style="display:block;" runat="server" /></h1>
                        </div>

                        <div class="row">
                            <div class="col-md-12 form-group mb-3">
                                <h2 class="col-md-12 text-center">
                                    <asp:Label Text="" ID="lblCorrectAnswer" runat="server" />
                                    /
                                <asp:Label Text="" ID="lblTotalQuestions" runat="server" />
                                </h2>
                            </div>


                            <div class="col-md-12 form-group mb-3">
                                <asp:LinkButton ID="lnkFinish" Text="Finish" CssClass="btn btn-primary float-right" runat="server" OnClick="lnkFinish_Click" />
                            </div>

                            <div class="col-md-12">
                            </div>

                        </div>

                    </div>

                </div>
            </div>
            <%--End divResult--%>

        </div>
    </div>


</asp:Content>
