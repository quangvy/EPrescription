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
	/// This class is the base class for any <see cref="VrEPresDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrEPresDetailProviderBaseCore : EntityViewProviderBase<VrEPresDetail>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrEPresDetail&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrEPresDetail&gt;"/></returns>
		protected static VList&lt;VrEPresDetail&gt; Fill(DataSet dataSet, VList<VrEPresDetail> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrEPresDetail>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrEPresDetail&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrEPresDetail>"/></returns>
		protected static VList&lt;VrEPresDetail&gt; Fill(DataTable dataTable, VList<VrEPresDetail> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrEPresDetail c = new VrEPresDetail();
					c.PrescriptionDetailId = (Convert.IsDBNull(row["PrescriptionDetailId"]))?(long)0:(System.Int64)row["PrescriptionDetailId"];
					c.PrescriptionId = (Convert.IsDBNull(row["PrescriptionID"]))?string.Empty:(System.String)row["PrescriptionID"];
					c.Sq = (Convert.IsDBNull(row["Sq"]))?(int)0:(System.Int32)row["Sq"];
					c.DrugId = (Convert.IsDBNull(row["DrugId"]))?string.Empty:(System.String)row["DrugId"];
					c.DrugName = (Convert.IsDBNull(row["DrugName"]))?string.Empty:(System.String)row["DrugName"];
					c.Unit = (Convert.IsDBNull(row["Unit"]))?string.Empty:(System.String)row["Unit"];
					c.UnitVn = (Convert.IsDBNull(row["UnitVN"]))?string.Empty:(System.String)row["UnitVN"];
					c.Remark = (Convert.IsDBNull(row["Remark"]))?string.Empty:(System.String)row["Remark"];
					c.Dosage = (Convert.IsDBNull(row["Dosage"]))?string.Empty:(System.String)row["Dosage"];
					c.Frequency = (Convert.IsDBNull(row["Frequency"]))?string.Empty:(System.String)row["Frequency"];
					c.VnMeaning = (Convert.IsDBNull(row["VN_meaning"]))?string.Empty:(System.String)row["VN_meaning"];
					c.Duration = (Convert.IsDBNull(row["Duration"]))?string.Empty:(System.String)row["Duration"];
					c.TotalUnit = (Convert.IsDBNull(row["TotalUnit"]))?string.Empty:(System.String)row["TotalUnit"];
					c.Expr1 = (Convert.IsDBNull(row["Expr1"]))?string.Empty:(System.String)row["Expr1"];
					c.Meaning = (Convert.IsDBNull(row["meaning"]))?string.Empty:(System.String)row["meaning"];
					c.Abbre = (Convert.IsDBNull(row["abbre"]))?string.Empty:(System.String)row["abbre"];
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
		/// Fill an <see cref="VList&lt;VrEPresDetail&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrEPresDetail&gt;"/></returns>
		protected VList<VrEPresDetail> Fill(IDataReader reader, VList<VrEPresDetail> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrEPresDetail entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrEPresDetail>("VrEPresDetail",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrEPresDetail();
					}
					
					entity.SuppressEntityEvents = true;

					entity.PrescriptionDetailId = (System.Int64)reader[((int)VrEPresDetailColumn.PrescriptionDetailId)];
					//entity.PrescriptionDetailId = (Convert.IsDBNull(reader["PrescriptionDetailId"]))?(long)0:(System.Int64)reader["PrescriptionDetailId"];
					entity.PrescriptionId = (System.String)reader[((int)VrEPresDetailColumn.PrescriptionId)];
					//entity.PrescriptionId = (Convert.IsDBNull(reader["PrescriptionID"]))?string.Empty:(System.String)reader["PrescriptionID"];
					entity.Sq = (System.Int32)reader[((int)VrEPresDetailColumn.Sq)];
					//entity.Sq = (Convert.IsDBNull(reader["Sq"]))?(int)0:(System.Int32)reader["Sq"];
					entity.DrugId = (reader.IsDBNull(((int)VrEPresDetailColumn.DrugId)))?null:(System.String)reader[((int)VrEPresDetailColumn.DrugId)];
					//entity.DrugId = (Convert.IsDBNull(reader["DrugId"]))?string.Empty:(System.String)reader["DrugId"];
					entity.DrugName = (System.String)reader[((int)VrEPresDetailColumn.DrugName)];
					//entity.DrugName = (Convert.IsDBNull(reader["DrugName"]))?string.Empty:(System.String)reader["DrugName"];
					entity.Unit = (reader.IsDBNull(((int)VrEPresDetailColumn.Unit)))?null:(System.String)reader[((int)VrEPresDetailColumn.Unit)];
					//entity.Unit = (Convert.IsDBNull(reader["Unit"]))?string.Empty:(System.String)reader["Unit"];
					entity.UnitVn = (reader.IsDBNull(((int)VrEPresDetailColumn.UnitVn)))?null:(System.String)reader[((int)VrEPresDetailColumn.UnitVn)];
					//entity.UnitVn = (Convert.IsDBNull(reader["UnitVN"]))?string.Empty:(System.String)reader["UnitVN"];
					entity.Remark = (reader.IsDBNull(((int)VrEPresDetailColumn.Remark)))?null:(System.String)reader[((int)VrEPresDetailColumn.Remark)];
					//entity.Remark = (Convert.IsDBNull(reader["Remark"]))?string.Empty:(System.String)reader["Remark"];
					entity.Dosage = (reader.IsDBNull(((int)VrEPresDetailColumn.Dosage)))?null:(System.String)reader[((int)VrEPresDetailColumn.Dosage)];
					//entity.Dosage = (Convert.IsDBNull(reader["Dosage"]))?string.Empty:(System.String)reader["Dosage"];
					entity.Frequency = (reader.IsDBNull(((int)VrEPresDetailColumn.Frequency)))?null:(System.String)reader[((int)VrEPresDetailColumn.Frequency)];
					//entity.Frequency = (Convert.IsDBNull(reader["Frequency"]))?string.Empty:(System.String)reader["Frequency"];
					entity.VnMeaning = (reader.IsDBNull(((int)VrEPresDetailColumn.VnMeaning)))?null:(System.String)reader[((int)VrEPresDetailColumn.VnMeaning)];
					//entity.VnMeaning = (Convert.IsDBNull(reader["VN_meaning"]))?string.Empty:(System.String)reader["VN_meaning"];
					entity.Duration = (reader.IsDBNull(((int)VrEPresDetailColumn.Duration)))?null:(System.String)reader[((int)VrEPresDetailColumn.Duration)];
					//entity.Duration = (Convert.IsDBNull(reader["Duration"]))?string.Empty:(System.String)reader["Duration"];
					entity.TotalUnit = (reader.IsDBNull(((int)VrEPresDetailColumn.TotalUnit)))?null:(System.String)reader[((int)VrEPresDetailColumn.TotalUnit)];
					//entity.TotalUnit = (Convert.IsDBNull(reader["TotalUnit"]))?string.Empty:(System.String)reader["TotalUnit"];
					entity.Expr1 = (reader.IsDBNull(((int)VrEPresDetailColumn.Expr1)))?null:(System.String)reader[((int)VrEPresDetailColumn.Expr1)];
					//entity.Expr1 = (Convert.IsDBNull(reader["Expr1"]))?string.Empty:(System.String)reader["Expr1"];
					entity.Meaning = (reader.IsDBNull(((int)VrEPresDetailColumn.Meaning)))?null:(System.String)reader[((int)VrEPresDetailColumn.Meaning)];
					//entity.Meaning = (Convert.IsDBNull(reader["meaning"]))?string.Empty:(System.String)reader["meaning"];
					entity.Abbre = (reader.IsDBNull(((int)VrEPresDetailColumn.Abbre)))?null:(System.String)reader[((int)VrEPresDetailColumn.Abbre)];
					//entity.Abbre = (Convert.IsDBNull(reader["abbre"]))?string.Empty:(System.String)reader["abbre"];
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
		/// Refreshes the <see cref="VrEPresDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrEPresDetail"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrEPresDetail entity)
		{
			reader.Read();
			entity.PrescriptionDetailId = (System.Int64)reader[((int)VrEPresDetailColumn.PrescriptionDetailId)];
			//entity.PrescriptionDetailId = (Convert.IsDBNull(reader["PrescriptionDetailId"]))?(long)0:(System.Int64)reader["PrescriptionDetailId"];
			entity.PrescriptionId = (System.String)reader[((int)VrEPresDetailColumn.PrescriptionId)];
			//entity.PrescriptionId = (Convert.IsDBNull(reader["PrescriptionID"]))?string.Empty:(System.String)reader["PrescriptionID"];
			entity.Sq = (System.Int32)reader[((int)VrEPresDetailColumn.Sq)];
			//entity.Sq = (Convert.IsDBNull(reader["Sq"]))?(int)0:(System.Int32)reader["Sq"];
			entity.DrugId = (reader.IsDBNull(((int)VrEPresDetailColumn.DrugId)))?null:(System.String)reader[((int)VrEPresDetailColumn.DrugId)];
			//entity.DrugId = (Convert.IsDBNull(reader["DrugId"]))?string.Empty:(System.String)reader["DrugId"];
			entity.DrugName = (System.String)reader[((int)VrEPresDetailColumn.DrugName)];
			//entity.DrugName = (Convert.IsDBNull(reader["DrugName"]))?string.Empty:(System.String)reader["DrugName"];
			entity.Unit = (reader.IsDBNull(((int)VrEPresDetailColumn.Unit)))?null:(System.String)reader[((int)VrEPresDetailColumn.Unit)];
			//entity.Unit = (Convert.IsDBNull(reader["Unit"]))?string.Empty:(System.String)reader["Unit"];
			entity.UnitVn = (reader.IsDBNull(((int)VrEPresDetailColumn.UnitVn)))?null:(System.String)reader[((int)VrEPresDetailColumn.UnitVn)];
			//entity.UnitVn = (Convert.IsDBNull(reader["UnitVN"]))?string.Empty:(System.String)reader["UnitVN"];
			entity.Remark = (reader.IsDBNull(((int)VrEPresDetailColumn.Remark)))?null:(System.String)reader[((int)VrEPresDetailColumn.Remark)];
			//entity.Remark = (Convert.IsDBNull(reader["Remark"]))?string.Empty:(System.String)reader["Remark"];
			entity.Dosage = (reader.IsDBNull(((int)VrEPresDetailColumn.Dosage)))?null:(System.String)reader[((int)VrEPresDetailColumn.Dosage)];
			//entity.Dosage = (Convert.IsDBNull(reader["Dosage"]))?string.Empty:(System.String)reader["Dosage"];
			entity.Frequency = (reader.IsDBNull(((int)VrEPresDetailColumn.Frequency)))?null:(System.String)reader[((int)VrEPresDetailColumn.Frequency)];
			//entity.Frequency = (Convert.IsDBNull(reader["Frequency"]))?string.Empty:(System.String)reader["Frequency"];
			entity.VnMeaning = (reader.IsDBNull(((int)VrEPresDetailColumn.VnMeaning)))?null:(System.String)reader[((int)VrEPresDetailColumn.VnMeaning)];
			//entity.VnMeaning = (Convert.IsDBNull(reader["VN_meaning"]))?string.Empty:(System.String)reader["VN_meaning"];
			entity.Duration = (reader.IsDBNull(((int)VrEPresDetailColumn.Duration)))?null:(System.String)reader[((int)VrEPresDetailColumn.Duration)];
			//entity.Duration = (Convert.IsDBNull(reader["Duration"]))?string.Empty:(System.String)reader["Duration"];
			entity.TotalUnit = (reader.IsDBNull(((int)VrEPresDetailColumn.TotalUnit)))?null:(System.String)reader[((int)VrEPresDetailColumn.TotalUnit)];
			//entity.TotalUnit = (Convert.IsDBNull(reader["TotalUnit"]))?string.Empty:(System.String)reader["TotalUnit"];
			entity.Expr1 = (reader.IsDBNull(((int)VrEPresDetailColumn.Expr1)))?null:(System.String)reader[((int)VrEPresDetailColumn.Expr1)];
			//entity.Expr1 = (Convert.IsDBNull(reader["Expr1"]))?string.Empty:(System.String)reader["Expr1"];
			entity.Meaning = (reader.IsDBNull(((int)VrEPresDetailColumn.Meaning)))?null:(System.String)reader[((int)VrEPresDetailColumn.Meaning)];
			//entity.Meaning = (Convert.IsDBNull(reader["meaning"]))?string.Empty:(System.String)reader["meaning"];
			entity.Abbre = (reader.IsDBNull(((int)VrEPresDetailColumn.Abbre)))?null:(System.String)reader[((int)VrEPresDetailColumn.Abbre)];
			//entity.Abbre = (Convert.IsDBNull(reader["abbre"]))?string.Empty:(System.String)reader["abbre"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrEPresDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrEPresDetail"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrEPresDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.PrescriptionDetailId = (Convert.IsDBNull(dataRow["PrescriptionDetailId"]))?(long)0:(System.Int64)dataRow["PrescriptionDetailId"];
			entity.PrescriptionId = (Convert.IsDBNull(dataRow["PrescriptionID"]))?string.Empty:(System.String)dataRow["PrescriptionID"];
			entity.Sq = (Convert.IsDBNull(dataRow["Sq"]))?(int)0:(System.Int32)dataRow["Sq"];
			entity.DrugId = (Convert.IsDBNull(dataRow["DrugId"]))?string.Empty:(System.String)dataRow["DrugId"];
			entity.DrugName = (Convert.IsDBNull(dataRow["DrugName"]))?string.Empty:(System.String)dataRow["DrugName"];
			entity.Unit = (Convert.IsDBNull(dataRow["Unit"]))?string.Empty:(System.String)dataRow["Unit"];
			entity.UnitVn = (Convert.IsDBNull(dataRow["UnitVN"]))?string.Empty:(System.String)dataRow["UnitVN"];
			entity.Remark = (Convert.IsDBNull(dataRow["Remark"]))?string.Empty:(System.String)dataRow["Remark"];
			entity.Dosage = (Convert.IsDBNull(dataRow["Dosage"]))?string.Empty:(System.String)dataRow["Dosage"];
			entity.Frequency = (Convert.IsDBNull(dataRow["Frequency"]))?string.Empty:(System.String)dataRow["Frequency"];
			entity.VnMeaning = (Convert.IsDBNull(dataRow["VN_meaning"]))?string.Empty:(System.String)dataRow["VN_meaning"];
			entity.Duration = (Convert.IsDBNull(dataRow["Duration"]))?string.Empty:(System.String)dataRow["Duration"];
			entity.TotalUnit = (Convert.IsDBNull(dataRow["TotalUnit"]))?string.Empty:(System.String)dataRow["TotalUnit"];
			entity.Expr1 = (Convert.IsDBNull(dataRow["Expr1"]))?string.Empty:(System.String)dataRow["Expr1"];
			entity.Meaning = (Convert.IsDBNull(dataRow["meaning"]))?string.Empty:(System.String)dataRow["meaning"];
			entity.Abbre = (Convert.IsDBNull(dataRow["abbre"]))?string.Empty:(System.String)dataRow["abbre"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrEPresDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailFilterBuilder : SqlFilterBuilder<VrEPresDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilterBuilder class.
		/// </summary>
		public VrEPresDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrEPresDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrEPresDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrEPresDetailFilterBuilder

	#region VrEPresDetailParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailParameterBuilder : ParameterizedSqlFilterBuilder<VrEPresDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailParameterBuilder class.
		/// </summary>
		public VrEPresDetailParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrEPresDetailParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrEPresDetailParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrEPresDetailParameterBuilder
	
	#region VrEPresDetailSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrEPresDetailSortBuilder : SqlSortBuilder<VrEPresDetailColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailSqlSortBuilder class.
		/// </summary>
		public VrEPresDetailSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrEPresDetailSortBuilder

} // end namespace
