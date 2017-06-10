<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Favorite.aspx.cs" Inherits="Favorite" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div id="FavouriteNew">
        <table>
            <tr>
                <td>Favourite Name:</td>
                <td><asp:TextBox ID="FavouriteName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Diagnosis:</td>
                <td>
                    <telerik:RadComboBox RenderMode="Lightweight" ID="rcbDiag" AllowCustomText="true" runat="server" Width="450" Height="400px"
                        DataSourceID="SqlDataSource1" DataTextField="diag_name" EmptyMessage="Search for diagnosis...">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>Is Private?</td>
                <td>
                    <asp:DropDownList ID="ddlIsPrivate" runat="server">
                        <asp:ListItem Text="True" Value="1" Selected="true" />
                        <asp:ListItem Text="False" Value="2" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

    </div>
    <div id="FavouriteList">
        <table>
            <tr>
                <td>Favourite Name</td>
                <td>Detail Item
                    <tr>

                    </tr>
                </td>
            </tr>
        </table>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMS %>"
        SelectCommand="SELECT top 100 Diag_code, Diag_code+' - ' + diag_name as diag_name FROM [diag_list] ORDER BY [diag_name]">
    </asp:SqlDataSource>




</asp:Content>

