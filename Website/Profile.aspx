<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="ProfilePage" Title="My Profile" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Users - Add/Edit</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td colspan="2">
                <h1>Update profile</h1>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Retype Password</td>
            <td>
                <asp:TextBox runat="server" ID="txtRetypePassword" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator runat="server" ErrorMessage="Password must match" ControlToCompare="txtRetypePassword" ControlToValidate="txtPassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Avatar
            </td>
            <td>
                <asp:Image ID="imgAvatar" runat="server" />
                <asp:FileUpload runat="server" ID="fulAvatar" />
            </td>
        </tr>
        <tr>
            <td>Signature</td>
            <td>
                <asp:Image ID="imgSignature" runat="server" />
                <asp:FileUpload runat="server" ID="fulSignature" /></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton runat="server" ID="btnSubmit" Text="Update" CausesValidation="True" /></td>
        </tr>
    </table>







</asp:Content>

