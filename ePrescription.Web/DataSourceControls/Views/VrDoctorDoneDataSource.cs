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
	/// Represents the DataRepository.VrDoctorDoneProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrDoctorDoneDataSourceDesigner))]
	public class VrDoctorDoneDataSource : ReadOnlyDataSource<VrDoctorDone>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneDataSource class.
		/// </summary>
		public VrDoctorDoneDataSource() : base(DataRepository.VrDoctorDoneProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrDoctorDoneDataSourceView used by the VrDoctorDoneDataSource.
		/// </summary>
		protected VrDoctorDoneDataSourceView VrDoctorDoneView
		{
			get { return ( View as VrDoctorDoneDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrDoctorDoneDataSourceView class that is to be
		/// used by the VrDoctorDoneDataSource.
		/// </summary>
		/// <returns>An instance of the VrDoctorDoneDataSourceView class.</returns>
		protected override BaseDataSourceView<VrDoctorDone, Object> GetNewDataSourceView()
		{
			return new VrDoctorDoneDataSourceView(this, DefaultViewName);
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
	/// Supports the VrDoctorDoneDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrDoctorDoneDataSourceView : ReadOnlyDataSourceView<VrDoctorDone>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrDoctorDoneDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrDoctorDoneDataSourceView(VrDoctorDoneDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrDoctorDoneDataSource VrDoctorDoneOwner
		{
			get { return Owner as VrDoctorDoneDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrDoctorDoneProviderBase VrDoctorDoneProvider
		{
			get { return Provider as VrDoctorDoneProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrDoctorDoneDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrDoctorDoneDataSource class.
	/// </summary>
	public class VrDoctorDoneDataSourceDesigner : ReadOnlyDataSourceDesigner<VrDoctorDone>
	{
	}

	#endregion VrDoctorDoneDataSourceDesigner

	#region VrDoctorDoneFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneFilter : SqlFilter<VrDoctorDoneColumn>
	{
	}

	#endregion VrDoctorDoneFilter

	#region VrDoctorDoneExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneExpressionBuilder : SqlExpressionBuilder<VrDoctorDoneColumn>
	{
	}
	
	#endregion VrDoctorDoneExpressionBuilder		
}

