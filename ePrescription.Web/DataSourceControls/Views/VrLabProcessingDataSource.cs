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
	/// Represents the DataRepository.VrLabProcessingProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrLabProcessingDataSourceDesigner))]
	public class VrLabProcessingDataSource : ReadOnlyDataSource<VrLabProcessing>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingDataSource class.
		/// </summary>
		public VrLabProcessingDataSource() : base(DataRepository.VrLabProcessingProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrLabProcessingDataSourceView used by the VrLabProcessingDataSource.
		/// </summary>
		protected VrLabProcessingDataSourceView VrLabProcessingView
		{
			get { return ( View as VrLabProcessingDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrLabProcessingDataSourceView class that is to be
		/// used by the VrLabProcessingDataSource.
		/// </summary>
		/// <returns>An instance of the VrLabProcessingDataSourceView class.</returns>
		protected override BaseDataSourceView<VrLabProcessing, Object> GetNewDataSourceView()
		{
			return new VrLabProcessingDataSourceView(this, DefaultViewName);
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
	/// Supports the VrLabProcessingDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrLabProcessingDataSourceView : ReadOnlyDataSourceView<VrLabProcessing>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrLabProcessingDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrLabProcessingDataSourceView(VrLabProcessingDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrLabProcessingDataSource VrLabProcessingOwner
		{
			get { return Owner as VrLabProcessingDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrLabProcessingProviderBase VrLabProcessingProvider
		{
			get { return Provider as VrLabProcessingProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrLabProcessingDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrLabProcessingDataSource class.
	/// </summary>
	public class VrLabProcessingDataSourceDesigner : ReadOnlyDataSourceDesigner<VrLabProcessing>
	{
	}

	#endregion VrLabProcessingDataSourceDesigner

	#region VrLabProcessingFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabProcessing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabProcessingFilter : SqlFilter<VrLabProcessingColumn>
	{
	}

	#endregion VrLabProcessingFilter

	#region VrLabProcessingExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabProcessing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabProcessingExpressionBuilder : SqlExpressionBuilder<VrLabProcessingColumn>
	{
	}
	
	#endregion VrLabProcessingExpressionBuilder		
}

