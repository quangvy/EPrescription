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
	/// This class is the base class for any <see cref="FavoritMasterProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FavoritMasterProviderBaseCore : EntityProviderBase<ePrescription.Entities.FavoritMaster, ePrescription.Entities.FavoritMasterKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.FavoritMasterKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
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
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
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
		public override ePrescription.Entities.FavoritMaster Get(TransactionManager transactionManager, ePrescription.Entities.FavoritMasterKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_FavoritMaster index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public ePrescription.Entities.FavoritMaster GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritMaster index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public ePrescription.Entities.FavoritMaster GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritMaster index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public ePrescription.Entities.FavoritMaster GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritMaster index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public ePrescription.Entities.FavoritMaster GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritMaster index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public ePrescription.Entities.FavoritMaster GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_FavoritMaster index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.FavoritMaster"/> class.</returns>
		public abstract ePrescription.Entities.FavoritMaster GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;FavoritMaster&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;FavoritMaster&gt;"/></returns>
		public static TList<FavoritMaster> Fill(IDataReader reader, TList<FavoritMaster> rows, int start, int pageLength)
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
				
				ePrescription.Entities.FavoritMaster c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("FavoritMaster")
					.Append("|").Append((System.Int32)reader[((int)FavoritMasterColumn.Id - 1)]).ToString();
					c = EntityManager.LocateOrCreate<FavoritMaster>(
					key.ToString(), // EntityTrackingKey
					"FavoritMaster",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.FavoritMaster();
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
					c.Id = (System.Int32)reader[((int)FavoritMasterColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.DiceaseName = (System.String)reader[((int)FavoritMasterColumn.DiceaseName - 1)];
					c.CreateBy = (reader.IsDBNull(((int)FavoritMasterColumn.CreateBy - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.CreateBy - 1)];
					c.Diagnosis = (reader.IsDBNull(((int)FavoritMasterColumn.Diagnosis - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.Diagnosis - 1)];
					c.DiagnosisVn = (reader.IsDBNull(((int)FavoritMasterColumn.DiagnosisVn - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.DiagnosisVn - 1)];
					c.IsPrivate = (reader.IsDBNull(((int)FavoritMasterColumn.IsPrivate - 1)))?null:(System.Boolean?)reader[((int)FavoritMasterColumn.IsPrivate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.FavoritMaster"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritMaster"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.FavoritMaster entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)FavoritMasterColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.DiceaseName = (System.String)reader[((int)FavoritMasterColumn.DiceaseName - 1)];
			entity.CreateBy = (reader.IsDBNull(((int)FavoritMasterColumn.CreateBy - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.CreateBy - 1)];
			entity.Diagnosis = (reader.IsDBNull(((int)FavoritMasterColumn.Diagnosis - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.Diagnosis - 1)];
			entity.DiagnosisVn = (reader.IsDBNull(((int)FavoritMasterColumn.DiagnosisVn - 1)))?null:(System.String)reader[((int)FavoritMasterColumn.DiagnosisVn - 1)];
			entity.IsPrivate = (reader.IsDBNull(((int)FavoritMasterColumn.IsPrivate - 1)))?null:(System.Boolean?)reader[((int)FavoritMasterColumn.IsPrivate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.FavoritMaster"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritMaster"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.FavoritMaster entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.DiceaseName = (System.String)dataRow["DiceaseName"];
			entity.CreateBy = Convert.IsDBNull(dataRow["CreateBy"]) ? null : (System.String)dataRow["CreateBy"];
			entity.Diagnosis = Convert.IsDBNull(dataRow["Diagnosis"]) ? null : (System.String)dataRow["Diagnosis"];
			entity.DiagnosisVn = Convert.IsDBNull(dataRow["DiagnosisVN"]) ? null : (System.String)dataRow["DiagnosisVN"];
			entity.IsPrivate = Convert.IsDBNull(dataRow["IsPrivate"]) ? null : (System.Boolean?)dataRow["IsPrivate"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.FavoritMaster"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.FavoritMaster Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.FavoritMaster entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.FavoritMaster object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.FavoritMaster instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.FavoritMaster Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.FavoritMaster entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region FavoritMasterChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.FavoritMaster</c>
	///</summary>
	public enum FavoritMasterChildEntityTypes
	{
	}
	
	#endregion FavoritMasterChildEntityTypes
	
	#region FavoritMasterFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FavoritMasterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterFilterBuilder : SqlFilterBuilder<FavoritMasterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilterBuilder class.
		/// </summary>
		public FavoritMasterFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritMasterFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritMasterFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritMasterFilterBuilder
	
	#region FavoritMasterParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FavoritMasterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterParameterBuilder : ParameterizedSqlFilterBuilder<FavoritMasterColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterParameterBuilder class.
		/// </summary>
		public FavoritMasterParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritMasterParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritMasterParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritMasterParameterBuilder
	
	#region FavoritMasterSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FavoritMasterColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FavoritMasterSortBuilder : SqlSortBuilder<FavoritMasterColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterSqlSortBuilder class.
		/// </summary>
		public FavoritMasterSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FavoritMasterSortBuilder
	
} // end namespace
