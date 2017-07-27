<%@ Control Language="C#" ClassName="FavoritMasterFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiceaseName" runat="server" Text="Dicease Name:" AssociatedControlID="dataDiceaseName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiceaseName" Text='<%# Bind("DiceaseName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDiceaseName" runat="server" Display="Dynamic" ControlToValidate="dataDiceaseName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateBy" runat="server" Text="Create By:" AssociatedControlID="dataCreateBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateBy" Text='<%# Bind("CreateBy") %>' MaxLength="50"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataIsPrivate" runat="server" Text="Is Private:" AssociatedControlID="dataIsPrivate" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsPrivate" SelectedValue='<%# Bind("IsPrivate") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


