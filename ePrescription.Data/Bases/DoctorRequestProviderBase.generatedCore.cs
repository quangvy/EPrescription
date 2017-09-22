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
	/// This class is the base class for any <see cref="DoctorRequestProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DoctorRequestProviderBaseCore : EntityProviderBase<ePrescription.Entities.DoctorRequest, ePrescription.Entities.DoctorRequestKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.DoctorRequestKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _id);		
		
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
		public override ePrescription.Entities.DoctorRequest Get(TransactionManager transactionManager, ePrescription.Entities.DoctorRequestKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public ePrescription.Entities.DoctorRequest GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public ePrescription.Entities.DoctorRequest GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public ePrescription.Entities.DoctorRequest GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public ePrescription.Entities.DoctorRequest GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Id index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public ePrescription.Entities.DoctorRequest GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Id index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.DoctorRequest"/> class.</returns>
		public abstract ePrescription.Entities.DoctorRequest GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region _DoctorRequest_UpdateStatus 
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdateStatus' stored procedure. 
		/// </summary>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateStatus(System.String reqStatus, System.String reqId)
		{
			 UpdateStatus(null, 0, int.MaxValue , reqStatus, reqId);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdateStatus' stored procedure. 
		/// </summary>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateStatus(int start, int pageLength, System.String reqStatus, System.String reqId)
		{
			 UpdateStatus(null, start, pageLength , reqStatus, reqId);
		}
				
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdateStatus' stored procedure. 
		/// </summary>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdateStatus(TransactionManager transactionManager, System.String reqStatus, System.String reqId)
		{
			 UpdateStatus(transactionManager, 0, int.MaxValue , reqStatus, reqId);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdateStatus' stored procedure. 
		/// </summary>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdateStatus(TransactionManager transactionManager, int start, int pageLength , System.String reqStatus, System.String reqId);
		
		#endregion
		
		#region _DoctorRequest_Insert 
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="reqDoctor"> A <c>System.String</c> instance.</param>
		/// <param name="reqDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String tid, System.String reqId, System.String code, System.String description, System.String reqDoctor, System.DateTime? reqDate, System.String reqStatus)
		{
			 Insert(null, 0, int.MaxValue , tid, reqId, code, description, reqDoctor, reqDate, reqStatus);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="reqDoctor"> A <c>System.String</c> instance.</param>
		/// <param name="reqDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String tid, System.String reqId, System.String code, System.String description, System.String reqDoctor, System.DateTime? reqDate, System.String reqStatus)
		{
			 Insert(null, start, pageLength , tid, reqId, code, description, reqDoctor, reqDate, reqStatus);
		}
				
		/// <summary>
		///	This method wrap the '_DoctorRequest_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="reqDoctor"> A <c>System.String</c> instance.</param>
		/// <param name="reqDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String tid, System.String reqId, System.String code, System.String description, System.String reqDoctor, System.DateTime? reqDate, System.String reqStatus)
		{
			 Insert(transactionManager, 0, int.MaxValue , tid, reqId, code, description, reqDoctor, reqDate, reqStatus);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reqId"> A <c>System.String</c> instance.</param>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="description"> A <c>System.String</c> instance.</param>
		/// <param name="reqDoctor"> A <c>System.String</c> instance.</param>
		/// <param name="reqDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="reqStatus"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String tid, System.String reqId, System.String code, System.String description, System.String reqDoctor, System.DateTime? reqDate, System.String reqStatus);
		
		#endregion
		
		#region _DoctorRequest_GetByTID 
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByTID(System.String tid)
		{
			return GetByTID(null, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_GetByTID' stored procedure. 
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
		///	This method wrap the '_DoctorRequest_GetByTID' stored procedure. 
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
		///	This method wrap the '_DoctorRequest_GetByTID' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByTID(TransactionManager transactionManager, int start, int pageLength , System.String tid);
		
		#endregion
		
		#region _DoctorRequest_UpdNurse 
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdNurse' stored procedure. 
		/// </summary>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="billable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdNurse(System.String code, System.Boolean? billable, System.String tid)
		{
			 UpdNurse(null, 0, int.MaxValue , code, billable, tid);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdNurse' stored procedure. 
		/// </summary>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="billable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdNurse(int start, int pageLength, System.String code, System.Boolean? billable, System.String tid)
		{
			 UpdNurse(null, start, pageLength , code, billable, tid);
		}
				
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdNurse' stored procedure. 
		/// </summary>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="billable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdNurse(TransactionManager transactionManager, System.String code, System.Boolean? billable, System.String tid)
		{
			 UpdNurse(transactionManager, 0, int.MaxValue , code, billable, tid);
		}
		
		/// <summary>
		///	This method wrap the '_DoctorRequest_UpdNurse' stored procedure. 
		/// </summary>
		/// <param name="code"> A <c>System.String</c> instance.</param>
		/// <param name="billable"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdNurse(TransactionManager transactionManager, int start, int pageLength , System.String code, System.Boolean? billable, System.String tid);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DoctorRequest&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DoctorRequest&gt;"/></returns>
		public static TList<DoctorRequest> Fill(IDataReader reader, TList<DoctorRequest> rows, int start, int pageLength)
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
				
				ePrescription.Entities.DoctorRequest c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DoctorRequest")
					.Append("|").Append((System.Int64)reader[((int)DoctorRequestColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DoctorRequest>(
					key.ToString(), // EntityTrackingKey
					"DoctorRequest",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.DoctorRequest();
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
					c.Id = (System.Int64)reader[((int)DoctorRequestColumn.Id - 1)];
					c.Tid = (reader.IsDBNull(((int)DoctorRequestColumn.Tid - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Tid - 1)];
					c.ReqId = (reader.IsDBNull(((int)DoctorRequestColumn.ReqId - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqId - 1)];
					c.Code = (reader.IsDBNull(((int)DoctorRequestColumn.Code - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Code - 1)];
					c.Description = (reader.IsDBNull(((int)DoctorRequestColumn.Description - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Description - 1)];
					c.ReqDoctor = (reader.IsDBNull(((int)DoctorRequestColumn.ReqDoctor - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqDoctor - 1)];
					c.ReqDate = (reader.IsDBNull(((int)DoctorRequestColumn.ReqDate - 1)))?null:(System.DateTime?)reader[((int)DoctorRequestColumn.ReqDate - 1)];
					c.ReqStatus = (reader.IsDBNull(((int)DoctorRequestColumn.ReqStatus - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqStatus - 1)];
					c.Billable = (reader.IsDBNull(((int)DoctorRequestColumn.Billable - 1)))?null:(System.Boolean?)reader[((int)DoctorRequestColumn.Billable - 1)];
					c.Sample = (reader.IsDBNull(((int)DoctorRequestColumn.Sample - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Sample - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.DoctorRequest"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.DoctorRequest"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.DoctorRequest entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)DoctorRequestColumn.Id - 1)];
			entity.Tid = (reader.IsDBNull(((int)DoctorRequestColumn.Tid - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Tid - 1)];
			entity.ReqId = (reader.IsDBNull(((int)DoctorRequestColumn.ReqId - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqId - 1)];
			entity.Code = (reader.IsDBNull(((int)DoctorRequestColumn.Code - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Code - 1)];
			entity.Description = (reader.IsDBNull(((int)DoctorRequestColumn.Description - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Description - 1)];
			entity.ReqDoctor = (reader.IsDBNull(((int)DoctorRequestColumn.ReqDoctor - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqDoctor - 1)];
			entity.ReqDate = (reader.IsDBNull(((int)DoctorRequestColumn.ReqDate - 1)))?null:(System.DateTime?)reader[((int)DoctorRequestColumn.ReqDate - 1)];
			entity.ReqStatus = (reader.IsDBNull(((int)DoctorRequestColumn.ReqStatus - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.ReqStatus - 1)];
			entity.Billable = (reader.IsDBNull(((int)DoctorRequestColumn.Billable - 1)))?null:(System.Boolean?)reader[((int)DoctorRequestColumn.Billable - 1)];
			entity.Sample = (reader.IsDBNull(((int)DoctorRequestColumn.Sample - 1)))?null:(System.String)reader[((int)DoctorRequestColumn.Sample - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.DoctorRequest"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.DoctorRequest"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.DoctorRequest entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["Id"];
			entity.Tid = Convert.IsDBNull(dataRow["TID"]) ? null : (System.String)dataRow["TID"];
			entity.ReqId = Convert.IsDBNull(dataRow["ReqID"]) ? null : (System.String)dataRow["ReqID"];
			entity.Code = Convert.IsDBNull(dataRow["Code"]) ? null : (System.String)dataRow["Code"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.ReqDoctor = Convert.IsDBNull(dataRow["ReqDoctor"]) ? null : (System.String)dataRow["ReqDoctor"];
			entity.ReqDate = Convert.IsDBNull(dataRow["ReqDate"]) ? null : (System.DateTime?)dataRow["ReqDate"];
			entity.ReqStatus = Convert.IsDBNull(dataRow["ReqStatus"]) ? null : (System.String)dataRow["ReqStatus"];
			entity.Billable = Convert.IsDBNull(dataRow["Billable"]) ? null : (System.Boolean?)dataRow["Billable"];
			entity.Sample = Convert.IsDBNull(dataRow["Sample"]) ? null : (System.String)dataRow["Sample"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.DoctorRequest"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.DoctorRequest Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.DoctorRequest entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.DoctorRequest object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.DoctorRequest instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.DoctorRequest Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.DoctorRequest entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DoctorRequestChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.DoctorRequest</c>
	///</summary>
	public enum DoctorRequestChildEntityTypes
	{
	}
	
	#endregion DoctorRequestChildEntityTypes
	
	#region DoctorRequestFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DoctorRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestFilterBuilder : SqlFilterBuilder<DoctorRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilterBuilder class.
		/// </summary>
		public DoctorRequestFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DoctorRequestFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DoctorRequestFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DoctorRequestFilterBuilder
	
	#region DoctorRequestParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DoctorRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestParameterBuilder : ParameterizedSqlFilterBuilder<DoctorRequestColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestParameterBuilder class.
		/// </summary>
		public DoctorRequestParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DoctorRequestParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DoctorRequestParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DoctorRequestParameterBuilder
	
	#region DoctorRequestSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DoctorRequestColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DoctorRequestSortBuilder : SqlSortBuilder<DoctorRequestColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestSqlSortBuilder class.
		/// </summary>
		public DoctorRequestSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DoctorRequestSortBuilder
	
} // end namespace
