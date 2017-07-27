#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using ePrescription.Entities;
using ePrescription.Data;
using ePrescription.Data.Bases;
#endregion

namespace ePrescription.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.EPrescriptionDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EPrescriptionDetailDataSourceDesigner))]
	public class EPrescriptionDetailDataSource : ProviderDataSource<EPrescriptionDetail, EPrescriptionDetailKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailDataSource class.
		/// </summary>
		public EPrescriptionDetailDataSource() : base(DataRepository.EPrescriptionDetailProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EPrescriptionDetailDataSourceView used by the EPrescriptionDetailDataSource.
		/// </summary>
		protected EPrescriptionDetailDataSourceView EPrescriptionDetailView
		{
			get { return ( View as EPrescriptionDetailDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EPrescriptionDetailDataSource control invokes to retrieve data.
		/// </summary>
		public EPrescriptionDetailSelectMethod SelectMethod
		{
			get
			{
				EPrescriptionDetailSelectMethod selectMethod = EPrescriptionDetailSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EPrescriptionDetailSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EPrescriptionDetailDataSourceView class that is to be
		/// used by the EPrescriptionDetailDataSource.
		/// </summary>
		/// <returns>An instance of the EPrescriptionDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<EPrescriptionDetail, EPrescriptionDetailKey> GetNewDataSourceView()
		{
			return new EPrescriptionDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the EPrescriptionDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EPrescriptionDetailDataSourceView : ProviderDataSourceView<EPrescriptionDetail, EPrescriptionDetailKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EPrescriptionDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EPrescriptionDetailDataSourceView(EPrescriptionDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EPrescriptionDetailDataSource EPrescriptionDetailOwner
		{
			get { return Owner as EPrescriptionDetailDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EPrescriptionDetailSelectMethod SelectMethod
		{
			get { return EPrescriptionDetailOwner.SelectMethod; }
			set { EPrescriptionDetailOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EPrescriptionDetailProviderBase EPrescriptionDetailProvider
		{
			get { return Provider as EPrescriptionDetailProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EPrescriptionDetail> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EPrescriptionDetail> results = null;
			EPrescriptionDetail item;
			count = 0;
			
			System.Int64 _prescriptionDetailId;
			System.String _prescriptionId;

			switch ( SelectMethod )
			{
				case EPrescriptionDetailSelectMethod.Get:
					EPrescriptionDetailKey entityKey  = new EPrescriptionDetailKey();
					entityKey.Load(values);
					item = EPrescriptionDetailProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<EPrescriptionDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EPrescriptionDetailSelectMethod.GetAll:
                    results = EPrescriptionDetailProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case EPrescriptionDetailSelectMethod.GetPaged:
					results = EPrescriptionDetailProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EPrescriptionDetailSelectMethod.Find:
					if ( FilterParameters != null )
						results = EPrescriptionDetailProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EPrescriptionDetailProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EPrescriptionDetailSelectMethod.GetByPrescriptionDetailId:
					_prescriptionDetailId = ( values["PrescriptionDetailId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["PrescriptionDetailId"], typeof(System.Int64)) : (long)0;
					item = EPrescriptionDetailProvider.GetByPrescriptionDetailId(GetTransactionManager(), _prescriptionDetailId);
					results = new TList<EPrescriptionDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EPrescriptionDetailSelectMethod.GetByPrescriptionId:
					_prescriptionId = ( values["PrescriptionId"] != null ) ? (System.String) EntityUtil.ChangeType(values["PrescriptionId"], typeof(System.String)) : string.Empty;
					results = EPrescriptionDetailProvider.GetByPrescriptionId(GetTransactionManager(), _prescriptionId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
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
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == EPrescriptionDetailSelectMethod.Get || SelectMethod == EPrescriptionDetailSelectMethod.GetByPrescriptionDetailId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				EPrescriptionDetail entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					EPrescriptionDetailProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<EPrescriptionDetail> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			EPrescriptionDetailProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EPrescriptionDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EPrescriptionDetailDataSource class.
	/// </summary>
	public class EPrescriptionDetailDataSourceDesigner : ProviderDataSourceDesigner<EPrescriptionDetail, EPrescriptionDetailKey>
	{
		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailDataSourceDesigner class.
		/// </summary>
		public EPrescriptionDetailDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EPrescriptionDetailSelectMethod SelectMethod
		{
			get { return ((EPrescriptionDetailDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EPrescriptionDetailDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EPrescriptionDetailDataSourceActionList

	/// <summary>
	/// Supports the EPrescriptionDetailDataSourceDesigner class.
	/// </summary>
	internal class EPrescriptionDetailDataSourceActionList : DesignerActionList
	{
		private EPrescriptionDetailDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EPrescriptionDetailDataSourceActionList(EPrescriptionDetailDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EPrescriptionDetailSelectMethod SelectMethod
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

	#endregion EPrescriptionDetailDataSourceActionList
	
	#endregion EPrescriptionDetailDataSourceDesigner
	
	#region EPrescriptionDetailSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EPrescriptionDetailDataSource.SelectMethod property.
	/// </summary>
	public enum EPrescriptionDetailSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByPrescriptionDetailId method.
		/// </summary>
		GetByPrescriptionDetailId,
		/// <summary>
		/// Represents the GetByPrescriptionId method.
		/// </summary>
		GetByPrescriptionId
	}
	
	#endregion EPrescriptionDetailSelectMethod

	#region EPrescriptionDetailFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailFilter : SqlFilter<EPrescriptionDetailColumn>
	{
	}
	
	#endregion EPrescriptionDetailFilter

	#region EPrescriptionDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailExpressionBuilder : SqlExpressionBuilder<EPrescriptionDetailColumn>
	{
	}
	
	#endregion EPrescriptionDetailExpressionBuilder	

	#region EPrescriptionDetailProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EPrescriptionDetailChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailProperty : ChildEntityProperty<EPrescriptionDetailChildEntityTypes>
	{
	}
	
	#endregion EPrescriptionDetailProperty
}

