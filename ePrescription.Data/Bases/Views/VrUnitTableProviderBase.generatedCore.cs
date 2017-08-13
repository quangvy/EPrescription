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
	/// This class is the base class for any <see cref="VrUnitTableProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrUnitTableProviderBaseCore : EntityViewProviderBase<VrUnitTable>
	{
		#region Custom Methods
		
		
		#region _VR_UnitTable_Update
		
		/// <summary>
		///	This method wrap the '_VR_UnitTable_Update' stored procedure. 
		/// </summary>
		/// <param name="unit"> A <c>System.String</c> instance.</param>
		/// <param name="unitVn"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnit"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnitVn"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.String unit, System.String unitVn, System.String dosageUnit, System.String dosageUnitVn)
		{
			 Update(null, 0, int.MaxValue , unit, unitVn, dosageUnit, dosageUnitVn);
		}
		
		/// <summary>
		///	This method wrap the '_VR_UnitTable_Update' stored procedure. 
		/// </summary>
		/// <param name="unit"> A <c>System.String</c> instance.</param>
		/// <param name="unitVn"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnit"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnitVn"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.String unit, System.String unitVn, System.String dosageUnit, System.String dosageUnitVn)
		{
			 Update(null, start, pageLength , unit, unitVn, dosageUnit, dosageUnitVn);
		}
				
		/// <summary>
		///	This method wrap the '_VR_UnitTable_Update' stored procedure. 
		/// </summary>
		/// <param name="unit"> A <c>System.String</c> instance.</param>
		/// <param name="unitVn"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnit"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnitVn"> A <c>System.String</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.String unit, System.String unitVn, System.String dosageUnit, System.String dosageUnitVn)
		{
			 Update(transactionManager, 0, int.MaxValue , unit, unitVn, dosageUnit, dosageUnitVn);
		}
		
		/// <summary>
		///	This method wrap the '_VR_UnitTable_Update' stored procedure. 
		/// </summary>
		/// <param name="unit"> A <c>System.String</c> instance.</param>
		/// <param name="unitVn"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnit"> A <c>System.String</c> instance.</param>
		/// <param name="dosageUnitVn"> A <c>System.String</c> instance.</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength, System.String unit, System.String unitVn, System.String dosageUnit, System.String dosageUnitVn);
		
		#endregion

		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;VrUnitTable&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;VrUnitTable&gt;"/></returns>
		protected static VList&lt;VrUnitTable&gt; Fill(DataSet dataSet, VList<VrUnitTable> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<VrUnitTable>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;VrUnitTable&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<VrUnitTable>"/></returns>
		protected static VList&lt;VrUnitTable&gt; Fill(DataTable dataTable, VList<VrUnitTable> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					VrUnitTable c = new VrUnitTable();
					c.Unit = (Convert.IsDBNull(row["Unit"]))?string.Empty:(System.String)row["Unit"];
					c.UnitVn = (Convert.IsDBNull(row["UnitVN"]))?string.Empty:(System.String)row["UnitVN"];
					c.DosageUnit = (Convert.IsDBNull(row["DosageUnit"]))?string.Empty:(System.String)row["DosageUnit"];
					c.DosageUnitVn = (Convert.IsDBNull(row["DosageUnitVN"]))?string.Empty:(System.String)row["DosageUnitVN"];
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
		/// Fill an <see cref="VList&lt;VrUnitTable&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;VrUnitTable&gt;"/></returns>
		protected VList<VrUnitTable> Fill(IDataReader reader, VList<VrUnitTable> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					VrUnitTable entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<VrUnitTable>("VrUnitTable",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new VrUnitTable();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Unit = (System.String)reader[((int)VrUnitTableColumn.Unit)];
					//entity.Unit = (Convert.IsDBNull(reader["Unit"]))?string.Empty:(System.String)reader["Unit"];
					entity.UnitVn = (reader.IsDBNull(((int)VrUnitTableColumn.UnitVn)))?null:(System.String)reader[((int)VrUnitTableColumn.UnitVn)];
					//entity.UnitVn = (Convert.IsDBNull(reader["UnitVN"]))?string.Empty:(System.String)reader["UnitVN"];
					entity.DosageUnit = (reader.IsDBNull(((int)VrUnitTableColumn.DosageUnit)))?null:(System.String)reader[((int)VrUnitTableColumn.DosageUnit)];
					//entity.DosageUnit = (Convert.IsDBNull(reader["DosageUnit"]))?string.Empty:(System.String)reader["DosageUnit"];
					entity.DosageUnitVn = (reader.IsDBNull(((int)VrUnitTableColumn.DosageUnitVn)))?null:(System.String)reader[((int)VrUnitTableColumn.DosageUnitVn)];
					//entity.DosageUnitVn = (Convert.IsDBNull(reader["DosageUnitVN"]))?string.Empty:(System.String)reader["DosageUnitVN"];
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
		/// Refreshes the <see cref="VrUnitTable"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="VrUnitTable"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, VrUnitTable entity)
		{
			reader.Read();
			entity.Unit = (System.String)reader[((int)VrUnitTableColumn.Unit)];
			//entity.Unit = (Convert.IsDBNull(reader["Unit"]))?string.Empty:(System.String)reader["Unit"];
			entity.UnitVn = (reader.IsDBNull(((int)VrUnitTableColumn.UnitVn)))?null:(System.String)reader[((int)VrUnitTableColumn.UnitVn)];
			//entity.UnitVn = (Convert.IsDBNull(reader["UnitVN"]))?string.Empty:(System.String)reader["UnitVN"];
			entity.DosageUnit = (reader.IsDBNull(((int)VrUnitTableColumn.DosageUnit)))?null:(System.String)reader[((int)VrUnitTableColumn.DosageUnit)];
			//entity.DosageUnit = (Convert.IsDBNull(reader["DosageUnit"]))?string.Empty:(System.String)reader["DosageUnit"];
			entity.DosageUnitVn = (reader.IsDBNull(((int)VrUnitTableColumn.DosageUnitVn)))?null:(System.String)reader[((int)VrUnitTableColumn.DosageUnitVn)];
			//entity.DosageUnitVn = (Convert.IsDBNull(reader["DosageUnitVN"]))?string.Empty:(System.String)reader["DosageUnitVN"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="VrUnitTable"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="VrUnitTable"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, VrUnitTable entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Unit = (Convert.IsDBNull(dataRow["Unit"]))?string.Empty:(System.String)dataRow["Unit"];
			entity.UnitVn = (Convert.IsDBNull(dataRow["UnitVN"]))?string.Empty:(System.String)dataRow["UnitVN"];
			entity.DosageUnit = (Convert.IsDBNull(dataRow["DosageUnit"]))?string.Empty:(System.String)dataRow["DosageUnit"];
			entity.DosageUnitVn = (Convert.IsDBNull(dataRow["DosageUnitVN"]))?string.Empty:(System.String)dataRow["DosageUnitVN"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region VrUnitTableFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableFilterBuilder : SqlFilterBuilder<VrUnitTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilterBuilder class.
		/// </summary>
		public VrUnitTableFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrUnitTableFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrUnitTableFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrUnitTableFilterBuilder

	#region VrUnitTableParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableParameterBuilder : ParameterizedSqlFilterBuilder<VrUnitTableColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableParameterBuilder class.
		/// </summary>
		public VrUnitTableParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrUnitTableParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrUnitTableParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrUnitTableParameterBuilder
	
	#region VrUnitTableSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class VrUnitTableSortBuilder : SqlSortBuilder<VrUnitTableColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableSqlSortBuilder class.
		/// </summary>
		public VrUnitTableSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion VrUnitTableSortBuilder

} // end namespace
