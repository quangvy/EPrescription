<%@ Control Language="C#" ClassName="DiaglistFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCategory" runat="server" Text="Category:" AssociatedControlID="dataCategory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCategory" Text='<%# Bind("Category") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCategory" runat="server" Display="Dynamic" ControlToValidate="dataCategory" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagCode" runat="server" Text="Diag Code:" AssociatedControlID="dataDiagCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagCode" Text='<%# Bind("DiagCode") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDiagCode" runat="server" Display="Dynamic" ControlToValidate="dataDiagCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagName" runat="server" Text="Diag Name:" AssociatedControlID="dataDiagName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagName" Text='<%# Bind("DiagName") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDiagName" runat="server" Display="Dynamic" ControlToValidate="dataDiagName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagNameVn" runat="server" Text="Diag Name Vn:" AssociatedControlID="dataDiagNameVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagNameVn" Text='<%# Bind("DiagNameVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDiagNameVn" runat="server" Display="Dynamic" ControlToValidate="dataDiagNameVn" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsDisabled" runat="server" Text="Is Disabled:" AssociatedControlID="dataIsDisabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsDisabled" SelectedValue='<%# Bind("IsDisabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


