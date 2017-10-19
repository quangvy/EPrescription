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
	/// Represents the DataRepository.VrNurseProcessedPatientsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(VrNurseProcessedPatientsDataSourceDesigner))]
	public class VrNurseProcessedPatientsDataSource : ReadOnlyDataSource<VrNurseProcessedPatients>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsDataSource class.
		/// </summary>
		public VrNurseProcessedPatientsDataSource() : base(DataRepository.VrNurseProcessedPatientsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VrNurseProcessedPatientsDataSourceView used by the VrNurseProcessedPatientsDataSource.
		/// </summary>
		protected VrNurseProcessedPatientsDataSourceView VrNurseProcessedPatientsView
		{
			get { return ( View as VrNurseProcessedPatientsDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VrNurseProcessedPatientsDataSourceView class that is to be
		/// used by the VrNurseProcessedPatientsDataSource.
		/// </summary>
		/// <returns>An instance of the VrNurseProcessedPatientsDataSourceView class.</returns>
		protected override BaseDataSourceView<VrNurseProcessedPatients, Object> GetNewDataSourceView()
		{
			return new VrNurseProcessedPatientsDataSourceView(this, DefaultViewName);
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
	/// Supports the VrNurseProcessedPatientsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VrNurseProcessedPatientsDataSourceView : ReadOnlyDataSourceView<VrNurseProcessedPatients>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VrNurseProcessedPatientsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VrNurseProcessedPatientsDataSourceView(VrNurseProcessedPatientsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VrNurseProcessedPatientsDataSource VrNurseProcessedPatientsOwner
		{
			get { return Owner as VrNurseProcessedPatientsDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VrNurseProcessedPatientsProviderBase VrNurseProcessedPatientsProvider
		{
			get { return Provider as VrNurseProcessedPatientsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region VrNurseProcessedPatientsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrNurseProcessedPatientsDataSource class.
	/// </summary>
	public class VrNurseProcessedPatientsDataSourceDesigner : ReadOnlyDataSourceDesigner<VrNurseProcessedPatients>
	{
	}

	#endregion VrNurseProcessedPatientsDataSourceDesigner

	#region VrNurseProcessedPatientsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsFilter : SqlFilter<VrNurseProcessedPatientsColumn>
	{
	}

	#endregion VrNurseProcessedPatientsFilter

	#region VrNurseProcessedPatientsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsExpressionBuilder : SqlExpressionBuilder<VrNurseProcessedPatientsColumn>
	{
	}
	
	#endregion VrNurseProcessedPatientsExpressionBuilder		
}

