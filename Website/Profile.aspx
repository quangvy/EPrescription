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
            <td>Full name</td>
            <td> <asp:TextBox runat="server" ID="txtFullName"/></td>
        </tr>
        <tr>
            <td>Display name</td>
            <td> <asp:TextBox runat="server" ID="txtDisplayName"/></td>
        </tr>
        <tr>
            <td>Email</td>
            <td> <asp:TextBox runat="server" ID="txtEmail"/></td>
        </tr>
        <tr>
            <td>Mobile phone number</td>
            <td> <asp:TextBox runat="server" ID="txtMobilePhone"/></td>
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
                <asp:FileUpload runat="server" ID="fulAvatar" accept="image/*" />
            </td>
        </tr>
        <tr>
            <td>Signature</td>
            <td>
                <asp:Image ID="imgSignature" runat="server" />
                <asp:FileUpload runat="server" ID="fulSignature" accept="image/*" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton runat="server" ID="btnSubmit" Text="Update" CausesValidation="True" OnClick="btnSubmit_OnClick" />
                <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" CausesValidation="False" /></td>
        </tr>
    </table>







</asp:Content>

