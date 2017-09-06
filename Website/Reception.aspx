<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reception.aspx.cs" Inherits="Reception" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:EntityGridView ID="gridPatientActivation" runat="server"
        DataSourceID="VrReceptionDataSource"
        DataKeyNames="TransactionId" AllowExportToExcel="True"
        AllowMultiColumnSorting="False" DefaultSortDirection="Ascending"
        ExportToExcelText="Excel" PageSelectorPageSizeInterval="10"
        AllowPaging="True"
        RecordsCount="0" ShowGridOnEmptyData="False"
        AutoGenerateColumns="False" AllowSorting="True" DefaultSortColumnName="TransactionId"
        OnRowCommand="gridPatientActivation_Rowcommand">
        <Columns>
            <asp:TemplateField HeaderText="CMD">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkVoid" runat="server" CommandName="Void" CommandArgument='<%#Bind("TransactionId") %>'>Void</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Add" CommandArgument='<%#Bind("TransactionId") %>'>Add</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Void reason">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlVoidReason" runat="server" Font-Size="Smaller">
                        <asp:ListItem>Wrong Patient info</asp:ListItem>
                        <asp:ListItem>Printer problem</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="[TransactionId]" ReadOnly="true" />
            <asp:TemplateField HeaderText="PatientCode" SortExpression="PatientCode">
                <EditItemTemplate>
                    <asp:TextBox ID="txbPatientCode" runat="server" Text='<%# Bind("PatientCode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPatientCode" runat="server" Text='<%# Bind("PatientCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                <EditItemTemplate>
                    <asp:TextBox ID="txbLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                <EditItemTemplate>
                    <asp:TextBox ID="txbFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sex" SortExpression="Sex">
                <EditItemTemplate>
                    <asp:TextBox ID="tbxSex" runat="server" Text='<%# Bind("Sex") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSex" runat="server" Text='<%# Bind("Sex") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOB" SortExpression="DOB">
                <EditItemTemplate>
                    <asp:TextBox ID="txbDOB" runat="server" Text='<%# Bind("DateOfBirth","{0:dd-MMM-yyyy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDOB" runat="server" Text='<%# Bind("DateOfBirth","{0:dd-MMM-yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nationality" SortExpression="Nationality">
                <EditItemTemplate>
                    <asp:TextBox ID="txbNationality" runat="server" Text='<%# Bind("Nationality") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNationality" runat="server" Text='<%# Bind("Nationality") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <b>No TID Yet!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <data:VrReceptionDataSource ID="VrReceptionDataSource" runat="server"
        SelectMethod="GetPaged"
        EnablePaging="True"
        EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            <asp:ControlParameter Name="PageIndex" ControlID="gridPatientActivation" PropertyName="PageIndex" Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="gridPatientActivation" PropertyName="PageSize" Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:VrReceptionDataSource>
    <br />
    <data:EntityGridView ID="gridReception" runat="server"
        AutoGenerateColumns="False"
        
        DataSourceID="ClinicalStatsDataSource"
        DataKeyNames="StatId"
        AllowMultiColumnSorting="False"
        DefaultSortColumnName="[TID]"
        DefaultSortDirection="Ascending"
        AllowPaging ="True"
        OnRowCommand="gridReception_Rowcommand" AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="10" RecordsCount="0" ShowGridOnEmptyData="False" 
        >
        <Columns>
            <asp:TemplateField HeaderText="CMD">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkRevert" runat="server" CommandName="Revert" CommandArgument='<%#Bind("TID") %>'>Revert</asp:LinkButton>
                    &nbsp;                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" />
           <asp:BoundField DataField="Tid" HeaderText="Tid" SortExpression="[Tid]" ReadOnly="true" />
            <asp:BoundField DataField="PatientCode" HeaderText="Patient Code" SortExpression="[PatientCode]" ReadOnly="true"/>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]" ReadOnly="true"/>
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="[LastName]" ReadOnly="true" />
            <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="[Sex]" ReadOnly="true"/>
            <asp:BoundField DataField="Nationality" HeaderText="Nationality" SortExpression="[Nationality]" ReadOnly="true"/>
            <asp:BoundField DataField="Dob" DataFormatString="{0:dd-MMM-yyyy}" HtmlEncode="False" HeaderText="Dob" SortExpression="[DOB]" ReadOnly="true"/>
            <asp:CheckBoxField DataField="PatientStart" HeaderText="Patient Start" SortExpression="[PatientStart]" ReadOnly="true"/>
            <asp:CheckBoxField DataField="IsCompleted" HeaderText="Complete" SortExpression="[IsCompleted]" />
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

