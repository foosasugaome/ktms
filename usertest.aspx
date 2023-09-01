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
         <div class="col-md-6 offset-3">
             <div class="card mb-4">
                 <div class="card-body">
                 
                     <div class="card-title mb-3">Start Test</div>

                     <div class="row">

                         <div class="col-md-6 form-group mb-3">
                             <asp:Label AssociatedControlID="ddlTestType" Text="Test Type" runat="server" CssClass="form-label" />
                             <asp:DropDownList ID="ddlTestType" runat="server" CssClass="form-control">
                                 <asp:ListItem Selected="True" Value="0" Text="Select" />
                                 <asp:ListItem Value="1" Text="Class 5" />
                                 <asp:ListItem Value="2" Text="Class 7" />
                             </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ErrorMessage="Please select test type." ControlToValidate="ddlTestType" CssClass="invalid-feedback" Display="Dynamic" />
                         </div>                         


                         <div class="col-md-6 form-group mb-3">
                         </div>

                         <div class="col-md-12">
                             <%--<asp:LinkButton ID="lnkCancel" CssClass="btn btn-dark float-right m-1" Text="Cancel" runat="server" PostBackUrl="~/default.aspx" CausesValidation="false" />--%>
                             <asp:LinkButton ID="lnkSubmit" CssClass="btn btn-primary float-right m-1" Text="Submit" runat="server" />
                         </div>

                     </div>

                 </div>

             </div>

         </div>

     </div>
 </div>


</asp:Content>
