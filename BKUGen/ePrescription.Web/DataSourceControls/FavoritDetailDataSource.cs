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
	/// Represents the DataRepository.FavoritDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FavoritDetailDataSourceDesigner))]
	public class FavoritDetailDataSource : ProviderDataSource<FavoritDetail, FavoritDetailKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailDataSource class.
		/// </summary>
		public FavoritDetailDataSource() : base(DataRepository.FavoritDetailProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FavoritDetailDataSourceView used by the FavoritDetailDataSource.
		/// </summary>
		protected FavoritDetailDataSourceView FavoritDetailView
		{
			get { return ( View as FavoritDetailDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FavoritDetailDataSource control invokes to retrieve data.
		/// </summary>
		public FavoritDetailSelectMethod SelectMethod
		{
			get
			{
				FavoritDetailSelectMethod selectMethod = FavoritDetailSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FavoritDetailSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FavoritDetailDataSourceView class that is to be
		/// used by the FavoritDetailDataSource.
		/// </summary>
		/// <returns>An instance of the FavoritDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<FavoritDetail, FavoritDetailKey> GetNewDataSourceView()
		{
			return new FavoritDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the FavoritDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FavoritDetailDataSourceView : ProviderDataSourceView<FavoritDetail, FavoritDetailKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FavoritDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FavoritDetailDataSourceView(FavoritDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FavoritDetailDataSource FavoritDetailOwner
		{
			get { return Owner as FavoritDetailDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FavoritDetailSelectMethod SelectMethod
		{
			get { return FavoritDetailOwner.SelectMethod; }
			set { FavoritDetailOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FavoritDetailProviderBase FavoritDetailProvider
		{
			get { return Provider as FavoritDetailProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<FavoritDetail> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<FavoritDetail> results = null;
			FavoritDetail item;
			count = 0;
			
			System.Int64 _id;
			System.String _favouriteId;

			switch ( SelectMethod )
			{
				case FavoritDetailSelectMethod.Get:
					FavoritDetailKey entityKey  = new FavoritDetailKey();
					entityKey.Load(values);
					item = FavoritDetailProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<FavoritDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FavoritDetailSelectMethod.GetAll:
                    results = FavoritDetailProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case FavoritDetailSelectMethod.GetPaged:
					results = FavoritDetailProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FavoritDetailSelectMethod.Find:
					if ( FilterParameters != null )
						results = FavoritDetailProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FavoritDetailProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FavoritDetailSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = FavoritDetailProvider.GetById(GetTransactionManager(), _id);
					results = new TList<FavoritDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case FavoritDetailSelectMethod.GetByFavouriteId:
					_favouriteId = ( values["FavouriteId"] != null ) ? (System.String) EntityUtil.ChangeType(values["FavouriteId"], typeof(System.String)) : string.Empty;
					results = FavoritDetailProvider.GetByFavouriteId(GetTransactionManager(), _favouriteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == FavoritDetailSelectMethod.Get || SelectMethod == FavoritDetailSelectMethod.GetById )
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
				FavoritDetail entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					FavoritDetailProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<FavoritDetail> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			FavoritDetailProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FavoritDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FavoritDetailDataSource class.
	/// </summary>
	public class FavoritDetailDataSourceDesigner : ProviderDataSourceDesigner<FavoritDetail, FavoritDetailKey>
	{
		/// <summary>
		/// Initializes a new instance of the FavoritDetailDataSourceDesigner class.
		/// </summary>
		public FavoritDetailDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FavoritDetailSelectMethod SelectMethod
		{
			get { return ((FavoritDetailDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FavoritDetailDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FavoritDetailDataSourceActionList

	/// <summary>
	/// Supports the FavoritDetailDataSourceDesigner class.
	/// </summary>
	internal class FavoritDetailDataSourceActionList : DesignerActionList
	{
		private FavoritDetailDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FavoritDetailDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FavoritDetailDataSourceActionList(FavoritDetailDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FavoritDetailSelectMethod SelectMethod
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

	#endregion FavoritDetailDataSourceActionList
	
	#endregion FavoritDetailDataSourceDesigner
	
	#region FavoritDetailSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FavoritDetailDataSource.SelectMethod property.
	/// </summary>
	public enum FavoritDetailSelectMethod
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
		/// Represents the GetById method.
		/// </summary>
		GetById,
		/// <summary>
		/// Represents the GetByFavouriteId method.
		/// </summary>
		GetByFavouriteId
	}
	
	#endregion FavoritDetailSelectMethod

	#region FavoritDetailFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailFilter : SqlFilter<FavoritDetailColumn>
	{
	}
	
	#endregion FavoritDetailFilter

	#region FavoritDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailExpressionBuilder : SqlExpressionBuilder<FavoritDetailColumn>
	{
	}
	
	#endregion FavoritDetailExpressionBuilder	

	#region FavoritDetailProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FavoritDetailChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailProperty : ChildEntityProperty<FavoritDetailChildEntityTypes>
	{
	}
	
	#endregion FavoritDetailProperty
}

