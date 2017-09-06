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
	/// This class is the base class for any <see cref="ClinicalStatsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ClinicalStatsProviderBaseCore : EntityProviderBase<ePrescription.Entities.ClinicalStats, ePrescription.Entities.ClinicalStatsKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.ClinicalStatsKey key)
		{
			return Delete(transactionManager, key.StatId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_statId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _statId)
		{
			return Delete(null, _statId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _statId);		
		
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
		public override ePrescription.Entities.ClinicalStats Get(TransactionManager transactionManager, ePrescription.Entities.ClinicalStatsKey key, int start, int pageLength)
		{
			return GetByStatId(transactionManager, key.StatId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ClinicalStats index.
		/// </summary>
		/// <param name="_statId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public ePrescription.Entities.ClinicalStats GetByStatId(System.Int64 _statId)
		{
			int count = -1;
			return GetByStatId(null,_statId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClinicalStats index.
		/// </summary>
		/// <param name="_statId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public ePrescription.Entities.ClinicalStats GetByStatId(System.Int64 _statId, int start, int pageLength)
		{
			int count = -1;
			return GetByStatId(null, _statId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClinicalStats index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public ePrescription.Entities.ClinicalStats GetByStatId(TransactionManager transactionManager, System.Int64 _statId)
		{
			int count = -1;
			return GetByStatId(transactionManager, _statId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClinicalStats index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public ePrescription.Entities.ClinicalStats GetByStatId(TransactionManager transactionManager, System.Int64 _statId, int start, int pageLength)
		{
			int count = -1;
			return GetByStatId(transactionManager, _statId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClinicalStats index.
		/// </summary>
		/// <param name="_statId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public ePrescription.Entities.ClinicalStats GetByStatId(System.Int64 _statId, int start, int pageLength, out int count)
		{
			return GetByStatId(null, _statId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ClinicalStats index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_statId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.ClinicalStats"/> class.</returns>
		public abstract ePrescription.Entities.ClinicalStats GetByStatId(TransactionManager transactionManager, System.Int64 _statId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region _ClinicalStats_GetByTID 
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByTID(System.String tid)
		{
			return GetByTID(null, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByTID(int start, int pageLength, System.String tid)
		{
			return GetByTID(null, start, pageLength , tid);
		}
				
		/// <summary>
		///	This method wrap the '_ClinicalStats_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByTID(TransactionManager transactionManager, System.String tid)
		{
			return GetByTID(transactionManager, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByTID(TransactionManager transactionManager, int start, int pageLength , System.String tid);
		
		#endregion
		
		#region _ClinicalStats_AddRecept 
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_AddRecept' stored procedure. 
		/// </summary>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="dob"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sex"> A <c>System.String</c> instance.</param>
		/// <param name="nationality"> A <c>System.String</c> instance.</param>
		/// <param name="patientStart"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddRecept(System.String patientCode, System.String tid, System.String firstName, System.String lastName, System.DateTime? dob, System.String sex, System.String nationality, System.Boolean? patientStart)
		{
			 AddRecept(null, 0, int.MaxValue , patientCode, tid, firstName, lastName, dob, sex, nationality, patientStart);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_AddRecept' stored procedure. 
		/// </summary>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="dob"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sex"> A <c>System.String</c> instance.</param>
		/// <param name="nationality"> A <c>System.String</c> instance.</param>
		/// <param name="patientStart"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddRecept(int start, int pageLength, System.String patientCode, System.String tid, System.String firstName, System.String lastName, System.DateTime? dob, System.String sex, System.String nationality, System.Boolean? patientStart)
		{
			 AddRecept(null, start, pageLength , patientCode, tid, firstName, lastName, dob, sex, nationality, patientStart);
		}
				
		/// <summary>
		///	This method wrap the '_ClinicalStats_AddRecept' stored procedure. 
		/// </summary>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="dob"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sex"> A <c>System.String</c> instance.</param>
		/// <param name="nationality"> A <c>System.String</c> instance.</param>
		/// <param name="patientStart"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void AddRecept(TransactionManager transactionManager, System.String patientCode, System.String tid, System.String firstName, System.String lastName, System.DateTime? dob, System.String sex, System.String nationality, System.Boolean? patientStart)
		{
			 AddRecept(transactionManager, 0, int.MaxValue , patientCode, tid, firstName, lastName, dob, sex, nationality, patientStart);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_AddRecept' stored procedure. 
		/// </summary>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="firstName"> A <c>System.String</c> instance.</param>
		/// <param name="lastName"> A <c>System.String</c> instance.</param>
		/// <param name="dob"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="sex"> A <c>System.String</c> instance.</param>
		/// <param name="nationality"> A <c>System.String</c> instance.</param>
		/// <param name="patientStart"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void AddRecept(TransactionManager transactionManager, int start, int pageLength , System.String patientCode, System.String tid, System.String firstName, System.String lastName, System.DateTime? dob, System.String sex, System.String nationality, System.Boolean? patientStart);
		
		#endregion
		
		#region _ClinicalStats_UpdateRecept 
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_UpdateRecept' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateRecept(System.String tid)
		{
			 UpdateRecept(null, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_UpdateRecept' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateRecept(int start, int pageLength, System.String tid)
		{
			 UpdateRecept(null, start, pageLength , tid);
		}
				
		/// <summary>
		///	This method wrap the '_ClinicalStats_UpdateRecept' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateRecept(TransactionManager transactionManager, System.String tid)
		{
			 UpdateRecept(transactionManager, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_ClinicalStats_UpdateRecept' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateRecept(TransactionManager transactionManager, int start, int pageLength , System.String tid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;ClinicalStats&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;ClinicalStats&gt;"/></returns>
		public static TList<ClinicalStats> Fill(IDataReader reader, TList<ClinicalStats> rows, int start, int pageLength)
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
				
				ePrescription.Entities.ClinicalStats c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ClinicalStats")
					.Append("|").Append((System.Int64)reader[((int)ClinicalStatsColumn.StatId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<ClinicalStats>(
					key.ToString(), // EntityTrackingKey
					"ClinicalStats",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.ClinicalStats();
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
					c.StatId = (System.Int64)reader[((int)ClinicalStatsColumn.StatId - 1)];
					c.PatientCode = (System.String)reader[((int)ClinicalStatsColumn.PatientCode - 1)];
					c.Tid = (System.String)reader[((int)ClinicalStatsColumn.Tid - 1)];
					c.FirstName = (System.String)reader[((int)ClinicalStatsColumn.FirstName - 1)];
					c.LastName = (System.String)reader[((int)ClinicalStatsColumn.LastName - 1)];
					c.Dob = (System.DateTime)reader[((int)ClinicalStatsColumn.Dob - 1)];
					c.Sex = (System.String)reader[((int)ClinicalStatsColumn.Sex - 1)];
					c.Nationality = (System.String)reader[((int)ClinicalStatsColumn.Nationality - 1)];
					c.PatientStart = (reader.IsDBNull(((int)ClinicalStatsColumn.PatientStart - 1)))?null:(System.Boolean?)reader[((int)ClinicalStatsColumn.PatientStart - 1)];
					c.VitalSign = (reader.IsDBNull(((int)ClinicalStatsColumn.VitalSign - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.VitalSign - 1)];
					c.Lab = (reader.IsDBNull(((int)ClinicalStatsColumn.Lab - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Lab - 1)];
					c.Xray = (reader.IsDBNull(((int)ClinicalStatsColumn.Xray - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Xray - 1)];
					c.UltraSound = (reader.IsDBNull(((int)ClinicalStatsColumn.UltraSound - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.UltraSound - 1)];
					c.Cardiology = (reader.IsDBNull(((int)ClinicalStatsColumn.Cardiology - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Cardiology - 1)];
					c.MedReport = (reader.IsDBNull(((int)ClinicalStatsColumn.MedReport - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.MedReport - 1)];
					c.ChargedCodes = (reader.IsDBNull(((int)ClinicalStatsColumn.ChargedCodes - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.ChargedCodes - 1)];
					c.IsCompleted = (reader.IsDBNull(((int)ClinicalStatsColumn.IsCompleted - 1)))?null:(System.Boolean?)reader[((int)ClinicalStatsColumn.IsCompleted - 1)];
					c.CreateDate = (reader.IsDBNull(((int)ClinicalStatsColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)ClinicalStatsColumn.CreateDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.ClinicalStats"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.ClinicalStats"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.ClinicalStats entity)
		{
			if (!reader.Read()) return;
			
			entity.StatId = (System.Int64)reader[((int)ClinicalStatsColumn.StatId - 1)];
			entity.PatientCode = (System.String)reader[((int)ClinicalStatsColumn.PatientCode - 1)];
			entity.Tid = (System.String)reader[((int)ClinicalStatsColumn.Tid - 1)];
			entity.FirstName = (System.String)reader[((int)ClinicalStatsColumn.FirstName - 1)];
			entity.LastName = (System.String)reader[((int)ClinicalStatsColumn.LastName - 1)];
			entity.Dob = (System.DateTime)reader[((int)ClinicalStatsColumn.Dob - 1)];
			entity.Sex = (System.String)reader[((int)ClinicalStatsColumn.Sex - 1)];
			entity.Nationality = (System.String)reader[((int)ClinicalStatsColumn.Nationality - 1)];
			entity.PatientStart = (reader.IsDBNull(((int)ClinicalStatsColumn.PatientStart - 1)))?null:(System.Boolean?)reader[((int)ClinicalStatsColumn.PatientStart - 1)];
			entity.VitalSign = (reader.IsDBNull(((int)ClinicalStatsColumn.VitalSign - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.VitalSign - 1)];
			entity.Lab = (reader.IsDBNull(((int)ClinicalStatsColumn.Lab - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Lab - 1)];
			entity.Xray = (reader.IsDBNull(((int)ClinicalStatsColumn.Xray - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Xray - 1)];
			entity.UltraSound = (reader.IsDBNull(((int)ClinicalStatsColumn.UltraSound - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.UltraSound - 1)];
			entity.Cardiology = (reader.IsDBNull(((int)ClinicalStatsColumn.Cardiology - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.Cardiology - 1)];
			entity.MedReport = (reader.IsDBNull(((int)ClinicalStatsColumn.MedReport - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.MedReport - 1)];
			entity.ChargedCodes = (reader.IsDBNull(((int)ClinicalStatsColumn.ChargedCodes - 1)))?null:(System.String)reader[((int)ClinicalStatsColumn.ChargedCodes - 1)];
			entity.IsCompleted = (reader.IsDBNull(((int)ClinicalStatsColumn.IsCompleted - 1)))?null:(System.Boolean?)reader[((int)ClinicalStatsColumn.IsCompleted - 1)];
			entity.CreateDate = (reader.IsDBNull(((int)ClinicalStatsColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)ClinicalStatsColumn.CreateDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.ClinicalStats"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.ClinicalStats"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.ClinicalStats entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StatId = (System.Int64)dataRow["StatId"];
			entity.PatientCode = (System.String)dataRow["PatientCode"];
			entity.Tid = (System.String)dataRow["TID"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.Dob = (System.DateTime)dataRow["DOB"];
			entity.Sex = (System.String)dataRow["Sex"];
			entity.Nationality = (System.String)dataRow["Nationality"];
			entity.PatientStart = Convert.IsDBNull(dataRow["PatientStart"]) ? null : (System.Boolean?)dataRow["PatientStart"];
			entity.VitalSign = Convert.IsDBNull(dataRow["VitalSign"]) ? null : (System.String)dataRow["VitalSign"];
			entity.Lab = Convert.IsDBNull(dataRow["Lab"]) ? null : (System.String)dataRow["Lab"];
			entity.Xray = Convert.IsDBNull(dataRow["Xray"]) ? null : (System.String)dataRow["Xray"];
			entity.UltraSound = Convert.IsDBNull(dataRow["UltraSound"]) ? null : (System.String)dataRow["UltraSound"];
			entity.Cardiology = Convert.IsDBNull(dataRow["Cardiology"]) ? null : (System.String)dataRow["Cardiology"];
			entity.MedReport = Convert.IsDBNull(dataRow["MedReport"]) ? null : (System.String)dataRow["MedReport"];
			entity.ChargedCodes = Convert.IsDBNull(dataRow["ChargedCodes"]) ? null : (System.String)dataRow["ChargedCodes"];
			entity.IsCompleted = Convert.IsDBNull(dataRow["IsCompleted"]) ? null : (System.Boolean?)dataRow["IsCompleted"];
			entity.CreateDate = Convert.IsDBNull(dataRow["CreateDate"]) ? null : (System.DateTime?)dataRow["CreateDate"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.ClinicalStats"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.ClinicalStats Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.ClinicalStats entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.ClinicalStats object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.ClinicalStats instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.ClinicalStats Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.ClinicalStats entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region ClinicalStatsChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.ClinicalStats</c>
	///</summary>
	public enum ClinicalStatsChildEntityTypes
	{
	}
	
	#endregion ClinicalStatsChildEntityTypes
	
	#region ClinicalStatsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ClinicalStatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsFilterBuilder : SqlFilterBuilder<ClinicalStatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilterBuilder class.
		/// </summary>
		public ClinicalStatsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClinicalStatsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClinicalStatsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClinicalStatsFilterBuilder
	
	#region ClinicalStatsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ClinicalStatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsParameterBuilder : ParameterizedSqlFilterBuilder<ClinicalStatsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsParameterBuilder class.
		/// </summary>
		public ClinicalStatsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClinicalStatsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClinicalStatsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClinicalStatsParameterBuilder
	
	#region ClinicalStatsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;ClinicalStatsColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class ClinicalStatsSortBuilder : SqlSortBuilder<ClinicalStatsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsSqlSortBuilder class.
		/// </summary>
		public ClinicalStatsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion ClinicalStatsSortBuilder
	
} // end namespace
