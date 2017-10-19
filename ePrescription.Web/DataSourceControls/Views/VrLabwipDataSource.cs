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
	/// Represents the DataRepository.VrLabwipProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrLabwipDataSourceDesigner))]
	public class VrLabwipDataSource : ReadOnlyDataSource<VrLabwip>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabwipDataSource class.
		/// </summary>
		public VrLabwipDataSource() : base(DataRepository.VrLabwipProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrLabwipDataSourceView used by the VrLabwipDataSource.
		/// </summary>
		protected VrLabwipDataSourceView VrLabwipView
		{
			get { return ( View as VrLabwipDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrLabwipDataSourceView class that is to be
		/// used by the VrLabwipDataSource.
		/// </summary>
		/// <returns>An instance of the VrLabwipDataSourceView class.</returns>
		protected override BaseDataSourceView<VrLabwip, Object> GetNewDataSourceView()
		{
			return new VrLabwipDataSourceView(this, DefaultViewName);
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
	/// Supports the VrLabwipDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrLabwipDataSourceView : ReadOnlyDataSourceView<VrLabwip>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabwipDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrLabwipDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrLabwipDataSourceView(VrLabwipDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrLabwipDataSource VrLabwipOwner
		{
			get { return Owner as VrLabwipDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrLabwipProviderBase VrLabwipProvider
		{
			get { return Provider as VrLabwipProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrLabwipDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrLabwipDataSource class.
	/// </summary>
	public class VrLabwipDataSourceDesigner : ReadOnlyDataSourceDesigner<VrLabwip>
	{
	}

	#endregion VrLabwipDataSourceDesigner

	#region VrLabwipFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabwipFilter : SqlFilter<VrLabwipColumn>
	{
	}

	#endregion VrLabwipFilter

	#region VrLabwipExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabwipExpressionBuilder : SqlExpressionBuilder<VrLabwipColumn>
	{
	}
	
	#endregion VrLabwipExpressionBuilder		
}

