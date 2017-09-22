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
	/// Represents the DataRepository.VrTidChargedCodeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrTidChargedCodeDataSourceDesigner))]
	public class VrTidChargedCodeDataSource : ReadOnlyDataSource<VrTidChargedCode>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeDataSource class.
		/// </summary>
		public VrTidChargedCodeDataSource() : base(DataRepository.VrTidChargedCodeProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrTidChargedCodeDataSourceView used by the VrTidChargedCodeDataSource.
		/// </summary>
		protected VrTidChargedCodeDataSourceView VrTidChargedCodeView
		{
			get { return ( View as VrTidChargedCodeDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrTidChargedCodeDataSourceView class that is to be
		/// used by the VrTidChargedCodeDataSource.
		/// </summary>
		/// <returns>An instance of the VrTidChargedCodeDataSourceView class.</returns>
		protected override BaseDataSourceView<VrTidChargedCode, Object> GetNewDataSourceView()
		{
			return new VrTidChargedCodeDataSourceView(this, DefaultViewName);
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
	/// Supports the VrTidChargedCodeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrTidChargedCodeDataSourceView : ReadOnlyDataSourceView<VrTidChargedCode>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrTidChargedCodeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrTidChargedCodeDataSourceView(VrTidChargedCodeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrTidChargedCodeDataSource VrTidChargedCodeOwner
		{
			get { return Owner as VrTidChargedCodeDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrTidChargedCodeProviderBase VrTidChargedCodeProvider
		{
			get { return Provider as VrTidChargedCodeProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrTidChargedCodeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrTidChargedCodeDataSource class.
	/// </summary>
	public class VrTidChargedCodeDataSourceDesigner : ReadOnlyDataSourceDesigner<VrTidChargedCode>
	{
	}

	#endregion VrTidChargedCodeDataSourceDesigner

	#region VrTidChargedCodeFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeFilter : SqlFilter<VrTidChargedCodeColumn>
	{
	}

	#endregion VrTidChargedCodeFilter

	#region VrTidChargedCodeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeExpressionBuilder : SqlExpressionBuilder<VrTidChargedCodeColumn>
	{
	}
	
	#endregion VrTidChargedCodeExpressionBuilder		
}

