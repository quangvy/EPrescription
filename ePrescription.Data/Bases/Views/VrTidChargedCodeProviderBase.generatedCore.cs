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
	/// This class is the base class for any <see cref="VrTidChargedCodeProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrTidChargedCodeProviderBaseCore : EntityViewProviderBase<VrTidChargedCode>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrTidChargedCode&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrTidChargedCode&gt;"/></returns>
		protected static VList&lt;VrTidChargedCode&gt; Fill(DataSet dataSet, VList<VrTidChargedCode> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrTidChargedCode>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrTidChargedCode&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrTidChargedCode>"/></returns>
		protected static VList&lt;VrTidChargedCode&gt; Fill(DataTable dataTable, VList<VrTidChargedCode> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrTidChargedCode c = new VrTidChargedCode();
					c.Tid = (Convert.IsDBNull(row["TID"]))?string.Empty:(System.String)row["TID"];
					c.ProcedureCodes = (Convert.IsDBNull(row["ProcedureCodes"]))?string.Empty:(System.String)row["ProcedureCodes"];
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
		/// Fill an <see cref="VList&lt;VrTidChargedCode&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrTidChargedCode&gt;"/></returns>
		protected VList<VrTidChargedCode> Fill(IDataReader reader, VList<VrTidChargedCode> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrTidChargedCode entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrTidChargedCode>("VrTidChargedCode",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrTidChargedCode();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Tid = (System.String)reader[((int)VrTidChargedCodeColumn.Tid)];
					//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
					entity.ProcedureCodes = (reader.IsDBNull(((int)VrTidChargedCodeColumn.ProcedureCodes)))?null:(System.String)reader[((int)VrTidChargedCodeColumn.ProcedureCodes)];
					//entity.ProcedureCodes = (Convert.IsDBNull(reader["ProcedureCodes"]))?string.Empty:(System.String)reader["ProcedureCodes"];
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
		/// Refreshes the <see cref="VrTidChargedCode"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrTidChargedCode"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrTidChargedCode entity)
		{
			reader.Read();
			entity.Tid = (System.String)reader[((int)VrTidChargedCodeColumn.Tid)];
			//entity.Tid = (Convert.IsDBNull(reader["TID"]))?string.Empty:(System.String)reader["TID"];
			entity.ProcedureCodes = (reader.IsDBNull(((int)VrTidChargedCodeColumn.ProcedureCodes)))?null:(System.String)reader[((int)VrTidChargedCodeColumn.ProcedureCodes)];
			//entity.ProcedureCodes = (Convert.IsDBNull(reader["ProcedureCodes"]))?string.Empty:(System.String)reader["ProcedureCodes"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrTidChargedCode"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrTidChargedCode"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrTidChargedCode entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Tid = (Convert.IsDBNull(dataRow["TID"]))?string.Empty:(System.String)dataRow["TID"];
			entity.ProcedureCodes = (Convert.IsDBNull(dataRow["ProcedureCodes"]))?string.Empty:(System.String)dataRow["ProcedureCodes"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrTidChargedCodeFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeFilterBuilder : SqlFilterBuilder<VrTidChargedCodeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilterBuilder class.
		/// </summary>
		public VrTidChargedCodeFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrTidChargedCodeFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrTidChargedCodeFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrTidChargedCodeFilterBuilder

	#region VrTidChargedCodeParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeParameterBuilder : ParameterizedSqlFilterBuilder<VrTidChargedCodeColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeParameterBuilder class.
		/// </summary>
		public VrTidChargedCodeParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrTidChargedCodeParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrTidChargedCodeParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrTidChargedCodeParameterBuilder
	
	#region VrTidChargedCodeSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrTidChargedCodeSortBuilder : SqlSortBuilder<VrTidChargedCodeColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeSqlSortBuilder class.
		/// </summary>
		public VrTidChargedCodeSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrTidChargedCodeSortBuilder

} // end namespace
