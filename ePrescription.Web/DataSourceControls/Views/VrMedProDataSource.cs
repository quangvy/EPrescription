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
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the VrMedProDataSource control invokes to retrieve data.
		/// </summary>
		public new VrMedProSelectMethod SelectMethod
		{
			get
			{
				VrMedProSelectMethod selectMethod = VrMedProSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (VrMedProSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
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
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal new VrMedProSelectMethod SelectMethod
		{
			get { return VrMedProOwner.SelectMethod; }
			set { VrMedProOwner.SelectMethod = value; }
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
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
	    /// <param name="values"></param>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<VrMedPro> GetSelectData(IDictionary values, out int count)
		{	
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			
			IList<VrMedPro> results = null;
			// VrMedPro item;
			count = 0;
			
			System.String sp10_Descriptiontion;

			switch ( SelectMethod )
			{
				case VrMedProSelectMethod.Get:
					results = VrMedProProvider.Get(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
                    break;
				case VrMedProSelectMethod.GetPaged:
					results = VrMedProProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case VrMedProSelectMethod.GetAll:
					results = VrMedProProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case VrMedProSelectMethod.Find:
					results = VrMedProProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
                    break;
				// Custom
				case VrMedProSelectMethod.GetByDescription:
					sp10_Descriptiontion = (System.String) EntityUtil.ChangeType(values["Descriptiontion"], typeof(System.String));
					results = VrMedProProvider.GetByDescription(GetTransactionManager(), StartIndex, PageSize, sp10_Descriptiontion);
					break;
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;
				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}				
			}
			
			return results;
		}
		
		#endregion Methods
	}

	#region VrMedProSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the VrMedProDataSource.SelectMethod property.
	/// </summary>
	public enum VrMedProSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByDescription method.
		/// </summary>
		GetByDescription
	}
	
	#endregion VrMedProSelectMethod
	
	#region VrMedProDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VrMedProDataSource class.
	/// </summary>
	public class VrMedProDataSourceDesigner : ReadOnlyDataSourceDesigner<VrMedPro>
	{
		/// <summary>
		/// Initializes a new instance of the VrMedProDataSourceDesigner class.
		/// </summary>
		public VrMedProDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public new VrMedProSelectMethod SelectMethod
		{
			get { return ((VrMedProDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new VrMedProDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region VrMedProDataSourceActionList

	/// <summary>
	/// Supports the VrMedProDataSourceDesigner class.
	/// </summary>
	internal class VrMedProDataSourceActionList : DesignerActionList
	{
		private VrMedProDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the VrMedProDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public VrMedProDataSourceActionList(VrMedProDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VrMedProSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion VrMedProDataSourceActionList

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

