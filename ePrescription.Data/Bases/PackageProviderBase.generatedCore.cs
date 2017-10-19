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
	/// This class is the base class for any <see cref="PackageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class PackageProviderBaseCore : EntityProviderBase<ePrescription.Entities.Package, ePrescription.Entities.PackageKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.PackageKey key)
		{
			return Delete(transactionManager, key.PackageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_packageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _packageId)
		{
			return Delete(null, _packageId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _packageId);		
		
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
		public override ePrescription.Entities.Package Get(TransactionManager transactionManager, ePrescription.Entities.PackageKey key, int start, int pageLength)
		{
			return GetByPackageId(transactionManager, key.PackageId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Package index.
		/// </summary>
		/// <param name="_packageId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public ePrescription.Entities.Package GetByPackageId(System.String _packageId)
		{
			int count = -1;
			return GetByPackageId(null,_packageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Package index.
		/// </summary>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public ePrescription.Entities.Package GetByPackageId(System.String _packageId, int start, int pageLength)
		{
			int count = -1;
			return GetByPackageId(null, _packageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Package index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public ePrescription.Entities.Package GetByPackageId(TransactionManager transactionManager, System.String _packageId)
		{
			int count = -1;
			return GetByPackageId(transactionManager, _packageId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Package index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public ePrescription.Entities.Package GetByPackageId(TransactionManager transactionManager, System.String _packageId, int start, int pageLength)
		{
			int count = -1;
			return GetByPackageId(transactionManager, _packageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Package index.
		/// </summary>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public ePrescription.Entities.Package GetByPackageId(System.String _packageId, int start, int pageLength, out int count)
		{
			return GetByPackageId(null, _packageId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Package index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_packageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Package"/> class.</returns>
		public abstract ePrescription.Entities.Package GetByPackageId(TransactionManager transactionManager, System.String _packageId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Package&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Package&gt;"/></returns>
		public static TList<Package> Fill(IDataReader reader, TList<Package> rows, int start, int pageLength)
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
				
				ePrescription.Entities.Package c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Package")
					.Append("|").Append((System.String)reader[((int)PackageColumn.PackageId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Package>(
					key.ToString(), // EntityTrackingKey
					"Package",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.Package();
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
					c.PackageId = (System.String)reader[((int)PackageColumn.PackageId - 1)];
					c.OriginalPackageId = c.PackageId;
					c.Name = (System.String)reader[((int)PackageColumn.Name - 1)];
					c.Description = (reader.IsDBNull(((int)PackageColumn.Description - 1)))?null:(System.String)reader[((int)PackageColumn.Description - 1)];
					c.SellPrice = (reader.IsDBNull(((int)PackageColumn.SellPrice - 1)))?null:(System.Decimal?)reader[((int)PackageColumn.SellPrice - 1)];
					c.CostPrice = (reader.IsDBNull(((int)PackageColumn.CostPrice - 1)))?null:(System.Decimal?)reader[((int)PackageColumn.CostPrice - 1)];
					c.CreatedBy = (reader.IsDBNull(((int)PackageColumn.CreatedBy - 1)))?null:(System.String)reader[((int)PackageColumn.CreatedBy - 1)];
					c.CreatedDate = (reader.IsDBNull(((int)PackageColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)PackageColumn.CreatedDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Package"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Package"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.Package entity)
		{
			if (!reader.Read()) return;
			
			entity.PackageId = (System.String)reader[((int)PackageColumn.PackageId - 1)];
			entity.OriginalPackageId = (System.String)reader["PackageID"];
			entity.Name = (System.String)reader[((int)PackageColumn.Name - 1)];
			entity.Description = (reader.IsDBNull(((int)PackageColumn.Description - 1)))?null:(System.String)reader[((int)PackageColumn.Description - 1)];
			entity.SellPrice = (reader.IsDBNull(((int)PackageColumn.SellPrice - 1)))?null:(System.Decimal?)reader[((int)PackageColumn.SellPrice - 1)];
			entity.CostPrice = (reader.IsDBNull(((int)PackageColumn.CostPrice - 1)))?null:(System.Decimal?)reader[((int)PackageColumn.CostPrice - 1)];
			entity.CreatedBy = (reader.IsDBNull(((int)PackageColumn.CreatedBy - 1)))?null:(System.String)reader[((int)PackageColumn.CreatedBy - 1)];
			entity.CreatedDate = (reader.IsDBNull(((int)PackageColumn.CreatedDate - 1)))?null:(System.DateTime?)reader[((int)PackageColumn.CreatedDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Package"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Package"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.Package entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PackageId = (System.String)dataRow["PackageID"];
			entity.OriginalPackageId = (System.String)dataRow["PackageID"];
			entity.Name = (System.String)dataRow["Name"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
			entity.SellPrice = Convert.IsDBNull(dataRow["SellPrice"]) ? null : (System.Decimal?)dataRow["SellPrice"];
			entity.CostPrice = Convert.IsDBNull(dataRow["CostPrice"]) ? null : (System.Decimal?)dataRow["CostPrice"];
			entity.CreatedBy = Convert.IsDBNull(dataRow["CreatedBy"]) ? null : (System.String)dataRow["CreatedBy"];
			entity.CreatedDate = Convert.IsDBNull(dataRow["CreatedDate"]) ? null : (System.DateTime?)dataRow["CreatedDate"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.Package"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.Package Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.Package entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByPackageId methods when available
			
			#region PackageDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<PackageDetail>|PackageDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'PackageDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.PackageDetailCollection = DataRepository.PackageDetailProvider.GetByPackageId(transactionManager, entity.PackageId);

				if (deep && entity.PackageDetailCollection.Count > 0)
				{
					deepHandles.Add("PackageDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<PackageDetail>) DataRepository.PackageDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.PackageDetailCollection, deep, deepLoadType, childTypes, innerList }
					));
				}
			}		
			#endregion 
			
			
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
		/// Deep Save the entire object graph of the ePrescription.Entities.Package object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.Package instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.Package Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.Package entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<PackageDetail>
				if (CanDeepSave(entity.PackageDetailCollection, "List<PackageDetail>|PackageDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(PackageDetail child in entity.PackageDetailCollection)
					{
						if(child.PackageIdSource != null)
						{
							child.PackageId = child.PackageIdSource.PackageId;
						}
						else
						{
							child.PackageId = entity.PackageId;
						}

					}

					if (entity.PackageDetailCollection.Count > 0 || entity.PackageDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.PackageDetailProvider.Save(transactionManager, entity.PackageDetailCollection);
						
						deepHandles.Add("PackageDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< PackageDetail >) DataRepository.PackageDetailProvider.DeepSave,
							new object[] { transactionManager, entity.PackageDetailCollection, deepSaveType, childTypes, innerList }
						));
					}
				} 
			#endregion 
				
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
	
	#region PackageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.Package</c>
	///</summary>
	public enum PackageChildEntityTypes
	{

		///<summary>
		/// Collection of <c>Package</c> as OneToMany for PackageDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<PackageDetail>))]
		PackageDetailCollection,
	}
	
	#endregion PackageChildEntityTypes
	
	#region PackageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;PackageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageFilterBuilder : SqlFilterBuilder<PackageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageFilterBuilder class.
		/// </summary>
		public PackageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageFilterBuilder
	
	#region PackageParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;PackageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageParameterBuilder : ParameterizedSqlFilterBuilder<PackageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageParameterBuilder class.
		/// </summary>
		public PackageParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageParameterBuilder
	
	#region PackageSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;PackageColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class PackageSortBuilder : SqlSortBuilder<PackageColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageSqlSortBuilder class.
		/// </summary>
		public PackageSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion PackageSortBuilder
	
} // end namespace
