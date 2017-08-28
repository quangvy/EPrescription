<%@ Control Language="C#" ClassName="EPrescriptionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrescriptionId" runat="server" Text="Prescription Id:" AssociatedControlID="dataPrescriptionId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrescriptionId" Text='<%# Bind("PrescriptionId") %>' MaxLength="20"></asp:TextBox>
				</td>
			    <td>
                    <asp:Label ID="lbldataLastName" runat="server" AssociatedControlID="dataLastName" Text="Full Name:" />
                </td>
                <td>
                    <asp:TextBox ID="dataLastName" runat="server" MaxLength="30" Text='<%# Bind("LastName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="dataFirstName" runat="server" MaxLength="30" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lbldataDateOfBirth" runat="server" AssociatedControlID="dataDateOfBirth" Text="Date Of Birth:" />
                </td>
                <td>
                    <asp:TextBox ID="dataDateOfBirth" runat="server" MaxLength="10" Text='<%# Bind("DateOfBirth", "{0:d}") %>'></asp:TextBox>
                </td>
			</tr>
			<tr>
        <td class="literal">
            <asp:Label ID="lbldataCreateDate" runat="server" AssociatedControlID="dataCreateDate" Text="Create Date:" />
                </td>
        <td>
					<asp:TextBox ID="dataCreateDate" runat="server" MaxLength="10" Text='<%# Bind("CreateDate", "{0:d}") %>'></asp:TextBox>
				</td>
			    <td>
                    <asp:Label ID="lbldataPatientCode" runat="server" AssociatedControlID="dataPatientCode" Text="Patient Code:" />
                </td>
                <td>
                    <asp:TextBox ID="dataPatientCode" runat="server" MaxLength="50" Text='<%# Bind("PatientCode") %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lbldataAge" runat="server" AssociatedControlID="dataAge" Text="Age:" />
                </td>
                <td>
                    <asp:TextBox ID="dataAge" runat="server" MaxLength="20" Text='<%# Bind("Age") %>'></asp:TextBox>
                </td>
			</tr>
			<tr>
        <td class="literal">
            <asp:Label ID="lbldataPrescribingDoctor" runat="server" AssociatedControlID="dataPrescribingDoctor" Text="Prescribing Doctor:" />
                </td>
        <td>
					<asp:TextBox ID="dataPrescribingDoctor" runat="server" MaxLength="100" Text='<%# Bind("PrescribingDoctor") %>'></asp:TextBox>
                </td>
			    <td>
                    <asp:Label ID="lbldataSex" runat="server" AssociatedControlID="dataSex" Text="Sex:" />
                </td>
                <td>
                    <asp:TextBox ID="dataSex" runat="server" MaxLength="10" Text='<%# Bind("Sex") %>'></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lbldataWeight" runat="server" AssociatedControlID="dataWeight" Text="Weight:" />
                </td>
                <td>
                    <asp:TextBox ID="dataWeight" runat="server" MaxLength="20" Text='<%# Bind("Weight") %>'></asp:TextBox>
                </td>
			</tr>
			<tr>
        <td class="literal">
            <asp:Label ID="lbldataDiagnosis" runat="server" AssociatedControlID="dataDiagnosis" Text="Diagnosis:" />
                </td>
        <td>
					<asp:TextBox ID="dataDiagnosis" runat="server" Height="27px" Rows="5" Text='<%# Bind("Diagnosis") %>' TextMode="MultiLine" Width="250px"></asp:TextBox>
                </td>
			    <td>
                    <asp:Label ID="lbldataAddress" runat="server" AssociatedControlID="dataAddress" Text="Address:" />
                </td>
                <td>
                    <asp:TextBox ID="dataAddress" runat="server" MaxLength="150" Text='<%# Bind("Address") %>' TextMode="MultiLine" ></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="lbldataRemark" runat="server" AssociatedControlID="dataRemark" Text="Remark:" />
                </td>
                <td>
                    <asp:TextBox ID="dataRemark" runat="server" MaxLength="250" Text='<%# Bind("Remark") %>' TextMode="MultiLine" ></asp:TextBox>
                </td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


