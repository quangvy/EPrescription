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
	/// This class is the base class for any <see cref="RouteProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class RouteProviderBaseCore : EntityProviderBase<ePrescription.Entities.Route, ePrescription.Entities.RouteKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.RouteKey key)
		{
			return Delete(transactionManager, key.RouteId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_routeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _routeId)
		{
			return Delete(null, _routeId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_routeId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _routeId);		
		
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
		public override ePrescription.Entities.Route Get(TransactionManager transactionManager, ePrescription.Entities.RouteKey key, int start, int pageLength)
		{
			return GetByRouteId(transactionManager, key.RouteId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Route index.
		/// </summary>
		/// <param name="_routeId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public ePrescription.Entities.Route GetByRouteId(System.Int64 _routeId)
		{
			int count = -1;
			return GetByRouteId(null,_routeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Route index.
		/// </summary>
		/// <param name="_routeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public ePrescription.Entities.Route GetByRouteId(System.Int64 _routeId, int start, int pageLength)
		{
			int count = -1;
			return GetByRouteId(null, _routeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Route index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_routeId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public ePrescription.Entities.Route GetByRouteId(TransactionManager transactionManager, System.Int64 _routeId)
		{
			int count = -1;
			return GetByRouteId(transactionManager, _routeId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Route index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_routeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public ePrescription.Entities.Route GetByRouteId(TransactionManager transactionManager, System.Int64 _routeId, int start, int pageLength)
		{
			int count = -1;
			return GetByRouteId(transactionManager, _routeId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Route index.
		/// </summary>
		/// <param name="_routeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public ePrescription.Entities.Route GetByRouteId(System.Int64 _routeId, int start, int pageLength, out int count)
		{
			return GetByRouteId(null, _routeId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Route index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_routeId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Route"/> class.</returns>
		public abstract ePrescription.Entities.Route GetByRouteId(TransactionManager transactionManager, System.Int64 _routeId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Route&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Route&gt;"/></returns>
		public static TList<Route> Fill(IDataReader reader, TList<Route> rows, int start, int pageLength)
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
				
				ePrescription.Entities.Route c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Route")
					.Append("|").Append((System.Int64)reader[((int)RouteColumn.RouteId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Route>(
					key.ToString(), // EntityTrackingKey
					"Route",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.Route();
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
					c.RouteId = (System.Int64)reader[((int)RouteColumn.RouteId - 1)];
					c.Route = (reader.IsDBNull(((int)RouteColumn.Route - 1)))?null:(System.String)reader[((int)RouteColumn.Route - 1)];
					c.RouteVn = (reader.IsDBNull(((int)RouteColumn.RouteVn - 1)))?null:(System.String)reader[((int)RouteColumn.RouteVn - 1)];
					c.Description = (reader.IsDBNull(((int)RouteColumn.Description - 1)))?null:(System.String)reader[((int)RouteColumn.Description - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Route"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Route"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.Route entity)
		{
			if (!reader.Read()) return;
			
			entity.RouteId = (System.Int64)reader[((int)RouteColumn.RouteId - 1)];
			entity.Route = (reader.IsDBNull(((int)RouteColumn.Route - 1)))?null:(System.String)reader[((int)RouteColumn.Route - 1)];
			entity.RouteVn = (reader.IsDBNull(((int)RouteColumn.RouteVn - 1)))?null:(System.String)reader[((int)RouteColumn.RouteVn - 1)];
			entity.Description = (reader.IsDBNull(((int)RouteColumn.Description - 1)))?null:(System.String)reader[((int)RouteColumn.Description - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Route"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Route"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.Route entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.RouteId = (System.Int64)dataRow["RouteId"];
			entity.Route = Convert.IsDBNull(dataRow["Route"]) ? null : (System.String)dataRow["Route"];
			entity.RouteVn = Convert.IsDBNull(dataRow["RouteVN"]) ? null : (System.String)dataRow["RouteVN"];
			entity.Description = Convert.IsDBNull(dataRow["Description"]) ? null : (System.String)dataRow["Description"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.Route"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.Route Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.Route entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.Route object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.Route instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.Route Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.Route entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region RouteChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.Route</c>
	///</summary>
	public enum RouteChildEntityTypes
	{
	}
	
	#endregion RouteChildEntityTypes
	
	#region RouteFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;RouteColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteFilterBuilder : SqlFilterBuilder<RouteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteFilterBuilder class.
		/// </summary>
		public RouteFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RouteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RouteFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RouteFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RouteFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RouteFilterBuilder
	
	#region RouteParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;RouteColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteParameterBuilder : ParameterizedSqlFilterBuilder<RouteColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteParameterBuilder class.
		/// </summary>
		public RouteParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the RouteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RouteParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RouteParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RouteParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RouteParameterBuilder
	
	#region RouteSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;RouteColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class RouteSortBuilder : SqlSortBuilder<RouteColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteSqlSortBuilder class.
		/// </summary>
		public RouteSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion RouteSortBuilder
	
} // end namespace
