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
	/// Represents the DataRepository.FrequencyProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FrequencyDataSourceDesigner))]
	public class FrequencyDataSource : ProviderDataSource<Frequency, FrequencyKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyDataSource class.
		/// </summary>
		public FrequencyDataSource() : base(DataRepository.FrequencyProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FrequencyDataSourceView used by the FrequencyDataSource.
		/// </summary>
		protected FrequencyDataSourceView FrequencyView
		{
			get { return ( View as FrequencyDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FrequencyDataSource control invokes to retrieve data.
		/// </summary>
		public FrequencySelectMethod SelectMethod
		{
			get
			{
				FrequencySelectMethod selectMethod = FrequencySelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FrequencySelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FrequencyDataSourceView class that is to be
		/// used by the FrequencyDataSource.
		/// </summary>
		/// <returns>An instance of the FrequencyDataSourceView class.</returns>
		protected override BaseDataSourceView<Frequency, FrequencyKey> GetNewDataSourceView()
		{
			return new FrequencyDataSourceView(this, DefaultViewName);
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
	/// Supports the FrequencyDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FrequencyDataSourceView : ProviderDataSourceView<Frequency, FrequencyKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FrequencyDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FrequencyDataSourceView(FrequencyDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FrequencyDataSource FrequencyOwner
		{
			get { return Owner as FrequencyDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FrequencySelectMethod SelectMethod
		{
			get { return FrequencyOwner.SelectMethod; }
			set { FrequencyOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FrequencyProviderBase FrequencyProvider
		{
			get { return Provider as FrequencyProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Frequency> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Frequency> results = null;
			Frequency item;
			count = 0;
			
			System.Int64 _frequencyId;

			switch ( SelectMethod )
			{
				case FrequencySelectMethod.Get:
					FrequencyKey entityKey  = new FrequencyKey();
					entityKey.Load(values);
					item = FrequencyProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Frequency>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FrequencySelectMethod.GetAll:
                    results = FrequencyProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case FrequencySelectMethod.GetPaged:
					results = FrequencyProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FrequencySelectMethod.Find:
					if ( FilterParameters != null )
						results = FrequencyProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FrequencyProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FrequencySelectMethod.GetByFrequencyId:
					_frequencyId = ( values["FrequencyId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["FrequencyId"], typeof(System.Int64)) : (long)0;
					item = FrequencyProvider.GetByFrequencyId(GetTransactionManager(), _frequencyId);
					results = new TList<Frequency>();
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
			if ( SelectMethod == FrequencySelectMethod.Get || SelectMethod == FrequencySelectMethod.GetByFrequencyId )
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
				Frequency entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					FrequencyProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Frequency> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			FrequencyProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FrequencyDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FrequencyDataSource class.
	/// </summary>
	public class FrequencyDataSourceDesigner : ProviderDataSourceDesigner<Frequency, FrequencyKey>
	{
		/// <summary>
		/// Initializes a new instance of the FrequencyDataSourceDesigner class.
		/// </summary>
		public FrequencyDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FrequencySelectMethod SelectMethod
		{
			get { return ((FrequencyDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FrequencyDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FrequencyDataSourceActionList

	/// <summary>
	/// Supports the FrequencyDataSourceDesigner class.
	/// </summary>
	internal class FrequencyDataSourceActionList : DesignerActionList
	{
		private FrequencyDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FrequencyDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FrequencyDataSourceActionList(FrequencyDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FrequencySelectMethod SelectMethod
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

	#endregion FrequencyDataSourceActionList
	
	#endregion FrequencyDataSourceDesigner
	
	#region FrequencySelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FrequencyDataSource.SelectMethod property.
	/// </summary>
	public enum FrequencySelectMethod
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
		/// Represents the GetByFrequencyId method.
		/// </summary>
		GetByFrequencyId
	}
	
	#endregion FrequencySelectMethod

	#region FrequencyFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyFilter : SqlFilter<FrequencyColumn>
	{
	}
	
	#endregion FrequencyFilter

	#region FrequencyExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyExpressionBuilder : SqlExpressionBuilder<FrequencyColumn>
	{
	}
	
	#endregion FrequencyExpressionBuilder	

	#region FrequencyProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FrequencyChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyProperty : ChildEntityProperty<FrequencyChildEntityTypes>
	{
	}
	
	#endregion FrequencyProperty
}

