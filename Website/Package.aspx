
<%@ Page Language="C#"  MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="Package.aspx.cs" Inherits="PackagePage" Title="Package List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PackageDataSource"
				DataKeyNames="PackageId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Package.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CostPrice" HeaderText="Cost Price" SortExpression="[CostPrice]"  />
				<asp:BoundField DataField="CreatedBy" HeaderText="Created By" SortExpression="[CreatedBy]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="SellPrice" HeaderText="Sell Price" SortExpression="[SellPrice]"  />
				<asp:BoundField DataField="PackageId" HeaderText="Package Id" SortExpression="[PackageID]" ReadOnly="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Package Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPackage" OnClientClick="javascript:location.href='PackageEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PackageDataSource ID="PackageDataSource" runat="server"
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
		</data:PackageDataSource>
	    		
</asp:Content>



