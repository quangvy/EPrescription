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
	/// This class is the base class for any <see cref="VrReceptionStartProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrReceptionStartProviderBaseCore : EntityViewProviderBase<VrReceptionStart>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrReceptionStart&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrReceptionStart&gt;"/></returns>
		protected static VList&lt;VrReceptionStart&gt; Fill(DataSet dataSet, VList<VrReceptionStart> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrReceptionStart>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrReceptionStart&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrReceptionStart>"/></returns>
		protected static VList&lt;VrReceptionStart&gt; Fill(DataTable dataTable, VList<VrReceptionStart> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrReceptionStart c = new VrReceptionStart();
					c.StatId = (Convert.IsDBNull(row["StatId"]))?(long)0:(System.Int64)row["StatId"];
					c.PatientCode = (Convert.IsDBNull(row["PatientCode"]))?string.Empty:(System.String)row["PatientCode"];
					c.Tid = (Convert.IsDBNull(row["TID"]))?string.Empty:(System.String)row["TID"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Dob = (Convert.IsDBNull(row["DOB"]))?DateTime.MinValue:(System.DateTime)row["DOB"];
					c.Sex = (Convert.IsDBNull(row["Sex"]))?string.Empty:(System.String)row["Sex"];
					c.Nationality = (Convert.IsDBNull(row["Nationality"]))?string.Empty:(System.String)row["Nationality"];
					c.PatientStart = (Convert.IsDBNull(row["PatientStart"]))?false:(System.Boolean?)row["PatientStart"];
					c.IsCompleted = (Convert.IsDBNull(row["IsCompleted"]))?false:(System.Boolean?)row["IsCompleted"];
					c.ChargedCodes = (Convert.IsDBNull(row["ChargedCodes"]))?string.Empty:(System.String)row["ChargedCodes"];
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
		/// Fill an <see cref="VList&lt;VrReceptionStart&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrReceptionStart&gt;"/></returns>
		protected VList<VrReceptionStart> Fill(IDataReader reader, VList<VrReceptionStart> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrReceptionStart entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrReceptionStart>("VrReceptionStart",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrReceptionStart();
					}
					
					entity.SuppressEntityEvents = true;

					entity.StatId = (System.Int64)reader[((int)VrReceptionStartColumn.StatId)];
					//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
					entity.PatientCode = (System.String)reader[((int)VrReceptionStartColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.Tid = (System.String)reader[((int)VrReceptionStartColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.FirstName = (System.String)reader[((int)VrReceptionStartColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (System.String)reader[((int)VrReceptionStartColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Dob = (System.DateTime)reader[((int)VrReceptionStartColumn.Dob)];
					//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
					entity.Sex = (System.String)reader[((int)VrReceptionStartColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.Nationality = (System.String)reader[((int)VrReceptionStartColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.PatientStart = (reader.IsDBNull(((int)VrReceptionStartColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionStartColumn.PatientStart)];
					//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
					entity.IsCompleted = (reader.IsDBNull(((int)VrReceptionStartColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrReceptionStartColumn.IsCompleted)];
					//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
					entity.ChargedCodes = (reader.IsDBNull(((int)VrReceptionStartColumn.ChargedCodes)))?null:(System.String)reader[((int)VrReceptionStartColumn.ChargedCodes)];
					//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
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
		/// Refreshes the <see cref="VrReceptionStart"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReceptionStart"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrReceptionStart entity)
		{
			reader.Read();
			entity.StatId = (System.Int64)reader[((int)VrReceptionStartColumn.StatId)];
			//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
			entity.PatientCode = (System.String)reader[((int)VrReceptionStartColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.Tid = (System.String)reader[((int)VrReceptionStartColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.FirstName = (System.String)reader[((int)VrReceptionStartColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader[((int)VrReceptionStartColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Dob = (System.DateTime)reader[((int)VrReceptionStartColumn.Dob)];
			//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
			entity.Sex = (System.String)reader[((int)VrReceptionStartColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.Nationality = (System.String)reader[((int)VrReceptionStartColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			entity.PatientStart = (reader.IsDBNull(((int)VrReceptionStartColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionStartColumn.PatientStart)];
			//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
			entity.IsCompleted = (reader.IsDBNull(((int)VrReceptionStartColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrReceptionStartColumn.IsCompleted)];
			//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
			entity.ChargedCodes = (reader.IsDBNull(((int)VrReceptionStartColumn.ChargedCodes)))?null:(System.String)reader[((int)VrReceptionStartColumn.ChargedCodes)];
			//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrReceptionStart"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReceptionStart"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrReceptionStart entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.StatId = (Convert.IsDBNull(dataRow["StatId"]))?(long)0:(System.Int64)dataRow["StatId"];
			entity.PatientCode = (Convert.IsDBNull(dataRow["PatientCode"]))?string.Empty:(System.String)dataRow["PatientCode"];
			entity.Tid = (Convert.IsDBNull(dataRow["TID"]))?string.Empty:(System.String)dataRow["TID"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Dob = (Convert.IsDBNull(dataRow["DOB"]))?DateTime.MinValue:(System.DateTime)dataRow["DOB"];
			entity.Sex = (Convert.IsDBNull(dataRow["Sex"]))?string.Empty:(System.String)dataRow["Sex"];
			entity.Nationality = (Convert.IsDBNull(dataRow["Nationality"]))?string.Empty:(System.String)dataRow["Nationality"];
			entity.PatientStart = (Convert.IsDBNull(dataRow["PatientStart"]))?false:(System.Boolean?)dataRow["PatientStart"];
			entity.IsCompleted = (Convert.IsDBNull(dataRow["IsCompleted"]))?false:(System.Boolean?)dataRow["IsCompleted"];
			entity.ChargedCodes = (Convert.IsDBNull(dataRow["ChargedCodes"]))?string.Empty:(System.String)dataRow["ChargedCodes"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrReceptionStartFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartFilterBuilder : SqlFilterBuilder<VrReceptionStartColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilterBuilder class.
		/// </summary>
		public VrReceptionStartFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionStartFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionStartFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionStartFilterBuilder

	#region VrReceptionStartParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartParameterBuilder : ParameterizedSqlFilterBuilder<VrReceptionStartColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartParameterBuilder class.
		/// </summary>
		public VrReceptionStartParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionStartParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionStartParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionStartParameterBuilder
	
	#region VrReceptionStartSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrReceptionStartSortBuilder : SqlSortBuilder<VrReceptionStartColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartSqlSortBuilder class.
		/// </summary>
		public VrReceptionStartSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrReceptionStartSortBuilder

} // end namespace
