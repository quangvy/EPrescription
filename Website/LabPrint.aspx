<%@ Page Title="" Language="C#"AutoEventWireup="true" CodeFile="LabPrint.aspx.cs" Inherits="LabPrint" %>

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
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="LabPrintTableAdapters.LabForm_PrintTableAdapter">
                <SelectParameters>
                    <asp:QueryStringParameter Name="ReqID" QueryStringField="ReqID" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="515px" Width="808px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="Lab.rdlc" EnableExternalImages="true">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>