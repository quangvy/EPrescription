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
	/// Represents the DataRepository.VrLabReceiveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrLabReceiveDataSourceDesigner))]
	public class VrLabReceiveDataSource : ReadOnlyDataSource<VrLabReceive>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveDataSource class.
		/// </summary>
		public VrLabReceiveDataSource() : base(DataRepository.VrLabReceiveProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrLabReceiveDataSourceView used by the VrLabReceiveDataSource.
		/// </summary>
		protected VrLabReceiveDataSourceView VrLabReceiveView
		{
			get { return ( View as VrLabReceiveDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrLabReceiveDataSourceView class that is to be
		/// used by the VrLabReceiveDataSource.
		/// </summary>
		/// <returns>An instance of the VrLabReceiveDataSourceView class.</returns>
		protected override BaseDataSourceView<VrLabReceive, Object> GetNewDataSourceView()
		{
			return new VrLabReceiveDataSourceView(this, DefaultViewName);
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
	/// Supports the VrLabReceiveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrLabReceiveDataSourceView : ReadOnlyDataSourceView<VrLabReceive>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrLabReceiveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrLabReceiveDataSourceView(VrLabReceiveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrLabReceiveDataSource VrLabReceiveOwner
		{
			get { return Owner as VrLabReceiveDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrLabReceiveProviderBase VrLabReceiveProvider
		{
			get { return Provider as VrLabReceiveProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrLabReceiveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrLabReceiveDataSource class.
	/// </summary>
	public class VrLabReceiveDataSourceDesigner : ReadOnlyDataSourceDesigner<VrLabReceive>
	{
	}

	#endregion VrLabReceiveDataSourceDesigner

	#region VrLabReceiveFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReceive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReceiveFilter : SqlFilter<VrLabReceiveColumn>
	{
	}

	#endregion VrLabReceiveFilter

	#region VrLabReceiveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReceive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReceiveExpressionBuilder : SqlExpressionBuilder<VrLabReceiveColumn>
	{
	}
	
	#endregion VrLabReceiveExpressionBuilder		
}

