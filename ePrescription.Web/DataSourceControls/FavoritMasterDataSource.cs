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
	/// Represents the DataRepository.FavoritMasterProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FavoritMasterDataSourceDesigner))]
	public class FavoritMasterDataSource : ProviderDataSource<FavoritMaster, FavoritMasterKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterDataSource class.
		/// </summary>
		public FavoritMasterDataSource() : base(DataRepository.FavoritMasterProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FavoritMasterDataSourceView used by the FavoritMasterDataSource.
		/// </summary>
		protected FavoritMasterDataSourceView FavoritMasterView
		{
			get { return ( View as FavoritMasterDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FavoritMasterDataSource control invokes to retrieve data.
		/// </summary>
		public FavoritMasterSelectMethod SelectMethod
		{
			get
			{
				FavoritMasterSelectMethod selectMethod = FavoritMasterSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FavoritMasterSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FavoritMasterDataSourceView class that is to be
		/// used by the FavoritMasterDataSource.
		/// </summary>
		/// <returns>An instance of the FavoritMasterDataSourceView class.</returns>
		protected override BaseDataSourceView<FavoritMaster, FavoritMasterKey> GetNewDataSourceView()
		{
			return new FavoritMasterDataSourceView(this, DefaultViewName);
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
	/// Supports the FavoritMasterDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FavoritMasterDataSourceView : ProviderDataSourceView<FavoritMaster, FavoritMasterKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FavoritMasterDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FavoritMasterDataSourceView(FavoritMasterDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FavoritMasterDataSource FavoritMasterOwner
		{
			get { return Owner as FavoritMasterDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FavoritMasterSelectMethod SelectMethod
		{
			get { return FavoritMasterOwner.SelectMethod; }
			set { FavoritMasterOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FavoritMasterProviderBase FavoritMasterProvider
		{
			get { return Provider as FavoritMasterProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<FavoritMaster> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<FavoritMaster> results = null;
			FavoritMaster item;
			count = 0;
			
			System.String _favouriteId;

			switch ( SelectMethod )
			{
				case FavoritMasterSelectMethod.Get:
					FavoritMasterKey entityKey  = new FavoritMasterKey();
					entityKey.Load(values);
					item = FavoritMasterProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<FavoritMaster>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FavoritMasterSelectMethod.GetAll:
                    results = FavoritMasterProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case FavoritMasterSelectMethod.GetPaged:
					results = FavoritMasterProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FavoritMasterSelectMethod.Find:
					if ( FilterParameters != null )
						results = FavoritMasterProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FavoritMasterProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FavoritMasterSelectMethod.GetByFavouriteId:
					_favouriteId = ( values["FavouriteId"] != null ) ? (System.String) EntityUtil.ChangeType(values["FavouriteId"], typeof(System.String)) : string.Empty;
					item = FavoritMasterProvider.GetByFavouriteId(GetTransactionManager(), _favouriteId);
					results = new TList<FavoritMaster>();
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
			if ( SelectMethod == FavoritMasterSelectMethod.Get || SelectMethod == FavoritMasterSelectMethod.GetByFavouriteId )
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
				FavoritMaster entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					FavoritMasterProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<FavoritMaster> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			FavoritMasterProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FavoritMasterDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FavoritMasterDataSource class.
	/// </summary>
	public class FavoritMasterDataSourceDesigner : ProviderDataSourceDesigner<FavoritMaster, FavoritMasterKey>
	{
		/// <summary>
		/// Initializes a new instance of the FavoritMasterDataSourceDesigner class.
		/// </summary>
		public FavoritMasterDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FavoritMasterSelectMethod SelectMethod
		{
			get { return ((FavoritMasterDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FavoritMasterDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FavoritMasterDataSourceActionList

	/// <summary>
	/// Supports the FavoritMasterDataSourceDesigner class.
	/// </summary>
	internal class FavoritMasterDataSourceActionList : DesignerActionList
	{
		private FavoritMasterDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FavoritMasterDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FavoritMasterDataSourceActionList(FavoritMasterDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FavoritMasterSelectMethod SelectMethod
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

	#endregion FavoritMasterDataSourceActionList
	
	#endregion FavoritMasterDataSourceDesigner
	
	#region FavoritMasterSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FavoritMasterDataSource.SelectMethod property.
	/// </summary>
	public enum FavoritMasterSelectMethod
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
		/// Represents the GetByFavouriteId method.
		/// </summary>
		GetByFavouriteId
	}
	
	#endregion FavoritMasterSelectMethod

	#region FavoritMasterFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterFilter : SqlFilter<FavoritMasterColumn>
	{
	}
	
	#endregion FavoritMasterFilter

	#region FavoritMasterExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterExpressionBuilder : SqlExpressionBuilder<FavoritMasterColumn>
	{
	}
	
	#endregion FavoritMasterExpressionBuilder	

	#region FavoritMasterProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FavoritMasterChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterProperty : ChildEntityProperty<FavoritMasterChildEntityTypes>
	{
	}
	
	#endregion FavoritMasterProperty
}

