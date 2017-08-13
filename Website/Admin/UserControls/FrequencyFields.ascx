<%@ Control Language="C#" ClassName="FrequencyFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAbbre" runat="server" Text="Abbre:" AssociatedControlID="dataAbbre" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAbbre" Text='<%# Bind("Abbre") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMeaning" runat="server" Text="Meaning:" AssociatedControlID="dataMeaning" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMeaning" Text='<%# Bind("Meaning") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataVnMeaning" runat="server" Text="Vn Meaning:" AssociatedControlID="dataVnMeaning" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataVnMeaning" Text='<%# Bind("VnMeaning") %>' MaxLength="250"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


