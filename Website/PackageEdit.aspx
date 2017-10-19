<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"  CodeFile="PackageEdit.aspx.cs" Inherits="PackageEdit" Title="Package Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PackageId" runat="server" DataSourceID="PackageDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PackageFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PackageFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Package not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PackageDataSource ID="PackageDataSource" runat="server"
			SelectMethod="GetByPackageId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PackageId" QueryStringField="PackageId" Type="String" />

			</Parameters>
		</data:PackageDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewPackageDetail1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewPackageDetail1_SelectedIndexChanged"			 			 
			DataSourceID="PackageDetailDataSource1"
			DataKeyNames="PackageDetailId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_PackageDetail.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Package Id" DataNavigateUrlFormatString="PackageEdit.aspx?PackageId={0}" DataNavigateUrlFields="PackageId" DataContainer="PackageIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Code" HeaderText="Code" SortExpression="[Code]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="ClinicPrice" HeaderText="Clinic Price" SortExpression="[ClinicPrice]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Package Detail Found! </b>
				<asp:HyperLink runat="server" ID="hypPackageDetail" NavigateUrl="~/admin/PackageDetailEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:PackageDetailDataSource ID="PackageDetailDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:PackageDetailProperty Name="Package"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:PackageDetailFilter  Column="PackageId" QueryStringField="PackageId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:PackageDetailDataSource>		
		
		<br />
		

</asp:Content>

