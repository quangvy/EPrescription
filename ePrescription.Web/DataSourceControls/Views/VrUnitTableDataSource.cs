#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using ePrescription.Entities;
using ePrescription.Data;
using ePrescription.Data.Bases;
#endregion

namespace ePrescription.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.VrUnitTableProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrUnitTableDataSourceDesigner))]
	public class VrUnitTableDataSource : ReadOnlyDataSource<VrUnitTable>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableDataSource class.
		/// </summary>
		public VrUnitTableDataSource() : base(DataRepository.VrUnitTableProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrUnitTableDataSourceView used by the VrUnitTableDataSource.
		/// </summary>
		protected VrUnitTableDataSourceView VrUnitTableView
		{
			get { return ( View as VrUnitTableDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrUnitTableDataSourceView class that is to be
		/// used by the VrUnitTableDataSource.
		/// </summary>
		/// <returns>An instance of the VrUnitTableDataSourceView class.</returns>
		protected override BaseDataSourceView<VrUnitTable, Object> GetNewDataSourceView()
		{
			return new VrUnitTableDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the VrUnitTableDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrUnitTableDataSourceView : ReadOnlyDataSourceView<VrUnitTable>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrUnitTableDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrUnitTableDataSourceView(VrUnitTableDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrUnitTableDataSource VrUnitTableOwner
		{
			get { return Owner as VrUnitTableDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrUnitTableProviderBase VrUnitTableProvider
		{
			get { return Provider as VrUnitTableProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrUnitTableDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrUnitTableDataSource class.
	/// </summary>
	public class VrUnitTableDataSourceDesigner : ReadOnlyDataSourceDesigner<VrUnitTable>
	{
	}

	#endregion VrUnitTableDataSourceDesigner

	#region VrUnitTableFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableFilter : SqlFilter<VrUnitTableColumn>
	{
	}

	#endregion VrUnitTableFilter

	#region VrUnitTableExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableExpressionBuilder : SqlExpressionBuilder<VrUnitTableColumn>
	{
	}
	
	#endregion VrUnitTableExpressionBuilder		
}

