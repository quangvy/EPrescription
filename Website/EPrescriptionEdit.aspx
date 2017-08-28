<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="EPrescriptionEdit.aspx.cs" Inherits="EPrescriptionEdit" Title="EPrescription Edit" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">E Prescription - Add/Edit</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="PrescriptionId" runat="server" DataSourceID="EPrescriptionDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EPrescriptionFieldsView.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/EPrescriptionFieldsView.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>EPrescription not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<%--<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />--%>
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:EPrescriptionDataSource ID="EPrescriptionDataSource" runat="server"
			SelectMethod="GetByPrescriptionId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="PrescriptionId" QueryStringField="PrescriptionId" Type="String" />

			</Parameters>
		</data:EPrescriptionDataSource>
		
		<br />

		<data:EntityGridView ID="GridViewEPrescriptionDetail1" runat="server"
			AutoGenerateColumns="False"	
			OnSelectedIndexChanged="GridViewEPrescriptionDetail1_SelectedIndexChanged"			 			 
			DataSourceID="EPrescriptionDetailDataSource1"
			DataKeyNames="PrescriptionDetailId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_EPrescriptionDetail.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
			<%--	<asp:CommandField ShowSelectButton="false" />--%>
				<data:HyperLinkField HeaderText="Prescription Id" DataNavigateUrlFormatString="EPrescriptionEdit.aspx?PrescriptionId={0}" DataNavigateUrlFields="PrescriptionId" DataContainer="PrescriptionIdSource" DataTextField="TransactionId" />
				<asp:BoundField DataField="Sq" HeaderText="Sq" SortExpression="[Sq]" />				
				<asp:BoundField DataField="DrugId" HeaderText="Drug Id" SortExpression="[DrugId]" />				
				<asp:BoundField DataField="DrugName" HeaderText="Drug Name" SortExpression="[DrugName]" />				
				<asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="[Unit]" />				
				<asp:BoundField DataField="UnitVn" HeaderText="Unit Vn" SortExpression="[UnitVN]" />				
				<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="[Remark]" />				
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
				<b>No E Prescription Detail Found! </b>
				<asp:HyperLink runat="server" ID="hypEPrescriptionDetail" NavigateUrl="~/admin/EPrescriptionDetailEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:EPrescriptionDetailDataSource ID="EPrescriptionDetailDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EPrescriptionDetailProperty Name="EPrescription"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:EPrescriptionDetailFilter  Column="PrescriptionId" QueryStringField="PrescriptionId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EPrescriptionDetailDataSource>		
		
		<br />
		

</asp:Content>

