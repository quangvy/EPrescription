<%@ Page Language="C#"  MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="FrequencyEdit.aspx.cs" Inherits="FrequencyEdit" Title="Frequency Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="FrequencyId" runat="server" DataSourceID="FrequencyDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FrequencyFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FrequencyFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Frequency not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:FrequencyDataSource ID="FrequencyDataSource" runat="server"
			SelectMethod="GetByFrequencyId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="FrequencyId" QueryStringField="FrequencyId" Type="String" />

			</Parameters>
		</data:FrequencyDataSource>
		
		<br />

		

</asp:Content>

