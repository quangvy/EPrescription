<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="PackageDetailEdit.aspx.cs" Inherits="PackageDetailEdit" Title="PackageDetail Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PackageDetailId" runat="server" DataSourceID="PackageDetailDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PackageDetailFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PackageDetailFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>PackageDetail not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PackageDetailDataSource ID="PackageDetailDataSource" runat="server"
			SelectMethod="GetByPackageDetailId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PackageDetailId" QueryStringField="PackageDetailId" Type="String" />

			</Parameters>
		</data:PackageDetailDataSource>
		
		<br />

		

</asp:Content>

