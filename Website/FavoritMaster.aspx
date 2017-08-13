
<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="FavoritMaster.aspx.cs" Inherits="FavoritMasterPage" Title="FavoritMaster List" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Favorit Master List</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="FavoritMasterDataSource"
				DataKeyNames="FavouriteId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_FavoritMaster.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="FavouriteId" HeaderText="Favourite Id" SortExpression="[FavouriteID]" ReadOnly="True" />
				<asp:BoundField DataField="DiceaseName" HeaderText="Dicease Name" SortExpression="[DiceaseName]"  />
				<asp:BoundField DataField="CreateBy" HeaderText="Create By" SortExpression="[CreateBy]"  />
				<asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" SortExpression="[Diagnosis]"  />
				<asp:BoundField DataField="DiagnosisVn" HeaderText="Diagnosis Vn" SortExpression="[DiagnosisVN]"  />
				<data:BoundRadioButtonField DataField="IsPrivate" HeaderText="Is Private" SortExpression="[IsPrivate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No FavoritMaster Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnFavoritMaster" OnClientClick="javascript:location.href='FavoritMasterEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:FavoritMasterDataSource ID="FavoritMasterDataSource" runat="server"
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
		</data:FavoritMasterDataSource>
	    		
</asp:Content>



