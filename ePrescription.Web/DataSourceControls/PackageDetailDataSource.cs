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
	/// Represents the DataRepository.PackageDetailProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(PackageDetailDataSourceDesigner))]
	public class PackageDetailDataSource : ProviderDataSource<PackageDetail, PackageDetailKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailDataSource class.
		/// </summary>
		public PackageDetailDataSource() : base(DataRepository.PackageDetailProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the PackageDetailDataSourceView used by the PackageDetailDataSource.
		/// </summary>
		protected PackageDetailDataSourceView PackageDetailView
		{
			get { return ( View as PackageDetailDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the PackageDetailDataSource control invokes to retrieve data.
		/// </summary>
		public PackageDetailSelectMethod SelectMethod
		{
			get
			{
				PackageDetailSelectMethod selectMethod = PackageDetailSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (PackageDetailSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the PackageDetailDataSourceView class that is to be
		/// used by the PackageDetailDataSource.
		/// </summary>
		/// <returns>An instance of the PackageDetailDataSourceView class.</returns>
		protected override BaseDataSourceView<PackageDetail, PackageDetailKey> GetNewDataSourceView()
		{
			return new PackageDetailDataSourceView(this, DefaultViewName);
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
	/// Supports the PackageDetailDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class PackageDetailDataSourceView : ProviderDataSourceView<PackageDetail, PackageDetailKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the PackageDetailDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public PackageDetailDataSourceView(PackageDetailDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal PackageDetailDataSource PackageDetailOwner
		{
			get { return Owner as PackageDetailDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal PackageDetailSelectMethod SelectMethod
		{
			get { return PackageDetailOwner.SelectMethod; }
			set { PackageDetailOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal PackageDetailProviderBase PackageDetailProvider
		{
			get { return Provider as PackageDetailProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<PackageDetail> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<PackageDetail> results = null;
			PackageDetail item;
			count = 0;
			
			System.Int32 _packageDetailId;
			System.String _packageId;

			switch ( SelectMethod )
			{
				case PackageDetailSelectMethod.Get:
					PackageDetailKey entityKey  = new PackageDetailKey();
					entityKey.Load(values);
					item = PackageDetailProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<PackageDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case PackageDetailSelectMethod.GetAll:
                    results = PackageDetailProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case PackageDetailSelectMethod.GetPaged:
					results = PackageDetailProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case PackageDetailSelectMethod.Find:
					if ( FilterParameters != null )
						results = PackageDetailProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = PackageDetailProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case PackageDetailSelectMethod.GetByPackageDetailId:
					_packageDetailId = ( values["PackageDetailId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["PackageDetailId"], typeof(System.Int32)) : (int)0;
					item = PackageDetailProvider.GetByPackageDetailId(GetTransactionManager(), _packageDetailId);
					results = new TList<PackageDetail>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case PackageDetailSelectMethod.GetByPackageId:
					_packageId = ( values["PackageId"] != null ) ? (System.String) EntityUtil.ChangeType(values["PackageId"], typeof(System.String)) : string.Empty;
					results = PackageDetailProvider.GetByPackageId(GetTransactionManager(), _packageId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == PackageDetailSelectMethod.Get || SelectMethod == PackageDetailSelectMethod.GetByPackageDetailId )
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
				PackageDetail entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					PackageDetailProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<PackageDetail> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			PackageDetailProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region PackageDetailDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the PackageDetailDataSource class.
	/// </summary>
	public class PackageDetailDataSourceDesigner : ProviderDataSourceDesigner<PackageDetail, PackageDetailKey>
	{
		/// <summary>
		/// Initializes a new instance of the PackageDetailDataSourceDesigner class.
		/// </summary>
		public PackageDetailDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PackageDetailSelectMethod SelectMethod
		{
			get { return ((PackageDetailDataSource) DataSource).SelectMethod; }
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
				actions.Add(new PackageDetailDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region PackageDetailDataSourceActionList

	/// <summary>
	/// Supports the PackageDetailDataSourceDesigner class.
	/// </summary>
	internal class PackageDetailDataSourceActionList : DesignerActionList
	{
		private PackageDetailDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the PackageDetailDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public PackageDetailDataSourceActionList(PackageDetailDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public PackageDetailSelectMethod SelectMethod
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

	#endregion PackageDetailDataSourceActionList
	
	#endregion PackageDetailDataSourceDesigner
	
	#region PackageDetailSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the PackageDetailDataSource.SelectMethod property.
	/// </summary>
	public enum PackageDetailSelectMethod
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
		/// Represents the GetByPackageDetailId method.
		/// </summary>
		GetByPackageDetailId,
		/// <summary>
		/// Represents the GetByPackageId method.
		/// </summary>
		GetByPackageId
	}
	
	#endregion PackageDetailSelectMethod

	#region PackageDetailFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailFilter : SqlFilter<PackageDetailColumn>
	{
	}
	
	#endregion PackageDetailFilter

	#region PackageDetailExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailExpressionBuilder : SqlExpressionBuilder<PackageDetailColumn>
	{
	}
	
	#endregion PackageDetailExpressionBuilder	

	#region PackageDetailProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;PackageDetailChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailProperty : ChildEntityProperty<PackageDetailChildEntityTypes>
	{
	}
	
	#endregion PackageDetailProperty
}

