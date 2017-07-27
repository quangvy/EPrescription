<%@ Control Language="C#" ClassName="UserRolesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataRoleId" runat="server" Text="Role Id:" AssociatedControlID="dataRoleId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRoleId" Text='<%# Bind("RoleId") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRoleId" runat="server" Display="Dynamic" ControlToValidate="dataRoleId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRoleName" runat="server" Text="Role Name:" AssociatedControlID="dataRoleName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRoleName" Text='<%# Bind("RoleName") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRoleName" runat="server" Display="Dynamic" ControlToValidate="dataRoleName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRemark" runat="server" Text="Remark:" AssociatedControlID="dataRemark" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRemark" Text='<%# Bind("Remark") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


