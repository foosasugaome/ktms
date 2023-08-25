<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ktms._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%
        Session["username"] = "Norman";
    %>
    <div class="breadcrumb">
        <h1>Hello <%=Session["username"] %>!</h1>
        <ul>
            <%--<li><a href="#">UI Kits</a></li>
            <li>Blank Page</li>--%>
        </ul>

    </div>

    <div class="separator-breadcrumb border-top"></div>
</asp:Content>
