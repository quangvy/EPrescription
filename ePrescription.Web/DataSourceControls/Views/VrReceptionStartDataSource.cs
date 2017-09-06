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
	/// Represents the DataRepository.VrReceptionStartProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrReceptionStartDataSourceDesigner))]
	public class VrReceptionStartDataSource : ReadOnlyDataSource<VrReceptionStart>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartDataSource class.
		/// </summary>
		public VrReceptionStartDataSource() : base(DataRepository.VrReceptionStartProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrReceptionStartDataSourceView used by the VrReceptionStartDataSource.
		/// </summary>
		protected VrReceptionStartDataSourceView VrReceptionStartView
		{
			get { return ( View as VrReceptionStartDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrReceptionStartDataSourceView class that is to be
		/// used by the VrReceptionStartDataSource.
		/// </summary>
		/// <returns>An instance of the VrReceptionStartDataSourceView class.</returns>
		protected override BaseDataSourceView<VrReceptionStart, Object> GetNewDataSourceView()
		{
			return new VrReceptionStartDataSourceView(this, DefaultViewName);
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
	/// Supports the VrReceptionStartDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrReceptionStartDataSourceView : ReadOnlyDataSourceView<VrReceptionStart>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrReceptionStartDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrReceptionStartDataSourceView(VrReceptionStartDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrReceptionStartDataSource VrReceptionStartOwner
		{
			get { return Owner as VrReceptionStartDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrReceptionStartProviderBase VrReceptionStartProvider
		{
			get { return Provider as VrReceptionStartProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrReceptionStartDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrReceptionStartDataSource class.
	/// </summary>
	public class VrReceptionStartDataSourceDesigner : ReadOnlyDataSourceDesigner<VrReceptionStart>
	{
	}

	#endregion VrReceptionStartDataSourceDesigner

	#region VrReceptionStartFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartFilter : SqlFilter<VrReceptionStartColumn>
	{
	}

	#endregion VrReceptionStartFilter

	#region VrReceptionStartExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartExpressionBuilder : SqlExpressionBuilder<VrReceptionStartColumn>
	{
	}
	
	#endregion VrReceptionStartExpressionBuilder		
}

