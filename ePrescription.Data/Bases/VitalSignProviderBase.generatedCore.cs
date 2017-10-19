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
	/// This class is the base class for any <see cref="VitalSignProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class VitalSignProviderBaseCore : EntityProviderBase<ePrescription.Entities.VitalSign, ePrescription.Entities.VitalSignKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.VitalSignKey key)
		{
			return Delete(transactionManager, key.Vid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_vid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _vid)
		{
			return Delete(null, _vid);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vid">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _vid);		
		
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
		public override ePrescription.Entities.VitalSign Get(TransactionManager transactionManager, ePrescription.Entities.VitalSignKey key, int start, int pageLength)
		{
			return GetByVid(transactionManager, key.Vid, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Vsign index.
		/// </summary>
		/// <param name="_vid"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public ePrescription.Entities.VitalSign GetByVid(System.Int64 _vid)
		{
			int count = -1;
			return GetByVid(null,_vid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="_vid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public ePrescription.Entities.VitalSign GetByVid(System.Int64 _vid, int start, int pageLength)
		{
			int count = -1;
			return GetByVid(null, _vid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vid"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public ePrescription.Entities.VitalSign GetByVid(TransactionManager transactionManager, System.Int64 _vid)
		{
			int count = -1;
			return GetByVid(transactionManager, _vid, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public ePrescription.Entities.VitalSign GetByVid(TransactionManager transactionManager, System.Int64 _vid, int start, int pageLength)
		{
			int count = -1;
			return GetByVid(transactionManager, _vid, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="_vid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public ePrescription.Entities.VitalSign GetByVid(System.Int64 _vid, int start, int pageLength, out int count)
		{
			return GetByVid(null, _vid, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vid"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		public abstract ePrescription.Entities.VitalSign GetByVid(TransactionManager transactionManager, System.Int64 _vid, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region _VitalSign_GetByTid 
		
		/// <summary>
		///	This method wrap the '_VitalSign_GetByTid' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;VitalSign&gt;"/> instance.</returns>
		public TList<VitalSign> GetByTid(System.String tid)
		{
			return GetByTid(null, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_GetByTid' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;VitalSign&gt;"/> instance.</returns>
		public TList<VitalSign> GetByTid(int start, int pageLength, System.String tid)
		{
			return GetByTid(null, start, pageLength , tid);
		}
				
		/// <summary>
		///	This method wrap the '_VitalSign_GetByTid' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;VitalSign&gt;"/> instance.</returns>
		public TList<VitalSign> GetByTid(TransactionManager transactionManager, System.String tid)
		{
			return GetByTid(transactionManager, 0, int.MaxValue , tid);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_GetByTid' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;VitalSign&gt;"/> instance.</returns>
		public abstract TList<VitalSign> GetByTid(TransactionManager transactionManager, int start, int pageLength , System.String tid);
		
		#endregion
		
		#region _VitalSign_Update 
		
		/// <summary>
		///	This method wrap the '_VitalSign_Update' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.String tid, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Update(null, 0, int.MaxValue , tid, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_Update' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.String tid, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Update(null, start, pageLength , tid, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
				
		/// <summary>
		///	This method wrap the '_VitalSign_Update' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.String tid, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Update(transactionManager, 0, int.MaxValue , tid, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_Update' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.String tid, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user);
		
		#endregion
		
		#region _VitalSign_Insert 
		
		/// <summary>
		///	This method wrap the '_VitalSign_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.String tid, System.String patientCode, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Insert(null, 0, int.MaxValue , tid, patientCode, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.String tid, System.String patientCode, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Insert(null, start, pageLength , tid, patientCode, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
				
		/// <summary>
		///	This method wrap the '_VitalSign_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.String tid, System.String patientCode, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user)
		{
			 Insert(transactionManager, 0, int.MaxValue , tid, patientCode, temp, pulse, res, press, sato2, gcs, height, weight, createDate, user);
		}
		
		/// <summary>
		///	This method wrap the '_VitalSign_Insert' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="patientCode"> A <c>System.String</c> instance.</param>
		/// <param name="temp"> A <c>System.String</c> instance.</param>
		/// <param name="pulse"> A <c>System.String</c> instance.</param>
		/// <param name="res"> A <c>System.String</c> instance.</param>
		/// <param name="press"> A <c>System.String</c> instance.</param>
		/// <param name="sato2"> A <c>System.String</c> instance.</param>
		/// <param name="gcs"> A <c>System.String</c> instance.</param>
		/// <param name="height"> A <c>System.String</c> instance.</param>
		/// <param name="weight"> A <c>System.String</c> instance.</param>
		/// <param name="createDate"> A <c>System.DateTime?</c> instance.</param>
		/// <param name="user"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.String tid, System.String patientCode, System.String temp, System.String pulse, System.String res, System.String press, System.String sato2, System.String gcs, System.String height, System.String weight, System.DateTime? createDate, System.String user);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;VitalSign&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;VitalSign&gt;"/></returns>
		public static TList<VitalSign> Fill(IDataReader reader, TList<VitalSign> rows, int start, int pageLength)
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
				
				ePrescription.Entities.VitalSign c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("VitalSign")
					.Append("|").Append((System.Int64)reader[((int)VitalSignColumn.Vid - 1)]).ToString();
					c = EntityManager.LocateOrCreate<VitalSign>(
					key.ToString(), // EntityTrackingKey
					"VitalSign",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.VitalSign();
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
					c.Vid = (System.Int64)reader[((int)VitalSignColumn.Vid - 1)];
					c.PatientCode = (System.String)reader[((int)VitalSignColumn.PatientCode - 1)];
					c.Tid = (System.String)reader[((int)VitalSignColumn.Tid - 1)];
					c.Tempurature = (reader.IsDBNull(((int)VitalSignColumn.Tempurature - 1)))?null:(System.String)reader[((int)VitalSignColumn.Tempurature - 1)];
					c.Pulse = (reader.IsDBNull(((int)VitalSignColumn.Pulse - 1)))?null:(System.String)reader[((int)VitalSignColumn.Pulse - 1)];
					c.Respiratory = (reader.IsDBNull(((int)VitalSignColumn.Respiratory - 1)))?null:(System.String)reader[((int)VitalSignColumn.Respiratory - 1)];
					c.BloodPressure = (reader.IsDBNull(((int)VitalSignColumn.BloodPressure - 1)))?null:(System.String)reader[((int)VitalSignColumn.BloodPressure - 1)];
					c.Sato2 = (reader.IsDBNull(((int)VitalSignColumn.Sato2 - 1)))?null:(System.String)reader[((int)VitalSignColumn.Sato2 - 1)];
					c.Gcs = (reader.IsDBNull(((int)VitalSignColumn.Gcs - 1)))?null:(System.String)reader[((int)VitalSignColumn.Gcs - 1)];
					c.Height = (reader.IsDBNull(((int)VitalSignColumn.Height - 1)))?null:(System.String)reader[((int)VitalSignColumn.Height - 1)];
					c.Weight = (reader.IsDBNull(((int)VitalSignColumn.Weight - 1)))?null:(System.String)reader[((int)VitalSignColumn.Weight - 1)];
					c.CreateDate = (reader.IsDBNull(((int)VitalSignColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)VitalSignColumn.CreateDate - 1)];
					c.UpdateDate = (reader.IsDBNull(((int)VitalSignColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)VitalSignColumn.UpdateDate - 1)];
					c.UpdateUser = (reader.IsDBNull(((int)VitalSignColumn.UpdateUser - 1)))?null:(System.String)reader[((int)VitalSignColumn.UpdateUser - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.VitalSign"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.VitalSign"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.VitalSign entity)
		{
			if (!reader.Read()) return;
			
			entity.Vid = (System.Int64)reader[((int)VitalSignColumn.Vid - 1)];
			entity.PatientCode = (System.String)reader[((int)VitalSignColumn.PatientCode - 1)];
			entity.Tid = (System.String)reader[((int)VitalSignColumn.Tid - 1)];
			entity.Tempurature = (reader.IsDBNull(((int)VitalSignColumn.Tempurature - 1)))?null:(System.String)reader[((int)VitalSignColumn.Tempurature - 1)];
			entity.Pulse = (reader.IsDBNull(((int)VitalSignColumn.Pulse - 1)))?null:(System.String)reader[((int)VitalSignColumn.Pulse - 1)];
			entity.Respiratory = (reader.IsDBNull(((int)VitalSignColumn.Respiratory - 1)))?null:(System.String)reader[((int)VitalSignColumn.Respiratory - 1)];
			entity.BloodPressure = (reader.IsDBNull(((int)VitalSignColumn.BloodPressure - 1)))?null:(System.String)reader[((int)VitalSignColumn.BloodPressure - 1)];
			entity.Sato2 = (reader.IsDBNull(((int)VitalSignColumn.Sato2 - 1)))?null:(System.String)reader[((int)VitalSignColumn.Sato2 - 1)];
			entity.Gcs = (reader.IsDBNull(((int)VitalSignColumn.Gcs - 1)))?null:(System.String)reader[((int)VitalSignColumn.Gcs - 1)];
			entity.Height = (reader.IsDBNull(((int)VitalSignColumn.Height - 1)))?null:(System.String)reader[((int)VitalSignColumn.Height - 1)];
			entity.Weight = (reader.IsDBNull(((int)VitalSignColumn.Weight - 1)))?null:(System.String)reader[((int)VitalSignColumn.Weight - 1)];
			entity.CreateDate = (reader.IsDBNull(((int)VitalSignColumn.CreateDate - 1)))?null:(System.DateTime?)reader[((int)VitalSignColumn.CreateDate - 1)];
			entity.UpdateDate = (reader.IsDBNull(((int)VitalSignColumn.UpdateDate - 1)))?null:(System.DateTime?)reader[((int)VitalSignColumn.UpdateDate - 1)];
			entity.UpdateUser = (reader.IsDBNull(((int)VitalSignColumn.UpdateUser - 1)))?null:(System.String)reader[((int)VitalSignColumn.UpdateUser - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.VitalSign"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.VitalSign"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.VitalSign entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Vid = (System.Int64)dataRow["VId"];
			entity.PatientCode = (System.String)dataRow["PatientCode"];
			entity.Tid = (System.String)dataRow["TID"];
			entity.Tempurature = Convert.IsDBNull(dataRow["Tempurature"]) ? null : (System.String)dataRow["Tempurature"];
			entity.Pulse = Convert.IsDBNull(dataRow["Pulse"]) ? null : (System.String)dataRow["Pulse"];
			entity.Respiratory = Convert.IsDBNull(dataRow["Respiratory"]) ? null : (System.String)dataRow["Respiratory"];
			entity.BloodPressure = Convert.IsDBNull(dataRow["BloodPressure"]) ? null : (System.String)dataRow["BloodPressure"];
			entity.Sato2 = Convert.IsDBNull(dataRow["SatO2"]) ? null : (System.String)dataRow["SatO2"];
			entity.Gcs = Convert.IsDBNull(dataRow["GCS"]) ? null : (System.String)dataRow["GCS"];
			entity.Height = Convert.IsDBNull(dataRow["Height"]) ? null : (System.String)dataRow["Height"];
			entity.Weight = Convert.IsDBNull(dataRow["Weight"]) ? null : (System.String)dataRow["Weight"];
			entity.CreateDate = Convert.IsDBNull(dataRow["CreateDate"]) ? null : (System.DateTime?)dataRow["CreateDate"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.VitalSign"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.VitalSign Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.VitalSign entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.VitalSign object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.VitalSign instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.VitalSign Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.VitalSign entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region VitalSignChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.VitalSign</c>
	///</summary>
	public enum VitalSignChildEntityTypes
	{
	}
	
	#endregion VitalSignChildEntityTypes
	
	#region VitalSignFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;VitalSignColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignFilterBuilder : SqlFilterBuilder<VitalSignColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignFilterBuilder class.
		/// </summary>
		public VitalSignFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VitalSignFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VitalSignFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VitalSignFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VitalSignFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VitalSignFilterBuilder
	
	#region VitalSignParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;VitalSignColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignParameterBuilder : ParameterizedSqlFilterBuilder<VitalSignColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignParameterBuilder class.
		/// </summary>
		public VitalSignParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VitalSignParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VitalSignParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VitalSignParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VitalSignParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VitalSignParameterBuilder
	
	#region VitalSignSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;VitalSignColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VitalSignSortBuilder : SqlSortBuilder<VitalSignColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignSqlSortBuilder class.
		/// </summary>
		public VitalSignSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VitalSignSortBuilder
	
} // end namespace
