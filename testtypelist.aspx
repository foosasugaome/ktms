<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testtypelist.aspx.cs" Inherits="ktms.testtypelist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="activePage" hidden>testtypelist</div>
    <div class="main-content-wrap sidenav-open d-flex flex-column">
        <div class="breadcrumb">
            <h1>Test Type List</h1>
            <%--<ul>
                <li><a href="#">Componets</a></li>
                <li>Table</li>
            </ul>--%>
        </div>

        <div class="separator-breadcrumb border-top"></div>

        <div class="row mb-4">


            <div class="col-md-12 mb-3">
                <div class="card text-left">

                    <div class="card-body">
                        <h4 class="card-title mb-3">Test Type List</h4>

                        <div>

                            <div class="row">
                                <div class="col-sm-2">
                                    <asp:TextBox placeholder="Search" ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlTestTypeStatus" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="All" Value="-1" />
                                        <asp:ListItem Text="Active" Value="1" />
                                        <asp:ListItem Text="Deleted" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-2">
                                    <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="lnkSubmit_Click"></asp:LinkButton>
                                </div>
                                <div class="col-sm-6">
                                    <asp:LinkButton ID="lnkAddUser" CssClass="btn btn-primary ripple m-1 float-right" runat="server" Text="Add Test Type" PostBackUrl="~/addtesttype.aspx" />
                                </div>

                            </div>
                            <div class="col-sm-12 table-responsive">
                                <asp:Label Text="" ID="lblResult" CssClass="alert-success" runat="server" />
                                <asp:GridView runat="server" ID="gvData" DataKeyNames="ID" CssClass="table table-striped m-1" AutoGenerateColumns="false" GridLines="None" EmptyDataText="There are no records to display.">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="ID" SortExpression="ID" />                                        
                                        <asp:BoundField HeaderText="Test Type" DataField="TestType" />
                                        <asp:BoundField HeaderText="Language" DataField="Language" />
                                        <asp:BoundField HeaderText="Created On" DataField="CreatedOn" />
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkChangeStatus" CommandArgument='<%#Eval("ID") %>' Text='<%#Eval("Status")%>' runat="server" OnClick="lnkChangeStatus_Click" CssClass="text-danger mr2">        
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" CommandArgument='<%#Eval("ID") %>' runat="server" CssClass="text-success mr-2" OnClick="lnkEdit_Click"> 
                                                    <i class="nav-icon i-Pen-2 font-weight-bold"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end of col-->
    </div>

    <script>
        function ConfirmDelete() {
            confirm('This action will delete the data');
        }
    </script>
</asp:Content>
