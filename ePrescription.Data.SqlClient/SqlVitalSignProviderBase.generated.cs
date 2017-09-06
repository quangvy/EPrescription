﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file SqlVitalSignProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using ePrescription.Entities;
using ePrescription.Data;
using ePrescription.Data.Bases;

#endregion

namespace ePrescription.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="VitalSign"/> entity.
	///</summary>
	public abstract partial class SqlVitalSignProviderBase : VitalSignProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlVitalSignProviderBase"/> instance.
		/// </summary>
		public SqlVitalSignProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlVitalSignProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we should use stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlVitalSignProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
		#endregion
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_vid">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Int64 _vid)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@Vid", DbType.Int64, _vid);
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Delete")); 

			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(VitalSign)
					,_vid);
                EntityManager.StopTracking(entityKey);
                
			}
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Delete")); 

			commandWrapper = null;
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions

		#region Parsed Find Methods
		/// <summary>
		/// 	Returns rows meeting the whereClause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND).</remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.VitalSign objects.</returns>
		public override TList<VitalSign> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new TList<VitalSign>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf(" OR ") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@Vid", DbType.Int64, DBNull.Value);
		database.AddInParameter(commandWrapper, "@PatientCode", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Tid", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Tempurature", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Pulse", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Respiratory", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@BloodPressure", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Sato2", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Gcs", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Height", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Weight", DbType.String, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@UpdateUser", DbType.String, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace(" AND ", "|").Replace(" OR ", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("vid ") || clause.Trim().StartsWith("vid="))
				{
					database.SetParameterValue(commandWrapper, "@Vid", 
						clause.Trim().Remove(0,3).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("patientcode ") || clause.Trim().StartsWith("patientcode="))
				{
					database.SetParameterValue(commandWrapper, "@PatientCode", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("tid ") || clause.Trim().StartsWith("tid="))
				{
					database.SetParameterValue(commandWrapper, "@Tid", 
						clause.Trim().Remove(0,3).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("tempurature ") || clause.Trim().StartsWith("tempurature="))
				{
					database.SetParameterValue(commandWrapper, "@Tempurature", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("pulse ") || clause.Trim().StartsWith("pulse="))
				{
					database.SetParameterValue(commandWrapper, "@Pulse", 
						clause.Trim().Remove(0,5).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("respiratory ") || clause.Trim().StartsWith("respiratory="))
				{
					database.SetParameterValue(commandWrapper, "@Respiratory", 
						clause.Trim().Remove(0,11).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("bloodpressure ") || clause.Trim().StartsWith("bloodpressure="))
				{
					database.SetParameterValue(commandWrapper, "@BloodPressure", 
						clause.Trim().Remove(0,13).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("sato2 ") || clause.Trim().StartsWith("sato2="))
				{
					database.SetParameterValue(commandWrapper, "@Sato2", 
						clause.Trim().Remove(0,5).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("gcs ") || clause.Trim().StartsWith("gcs="))
				{
					database.SetParameterValue(commandWrapper, "@Gcs", 
						clause.Trim().Remove(0,3).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("height ") || clause.Trim().StartsWith("height="))
				{
					database.SetParameterValue(commandWrapper, "@Height", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("weight ") || clause.Trim().StartsWith("weight="))
				{
					database.SetParameterValue(commandWrapper, "@Weight", 
						clause.Trim().Remove(0,6).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("createdate ") || clause.Trim().StartsWith("createdate="))
				{
					database.SetParameterValue(commandWrapper, "@CreateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updatedate ") || clause.Trim().StartsWith("updatedate="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateDate", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("updateuser ") || clause.Trim().StartsWith("updateuser="))
				{
					database.SetParameterValue(commandWrapper, "@UpdateUser", 
						clause.Trim().Remove(0,10).Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			TList<VitalSign> rows = new TList<VitalSign>();
	
				
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if (reader != null) 
					reader.Close();	
					
				commandWrapper = null;
			}
			return rows;
		}

		#endregion Parsed Find Methods
		
		#region Parameterized Find Methods
		
		/// <summary>
		/// 	Returns rows from the DataSource that meet the parameter conditions.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="parameters">A collection of <see cref="SqlFilterParameter"/> objects.</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <returns>Returns a typed collection of ePrescription.Entities.VitalSign objects.</returns>
		public override TList<VitalSign> Find(TransactionManager transactionManager, IFilterParameterCollection parameters, string orderBy, int start, int pageLength, out int count)
		{
			SqlFilterParameterCollection filter = null;
			
			if (parameters == null)
				filter = new SqlFilterParameterCollection();
			else 
				filter = parameters.GetParameters();
				
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Find_Dynamic", typeof(VitalSignColumn), filter, orderBy, start, pageLength);
		
			SqlFilterParameter param;

			for ( int i = 0; i < filter.Count; i++ )
			{
				param = filter[i];
				database.AddInParameter(commandWrapper, param.Name, param.DbType, param.GetValue());
			}

			TList<VitalSign> rows = new TList<VitalSign>();
			IDataReader reader = null;
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "Find", rows)); 

				if ( transactionManager != null )
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;
				
				if ( reader.NextResult() )
				{
					if ( reader.Read() )
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "Find", rows)); 
			}
			finally
			{
				if ( reader != null )
					reader.Close();
					
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion Parameterized Find Methods
		
		#endregion Find Functions
	
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.VitalSign objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override TList<VitalSign> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			TList<VitalSign> rows = new TList<VitalSign>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
					
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetAll", rows)); 
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;	
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region GetPaged Methods
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ePrescription.Entities.VitalSign objects.</returns>
		public override TList<VitalSign> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_GetPaged", _useStoredProcedure);
		
			
            if (commandWrapper.CommandType == CommandType.Text
                && commandWrapper.CommandText != null)
            {
                commandWrapper.CommandText = commandWrapper.CommandText.Replace(SqlUtil.PAGE_INDEX, string.Concat(SqlUtil.PAGE_INDEX, Guid.NewGuid().ToString("N").Substring(0, 8)));
            }
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			TList<VitalSign> rows = new TList<VitalSign>();
			
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetPaged", rows)); 

			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
				
				commandWrapper = null;
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions
	#endregion
	
		#region Get By Index Functions

		#region GetByVid
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Vsign index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_vid"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query.</param>
		/// <returns>Returns an instance of the <see cref="ePrescription.Entities.VitalSign"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override ePrescription.Entities.VitalSign GetByVid(TransactionManager transactionManager, System.Int64 _vid, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_GetByVid", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@Vid", DbType.Int64, _vid);
			
			IDataReader reader = null;
			TList<VitalSign> tmp = new TList<VitalSign>();
			try
			{
				//Provider Data Requesting Command Event
				OnDataRequesting(new CommandEventArgs(commandWrapper, "GetByVid", tmp)); 

				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
				
				//Provider Data Requested Command Event
				OnDataRequested(new CommandEventArgs(commandWrapper, "GetByVid", tmp));
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
					
				commandWrapper = null;
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Methods
		/// <summary>
		/// Lets you efficiently bulk insert many entities to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the ePrescription.Entities.VitalSign object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<ePrescription.Entities.VitalSign> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "VitalSign";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("VId", typeof(System.Int64));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("PatientCode", typeof(System.String));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("TID", typeof(System.String));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("Tempurature", typeof(System.String));
			col3.AllowDBNull = true;		
			DataColumn col4 = dataTable.Columns.Add("Pulse", typeof(System.String));
			col4.AllowDBNull = true;		
			DataColumn col5 = dataTable.Columns.Add("Respiratory", typeof(System.String));
			col5.AllowDBNull = true;		
			DataColumn col6 = dataTable.Columns.Add("BloodPressure", typeof(System.String));
			col6.AllowDBNull = true;		
			DataColumn col7 = dataTable.Columns.Add("SatO2", typeof(System.String));
			col7.AllowDBNull = true;		
			DataColumn col8 = dataTable.Columns.Add("GCS", typeof(System.String));
			col8.AllowDBNull = true;		
			DataColumn col9 = dataTable.Columns.Add("Height", typeof(System.String));
			col9.AllowDBNull = true;		
			DataColumn col10 = dataTable.Columns.Add("Weight", typeof(System.String));
			col10.AllowDBNull = true;		
			DataColumn col11 = dataTable.Columns.Add("CreateDate", typeof(System.DateTime));
			col11.AllowDBNull = true;		
			DataColumn col12 = dataTable.Columns.Add("UpdateDate", typeof(System.DateTime));
			col12.AllowDBNull = true;		
			DataColumn col13 = dataTable.Columns.Add("UpdateUser", typeof(System.String));
			col13.AllowDBNull = true;		
			
			bulkCopy.ColumnMappings.Add("VId", "VId");
			bulkCopy.ColumnMappings.Add("PatientCode", "PatientCode");
			bulkCopy.ColumnMappings.Add("TID", "TID");
			bulkCopy.ColumnMappings.Add("Tempurature", "Tempurature");
			bulkCopy.ColumnMappings.Add("Pulse", "Pulse");
			bulkCopy.ColumnMappings.Add("Respiratory", "Respiratory");
			bulkCopy.ColumnMappings.Add("BloodPressure", "BloodPressure");
			bulkCopy.ColumnMappings.Add("SatO2", "SatO2");
			bulkCopy.ColumnMappings.Add("GCS", "GCS");
			bulkCopy.ColumnMappings.Add("Height", "Height");
			bulkCopy.ColumnMappings.Add("Weight", "Weight");
			bulkCopy.ColumnMappings.Add("CreateDate", "CreateDate");
			bulkCopy.ColumnMappings.Add("UpdateDate", "UpdateDate");
			bulkCopy.ColumnMappings.Add("UpdateUser", "UpdateUser");
			
			foreach(ePrescription.Entities.VitalSign entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["VId"] = entity.Vid;
							
				
					row["PatientCode"] = entity.PatientCode;
							
				
					row["TID"] = entity.Tid;
							
				
					row["Tempurature"] = entity.Tempurature;
							
				
					row["Pulse"] = entity.Pulse;
							
				
					row["Respiratory"] = entity.Respiratory;
							
				
					row["BloodPressure"] = entity.BloodPressure;
							
				
					row["SatO2"] = entity.Sato2;
							
				
					row["GCS"] = entity.Gcs;
							
				
					row["Height"] = entity.Height;
							
				
					row["Weight"] = entity.Weight;
							
				
					row["CreateDate"] = entity.CreateDate.HasValue ? (object) entity.CreateDate  : System.DBNull.Value;
							
				
					row["UpdateDate"] = entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value;
							
				
					row["UpdateUser"] = entity.UpdateUser;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(ePrescription.Entities.VitalSign entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a ePrescription.Entities.VitalSign object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ePrescription.Entities.VitalSign object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the ePrescription.Entities.VitalSign object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, ePrescription.Entities.VitalSign entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Insert", _useStoredProcedure);
			
			database.AddOutParameter(commandWrapper, "@Vid", DbType.Int64, 8);
            database.AddInParameter(commandWrapper, "@PatientCode", DbType.String, entity.PatientCode );
            database.AddInParameter(commandWrapper, "@Tid", DbType.String, entity.Tid );
            database.AddInParameter(commandWrapper, "@Tempurature", DbType.String, entity.Tempurature );
            database.AddInParameter(commandWrapper, "@Pulse", DbType.String, entity.Pulse );
            database.AddInParameter(commandWrapper, "@Respiratory", DbType.String, entity.Respiratory );
            database.AddInParameter(commandWrapper, "@BloodPressure", DbType.String, entity.BloodPressure );
            database.AddInParameter(commandWrapper, "@Sato2", DbType.String, entity.Sato2 );
            database.AddInParameter(commandWrapper, "@Gcs", DbType.String, entity.Gcs );
            database.AddInParameter(commandWrapper, "@Height", DbType.String, entity.Height );
            database.AddInParameter(commandWrapper, "@Weight", DbType.String, entity.Weight );
			database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, (entity.CreateDate.HasValue ? (object) entity.CreateDate  : System.DBNull.Value));
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate  : System.DBNull.Value));
            database.AddInParameter(commandWrapper, "@UpdateUser", DbType.String, entity.UpdateUser );
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Insert", entity));
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					
			object _vid = database.GetParameterValue(commandWrapper, "@Vid");
			entity.Vid = (System.Int64)_vid;
			
			
			entity.AcceptChanges();
	
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Insert", entity));

			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Methods
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">ePrescription.Entities.VitalSign object to update.</param>
		/// <remarks>
		///		After updating the datasource, the ePrescription.Entities.VitalSign object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, ePrescription.Entities.VitalSign entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.VitalSign_Update", _useStoredProcedure);
			
            database.AddInParameter(commandWrapper, "@Vid", DbType.Int64, entity.Vid );
            database.AddInParameter(commandWrapper, "@PatientCode", DbType.String, entity.PatientCode );
            database.AddInParameter(commandWrapper, "@Tid", DbType.String, entity.Tid );
            database.AddInParameter(commandWrapper, "@Tempurature", DbType.String, entity.Tempurature );
            database.AddInParameter(commandWrapper, "@Pulse", DbType.String, entity.Pulse );
            database.AddInParameter(commandWrapper, "@Respiratory", DbType.String, entity.Respiratory );
            database.AddInParameter(commandWrapper, "@BloodPressure", DbType.String, entity.BloodPressure );
            database.AddInParameter(commandWrapper, "@Sato2", DbType.String, entity.Sato2 );
            database.AddInParameter(commandWrapper, "@Gcs", DbType.String, entity.Gcs );
            database.AddInParameter(commandWrapper, "@Height", DbType.String, entity.Height );
            database.AddInParameter(commandWrapper, "@Weight", DbType.String, entity.Weight );
			database.AddInParameter(commandWrapper, "@CreateDate", DbType.DateTime, (entity.CreateDate.HasValue ? (object) entity.CreateDate : System.DBNull.Value) );
			database.AddInParameter(commandWrapper, "@UpdateDate", DbType.DateTime, (entity.UpdateDate.HasValue ? (object) entity.UpdateDate : System.DBNull.Value) );
            database.AddInParameter(commandWrapper, "@UpdateUser", DbType.String, entity.UpdateUser );
			
			int results = 0;
			
			//Provider Data Requesting Command Event
			OnDataRequesting(new CommandEventArgs(commandWrapper, "Update", entity));

			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
            {
                EntityManager.StopTracking(entity.EntityTrackingKey);				
            }
			
			
			entity.AcceptChanges();
			
			//Provider Data Requested Command Event
			OnDataRequested(new CommandEventArgs(commandWrapper, "Update", entity));

			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#endregion
	}//end class
} // end namespace
