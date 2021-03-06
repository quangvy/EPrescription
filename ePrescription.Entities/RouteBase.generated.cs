﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Route.cs instead.
*/

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using ePrescription.Entities.Validation;
#endregion

namespace ePrescription.Entities
{
	///<summary>
	/// An object representation of the 'Route' table. [No description found the database]	
	///</summary>
	[Serializable]
	[DataObject, CLSCompliant(true)]
	public abstract partial class RouteBase : EntityBase, IRoute, IEntityId<RouteKey>, System.IComparable, System.ICloneable, ICloneableEx, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private RouteEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private RouteEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private RouteEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
		[NonSerialized]
		private TList<Route> parentCollection;
		
		private bool inTxn = false;
		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event RouteEventHandler ColumnChanging;		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event RouteEventHandler ColumnChanged;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="RouteBase"/> instance.
		///</summary>
		public RouteBase()
		{
			this.entityData = new RouteEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="RouteBase"/> instance.
		///</summary>
		///<param name="_route"></param>
		///<param name="_routeVn"></param>
		///<param name="_description"></param>
		public RouteBase(System.String _route, System.String _routeVn, System.String _description)
		{
			this.entityData = new RouteEntityData();
			this.backupData = null;

			this.Route = _route;
			this.RouteVn = _routeVn;
			this.Description = _description;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Route"/> instance.
		///</summary>
		///<param name="_route"></param>
		///<param name="_routeVn"></param>
		///<param name="_description"></param>
		public static Route CreateRoute(System.String _route, System.String _routeVn, System.String _description)
		{
			Route newRoute = new Route();
			newRoute.Route = _route;
			newRoute.RouteVn = _routeVn;
			newRoute.Description = _description;
			return newRoute;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the RouteId property. 
		///		
		/// </summary>
		/// <value>This type is bigint.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		
		[Required(ErrorMessage = "RouteId is required")]




		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, true, false)]
		public virtual System.Int64 RouteId
		{
			get
			{
				return this.entityData.RouteId; 
			}
			
			set
			{
				if (this.entityData.RouteId == value)
					return;
				
                OnPropertyChanging("RouteId");                    
				OnColumnChanging(RouteColumn.RouteId, this.entityData.RouteId);
				this.entityData.RouteId = value;
				this.EntityId.RouteId = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(RouteColumn.RouteId, this.entityData.RouteId);
				OnPropertyChanged("RouteId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Route property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String Route
		{
			get
			{
				return this.entityData.Route; 
			}
			
			set
			{
				if (this.entityData.Route == value)
					return;
				
                OnPropertyChanging("Route");                    
				OnColumnChanging(RouteColumn.Route, this.entityData.Route);
				this.entityData.Route = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(RouteColumn.Route, this.entityData.Route);
				OnPropertyChanged("Route");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the RouteVn property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 50)]
		public virtual System.String RouteVn
		{
			get
			{
				return this.entityData.RouteVn; 
			}
			
			set
			{
				if (this.entityData.RouteVn == value)
					return;
				
                OnPropertyChanging("RouteVn");                    
				OnColumnChanging(RouteColumn.RouteVn, this.entityData.RouteVn);
				this.entityData.RouteVn = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(RouteColumn.RouteVn, this.entityData.RouteVn);
				OnPropertyChanged("RouteVn");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Description property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		
		




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, true, 500)]
		public virtual System.String Description
		{
			get
			{
				return this.entityData.Description; 
			}
			
			set
			{
				if (this.entityData.Description == value)
					return;
				
                OnPropertyChanging("Description");                    
				OnColumnChanging(RouteColumn.Description, this.entityData.Description);
				this.entityData.Description = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(RouteColumn.Description, this.entityData.Description);
				OnPropertyChanged("Description");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("Route", "Route", 50));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("RouteVn", "Route Vn", 50));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("Description", "Description", 500));
		}
   		#endregion
		
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "Route"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"RouteId", "Route", "RouteVN", "Description"};
			}
		}
		#endregion 
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as RouteEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (Route) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<Route>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Route);
	        }
	    }


		#endregion
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Route Entity 
		///</summary>
		protected virtual Route Copy(IDictionary existingCopies)
		{
			if (existingCopies == null)
			{
				// This is the root of the tree to be copied!
				existingCopies = new Hashtable();
			}

			//shallow copy entity
			Route copy = new Route();
			existingCopies.Add(this, copy);
			copy.SuppressEntityEvents = true;
				copy.RouteId = this.RouteId;
				copy.Route = this.Route;
				copy.RouteVn = this.RouteVn;
				copy.Description = this.Description;
			
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}		
		
		
		
		///<summary>
		///  Returns a Typed Route Entity 
		///</summary>
		public virtual Route Copy()
		{
			return this.Copy(null);	
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy(null);
		}
		
		///<summary>
		/// ICloneableEx.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone(IDictionary existingCopies)
		{
			return this.Copy(existingCopies);
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x, IDictionary existingCopies)
		{
			if (x == null)
				return null;
			
			if (x is ICloneableEx)
			{
				// Return a deep copy of the object
				return ((ICloneableEx)x).Clone(existingCopies);
			}
			else if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable or IClonableEx Interface.");
		}
		
		
		///<summary>
		///  Returns a Typed Route Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Route DeepCopy()
		{
			return EntityHelper.Clone<Route>(this as Route);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as RouteEntityData;
			}
			else
			{
				//Since this had no _originalData, then just reset the entityData with a new one.  entityData cannot be null.
				this.entityData = new RouteEntityData();
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as RouteEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(RouteColumn column)
		{
			switch(column)
			{
					case RouteColumn.RouteId:
					return entityData.RouteId != _originalData.RouteId;
					case RouteColumn.Route:
					return entityData.Route != _originalData.Route;
					case RouteColumn.RouteVn:
					return entityData.RouteVn != _originalData.RouteVn;
					case RouteColumn.Description:
					return entityData.Description != _originalData.Description;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsPropertyChanged(string columnName)
		{
			return 	IsPropertyChanged(EntityHelper.GetEnumValue< RouteColumn >(columnName));
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if data has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.RouteId != _originalData.RouteId;
			result = result || entityData.Route != _originalData.Route;
			result = result || entityData.RouteVn != _originalData.RouteVn;
			result = result || entityData.Description != _originalData.Description;
			return result;
		}	
		
		///<summary>
		///  Returns a Route Entity with the original data.
		///</summary>
		public Route GetOriginalEntity()
		{
			if (_originalData != null)
				return CreateRoute(
				_originalData.Route,
				_originalData.RouteVn,
				_originalData.Description
				);
				
			return (Route)this.Clone();
		}
		#endregion
	
	#region Value Semantics Instance Equality
        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object using value semantics.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="RouteBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			// Cast exception if Object1 is null or DbNull
			if (Object1 != null && Object1 != DBNull.Value && Object1 is RouteBase)
				return ValueEquals(this, (RouteBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="RouteBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.RouteId.GetHashCode() ^ 
					((this.Route == null) ? string.Empty : this.Route.ToString()).GetHashCode() ^ 
					((this.RouteVn == null) ? string.Empty : this.RouteVn.ToString()).GetHashCode() ^ 
					((this.Description == null) ? string.Empty : this.Description.ToString()).GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object using value semantics.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="RouteBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(RouteBase toObject)
		{
			if (toObject == null)
				return false;
			return ValueEquals(this, toObject);
		}
		#endregion
		
		///<summary>
		/// Determines whether the specified <see cref="RouteBase"/> instances are considered equal using value semantics.
		///</summary>
		///<param name="Object1">The first <see cref="RouteBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="RouteBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool ValueEquals(RouteBase Object1, RouteBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.RouteId != Object2.RouteId)
				equal = false;
			if ( Object1.Route != null && Object2.Route != null )
			{
				if (Object1.Route != Object2.Route)
					equal = false;
			}
			else if (Object1.Route == null ^ Object2.Route == null )
			{
				equal = false;
			}
			if ( Object1.RouteVn != null && Object2.RouteVn != null )
			{
				if (Object1.RouteVn != Object2.RouteVn)
					equal = false;
			}
			else if (Object1.RouteVn == null ^ Object2.RouteVn == null )
			{
				equal = false;
			}
			if ( Object1.Description != null && Object2.Description != null )
			{
				if (Object1.Description != Object2.Description)
					equal = false;
			}
			else if (Object1.Description == null ^ Object2.Description == null )
			{
				equal = false;
			}
					
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((RouteBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
		}
		
		/*
		// static method to get a Comparer object
        public static RouteComparer GetComparer()
        {
            return new RouteComparer();
        }
        */

        // Comparer delegates back to Route
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(Route rhs, RouteColumn which)
        {
            switch (which)
            {
            	
            	
            	case RouteColumn.RouteId:
            		return this.RouteId.CompareTo(rhs.RouteId);
            		
            		                 
            	
            	
            	case RouteColumn.Route:
            		return this.Route.CompareTo(rhs.Route);
            		
            		                 
            	
            	
            	case RouteColumn.RouteVn:
            		return this.RouteVn.CompareTo(rhs.RouteVn);
            		
            		                 
            	
            	
            	case RouteColumn.Description:
            		return this.Description.CompareTo(rhs.Description);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public virtual void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<RouteKey> Members
		
		// member variable for the EntityId property
		private RouteKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public virtual RouteKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new RouteKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
		}
		#endregion 
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = new System.Text.StringBuilder("Route")
					.Append("|").Append( this.RouteId.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{5}{4}- RouteId: {0}{4}- Route: {1}{4}- RouteVn: {2}{4}- Description: {3}{4}{6}", 
				this.RouteId,
				(this.Route == null) ? string.Empty : this.Route.ToString(),
				(this.RouteVn == null) ? string.Empty : this.RouteVn.ToString(),
				(this.Description == null) ? string.Empty : this.Description.ToString(),
				System.Environment.NewLine, 
				this.GetType(),
				this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n",this.Error));
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Route' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class RouteEntityData : ICloneable, ICloneableEx
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
		/// <summary>			
		/// RouteId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Route"</remarks>
		public System.Int64 RouteId;
			
		#endregion
		
		#region Non Primary key(s)
		
		/// <summary>
		/// Route : 
		/// </summary>
		public System.String Route = null;
		
		/// <summary>
		/// RouteVN : 
		/// </summary>
		public System.String RouteVn = null;
		
		/// <summary>
		/// Description : 
		/// </summary>
		public System.String Description = null;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
        
		#endregion Variable Declarations

		#region Data Properties

		#endregion Data Properties
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			RouteEntityData _tmp = new RouteEntityData();
						
			_tmp.RouteId = this.RouteId;
			
			_tmp.Route = this.Route;
			_tmp.RouteVn = this.RouteVn;
			_tmp.Description = this.Description;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone(IDictionary existingCopies)
		{
			if (existingCopies == null)
				existingCopies = new Hashtable();
				
			RouteEntityData _tmp = new RouteEntityData();
						
			_tmp.RouteId = this.RouteId;
			
			_tmp.Route = this.Route;
			_tmp.RouteVn = this.RouteVn;
			_tmp.Description = this.Description;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct

		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="RouteColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanging(RouteColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="RouteColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanged(RouteColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="RouteColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanging(RouteColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
                EntityManager.StopTracking(entityTrackingKey);
                
			if (!SuppressEntityEvents)
			{
				RouteEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new RouteEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="RouteColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanged(RouteColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				RouteEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new RouteEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
	#region RouteEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Route"/> object.
	/// </remarks>
	public class RouteEventArgs : System.EventArgs
	{
		private RouteColumn column;
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the RouteEventArgs class.
		///</summary>
		public RouteEventArgs(RouteColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the RouteEventArgs class.
		///</summary>
		public RouteEventArgs(RouteColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The RouteColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="RouteColumn" />
		public RouteColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all Route related events.
	///</summary>
	public delegate void RouteEventHandler(object sender, RouteEventArgs e);
	
	#region RouteComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class RouteComparer : System.Collections.Generic.IComparer<Route>
	{
		RouteColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:RouteComparer"/> class.
        /// </summary>
		public RouteComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RouteComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public RouteComparer(RouteColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <see cref="Route"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <see cref="Route"/> to compare.</param>
        /// <param name="b">The second <c>Route</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Route a, Route b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Route entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Route a, Route b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public RouteColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region RouteKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Route"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class RouteKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the RouteKey class.
		/// </summary>
		public RouteKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the RouteKey class.
		/// </summary>
		public RouteKey(RouteBase entity)
		{
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.RouteId = entity.RouteId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the RouteKey class.
		/// </summary>
		public RouteKey(System.Int64 _routeId)
		{
			#region Init Properties

			this.RouteId = _routeId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private RouteBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public RouteBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the RouteId property
		private System.Int64 _routeId;
		
		/// <summary>
		/// Gets or sets the RouteId property.
		/// </summary>
		public System.Int64 RouteId
		{
			get { return _routeId; }
			set
			{
				if ( this.Entity != null )
					this.Entity.RouteId = value;
				
				_routeId = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				RouteId = ( values["RouteId"] != null ) ? (System.Int64) EntityUtil.ChangeType(values["RouteId"], typeof(System.Int64)) : (long)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("RouteId", RouteId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("RouteId: {0}{1}",
								RouteId,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region RouteColumn Enum
	
	/// <summary>
	/// Enumerate the Route columns.
	/// </summary>
	[Serializable]
	public enum RouteColumn : int
	{
		/// <summary>
		/// RouteId : 
		/// </summary>
		[EnumTextValue("Route Id")]
		[ColumnEnum("RouteId", typeof(System.Int64), System.Data.DbType.Int64, true, true, false)]
		RouteId = 1,
		/// <summary>
		/// Route : 
		/// </summary>
		[EnumTextValue("Route")]
		[ColumnEnum("Route", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Route = 2,
		/// <summary>
		/// RouteVn : 
		/// </summary>
		[EnumTextValue("Route Vn")]
		[ColumnEnum("RouteVN", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		RouteVn = 3,
		/// <summary>
		/// Description : 
		/// </summary>
		[EnumTextValue("Description")]
		[ColumnEnum("Description", typeof(System.String), System.Data.DbType.String, false, false, true, 500)]
		Description = 4
	}//End enum

	#endregion RouteColumn Enum

} // end namespace
