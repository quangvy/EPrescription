<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Unit.aspx.cs" Inherits="UnitPage" Title="Unit List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        DataSourceID="VrUnitTableDataSource"
        DataKeyNames="Unit"
        AllowMultiColumnSorting="False"
        ExcelExportFileName="Export_Unit.xls"
        AllowPaging="True"
        AllowExportToExcel="True" AllowSorting="True" DefaultSortColumnName="[Unit]" DefaultSortDirection="Ascending" ExportToExcelText="Excel" OnRowCommand="GridView1_RowCommand" PageSelectorPageSizeInterval="10" RecordsCount="0" ShowGridOnEmptyData="False">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="UpdateUnit" Text="Update" CommandArgument='<%#Bind("Unit") %>'></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Unit" HeaderText="Unit" SortExpression="[Unit]" ReadOnly="true" />
            <asp:TemplateField HeaderText="Unit VN" SortExpression="[UnitVN]">
                <EditItemTemplate>
                    <asp:TextBox ID="txtUnitVN" runat="server" Text='<%# Bind("UnitVN") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("UnitVN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DosageUnit" SortExpression="[DosageUnit]">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDosageUnit" runat="server" Text='<%# Bind("DosageUnit") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DosageUnit") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DosageUnitVN" SortExpression="[DosageUnitVN]">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDosageUnitVN" runat="server" Text='<%# Bind("DosageUnitVN") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("DosageUnitVN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <b>No Route Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <%--<asp:Button runat="server" ID="btnRoute" OnClientClick="javascript:location.href='RouteEdit.aspx'; return false;" Text="Add New"></asp:Button>--%>
    <data:VrUnitTableDataSource ID="VrUnitTableDataSource" runat="server"
        SelectMethod="GetPaged"
        EnablePaging="True"
        EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:VrUnitTableDataSource>

</asp:Content>



