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
	/// This class is the base class for any <see cref="UsersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class UsersProviderBaseCore : EntityProviderBase<ePrescription.Entities.Users, ePrescription.Entities.UsersKey>
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
		public override bool Delete(TransactionManager transactionManager, ePrescription.Entities.UsersKey key)
		{
			return Delete(transactionManager, key.UserName);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_userName">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.String _userName)
		{
			return Delete(null, _userName);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.String _userName);		
		
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
		public override ePrescription.Entities.Users Get(TransactionManager transactionManager, ePrescription.Entities.UsersKey key, int start, int pageLength)
		{
			return GetByUserName(transactionManager, key.UserName, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public ePrescription.Entities.Users GetByUserName(System.String _userName)
		{
			int count = -1;
			return GetByUserName(null,_userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public ePrescription.Entities.Users GetByUserName(System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public ePrescription.Entities.Users GetByUserName(TransactionManager transactionManager, System.String _userName)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public ePrescription.Entities.Users GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength)
		{
			int count = -1;
			return GetByUserName(transactionManager, _userName, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public ePrescription.Entities.Users GetByUserName(System.String _userName, int start, int pageLength, out int count)
		{
			return GetByUserName(null, _userName, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Users index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_userName"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.Users"/> class.</returns>
		public abstract ePrescription.Entities.Users GetByUserName(TransactionManager transactionManager, System.String _userName, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;Users&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;Users&gt;"/></returns>
		public static TList<Users> Fill(IDataReader reader, TList<Users> rows, int start, int pageLength)
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
				
				ePrescription.Entities.Users c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("Users")
					.Append("|").Append((System.String)reader[((int)UsersColumn.UserName - 1)]).ToString();
					c = EntityManager.LocateOrCreate<Users>(
					key.ToString(), // EntityTrackingKey
					"Users",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new ePrescription.Entities.Users();
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
					c.UserName = (System.String)reader[((int)UsersColumn.UserName - 1)];
					c.OriginalUserName = c.UserName;
					c.Password = (System.String)reader[((int)UsersColumn.Password - 1)];
					c.UserRole = (System.String)reader[((int)UsersColumn.UserRole - 1)];
					c.FullName = (System.String)reader[((int)UsersColumn.FullName - 1)];
					c.Email = (System.String)reader[((int)UsersColumn.Email - 1)];
					c.DisplayName = (System.String)reader[((int)UsersColumn.DisplayName - 1)];
					c.Signature = (reader.IsDBNull(((int)UsersColumn.Signature - 1)))?null:(System.String)reader[((int)UsersColumn.Signature - 1)];
					c.Location = (reader.IsDBNull(((int)UsersColumn.Location - 1)))?null:(System.String)reader[((int)UsersColumn.Location - 1)];
					c.IsDisabled = (System.Boolean)reader[((int)UsersColumn.IsDisabled - 1)];
					c.Avatar = (reader.IsDBNull(((int)UsersColumn.Avatar - 1)))?null:(System.String)reader[((int)UsersColumn.Avatar - 1)];
					c.MobilePhone = (reader.IsDBNull(((int)UsersColumn.MobilePhone - 1)))?null:(System.String)reader[((int)UsersColumn.MobilePhone - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Users"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Users"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, ePrescription.Entities.Users entity)
		{
			if (!reader.Read()) return;
			
			entity.UserName = (System.String)reader[((int)UsersColumn.UserName - 1)];
			entity.OriginalUserName = (System.String)reader["UserName"];
			entity.Password = (System.String)reader[((int)UsersColumn.Password - 1)];
			entity.UserRole = (System.String)reader[((int)UsersColumn.UserRole - 1)];
			entity.FullName = (System.String)reader[((int)UsersColumn.FullName - 1)];
			entity.Email = (System.String)reader[((int)UsersColumn.Email - 1)];
			entity.DisplayName = (System.String)reader[((int)UsersColumn.DisplayName - 1)];
			entity.Signature = (reader.IsDBNull(((int)UsersColumn.Signature - 1)))?null:(System.String)reader[((int)UsersColumn.Signature - 1)];
			entity.Location = (reader.IsDBNull(((int)UsersColumn.Location - 1)))?null:(System.String)reader[((int)UsersColumn.Location - 1)];
			entity.IsDisabled = (System.Boolean)reader[((int)UsersColumn.IsDisabled - 1)];
			entity.Avatar = (reader.IsDBNull(((int)UsersColumn.Avatar - 1)))?null:(System.String)reader[((int)UsersColumn.Avatar - 1)];
			entity.MobilePhone = (reader.IsDBNull(((int)UsersColumn.MobilePhone - 1)))?null:(System.String)reader[((int)UsersColumn.MobilePhone - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="ePrescription.Entities.Users"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="ePrescription.Entities.Users"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, ePrescription.Entities.Users entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.UserName = (System.String)dataRow["UserName"];
			entity.OriginalUserName = (System.String)dataRow["UserName"];
			entity.Password = (System.String)dataRow["Password"];
			entity.UserRole = (System.String)dataRow["UserRole"];
			entity.FullName = (System.String)dataRow["FullName"];
			entity.Email = (System.String)dataRow["Email"];
			entity.DisplayName = (System.String)dataRow["DisplayName"];
			entity.Signature = Convert.IsDBNull(dataRow["Signature"]) ? null : (System.String)dataRow["Signature"];
			entity.Location = Convert.IsDBNull(dataRow["Location"]) ? null : (System.String)dataRow["Location"];
			entity.IsDisabled = (System.Boolean)dataRow["IsDisabled"];
			entity.Avatar = Convert.IsDBNull(dataRow["Avatar"]) ? null : (System.String)dataRow["Avatar"];
			entity.MobilePhone = Convert.IsDBNull(dataRow["MobilePhone"]) ? null : (System.String)dataRow["MobilePhone"];
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
		/// <param name="entity">The <see cref="ePrescription.Entities.Users"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">ePrescription.Entities.Users Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, ePrescription.Entities.Users entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
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
		/// Deep Save the entire object graph of the ePrescription.Entities.Users object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">ePrescription.Entities.Users instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">ePrescription.Entities.Users Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, ePrescription.Entities.Users entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
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
	
	#region UsersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>ePrescription.Entities.Users</c>
	///</summary>
	public enum UsersChildEntityTypes
	{
	}
	
	#endregion UsersChildEntityTypes
	
	#region UsersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersFilterBuilder : SqlFilterBuilder<UsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		public UsersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersFilterBuilder
	
	#region UsersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersParameterBuilder : ParameterizedSqlFilterBuilder<UsersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		public UsersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersParameterBuilder
	
	#region UsersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;UsersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class UsersSortBuilder : SqlSortBuilder<UsersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersSqlSortBuilder class.
		/// </summary>
		public UsersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion UsersSortBuilder
	
} // end namespace
