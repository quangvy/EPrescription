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
	/// Represents the DataRepository.VrEPresDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrEPresDetailDataSourceDesigner))]
	public class VrEPresDetailDataSource : ReadOnlyDataSource<VrEPresDetail>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailDataSource class.
		/// </summary>
		public VrEPresDetailDataSource() : base(DataRepository.VrEPresDetailProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrEPresDetailDataSourceView used by the VrEPresDetailDataSource.
		/// </summary>
		protected VrEPresDetailDataSourceView VrEPresDetailView
		{
			get { return ( View as VrEPresDetailDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrEPresDetailDataSourceView class that is to be
		/// used by the VrEPresDetailDataSource.
		/// </summary>
		/// <returns>An instance of the VrEPresDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<VrEPresDetail, Object> GetNewDataSourceView()
		{
			return new VrEPresDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the VrEPresDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrEPresDetailDataSourceView : ReadOnlyDataSourceView<VrEPresDetail>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrEPresDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrEPresDetailDataSourceView(VrEPresDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrEPresDetailDataSource VrEPresDetailOwner
		{
			get { return Owner as VrEPresDetailDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrEPresDetailProviderBase VrEPresDetailProvider
		{
			get { return Provider as VrEPresDetailProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrEPresDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrEPresDetailDataSource class.
	/// </summary>
	public class VrEPresDetailDataSourceDesigner : ReadOnlyDataSourceDesigner<VrEPresDetail>
	{
	}

	#endregion VrEPresDetailDataSourceDesigner

	#region VrEPresDetailFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailFilter : SqlFilter<VrEPresDetailColumn>
	{
	}

	#endregion VrEPresDetailFilter

	#region VrEPresDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailExpressionBuilder : SqlExpressionBuilder<VrEPresDetailColumn>
	{
	}
	
	#endregion VrEPresDetailExpressionBuilder		
}

