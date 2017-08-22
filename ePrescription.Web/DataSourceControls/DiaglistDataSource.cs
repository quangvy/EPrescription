﻿#region Using Directives
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
	/// Represents the DataRepository.DiaglistProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DiaglistDataSourceDesigner))]
	public class DiaglistDataSource : ProviderDataSource<Diaglist, DiaglistKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistDataSource class.
		/// </summary>
		public DiaglistDataSource() : base(DataRepository.DiaglistProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DiaglistDataSourceView used by the DiaglistDataSource.
		/// </summary>
		protected DiaglistDataSourceView DiaglistView
		{
			get { return ( View as DiaglistDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DiaglistDataSource control invokes to retrieve data.
		/// </summary>
		public DiaglistSelectMethod SelectMethod
		{
			get
			{
				DiaglistSelectMethod selectMethod = DiaglistSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DiaglistSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DiaglistDataSourceView class that is to be
		/// used by the DiaglistDataSource.
		/// </summary>
		/// <returns>An instance of the DiaglistDataSourceView class.</returns>
		protected override BaseDataSourceView<Diaglist, DiaglistKey> GetNewDataSourceView()
		{
			return new DiaglistDataSourceView(this, DefaultViewName);
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
	/// Supports the DiaglistDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DiaglistDataSourceView : ProviderDataSourceView<Diaglist, DiaglistKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DiaglistDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DiaglistDataSourceView(DiaglistDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DiaglistDataSource DiaglistOwner
		{
			get { return Owner as DiaglistDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DiaglistSelectMethod SelectMethod
		{
			get { return DiaglistOwner.SelectMethod; }
			set { DiaglistOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DiaglistProviderBase DiaglistProvider
		{
			get { return Provider as DiaglistProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Diaglist> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Diaglist> results = null;
			Diaglist item;
			count = 0;
			
			System.String _diagCode;

			switch ( SelectMethod )
			{
				case DiaglistSelectMethod.Get:
					DiaglistKey entityKey  = new DiaglistKey();
					entityKey.Load(values);
					item = DiaglistProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<Diaglist>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DiaglistSelectMethod.GetAll:
                    results = DiaglistProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case DiaglistSelectMethod.GetPaged:
					results = DiaglistProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DiaglistSelectMethod.Find:
					if ( FilterParameters != null )
						results = DiaglistProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DiaglistProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DiaglistSelectMethod.GetByDiagCode:
					_diagCode = ( values["DiagCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["DiagCode"], typeof(System.String)) : string.Empty;
					item = DiaglistProvider.GetByDiagCode(GetTransactionManager(), _diagCode);
					results = new TList<Diaglist>();
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
			if ( SelectMethod == DiaglistSelectMethod.Get || SelectMethod == DiaglistSelectMethod.GetByDiagCode )
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
				Diaglist entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					DiaglistProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Diaglist> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			DiaglistProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DiaglistDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DiaglistDataSource class.
	/// </summary>
	public class DiaglistDataSourceDesigner : ProviderDataSourceDesigner<Diaglist, DiaglistKey>
	{
		/// <summary>
		/// Initializes a new instance of the DiaglistDataSourceDesigner class.
		/// </summary>
		public DiaglistDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DiaglistSelectMethod SelectMethod
		{
			get { return ((DiaglistDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DiaglistDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DiaglistDataSourceActionList

	/// <summary>
	/// Supports the DiaglistDataSourceDesigner class.
	/// </summary>
	internal class DiaglistDataSourceActionList : DesignerActionList
	{
		private DiaglistDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DiaglistDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DiaglistDataSourceActionList(DiaglistDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DiaglistSelectMethod SelectMethod
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

	#endregion DiaglistDataSourceActionList
	
	#endregion DiaglistDataSourceDesigner
	
	#region DiaglistSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DiaglistDataSource.SelectMethod property.
	/// </summary>
	public enum DiaglistSelectMethod
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
		/// Represents the GetByDiagCode method.
		/// </summary>
		GetByDiagCode
	}
	
	#endregion DiaglistSelectMethod

	#region DiaglistFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistFilter : SqlFilter<DiaglistColumn>
	{
	}
	
	#endregion DiaglistFilter

	#region DiaglistExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistExpressionBuilder : SqlExpressionBuilder<DiaglistColumn>
	{
	}
	
	#endregion DiaglistExpressionBuilder	

	#region DiaglistProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DiaglistChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistProperty : ChildEntityProperty<DiaglistChildEntityTypes>
	{
	}
	
	#endregion DiaglistProperty
}
