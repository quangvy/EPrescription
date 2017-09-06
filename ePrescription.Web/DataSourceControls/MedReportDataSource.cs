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
	/// Represents the DataRepository.MedReportProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MedReportDataSourceDesigner))]
	public class MedReportDataSource : ProviderDataSource<MedReport, MedReportKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportDataSource class.
		/// </summary>
		public MedReportDataSource() : base(DataRepository.MedReportProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MedReportDataSourceView used by the MedReportDataSource.
		/// </summary>
		protected MedReportDataSourceView MedReportView
		{
			get { return ( View as MedReportDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MedReportDataSource control invokes to retrieve data.
		/// </summary>
		public MedReportSelectMethod SelectMethod
		{
			get
			{
				MedReportSelectMethod selectMethod = MedReportSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MedReportSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MedReportDataSourceView class that is to be
		/// used by the MedReportDataSource.
		/// </summary>
		/// <returns>An instance of the MedReportDataSourceView class.</returns>
		protected override BaseDataSourceView<MedReport, MedReportKey> GetNewDataSourceView()
		{
			return new MedReportDataSourceView(this, DefaultViewName);
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
	/// Supports the MedReportDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MedReportDataSourceView : ProviderDataSourceView<MedReport, MedReportKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MedReportDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MedReportDataSourceView(MedReportDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MedReportDataSource MedReportOwner
		{
			get { return Owner as MedReportDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MedReportSelectMethod SelectMethod
		{
			get { return MedReportOwner.SelectMethod; }
			set { MedReportOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MedReportProviderBase MedReportProvider
		{
			get { return Provider as MedReportProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MedReport> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MedReport> results = null;
			MedReport item;
			count = 0;
			
			System.Int64 _medId;

			switch ( SelectMethod )
			{
				case MedReportSelectMethod.Get:
					MedReportKey entityKey  = new MedReportKey();
					entityKey.Load(values);
					item = MedReportProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<MedReport>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MedReportSelectMethod.GetAll:
                    results = MedReportProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case MedReportSelectMethod.GetPaged:
					results = MedReportProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MedReportSelectMethod.Find:
					if ( FilterParameters != null )
						results = MedReportProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MedReportProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MedReportSelectMethod.GetByMedId:
					_medId = ( values["MedId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["MedId"], typeof(System.Int64)) : (long)0;
					item = MedReportProvider.GetByMedId(GetTransactionManager(), _medId);
					results = new TList<MedReport>();
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
			if ( SelectMethod == MedReportSelectMethod.Get || SelectMethod == MedReportSelectMethod.GetByMedId )
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
				MedReport entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					MedReportProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MedReport> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			MedReportProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MedReportDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MedReportDataSource class.
	/// </summary>
	public class MedReportDataSourceDesigner : ProviderDataSourceDesigner<MedReport, MedReportKey>
	{
		/// <summary>
		/// Initializes a new instance of the MedReportDataSourceDesigner class.
		/// </summary>
		public MedReportDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MedReportSelectMethod SelectMethod
		{
			get { return ((MedReportDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MedReportDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MedReportDataSourceActionList

	/// <summary>
	/// Supports the MedReportDataSourceDesigner class.
	/// </summary>
	internal class MedReportDataSourceActionList : DesignerActionList
	{
		private MedReportDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MedReportDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MedReportDataSourceActionList(MedReportDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MedReportSelectMethod SelectMethod
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

	#endregion MedReportDataSourceActionList
	
	#endregion MedReportDataSourceDesigner
	
	#region MedReportSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MedReportDataSource.SelectMethod property.
	/// </summary>
	public enum MedReportSelectMethod
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
		/// Represents the GetByMedId method.
		/// </summary>
		GetByMedId
	}
	
	#endregion MedReportSelectMethod

	#region MedReportFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportFilter : SqlFilter<MedReportColumn>
	{
	}
	
	#endregion MedReportFilter

	#region MedReportExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportExpressionBuilder : SqlExpressionBuilder<MedReportColumn>
	{
	}
	
	#endregion MedReportExpressionBuilder	

	#region MedReportProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MedReportChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportProperty : ChildEntityProperty<MedReportChildEntityTypes>
	{
	}
	
	#endregion MedReportProperty
}

