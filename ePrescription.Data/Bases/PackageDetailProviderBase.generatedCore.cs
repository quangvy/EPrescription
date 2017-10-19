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
	/// This class is the base class for any <see cref="PackageDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PackageDetailProviderBaseCore : EntityProviderBase<ePrescription.Entities.PackageDetail, ePrescription.Entities.PackageDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.PackageDetailKey key)
		{
			return Delete(transactionManager, key.PackageDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_packageDetailId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _packageDetailId)
		{
			return Delete(null, _packageDetailId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageDetailId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _packageDetailId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		PK_PackageDetail_Package Description: 
		/// </summary>
		/// <param name="_packageId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		public TList<PackageDetail> GetByPackageId(System.String _packageId)
		{
			int count = -1;
			return GetByPackageId(_packageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		PK_PackageDetail_Package Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		/// <remarks></remarks>
		public TList<PackageDetail> GetByPackageId(TransactionManager transactionManager, System.String _packageId)
		{
			int count = -1;
			return GetByPackageId(transactionManager, _packageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		PK_PackageDetail_Package Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		public TList<PackageDetail> GetByPackageId(TransactionManager transactionManager, System.String _packageId, int start, int pageLength)
		{
			int count = -1;
			return GetByPackageId(transactionManager, _packageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		pkPackageDetailPackage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_packageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		public TList<PackageDetail> GetByPackageId(System.String _packageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByPackageId(null, _packageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		pkPackageDetailPackage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_packageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		public TList<PackageDetail> GetByPackageId(System.String _packageId, int start, int pageLength,out int count)
		{
			return GetByPackageId(null, _packageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail_Package key.
		///		PK_PackageDetail_Package Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of ePrescription.Entities.PackageDetail objects.</returns>
		public abstract TList<PackageDetail> GetByPackageId(TransactionManager transactionManager, System.String _packageId, int start, int pageLength, out int count);
		
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
		public override ePrescription.Entities.PackageDetail Get(TransactionManager transactionManager, ePrescription.Entities.PackageDetailKey key, int start, int pageLength)
		{
			return GetByPackageDetailId(transactionManager, key.PackageDetailId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_PackageDetail index.
		/// </summary>
		/// <param name="_packageDetailId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public ePrescription.Entities.PackageDetail GetByPackageDetailId(System.Int32 _packageDetailId)
		{
			int count = -1;
			return GetByPackageDetailId(null,_packageDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail index.
		/// </summary>
		/// <param name="_packageDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public ePrescription.Entities.PackageDetail GetByPackageDetailId(System.Int32 _packageDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPackageDetailId(null, _packageDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageDetailId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public ePrescription.Entities.PackageDetail GetByPackageDetailId(TransactionManager transactionManager, System.Int32 _packageDetailId)
		{
			int count = -1;
			return GetByPackageDetailId(transactionManager, _packageDetailId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public ePrescription.Entities.PackageDetail GetByPackageDetailId(TransactionManager transactionManager, System.Int32 _packageDetailId, int start, int pageLength)
		{
			int count = -1;
			return GetByPackageDetailId(transactionManager, _packageDetailId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail index.
		/// </summary>
		/// <param name="_packageDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public ePrescription.Entities.PackageDetail GetByPackageDetailId(System.Int32 _packageDetailId, int start, int pageLength, out int count)
		{
			return GetByPackageDetailId(null, _packageDetailId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_PackageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageDetailId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.PackageDetail"/> class.</returns>
		public abstract ePrescription.Entities.PackageDetail GetByPackageDetailId(TransactionManager transactionManager, System.Int32 _packageDetailId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;PackageDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;PackageDetail&gt;"/></returns>
		public static TList<PackageDetail> Fill(IDataReader reader, TList<PackageDetail> rows, int start, int pageLength)
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
				
				ePrescription.Entities.PackageDetail c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("PackageDetail")
					.Append("|").Append((System.Int32)reader[((int)PackageDetailColumn.PackageDetailId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<PackageDetail>(
					key.ToString(), // EntityTrackingKey
					"PackageDetail",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.PackageDetail();
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
					c.PackageDetailId = (System.Int32)reader[((int)PackageDetailColumn.PackageDetailId - 1)];
					c.PackageId = (System.String)reader[((int)PackageDetailColumn.PackageId - 1)];
					c.Code = (reader.IsDBNull(((int)PackageDetailColumn.Code - 1)))?null:(System.String)reader[((int)PackageDetailColumn.Code - 1)];
					c.Description = (reader.IsDBNull(((int)PackageDetailColumn.Description - 1)))?null:(System.String)reader[((int)PackageDetailColumn.Description - 1)];
					c.ClinicPrice = (reader.IsDBNull(((int)PackageDetailColumn.ClinicPrice - 1)))?null:(System.Decimal?)reader[((int)PackageDetailColumn.ClinicPrice - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.PackageDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.PackageDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.PackageDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.PackageDetailId = (System.Int32)reader[((int)PackageDetailColumn.PackageDetailId - 1)];
			entity.PackageId = (System.String)reader[((int)PackageDetailColumn.PackageId - 1)];
			entity.Code = (reader.IsDBNull(((int)PackageDetailColumn.Code - 1)))?null:(System.String)reader[((int)PackageDetailColumn.Code - 1)];
			entity.Description = (reader.IsDBNull(((int)PackageDetailColumn.Description - 1)))?null:(System.String)reader[((int)PackageDetailColumn.Description - 1)];
			entity.ClinicPrice = (reader.IsDBNull(((int)PackageDetailColumn.ClinicPrice - 1)))?null:(System.Decimal?)reader[((int)PackageDetailColumn.ClinicPrice - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.PackageDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.PackageDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.PackageDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PackageDetailId = (System.Int32)dataRow["PackageDetailId"];
			entity.PackageId = (System.String)dataRow["PackageID"];
			entity.Code = Convert.IsDBNull(dataRow["Code"]) ? null : (System.String)dataRow["Code"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.ClinicPrice = Convert.IsDBNull(dataRow["ClinicPrice"]) ? null : (System.Decimal?)dataRow["ClinicPrice"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.PackageDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.PackageDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.PackageDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region PackageIdSource	
			if (CanDeepLoad(entity, "Package|PackageIdSource", deepLoadType, innerList) 
				&& entity.PackageIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.PackageId;
				Package tmpEntity = EntityManager.LocateEntity<Package>(EntityLocator.ConstructKeyFromPkItems(typeof(Package), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.PackageIdSource = tmpEntity;
				else
					entity.PackageIdSource = DataRepository.PackageProvider.GetByPackageId(transactionManager, entity.PackageId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PackageIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.PackageIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.PackageProvider.DeepLoad(transactionManager, entity.PackageIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion PackageIdSource
			
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
		/// Deep Save the entire object graph of the ePrescription.Entities.PackageDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.PackageDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.PackageDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.PackageDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region PackageIdSource
			if (CanDeepSave(entity, "Package|PackageIdSource", deepSaveType, innerList) 
				&& entity.PackageIdSource != null)
			{
				DataRepository.PackageProvider.Save(transactionManager, entity.PackageIdSource);
				entity.PackageId = entity.PackageIdSource.PackageId;
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
	
	#region PackageDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.PackageDetail</c>
	///</summary>
	public enum PackageDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Package</c> at PackageIdSource
		///</summary>
		[ChildEntityType(typeof(Package))]
		Package,
		}
	
	#endregion PackageDetailChildEntityTypes
	
	#region PackageDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PackageDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailFilterBuilder : SqlFilterBuilder<PackageDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilterBuilder class.
		/// </summary>
		public PackageDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageDetailFilterBuilder
	
	#region PackageDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PackageDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailParameterBuilder : ParameterizedSqlFilterBuilder<PackageDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailParameterBuilder class.
		/// </summary>
		public PackageDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageDetailParameterBuilder
	
	#region PackageDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PackageDetailColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PackageDetailSortBuilder : SqlSortBuilder<PackageDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailSqlSortBuilder class.
		/// </summary>
		public PackageDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PackageDetailSortBuilder
	
} // end namespace
