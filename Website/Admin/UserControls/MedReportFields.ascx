<%@ Control Language="C#" ClassName="MedReportFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagnosisDetailVn" runat="server" Text="Diagnosis Detail Vn:" AssociatedControlID="dataDiagnosisDetailVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagnosisDetailVn" Text='<%# Bind("DiagnosisDetailVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTreatment" runat="server" Text="Treatment:" AssociatedControlID="dataTreatment" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTreatment" Text='<%# Bind("Treatment") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTreatmentVn" runat="server" Text="Treatment Vn:" AssociatedControlID="dataTreatmentVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTreatmentVn" Text='<%# Bind("TreatmentVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInvestigations" runat="server" Text="Investigations:" AssociatedControlID="dataInvestigations" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInvestigations" Text='<%# Bind("Investigations") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInvestigationsVn" runat="server" Text="Investigations Vn:" AssociatedControlID="dataInvestigationsVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInvestigationsVn" Text='<%# Bind("InvestigationsVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDiagnosisDetail" runat="server" Text="Diagnosis Detail:" AssociatedControlID="dataDiagnosisDetail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDiagnosisDetail" Text='<%# Bind("DiagnosisDetail") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateUser" runat="server" Text="Create User:" AssociatedControlID="dataCreateUser" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateUser" Text='<%# Bind("CreateUser") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateDate" runat="server" Text="Update Date:" AssociatedControlID="dataUpdateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateDate" Text='<%# Bind("UpdateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUpdateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUpdateUser" runat="server" Text="Update User:" AssociatedControlID="dataUpdateUser" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUpdateUser" Text='<%# Bind("UpdateUser") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReviewPlan" runat="server" Text="Review Plan:" AssociatedControlID="dataReviewPlan" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReviewPlan" Text='<%# Bind("ReviewPlan") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReviewPlanVn" runat="server" Text="Review Plan Vn:" AssociatedControlID="dataReviewPlanVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReviewPlanVn" Text='<%# Bind("ReviewPlanVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreateDate" runat="server" Text="Create Date:" AssociatedControlID="dataCreateDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreateDate" Text='<%# Bind("CreateDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreateDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhysicalExamVn" runat="server" Text="Physical Exam Vn:" AssociatedControlID="dataPhysicalExamVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhysicalExamVn" Text='<%# Bind("PhysicalExamVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstConsultDate" runat="server" Text="First Consult Date:" AssociatedControlID="dataFirstConsultDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstConsultDate" Text='<%# Bind("FirstConsultDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFirstConsultDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeceaseHistory" runat="server" Text="Decease History:" AssociatedControlID="dataDeceaseHistory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeceaseHistory" Text='<%# Bind("DeceaseHistory") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDeceaseHistoryVn" runat="server" Text="Decease History Vn:" AssociatedControlID="dataDeceaseHistoryVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDeceaseHistoryVn" Text='<%# Bind("DeceaseHistoryVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPatientCode" runat="server" Text="Patient Code:" AssociatedControlID="dataPatientCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPatientCode" Text='<%# Bind("PatientCode") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPatientCode" runat="server" Display="Dynamic" ControlToValidate="dataPatientCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTid" runat="server" Text="Tid:" AssociatedControlID="dataTid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTid" Text='<%# Bind("Tid") %>' MaxLength="15"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTid" runat="server" Display="Dynamic" ControlToValidate="dataTid" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOnsetDate" runat="server" Text="Onset Date:" AssociatedControlID="dataOnsetDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOnsetDate" Text='<%# Bind("OnsetDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataOnsetDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:showCalendarControl(this.previousSibling);return false;" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPastMedHistoryVn" runat="server" Text="Past Med History Vn:" AssociatedControlID="dataPastMedHistoryVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPastMedHistoryVn" Text='<%# Bind("PastMedHistoryVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrentMedications" runat="server" Text="Current Medications:" AssociatedControlID="dataCurrentMedications" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCurrentMedications" Text='<%# Bind("CurrentMedications") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhysicalExam" runat="server" Text="Physical Exam:" AssociatedControlID="dataPhysicalExam" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhysicalExam" Text='<%# Bind("PhysicalExam") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSymptoms" runat="server" Text="Symptoms:" AssociatedControlID="dataSymptoms" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSymptoms" Text='<%# Bind("Symptoms") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSymptomsVn" runat="server" Text="Symptoms Vn:" AssociatedControlID="dataSymptomsVn" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSymptomsVn" Text='<%# Bind("SymptomsVn") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPastMedHistory" runat="server" Text="Past Med History:" AssociatedControlID="dataPastMedHistory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPastMedHistory" Text='<%# Bind("PastMedHistory") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


