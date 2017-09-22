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
	/// Represents the DataRepository.DoctorRequestProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DoctorRequestDataSourceDesigner))]
	public class DoctorRequestDataSource : ProviderDataSource<DoctorRequest, DoctorRequestKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestDataSource class.
		/// </summary>
		public DoctorRequestDataSource() : base(DataRepository.DoctorRequestProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DoctorRequestDataSourceView used by the DoctorRequestDataSource.
		/// </summary>
		protected DoctorRequestDataSourceView DoctorRequestView
		{
			get { return ( View as DoctorRequestDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DoctorRequestDataSource control invokes to retrieve data.
		/// </summary>
		public DoctorRequestSelectMethod SelectMethod
		{
			get
			{
				DoctorRequestSelectMethod selectMethod = DoctorRequestSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DoctorRequestSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DoctorRequestDataSourceView class that is to be
		/// used by the DoctorRequestDataSource.
		/// </summary>
		/// <returns>An instance of the DoctorRequestDataSourceView class.</returns>
		protected override BaseDataSourceView<DoctorRequest, DoctorRequestKey> GetNewDataSourceView()
		{
			return new DoctorRequestDataSourceView(this, DefaultViewName);
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
	/// Supports the DoctorRequestDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DoctorRequestDataSourceView : ProviderDataSourceView<DoctorRequest, DoctorRequestKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DoctorRequestDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DoctorRequestDataSourceView(DoctorRequestDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DoctorRequestDataSource DoctorRequestOwner
		{
			get { return Owner as DoctorRequestDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DoctorRequestSelectMethod SelectMethod
		{
			get { return DoctorRequestOwner.SelectMethod; }
			set { DoctorRequestOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DoctorRequestProviderBase DoctorRequestProvider
		{
			get { return Provider as DoctorRequestProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DoctorRequest> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DoctorRequest> results = null;
			DoctorRequest item;
			count = 0;
			
			System.Int64 _id;

			switch ( SelectMethod )
			{
				case DoctorRequestSelectMethod.Get:
					DoctorRequestKey entityKey  = new DoctorRequestKey();
					entityKey.Load(values);
					item = DoctorRequestProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<DoctorRequest>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DoctorRequestSelectMethod.GetAll:
                    results = DoctorRequestProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DoctorRequestSelectMethod.GetPaged:
					results = DoctorRequestProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DoctorRequestSelectMethod.Find:
					if ( FilterParameters != null )
						results = DoctorRequestProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DoctorRequestProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DoctorRequestSelectMethod.GetById:
					_id = ( values["Id"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Id"], typeof(System.Int64)) : (long)0;
					item = DoctorRequestProvider.GetById(GetTransactionManager(), _id);
					results = new TList<DoctorRequest>();
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
			if ( SelectMethod == DoctorRequestSelectMethod.Get || SelectMethod == DoctorRequestSelectMethod.GetById )
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
				DoctorRequest entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DoctorRequestProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DoctorRequest> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DoctorRequestProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DoctorRequestDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DoctorRequestDataSource class.
	/// </summary>
	public class DoctorRequestDataSourceDesigner : ProviderDataSourceDesigner<DoctorRequest, DoctorRequestKey>
	{
		/// <summary>
		/// Initializes a new instance of the DoctorRequestDataSourceDesigner class.
		/// </summary>
		public DoctorRequestDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DoctorRequestSelectMethod SelectMethod
		{
			get { return ((DoctorRequestDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DoctorRequestDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DoctorRequestDataSourceActionList

	/// <summary>
	/// Supports the DoctorRequestDataSourceDesigner class.
	/// </summary>
	internal class DoctorRequestDataSourceActionList : DesignerActionList
	{
		private DoctorRequestDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DoctorRequestDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DoctorRequestDataSourceActionList(DoctorRequestDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DoctorRequestSelectMethod SelectMethod
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

	#endregion DoctorRequestDataSourceActionList
	
	#endregion DoctorRequestDataSourceDesigner
	
	#region DoctorRequestSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DoctorRequestDataSource.SelectMethod property.
	/// </summary>
	public enum DoctorRequestSelectMethod
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
		GetById
	}
	
	#endregion DoctorRequestSelectMethod

	#region DoctorRequestFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestFilter : SqlFilter<DoctorRequestColumn>
	{
	}
	
	#endregion DoctorRequestFilter

	#region DoctorRequestExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestExpressionBuilder : SqlExpressionBuilder<DoctorRequestColumn>
	{
	}
	
	#endregion DoctorRequestExpressionBuilder	

	#region DoctorRequestProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DoctorRequestChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestProperty : ChildEntityProperty<DoctorRequestChildEntityTypes>
	{
	}
	
	#endregion DoctorRequestProperty
}

