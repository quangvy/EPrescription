<%@ Control Language="C#" ClassName="UsersFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserName" runat="server" Text="User Name:" AssociatedControlID="dataUserName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserName" Text='<%# Bind("UserName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserName" runat="server" Display="Dynamic" ControlToValidate="dataUserName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassword" runat="server" Text="Password:" AssociatedControlID="dataPassword" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="200"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassword" runat="server" Display="Dynamic" ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserRole" runat="server" Text="User Role:" AssociatedControlID="dataUserRole" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserRole" Text='<%# Bind("UserRole") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserRole" runat="server" Display="Dynamic" ControlToValidate="dataUserRole" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFullName" runat="server" Text="Full Name:" AssociatedControlID="dataFullName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFullName" Text='<%# Bind("FullName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFullName" runat="server" Display="Dynamic" ControlToValidate="dataFullName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmail" runat="server" Display="Dynamic" ControlToValidate="dataEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDisplayName" runat="server" Display="Dynamic" ControlToValidate="dataDisplayName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSignature" runat="server" Text="Signature:" AssociatedControlID="dataSignature" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataSignature" Value='<%# Bind("Signature") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocation" runat="server" Text="Location:" AssociatedControlID="dataLocation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocation" Text='<%# Bind("Location") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsDisabled" runat="server" Text="Is Disabled:" AssociatedControlID="dataIsDisabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIsDisabled" SelectedValue='<%# Bind("IsDisabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem><asp:ListItem Value="" Text="Pick ..." Enabled="False"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAvatar" runat="server" Text="Avatar:" AssociatedControlID="dataAvatar" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataAvatar" Value='<%# Bind("Avatar") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMobilePhone" runat="server" Text="Mobile Phone:" AssociatedControlID="dataMobilePhone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMobilePhone" Text='<%# Bind("MobilePhone") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


