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
	/// Represents the DataRepository.VrMedProProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrMedProDataSourceDesigner))]
	public class VrMedProDataSource : ReadOnlyDataSource<VrMedPro>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProDataSource class.
		/// </summary>
		public VrMedProDataSource() : base(DataRepository.VrMedProProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrMedProDataSourceView used by the VrMedProDataSource.
		/// </summary>
		protected VrMedProDataSourceView VrMedProView
		{
			get { return ( View as VrMedProDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrMedProDataSourceView class that is to be
		/// used by the VrMedProDataSource.
		/// </summary>
		/// <returns>An instance of the VrMedProDataSourceView class.</returns>
		protected override BaseDataSourceView<VrMedPro, Object> GetNewDataSourceView()
		{
			return new VrMedProDataSourceView(this, DefaultViewName);
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
	/// Supports the VrMedProDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrMedProDataSourceView : ReadOnlyDataSourceView<VrMedPro>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrMedProDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrMedProDataSourceView(VrMedProDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrMedProDataSource VrMedProOwner
		{
			get { return Owner as VrMedProDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrMedProProviderBase VrMedProProvider
		{
			get { return Provider as VrMedProProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrMedProDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrMedProDataSource class.
	/// </summary>
	public class VrMedProDataSourceDesigner : ReadOnlyDataSourceDesigner<VrMedPro>
	{
	}

	#endregion VrMedProDataSourceDesigner

	#region VrMedProFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProFilter : SqlFilter<VrMedProColumn>
	{
	}

	#endregion VrMedProFilter

	#region VrMedProExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProExpressionBuilder : SqlExpressionBuilder<VrMedProColumn>
	{
	}
	
	#endregion VrMedProExpressionBuilder		
}

