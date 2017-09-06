<%@ Control Language="C#" ClassName="VitalSignFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeight" runat="server" Text="Weight:" AssociatedControlID="dataWeight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeight" Text='<%# Bind("Weight") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHeight" runat="server" Text="Height:" AssociatedControlID="dataHeight" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHeight" Text='<%# Bind("Height") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataGcs" runat="server" Text="Gcs:" AssociatedControlID="dataGcs" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataGcs" Text='<%# Bind("Gcs") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateUser" runat="server" Text="Update User:" AssociatedControlID="dataUpdateUser" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateUser" Text='<%# Bind("UpdateUser") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateDate" runat="server" Text="Update Date:" AssociatedControlID="dataUpdateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateDate" Text='<%# Bind("UpdateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateDate" runat="server" Text="Create Date:" AssociatedControlID="dataCreateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateDate" Text='<%# Bind("CreateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSato2" runat="server" Text="Sato2:" AssociatedControlID="dataSato2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSato2" Text='<%# Bind("Sato2") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTempurature" runat="server" Text="Tempurature:" AssociatedControlID="dataTempurature" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTempurature" Text='<%# Bind("Tempurature") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTid" runat="server" Text="Tid:" AssociatedControlID="dataTid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTid" Text='<%# Bind("Tid") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTid" runat="server" Display="Dynamic" ControlToValidate="dataTid" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPatientCode" runat="server" Text="Patient Code:" AssociatedControlID="dataPatientCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPatientCode" Text='<%# Bind("PatientCode") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPatientCode" runat="server" Display="Dynamic" ControlToValidate="dataPatientCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBloodPressure" runat="server" Text="Blood Pressure:" AssociatedControlID="dataBloodPressure" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBloodPressure" Text='<%# Bind("BloodPressure") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRespiratory" runat="server" Text="Respiratory:" AssociatedControlID="dataRespiratory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRespiratory" Text='<%# Bind("Respiratory") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPulse" runat="server" Text="Pulse:" AssociatedControlID="dataPulse" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPulse" Text='<%# Bind("Pulse") %>' MaxLength="15"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


