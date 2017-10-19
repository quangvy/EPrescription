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
	/// Represents the DataRepository.PackageProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PackageDataSourceDesigner))]
	public class PackageDataSource : ProviderDataSource<Package, PackageKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDataSource class.
		/// </summary>
		public PackageDataSource() : base(DataRepository.PackageProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PackageDataSourceView used by the PackageDataSource.
		/// </summary>
		protected PackageDataSourceView PackageView
		{
			get { return ( View as PackageDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PackageDataSource control invokes to retrieve data.
		/// </summary>
		public PackageSelectMethod SelectMethod
		{
			get
			{
				PackageSelectMethod selectMethod = PackageSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PackageSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PackageDataSourceView class that is to be
		/// used by the PackageDataSource.
		/// </summary>
		/// <returns>An instance of the PackageDataSourceView class.</returns>
		protected override BaseDataSourceView<Package, PackageKey> GetNewDataSourceView()
		{
			return new PackageDataSourceView(this, DefaultViewName);
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
	/// Supports the PackageDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PackageDataSourceView : ProviderDataSourceView<Package, PackageKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PackageDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PackageDataSourceView(PackageDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PackageDataSource PackageOwner
		{
			get { return Owner as PackageDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PackageSelectMethod SelectMethod
		{
			get { return PackageOwner.SelectMethod; }
			set { PackageOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PackageProviderBase PackageProvider
		{
			get { return Provider as PackageProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Package> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Package> results = null;
			Package item;
			count = 0;
			
			System.String _packageId;

			switch ( SelectMethod )
			{
				case PackageSelectMethod.Get:
					PackageKey entityKey  = new PackageKey();
					entityKey.Load(values);
					item = PackageProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Package>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PackageSelectMethod.GetAll:
                    results = PackageProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case PackageSelectMethod.GetPaged:
					results = PackageProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PackageSelectMethod.Find:
					if ( FilterParameters != null )
						results = PackageProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PackageProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PackageSelectMethod.GetByPackageId:
					_packageId = ( values["PackageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["PackageId"], typeof(System.String)) : string.Empty;
					item = PackageProvider.GetByPackageId(GetTransactionManager(), _packageId);
					results = new TList<Package>();
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
			if ( SelectMethod == PackageSelectMethod.Get || SelectMethod == PackageSelectMethod.GetByPackageId )
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
				Package entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					PackageProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Package> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			PackageProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PackageDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PackageDataSource class.
	/// </summary>
	public class PackageDataSourceDesigner : ProviderDataSourceDesigner<Package, PackageKey>
	{
		/// <summary>
		/// Initializes a new instance of the PackageDataSourceDesigner class.
		/// </summary>
		public PackageDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PackageSelectMethod SelectMethod
		{
			get { return ((PackageDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PackageDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PackageDataSourceActionList

	/// <summary>
	/// Supports the PackageDataSourceDesigner class.
	/// </summary>
	internal class PackageDataSourceActionList : DesignerActionList
	{
		private PackageDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PackageDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PackageDataSourceActionList(PackageDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PackageSelectMethod SelectMethod
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

	#endregion PackageDataSourceActionList
	
	#endregion PackageDataSourceDesigner
	
	#region PackageSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PackageDataSource.SelectMethod property.
	/// </summary>
	public enum PackageSelectMethod
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
		/// Represents the GetByPackageId method.
		/// </summary>
		GetByPackageId
	}
	
	#endregion PackageSelectMethod

	#region PackageFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageFilter : SqlFilter<PackageColumn>
	{
	}
	
	#endregion PackageFilter

	#region PackageExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageExpressionBuilder : SqlExpressionBuilder<PackageColumn>
	{
	}
	
	#endregion PackageExpressionBuilder	

	#region PackageProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PackageChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageProperty : ChildEntityProperty<PackageChildEntityTypes>
	{
	}
	
	#endregion PackageProperty
}

