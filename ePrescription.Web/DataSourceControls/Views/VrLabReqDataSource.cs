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
	/// Represents the DataRepository.VrLabReqProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrLabReqDataSourceDesigner))]
	public class VrLabReqDataSource : ReadOnlyDataSource<VrLabReq>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReqDataSource class.
		/// </summary>
		public VrLabReqDataSource() : base(DataRepository.VrLabReqProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrLabReqDataSourceView used by the VrLabReqDataSource.
		/// </summary>
		protected VrLabReqDataSourceView VrLabReqView
		{
			get { return ( View as VrLabReqDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrLabReqDataSourceView class that is to be
		/// used by the VrLabReqDataSource.
		/// </summary>
		/// <returns>An instance of the VrLabReqDataSourceView class.</returns>
		protected override BaseDataSourceView<VrLabReq, Object> GetNewDataSourceView()
		{
			return new VrLabReqDataSourceView(this, DefaultViewName);
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
	/// Supports the VrLabReqDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrLabReqDataSourceView : ReadOnlyDataSourceView<VrLabReq>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReqDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrLabReqDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrLabReqDataSourceView(VrLabReqDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrLabReqDataSource VrLabReqOwner
		{
			get { return Owner as VrLabReqDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrLabReqProviderBase VrLabReqProvider
		{
			get { return Provider as VrLabReqProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrLabReqDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrLabReqDataSource class.
	/// </summary>
	public class VrLabReqDataSourceDesigner : ReadOnlyDataSourceDesigner<VrLabReq>
	{
	}

	#endregion VrLabReqDataSourceDesigner

	#region VrLabReqFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReq"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReqFilter : SqlFilter<VrLabReqColumn>
	{
	}

	#endregion VrLabReqFilter

	#region VrLabReqExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReq"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReqExpressionBuilder : SqlExpressionBuilder<VrLabReqColumn>
	{
	}
	
	#endregion VrLabReqExpressionBuilder		
}

