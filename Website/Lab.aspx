<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Lab.aspx.cs" Inherits="Lab" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/ePressLab.css" rel="stylesheet" />
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div id="PageE">
        <div class="inputE">
            <div class="colLabel">Patient</div>
            <div class="colValue">
                <asp:Label ID="lblTid" runat="server" Width="100%"></asp:Label>
            </div>
            <div class="colLabel"></div>
            <div class="colValue">
                <asp:Button ID="btnGenPatient" runat="server" Text="Generate Patient" OnClick="btnGenPatient_Click" Width="100%" />
            </div>
        </div>

        <div class="PatInfo">
            <div class="title-info">First Name</div>
            <div class="content-info" id="divFirstname" style="margin-right: 35px;">
                &nbsp;
            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
            </div>
            <div class="title-info">Last Name</div>
            <div class="content-info" id="divLastname">
                &nbsp;
            <asp:Label ID="lblLastName" runat="server"></asp:Label>
            </div>
            <div class="clear"></div>
            <div class="title-info">DOB</div>
            <div class="content-info" id="divDOB" style="margin-right: 35px;">
                &nbsp;
            <asp:Label ID="lblDOB" runat="server" DataFormatString="dd-MMM-yyyy"></asp:Label>
            </div>
            <div class="title-info">Nationality</div>
            <div class="content-info" id="divAge">
                &nbsp;
            <asp:Label ID="lblNat" runat="server"></asp:Label>
            </div>
            <div class="clear"></div>
            <div class="title-info">Code</div>
            <div class="content-info" id="divCode" style="margin-right: 35px;">
                &nbsp;
            <asp:Label ID="lblCode" runat="server"></asp:Label>
            </div>
            <div class="title-info">Gender</div>
            <div class="content-info" id="divGender">
                &nbsp;
            <asp:Label ID="lblGender" runat="server"></asp:Label>
            </div>
            <div class="clear"></div>
        </div>
        <div class="Favourite">
            <table>
                <tr>
                    <td>Collection date: </td>
                    <td>&nbsp;<asp:TextBox ID="tbxColDate" runat="server" font-size="Smaller"> </asp:TextBox> 
                        <asp:Label ID="lblcoldate" runat="server" Text="(F) yyyy-MM-dd" font-size="XX-Small" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td>Collection time: </td>
                    <td>&nbsp;<asp:TextBox ID="tbxColTime" runat="server" font-size="Smaller"> </asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="(F) hh:mm" font-size="XX-Small" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            
        </div>
    </div>
    <div id="PageSpace"></div>
    <div id="Med">
        <div class="AddMed">
            <div class="Add">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 60%" class="text-left">Search Lab items</td>
                        <td style="width: 10%" class="text-center">Code </td>
                        <td style="width: 10%" class="text-center">Price </td>
                        <td style="width: 10%" class="text-center"></td>
                        <td style="width: 10%" class="text-center"></td>
                    </tr>
                    <tr>
                        <td style="width: 60%">
                            <telerik:RadComboBox ID="rcbSearchLab" Width="95%" runat="server" DropDownWidth="650px"
                                EmptyMessage="Please choose a Lab"
                                HighlightTemplatedItems="true"
                                RenderMode="Lightweight" AllowCustomText="true" DataSourceID="SqlDataLab" DataTextField="Description"
                                EnableLoadOnDemand="true"
                                OnSelectedIndexChanged="rcbSearchLab_SelectedIndexChanged"
                                AutoPostBack="True">
                            </telerik:RadComboBox>
                        </td>
                        <td style="width: 10%">
                            <asp:TextBox ID="tbxProCode" runat="server" Width="95%" class="text-center"></asp:TextBox></td>
                        <td style="width: 10%">
                            <asp:TextBox ID="tbxPrice" runat="server" Width="95%" class="text-right"></asp:TextBox></td>
                        <td style="width: 10%">
                            <asp:Button ID="btnAdd" runat="server" Width="95%" Text="Add" OnClick="btnAdd_Click"></asp:Button></td>
                        <td style="width: 10%">
                            <asp:Button ID="btnClear" runat="server" Width="95%" Text="Clear" OnClick="btnClearRowClick"></asp:Button></td>
                    </tr>
                </table>
            </div>
            <div class="GridMed">
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" EmptyDataText="No Lab requested yet!" OnRowDeleting="GridView1_RowDeleting" Width="97%">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="sq" />
                        <asp:TemplateField HeaderText="TID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblTID" runat="server" Text='<%# Bind("TID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReqID") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblReqID" runat="server" Text='<%# Bind("ReqID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqDoctor">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("ReqDoctor") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblReqDoctor" runat="server" Text='<%# Bind("ReqDoctor") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqDate">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("ReqDate") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblReqDate" runat="server" Text='<%# Bind("ReqDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReqStatus">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("ReqStatus") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("ReqStatus") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#333333" />
                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#487575" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#275353" />
                </asp:GridView>
            </div>
             <div class="SavePres">
                 <strong>
                <asp:Button ID="btnSave" runat="server" Width="100%" Height="30px" Text="SAVE REQUEST" OnClick="btnSave_OnClick" font-size="Large" />
                 </strong>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#tbxColDate").datepicker( );
        });
    </script>
    <asp:SqlDataSource ID="SqlDataLab" runat="server" ConnectionString="<%$ ConnectionStrings:ePrescription %>"
        SelectCommand="SELECT description FROM Vr_MedPro where main_area ='Laboratory' ORDER BY description"></asp:SqlDataSource>
</asp:Content>

