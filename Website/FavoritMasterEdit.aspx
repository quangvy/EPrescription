<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="FavoritMasterEdit.aspx.cs" Inherits="FavoritMasterEdit" Title="FavoritMaster Edit" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Favorit Master - Add/Edit</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="FavouriteId" runat="server" DataSourceID="FavoritMasterDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FavoritMasterFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FavoritMasterFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>FavoritMaster not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:FavoritMasterDataSource ID="FavoritMasterDataSource" runat="server"
			SelectMethod="GetByFavouriteId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="FavouriteId" QueryStringField="FavouriteId" Type="String" />

			</Parameters>
		</data:FavoritMasterDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewFavoritDetail1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewFavoritDetail1_SelectedIndexChanged"			 			 
			DataSourceID="FavoritDetailDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_FavoritDetail.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Favourite Id" DataNavigateUrlFormatString="FavoritMasterEdit.aspx?FavouriteId={0}" DataNavigateUrlFields="FavouriteId" DataContainer="FavouriteIdSource" DataTextField="DiceaseName" />
				<asp:BoundField DataField="DrugId" HeaderText="Drug Id" SortExpression="[DrugID]" />				
				<asp:BoundField DataField="DrugName" HeaderText="Drug Name" SortExpression="[DrugName]" />				
				<asp:BoundField DataField="RouteType" HeaderText="Route Type" SortExpression="[RouteType]" />				
				<asp:BoundField DataField="RouteTypeVn" HeaderText="Route Type Vn" SortExpression="[RouteTypeVN]" />				
				<asp:BoundField DataField="Dosage" HeaderText="Dosage" SortExpression="[Dosage]" />				
				<asp:BoundField DataField="DosageUnit" HeaderText="Dosage Unit" SortExpression="[DosageUnit]" />				
				<asp:BoundField DataField="DosageUnitVn" HeaderText="Dosage Unit Vn" SortExpression="[DosageUnitVN]" />				
				<asp:BoundField DataField="Frequency" HeaderText="Frequency" SortExpression="[Frequency]" />				
				<asp:BoundField DataField="FrequencyVn" HeaderText="Frequency Vn" SortExpression="[FrequencyVN]" />				
				<asp:BoundField DataField="Duration" HeaderText="Duration" SortExpression="[Duration]" />				
				<asp:BoundField DataField="DurationUnit" HeaderText="Duration Unit" SortExpression="[DurationUnit]" />				
				<asp:BoundField DataField="DurationUnitVn" HeaderText="Duration Unit Vn" SortExpression="[DurationUnitVN]" />				
				<asp:BoundField DataField="TotalUnit" HeaderText="Total Unit" SortExpression="[TotalUnit]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Favorit Detail Found! </b>
				<asp:HyperLink runat="server" ID="hypFavoritDetail" NavigateUrl="~/FavoritDetailEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:FavoritDetailDataSource ID="FavoritDetailDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FavoritDetailProperty Name="FavoritMaster"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:FavoritDetailFilter  Column="FavouriteId" QueryStringField="FavouriteId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:FavoritDetailDataSource>		
		
		<br />
		

</asp:Content>

