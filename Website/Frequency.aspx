<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Frequency.aspx.cs" Inherits="FrequencyPage" Title="Frequency List" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
    <br />
    <data:EntityGridView ID="GridView1" runat="server"
        AutoGenerateColumns="False"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
        DataSourceID="FrequencyDataSource"
        DataKeyNames="FrequencyId"
        AllowMultiColumnSorting="false"
        DefaultSortColumnName=""
        DefaultSortDirection="Ascending"
        AllowPaging="true"
        ExcelExportFileName="Export_Frequency.xls">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="Abbre" HeaderText="Abbre" SortExpression="[abbre]" />
            <asp:BoundField DataField="Meaning" HeaderText="Meaning" SortExpression="[meaning]" />
            <asp:BoundField DataField="VnMeaning" HeaderText="Vn Meaning" SortExpression="[VN_meaning]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No Frequency Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
    <asp:Button runat="server" ID="btnFrequency" OnClientClick="javascript:location.href='FrequencyEdit.aspx'; return false;" Text="Add New"></asp:Button>
    <data:FrequencyDataSource ID="FrequencyDataSource" runat="server"
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
    </data:FrequencyDataSource>

</asp:Content>



