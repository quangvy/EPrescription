
<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="Users.aspx.cs" Inherits="UsersPage" Title="Users List" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Users List</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="UsersDataSource"
				DataKeyNames="UserName"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Users.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" ReadOnly="True" />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]"  />
				<asp:BoundField DataField="UserRole" HeaderText="User Role" SortExpression="[UserRole]"  />
				<asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="[FullName]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]"  />
				<asp:BoundField DataField="Signature" HeaderText="Signature" SortExpression="[Signature]"  />
				<asp:BoundField DataField="Location" HeaderText="Location" SortExpression="[Location]"  />
				<data:BoundRadioButtonField DataField="IsDisabled" HeaderText="Is Disabled" SortExpression="[IsDisabled]"  />
				<asp:BoundField DataField="Avatar" HeaderText="Avatar" SortExpression="[Avatar]"  />
				<asp:BoundField DataField="MobilePhone" HeaderText="Mobile Phone" SortExpression="[MobilePhone]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Users Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUsers" OnClientClick="javascript:location.href='UsersEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:UsersDataSource ID="UsersDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:UsersDataSource>
	    		
</asp:Content>



