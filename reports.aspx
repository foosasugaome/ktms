<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reports.aspx.cs" Inherits="ktms.reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>reports</div>

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
                                <asp:Label AssociatedControlID="ddlUserList" Text="User" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlUserList" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTestType_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6 form-group mb-3">
                                <asp:Label AssociatedControlID="ddlTestType" Text="Test Type" runat="server" CssClass="form-label" />
                                <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTestType_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>                                
                            </div>


                            <div class="col-md-6 form-group mb-3">
                            </div>




                            <div class="col-md-6 form-group mb-3">
                            </div>

                            <%--<div class="col-md-12">
                            
                                <asp:LinkButton ID="btnSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                            </div>--%>

                        </div>

                        <div class="col-md-6 form-group mb-3"></div>
                        <!-- Spacer -->
                        <div class="col-md-12">
                            <asp:Label Text="" ID="lblResult" CssClass="alert-success" runat="server" />
                        </div>


                        <div class="col-sm-12 table-responsive">                            
                            <asp:GridView runat="server" ID="gvData" CssClass="table table-striped m-1" AutoGenerateColumns="false" GridLines="None" EmptyDataText="There are no records to display.">
                                <Columns>
                                    <%--<asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" />--%>
                                    <asp:BoundField HeaderText="Name" DataField="Name" />
                                    <asp:BoundField HeaderText="Test Type" DataField="TestType" />
                                    <asp:BoundField HeaderText="Correct Answers" DataField="CorrectAnswers" />
                                    <asp:BoundField HeaderText="Total Questions" DataField="TotalQuestions" />
                                    <asp:BoundField HeaderText="Test Result" DataField="TestResult" />
                                    <asp:BoundField HeaderText="Created On" DataField="CreatedOn" />                                

                                    <%--<asp:TemplateField HeaderText="">
                 <ItemTemplate>
                     <asp:LinkButton ID="btnEdit" CommandArgument='<%#Eval("ID") %>' runat="server" CssClass="text-success mr-2" OnClick="btnEdit_Click" CausesValidation="false"> 
                         <i class="nav-icon i-Pen-2 font-weight-bold"></i>
                     </asp:LinkButton>
                 </ItemTemplate>
             </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </div>

            </div>

        </div>
    </div>

</asp:Content>
