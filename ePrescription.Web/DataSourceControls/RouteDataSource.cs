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
	/// Represents the DataRepository.RouteProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RouteDataSourceDesigner))]
	public class RouteDataSource : ProviderDataSource<Route, RouteKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteDataSource class.
		/// </summary>
		public RouteDataSource() : base(DataRepository.RouteProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RouteDataSourceView used by the RouteDataSource.
		/// </summary>
		protected RouteDataSourceView RouteView
		{
			get { return ( View as RouteDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RouteDataSource control invokes to retrieve data.
		/// </summary>
		public RouteSelectMethod SelectMethod
		{
			get
			{
				RouteSelectMethod selectMethod = RouteSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RouteSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RouteDataSourceView class that is to be
		/// used by the RouteDataSource.
		/// </summary>
		/// <returns>An instance of the RouteDataSourceView class.</returns>
		protected override BaseDataSourceView<Route, RouteKey> GetNewDataSourceView()
		{
			return new RouteDataSourceView(this, DefaultViewName);
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
	/// Supports the RouteDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RouteDataSourceView : ProviderDataSourceView<Route, RouteKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RouteDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RouteDataSourceView(RouteDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RouteDataSource RouteOwner
		{
			get { return Owner as RouteDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RouteSelectMethod SelectMethod
		{
			get { return RouteOwner.SelectMethod; }
			set { RouteOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RouteProviderBase RouteProvider
		{
			get { return Provider as RouteProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Route> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Route> results = null;
			Route item;
			count = 0;
			
			System.Int64 _routeId;

			switch ( SelectMethod )
			{
				case RouteSelectMethod.Get:
					RouteKey entityKey  = new RouteKey();
					entityKey.Load(values);
					item = RouteProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Route>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RouteSelectMethod.GetAll:
                    results = RouteProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case RouteSelectMethod.GetPaged:
					results = RouteProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RouteSelectMethod.Find:
					if ( FilterParameters != null )
						results = RouteProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RouteProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RouteSelectMethod.GetByRouteId:
					_routeId = ( values["RouteId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["RouteId"], typeof(System.Int64)) : (long)0;
					item = RouteProvider.GetByRouteId(GetTransactionManager(), _routeId);
					results = new TList<Route>();
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
			if ( SelectMethod == RouteSelectMethod.Get || SelectMethod == RouteSelectMethod.GetByRouteId )
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
				Route entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					RouteProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Route> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			RouteProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RouteDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RouteDataSource class.
	/// </summary>
	public class RouteDataSourceDesigner : ProviderDataSourceDesigner<Route, RouteKey>
	{
		/// <summary>
		/// Initializes a new instance of the RouteDataSourceDesigner class.
		/// </summary>
		public RouteDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RouteSelectMethod SelectMethod
		{
			get { return ((RouteDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RouteDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RouteDataSourceActionList

	/// <summary>
	/// Supports the RouteDataSourceDesigner class.
	/// </summary>
	internal class RouteDataSourceActionList : DesignerActionList
	{
		private RouteDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RouteDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RouteDataSourceActionList(RouteDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RouteSelectMethod SelectMethod
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

	#endregion RouteDataSourceActionList
	
	#endregion RouteDataSourceDesigner
	
	#region RouteSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RouteDataSource.SelectMethod property.
	/// </summary>
	public enum RouteSelectMethod
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
		/// Represents the GetByRouteId method.
		/// </summary>
		GetByRouteId
	}
	
	#endregion RouteSelectMethod

	#region RouteFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteFilter : SqlFilter<RouteColumn>
	{
	}
	
	#endregion RouteFilter

	#region RouteExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteExpressionBuilder : SqlExpressionBuilder<RouteColumn>
	{
	}
	
	#endregion RouteExpressionBuilder	

	#region RouteProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RouteChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteProperty : ChildEntityProperty<RouteChildEntityTypes>
	{
	}
	
	#endregion RouteProperty
}

