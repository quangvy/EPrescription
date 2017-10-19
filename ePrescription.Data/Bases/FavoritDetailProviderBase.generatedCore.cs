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
	/// This class is the base class for any <see cref="FavoritDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FavoritDetailProviderBaseCore : EntityProviderBase<ePrescription.Entities.FavoritDetail, ePrescription.Entities.FavoritDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.FavoritDetailKey key)
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
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		FK_FavoritDetail_ID Description: 
		/// </summary>
		/// <param name="_favouriteId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		public TList<FavoritDetail> GetByFavouriteId(System.String _favouriteId)
		{
			int count = -1;
			return GetByFavouriteId(_favouriteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		FK_FavoritDetail_ID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_favouriteId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		/// <remarks></remarks>
		public TList<FavoritDetail> GetByFavouriteId(TransactionManager transactionManager, System.String _favouriteId)
		{
			int count = -1;
			return GetByFavouriteId(transactionManager, _favouriteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		FK_FavoritDetail_ID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_favouriteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		public TList<FavoritDetail> GetByFavouriteId(TransactionManager transactionManager, System.String _favouriteId, int start, int pageLength)
		{
			int count = -1;
			return GetByFavouriteId(transactionManager, _favouriteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		fkFavoritDetailId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_favouriteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		public TList<FavoritDetail> GetByFavouriteId(System.String _favouriteId, int start, int pageLength)
		{
			int count =  -1;
			return GetByFavouriteId(null, _favouriteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		fkFavoritDetailId Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_favouriteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		public TList<FavoritDetail> GetByFavouriteId(System.String _favouriteId, int start, int pageLength,out int count)
		{
			return GetByFavouriteId(null, _favouriteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_FavoritDetail_ID key.
		///		FK_FavoritDetail_ID Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_favouriteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ePrescription.Entities.FavoritDetail objects.</returns>
		public abstract TList<FavoritDetail> GetByFavouriteId(TransactionManager transactionManager, System.String _favouriteId, int start, int pageLength, out int count);
		
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
		public override ePrescription.Entities.FavoritDetail Get(TransactionManager transactionManager, ePrescription.Entities.FavoritDetailKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_FavoritDetail index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public ePrescription.Entities.FavoritDetail GetById(System.Int64 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritDetail index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public ePrescription.Entities.FavoritDetail GetById(System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public ePrescription.Entities.FavoritDetail GetById(TransactionManager transactionManager, System.Int64 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public ePrescription.Entities.FavoritDetail GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritDetail index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public ePrescription.Entities.FavoritDetail GetById(System.Int64 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritDetail"/> class.</returns>
		public abstract ePrescription.Entities.FavoritDetail GetById(TransactionManager transactionManager, System.Int64 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;FavoritDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;FavoritDetail&gt;"/></returns>
		public static TList<FavoritDetail> Fill(IDataReader reader, TList<FavoritDetail> rows, int start, int pageLength)
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
				
				ePrescription.Entities.FavoritDetail c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("FavoritDetail")
					.Append("|").Append((System.Int64)reader[((int)FavoritDetailColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<FavoritDetail>(
					key.ToString(), // EntityTrackingKey
					"FavoritDetail",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.FavoritDetail();
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
					c.Id = (System.Int64)reader[((int)FavoritDetailColumn.Id - 1)];
					c.FavouriteId = (System.String)reader[((int)FavoritDetailColumn.FavouriteId - 1)];
					c.DrugId = (reader.IsDBNull(((int)FavoritDetailColumn.DrugId - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DrugId - 1)];
					c.DrugName = (reader.IsDBNull(((int)FavoritDetailColumn.DrugName - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DrugName - 1)];
					c.RouteType = (reader.IsDBNull(((int)FavoritDetailColumn.RouteType - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.RouteType - 1)];
					c.RouteTypeVn = (reader.IsDBNull(((int)FavoritDetailColumn.RouteTypeVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.RouteTypeVn - 1)];
					c.Dosage = (reader.IsDBNull(((int)FavoritDetailColumn.Dosage - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Dosage - 1)];
					c.DosageUnit = (reader.IsDBNull(((int)FavoritDetailColumn.DosageUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DosageUnit - 1)];
					c.DosageUnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.DosageUnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DosageUnitVn - 1)];
					c.Frequency = (reader.IsDBNull(((int)FavoritDetailColumn.Frequency - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Frequency - 1)];
					c.FrequencyVn = (reader.IsDBNull(((int)FavoritDetailColumn.FrequencyVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.FrequencyVn - 1)];
					c.Duration = (reader.IsDBNull(((int)FavoritDetailColumn.Duration - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Duration - 1)];
					c.DurationUnit = (reader.IsDBNull(((int)FavoritDetailColumn.DurationUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DurationUnit - 1)];
					c.DurationUnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.DurationUnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DurationUnitVn - 1)];
					c.TotalUnit = (reader.IsDBNull(((int)FavoritDetailColumn.TotalUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.TotalUnit - 1)];
					c.Unit = (reader.IsDBNull(((int)FavoritDetailColumn.Unit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Unit - 1)];
					c.UnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.UnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.UnitVn - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.FavoritDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.FavoritDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int64)reader[((int)FavoritDetailColumn.Id - 1)];
			entity.FavouriteId = (System.String)reader[((int)FavoritDetailColumn.FavouriteId - 1)];
			entity.DrugId = (reader.IsDBNull(((int)FavoritDetailColumn.DrugId - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DrugId - 1)];
			entity.DrugName = (reader.IsDBNull(((int)FavoritDetailColumn.DrugName - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DrugName - 1)];
			entity.RouteType = (reader.IsDBNull(((int)FavoritDetailColumn.RouteType - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.RouteType - 1)];
			entity.RouteTypeVn = (reader.IsDBNull(((int)FavoritDetailColumn.RouteTypeVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.RouteTypeVn - 1)];
			entity.Dosage = (reader.IsDBNull(((int)FavoritDetailColumn.Dosage - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Dosage - 1)];
			entity.DosageUnit = (reader.IsDBNull(((int)FavoritDetailColumn.DosageUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DosageUnit - 1)];
			entity.DosageUnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.DosageUnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DosageUnitVn - 1)];
			entity.Frequency = (reader.IsDBNull(((int)FavoritDetailColumn.Frequency - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Frequency - 1)];
			entity.FrequencyVn = (reader.IsDBNull(((int)FavoritDetailColumn.FrequencyVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.FrequencyVn - 1)];
			entity.Duration = (reader.IsDBNull(((int)FavoritDetailColumn.Duration - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Duration - 1)];
			entity.DurationUnit = (reader.IsDBNull(((int)FavoritDetailColumn.DurationUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DurationUnit - 1)];
			entity.DurationUnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.DurationUnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.DurationUnitVn - 1)];
			entity.TotalUnit = (reader.IsDBNull(((int)FavoritDetailColumn.TotalUnit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.TotalUnit - 1)];
			entity.Unit = (reader.IsDBNull(((int)FavoritDetailColumn.Unit - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.Unit - 1)];
			entity.UnitVn = (reader.IsDBNull(((int)FavoritDetailColumn.UnitVn - 1)))?null:(System.String)reader[((int)FavoritDetailColumn.UnitVn - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.FavoritDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.FavoritDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int64)dataRow["ID"];
			entity.FavouriteId = (System.String)dataRow["FavouriteID"];
			entity.DrugId = Convert.IsDBNull(dataRow["DrugID"]) ? null : (System.String)dataRow["DrugID"];
			entity.DrugName = Convert.IsDBNull(dataRow["DrugName"]) ? null : (System.String)dataRow["DrugName"];
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
			entity.Unit = Convert.IsDBNull(dataRow["Unit"]) ? null : (System.String)dataRow["Unit"];
			entity.UnitVn = Convert.IsDBNull(dataRow["UnitVN"]) ? null : (System.String)dataRow["UnitVN"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.FavoritDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.FavoritDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region FavouriteIdSource	
			if (CanDeepLoad(entity, "FavoritMaster|FavouriteIdSource", deepLoadType, innerList) 
				&& entity.FavouriteIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.FavouriteId;
				FavoritMaster tmpEntity = EntityManager.LocateEntity<FavoritMaster>(EntityLocator.ConstructKeyFromPkItems(typeof(FavoritMaster), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.FavouriteIdSource = tmpEntity;
				else
					entity.FavouriteIdSource = DataRepository.FavoritMasterProvider.GetByFavouriteId(transactionManager, entity.FavouriteId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'FavouriteIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.FavouriteIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.FavoritMasterProvider.DeepLoad(transactionManager, entity.FavouriteIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion FavouriteIdSource
			
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
		/// Deep Save the entire object graph of the ePrescription.Entities.FavoritDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.FavoritDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.FavoritDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.FavoritDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region FavouriteIdSource
			if (CanDeepSave(entity, "FavoritMaster|FavouriteIdSource", deepSaveType, innerList) 
				&& entity.FavouriteIdSource != null)
			{
				DataRepository.FavoritMasterProvider.Save(transactionManager, entity.FavouriteIdSource);
				entity.FavouriteId = entity.FavouriteIdSource.FavouriteId;
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
	
	#region FavoritDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.FavoritDetail</c>
	///</summary>
	public enum FavoritDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>FavoritMaster</c> at FavouriteIdSource
		///</summary>
		[ChildEntityType(typeof(FavoritMaster))]
		FavoritMaster,
		}
	
	#endregion FavoritDetailChildEntityTypes
	
	#region FavoritDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FavoritDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailFilterBuilder : SqlFilterBuilder<FavoritDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilterBuilder class.
		/// </summary>
		public FavoritDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritDetailFilterBuilder
	
	#region FavoritDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FavoritDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailParameterBuilder : ParameterizedSqlFilterBuilder<FavoritDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailParameterBuilder class.
		/// </summary>
		public FavoritDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritDetailParameterBuilder
	
	#region FavoritDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FavoritDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FavoritDetailSortBuilder : SqlSortBuilder<FavoritDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailSqlSortBuilder class.
		/// </summary>
		public FavoritDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FavoritDetailSortBuilder
	
} // end namespace
