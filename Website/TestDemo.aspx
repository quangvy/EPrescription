<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TestDemo.aspx.cs" Inherits="TestDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DropDownList ID="ddlPO" runat="server" ToolTip ="Chọn PO">
            <asp:ListItem Text="HĐ chính" Value="HĐ chính"></asp:ListItem>
            <asp:ListItem Text="Phế liệu Maruchi" Value="Phế liệu Maruchi"></asp:ListItem>
            <asp:ListItem Text="HDMU CAWB3371327" Value="HDMU CAWB3371327"></asp:ListItem>
            <asp:ListItem Text="MAEU 572411852" Value="MAEU 572411852"></asp:ListItem>
            <asp:ListItem Text="MAEU 960012978" Value="MAEU 960012978"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>

