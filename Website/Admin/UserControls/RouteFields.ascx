<%@ Control Language="C#" ClassName="RouteFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
						<tr>
        <td class="literal"><asp:Label ID="lbldataRoute" runat="server" Text="Route:" AssociatedControlID="dataRoute" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRoute" Text='<%# Bind("Route") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRouteVn" runat="server" Text="Route Vn:" AssociatedControlID="dataRouteVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRouteVn" Text='<%# Bind("RouteVn") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
		</table>

	</ItemTemplate>
</asp:FormView>


