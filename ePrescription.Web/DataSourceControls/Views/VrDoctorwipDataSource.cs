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
	/// Represents the DataRepository.VrDoctorwipProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrDoctorwipDataSourceDesigner))]
	public class VrDoctorwipDataSource : ReadOnlyDataSource<VrDoctorwip>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipDataSource class.
		/// </summary>
		public VrDoctorwipDataSource() : base(DataRepository.VrDoctorwipProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrDoctorwipDataSourceView used by the VrDoctorwipDataSource.
		/// </summary>
		protected VrDoctorwipDataSourceView VrDoctorwipView
		{
			get { return ( View as VrDoctorwipDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrDoctorwipDataSourceView class that is to be
		/// used by the VrDoctorwipDataSource.
		/// </summary>
		/// <returns>An instance of the VrDoctorwipDataSourceView class.</returns>
		protected override BaseDataSourceView<VrDoctorwip, Object> GetNewDataSourceView()
		{
			return new VrDoctorwipDataSourceView(this, DefaultViewName);
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
	/// Supports the VrDoctorwipDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrDoctorwipDataSourceView : ReadOnlyDataSourceView<VrDoctorwip>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrDoctorwipDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrDoctorwipDataSourceView(VrDoctorwipDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrDoctorwipDataSource VrDoctorwipOwner
		{
			get { return Owner as VrDoctorwipDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrDoctorwipProviderBase VrDoctorwipProvider
		{
			get { return Provider as VrDoctorwipProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrDoctorwipDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrDoctorwipDataSource class.
	/// </summary>
	public class VrDoctorwipDataSourceDesigner : ReadOnlyDataSourceDesigner<VrDoctorwip>
	{
	}

	#endregion VrDoctorwipDataSourceDesigner

	#region VrDoctorwipFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorwipFilter : SqlFilter<VrDoctorwipColumn>
	{
	}

	#endregion VrDoctorwipFilter

	#region VrDoctorwipExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorwipExpressionBuilder : SqlExpressionBuilder<VrDoctorwipColumn>
	{
	}
	
	#endregion VrDoctorwipExpressionBuilder		
}

