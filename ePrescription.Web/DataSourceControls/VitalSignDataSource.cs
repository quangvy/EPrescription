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
	/// Represents the DataRepository.VitalSignProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(VitalSignDataSourceDesigner))]
	public class VitalSignDataSource : ProviderDataSource<VitalSign, VitalSignKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignDataSource class.
		/// </summary>
		public VitalSignDataSource() : base(DataRepository.VitalSignProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the VitalSignDataSourceView used by the VitalSignDataSource.
		/// </summary>
		protected VitalSignDataSourceView VitalSignView
		{
			get { return ( View as VitalSignDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the VitalSignDataSource control invokes to retrieve data.
		/// </summary>
		public VitalSignSelectMethod SelectMethod
		{
			get
			{
				VitalSignSelectMethod selectMethod = VitalSignSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (VitalSignSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the VitalSignDataSourceView class that is to be
		/// used by the VitalSignDataSource.
		/// </summary>
		/// <returns>An instance of the VitalSignDataSourceView class.</returns>
		protected override BaseDataSourceView<VitalSign, VitalSignKey> GetNewDataSourceView()
		{
			return new VitalSignDataSourceView(this, DefaultViewName);
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
	/// Supports the VitalSignDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class VitalSignDataSourceView : ProviderDataSourceView<VitalSign, VitalSignKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the VitalSignDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public VitalSignDataSourceView(VitalSignDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal VitalSignDataSource VitalSignOwner
		{
			get { return Owner as VitalSignDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal VitalSignSelectMethod SelectMethod
		{
			get { return VitalSignOwner.SelectMethod; }
			set { VitalSignOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal VitalSignProviderBase VitalSignProvider
		{
			get { return Provider as VitalSignProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<VitalSign> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<VitalSign> results = null;
			VitalSign item;
			count = 0;
			
			System.Int64 _vid;

			switch ( SelectMethod )
			{
				case VitalSignSelectMethod.Get:
					VitalSignKey entityKey  = new VitalSignKey();
					entityKey.Load(values);
					item = VitalSignProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<VitalSign>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case VitalSignSelectMethod.GetAll:
                    results = VitalSignProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case VitalSignSelectMethod.GetPaged:
					results = VitalSignProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case VitalSignSelectMethod.Find:
					if ( FilterParameters != null )
						results = VitalSignProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = VitalSignProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case VitalSignSelectMethod.GetByVid:
					_vid = ( values["Vid"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["Vid"], typeof(System.Int64)) : (long)0;
					item = VitalSignProvider.GetByVid(GetTransactionManager(), _vid);
					results = new TList<VitalSign>();
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
			if ( SelectMethod == VitalSignSelectMethod.Get || SelectMethod == VitalSignSelectMethod.GetByVid )
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
				VitalSign entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					VitalSignProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<VitalSign> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			VitalSignProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region VitalSignDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the VitalSignDataSource class.
	/// </summary>
	public class VitalSignDataSourceDesigner : ProviderDataSourceDesigner<VitalSign, VitalSignKey>
	{
		/// <summary>
		/// Initializes a new instance of the VitalSignDataSourceDesigner class.
		/// </summary>
		public VitalSignDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VitalSignSelectMethod SelectMethod
		{
			get { return ((VitalSignDataSource) DataSource).SelectMethod; }
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
				actions.Add(new VitalSignDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region VitalSignDataSourceActionList

	/// <summary>
	/// Supports the VitalSignDataSourceDesigner class.
	/// </summary>
	internal class VitalSignDataSourceActionList : DesignerActionList
	{
		private VitalSignDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the VitalSignDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public VitalSignDataSourceActionList(VitalSignDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public VitalSignSelectMethod SelectMethod
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

	#endregion VitalSignDataSourceActionList
	
	#endregion VitalSignDataSourceDesigner
	
	#region VitalSignSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the VitalSignDataSource.SelectMethod property.
	/// </summary>
	public enum VitalSignSelectMethod
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
		/// Represents the GetByVid method.
		/// </summary>
		GetByVid
	}
	
	#endregion VitalSignSelectMethod

	#region VitalSignFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignFilter : SqlFilter<VitalSignColumn>
	{
	}
	
	#endregion VitalSignFilter

	#region VitalSignExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignExpressionBuilder : SqlExpressionBuilder<VitalSignColumn>
	{
	}
	
	#endregion VitalSignExpressionBuilder	

	#region VitalSignProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;VitalSignChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignProperty : ChildEntityProperty<VitalSignChildEntityTypes>
	{
	}
	
	#endregion VitalSignProperty
}

