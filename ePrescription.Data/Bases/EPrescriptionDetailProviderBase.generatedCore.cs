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
	/// This class is the base class for any <see cref="EPrescriptionDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EPrescriptionDetailProviderBaseCore : EntityProviderBase<ePrescription.Entities.EPrescriptionDetail, ePrescription.Entities.EPrescriptionDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionDetailKey key)
		{
			return Delete(transactionManager, key.PrescriptionDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_prescriptionDetailId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _prescriptionDetailId)
		{
			return Delete(null, _prescriptionDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionDetailId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _prescriptionDetailId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		FK_ePrescriptionDetail_ePrescription Description: 
		/// </summary>
		/// <param name="_prescriptionId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		public TList<EPrescriptionDetail> GetByPrescriptionId(System.String _prescriptionId)
		{
			int count = -1;
			return GetByPrescriptionId(_prescriptionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		FK_ePrescriptionDetail_ePrescription Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		/// <remarks></remarks>
		public TList<EPrescriptionDetail> GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId)
		{
			int count = -1;
			return GetByPrescriptionId(transactionManager, _prescriptionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		FK_ePrescriptionDetail_ePrescription Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		public TList<EPrescriptionDetail> GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByPrescriptionId(transactionManager, _prescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		fkEPrescriptionDetailEPrescription Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_prescriptionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		public TList<EPrescriptionDetail> GetByPrescriptionId(System.String _prescriptionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPrescriptionId(null, _prescriptionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		fkEPrescriptionDetailEPrescription Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_prescriptionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		public TList<EPrescriptionDetail> GetByPrescriptionId(System.String _prescriptionId, int start, int pageLength,out int count)
		{
			return GetByPrescriptionId(null, _prescriptionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ePrescriptionDetail_ePrescription key.
		///		FK_ePrescriptionDetail_ePrescription Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ePrescription.Entities.EPrescriptionDetail objects.</returns>
		public abstract TList<EPrescriptionDetail> GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId, int start, int pageLength, out int count);
		
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
		public override ePrescription.Entities.EPrescriptionDetail Get(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionDetailKey key, int start, int pageLength)
		{
			return GetByPrescriptionDetailId(transactionManager, key.PrescriptionDetailId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="_prescriptionDetailId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(System.Int64 _prescriptionDetailId)
		{
			int count = -1;
			return GetByPrescriptionDetailId(null,_prescriptionDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="_prescriptionDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(System.Int64 _prescriptionDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPrescriptionDetailId(null, _prescriptionDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionDetailId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(TransactionManager transactionManager, System.Int64 _prescriptionDetailId)
		{
			int count = -1;
			return GetByPrescriptionDetailId(transactionManager, _prescriptionDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(TransactionManager transactionManager, System.Int64 _prescriptionDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPrescriptionDetailId(transactionManager, _prescriptionDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="_prescriptionDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(System.Int64 _prescriptionDetailId, int start, int pageLength, out int count)
		{
			return GetByPrescriptionDetailId(null, _prescriptionDetailId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescriptionDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescriptionDetail"/> class.</returns>
		public abstract ePrescription.Entities.EPrescriptionDetail GetByPrescriptionDetailId(TransactionManager transactionManager, System.Int64 _prescriptionDetailId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EPrescriptionDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EPrescriptionDetail&gt;"/></returns>
		public static TList<EPrescriptionDetail> Fill(IDataReader reader, TList<EPrescriptionDetail> rows, int start, int pageLength)
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
				
				ePrescription.Entities.EPrescriptionDetail c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EPrescriptionDetail")
					.Append("|").Append((System.Int64)reader[((int)EPrescriptionDetailColumn.PrescriptionDetailId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EPrescriptionDetail>(
					key.ToString(), // EntityTrackingKey
					"EPrescriptionDetail",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.EPrescriptionDetail();
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
					c.PrescriptionDetailId = (System.Int64)reader[((int)EPrescriptionDetailColumn.PrescriptionDetailId - 1)];
					c.PrescriptionId = (System.String)reader[((int)EPrescriptionDetailColumn.PrescriptionId - 1)];
					c.Sq = (System.Int32)reader[((int)EPrescriptionDetailColumn.Sq - 1)];
					c.DrugId = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DrugId - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DrugId - 1)];
					c.DrugName = (System.String)reader[((int)EPrescriptionDetailColumn.DrugName - 1)];
					c.Unit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Unit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Unit - 1)];
					c.UnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.UnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.UnitVn - 1)];
					c.Remark = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Remark - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Remark - 1)];
					c.RouteType = (reader.IsDBNull(((int)EPrescriptionDetailColumn.RouteType - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.RouteType - 1)];
					c.RouteTypeVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.RouteTypeVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.RouteTypeVn - 1)];
					c.Dosage = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Dosage - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Dosage - 1)];
					c.DosageUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DosageUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DosageUnit - 1)];
					c.DosageUnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DosageUnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DosageUnitVn - 1)];
					c.Frequency = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Frequency - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Frequency - 1)];
					c.FrequencyVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.FrequencyVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.FrequencyVn - 1)];
					c.Duration = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Duration - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Duration - 1)];
					c.DurationUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DurationUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DurationUnit - 1)];
					c.DurationUnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DurationUnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DurationUnitVn - 1)];
					c.TotalUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.TotalUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.TotalUnit - 1)];
					c.Refill = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Refill - 1)))?null:(System.Boolean?)reader[((int)EPrescriptionDetailColumn.Refill - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.EPrescriptionDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescriptionDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.EPrescriptionDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.PrescriptionDetailId = (System.Int64)reader[((int)EPrescriptionDetailColumn.PrescriptionDetailId - 1)];
			entity.PrescriptionId = (System.String)reader[((int)EPrescriptionDetailColumn.PrescriptionId - 1)];
			entity.Sq = (System.Int32)reader[((int)EPrescriptionDetailColumn.Sq - 1)];
			entity.DrugId = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DrugId - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DrugId - 1)];
			entity.DrugName = (System.String)reader[((int)EPrescriptionDetailColumn.DrugName - 1)];
			entity.Unit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Unit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Unit - 1)];
			entity.UnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.UnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.UnitVn - 1)];
			entity.Remark = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Remark - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Remark - 1)];
			entity.RouteType = (reader.IsDBNull(((int)EPrescriptionDetailColumn.RouteType - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.RouteType - 1)];
			entity.RouteTypeVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.RouteTypeVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.RouteTypeVn - 1)];
			entity.Dosage = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Dosage - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Dosage - 1)];
			entity.DosageUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DosageUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DosageUnit - 1)];
			entity.DosageUnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DosageUnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DosageUnitVn - 1)];
			entity.Frequency = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Frequency - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Frequency - 1)];
			entity.FrequencyVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.FrequencyVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.FrequencyVn - 1)];
			entity.Duration = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Duration - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.Duration - 1)];
			entity.DurationUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DurationUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DurationUnit - 1)];
			entity.DurationUnitVn = (reader.IsDBNull(((int)EPrescriptionDetailColumn.DurationUnitVn - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.DurationUnitVn - 1)];
			entity.TotalUnit = (reader.IsDBNull(((int)EPrescriptionDetailColumn.TotalUnit - 1)))?null:(System.String)reader[((int)EPrescriptionDetailColumn.TotalUnit - 1)];
			entity.Refill = (reader.IsDBNull(((int)EPrescriptionDetailColumn.Refill - 1)))?null:(System.Boolean?)reader[((int)EPrescriptionDetailColumn.Refill - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.EPrescriptionDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescriptionDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.EPrescriptionDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PrescriptionDetailId = (System.Int64)dataRow["PrescriptionDetailId"];
			entity.PrescriptionId = (System.String)dataRow["PrescriptionID"];
			entity.Sq = (System.Int32)dataRow["Sq"];
			entity.DrugId = Convert.IsDBNull(dataRow["DrugId"]) ? null : (System.String)dataRow["DrugId"];
			entity.DrugName = (System.String)dataRow["DrugName"];
			entity.Unit = Convert.IsDBNull(dataRow["Unit"]) ? null : (System.String)dataRow["Unit"];
			entity.UnitVn = Convert.IsDBNull(dataRow["UnitVN"]) ? null : (System.String)dataRow["UnitVN"];
			entity.Remark = Convert.IsDBNull(dataRow["Remark"]) ? null : (System.String)dataRow["Remark"];
			entity.RouteType = Convert.IsDBNull(dataRow["RouteType"]) ? null : (System.String)dataRow["RouteType"];
			entity.RouteTypeVn = Convert.IsDBNull(dataRow["RouteTypeVN"]) ? null : (System.String)dataRow["RouteTypeVN"];
			entity.Dosage = Convert.IsDBNull(dataRow["Dosage"]) ? null : (System.String)dataRow["Dosage"];
			entity.DosageUnit = Convert.IsDBNull(dataRow["DosageUnit"]) ? null : (System.String)dataRow["DosageUnit"];
			entity.DosageUnitVn = Convert.IsDBNull(dataRow["DosageUnitVN"]) ? null : (System.String)dataRow["DosageUnitVN"];
			entity.Frequency = Convert.IsDBNull(dataRow["Frequency"]) ? null : (System.String)dataRow["Frequency"];
			entity.FrequencyVn = Convert.IsDBNull(dataRow["FrequencyVN"]) ? null : (System.String)dataRow["FrequencyVN"];
			entity.Duration = Convert.IsDBNull(dataRow["Duration"]) ? null : (System.String)dataRow["Duration"];
			entity.DurationUnit = Convert.IsDBNull(dataRow["DurationUnit"]) ? null : (System.String)dataRow["DurationUnit"];
			entity.DurationUnitVn = Convert.IsDBNull(dataRow["DurationUnitVN"]) ? null : (System.String)dataRow["DurationUnitVN"];
			entity.TotalUnit = Convert.IsDBNull(dataRow["TotalUnit"]) ? null : (System.String)dataRow["TotalUnit"];
			entity.Refill = Convert.IsDBNull(dataRow["Refill"]) ? null : (System.Boolean?)dataRow["Refill"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescriptionDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.EPrescriptionDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region PrescriptionIdSource	
			if (CanDeepLoad(entity, "EPrescription|PrescriptionIdSource", deepLoadType, innerList) 
				&& entity.PrescriptionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PrescriptionId;
				EPrescription tmpEntity = EntityManager.LocateEntity<EPrescription>(EntityLocator.ConstructKeyFromPkItems(typeof(EPrescription), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PrescriptionIdSource = tmpEntity;
				else
					entity.PrescriptionIdSource = DataRepository.EPrescriptionProvider.GetByPrescriptionId(transactionManager, entity.PrescriptionId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PrescriptionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PrescriptionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.EPrescriptionProvider.DeepLoad(transactionManager, entity.PrescriptionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PrescriptionIdSource
			
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
		/// Deep Save the entire object graph of the ePrescription.Entities.EPrescriptionDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.EPrescriptionDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.EPrescriptionDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PrescriptionIdSource
			if (CanDeepSave(entity, "EPrescription|PrescriptionIdSource", deepSaveType, innerList) 
				&& entity.PrescriptionIdSource != null)
			{
				DataRepository.EPrescriptionProvider.Save(transactionManager, entity.PrescriptionIdSource);
				entity.PrescriptionId = entity.PrescriptionIdSource.PrescriptionId;
			}
			#endregion 
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
	
	#region EPrescriptionDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.EPrescriptionDetail</c>
	///</summary>
	public enum EPrescriptionDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>EPrescription</c> at PrescriptionIdSource
		///</summary>
		[ChildEntityType(typeof(EPrescription))]
		EPrescription,
		}
	
	#endregion EPrescriptionDetailChildEntityTypes
	
	#region EPrescriptionDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EPrescriptionDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailFilterBuilder : SqlFilterBuilder<EPrescriptionDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilterBuilder class.
		/// </summary>
		public EPrescriptionDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionDetailFilterBuilder
	
	#region EPrescriptionDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EPrescriptionDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailParameterBuilder : ParameterizedSqlFilterBuilder<EPrescriptionDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailParameterBuilder class.
		/// </summary>
		public EPrescriptionDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionDetailParameterBuilder
	
	#region EPrescriptionDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EPrescriptionDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EPrescriptionDetailSortBuilder : SqlSortBuilder<EPrescriptionDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailSqlSortBuilder class.
		/// </summary>
		public EPrescriptionDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EPrescriptionDetailSortBuilder
	
} // end namespace
