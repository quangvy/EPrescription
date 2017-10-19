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
	/// This class is the base class for any <see cref="VrLabResultProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrLabResultProviderBaseCore : EntityViewProviderBase<VrLabResult>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrLabResult&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrLabResult&gt;"/></returns>
		protected static VList&lt;VrLabResult&gt; Fill(DataSet dataSet, VList<VrLabResult> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrLabResult>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrLabResult&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrLabResult>"/></returns>
		protected static VList&lt;VrLabResult&gt; Fill(DataTable dataTable, VList<VrLabResult> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrLabResult c = new VrLabResult();
					c.Id = (Convert.IsDBNull(row["Id"]))?(long)0:(System.Int64)row["Id"];
					c.Tid = (Convert.IsDBNull(row["TID"]))?string.Empty:(System.String)row["TID"];
					c.ReqId = (Convert.IsDBNull(row["ReqID"]))?string.Empty:(System.String)row["ReqID"];
					c.Code = (Convert.IsDBNull(row["Code"]))?string.Empty:(System.String)row["Code"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.ReqDoctor = (Convert.IsDBNull(row["ReqDoctor"]))?string.Empty:(System.String)row["ReqDoctor"];
					c.Billable = (Convert.IsDBNull(row["Billable"]))?false:(System.Boolean?)row["Billable"];
					c.Sample = (Convert.IsDBNull(row["Sample"]))?string.Empty:(System.String)row["Sample"];
					c.ColDate = (Convert.IsDBNull(row["ColDate"]))?DateTime.MinValue:(System.DateTime?)row["ColDate"];
					c.ColTime = (Convert.IsDBNull(row["ColTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)row["ColTime"];
					c.ReqDate = (Convert.IsDBNull(row["ReqDate"]))?DateTime.MinValue:(System.DateTime?)row["ReqDate"];
					c.SampleType = (Convert.IsDBNull(row["SampleType"]))?string.Empty:(System.String)row["SampleType"];
					c.ProviderType = (Convert.IsDBNull(row["ProviderType"]))?string.Empty:(System.String)row["ProviderType"];
					c.StatId = (Convert.IsDBNull(row["StatId"]))?(long)0:(System.Int64)row["StatId"];
					c.PatientCode = (Convert.IsDBNull(row["PatientCode"]))?string.Empty:(System.String)row["PatientCode"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Dob = (Convert.IsDBNull(row["DOB"]))?DateTime.MinValue:(System.DateTime)row["DOB"];
					c.Sex = (Convert.IsDBNull(row["Sex"]))?string.Empty:(System.String)row["Sex"];
					c.Nationality = (Convert.IsDBNull(row["Nationality"]))?string.Empty:(System.String)row["Nationality"];
					c.ReqStatus = (Convert.IsDBNull(row["ReqStatus"]))?string.Empty:(System.String)row["ReqStatus"];
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
		/// Fill an <see cref="VList&lt;VrLabResult&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrLabResult&gt;"/></returns>
		protected VList<VrLabResult> Fill(IDataReader reader, VList<VrLabResult> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrLabResult entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrLabResult>("VrLabResult",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrLabResult();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int64)reader[((int)VrLabResultColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["Id"]))?(long)0:(System.Int64)reader["Id"];
					entity.Tid = (reader.IsDBNull(((int)VrLabResultColumn.Tid)))?null:(System.String)reader[((int)VrLabResultColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.ReqId = (reader.IsDBNull(((int)VrLabResultColumn.ReqId)))?null:(System.String)reader[((int)VrLabResultColumn.ReqId)];
					//entity.ReqId = (Convert.IsDBNull(reader["ReqID"]))?string.Empty:(System.String)reader["ReqID"];
					entity.Code = (reader.IsDBNull(((int)VrLabResultColumn.Code)))?null:(System.String)reader[((int)VrLabResultColumn.Code)];
					//entity.Code = (Convert.IsDBNull(reader["Code"]))?string.Empty:(System.String)reader["Code"];
					entity.Description = (reader.IsDBNull(((int)VrLabResultColumn.Description)))?null:(System.String)reader[((int)VrLabResultColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.ReqDoctor = (reader.IsDBNull(((int)VrLabResultColumn.ReqDoctor)))?null:(System.String)reader[((int)VrLabResultColumn.ReqDoctor)];
					//entity.ReqDoctor = (Convert.IsDBNull(reader["ReqDoctor"]))?string.Empty:(System.String)reader["ReqDoctor"];
					entity.Billable = (reader.IsDBNull(((int)VrLabResultColumn.Billable)))?null:(System.Boolean?)reader[((int)VrLabResultColumn.Billable)];
					//entity.Billable = (Convert.IsDBNull(reader["Billable"]))?false:(System.Boolean?)reader["Billable"];
					entity.Sample = (reader.IsDBNull(((int)VrLabResultColumn.Sample)))?null:(System.String)reader[((int)VrLabResultColumn.Sample)];
					//entity.Sample = (Convert.IsDBNull(reader["Sample"]))?string.Empty:(System.String)reader["Sample"];
					entity.ColDate = (reader.IsDBNull(((int)VrLabResultColumn.ColDate)))?null:(System.DateTime?)reader[((int)VrLabResultColumn.ColDate)];
					//entity.ColDate = (Convert.IsDBNull(reader["ColDate"]))?DateTime.MinValue:(System.DateTime?)reader["ColDate"];
					entity.ColTime = (reader.IsDBNull(((int)VrLabResultColumn.ColTime)))?null:(System.TimeSpan?)reader[((int)VrLabResultColumn.ColTime)];
					//entity.ColTime = (Convert.IsDBNull(reader["ColTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["ColTime"];
					entity.ReqDate = (reader.IsDBNull(((int)VrLabResultColumn.ReqDate)))?null:(System.DateTime?)reader[((int)VrLabResultColumn.ReqDate)];
					//entity.ReqDate = (Convert.IsDBNull(reader["ReqDate"]))?DateTime.MinValue:(System.DateTime?)reader["ReqDate"];
					entity.SampleType = (reader.IsDBNull(((int)VrLabResultColumn.SampleType)))?null:(System.String)reader[((int)VrLabResultColumn.SampleType)];
					//entity.SampleType = (Convert.IsDBNull(reader["SampleType"]))?string.Empty:(System.String)reader["SampleType"];
					entity.ProviderType = (reader.IsDBNull(((int)VrLabResultColumn.ProviderType)))?null:(System.String)reader[((int)VrLabResultColumn.ProviderType)];
					//entity.ProviderType = (Convert.IsDBNull(reader["ProviderType"]))?string.Empty:(System.String)reader["ProviderType"];
					entity.StatId = (System.Int64)reader[((int)VrLabResultColumn.StatId)];
					//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
					entity.PatientCode = (System.String)reader[((int)VrLabResultColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.FirstName = (System.String)reader[((int)VrLabResultColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (System.String)reader[((int)VrLabResultColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Dob = (System.DateTime)reader[((int)VrLabResultColumn.Dob)];
					//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
					entity.Sex = (System.String)reader[((int)VrLabResultColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.Nationality = (System.String)reader[((int)VrLabResultColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.ReqStatus = (reader.IsDBNull(((int)VrLabResultColumn.ReqStatus)))?null:(System.String)reader[((int)VrLabResultColumn.ReqStatus)];
					//entity.ReqStatus = (Convert.IsDBNull(reader["ReqStatus"]))?string.Empty:(System.String)reader["ReqStatus"];
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
		/// Refreshes the <see cref="VrLabResult"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrLabResult"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrLabResult entity)
		{
			reader.Read();
			entity.Id = (System.Int64)reader[((int)VrLabResultColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["Id"]))?(long)0:(System.Int64)reader["Id"];
			entity.Tid = (reader.IsDBNull(((int)VrLabResultColumn.Tid)))?null:(System.String)reader[((int)VrLabResultColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.ReqId = (reader.IsDBNull(((int)VrLabResultColumn.ReqId)))?null:(System.String)reader[((int)VrLabResultColumn.ReqId)];
			//entity.ReqId = (Convert.IsDBNull(reader["ReqID"]))?string.Empty:(System.String)reader["ReqID"];
			entity.Code = (reader.IsDBNull(((int)VrLabResultColumn.Code)))?null:(System.String)reader[((int)VrLabResultColumn.Code)];
			//entity.Code = (Convert.IsDBNull(reader["Code"]))?string.Empty:(System.String)reader["Code"];
			entity.Description = (reader.IsDBNull(((int)VrLabResultColumn.Description)))?null:(System.String)reader[((int)VrLabResultColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.ReqDoctor = (reader.IsDBNull(((int)VrLabResultColumn.ReqDoctor)))?null:(System.String)reader[((int)VrLabResultColumn.ReqDoctor)];
			//entity.ReqDoctor = (Convert.IsDBNull(reader["ReqDoctor"]))?string.Empty:(System.String)reader["ReqDoctor"];
			entity.Billable = (reader.IsDBNull(((int)VrLabResultColumn.Billable)))?null:(System.Boolean?)reader[((int)VrLabResultColumn.Billable)];
			//entity.Billable = (Convert.IsDBNull(reader["Billable"]))?false:(System.Boolean?)reader["Billable"];
			entity.Sample = (reader.IsDBNull(((int)VrLabResultColumn.Sample)))?null:(System.String)reader[((int)VrLabResultColumn.Sample)];
			//entity.Sample = (Convert.IsDBNull(reader["Sample"]))?string.Empty:(System.String)reader["Sample"];
			entity.ColDate = (reader.IsDBNull(((int)VrLabResultColumn.ColDate)))?null:(System.DateTime?)reader[((int)VrLabResultColumn.ColDate)];
			//entity.ColDate = (Convert.IsDBNull(reader["ColDate"]))?DateTime.MinValue:(System.DateTime?)reader["ColDate"];
			entity.ColTime = (reader.IsDBNull(((int)VrLabResultColumn.ColTime)))?null:(System.TimeSpan?)reader[((int)VrLabResultColumn.ColTime)];
			//entity.ColTime = (Convert.IsDBNull(reader["ColTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)reader["ColTime"];
			entity.ReqDate = (reader.IsDBNull(((int)VrLabResultColumn.ReqDate)))?null:(System.DateTime?)reader[((int)VrLabResultColumn.ReqDate)];
			//entity.ReqDate = (Convert.IsDBNull(reader["ReqDate"]))?DateTime.MinValue:(System.DateTime?)reader["ReqDate"];
			entity.SampleType = (reader.IsDBNull(((int)VrLabResultColumn.SampleType)))?null:(System.String)reader[((int)VrLabResultColumn.SampleType)];
			//entity.SampleType = (Convert.IsDBNull(reader["SampleType"]))?string.Empty:(System.String)reader["SampleType"];
			entity.ProviderType = (reader.IsDBNull(((int)VrLabResultColumn.ProviderType)))?null:(System.String)reader[((int)VrLabResultColumn.ProviderType)];
			//entity.ProviderType = (Convert.IsDBNull(reader["ProviderType"]))?string.Empty:(System.String)reader["ProviderType"];
			entity.StatId = (System.Int64)reader[((int)VrLabResultColumn.StatId)];
			//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
			entity.PatientCode = (System.String)reader[((int)VrLabResultColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.FirstName = (System.String)reader[((int)VrLabResultColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader[((int)VrLabResultColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Dob = (System.DateTime)reader[((int)VrLabResultColumn.Dob)];
			//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
			entity.Sex = (System.String)reader[((int)VrLabResultColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.Nationality = (System.String)reader[((int)VrLabResultColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			entity.ReqStatus = (reader.IsDBNull(((int)VrLabResultColumn.ReqStatus)))?null:(System.String)reader[((int)VrLabResultColumn.ReqStatus)];
			//entity.ReqStatus = (Convert.IsDBNull(reader["ReqStatus"]))?string.Empty:(System.String)reader["ReqStatus"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrLabResult"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrLabResult"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrLabResult entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["Id"]))?(long)0:(System.Int64)dataRow["Id"];
			entity.Tid = (Convert.IsDBNull(dataRow["TID"]))?string.Empty:(System.String)dataRow["TID"];
			entity.ReqId = (Convert.IsDBNull(dataRow["ReqID"]))?string.Empty:(System.String)dataRow["ReqID"];
			entity.Code = (Convert.IsDBNull(dataRow["Code"]))?string.Empty:(System.String)dataRow["Code"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.ReqDoctor = (Convert.IsDBNull(dataRow["ReqDoctor"]))?string.Empty:(System.String)dataRow["ReqDoctor"];
			entity.Billable = (Convert.IsDBNull(dataRow["Billable"]))?false:(System.Boolean?)dataRow["Billable"];
			entity.Sample = (Convert.IsDBNull(dataRow["Sample"]))?string.Empty:(System.String)dataRow["Sample"];
			entity.ColDate = (Convert.IsDBNull(dataRow["ColDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ColDate"];
			entity.ColTime = (Convert.IsDBNull(dataRow["ColTime"]))?new TimeSpan(1,0,0,0,0):(System.TimeSpan?)dataRow["ColTime"];
			entity.ReqDate = (Convert.IsDBNull(dataRow["ReqDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ReqDate"];
			entity.SampleType = (Convert.IsDBNull(dataRow["SampleType"]))?string.Empty:(System.String)dataRow["SampleType"];
			entity.ProviderType = (Convert.IsDBNull(dataRow["ProviderType"]))?string.Empty:(System.String)dataRow["ProviderType"];
			entity.StatId = (Convert.IsDBNull(dataRow["StatId"]))?(long)0:(System.Int64)dataRow["StatId"];
			entity.PatientCode = (Convert.IsDBNull(dataRow["PatientCode"]))?string.Empty:(System.String)dataRow["PatientCode"];
			entity.FirstName = (Convert.IsDBNull(dataRow["FirstName"]))?string.Empty:(System.String)dataRow["FirstName"];
			entity.LastName = (Convert.IsDBNull(dataRow["LastName"]))?string.Empty:(System.String)dataRow["LastName"];
			entity.Dob = (Convert.IsDBNull(dataRow["DOB"]))?DateTime.MinValue:(System.DateTime)dataRow["DOB"];
			entity.Sex = (Convert.IsDBNull(dataRow["Sex"]))?string.Empty:(System.String)dataRow["Sex"];
			entity.Nationality = (Convert.IsDBNull(dataRow["Nationality"]))?string.Empty:(System.String)dataRow["Nationality"];
			entity.ReqStatus = (Convert.IsDBNull(dataRow["ReqStatus"]))?string.Empty:(System.String)dataRow["ReqStatus"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrLabResultFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultFilterBuilder : SqlFilterBuilder<VrLabResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilterBuilder class.
		/// </summary>
		public VrLabResultFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabResultFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabResultFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabResultFilterBuilder

	#region VrLabResultParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultParameterBuilder : ParameterizedSqlFilterBuilder<VrLabResultColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultParameterBuilder class.
		/// </summary>
		public VrLabResultParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabResultParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabResultParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabResultParameterBuilder
	
	#region VrLabResultSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrLabResultSortBuilder : SqlSortBuilder<VrLabResultColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultSqlSortBuilder class.
		/// </summary>
		public VrLabResultSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrLabResultSortBuilder

} // end namespace
