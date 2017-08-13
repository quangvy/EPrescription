
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeFile="EPrescription.aspx.cs" Inherits="EPrescriptionPage" Title="Doctor home page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EPrescriptionDataSource"
				DataKeyNames="PrescriptionId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EPrescription.xls"  		
             AllowPaging="true"
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="PrescriptionId" HeaderText="Prescription Id" SortExpression="[PrescriptionID]" ReadOnly="True" />
				<%--<asp:BoundField DataField="TransactionId" HeaderText="Transaction Id" SortExpression="[TransactionID]"  />--%>
				<asp:BoundField DataField="PatientCode" HeaderText="Patient Code" SortExpression="[PatientCode]"  />
				<asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="[LastName]"  />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]"  />
				<asp:BoundField DataField="Age" HeaderText="Age" SortExpression="[Age]"  />
                <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="[Sex]"  />
				<asp:BoundField DataField="Weight" HeaderText="Weight" SortExpression="[Weight]"  />
				<%--<asp:BoundField DataField="DeliveryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Delivery Date" SortExpression="[DeliveryDate]"  />--%>				
				<%--<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />--%>
				<%--<asp:BoundField DataField="DateOfBirth" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Of Birth" SortExpression="[DateOfBirth]"  />--%>				
				<asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" SortExpression="[Diagnosis]"  />
				<%--<asp:BoundField DataField="DiagnosisVn" HeaderText="Diagnosis Vn" SortExpression="[DiagnosisVN]"  />--%>
				<asp:BoundField DataField="PrescribingDoctor" HeaderText="Prescribing Doctor" SortExpression="[PrescribingDoctor]"  />	
				<asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="[Remark]"  />
                <asp:BoundField DataField="CreateDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Create Date" SortExpression="[CreateDate]"   />
				<%--<data:BoundRadioButtonField DataField="IsComplete" HeaderText="Is Complete" SortExpression="[IsComplete]"  />--%>
			</Columns>
			<EmptyDataTemplate>
				<b>No EPrescription Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<%--<asp:Button runat="server" ID="btnEPrescription" OnClientClick="javascript:location.href='EPrescriptionEdit.aspx'; return false;" Text="Add New"></asp:Button>--%>
		<data:EPrescriptionDataSource ID="EPrescriptionDataSource" runat="server"
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
		</data:EPrescriptionDataSource>    
	    		
</asp:Content>



