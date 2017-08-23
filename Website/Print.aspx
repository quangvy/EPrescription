<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Print" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #btnPrint {
            width: 69px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        <%--<asp:Button ID="btnView"  Text="PRINT" runat="server" OnClick="btnView_Click"   />--%>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="515px" Width="808px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="ePres.rdlc" EnableExternalImages="true">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                SelectMethod="GetData"
                TypeName="EPrescriptionDataSetTableAdapters.EPrescription_PrintTableAdapter" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:QueryStringParameter Name="EPrescriptionId" QueryStringField="PrescriptionId" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
