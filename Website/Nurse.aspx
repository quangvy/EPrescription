<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Nurse.aspx.cs" Inherits="Nurse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="css/nurse.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="waiting">
        Waiting patients
        <data:EntityGridView ID="gridWaitingPat" runat="server"
            AutoGenerateColumns="False"
            DataSourceID="VrLabReqDataSource"
            DataKeyNames="TID"
            AllowMultiColumnSorting="False"
            DefaultSortColumnName="[TID]"
            DefaultSortDirection="Ascending"
            AllowPaging="True" AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="10" RecordsCount="0" ShowGridOnEmptyData="False"
            OnRowCommand="gridWaitingPat_process">

            <Columns>
                <asp:TemplateField HeaderText="CMD">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkProcess" runat="server" CommandName="Process" CommandArgument='<%#Bind("TID") %>'>Add</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TID" SortExpression="[TID]">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbxTID" runat="server" Text='<%# Bind("TID") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTID" runat="server" Text='<%# Bind("TID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PatientCode" SortExpression="[PatientCode]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PatientCode") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPatientCode" runat="server" Text='<%# Bind("PatientCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FirstName" SortExpression="[FirstName]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastName" SortExpression="[LastName]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DOB" SortExpression="[DOB]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DOB") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DOB","{0:dd-MMM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sex" SortExpression="[Sex]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Sex") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSex" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nationality" SortExpression="[Nationality]">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Nationality") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNationality" runat="server" Text='<%# Bind("Nationality") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <b>No patients yet</b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <br />

        <data:VrLabReqDataSource ID="VrLabReqDataSource" runat="server"
            SelectMethod="GetPaged"
            EnablePaging="True"
            EnableSorting="True">
            <Parameters>
                <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
                <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                <asp:ControlParameter Name="PageIndex" ControlID="gridWaitingPat" PropertyName="PageIndex" Type="Int32" />
                <asp:ControlParameter Name="PageSize" ControlID="gridWaitingPat" PropertyName="PageSize" Type="Int32" />
                <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
            </Parameters>
        </data:VrLabReqDataSource>
    </div>
    <div id="done">
        Processed patients
        <asp:Label id="lbltest" runat="server"></asp:Label>
    </div>
    <div id="PageSpace"></div>
    <div id="Update">
        <div class="Patient">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblTranID" runat="server"></asp:Label></td>
                    <td>&nbsp;|<asp:Label ID="lblFname" runat="server" Font-Bold="true"></asp:Label></td>
                    <td>&nbsp;<asp:Label ID="lblLname" runat="server" Font-Bold="true"></asp:Label></td>
                    <td>&nbsp;|Code:
                        <asp:Label ID="lblpatcode" runat="server" Font-Bold="true"></asp:Label></td>
                    <td>&nbsp;|Gender:
                        <asp:Label ID="lblSex" runat="server" Font-Bold="true"></asp:Label></td>
                    <td>&nbsp;|DOB:
                        <asp:Label ID="lblDOB" runat="server"></asp:Label></td>
                    <td>&nbsp;|<asp:Label ID="lblNat" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        <table>
            <tr>

                <td class="text-center">Temp(oC) </td>
                <td class="text-center">Pulse</td>
                <td class="text-center">Respiratory</td>
                <td class="text-center">Blood-P</td>
                <td class="text-center">Sat O2</td>
                <td class="text-center">GCS</td>
                <td class="text-center">Height(cm)</td>
                <td class="text-center">Weight(kg)</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxTemp" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxPulse" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxRes" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxPress" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxSat" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxGCS" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxHeight" runat="server" Width="98%"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxWeight" runat="server" Width="98%"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gridUpdate" runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="TID" AllowExportToExcel="false" ShowGridOnEmptyData="False" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" Width="100%">
            <Columns>
                <asp:BoundField DataField="TID" HeaderText="TID" Visible="false" />
                <asp:TemplateField HeaderText="Code" Visible="False">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCode" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="ReqDoctor" HeaderText="Doctor" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>Billable </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cb_Billable" runat="server" Checked='<%# Eval("Billable").ToString()=="True"?true:false %>'
                            CausesValidation="false" Enabled="true" TextAlign="Left" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        <div>
            <asp:Button ID="btnSaveVS" runat="server" Text="Confirmation to next steps" Width="100%" OnClick="btnSaveVS_OnClick" Font-Size="Large" ForeColor="#003300" /></div>
    </div>
</asp:Content>

