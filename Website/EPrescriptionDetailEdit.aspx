<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="EPrescriptionDetailEdit.aspx.cs" Inherits="EPrescriptionDetailEdit" Title="EPrescriptionDetail Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PrescriptionDetailId" runat="server" DataSourceID="EPrescriptionDetailDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EPrescriptionDetailFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EPrescriptionDetailFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EPrescriptionDetail not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EPrescriptionDetailDataSource ID="EPrescriptionDetailDataSource" runat="server"
			SelectMethod="GetByPrescriptionDetailId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PrescriptionDetailId" QueryStringField="PrescriptionDetailId" Type="String" />

			</Parameters>
		</data:EPrescriptionDetailDataSource>
		
		<br />

		

</asp:Content>

