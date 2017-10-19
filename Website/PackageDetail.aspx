
<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="PackageDetail.aspx.cs" Inherits="PackageDetailPage" Title="PackageDetail List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PackageDetailDataSource"
				DataKeyNames="PackageDetailId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PackageDetail.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="ClinicPrice" HeaderText="Clinic Price" SortExpression="[ClinicPrice]"  />
				<data:HyperLinkField HeaderText="Package Id" DataNavigateUrlFormatString="PackageEdit.aspx?PackageId={0}" DataNavigateUrlFields="PackageId" DataContainer="PackageIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="[Code]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PackageDetail Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPackageDetail" OnClientClick="javascript:location.href='PackageDetailEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:PackageDetailDataSource ID="PackageDetailDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PackageDetailProperty Name="Package"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:PackageDetailDataSource>
	    		
</asp:Content>



