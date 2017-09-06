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
	/// Represents the DataRepository.ClinicalStatsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ClinicalStatsDataSourceDesigner))]
	public class ClinicalStatsDataSource : ProviderDataSource<ClinicalStats, ClinicalStatsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsDataSource class.
		/// </summary>
		public ClinicalStatsDataSource() : base(DataRepository.ClinicalStatsProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ClinicalStatsDataSourceView used by the ClinicalStatsDataSource.
		/// </summary>
		protected ClinicalStatsDataSourceView ClinicalStatsView
		{
			get { return ( View as ClinicalStatsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ClinicalStatsDataSource control invokes to retrieve data.
		/// </summary>
		public ClinicalStatsSelectMethod SelectMethod
		{
			get
			{
				ClinicalStatsSelectMethod selectMethod = ClinicalStatsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ClinicalStatsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ClinicalStatsDataSourceView class that is to be
		/// used by the ClinicalStatsDataSource.
		/// </summary>
		/// <returns>An instance of the ClinicalStatsDataSourceView class.</returns>
		protected override BaseDataSourceView<ClinicalStats, ClinicalStatsKey> GetNewDataSourceView()
		{
			return new ClinicalStatsDataSourceView(this, DefaultViewName);
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
	/// Supports the ClinicalStatsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ClinicalStatsDataSourceView : ProviderDataSourceView<ClinicalStats, ClinicalStatsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ClinicalStatsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ClinicalStatsDataSourceView(ClinicalStatsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ClinicalStatsDataSource ClinicalStatsOwner
		{
			get { return Owner as ClinicalStatsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ClinicalStatsSelectMethod SelectMethod
		{
			get { return ClinicalStatsOwner.SelectMethod; }
			set { ClinicalStatsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ClinicalStatsProviderBase ClinicalStatsProvider
		{
			get { return Provider as ClinicalStatsProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ClinicalStats> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<ClinicalStats> results = null;
			ClinicalStats item;
			count = 0;
			
			System.Int64 _statId;

			switch ( SelectMethod )
			{
				case ClinicalStatsSelectMethod.Get:
					ClinicalStatsKey entityKey  = new ClinicalStatsKey();
					entityKey.Load(values);
					item = ClinicalStatsProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<ClinicalStats>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ClinicalStatsSelectMethod.GetAll:
                    results = ClinicalStatsProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case ClinicalStatsSelectMethod.GetPaged:
					results = ClinicalStatsProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ClinicalStatsSelectMethod.Find:
					if ( FilterParameters != null )
						results = ClinicalStatsProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ClinicalStatsProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ClinicalStatsSelectMethod.GetByStatId:
					_statId = ( values["StatId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["StatId"], typeof(System.Int64)) : (long)0;
					item = ClinicalStatsProvider.GetByStatId(GetTransactionManager(), _statId);
					results = new TList<ClinicalStats>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == ClinicalStatsSelectMethod.Get || SelectMethod == ClinicalStatsSelectMethod.GetByStatId )
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
				ClinicalStats entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					ClinicalStatsProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<ClinicalStats> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			ClinicalStatsProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ClinicalStatsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ClinicalStatsDataSource class.
	/// </summary>
	public class ClinicalStatsDataSourceDesigner : ProviderDataSourceDesigner<ClinicalStats, ClinicalStatsKey>
	{
		/// <summary>
		/// Initializes a new instance of the ClinicalStatsDataSourceDesigner class.
		/// </summary>
		public ClinicalStatsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClinicalStatsSelectMethod SelectMethod
		{
			get { return ((ClinicalStatsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ClinicalStatsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ClinicalStatsDataSourceActionList

	/// <summary>
	/// Supports the ClinicalStatsDataSourceDesigner class.
	/// </summary>
	internal class ClinicalStatsDataSourceActionList : DesignerActionList
	{
		private ClinicalStatsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ClinicalStatsDataSourceActionList(ClinicalStatsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ClinicalStatsSelectMethod SelectMethod
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

	#endregion ClinicalStatsDataSourceActionList
	
	#endregion ClinicalStatsDataSourceDesigner
	
	#region ClinicalStatsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ClinicalStatsDataSource.SelectMethod property.
	/// </summary>
	public enum ClinicalStatsSelectMethod
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
		/// Represents the GetByStatId method.
		/// </summary>
		GetByStatId
	}
	
	#endregion ClinicalStatsSelectMethod

	#region ClinicalStatsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsFilter : SqlFilter<ClinicalStatsColumn>
	{
	}
	
	#endregion ClinicalStatsFilter

	#region ClinicalStatsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsExpressionBuilder : SqlExpressionBuilder<ClinicalStatsColumn>
	{
	}
	
	#endregion ClinicalStatsExpressionBuilder	

	#region ClinicalStatsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ClinicalStatsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsProperty : ChildEntityProperty<ClinicalStatsChildEntityTypes>
	{
	}
	
	#endregion ClinicalStatsProperty
}

