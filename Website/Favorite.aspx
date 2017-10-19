<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Favorite.aspx.cs" Inherits="Favorite" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/fav.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div id="Med">
        <div class="AddMed">
            <div >
                <asp:Label ID="lblFav" runat="server" Text ="Favourite name: " Width="17%"></asp:Label>
                <asp:TextBox ID="tbxFavName" runat="server" Width="82%"></asp:TextBox>
            </div>
            <div class="Add">
                <table style="width: 100%;">
                    <tr>
                        <td>Search by Generic Name</td>
                        <td>DrugID</td>
                        <td>Form.</td>
                        <td>Route</td>
                        <td>Dosage</td>
                        <td>DosUnit</td>
                        <td>Freq</td>
                        <td>Dur</td>
                        <td>DUnit</td>
                        <td>Total</td>                        
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="rcbSearchMed" Width="230px" runat="server" DropDownWidth="600"
                                EmptyMessage="Please choose a medication"
                                HighlightTemplatedItems="true"
                                EnableLoadOnDemand="true"
                                AutoPostBack="True"
                                OnItemsRequested="rcbSearchMed_ItemsRequested"
                                OnSelectedIndexChanged="rcbSearchMed_SelectedIndexChanged">

                                <HeaderTemplate>
                                    <table style="width: 600px;">
                                        <tr>
                                            <td style="width: 40px;">Drug ID</td>
                                            <td style="width: 200px;">Drug Name</td>
                                            <td style="width: 200px;">Generic Name</td>
                                            <td style="width: 30px;">Quantity</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table style="width: 580px; font-size: smaller">
                                        <tr>
                                            <td style="width: 30px"><%# DataBinder.Eval(Container, "Attributes['DrugID']")%></td>
                                            <td style="width: 200px"><%# DataBinder.Eval(Container,"Attributes['DrugName']")%></td>
                                            <td style="width: 200px"><%# DataBinder.Eval(Container, "Text")%></td>
                                            <td style="width: 30px"><%# DataBinder.Eval(Container, "Attributes['Quantity']")%></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:Label ID="lblDrugID" runat="server" Width="50px"
                                Font-Size="Smaller"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Width="50px"
                                Font-Size="Smaller"></asp:Label></td>
                        <td>
                            <telerik:RadComboBox ID="rcbRoute" Width="50px" runat="server" DropDownWidth="100"
                                RenderMode="Lightweight" AllowCustomText="true" DataSourceID="SqlDataSource3" DataTextField="route"
                                EmptyMessage="Route...">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxDosage" runat="server" Width="30px"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="lblDosageUnit" runat="server" Width="40px" Height="21px"
                                Font-Size="Smaller"></asp:TextBox></td>
                        <td>
                            <telerik:RadComboBox ID="rcbFreq" Width="50px" runat="server" DropDownWidth="300"
                                RenderMode="Lightweight" AllowCustomText="true" DataSourceID="SqlDataSource2"
                                DataValueField="abbre" DataTextField="meaning"
                                EmptyMessage="Frequency...">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxDuration" runat="server" Width="30px"></asp:TextBox></td>
                        <td>
                            <asp:DropDownList ID="ddlDUnit" runat="server" Width="40px" Height="21px"
                                Font-Size="Small">
                                <asp:ListItem>Day(s)</asp:ListItem>
                                <asp:ListItem>Hour(s)</asp:ListItem>
                                <asp:ListItem>Week(s)</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>
                            <asp:TextBox ID="tbxTotalUnit" runat="server" Width="30px"></asp:TextBox></td>
                        <asp:RegularExpressionValidator ID="NumberOnlyTotal" runat="server" ControlToValidate="tbxTotalUnit" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">
                        </asp:RegularExpressionValidator>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Add" Width="40px" /></td>
                        <td>
                            <asp:Button ID="btnClearRow" runat="server" OnClick="btnClearRowClick"
                                Text="Clear" Width="40px" /></td>
                    </tr>
                </table>

            </div>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ePrescription %>"
            SelectCommand="SELECT abbre, abbre+ ' - ' + meaning as meaning FROM [Frequency] ORDER BY [abbre]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ePrescription %>"
            SelectCommand="SELECT route FROM [route] ORDER BY [route]"></asp:SqlDataSource>
            <div class="GridMed">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                    ForeColor="Black" GridLines="Vertical"
                    EmptyDataText="No record has been added!" OnRowEditing="OnRowEditing"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" Text="Upd." runat="server" OnClick="OnUpdate" />
                                <asp:LinkButton ID="LinkButton2" Text="Can." runat="server" OnClick="OnCancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Del" ShowDeleteButton="True" ButtonType="Link" />
                        <asp:BoundField HeaderText="Sq" DataField="ID" ItemStyle-Width="15px" ControlStyle-Width="15" ItemStyle-HorizontalAlign="Center">
                            <ControlStyle Width="15px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="15px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drug Name" DataField="Drugname" ItemStyle-Width="300px" ControlStyle-Width="300" ReadOnly="true">
                            <ControlStyle Width="300px"></ControlStyle>

                            <ItemStyle Width="300px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Drug ID" DataField="DrugID" ItemStyle-Width="50px" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                            <ControlStyle Width="50px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Route" DataField="RouteType" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Form" DataField="Unit" ItemStyle-Width="60px" ControlStyle-Width="60" ItemStyle-HorizontalAlign="Center" ReadOnly="true">
                            <ControlStyle Width="60px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Dosage" DataField="Dosage" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Dose.Unit" DataField="DosageUnit" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" ReadOnly="true" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Freq" DataField="Frequency" ItemStyle-Width="50px" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="50px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Dur." DataField="Duration" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="D_Unit" DataField="DurationUnit" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Total" DataField="TotalUnit" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" NullDisplayText=" ">
                            <ControlStyle Width="40px"></ControlStyle>

                            <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Refill">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkEditRefill" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="label1" runat="server" Text='<%# Bind("Refill") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Remark" DataField="Remark" ItemStyle-Width="140px" ControlStyle-Width="140" NullDisplayText=" ">
                            <ControlStyle Width="140px"></ControlStyle>

                            <ItemStyle Width="140px"></ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#008066" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="SavePres">
                <asp:Button ID="btnSave" runat="server" Width="100%" Height="30px" Text="SAVE FAVOURITE" OnClick="btnSave_OnClick" />
            </div>
        </div>

        <div class="LoadPres">
            <asp:Repeater runat="server" ID="rptFavorite" OnItemDataBound="rptFavorite_ItemDataBound" OnItemCommand="rptFavorite_OnItemCommand">
                <ItemTemplate>
                    <input type="checkbox" class="toggle-box" id="identifier" runat="server" />
                    <asp:Label AssociatedControlID='identifier' runat="server" ID="lblDiceaseName" Text='<%#Eval("DiceaseName") %>'></asp:Label>
                    <div>
                            <asp:Button runat="server" ID="btnAdd" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("FavouriteId") %>'></asp:Button>
                        <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="DrugID" HeaderText="Drug ID" />
                                <asp:BoundField DataField="DrugName" HeaderText="Drug Name" />
                                <asp:BoundField DataField="Frequency" HeaderText="Frequency" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
        </div>
    </div>

</asp:Content>

