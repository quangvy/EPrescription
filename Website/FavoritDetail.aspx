
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="FavoritDetail.aspx.cs" Inherits="FavoritDetailPage" Title="FavoritDetail List" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Favorit Detail List</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="FavoritDetailDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_FavoritDetail.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Favourite Id" DataNavigateUrlFormatString="FavoritMasterEdit.aspx?FavouriteId={0}" DataNavigateUrlFields="FavouriteId" DataContainer="FavouriteIdSource" DataTextField="DiceaseName" />
				<asp:BoundField DataField="DrugId" HeaderText="Drug Id" SortExpression="[DrugID]"  />
				<asp:BoundField DataField="DrugName" HeaderText="Drug Name" SortExpression="[DrugName]"  />
				<asp:BoundField DataField="RouteType" HeaderText="Route Type" SortExpression="[RouteType]"  />
				<asp:BoundField DataField="RouteTypeVn" HeaderText="Route Type Vn" SortExpression="[RouteTypeVN]"  />
				<asp:BoundField DataField="Dosage" HeaderText="Dosage" SortExpression="[Dosage]"  />
				<asp:BoundField DataField="DosageUnit" HeaderText="Dosage Unit" SortExpression="[DosageUnit]"  />
				<asp:BoundField DataField="DosageUnitVn" HeaderText="Dosage Unit Vn" SortExpression="[DosageUnitVN]"  />
				<asp:BoundField DataField="Frequency" HeaderText="Frequency" SortExpression="[Frequency]"  />
				<asp:BoundField DataField="FrequencyVn" HeaderText="Frequency Vn" SortExpression="[FrequencyVN]"  />
				<asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="[Duration]"  />
				<asp:BoundField DataField="DurationUnit" HeaderText="Duration Unit" SortExpression="[DurationUnit]"  />
				<asp:BoundField DataField="DurationUnitVn" HeaderText="Duration Unit Vn" SortExpression="[DurationUnitVN]"  />
				<asp:BoundField DataField="TotalUnit" HeaderText="Total Unit" SortExpression="[TotalUnit]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No FavoritDetail Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnFavoritDetail" OnClientClick="javascript:location.href='FavoritDetailEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:FavoritDetailDataSource ID="FavoritDetailDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FavoritDetailProperty Name="FavoritMaster"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:FavoritDetailDataSource>
	    		
</asp:Content>



