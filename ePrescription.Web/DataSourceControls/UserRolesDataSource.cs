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
	/// Represents the DataRepository.UserRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(UserRolesDataSourceDesigner))]
	public class UserRolesDataSource : ProviderDataSource<UserRoles, UserRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserRolesDataSource class.
		/// </summary>
		public UserRolesDataSource() : base(DataRepository.UserRolesProvider)
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the UserRolesDataSourceView used by the UserRolesDataSource.
		/// </summary>
		protected UserRolesDataSourceView UserRolesView
		{
			get { return ( View as UserRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the UserRolesDataSource control invokes to retrieve data.
		/// </summary>
		public UserRolesSelectMethod SelectMethod
		{
			get
			{
				UserRolesSelectMethod selectMethod = UserRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (UserRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the UserRolesDataSourceView class that is to be
		/// used by the UserRolesDataSource.
		/// </summary>
		/// <returns>An instance of the UserRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<UserRoles, UserRolesKey> GetNewDataSourceView()
		{
			return new UserRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the UserRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class UserRolesDataSourceView : ProviderDataSourceView<UserRoles, UserRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the UserRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public UserRolesDataSourceView(UserRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal UserRolesDataSource UserRolesOwner
		{
			get { return Owner as UserRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal UserRolesSelectMethod SelectMethod
		{
			get { return UserRolesOwner.SelectMethod; }
			set { UserRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal UserRolesProviderBase UserRolesProvider
		{
			get { return Provider as UserRolesProviderBase; }
		}

		#endregion Properties
		
		#region Methods
		 
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
	    /// <param name="values"></param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<UserRoles> GetSelectData(IDictionary values, out int count)
		{
            if (values == null || values.Count == 0) values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
            
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<UserRoles> results = null;
			UserRoles item;
			count = 0;
			
			System.String _roleId;

			switch ( SelectMethod )
			{
				case UserRolesSelectMethod.Get:
					UserRolesKey entityKey  = new UserRolesKey();
					entityKey.Load(values);
					item = UserRolesProvider.Get(GetTransactionManager(), entityKey);
					results = new TList<UserRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case UserRolesSelectMethod.GetAll:
                    results = UserRolesProvider.GetAll(GetTransactionManager(), StartIndex, PageSize, out count);
                    break;
				case UserRolesSelectMethod.GetPaged:
					results = UserRolesProvider.GetPaged(GetTransactionManager(), WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case UserRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = UserRolesProvider.Find(GetTransactionManager(), FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = UserRolesProvider.Find(GetTransactionManager(), WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case UserRolesSelectMethod.GetByRoleId:
					_roleId = ( values["RoleId"] != null ) ? (System.String) EntityUtil.ChangeType(values["RoleId"], typeof(System.String)) : string.Empty;
					item = UserRolesProvider.GetByRoleId(GetTransactionManager(), _roleId);
					results = new TList<UserRoles>();
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
			if ( SelectMethod == UserRolesSelectMethod.Get || SelectMethod == UserRolesSelectMethod.GetByRoleId )
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
				UserRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// execute deep load method
					UserRolesProvider.DeepLoad(GetTransactionManager(), GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<UserRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// execute deep load method
			UserRolesProvider.DeepLoad(GetTransactionManager(), entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region UserRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the UserRolesDataSource class.
	/// </summary>
	public class UserRolesDataSourceDesigner : ProviderDataSourceDesigner<UserRoles, UserRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the UserRolesDataSourceDesigner class.
		/// </summary>
		public UserRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserRolesSelectMethod SelectMethod
		{
			get { return ((UserRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new UserRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region UserRolesDataSourceActionList

	/// <summary>
	/// Supports the UserRolesDataSourceDesigner class.
	/// </summary>
	internal class UserRolesDataSourceActionList : DesignerActionList
	{
		private UserRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the UserRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public UserRolesDataSourceActionList(UserRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public UserRolesSelectMethod SelectMethod
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

	#endregion UserRolesDataSourceActionList
	
	#endregion UserRolesDataSourceDesigner
	
	#region UserRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the UserRolesDataSource.SelectMethod property.
	/// </summary>
	public enum UserRolesSelectMethod
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
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId
	}
	
	#endregion UserRolesSelectMethod

	#region UserRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserRolesFilter : SqlFilter<UserRolesColumn>
	{
	}
	
	#endregion UserRolesFilter

	#region UserRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserRolesExpressionBuilder : SqlExpressionBuilder<UserRolesColumn>
	{
	}
	
	#endregion UserRolesExpressionBuilder	

	#region UserRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;UserRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="UserRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserRolesProperty : ChildEntityProperty<UserRolesChildEntityTypes>
	{
	}
	
	#endregion UserRolesProperty
}

