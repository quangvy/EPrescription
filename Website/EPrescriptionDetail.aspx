
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="EPrescriptionDetail.aspx.cs" Inherits="EPrescriptionDetailPage" Title="EPrescriptionDetail List" %>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">E Prescription Detail List</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EPrescriptionDetailDataSource"
				DataKeyNames="PrescriptionDetailId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EPrescriptionDetail.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Prescription Id" DataNavigateUrlFormatString="EPrescriptionEdit.aspx?PrescriptionId={0}" DataNavigateUrlFields="PrescriptionId" DataContainer="PrescriptionIdSource" DataTextField="TransactionId" />
				<asp:BoundField DataField="Sq" HeaderText="Sq" SortExpression="[Sq]"  />
				<asp:BoundField DataField="DrugId" HeaderText="Drug Id" SortExpression="[DrugId]"  />
				<asp:BoundField DataField="DrugName" HeaderText="Drug Name" SortExpression="[DrugName]"  />
				<asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="[Unit]"  />
				<asp:BoundField DataField="UnitVn" HeaderText="Unit Vn" SortExpression="[UnitVN]"  />
				<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="[Remark]"  />
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
				<b>No EPrescriptionDetail Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEPrescriptionDetail" OnClientClick="javascript:location.href='EPrescriptionDetailEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EPrescriptionDetailDataSource ID="EPrescriptionDetailDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EPrescriptionDetailProperty Name="EPrescription"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EPrescriptionDetailDataSource>
	    		
</asp:Content>



