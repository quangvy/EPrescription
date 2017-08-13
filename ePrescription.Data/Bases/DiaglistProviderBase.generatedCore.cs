﻿#region Using directives

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
	/// This class is the base class for any <see cref="DiaglistProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DiaglistProviderBaseCore : EntityProviderBase<ePrescription.Entities.Diaglist, ePrescription.Entities.DiaglistKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.DiaglistKey key)
		{
			return Delete(transactionManager, key.DiagCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_diagCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _diagCode)
		{
			return Delete(null, _diagCode);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_diagCode">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _diagCode);		
		
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
		public override ePrescription.Entities.Diaglist Get(TransactionManager transactionManager, ePrescription.Entities.DiaglistKey key, int start, int pageLength)
		{
			return GetByDiagCode(transactionManager, key.DiagCode, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_DIAG_LIST index.
		/// </summary>
		/// <param name="_diagCode"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public ePrescription.Entities.Diaglist GetByDiagCode(System.String _diagCode)
		{
			int count = -1;
			return GetByDiagCode(null,_diagCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DIAG_LIST index.
		/// </summary>
		/// <param name="_diagCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public ePrescription.Entities.Diaglist GetByDiagCode(System.String _diagCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDiagCode(null, _diagCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DIAG_LIST index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_diagCode"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public ePrescription.Entities.Diaglist GetByDiagCode(TransactionManager transactionManager, System.String _diagCode)
		{
			int count = -1;
			return GetByDiagCode(transactionManager, _diagCode, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DIAG_LIST index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_diagCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public ePrescription.Entities.Diaglist GetByDiagCode(TransactionManager transactionManager, System.String _diagCode, int start, int pageLength)
		{
			int count = -1;
			return GetByDiagCode(transactionManager, _diagCode, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DIAG_LIST index.
		/// </summary>
		/// <param name="_diagCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public ePrescription.Entities.Diaglist GetByDiagCode(System.String _diagCode, int start, int pageLength, out int count)
		{
			return GetByDiagCode(null, _diagCode, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_DIAG_LIST index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_diagCode"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Diaglist"/> class.</returns>
		public abstract ePrescription.Entities.Diaglist GetByDiagCode(TransactionManager transactionManager, System.String _diagCode, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Diaglist&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Diaglist&gt;"/></returns>
		public static TList<Diaglist> Fill(IDataReader reader, TList<Diaglist> rows, int start, int pageLength)
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
				
				ePrescription.Entities.Diaglist c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Diaglist")
					.Append("|").Append((System.String)reader[((int)DiaglistColumn.DiagCode - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Diaglist>(
					key.ToString(), // EntityTrackingKey
					"Diaglist",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.Diaglist();
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
					c.Category = (System.String)reader[((int)DiaglistColumn.Category - 1)];
					c.DiagCode = (System.String)reader[((int)DiaglistColumn.DiagCode - 1)];
					c.OriginalDiagCode = c.DiagCode;
					c.DiagName = (System.String)reader[((int)DiaglistColumn.DiagName - 1)];
					c.DiagNameVn = (System.String)reader[((int)DiaglistColumn.DiagNameVn - 1)];
					c.IsDisabled = (System.Boolean)reader[((int)DiaglistColumn.IsDisabled - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Diaglist"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Diaglist"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.Diaglist entity)
		{
			if (!reader.Read()) return;
			
			entity.Category = (System.String)reader[((int)DiaglistColumn.Category - 1)];
			entity.DiagCode = (System.String)reader[((int)DiaglistColumn.DiagCode - 1)];
			entity.OriginalDiagCode = (System.String)reader["DIAG_CODE"];
			entity.DiagName = (System.String)reader[((int)DiaglistColumn.DiagName - 1)];
			entity.DiagNameVn = (System.String)reader[((int)DiaglistColumn.DiagNameVn - 1)];
			entity.IsDisabled = (System.Boolean)reader[((int)DiaglistColumn.IsDisabled - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Diaglist"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Diaglist"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.Diaglist entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Category = (System.String)dataRow["CATEGORY"];
			entity.DiagCode = (System.String)dataRow["DIAG_CODE"];
			entity.OriginalDiagCode = (System.String)dataRow["DIAG_CODE"];
			entity.DiagName = (System.String)dataRow["DIAG_NAME"];
			entity.DiagNameVn = (System.String)dataRow["DIAG_NAME_VN"];
			entity.IsDisabled = (System.Boolean)dataRow["IsDisabled"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.Diaglist"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.Diaglist Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.Diaglist entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.Diaglist object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.Diaglist instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.Diaglist Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.Diaglist entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region DiaglistChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.Diaglist</c>
	///</summary>
	public enum DiaglistChildEntityTypes
	{
	}
	
	#endregion DiaglistChildEntityTypes
	
	#region DiaglistFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DiaglistColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistFilterBuilder : SqlFilterBuilder<DiaglistColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistFilterBuilder class.
		/// </summary>
		public DiaglistFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiaglistFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiaglistFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiaglistFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiaglistFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiaglistFilterBuilder
	
	#region DiaglistParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DiaglistColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistParameterBuilder : ParameterizedSqlFilterBuilder<DiaglistColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistParameterBuilder class.
		/// </summary>
		public DiaglistParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiaglistParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiaglistParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiaglistParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiaglistParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiaglistParameterBuilder
	
	#region DiaglistSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DiaglistColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DiaglistSortBuilder : SqlSortBuilder<DiaglistColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistSqlSortBuilder class.
		/// </summary>
		public DiaglistSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DiaglistSortBuilder
	
} // end namespace
