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
	/// Represents the DataRepository.VrReceptionDoneProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrReceptionDoneDataSourceDesigner))]
	public class VrReceptionDoneDataSource : ReadOnlyDataSource<VrReceptionDone>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneDataSource class.
		/// </summary>
		public VrReceptionDoneDataSource() : base(DataRepository.VrReceptionDoneProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrReceptionDoneDataSourceView used by the VrReceptionDoneDataSource.
		/// </summary>
		protected VrReceptionDoneDataSourceView VrReceptionDoneView
		{
			get { return ( View as VrReceptionDoneDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrReceptionDoneDataSourceView class that is to be
		/// used by the VrReceptionDoneDataSource.
		/// </summary>
		/// <returns>An instance of the VrReceptionDoneDataSourceView class.</returns>
		protected override BaseDataSourceView<VrReceptionDone, Object> GetNewDataSourceView()
		{
			return new VrReceptionDoneDataSourceView(this, DefaultViewName);
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
	/// Supports the VrReceptionDoneDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrReceptionDoneDataSourceView : ReadOnlyDataSourceView<VrReceptionDone>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrReceptionDoneDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrReceptionDoneDataSourceView(VrReceptionDoneDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrReceptionDoneDataSource VrReceptionDoneOwner
		{
			get { return Owner as VrReceptionDoneDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrReceptionDoneProviderBase VrReceptionDoneProvider
		{
			get { return Provider as VrReceptionDoneProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrReceptionDoneDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrReceptionDoneDataSource class.
	/// </summary>
	public class VrReceptionDoneDataSourceDesigner : ReadOnlyDataSourceDesigner<VrReceptionDone>
	{
	}

	#endregion VrReceptionDoneDataSourceDesigner

	#region VrReceptionDoneFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneFilter : SqlFilter<VrReceptionDoneColumn>
	{
	}

	#endregion VrReceptionDoneFilter

	#region VrReceptionDoneExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneExpressionBuilder : SqlExpressionBuilder<VrReceptionDoneColumn>
	{
	}
	
	#endregion VrReceptionDoneExpressionBuilder		
}

