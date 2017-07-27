<%@ Control Language="C#" ClassName="EPrescriptionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrescriptionId" runat="server" Text="Prescription Id:" AssociatedControlID="dataPrescriptionId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrescriptionId" Text='<%# Bind("PrescriptionId") %>' MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrescriptionId" runat="server" Display="Dynamic" ControlToValidate="dataPrescriptionId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionId" runat="server" Text="Transaction Id:" AssociatedControlID="dataTransactionId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionId" Text='<%# Bind("TransactionId") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPatientCode" runat="server" Text="Patient Code:" AssociatedControlID="dataPatientCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPatientCode" Text='<%# Bind("PatientCode") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPatientCode" runat="server" Display="Dynamic" ControlToValidate="dataPatientCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstName" runat="server" Text="First Name:" AssociatedControlID="dataFirstName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstName" Text='<%# Bind("FirstName") %>' MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFirstName" runat="server" Display="Dynamic" ControlToValidate="dataFirstName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastName" runat="server" Text="Last Name:" AssociatedControlID="dataLastName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastName" Text='<%# Bind("LastName") %>' MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLastName" runat="server" Display="Dynamic" ControlToValidate="dataLastName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeliveryDate" runat="server" Text="Delivery Date:" AssociatedControlID="dataDeliveryDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeliveryDate" Text='<%# Bind("DeliveryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDeliveryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDeliveryDate" runat="server" Display="Dynamic" ControlToValidate="dataDeliveryDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateDate" runat="server" Text="Create Date:" AssociatedControlID="dataCreateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateDate" Text='<%# Bind("CreateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataCreateDate" runat="server" Display="Dynamic" ControlToValidate="dataCreateDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' MaxLength="150"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateOfBirth" runat="server" Text="Date Of Birth:" AssociatedControlID="dataDateOfBirth" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateOfBirth" Text='<%# Bind("DateOfBirth", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateOfBirth" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAge" runat="server" Text="Age:" AssociatedControlID="dataAge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAge" Text='<%# Bind("Age") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeight" runat="server" Text="Weight:" AssociatedControlID="dataWeight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeight" Text='<%# Bind("Weight") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagnosis" runat="server" Text="Diagnosis:" AssociatedControlID="dataDiagnosis" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagnosis" Text='<%# Bind("Diagnosis") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagnosisVn" runat="server" Text="Diagnosis Vn:" AssociatedControlID="dataDiagnosisVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagnosisVn" Text='<%# Bind("DiagnosisVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrescribingDoctor" runat="server" Text="Prescribing Doctor:" AssociatedControlID="dataPrescribingDoctor" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrescribingDoctor" Text='<%# Bind("PrescribingDoctor") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSex" runat="server" Text="Sex:" AssociatedControlID="dataSex" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSex" Text='<%# Bind("Sex") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRemark" runat="server" Text="Remark:" AssociatedControlID="dataRemark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRemark" Text='<%# Bind("Remark") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsComplete" runat="server" Text="Is Complete:" AssociatedControlID="dataIsComplete" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsComplete" SelectedValue='<%# Bind("IsComplete") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


