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
	/// This class is the base class for any <see cref="FrequencyProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class FrequencyProviderBaseCore : EntityProviderBase<ePrescription.Entities.Frequency, ePrescription.Entities.FrequencyKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.FrequencyKey key)
		{
			return Delete(transactionManager, key.FrequencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_frequencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int64 _frequencyId)
		{
			return Delete(null, _frequencyId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_frequencyId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int64 _frequencyId);		
		
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
		public override ePrescription.Entities.Frequency Get(TransactionManager transactionManager, ePrescription.Entities.FrequencyKey key, int start, int pageLength)
		{
			return GetByFrequencyId(transactionManager, key.FrequencyId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Frequency index.
		/// </summary>
		/// <param name="_frequencyId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public ePrescription.Entities.Frequency GetByFrequencyId(System.Int64 _frequencyId)
		{
			int count = -1;
			return GetByFrequencyId(null,_frequencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Frequency index.
		/// </summary>
		/// <param name="_frequencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public ePrescription.Entities.Frequency GetByFrequencyId(System.Int64 _frequencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByFrequencyId(null, _frequencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Frequency index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_frequencyId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public ePrescription.Entities.Frequency GetByFrequencyId(TransactionManager transactionManager, System.Int64 _frequencyId)
		{
			int count = -1;
			return GetByFrequencyId(transactionManager, _frequencyId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Frequency index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_frequencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public ePrescription.Entities.Frequency GetByFrequencyId(TransactionManager transactionManager, System.Int64 _frequencyId, int start, int pageLength)
		{
			int count = -1;
			return GetByFrequencyId(transactionManager, _frequencyId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Frequency index.
		/// </summary>
		/// <param name="_frequencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public ePrescription.Entities.Frequency GetByFrequencyId(System.Int64 _frequencyId, int start, int pageLength, out int count)
		{
			return GetByFrequencyId(null, _frequencyId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Frequency index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_frequencyId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Frequency"/> class.</returns>
		public abstract ePrescription.Entities.Frequency GetByFrequencyId(TransactionManager transactionManager, System.Int64 _frequencyId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Frequency&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Frequency&gt;"/></returns>
		public static TList<Frequency> Fill(IDataReader reader, TList<Frequency> rows, int start, int pageLength)
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
				
				ePrescription.Entities.Frequency c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Frequency")
					.Append("|").Append((System.Int64)reader[((int)FrequencyColumn.FrequencyId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Frequency>(
					key.ToString(), // EntityTrackingKey
					"Frequency",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.Frequency();
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
					c.FrequencyId = (System.Int64)reader[((int)FrequencyColumn.FrequencyId - 1)];
					c.Abbre = (reader.IsDBNull(((int)FrequencyColumn.Abbre - 1)))?null:(System.String)reader[((int)FrequencyColumn.Abbre - 1)];
					c.Meaning = (reader.IsDBNull(((int)FrequencyColumn.Meaning - 1)))?null:(System.String)reader[((int)FrequencyColumn.Meaning - 1)];
					c.VnMeaning = (reader.IsDBNull(((int)FrequencyColumn.VnMeaning - 1)))?null:(System.String)reader[((int)FrequencyColumn.VnMeaning - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Frequency"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Frequency"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.Frequency entity)
		{
			if (!reader.Read()) return;
			
			entity.FrequencyId = (System.Int64)reader[((int)FrequencyColumn.FrequencyId - 1)];
			entity.Abbre = (reader.IsDBNull(((int)FrequencyColumn.Abbre - 1)))?null:(System.String)reader[((int)FrequencyColumn.Abbre - 1)];
			entity.Meaning = (reader.IsDBNull(((int)FrequencyColumn.Meaning - 1)))?null:(System.String)reader[((int)FrequencyColumn.Meaning - 1)];
			entity.VnMeaning = (reader.IsDBNull(((int)FrequencyColumn.VnMeaning - 1)))?null:(System.String)reader[((int)FrequencyColumn.VnMeaning - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Frequency"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Frequency"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.Frequency entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.FrequencyId = (System.Int64)dataRow["FrequencyId"];
			entity.Abbre = Convert.IsDBNull(dataRow["abbre"]) ? null : (System.String)dataRow["abbre"];
			entity.Meaning = Convert.IsDBNull(dataRow["meaning"]) ? null : (System.String)dataRow["meaning"];
			entity.VnMeaning = Convert.IsDBNull(dataRow["VN_meaning"]) ? null : (System.String)dataRow["VN_meaning"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.Frequency"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.Frequency Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.Frequency entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.Frequency object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.Frequency instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.Frequency Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.Frequency entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region FrequencyChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.Frequency</c>
	///</summary>
	public enum FrequencyChildEntityTypes
	{
	}
	
	#endregion FrequencyChildEntityTypes
	
	#region FrequencyFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;FrequencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyFilterBuilder : SqlFilterBuilder<FrequencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyFilterBuilder class.
		/// </summary>
		public FrequencyFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FrequencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FrequencyFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FrequencyFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FrequencyFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FrequencyFilterBuilder
	
	#region FrequencyParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;FrequencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyParameterBuilder : ParameterizedSqlFilterBuilder<FrequencyColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyParameterBuilder class.
		/// </summary>
		public FrequencyParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the FrequencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FrequencyParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FrequencyParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FrequencyParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FrequencyParameterBuilder
	
	#region FrequencySortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;FrequencyColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class FrequencySortBuilder : SqlSortBuilder<FrequencyColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencySqlSortBuilder class.
		/// </summary>
		public FrequencySortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion FrequencySortBuilder
	
} // end namespace
