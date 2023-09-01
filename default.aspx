<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ktms._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Session["username"] = "Norman Teodoro";    
    %>


    <div class="separator-breadcrumb border-top"></div>

     <div class="main-content-wrap sidenav-open d-flex flex-column">
     <div class="main-content">
         <div class="breadcrumb">
             <h1>Hello <asp:Label ID="lblFullName" runat="server" /></h1>
           
         </div>

         <div class="separator-breadcrumb border-top"></div>

         <!-- content goes here -->
         <div>
             <asp:Label ID="Label1" runat="server" Text="">This could serve as the landing page for normal users since they may not have access to the Dashboard.</asp:Label>
         </div>
     </div>
     <!-- end of main content -->    
 </div>
</asp:Content>
