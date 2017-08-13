<%@ Page Language="C#"  MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="RouteEdit.aspx.cs" Inherits="RouteEdit" Title="Route Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="RouteId" runat="server" DataSourceID="RouteDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RouteFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RouteFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Route not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:RouteDataSource ID="RouteDataSource" runat="server"
			SelectMethod="GetByRouteId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="RouteId" QueryStringField="RouteId" Type="String" />

			</Parameters>
		</data:RouteDataSource>
		
		<br />

		

</asp:Content>

