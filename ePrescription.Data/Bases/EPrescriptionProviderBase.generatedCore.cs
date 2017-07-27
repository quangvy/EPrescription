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
	/// This class is the base class for any <see cref="EPrescriptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EPrescriptionProviderBaseCore : EntityProviderBase<ePrescription.Entities.EPrescription, ePrescription.Entities.EPrescriptionKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionKey key)
		{
			return Delete(transactionManager, key.PrescriptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_prescriptionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _prescriptionId)
		{
			return Delete(null, _prescriptionId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _prescriptionId);		
		
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
		public override ePrescription.Entities.EPrescription Get(TransactionManager transactionManager, ePrescription.Entities.EPrescriptionKey key, int start, int pageLength)
		{
			return GetByPrescriptionId(transactionManager, key.PrescriptionId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_ePrescription index.
		/// </summary>
		/// <param name="_prescriptionId"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public ePrescription.Entities.EPrescription GetByPrescriptionId(System.String _prescriptionId)
		{
			int count = -1;
			return GetByPrescriptionId(null,_prescriptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescription index.
		/// </summary>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public ePrescription.Entities.EPrescription GetByPrescriptionId(System.String _prescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByPrescriptionId(null, _prescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public ePrescription.Entities.EPrescription GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId)
		{
			int count = -1;
			return GetByPrescriptionId(transactionManager, _prescriptionId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public ePrescription.Entities.EPrescription GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId, int start, int pageLength)
		{
			int count = -1;
			return GetByPrescriptionId(transactionManager, _prescriptionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescription index.
		/// </summary>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public ePrescription.Entities.EPrescription GetByPrescriptionId(System.String _prescriptionId, int start, int pageLength, out int count)
		{
			return GetByPrescriptionId(null, _prescriptionId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ePrescription index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_prescriptionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.EPrescription"/> class.</returns>
		public abstract ePrescription.Entities.EPrescription GetByPrescriptionId(TransactionManager transactionManager, System.String _prescriptionId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;EPrescription&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;EPrescription&gt;"/></returns>
		public static TList<EPrescription> Fill(IDataReader reader, TList<EPrescription> rows, int start, int pageLength)
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
				
				ePrescription.Entities.EPrescription c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("EPrescription")
					.Append("|").Append((System.String)reader[((int)EPrescriptionColumn.PrescriptionId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<EPrescription>(
					key.ToString(), // EntityTrackingKey
					"EPrescription",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.EPrescription();
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
					c.PrescriptionId = (System.String)reader[((int)EPrescriptionColumn.PrescriptionId - 1)];
					c.OriginalPrescriptionId = c.PrescriptionId;
					c.TransactionId = (reader.IsDBNull(((int)EPrescriptionColumn.TransactionId - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.TransactionId - 1)];
					c.PatientCode = (System.String)reader[((int)EPrescriptionColumn.PatientCode - 1)];
					c.FirstName = (System.String)reader[((int)EPrescriptionColumn.FirstName - 1)];
					c.LastName = (System.String)reader[((int)EPrescriptionColumn.LastName - 1)];
					c.DeliveryDate = (System.DateTime)reader[((int)EPrescriptionColumn.DeliveryDate - 1)];
					c.CreateDate = (System.DateTime)reader[((int)EPrescriptionColumn.CreateDate - 1)];
					c.Address = (reader.IsDBNull(((int)EPrescriptionColumn.Address - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Address - 1)];
					c.DateOfBirth = (reader.IsDBNull(((int)EPrescriptionColumn.DateOfBirth - 1)))?null:(System.DateTime?)reader[((int)EPrescriptionColumn.DateOfBirth - 1)];
					c.Age = (reader.IsDBNull(((int)EPrescriptionColumn.Age - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Age - 1)];
					c.Weight = (reader.IsDBNull(((int)EPrescriptionColumn.Weight - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Weight - 1)];
					c.Diagnosis = (reader.IsDBNull(((int)EPrescriptionColumn.Diagnosis - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Diagnosis - 1)];
					c.DiagnosisVn = (reader.IsDBNull(((int)EPrescriptionColumn.DiagnosisVn - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.DiagnosisVn - 1)];
					c.PrescribingDoctor = (reader.IsDBNull(((int)EPrescriptionColumn.PrescribingDoctor - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.PrescribingDoctor - 1)];
					c.Sex = (reader.IsDBNull(((int)EPrescriptionColumn.Sex - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Sex - 1)];
					c.Remark = (reader.IsDBNull(((int)EPrescriptionColumn.Remark - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Remark - 1)];
					c.IsComplete = (System.Boolean)reader[((int)EPrescriptionColumn.IsComplete - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.EPrescription"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescription"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.EPrescription entity)
		{
			if (!reader.Read()) return;
			
			entity.PrescriptionId = (System.String)reader[((int)EPrescriptionColumn.PrescriptionId - 1)];
			entity.OriginalPrescriptionId = (System.String)reader["PrescriptionID"];
			entity.TransactionId = (reader.IsDBNull(((int)EPrescriptionColumn.TransactionId - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.TransactionId - 1)];
			entity.PatientCode = (System.String)reader[((int)EPrescriptionColumn.PatientCode - 1)];
			entity.FirstName = (System.String)reader[((int)EPrescriptionColumn.FirstName - 1)];
			entity.LastName = (System.String)reader[((int)EPrescriptionColumn.LastName - 1)];
			entity.DeliveryDate = (System.DateTime)reader[((int)EPrescriptionColumn.DeliveryDate - 1)];
			entity.CreateDate = (System.DateTime)reader[((int)EPrescriptionColumn.CreateDate - 1)];
			entity.Address = (reader.IsDBNull(((int)EPrescriptionColumn.Address - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Address - 1)];
			entity.DateOfBirth = (reader.IsDBNull(((int)EPrescriptionColumn.DateOfBirth - 1)))?null:(System.DateTime?)reader[((int)EPrescriptionColumn.DateOfBirth - 1)];
			entity.Age = (reader.IsDBNull(((int)EPrescriptionColumn.Age - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Age - 1)];
			entity.Weight = (reader.IsDBNull(((int)EPrescriptionColumn.Weight - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Weight - 1)];
			entity.Diagnosis = (reader.IsDBNull(((int)EPrescriptionColumn.Diagnosis - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Diagnosis - 1)];
			entity.DiagnosisVn = (reader.IsDBNull(((int)EPrescriptionColumn.DiagnosisVn - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.DiagnosisVn - 1)];
			entity.PrescribingDoctor = (reader.IsDBNull(((int)EPrescriptionColumn.PrescribingDoctor - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.PrescribingDoctor - 1)];
			entity.Sex = (reader.IsDBNull(((int)EPrescriptionColumn.Sex - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Sex - 1)];
			entity.Remark = (reader.IsDBNull(((int)EPrescriptionColumn.Remark - 1)))?null:(System.String)reader[((int)EPrescriptionColumn.Remark - 1)];
			entity.IsComplete = (System.Boolean)reader[((int)EPrescriptionColumn.IsComplete - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.EPrescription"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescription"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.EPrescription entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PrescriptionId = (System.String)dataRow["PrescriptionID"];
			entity.OriginalPrescriptionId = (System.String)dataRow["PrescriptionID"];
			entity.TransactionId = Convert.IsDBNull(dataRow["TransactionID"]) ? null : (System.String)dataRow["TransactionID"];
			entity.PatientCode = (System.String)dataRow["PatientCode"];
			entity.FirstName = (System.String)dataRow["FirstName"];
			entity.LastName = (System.String)dataRow["LastName"];
			entity.DeliveryDate = (System.DateTime)dataRow["DeliveryDate"];
			entity.CreateDate = (System.DateTime)dataRow["CreateDate"];
			entity.Address = Convert.IsDBNull(dataRow["Address"]) ? null : (System.String)dataRow["Address"];
			entity.DateOfBirth = Convert.IsDBNull(dataRow["DateOfBirth"]) ? null : (System.DateTime?)dataRow["DateOfBirth"];
			entity.Age = Convert.IsDBNull(dataRow["Age"]) ? null : (System.String)dataRow["Age"];
			entity.Weight = Convert.IsDBNull(dataRow["Weight"]) ? null : (System.String)dataRow["Weight"];
			entity.Diagnosis = Convert.IsDBNull(dataRow["Diagnosis"]) ? null : (System.String)dataRow["Diagnosis"];
			entity.DiagnosisVn = Convert.IsDBNull(dataRow["DiagnosisVN"]) ? null : (System.String)dataRow["DiagnosisVN"];
			entity.PrescribingDoctor = Convert.IsDBNull(dataRow["PrescribingDoctor"]) ? null : (System.String)dataRow["PrescribingDoctor"];
			entity.Sex = Convert.IsDBNull(dataRow["Sex"]) ? null : (System.String)dataRow["Sex"];
			entity.Remark = Convert.IsDBNull(dataRow["Remark"]) ? null : (System.String)dataRow["Remark"];
			entity.IsComplete = (System.Boolean)dataRow["IsComplete"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.EPrescription"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.EPrescription Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.EPrescription entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			// Deep load child collections  - Call GetByPrescriptionId methods when available
			
			#region EPrescriptionDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EPrescriptionDetail>|EPrescriptionDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'EPrescriptionDetailCollection' loaded. key " + entity.EntityTrackingKey);
				#endif 

				entity.EPrescriptionDetailCollection = DataRepository.EPrescriptionDetailProvider.GetByPrescriptionId(transactionManager, entity.PrescriptionId);

				if (deep && entity.EPrescriptionDetailCollection.Count > 0)
				{
					deepHandles.Add("EPrescriptionDetailCollection",
						new KeyValuePair<Delegate, object>((DeepLoadHandle<EPrescriptionDetail>) DataRepository.EPrescriptionDetailProvider.DeepLoad,
						new object[] { transactionManager, entity.EPrescriptionDetailCollection, deep, deepLoadType, childTypes, innerList }
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
		/// Deep Save the entire object graph of the ePrescription.Entities.EPrescription object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.EPrescription instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.EPrescription Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.EPrescription entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
			#region List<EPrescriptionDetail>
				if (CanDeepSave(entity.EPrescriptionDetailCollection, "List<EPrescriptionDetail>|EPrescriptionDetailCollection", deepSaveType, innerList)) 
				{	
					// update each child parent id with the real parent id (mostly used on insert)
					foreach(EPrescriptionDetail child in entity.EPrescriptionDetailCollection)
					{
						if(child.PrescriptionIdSource != null)
						{
							child.PrescriptionId = child.PrescriptionIdSource.PrescriptionId;
						}
						else
						{
							child.PrescriptionId = entity.PrescriptionId;
						}

					}

					if (entity.EPrescriptionDetailCollection.Count > 0 || entity.EPrescriptionDetailCollection.DeletedItems.Count > 0)
					{
						//DataRepository.EPrescriptionDetailProvider.Save(transactionManager, entity.EPrescriptionDetailCollection);
						
						deepHandles.Add("EPrescriptionDetailCollection",
						new KeyValuePair<Delegate, object>((DeepSaveHandle< EPrescriptionDetail >) DataRepository.EPrescriptionDetailProvider.DeepSave,
							new object[] { transactionManager, entity.EPrescriptionDetailCollection, deepSaveType, childTypes, innerList }
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
	
	#region EPrescriptionChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.EPrescription</c>
	///</summary>
	public enum EPrescriptionChildEntityTypes
	{

		///<summary>
		/// Collection of <c>EPrescription</c> as OneToMany for EPrescriptionDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<EPrescriptionDetail>))]
		EPrescriptionDetailCollection,
	}
	
	#endregion EPrescriptionChildEntityTypes
	
	#region EPrescriptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EPrescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionFilterBuilder : SqlFilterBuilder<EPrescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilterBuilder class.
		/// </summary>
		public EPrescriptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionFilterBuilder
	
	#region EPrescriptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EPrescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionParameterBuilder : ParameterizedSqlFilterBuilder<EPrescriptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionParameterBuilder class.
		/// </summary>
		public EPrescriptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionParameterBuilder
	
	#region EPrescriptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EPrescriptionColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescription"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class EPrescriptionSortBuilder : SqlSortBuilder<EPrescriptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionSqlSortBuilder class.
		/// </summary>
		public EPrescriptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion EPrescriptionSortBuilder
	
} // end namespace
