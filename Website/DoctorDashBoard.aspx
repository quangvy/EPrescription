<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DoctorDashBoard.aspx.cs" Inherits="DoctorDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbltest" runat="server"></asp:Label>
    <data:EntityGridView ID="gridReception" runat="server"
        AutoGenerateColumns="False"        
        DataSourceID="ClinicalStatsDataSource"
        DataKeyNames="StatId"
        AllowMultiColumnSorting="False"
        DefaultSortColumnName="[TID]"
        DefaultSortDirection="Ascending"
        AllowPaging ="True"
        OnRowCommand="gridDoctor_Rowcommand" AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="10" RecordsCount="0" ShowGridOnEmptyData="False" Font-size ="Smaller"
        >
        <Columns>
            
            <asp:CommandField ShowEditButton="true" />
           <asp:BoundField DataField="Tid" HeaderText="Tid" SortExpression="[Tid]" ReadOnly="true" />
            <asp:BoundField DataField="PatientCode" HeaderText="Patient Code" SortExpression="[PatientCode]" ReadOnly="true"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]" ReadOnly="true"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="[LastName]" ReadOnly="true" />
            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="[Sex]" ReadOnly="true"/>
            <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="[Nationality]" ReadOnly="true"/>
            <asp:BoundField DataField="Dob" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" HeaderText="Dob" SortExpression="[DOB]" ReadOnly="true"/>
            <asp:TemplateField HeaderText="CMD">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkLAB" runat="server" CommandName="LAB" CommandArgument='<%#Bind("TID") %>'>Req.LAB</asp:LinkButton>
                    &nbsp;                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Lab" HeaderText="Lab" SortExpression="[Lab]" ReadOnly="true"/>
            <asp:BoundField DataField="ChargedCodes" HeaderText="ChargedCodes" SortExpression="[ChargedCodes]" ReadOnly="true"/>
            <asp:BoundField DataField="CreateDate" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" HeaderText="Create Date" SortExpression="[CreateDate]" ReadOnly="true"/>
        </Columns>
        <EmptyDataTemplate>
            <b>No Patient Starts Yet!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />

    <data:ClinicalStatsDataSource ID="ClinicalStatsDataSource" runat="server"
        SelectMethod="GetPaged"
        EnablePaging="True"
        EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="gridReception" PropertyName="PageIndex" Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="gridReception" PropertyName="PageSize" Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:ClinicalStatsDataSource>

</asp:Content>

