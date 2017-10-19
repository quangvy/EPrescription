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
	/// This class is the base class for any <see cref="VrReceptionDoneProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrReceptionDoneProviderBaseCore : EntityViewProviderBase<VrReceptionDone>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrReceptionDone&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrReceptionDone&gt;"/></returns>
		protected static VList&lt;VrReceptionDone&gt; Fill(DataSet dataSet, VList<VrReceptionDone> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrReceptionDone>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrReceptionDone&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrReceptionDone>"/></returns>
		protected static VList&lt;VrReceptionDone&gt; Fill(DataTable dataTable, VList<VrReceptionDone> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrReceptionDone c = new VrReceptionDone();
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
					c.CreateDate = (Convert.IsDBNull(row["CreateDate"]))?DateTime.MinValue:(System.DateTime?)row["CreateDate"];
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
		/// Fill an <see cref="VList&lt;VrReceptionDone&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrReceptionDone&gt;"/></returns>
		protected VList<VrReceptionDone> Fill(IDataReader reader, VList<VrReceptionDone> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrReceptionDone entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrReceptionDone>("VrReceptionDone",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrReceptionDone();
					}
					
					entity.SuppressEntityEvents = true;

					entity.StatId = (System.Int64)reader[((int)VrReceptionDoneColumn.StatId)];
					//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
					entity.PatientCode = (System.String)reader[((int)VrReceptionDoneColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.Tid = (System.String)reader[((int)VrReceptionDoneColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.FirstName = (System.String)reader[((int)VrReceptionDoneColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (System.String)reader[((int)VrReceptionDoneColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Dob = (System.DateTime)reader[((int)VrReceptionDoneColumn.Dob)];
					//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
					entity.Sex = (System.String)reader[((int)VrReceptionDoneColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.Nationality = (System.String)reader[((int)VrReceptionDoneColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.PatientStart = (reader.IsDBNull(((int)VrReceptionDoneColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionDoneColumn.PatientStart)];
					//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
					entity.IsCompleted = (reader.IsDBNull(((int)VrReceptionDoneColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrReceptionDoneColumn.IsCompleted)];
					//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
					entity.ChargedCodes = (reader.IsDBNull(((int)VrReceptionDoneColumn.ChargedCodes)))?null:(System.String)reader[((int)VrReceptionDoneColumn.ChargedCodes)];
					//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
					entity.CreateDate = (reader.IsDBNull(((int)VrReceptionDoneColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrReceptionDoneColumn.CreateDate)];
					//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
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
		/// Refreshes the <see cref="VrReceptionDone"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReceptionDone"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrReceptionDone entity)
		{
			reader.Read();
			entity.StatId = (System.Int64)reader[((int)VrReceptionDoneColumn.StatId)];
			//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
			entity.PatientCode = (System.String)reader[((int)VrReceptionDoneColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.Tid = (System.String)reader[((int)VrReceptionDoneColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.FirstName = (System.String)reader[((int)VrReceptionDoneColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader[((int)VrReceptionDoneColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Dob = (System.DateTime)reader[((int)VrReceptionDoneColumn.Dob)];
			//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
			entity.Sex = (System.String)reader[((int)VrReceptionDoneColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.Nationality = (System.String)reader[((int)VrReceptionDoneColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			entity.PatientStart = (reader.IsDBNull(((int)VrReceptionDoneColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrReceptionDoneColumn.PatientStart)];
			//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
			entity.IsCompleted = (reader.IsDBNull(((int)VrReceptionDoneColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrReceptionDoneColumn.IsCompleted)];
			//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
			entity.ChargedCodes = (reader.IsDBNull(((int)VrReceptionDoneColumn.ChargedCodes)))?null:(System.String)reader[((int)VrReceptionDoneColumn.ChargedCodes)];
			//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
			entity.CreateDate = (reader.IsDBNull(((int)VrReceptionDoneColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrReceptionDoneColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrReceptionDone"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrReceptionDone"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrReceptionDone entity)
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
			entity.CreateDate = (Convert.IsDBNull(dataRow["CreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreateDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrReceptionDoneFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneFilterBuilder : SqlFilterBuilder<VrReceptionDoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilterBuilder class.
		/// </summary>
		public VrReceptionDoneFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionDoneFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionDoneFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionDoneFilterBuilder

	#region VrReceptionDoneParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneParameterBuilder : ParameterizedSqlFilterBuilder<VrReceptionDoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneParameterBuilder class.
		/// </summary>
		public VrReceptionDoneParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionDoneParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionDoneParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionDoneParameterBuilder
	
	#region VrReceptionDoneSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrReceptionDoneSortBuilder : SqlSortBuilder<VrReceptionDoneColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneSqlSortBuilder class.
		/// </summary>
		public VrReceptionDoneSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrReceptionDoneSortBuilder

} // end namespace
