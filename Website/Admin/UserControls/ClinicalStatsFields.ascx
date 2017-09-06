<%@ Control Language="C#" ClassName="ClinicalStatsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUltraSound" runat="server" Text="Ultra Sound:" AssociatedControlID="dataUltraSound" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUltraSound" Text='<%# Bind("UltraSound") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCardiology" runat="server" Text="Cardiology:" AssociatedControlID="dataCardiology" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCardiology" Text='<%# Bind("Cardiology") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLab" runat="server" Text="Lab:" AssociatedControlID="dataLab" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLab" Text='<%# Bind("Lab") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataXray" runat="server" Text="Xray:" AssociatedControlID="dataXray" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataXray" Text='<%# Bind("Xray") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsCompleted" runat="server" Text="Is Completed:" AssociatedControlID="dataIsCompleted" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsCompleted" SelectedValue='<%# Bind("IsCompleted") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateDate" runat="server" Text="Create Date:" AssociatedControlID="dataCreateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateDate" Text='<%# Bind("CreateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMedReport" runat="server" Text="Med Report:" AssociatedControlID="dataMedReport" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMedReport" Text='<%# Bind("MedReport") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataChargedCodes" runat="server" Text="Charged Codes:" AssociatedControlID="dataChargedCodes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataChargedCodes" Text='<%# Bind("ChargedCodes") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVitalSign" runat="server" Text="Vital Sign:" AssociatedControlID="dataVitalSign" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVitalSign" Text='<%# Bind("VitalSign") %>' MaxLength="50"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataPatientCode" runat="server" Text="Patient Code:" AssociatedControlID="dataPatientCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPatientCode" Text='<%# Bind("PatientCode") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPatientCode" runat="server" Display="Dynamic" ControlToValidate="dataPatientCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTid" runat="server" Text="Tid:" AssociatedControlID="dataTid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTid" Text='<%# Bind("Tid") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTid" runat="server" Display="Dynamic" ControlToValidate="dataTid" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNationality" runat="server" Text="Nationality:" AssociatedControlID="dataNationality" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNationality" Text='<%# Bind("Nationality") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNationality" runat="server" Display="Dynamic" ControlToValidate="dataNationality" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPatientStart" runat="server" Text="Patient Start:" AssociatedControlID="dataPatientStart" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPatientStart" SelectedValue='<%# Bind("PatientStart") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDob" runat="server" Text="Dob:" AssociatedControlID="dataDob" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDob" Text='<%# Bind("Dob", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDob" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" /><asp:RequiredFieldValidator ID="ReqVal_dataDob" runat="server" Display="Dynamic" ControlToValidate="dataDob" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSex" runat="server" Text="Sex:" AssociatedControlID="dataSex" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSex" Text='<%# Bind("Sex") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSex" runat="server" Display="Dynamic" ControlToValidate="dataSex" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


