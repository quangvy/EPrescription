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
	/// This class is the base class for any <see cref="VrDoctorDoneProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrDoctorDoneProviderBaseCore : EntityViewProviderBase<VrDoctorDone>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrDoctorDone&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrDoctorDone&gt;"/></returns>
		protected static VList&lt;VrDoctorDone&gt; Fill(DataSet dataSet, VList<VrDoctorDone> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrDoctorDone>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrDoctorDone&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrDoctorDone>"/></returns>
		protected static VList&lt;VrDoctorDone&gt; Fill(DataTable dataTable, VList<VrDoctorDone> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrDoctorDone c = new VrDoctorDone();
					c.StatId = (Convert.IsDBNull(row["StatId"]))?(long)0:(System.Int64)row["StatId"];
					c.PatientCode = (Convert.IsDBNull(row["PatientCode"]))?string.Empty:(System.String)row["PatientCode"];
					c.Tid = (Convert.IsDBNull(row["TID"]))?string.Empty:(System.String)row["TID"];
					c.FirstName = (Convert.IsDBNull(row["FirstName"]))?string.Empty:(System.String)row["FirstName"];
					c.LastName = (Convert.IsDBNull(row["LastName"]))?string.Empty:(System.String)row["LastName"];
					c.Dob = (Convert.IsDBNull(row["DOB"]))?DateTime.MinValue:(System.DateTime)row["DOB"];
					c.Sex = (Convert.IsDBNull(row["Sex"]))?string.Empty:(System.String)row["Sex"];
					c.Nationality = (Convert.IsDBNull(row["Nationality"]))?string.Empty:(System.String)row["Nationality"];
					c.PatientStart = (Convert.IsDBNull(row["PatientStart"]))?false:(System.Boolean?)row["PatientStart"];
					c.VitalSign = (Convert.IsDBNull(row["VitalSign"]))?string.Empty:(System.String)row["VitalSign"];
					c.Lab = (Convert.IsDBNull(row["Lab"]))?string.Empty:(System.String)row["Lab"];
					c.Xray = (Convert.IsDBNull(row["Xray"]))?string.Empty:(System.String)row["Xray"];
					c.UltraSound = (Convert.IsDBNull(row["UltraSound"]))?string.Empty:(System.String)row["UltraSound"];
					c.Cardiology = (Convert.IsDBNull(row["Cardiology"]))?string.Empty:(System.String)row["Cardiology"];
					c.MedReport = (Convert.IsDBNull(row["MedReport"]))?string.Empty:(System.String)row["MedReport"];
					c.ChargedCodes = (Convert.IsDBNull(row["ChargedCodes"]))?string.Empty:(System.String)row["ChargedCodes"];
					c.IsCompleted = (Convert.IsDBNull(row["IsCompleted"]))?false:(System.Boolean?)row["IsCompleted"];
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
		/// Fill an <see cref="VList&lt;VrDoctorDone&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrDoctorDone&gt;"/></returns>
		protected VList<VrDoctorDone> Fill(IDataReader reader, VList<VrDoctorDone> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrDoctorDone entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrDoctorDone>("VrDoctorDone",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrDoctorDone();
					}
					
					entity.SuppressEntityEvents = true;

					entity.StatId = (System.Int64)reader[((int)VrDoctorDoneColumn.StatId)];
					//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
					entity.PatientCode = (System.String)reader[((int)VrDoctorDoneColumn.PatientCode)];
					//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
					entity.Tid = (System.String)reader[((int)VrDoctorDoneColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.FirstName = (System.String)reader[((int)VrDoctorDoneColumn.FirstName)];
					//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
					entity.LastName = (System.String)reader[((int)VrDoctorDoneColumn.LastName)];
					//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
					entity.Dob = (System.DateTime)reader[((int)VrDoctorDoneColumn.Dob)];
					//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
					entity.Sex = (System.String)reader[((int)VrDoctorDoneColumn.Sex)];
					//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
					entity.Nationality = (System.String)reader[((int)VrDoctorDoneColumn.Nationality)];
					//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
					entity.PatientStart = (reader.IsDBNull(((int)VrDoctorDoneColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrDoctorDoneColumn.PatientStart)];
					//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
					entity.VitalSign = (reader.IsDBNull(((int)VrDoctorDoneColumn.VitalSign)))?null:(System.String)reader[((int)VrDoctorDoneColumn.VitalSign)];
					//entity.VitalSign = (Convert.IsDBNull(reader["VitalSign"]))?string.Empty:(System.String)reader["VitalSign"];
					entity.Lab = (reader.IsDBNull(((int)VrDoctorDoneColumn.Lab)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Lab)];
					//entity.Lab = (Convert.IsDBNull(reader["Lab"]))?string.Empty:(System.String)reader["Lab"];
					entity.Xray = (reader.IsDBNull(((int)VrDoctorDoneColumn.Xray)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Xray)];
					//entity.Xray = (Convert.IsDBNull(reader["Xray"]))?string.Empty:(System.String)reader["Xray"];
					entity.UltraSound = (reader.IsDBNull(((int)VrDoctorDoneColumn.UltraSound)))?null:(System.String)reader[((int)VrDoctorDoneColumn.UltraSound)];
					//entity.UltraSound = (Convert.IsDBNull(reader["UltraSound"]))?string.Empty:(System.String)reader["UltraSound"];
					entity.Cardiology = (reader.IsDBNull(((int)VrDoctorDoneColumn.Cardiology)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Cardiology)];
					//entity.Cardiology = (Convert.IsDBNull(reader["Cardiology"]))?string.Empty:(System.String)reader["Cardiology"];
					entity.MedReport = (reader.IsDBNull(((int)VrDoctorDoneColumn.MedReport)))?null:(System.String)reader[((int)VrDoctorDoneColumn.MedReport)];
					//entity.MedReport = (Convert.IsDBNull(reader["MedReport"]))?string.Empty:(System.String)reader["MedReport"];
					entity.ChargedCodes = (reader.IsDBNull(((int)VrDoctorDoneColumn.ChargedCodes)))?null:(System.String)reader[((int)VrDoctorDoneColumn.ChargedCodes)];
					//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
					entity.IsCompleted = (reader.IsDBNull(((int)VrDoctorDoneColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrDoctorDoneColumn.IsCompleted)];
					//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
					entity.CreateDate = (reader.IsDBNull(((int)VrDoctorDoneColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrDoctorDoneColumn.CreateDate)];
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
		/// Refreshes the <see cref="VrDoctorDone"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrDoctorDone"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrDoctorDone entity)
		{
			reader.Read();
			entity.StatId = (System.Int64)reader[((int)VrDoctorDoneColumn.StatId)];
			//entity.StatId = (Convert.IsDBNull(reader["StatId"]))?(long)0:(System.Int64)reader["StatId"];
			entity.PatientCode = (System.String)reader[((int)VrDoctorDoneColumn.PatientCode)];
			//entity.PatientCode = (Convert.IsDBNull(reader["PatientCode"]))?string.Empty:(System.String)reader["PatientCode"];
			entity.Tid = (System.String)reader[((int)VrDoctorDoneColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.FirstName = (System.String)reader[((int)VrDoctorDoneColumn.FirstName)];
			//entity.FirstName = (Convert.IsDBNull(reader["FirstName"]))?string.Empty:(System.String)reader["FirstName"];
			entity.LastName = (System.String)reader[((int)VrDoctorDoneColumn.LastName)];
			//entity.LastName = (Convert.IsDBNull(reader["LastName"]))?string.Empty:(System.String)reader["LastName"];
			entity.Dob = (System.DateTime)reader[((int)VrDoctorDoneColumn.Dob)];
			//entity.Dob = (Convert.IsDBNull(reader["DOB"]))?DateTime.MinValue:(System.DateTime)reader["DOB"];
			entity.Sex = (System.String)reader[((int)VrDoctorDoneColumn.Sex)];
			//entity.Sex = (Convert.IsDBNull(reader["Sex"]))?string.Empty:(System.String)reader["Sex"];
			entity.Nationality = (System.String)reader[((int)VrDoctorDoneColumn.Nationality)];
			//entity.Nationality = (Convert.IsDBNull(reader["Nationality"]))?string.Empty:(System.String)reader["Nationality"];
			entity.PatientStart = (reader.IsDBNull(((int)VrDoctorDoneColumn.PatientStart)))?null:(System.Boolean?)reader[((int)VrDoctorDoneColumn.PatientStart)];
			//entity.PatientStart = (Convert.IsDBNull(reader["PatientStart"]))?false:(System.Boolean?)reader["PatientStart"];
			entity.VitalSign = (reader.IsDBNull(((int)VrDoctorDoneColumn.VitalSign)))?null:(System.String)reader[((int)VrDoctorDoneColumn.VitalSign)];
			//entity.VitalSign = (Convert.IsDBNull(reader["VitalSign"]))?string.Empty:(System.String)reader["VitalSign"];
			entity.Lab = (reader.IsDBNull(((int)VrDoctorDoneColumn.Lab)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Lab)];
			//entity.Lab = (Convert.IsDBNull(reader["Lab"]))?string.Empty:(System.String)reader["Lab"];
			entity.Xray = (reader.IsDBNull(((int)VrDoctorDoneColumn.Xray)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Xray)];
			//entity.Xray = (Convert.IsDBNull(reader["Xray"]))?string.Empty:(System.String)reader["Xray"];
			entity.UltraSound = (reader.IsDBNull(((int)VrDoctorDoneColumn.UltraSound)))?null:(System.String)reader[((int)VrDoctorDoneColumn.UltraSound)];
			//entity.UltraSound = (Convert.IsDBNull(reader["UltraSound"]))?string.Empty:(System.String)reader["UltraSound"];
			entity.Cardiology = (reader.IsDBNull(((int)VrDoctorDoneColumn.Cardiology)))?null:(System.String)reader[((int)VrDoctorDoneColumn.Cardiology)];
			//entity.Cardiology = (Convert.IsDBNull(reader["Cardiology"]))?string.Empty:(System.String)reader["Cardiology"];
			entity.MedReport = (reader.IsDBNull(((int)VrDoctorDoneColumn.MedReport)))?null:(System.String)reader[((int)VrDoctorDoneColumn.MedReport)];
			//entity.MedReport = (Convert.IsDBNull(reader["MedReport"]))?string.Empty:(System.String)reader["MedReport"];
			entity.ChargedCodes = (reader.IsDBNull(((int)VrDoctorDoneColumn.ChargedCodes)))?null:(System.String)reader[((int)VrDoctorDoneColumn.ChargedCodes)];
			//entity.ChargedCodes = (Convert.IsDBNull(reader["ChargedCodes"]))?string.Empty:(System.String)reader["ChargedCodes"];
			entity.IsCompleted = (reader.IsDBNull(((int)VrDoctorDoneColumn.IsCompleted)))?null:(System.Boolean?)reader[((int)VrDoctorDoneColumn.IsCompleted)];
			//entity.IsCompleted = (Convert.IsDBNull(reader["IsCompleted"]))?false:(System.Boolean?)reader["IsCompleted"];
			entity.CreateDate = (reader.IsDBNull(((int)VrDoctorDoneColumn.CreateDate)))?null:(System.DateTime?)reader[((int)VrDoctorDoneColumn.CreateDate)];
			//entity.CreateDate = (Convert.IsDBNull(reader["CreateDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreateDate"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrDoctorDone"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrDoctorDone"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrDoctorDone entity)
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
			entity.VitalSign = (Convert.IsDBNull(dataRow["VitalSign"]))?string.Empty:(System.String)dataRow["VitalSign"];
			entity.Lab = (Convert.IsDBNull(dataRow["Lab"]))?string.Empty:(System.String)dataRow["Lab"];
			entity.Xray = (Convert.IsDBNull(dataRow["Xray"]))?string.Empty:(System.String)dataRow["Xray"];
			entity.UltraSound = (Convert.IsDBNull(dataRow["UltraSound"]))?string.Empty:(System.String)dataRow["UltraSound"];
			entity.Cardiology = (Convert.IsDBNull(dataRow["Cardiology"]))?string.Empty:(System.String)dataRow["Cardiology"];
			entity.MedReport = (Convert.IsDBNull(dataRow["MedReport"]))?string.Empty:(System.String)dataRow["MedReport"];
			entity.ChargedCodes = (Convert.IsDBNull(dataRow["ChargedCodes"]))?string.Empty:(System.String)dataRow["ChargedCodes"];
			entity.IsCompleted = (Convert.IsDBNull(dataRow["IsCompleted"]))?false:(System.Boolean?)dataRow["IsCompleted"];
			entity.CreateDate = (Convert.IsDBNull(dataRow["CreateDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreateDate"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrDoctorDoneFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneFilterBuilder : SqlFilterBuilder<VrDoctorDoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilterBuilder class.
		/// </summary>
		public VrDoctorDoneFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorDoneFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorDoneFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorDoneFilterBuilder

	#region VrDoctorDoneParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneParameterBuilder : ParameterizedSqlFilterBuilder<VrDoctorDoneColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneParameterBuilder class.
		/// </summary>
		public VrDoctorDoneParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorDoneParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorDoneParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorDoneParameterBuilder
	
	#region VrDoctorDoneSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrDoctorDoneSortBuilder : SqlSortBuilder<VrDoctorDoneColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneSqlSortBuilder class.
		/// </summary>
		public VrDoctorDoneSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrDoctorDoneSortBuilder

} // end namespace
