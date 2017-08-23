
<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Route.aspx.cs" Inherits="RoutePage" Title="Route List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="RouteDataSource"
				DataKeyNames="RouteId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Route.xls" 
             AllowPaging =" true" 		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Route" HeaderText="Route" SortExpression="[Route]"  />
				<asp:BoundField DataField="RouteVn" HeaderText="Route Vn" SortExpression="[RouteVN]"  />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Route Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRoute" OnClientClick="javascript:location.href='RouteEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:RouteDataSource ID="RouteDataSource" runat="server"
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
		</data:RouteDataSource>
	    		
</asp:Content>



