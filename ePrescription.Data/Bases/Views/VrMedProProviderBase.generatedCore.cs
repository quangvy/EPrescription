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
	/// This class is the base class for any <see cref="VrMedProProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrMedProProviderBaseCore : EntityViewProviderBase<VrMedPro>
	{
		#region Custom Methods
		
		
		#region _VR_MedPro_GetByDescription
		
		/// <summary>
		///	This method wrap the '_VR_MedPro_GetByDescription' stored procedure. 
		/// </summary>
		/// <param name="descriptiontion"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDescription(System.String descriptiontion)
		{
			return GetByDescription(null, 0, int.MaxValue , descriptiontion);
		}
		
		/// <summary>
		///	This method wrap the '_VR_MedPro_GetByDescription' stored procedure. 
		/// </summary>
		/// <param name="descriptiontion"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDescription(int start, int pageLength, System.String descriptiontion)
		{
			return GetByDescription(null, start, pageLength , descriptiontion);
		}
				
		/// <summary>
		///	This method wrap the '_VR_MedPro_GetByDescription' stored procedure. 
		/// </summary>
		/// <param name="descriptiontion"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDescription(TransactionManager transactionManager, System.String descriptiontion)
		{
			return GetByDescription(transactionManager, 0, int.MaxValue , descriptiontion);
		}
		
		/// <summary>
		///	This method wrap the '_VR_MedPro_GetByDescription' stored procedure. 
		/// </summary>
		/// <param name="descriptiontion"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDescription(TransactionManager transactionManager, int start, int pageLength, System.String descriptiontion);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrMedPro&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrMedPro&gt;"/></returns>
		protected static VList&lt;VrMedPro&gt; Fill(DataSet dataSet, VList<VrMedPro> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrMedPro>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrMedPro&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrMedPro>"/></returns>
		protected static VList&lt;VrMedPro&gt; Fill(DataTable dataTable, VList<VrMedPro> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrMedPro c = new VrMedPro();
					c.ProCode = (Convert.IsDBNull(row["PRO_CODE"]))?string.Empty:(System.String)row["PRO_CODE"];
					c.Description = (Convert.IsDBNull(row["Description"]))?string.Empty:(System.String)row["Description"];
					c.MainArea = (Convert.IsDBNull(row["MAIN_AREA"]))?string.Empty:(System.String)row["MAIN_AREA"];
					c.PubPrice = (Convert.IsDBNull(row["PUB_PRICE"]))?0.0m:(System.Decimal)row["PUB_PRICE"];
					c.SampleType = (Convert.IsDBNull(row["SampleType"]))?string.Empty:(System.String)row["SampleType"];
					c.ProviderType = (Convert.IsDBNull(row["ProviderType"]))?string.Empty:(System.String)row["ProviderType"];
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
		/// Fill an <see cref="VList&lt;VrMedPro&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrMedPro&gt;"/></returns>
		protected VList<VrMedPro> Fill(IDataReader reader, VList<VrMedPro> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrMedPro entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrMedPro>("VrMedPro",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrMedPro();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ProCode = (System.String)reader[((int)VrMedProColumn.ProCode)];
					//entity.ProCode = (Convert.IsDBNull(reader["PRO_CODE"]))?string.Empty:(System.String)reader["PRO_CODE"];
					entity.Description = (reader.IsDBNull(((int)VrMedProColumn.Description)))?null:(System.String)reader[((int)VrMedProColumn.Description)];
					//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
					entity.MainArea = (reader.IsDBNull(((int)VrMedProColumn.MainArea)))?null:(System.String)reader[((int)VrMedProColumn.MainArea)];
					//entity.MainArea = (Convert.IsDBNull(reader["MAIN_AREA"]))?string.Empty:(System.String)reader["MAIN_AREA"];
					entity.PubPrice = (System.Decimal)reader[((int)VrMedProColumn.PubPrice)];
					//entity.PubPrice = (Convert.IsDBNull(reader["PUB_PRICE"]))?0.0m:(System.Decimal)reader["PUB_PRICE"];
					entity.SampleType = (reader.IsDBNull(((int)VrMedProColumn.SampleType)))?null:(System.String)reader[((int)VrMedProColumn.SampleType)];
					//entity.SampleType = (Convert.IsDBNull(reader["SampleType"]))?string.Empty:(System.String)reader["SampleType"];
					entity.ProviderType = (reader.IsDBNull(((int)VrMedProColumn.ProviderType)))?null:(System.String)reader[((int)VrMedProColumn.ProviderType)];
					//entity.ProviderType = (Convert.IsDBNull(reader["ProviderType"]))?string.Empty:(System.String)reader["ProviderType"];
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
		/// Refreshes the <see cref="VrMedPro"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrMedPro"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrMedPro entity)
		{
			reader.Read();
			entity.ProCode = (System.String)reader[((int)VrMedProColumn.ProCode)];
			//entity.ProCode = (Convert.IsDBNull(reader["PRO_CODE"]))?string.Empty:(System.String)reader["PRO_CODE"];
			entity.Description = (reader.IsDBNull(((int)VrMedProColumn.Description)))?null:(System.String)reader[((int)VrMedProColumn.Description)];
			//entity.Description = (Convert.IsDBNull(reader["Description"]))?string.Empty:(System.String)reader["Description"];
			entity.MainArea = (reader.IsDBNull(((int)VrMedProColumn.MainArea)))?null:(System.String)reader[((int)VrMedProColumn.MainArea)];
			//entity.MainArea = (Convert.IsDBNull(reader["MAIN_AREA"]))?string.Empty:(System.String)reader["MAIN_AREA"];
			entity.PubPrice = (System.Decimal)reader[((int)VrMedProColumn.PubPrice)];
			//entity.PubPrice = (Convert.IsDBNull(reader["PUB_PRICE"]))?0.0m:(System.Decimal)reader["PUB_PRICE"];
			entity.SampleType = (reader.IsDBNull(((int)VrMedProColumn.SampleType)))?null:(System.String)reader[((int)VrMedProColumn.SampleType)];
			//entity.SampleType = (Convert.IsDBNull(reader["SampleType"]))?string.Empty:(System.String)reader["SampleType"];
			entity.ProviderType = (reader.IsDBNull(((int)VrMedProColumn.ProviderType)))?null:(System.String)reader[((int)VrMedProColumn.ProviderType)];
			//entity.ProviderType = (Convert.IsDBNull(reader["ProviderType"]))?string.Empty:(System.String)reader["ProviderType"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrMedPro"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrMedPro"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrMedPro entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ProCode = (Convert.IsDBNull(dataRow["PRO_CODE"]))?string.Empty:(System.String)dataRow["PRO_CODE"];
			entity.Description = (Convert.IsDBNull(dataRow["Description"]))?string.Empty:(System.String)dataRow["Description"];
			entity.MainArea = (Convert.IsDBNull(dataRow["MAIN_AREA"]))?string.Empty:(System.String)dataRow["MAIN_AREA"];
			entity.PubPrice = (Convert.IsDBNull(dataRow["PUB_PRICE"]))?0.0m:(System.Decimal)dataRow["PUB_PRICE"];
			entity.SampleType = (Convert.IsDBNull(dataRow["SampleType"]))?string.Empty:(System.String)dataRow["SampleType"];
			entity.ProviderType = (Convert.IsDBNull(dataRow["ProviderType"]))?string.Empty:(System.String)dataRow["ProviderType"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrMedProFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProFilterBuilder : SqlFilterBuilder<VrMedProColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProFilterBuilder class.
		/// </summary>
		public VrMedProFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrMedProFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrMedProFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrMedProFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrMedProFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrMedProFilterBuilder

	#region VrMedProParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProParameterBuilder : ParameterizedSqlFilterBuilder<VrMedProColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProParameterBuilder class.
		/// </summary>
		public VrMedProParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrMedProParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrMedProParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrMedProParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrMedProParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrMedProParameterBuilder
	
	#region VrMedProSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrMedProSortBuilder : SqlSortBuilder<VrMedProColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProSqlSortBuilder class.
		/// </summary>
		public VrMedProSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrMedProSortBuilder

} // end namespace
