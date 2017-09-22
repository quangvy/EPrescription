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
	/// Represents the DataRepository.VrLabResultProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrLabResultDataSourceDesigner))]
	public class VrLabResultDataSource : ReadOnlyDataSource<VrLabResult>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultDataSource class.
		/// </summary>
		public VrLabResultDataSource() : base(DataRepository.VrLabResultProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrLabResultDataSourceView used by the VrLabResultDataSource.
		/// </summary>
		protected VrLabResultDataSourceView VrLabResultView
		{
			get { return ( View as VrLabResultDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrLabResultDataSourceView class that is to be
		/// used by the VrLabResultDataSource.
		/// </summary>
		/// <returns>An instance of the VrLabResultDataSourceView class.</returns>
		protected override BaseDataSourceView<VrLabResult, Object> GetNewDataSourceView()
		{
			return new VrLabResultDataSourceView(this, DefaultViewName);
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
	/// Supports the VrLabResultDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrLabResultDataSourceView : ReadOnlyDataSourceView<VrLabResult>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrLabResultDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrLabResultDataSourceView(VrLabResultDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrLabResultDataSource VrLabResultOwner
		{
			get { return Owner as VrLabResultDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrLabResultProviderBase VrLabResultProvider
		{
			get { return Provider as VrLabResultProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrLabResultDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrLabResultDataSource class.
	/// </summary>
	public class VrLabResultDataSourceDesigner : ReadOnlyDataSourceDesigner<VrLabResult>
	{
	}

	#endregion VrLabResultDataSourceDesigner

	#region VrLabResultFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultFilter : SqlFilter<VrLabResultColumn>
	{
	}

	#endregion VrLabResultFilter

	#region VrLabResultExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultExpressionBuilder : SqlExpressionBuilder<VrLabResultColumn>
	{
	}
	
	#endregion VrLabResultExpressionBuilder		
}

