<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Print" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="tbxPresID" runat="server"></asp:TextBox>
        <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" />
        <div>

            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="399px" Width="1026px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="ePres.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet2" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                SelectMethod="GetData"
                TypeName="EPrescriptionDataSetTableAdapters.ePrescriptionTableAdapter" OldValuesParameterFormatString="original_{0}" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_PrescriptionID" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="PrescriptionID" Type="String" />
                    <asp:Parameter Name="TransactionID" Type="String" />
                    <asp:Parameter Name="PatientCode" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="DeliveryDate" Type="DateTime" />
                    <asp:Parameter Name="CreateDate" Type="DateTime" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="DateOfBirth" Type="DateTime" />
                    <asp:Parameter Name="Age" Type="String" />
                    <asp:Parameter Name="Weight" Type="String" />
                    <asp:Parameter Name="Diagnosis" Type="String" />
                    <asp:Parameter Name="PrescribingDoctor" Type="String" />
                    <asp:Parameter Name="Sex" Type="String" />
                    <asp:Parameter Name="Remark" Type="String" />
                    <asp:Parameter Name="IsComplete" Type="Boolean" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbxPresID" Name="PrescriptionID" PropertyName="Text" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TransactionID" Type="String" />
                    <asp:Parameter Name="PatientCode" Type="String" />
                    <asp:Parameter Name="FirstName" Type="String" />
                    <asp:Parameter Name="LastName" Type="String" />
                    <asp:Parameter Name="DeliveryDate" Type="DateTime" />
                    <asp:Parameter Name="CreateDate" Type="DateTime" />
                    <asp:Parameter Name="Address" Type="String" />
                    <asp:Parameter Name="DateOfBirth" Type="DateTime" />
                    <asp:Parameter Name="Age" Type="String" />
                    <asp:Parameter Name="Weight" Type="String" />
                    <asp:Parameter Name="Diagnosis" Type="String" />
                    <asp:Parameter Name="PrescribingDoctor" Type="String" />
                    <asp:Parameter Name="Sex" Type="String" />
                    <asp:Parameter Name="Remark" Type="String" />
                    <asp:Parameter Name="IsComplete" Type="Boolean" />
                    <asp:Parameter Name="Original_PrescriptionID" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="EPrescriptionDataSetTableAdapters.VR_ePresDetailTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="tbxPresID" Name="PrescriptionID" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
