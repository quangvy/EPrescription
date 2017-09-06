#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ePrescription.Entities;
using ePrescription.Data;

#endregion

namespace ePrescription.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VrReceptionProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrReceptionProviderBaseCore : EntityViewProviderBase<VrReception>
	{
		#region Custom Methods
		
		
		#region _VR_Reception_UpdatePatCMS
		
		/// <summary>
		///	This method wrap the '_VR_Reception_UpdatePatCMS' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reason"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdatePatCMS(System.String tid, System.String reason)
		{
			 UpdatePatCMS(null, 0, int.MaxValue , tid, reason);
		}
		
		/// <summary>
		///	This method wrap the '_VR_Reception_UpdatePatCMS' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reason"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdatePatCMS(int start, int pageLength, System.String tid, System.String reason)
		{
			 UpdatePatCMS(null, start, pageLength , tid, reason);
		}
				
		/// <summary>
		///	This method wrap the '_VR_Reception_UpdatePatCMS' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reason"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void UpdatePatCMS(TransactionManager transactionManager, System.String tid, System.String reason)
		{
			 UpdatePatCMS(transactionManager, 0, int.MaxValue , tid, reason);
		}
		
		/// <summary>
		///	This method wrap the '_VR_Reception_UpdatePatCMS' stored procedure. 
		/// </summary>
		/// <param name="tid"> A <c>System.String</c> instance.</param>
		/// <param name="reason"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void UpdatePatCMS(TransactionManager transactionManager, int start, int pageLength, System.String tid, System.String reason);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrReception&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrReception&gt;"/></returns>
		protected static VList&lt;VrReception&gt; Fill(DataSet dataSet, VList<VrReception> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrReception>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrReception&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrReception>"/></returns>
		protected static VList&lt;VrReception&gt; Fill(DataTable dataTable, VList<VrReception> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrReception c = new VrReception();
					c.PatientCode = (Convert.IsDBNull(row["PatientCode"]))?string.Empty:(System.String)row["PatientCode"];
					c.TransactionId = (Convert.IsDBNull(row["TransactionId"]))?string.Empty:(System.String)row["TransactionId"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.DateOfBirth = (Convert.IsDBNull(row["DateOfBirth"]))?DateTime.MinValue:(System.DateTime?)row["DateOfBirth"];
					c.Sex = (Convert.IsDBNull(row["Sex"]))?string.Empty:(System.String)row["Sex"];
					c.PatientStart = (Convert.IsDBNull(row["PatientStart"]))?false:(System.Boolean?)row["PatientStart"];
					c.Nationality = (Convert.IsDBNull(row["Nationality"]))?string.Empty:(System.String)row["Nationality"];
					c.AcceptChanges();
					rows.Add(c);
					pagelen -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		*/	
						
		///<summary>
		/// Fill an <see cref="VList&lt;VrReception&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrReception&gt;"/></returns>
		protected VList<VrReception> Fill(IDataReader reader, VList<VrReception> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrReception entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrReception>("VrReception",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrReception();
					}
					
					entity.SuppressEntityEvents = true;

					entity.PatientCode = (reader.IsDBNull(((int)VrReceptionColumn.PatientCode)))?null:(System.String)reader[((int)VrReceptionColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.TransactionId = (System.String)reader[((int)VrReceptionColumn.TransactionId)];
					//entity.TransactionId = (Convert.IsDBNull(reader["TransactionId"]))?string.Empty:(System.String)reader["TransactionId"];
					entity.FirstName = (reader.IsDBNull(((int)VrReceptionColumn.FirstName)))?null:(System.String)reader[((int)VrReceptionColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (reader.IsDBNull(((int)VrReceptionColumn.LastName)))?null:(System.String)reader[((int)VrReceptionColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.DateOfBirth = (reader.IsDBNull(((int)VrReceptionColumn.DateOfBirth)))?null:(System.DateTime?)reader[((int)VrReceptionColumn.DateOfBirth)];
					//entity.DateOfBirth = (Convert.IsDBNull(reader["DateOfBirth"]))?DateTime.MinValue:(System.DateTime?)reader["DateOfBirth"];
					entity.Sex = (reader.IsDBNull(((int)VrReceptionColumn.Sex)))?null:(System.String)reader[((int)VrReceptionColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.PatientStart = (reader.IsDBNull(((int)VrReceptionColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionColumn.PatientStart)];
					//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
					entity.Nationality = (reader.IsDBNull(((int)VrReceptionColumn.Nationality)))?null:(System.String)reader[((int)VrReceptionColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.AcceptChanges();
					entity.SuppressEntityEvents = false;
					
					rows.Add(entity);
					pageLength -= 1;
				}
				recordnum += 1;
			}
			return rows;
		}
		
		
		/// <summary>
		/// Refreshes the <see cref="VrReception"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReception"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrReception entity)
		{
			reader.Read();
			entity.PatientCode = (reader.IsDBNull(((int)VrReceptionColumn.PatientCode)))?null:(System.String)reader[((int)VrReceptionColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.TransactionId = (System.String)reader[((int)VrReceptionColumn.TransactionId)];
			//entity.TransactionId = (Convert.IsDBNull(reader["TransactionId"]))?string.Empty:(System.String)reader["TransactionId"];
			entity.FirstName = (reader.IsDBNull(((int)VrReceptionColumn.FirstName)))?null:(System.String)reader[((int)VrReceptionColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (reader.IsDBNull(((int)VrReceptionColumn.LastName)))?null:(System.String)reader[((int)VrReceptionColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.DateOfBirth = (reader.IsDBNull(((int)VrReceptionColumn.DateOfBirth)))?null:(System.DateTime?)reader[((int)VrReceptionColumn.DateOfBirth)];
			//entity.DateOfBirth = (Convert.IsDBNull(reader["DateOfBirth"]))?DateTime.MinValue:(System.DateTime?)reader["DateOfBirth"];
			entity.Sex = (reader.IsDBNull(((int)VrReceptionColumn.Sex)))?null:(System.String)reader[((int)VrReceptionColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.PatientStart = (reader.IsDBNull(((int)VrReceptionColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionColumn.PatientStart)];
			//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
			entity.Nationality = (reader.IsDBNull(((int)VrReceptionColumn.Nationality)))?null:(System.String)reader[((int)VrReceptionColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrReception"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReception"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrReception entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PatientCode = (Convert.IsDBNull(dataRow["PatientCode"]))?string.Empty:(System.String)dataRow["PatientCode"];
			entity.TransactionId = (Convert.IsDBNull(dataRow["TransactionId"]))?string.Empty:(System.String)dataRow["TransactionId"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.DateOfBirth = (Convert.IsDBNull(dataRow["DateOfBirth"]))?DateTime.MinValue:(System.DateTime?)dataRow["DateOfBirth"];
			entity.Sex = (Convert.IsDBNull(dataRow["Sex"]))?string.Empty:(System.String)dataRow["Sex"];
			entity.PatientStart = (Convert.IsDBNull(dataRow["PatientStart"]))?false:(System.Boolean?)dataRow["PatientStart"];
			entity.Nationality = (Convert.IsDBNull(dataRow["Nationality"]))?string.Empty:(System.String)dataRow["Nationality"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrReceptionFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionFilterBuilder : SqlFilterBuilder<VrReceptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilterBuilder class.
		/// </summary>
		public VrReceptionFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionFilterBuilder

	#region VrReceptionParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionParameterBuilder : ParameterizedSqlFilterBuilder<VrReceptionColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionParameterBuilder class.
		/// </summary>
		public VrReceptionParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionParameterBuilder
	
	#region VrReceptionSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrReceptionSortBuilder : SqlSortBuilder<VrReceptionColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionSqlSortBuilder class.
		/// </summary>
		public VrReceptionSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrReceptionSortBuilder

} // end namespace
