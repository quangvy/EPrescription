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
	/// This class is the base class for any <see cref="VrNurseProcessedPatientsProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrNurseProcessedPatientsProviderBaseCore : EntityViewProviderBase<VrNurseProcessedPatients>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrNurseProcessedPatients&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrNurseProcessedPatients&gt;"/></returns>
		protected static VList&lt;VrNurseProcessedPatients&gt; Fill(DataSet dataSet, VList<VrNurseProcessedPatients> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrNurseProcessedPatients>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrNurseProcessedPatients&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrNurseProcessedPatients>"/></returns>
		protected static VList&lt;VrNurseProcessedPatients&gt; Fill(DataTable dataTable, VList<VrNurseProcessedPatients> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrNurseProcessedPatients c = new VrNurseProcessedPatients();
					c.StatId = (Convert.IsDBNull(row["StatId"]))?(long)0:(System.Int64)row["StatId"];
					c.PatientCode = (Convert.IsDBNull(row["PatientCode"]))?string.Empty:(System.String)row["PatientCode"];
					c.Tid = (Convert.IsDBNull(row["TID"]))?string.Empty:(System.String)row["TID"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Dob = (Convert.IsDBNull(row["DOB"]))?DateTime.MinValue:(System.DateTime)row["DOB"];
					c.Sex = (Convert.IsDBNull(row["Sex"]))?string.Empty:(System.String)row["Sex"];
					c.Nationality = (Convert.IsDBNull(row["Nationality"]))?string.Empty:(System.String)row["Nationality"];
					c.PatientStart = (Convert.IsDBNull(row["PatientStart"]))?false:(System.Boolean?)row["PatientStart"];
					c.Lab = (Convert.IsDBNull(row["Lab"]))?string.Empty:(System.String)row["Lab"];
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
		/// Fill an <see cref="VList&lt;VrNurseProcessedPatients&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrNurseProcessedPatients&gt;"/></returns>
		protected VList<VrNurseProcessedPatients> Fill(IDataReader reader, VList<VrNurseProcessedPatients> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrNurseProcessedPatients entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrNurseProcessedPatients>("VrNurseProcessedPatients",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrNurseProcessedPatients();
					}
					
					entity.SuppressEntityEvents = true;

					entity.StatId = (System.Int64)reader[((int)VrNurseProcessedPatientsColumn.StatId)];
					//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
					entity.PatientCode = (System.String)reader[((int)VrNurseProcessedPatientsColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.Tid = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.FirstName = (System.String)reader[((int)VrNurseProcessedPatientsColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (System.String)reader[((int)VrNurseProcessedPatientsColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Dob = (System.DateTime)reader[((int)VrNurseProcessedPatientsColumn.Dob)];
					//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
					entity.Sex = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.Nationality = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.PatientStart = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrNurseProcessedPatientsColumn.PatientStart)];
					//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
					entity.Lab = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.Lab)))?null:(System.String)reader[((int)VrNurseProcessedPatientsColumn.Lab)];
					//entity.Lab = (Convert.IsDBNull(reader["Lab"]))?string.Empty:(System.String)reader["Lab"];
					entity.ChargedCodes = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.ChargedCodes)))?null:(System.String)reader[((int)VrNurseProcessedPatientsColumn.ChargedCodes)];
					//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
					entity.CreateDate = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrNurseProcessedPatientsColumn.CreateDate)];
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
		/// Refreshes the <see cref="VrNurseProcessedPatients"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrNurseProcessedPatients"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrNurseProcessedPatients entity)
		{
			reader.Read();
			entity.StatId = (System.Int64)reader[((int)VrNurseProcessedPatientsColumn.StatId)];
			//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
			entity.PatientCode = (System.String)reader[((int)VrNurseProcessedPatientsColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.Tid = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.FirstName = (System.String)reader[((int)VrNurseProcessedPatientsColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader[((int)VrNurseProcessedPatientsColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Dob = (System.DateTime)reader[((int)VrNurseProcessedPatientsColumn.Dob)];
			//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
			entity.Sex = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.Nationality = (System.String)reader[((int)VrNurseProcessedPatientsColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			entity.PatientStart = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrNurseProcessedPatientsColumn.PatientStart)];
			//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
			entity.Lab = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.Lab)))?null:(System.String)reader[((int)VrNurseProcessedPatientsColumn.Lab)];
			//entity.Lab = (Convert.IsDBNull(reader["Lab"]))?string.Empty:(System.String)reader["Lab"];
			entity.ChargedCodes = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.ChargedCodes)))?null:(System.String)reader[((int)VrNurseProcessedPatientsColumn.ChargedCodes)];
			//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
			entity.CreateDate = (reader.IsDBNull(((int)VrNurseProcessedPatientsColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrNurseProcessedPatientsColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrNurseProcessedPatients"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrNurseProcessedPatients"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrNurseProcessedPatients entity)
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
			entity.Lab = (Convert.IsDBNull(dataRow["Lab"]))?string.Empty:(System.String)dataRow["Lab"];
			entity.ChargedCodes = (Convert.IsDBNull(dataRow["ChargedCodes"]))?string.Empty:(System.String)dataRow["ChargedCodes"];
			entity.CreateDate = (Convert.IsDBNull(dataRow["CreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreateDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrNurseProcessedPatientsFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsFilterBuilder : SqlFilterBuilder<VrNurseProcessedPatientsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilterBuilder class.
		/// </summary>
		public VrNurseProcessedPatientsFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrNurseProcessedPatientsFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrNurseProcessedPatientsFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrNurseProcessedPatientsFilterBuilder

	#region VrNurseProcessedPatientsParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsParameterBuilder : ParameterizedSqlFilterBuilder<VrNurseProcessedPatientsColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsParameterBuilder class.
		/// </summary>
		public VrNurseProcessedPatientsParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrNurseProcessedPatientsParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrNurseProcessedPatientsParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrNurseProcessedPatientsParameterBuilder
	
	#region VrNurseProcessedPatientsSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrNurseProcessedPatientsSortBuilder : SqlSortBuilder<VrNurseProcessedPatientsColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsSqlSortBuilder class.
		/// </summary>
		public VrNurseProcessedPatientsSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrNurseProcessedPatientsSortBuilder

} // end namespace
