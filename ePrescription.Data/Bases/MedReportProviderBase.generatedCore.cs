#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using ePrescription.Entities;
using ePrescription.Data;

#endregion

namespace ePrescription.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="MedReportProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class MedReportProviderBaseCore : EntityProviderBase<ePrescription.Entities.MedReport, ePrescription.Entities.MedReportKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.MedReportKey key)
		{
			return Delete(transactionManager, key.MedId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_medId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _medId)
		{
			return Delete(null, _medId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _medId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override ePrescription.Entities.MedReport Get(TransactionManager transactionManager, ePrescription.Entities.MedReportKey key, int start, int pageLength)
		{
			return GetByMedId(transactionManager, key.MedId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_MedReport index.
		/// </summary>
		/// <param name="_medId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public ePrescription.Entities.MedReport GetByMedId(System.Int64 _medId)
		{
			int count = -1;
			return GetByMedId(null,_medId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MedReport index.
		/// </summary>
		/// <param name="_medId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public ePrescription.Entities.MedReport GetByMedId(System.Int64 _medId, int start, int pageLength)
		{
			int count = -1;
			return GetByMedId(null, _medId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MedReport index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public ePrescription.Entities.MedReport GetByMedId(TransactionManager transactionManager, System.Int64 _medId)
		{
			int count = -1;
			return GetByMedId(transactionManager, _medId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MedReport index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public ePrescription.Entities.MedReport GetByMedId(TransactionManager transactionManager, System.Int64 _medId, int start, int pageLength)
		{
			int count = -1;
			return GetByMedId(transactionManager, _medId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MedReport index.
		/// </summary>
		/// <param name="_medId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public ePrescription.Entities.MedReport GetByMedId(System.Int64 _medId, int start, int pageLength, out int count)
		{
			return GetByMedId(null, _medId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_MedReport index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_medId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.MedReport"/> class.</returns>
		public abstract ePrescription.Entities.MedReport GetByMedId(TransactionManager transactionManager, System.Int64 _medId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;MedReport&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;MedReport&gt;"/></returns>
		public static TList<MedReport> Fill(IDataReader reader, TList<MedReport> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			Type entityCreationFactoryType = currentProvider.EntityCreationalFactoryType;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				ePrescription.Entities.MedReport c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("MedReport")
					.Append("|").Append((System.Int64)reader[((int)MedReportColumn.MedId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<MedReport>(
					key.ToString(), // EntityTrackingKey
					"MedReport",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.MedReport();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
					
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && c.EntityState != EntityState.Unchanged)
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.MedId = (System.Int64)reader[((int)MedReportColumn.MedId - 1)];
					c.PatientCode = (System.String)reader[((int)MedReportColumn.PatientCode - 1)];
					c.Tid = (System.String)reader[((int)MedReportColumn.Tid - 1)];
					c.OnsetDate = (reader.IsDBNull(((int)MedReportColumn.OnsetDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.OnsetDate - 1)];
					c.FirstConsultDate = (reader.IsDBNull(((int)MedReportColumn.FirstConsultDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.FirstConsultDate - 1)];
					c.DeceaseHistory = (reader.IsDBNull(((int)MedReportColumn.DeceaseHistory - 1)))?null:(System.String)reader[((int)MedReportColumn.DeceaseHistory - 1)];
					c.DeceaseHistoryVn = (reader.IsDBNull(((int)MedReportColumn.DeceaseHistoryVn - 1)))?null:(System.String)reader[((int)MedReportColumn.DeceaseHistoryVn - 1)];
					c.Symptoms = (reader.IsDBNull(((int)MedReportColumn.Symptoms - 1)))?null:(System.String)reader[((int)MedReportColumn.Symptoms - 1)];
					c.SymptomsVn = (reader.IsDBNull(((int)MedReportColumn.SymptomsVn - 1)))?null:(System.String)reader[((int)MedReportColumn.SymptomsVn - 1)];
					c.PastMedHistory = (reader.IsDBNull(((int)MedReportColumn.PastMedHistory - 1)))?null:(System.String)reader[((int)MedReportColumn.PastMedHistory - 1)];
					c.PastMedHistoryVn = (reader.IsDBNull(((int)MedReportColumn.PastMedHistoryVn - 1)))?null:(System.String)reader[((int)MedReportColumn.PastMedHistoryVn - 1)];
					c.CurrentMedications = (reader.IsDBNull(((int)MedReportColumn.CurrentMedications - 1)))?null:(System.String)reader[((int)MedReportColumn.CurrentMedications - 1)];
					c.PhysicalExam = (reader.IsDBNull(((int)MedReportColumn.PhysicalExam - 1)))?null:(System.String)reader[((int)MedReportColumn.PhysicalExam - 1)];
					c.PhysicalExamVn = (reader.IsDBNull(((int)MedReportColumn.PhysicalExamVn - 1)))?null:(System.String)reader[((int)MedReportColumn.PhysicalExamVn - 1)];
					c.Investigations = (reader.IsDBNull(((int)MedReportColumn.Investigations - 1)))?null:(System.String)reader[((int)MedReportColumn.Investigations - 1)];
					c.InvestigationsVn = (reader.IsDBNull(((int)MedReportColumn.InvestigationsVn - 1)))?null:(System.String)reader[((int)MedReportColumn.InvestigationsVn - 1)];
					c.DiagnosisDetail = (reader.IsDBNull(((int)MedReportColumn.DiagnosisDetail - 1)))?null:(System.String)reader[((int)MedReportColumn.DiagnosisDetail - 1)];
					c.DiagnosisDetailVn = (reader.IsDBNull(((int)MedReportColumn.DiagnosisDetailVn - 1)))?null:(System.String)reader[((int)MedReportColumn.DiagnosisDetailVn - 1)];
					c.Treatment = (reader.IsDBNull(((int)MedReportColumn.Treatment - 1)))?null:(System.String)reader[((int)MedReportColumn.Treatment - 1)];
					c.TreatmentVn = (reader.IsDBNull(((int)MedReportColumn.TreatmentVn - 1)))?null:(System.String)reader[((int)MedReportColumn.TreatmentVn - 1)];
					c.ReviewPlan = (reader.IsDBNull(((int)MedReportColumn.ReviewPlan - 1)))?null:(System.String)reader[((int)MedReportColumn.ReviewPlan - 1)];
					c.ReviewPlanVn = (reader.IsDBNull(((int)MedReportColumn.ReviewPlanVn - 1)))?null:(System.String)reader[((int)MedReportColumn.ReviewPlanVn - 1)];
					c.CreateDate = (reader.IsDBNull(((int)MedReportColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.CreateDate - 1)];
					c.CreateUser = (reader.IsDBNull(((int)MedReportColumn.CreateUser - 1)))?null:(System.String)reader[((int)MedReportColumn.CreateUser - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)MedReportColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.UpdateDate - 1)];
					c.UpdateUser = (reader.IsDBNull(((int)MedReportColumn.UpdateUser - 1)))?null:(System.String)reader[((int)MedReportColumn.UpdateUser - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.MedReport"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.MedReport"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.MedReport entity)
		{
			if (!reader.Read()) return;
			
			entity.MedId = (System.Int64)reader[((int)MedReportColumn.MedId - 1)];
			entity.PatientCode = (System.String)reader[((int)MedReportColumn.PatientCode - 1)];
			entity.Tid = (System.String)reader[((int)MedReportColumn.Tid - 1)];
			entity.OnsetDate = (reader.IsDBNull(((int)MedReportColumn.OnsetDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.OnsetDate - 1)];
			entity.FirstConsultDate = (reader.IsDBNull(((int)MedReportColumn.FirstConsultDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.FirstConsultDate - 1)];
			entity.DeceaseHistory = (reader.IsDBNull(((int)MedReportColumn.DeceaseHistory - 1)))?null:(System.String)reader[((int)MedReportColumn.DeceaseHistory - 1)];
			entity.DeceaseHistoryVn = (reader.IsDBNull(((int)MedReportColumn.DeceaseHistoryVn - 1)))?null:(System.String)reader[((int)MedReportColumn.DeceaseHistoryVn - 1)];
			entity.Symptoms = (reader.IsDBNull(((int)MedReportColumn.Symptoms - 1)))?null:(System.String)reader[((int)MedReportColumn.Symptoms - 1)];
			entity.SymptomsVn = (reader.IsDBNull(((int)MedReportColumn.SymptomsVn - 1)))?null:(System.String)reader[((int)MedReportColumn.SymptomsVn - 1)];
			entity.PastMedHistory = (reader.IsDBNull(((int)MedReportColumn.PastMedHistory - 1)))?null:(System.String)reader[((int)MedReportColumn.PastMedHistory - 1)];
			entity.PastMedHistoryVn = (reader.IsDBNull(((int)MedReportColumn.PastMedHistoryVn - 1)))?null:(System.String)reader[((int)MedReportColumn.PastMedHistoryVn - 1)];
			entity.CurrentMedications = (reader.IsDBNull(((int)MedReportColumn.CurrentMedications - 1)))?null:(System.String)reader[((int)MedReportColumn.CurrentMedications - 1)];
			entity.PhysicalExam = (reader.IsDBNull(((int)MedReportColumn.PhysicalExam - 1)))?null:(System.String)reader[((int)MedReportColumn.PhysicalExam - 1)];
			entity.PhysicalExamVn = (reader.IsDBNull(((int)MedReportColumn.PhysicalExamVn - 1)))?null:(System.String)reader[((int)MedReportColumn.PhysicalExamVn - 1)];
			entity.Investigations = (reader.IsDBNull(((int)MedReportColumn.Investigations - 1)))?null:(System.String)reader[((int)MedReportColumn.Investigations - 1)];
			entity.InvestigationsVn = (reader.IsDBNull(((int)MedReportColumn.InvestigationsVn - 1)))?null:(System.String)reader[((int)MedReportColumn.InvestigationsVn - 1)];
			entity.DiagnosisDetail = (reader.IsDBNull(((int)MedReportColumn.DiagnosisDetail - 1)))?null:(System.String)reader[((int)MedReportColumn.DiagnosisDetail - 1)];
			entity.DiagnosisDetailVn = (reader.IsDBNull(((int)MedReportColumn.DiagnosisDetailVn - 1)))?null:(System.String)reader[((int)MedReportColumn.DiagnosisDetailVn - 1)];
			entity.Treatment = (reader.IsDBNull(((int)MedReportColumn.Treatment - 1)))?null:(System.String)reader[((int)MedReportColumn.Treatment - 1)];
			entity.TreatmentVn = (reader.IsDBNull(((int)MedReportColumn.TreatmentVn - 1)))?null:(System.String)reader[((int)MedReportColumn.TreatmentVn - 1)];
			entity.ReviewPlan = (reader.IsDBNull(((int)MedReportColumn.ReviewPlan - 1)))?null:(System.String)reader[((int)MedReportColumn.ReviewPlan - 1)];
			entity.ReviewPlanVn = (reader.IsDBNull(((int)MedReportColumn.ReviewPlanVn - 1)))?null:(System.String)reader[((int)MedReportColumn.ReviewPlanVn - 1)];
			entity.CreateDate = (reader.IsDBNull(((int)MedReportColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.CreateDate - 1)];
			entity.CreateUser = (reader.IsDBNull(((int)MedReportColumn.CreateUser - 1)))?null:(System.String)reader[((int)MedReportColumn.CreateUser - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)MedReportColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)MedReportColumn.UpdateDate - 1)];
			entity.UpdateUser = (reader.IsDBNull(((int)MedReportColumn.UpdateUser - 1)))?null:(System.String)reader[((int)MedReportColumn.UpdateUser - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.MedReport"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.MedReport"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.MedReport entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.MedId = (System.Int64)dataRow["MedId"];
			entity.PatientCode = (System.String)dataRow["PatientCode"];
			entity.Tid = (System.String)dataRow["TID"];
			entity.OnsetDate = Convert.IsDBNull(dataRow["OnsetDate"]) ? null : (System.DateTime?)dataRow["OnsetDate"];
			entity.FirstConsultDate = Convert.IsDBNull(dataRow["FirstConsultDate"]) ? null : (System.DateTime?)dataRow["FirstConsultDate"];
			entity.DeceaseHistory = Convert.IsDBNull(dataRow["DeceaseHistory"]) ? null : (System.String)dataRow["DeceaseHistory"];
			entity.DeceaseHistoryVn = Convert.IsDBNull(dataRow["DeceaseHistoryVN"]) ? null : (System.String)dataRow["DeceaseHistoryVN"];
			entity.Symptoms = Convert.IsDBNull(dataRow["Symptoms"]) ? null : (System.String)dataRow["Symptoms"];
			entity.SymptomsVn = Convert.IsDBNull(dataRow["SymptomsVN"]) ? null : (System.String)dataRow["SymptomsVN"];
			entity.PastMedHistory = Convert.IsDBNull(dataRow["PastMedHistory"]) ? null : (System.String)dataRow["PastMedHistory"];
			entity.PastMedHistoryVn = Convert.IsDBNull(dataRow["PastMedHistoryVN"]) ? null : (System.String)dataRow["PastMedHistoryVN"];
			entity.CurrentMedications = Convert.IsDBNull(dataRow["CurrentMedications"]) ? null : (System.String)dataRow["CurrentMedications"];
			entity.PhysicalExam = Convert.IsDBNull(dataRow["PhysicalExam"]) ? null : (System.String)dataRow["PhysicalExam"];
			entity.PhysicalExamVn = Convert.IsDBNull(dataRow["PhysicalExamVN"]) ? null : (System.String)dataRow["PhysicalExamVN"];
			entity.Investigations = Convert.IsDBNull(dataRow["Investigations"]) ? null : (System.String)dataRow["Investigations"];
			entity.InvestigationsVn = Convert.IsDBNull(dataRow["InvestigationsVN"]) ? null : (System.String)dataRow["InvestigationsVN"];
			entity.DiagnosisDetail = Convert.IsDBNull(dataRow["DiagnosisDetail"]) ? null : (System.String)dataRow["DiagnosisDetail"];
			entity.DiagnosisDetailVn = Convert.IsDBNull(dataRow["DiagnosisDetailVN"]) ? null : (System.String)dataRow["DiagnosisDetailVN"];
			entity.Treatment = Convert.IsDBNull(dataRow["Treatment"]) ? null : (System.String)dataRow["Treatment"];
			entity.TreatmentVn = Convert.IsDBNull(dataRow["TreatmentVN"]) ? null : (System.String)dataRow["TreatmentVN"];
			entity.ReviewPlan = Convert.IsDBNull(dataRow["ReviewPlan"]) ? null : (System.String)dataRow["ReviewPlan"];
			entity.ReviewPlanVn = Convert.IsDBNull(dataRow["ReviewPlanVN"]) ? null : (System.String)dataRow["ReviewPlanVN"];
			entity.CreateDate = Convert.IsDBNull(dataRow["CreateDate"]) ? null : (System.DateTime?)dataRow["CreateDate"];
			entity.CreateUser = Convert.IsDBNull(dataRow["CreateUser"]) ? null : (System.String)dataRow["CreateUser"];
			entity.UpdateDate = Convert.IsDBNull(dataRow["UpdateDate"]) ? null : (System.DateTime?)dataRow["UpdateDate"];
			entity.UpdateUser = Convert.IsDBNull(dataRow["UpdateUser"]) ? null : (System.String)dataRow["UpdateUser"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.MedReport"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.MedReport Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.MedReport entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the ePrescription.Entities.MedReport object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.MedReport instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.MedReport Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.MedReport entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region MedReportChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.MedReport</c>
	///</summary>
	public enum MedReportChildEntityTypes
	{
	}
	
	#endregion MedReportChildEntityTypes
	
	#region MedReportFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;MedReportColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportFilterBuilder : SqlFilterBuilder<MedReportColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportFilterBuilder class.
		/// </summary>
		public MedReportFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MedReportFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MedReportFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MedReportFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MedReportFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MedReportFilterBuilder
	
	#region MedReportParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;MedReportColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportParameterBuilder : ParameterizedSqlFilterBuilder<MedReportColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportParameterBuilder class.
		/// </summary>
		public MedReportParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the MedReportParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MedReportParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MedReportParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MedReportParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MedReportParameterBuilder
	
	#region MedReportSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;MedReportColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class MedReportSortBuilder : SqlSortBuilder<MedReportColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportSqlSortBuilder class.
		/// </summary>
		public MedReportSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion MedReportSortBuilder
	
} // end namespace
