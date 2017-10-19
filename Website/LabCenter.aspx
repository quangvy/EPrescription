<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LabCenter.aspx.cs" Inherits="LabCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/Lab.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="waiting">
        Waiting Patients 
        <asp:Repeater runat="server" ID="rptLabReceive" OnItemDataBound="rptLabReceive_ItemDataBound" OnItemCommand="rptLabReceive_OnItemCommand">
                <ItemTemplate>
                    <input type="checkbox" class="toggle-box" id="identifier" runat="server" />
                    <asp:Label AssociatedControlID='identifier' runat="server" ID="lblPatInfo" Text='<%#Eval("TID")+"||"+Eval("ReqID")
                             +"||"+Eval("PatientCode")+"||"+ Eval("FirstName").ToString().ToUpper()+" "+Eval("LastName").ToString().ToUpper()+"||"+Eval("DOB","{0:dd-MMM-yyyy}")%>'></asp:Label>
                    <div>
                        <asp:Label ID="lblSample" runat="server" Text="Input Sample details" Font-Size="X-Small"></asp:Label>
                        <asp:TextBox ID="tbxSample" runat="server"></asp:TextBox>
                        <asp:Button runat="server" ID="btnProcess" Text="Process" CommandName="Confirm" CommandArgument='<%#Eval("TID") %>'></asp:Button>
                        <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Code" HeaderText="Code" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Billable" HeaderText="Billable" />
                                <asp:BoundField DataField="SampleType" HeaderText="Sample" />
                                <asp:BoundField DataField="ProviderType" HeaderText="provider" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
    </div>
    <div id="done">
        <asp:Repeater runat="server" ID="rptDone" OnItemDataBound="rptDone_ItemDataBound" OnItemCommand="rptDone_OnItemCommand">
                <ItemTemplate>
                    <input type="checkbox" class="toggle-box" id="identifier" runat="server" />
                    <asp:Label AssociatedControlID='identifier' runat="server" ID="lblPatInfo" Text='<%#Eval("TID")+"||"+Eval("ReqID")
                             +"||"+Eval("PatientCode")+"||"+ Eval("FirstName").ToString().ToUpper()+" "+Eval("LastName").ToString().ToUpper()+"||"+Eval("DOB","{0:dd-MMM-yyyy}")%>'></asp:Label>
                    <div>
                        <asp:Button runat="server" ID="btnPrint" Text="View" CommandName="Print" CommandArgument='<%#Eval("ReqID") %>'></asp:Button>
                        <%--<asp:Button runat="server" ID="btnProcess" Text="Done" CommandName="Confirm" CommandArgument='<%#Eval("ReqID") %>'></asp:Button>--%>
                        <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Code" HeaderText="Code" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Billable" HeaderText="Billable" />
                                <asp:BoundField DataField="SampleType" HeaderText="Sample" />
                                <asp:BoundField DataField="ProviderType" HeaderText="provider" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
    </div>
    <div id="PageSpace"></div>
    <div id="Update">
        Processing Patients 
        <asp:Repeater runat="server" ID="rptLabProcess" OnItemDataBound="rptLabProcess_ItemDataBound" OnItemCommand="rptLabProcess_OnItemCommand">
                <ItemTemplate>
                    <input type="checkbox" class="toggle-box" id="identifier" runat="server" />
                    <asp:Label AssociatedControlID='identifier' runat="server" ID="lblPatInfo" Text='<%#Eval("TID")+"||"+Eval("ReqID")
                             +"||"+Eval("PatientCode")+"||"+ Eval("FirstName").ToString().ToUpper()+" "+Eval("LastName").ToString().ToUpper()+"||"+Eval("DOB","{0:dd-MMM-yyyy}")%>'></asp:Label>
                    <div>
                        <asp:Button runat="server" ID="btnPrint" Text="Print Form" CommandName="Print" CommandArgument='<%#Eval("ReqID") %>'></asp:Button>
                        <asp:Button runat="server" ID="btnProcess" Text="Done" CommandName="Confirm" CommandArgument='<%#Eval("TID") %>'></asp:Button>
                        <asp:GridView ID="grvDetails" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Code" HeaderText="Code" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Billable" HeaderText="Billable" />
                                <asp:BoundField DataField="SampleType" HeaderText="Sample" />
                                <asp:BoundField DataField="ProviderType" HeaderText="provider" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
    </div>
</asp:Content>

