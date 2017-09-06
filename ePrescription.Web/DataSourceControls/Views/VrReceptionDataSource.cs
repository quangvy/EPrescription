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
	/// Represents the DataRepository.VrReceptionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrReceptionDataSourceDesigner))]
	public class VrReceptionDataSource : ReadOnlyDataSource<VrReception>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDataSource class.
		/// </summary>
		public VrReceptionDataSource() : base(DataRepository.VrReceptionProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrReceptionDataSourceView used by the VrReceptionDataSource.
		/// </summary>
		protected VrReceptionDataSourceView VrReceptionView
		{
			get { return ( View as VrReceptionDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrReceptionDataSourceView class that is to be
		/// used by the VrReceptionDataSource.
		/// </summary>
		/// <returns>An instance of the VrReceptionDataSourceView class.</returns>
		protected override BaseDataSourceView<VrReception, Object> GetNewDataSourceView()
		{
			return new VrReceptionDataSourceView(this, DefaultViewName);
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
	/// Supports the VrReceptionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrReceptionDataSourceView : ReadOnlyDataSourceView<VrReception>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrReceptionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrReceptionDataSourceView(VrReceptionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrReceptionDataSource VrReceptionOwner
		{
			get { return Owner as VrReceptionDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrReceptionProviderBase VrReceptionProvider
		{
			get { return Provider as VrReceptionProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrReceptionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrReceptionDataSource class.
	/// </summary>
	public class VrReceptionDataSourceDesigner : ReadOnlyDataSourceDesigner<VrReception>
	{
	}

	#endregion VrReceptionDataSourceDesigner

	#region VrReceptionFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionFilter : SqlFilter<VrReceptionColumn>
	{
	}

	#endregion VrReceptionFilter

	#region VrReceptionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionExpressionBuilder : SqlExpressionBuilder<VrReceptionColumn>
	{
	}
	
	#endregion VrReceptionExpressionBuilder		
}

