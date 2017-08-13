<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Prescription.aspx.cs" Inherits="Prescription" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/ePress.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div id="PageE">
        <div class="inputE">
            <div class="colLabel">Patient</div>
            <div class="colValue">
                <telerik:RadComboBox ID="RadComboBox1" Width="160" Height="400"  runat="server" DropDownWidth="500"     EmptyMessage="Please choose a patient" 
                  HighlightTemplatedItems="true"
                  EnableLoadOnDemand="true" 
                  OnItemsRequested="RadComboBoxProduct_ItemsRequested"
                  onselectedindexchanged="RadComboBox1_SelectedIndexChanged" 
                  AutoPostBack="True" TabIndex="1">
                    <HeaderTemplate>
                        <table style="width: 500px; border: thin; border-color: black">
                            <tr>
                                <td style="width: 275px">Fullname</td>
                                <td style="width: 15px">Sex</td>
                                <td style="width: 90px">DOB</td>
                                <td style="width: 120px">Member Type</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 500px">
                            <tr>
                                <td style="width: 275px; text-transform: uppercase;"><%# DataBinder.Eval(Container, "Attributes['Fullname']")%></td>
                                <td style="width: 15px"><%# DataBinder.Eval(Container,"Attributes['Sex']")%></td>
                                <td style="width: 90px"><%# DataBinder.Eval(Container, "Attributes['DateOfBirth']")%></td>
                                <td style="width: 120px"><%# DataBinder.Eval(Container, "Attributes['MemberType']")%></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </telerik:RadComboBox>
            </div>
            <div class="clear"></div>
            <div class="colLabel">Weight</div>
            <div class="colValue">
                <asp:TextBox ID="tbxWeight" runat="server" Width="160px"></asp:TextBox>
            </div>
            <div class="clear"></div>
            <div class="colLabel">TID</div>
            <div class="colLabel">
                <asp:Label ID="lblTID" runat="server" Width="160px">
                </asp:Label>
            </div>
            <div class="clear"></div>
          </div>

        <div class="PatInfo">
        <div class="title-info">
            First Name
        </div>
        <div class="content-info" id="divFirstname" style="margin-right: 35px;">
            &nbsp;
            <asp:label ID="lblFirstName" runat="server"></asp:label>
        </div>
        <div class="title-info">
            Last Name
        </div>
        <div class="content-info" id="divLastname">
            &nbsp;
            <asp:label ID="lblLastName" runat="server"></asp:label>
        </div>
        <div class="clear">
        </div>
        <div class="title-info">
            DOB
        </div>
        <div class="content-info" id="divDOB" style="margin-right: 35px;">
            &nbsp;
            <asp:label ID="lblDOB" runat="server"></asp:label>
        </div>
        <div class="title-info">
            Age
        </div>
        <div class="content-info" id="divAge">
            &nbsp;
            <asp:label ID="lblAge" runat="server"></asp:label>
        </div>
        <div class="clear">
        </div>
        <div class="title-info">
            Code
        </div>
        <div class="content-info" id="divCode" style="margin-right: 35px;">
            &nbsp;
            <asp:label ID="lblCode" runat="server"></asp:label>
        </div>
        <div class="title-info">
            Gender
        </div>
        <div class="content-info" id="divGender">
            &nbsp;
            <asp:label ID="lblGender" runat="server"></asp:label>
        </div>
        <div class="clear">
        </div>
          <div class="title-info">
            Address
        </div>
        <div class="content-infoAdd" id="divAdd">
            &nbsp;
            <asp:label ID="lblAddress" runat="server"></asp:label>
        </div>
        <div class="clear">
        </div>
        <div class="title-info">
            Diagnosis
        </div>
        <div class="content-infoDiag" id="divDiag">
            &nbsp; 
            <telerik:RadComboBox RenderMode="Lightweight" ID="rcbDiag" AllowCustomText="true" runat="server" Width="450" Height="400px"
                DataSourceID="SqlDataSource1" DataTextField="diag_name" EmptyMessage="Search for diagnosis...">
            </telerik:RadComboBox>        
  
        </div>
        <div class="clear">
        </div>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMS %>"
            SelectCommand="SELECT top 100 Diag_code, Diag_code+' - ' + diag_name as diag_name FROM [diag_list] ORDER BY [diag_name]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ePrescription %>"
            SelectCommand="SELECT abbre as frequency FROM [Frequency] ORDER BY [abbre]">
        </asp:SqlDataSource>
    <div class="Favourite">
        Favourite
    </div>
    </div>    
    
    <div id="Med" >
        <div class="AddMed">
            <div class="Add">
                <table style="width: 600px;">
                    <tr>
                        <td>Search by Generic Name</td>
                        <td>DrugID</td>
                        <td>Form.</td>
                        <td>Dosage</td>
                        <td>DosUnit</td>
                        <td>Frequency</td>
                        <td>Dur.</td>
                        <td>Total</td>
                        <td>Remark</td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadComboBox ID="rcbSearchMed" Width="250px" runat="server" DropDownWidth="600"
                                EmptyMessage="Please choose a medication"
                                HighlightTemplatedItems="true"
                                EnableLoadOnDemand="true"
                                AutoPostBack="True"
                                OnItemsRequested="rcbSearchMed_ItemsRequested"
                                OnSelectedIndexChanged="rcbSearchMed_SelectedIndexChanged">

                                <HeaderTemplate>
                                    <table style="width: 600px" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="width: 40px;">Drug ID</td>
                                            <td style="width: 200px;">Drug Name</td>
                                            <td style="width: 200px;">Generic Name</td>
                                            <td style="width: 30px;">Quantity</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table style="width: 580px">
                                        <tr>
                                            <td style="width: 30px"><%# DataBinder.Eval(Container, "Attributes['DrugID']")%></td>
                                            <td style="width: 200px"><%# DataBinder.Eval(Container,"Attributes['DrugName']")%></td>
                                            <td style="width: 200px"><%# DataBinder.Eval(Container, "Text")%></td>
                                            <td style="width: 30px"><%# DataBinder.Eval(Container, "Attributes['Quantity']")%></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:Label ID="lblDrugID" runat="server" Width="50px"
                                Font-Size="Smaller"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblUnit" runat="server" Width="70px"
                                Font-Size="Smaller"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbxDosage" runat="server" Width="30px"></asp:TextBox></td>
                        <td><asp:Label ID="lblDosageUnit" runat="server" Width="50px"
                                Font-Size="Smaller"></asp:Label></td>
                        <td>
                            <telerik:RadComboBox ID="rcbFreq" Width="70px" runat="server" DropDownWidth="100"
                                RenderMode="Lightweight" AllowCustomText="true" DataSourceID="SqlDataSource2" DataTextField="frequency"
                                EmptyMessage="Search for frequency...">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxDuration" runat="server" Width="30px"></asp:TextBox></td>
                        <td>
                            <asp:TextBox ID="tbxTotalUnit" runat="server" Width="30px"></asp:TextBox></td>
                        <asp:RegularExpressionValidator ID="NumberOnlyTotal" runat="server" ControlToValidate="tbxTotalUnit" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">
                        </asp:RegularExpressionValidator>
                        <td>
                            <asp:TextBox ID="tbxRemark" runat="server" Width="100px"></asp:TextBox></td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Add" Width="40px" /></td>
                        <td>
                            <asp:Button ID="btnClearRow" runat="server" OnClick="btnClearRowClick"
                                Text="Clear" Width="50px" /></td>
                    </tr>
                </table>

            </div>
            <div class="GridMed">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                    ForeColor="Black" GridLines="Vertical"
                    EmptyDataText="No record has been added!" OnRowEditing="OnRowEditing"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound">
                    <RowStyle BackColor="#F7F7DE" />
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" Text="Edit" CommandName="Edit"></asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" Text="Upd." runat="server" OnClick="OnUpdate" />
                                <asp:LinkButton ID="LinkButton2" Text="Can." runat="server" OnClick="OnCancel" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Del" ShowDeleteButton="True" ButtonType="Link" />
                        <asp:BoundField HeaderText="Sq" DataField="ID" ItemStyle-Width="15px" ControlStyle-Width="15" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Drug Name" DataField="Drugname" ItemStyle-Width="300px" ControlStyle-Width="300" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField HeaderText="Drug ID" DataField="DrugID" ItemStyle-Width="50px" ControlStyle-Width="50" ItemStyle-HorizontalAlign="Center" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField HeaderText="Form" DataField="Unit" ItemStyle-Width="60px" ControlStyle-Width="60" ItemStyle-HorizontalAlign="Center" ReadOnly="true"></asp:BoundField>
                        <asp:BoundField HeaderText="Dosage" DataField="Dosage" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Frequency" DataField="Frequency" ItemStyle-Width="85px" ControlStyle-Width="85" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Dur." DataField="Duration" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Total" DataField="TotalUnit" ItemStyle-Width="40px" ControlStyle-Width="40" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:BoundField HeaderText="Remark" DataField="Remark" ItemStyle-Width="140px" ControlStyle-Width="140"></asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#008066" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="SavePres">
                <asp:Button ID="btnSave" runat="server" Width="100%" height="30px" Text="SAVE PRESCRIPTION" OnClick="btnSave_OnClick" />
            </div>
        </div>

        <div class="LoadPres">
        <asp:Label ID="lblPresID" runat="server" Width="70px" Text="lbl"></asp:Label>
        </div>

    </div>
</asp:Content>

