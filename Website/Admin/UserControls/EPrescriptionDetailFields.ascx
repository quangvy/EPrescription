<%@ Control Language="C#" ClassName="EPrescriptionDetailFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrescriptionId" runat="server" Text="Prescription Id:" AssociatedControlID="dataPrescriptionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataPrescriptionId" DataSourceID="PrescriptionIdEPrescriptionDataSource" DataTextField="TransactionId" DataValueField="PrescriptionId" SelectedValue='<%# Bind("PrescriptionId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:EPrescriptionDataSource ID="PrescriptionIdEPrescriptionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSq" runat="server" Text="Sq:" AssociatedControlID="dataSq" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSq" Text='<%# Bind("Sq") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSq" runat="server" Display="Dynamic" ControlToValidate="dataSq" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSq" runat="server" Display="Dynamic" ControlToValidate="dataSq" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDrugId" runat="server" Text="Drug Id:" AssociatedControlID="dataDrugId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDrugId" Text='<%# Bind("DrugId") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDrugName" runat="server" Text="Drug Name:" AssociatedControlID="dataDrugName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDrugName" Text='<%# Bind("DrugName") %>' MaxLength="250"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDrugName" runat="server" Display="Dynamic" ControlToValidate="dataDrugName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnit" runat="server" Text="Unit:" AssociatedControlID="dataUnit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUnit" Text='<%# Bind("Unit") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUnitVn" runat="server" Text="Unit Vn:" AssociatedControlID="dataUnitVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUnitVn" Text='<%# Bind("UnitVn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRemark" runat="server" Text="Remark:" AssociatedControlID="dataRemark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRemark" Text='<%# Bind("Remark") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRouteType" runat="server" Text="Route Type:" AssociatedControlID="dataRouteType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRouteType" Text='<%# Bind("RouteType") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRouteTypeVn" runat="server" Text="Route Type Vn:" AssociatedControlID="dataRouteTypeVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRouteTypeVn" Text='<%# Bind("RouteTypeVn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDosage" runat="server" Text="Dosage:" AssociatedControlID="dataDosage" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDosage" Text='<%# Bind("Dosage") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDosageUnit" runat="server" Text="Dosage Unit:" AssociatedControlID="dataDosageUnit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDosageUnit" Text='<%# Bind("DosageUnit") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDosageUnitVn" runat="server" Text="Dosage Unit Vn:" AssociatedControlID="dataDosageUnitVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDosageUnitVn" Text='<%# Bind("DosageUnitVn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFrequency" runat="server" Text="Frequency:" AssociatedControlID="dataFrequency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFrequency" Text='<%# Bind("Frequency") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFrequencyVn" runat="server" Text="Frequency Vn:" AssociatedControlID="dataFrequencyVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFrequencyVn" Text='<%# Bind("FrequencyVn") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDuration" runat="server" Text="Duration:" AssociatedControlID="dataDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDuration" Text='<%# Bind("Duration") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDurationUnit" runat="server" Text="Duration Unit:" AssociatedControlID="dataDurationUnit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDurationUnit" Text='<%# Bind("DurationUnit") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDurationUnitVn" runat="server" Text="Duration Unit Vn:" AssociatedControlID="dataDurationUnitVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDurationUnitVn" Text='<%# Bind("DurationUnitVn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalUnit" runat="server" Text="Total Unit:" AssociatedControlID="dataTotalUnit" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalUnit" Text='<%# Bind("TotalUnit") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


