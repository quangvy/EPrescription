<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Lab.aspx.cs" Inherits="Lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTid" runat="server" ></asp:Label>
    <asp:Label ID="Label1" runat="server" ></asp:Label>
    <asp:TextBox ID="txbTid" runat ="server" OnTextChanged="lblTid_DataBinding" ></asp:TextBox>
</asp:Content>

