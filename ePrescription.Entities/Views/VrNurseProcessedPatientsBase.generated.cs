﻿/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VrNurseProcessedPatients.cs instead.
*/
#region Using Directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml.Serialization;
#endregion

namespace ePrescription.Entities
{
	///<summary>
	/// An object representation of the 'Vr_NurseProcessedPatients' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VrNurseProcessedPatientsBase")]
	public abstract partial class VrNurseProcessedPatientsBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// StatId : 
		/// </summary>
		private System.Int64		  _statId = (long)0;
		
		/// <summary>
		/// PatientCode : 
		/// </summary>
		private System.String		  _patientCode = string.Empty;
		
		/// <summary>
		/// TID : 
		/// </summary>
		private System.String		  _tid = string.Empty;
		
		/// <summary>
		/// FirstName : 
		/// </summary>
		private System.String		  _firstName = string.Empty;
		
		/// <summary>
		/// LastName : 
		/// </summary>
		private System.String		  _lastName = string.Empty;
		
		/// <summary>
		/// DOB : 
		/// </summary>
		private System.DateTime		  _dob = DateTime.MinValue;
		
		/// <summary>
		/// Sex : 
		/// </summary>
		private System.String		  _sex = string.Empty;
		
		/// <summary>
		/// Nationality : 
		/// </summary>
		private System.String		  _nationality = string.Empty;
		
		/// <summary>
		/// PatientStart : 
		/// </summary>
		private System.Boolean?		  _patientStart = null;
		
		/// <summary>
		/// Lab : 
		/// </summary>
		private System.String		  _lab = null;
		
		/// <summary>
		/// ChargedCodes : 
		/// </summary>
		private System.String		  _chargedCodes = null;
		
		/// <summary>
		/// CreateDate : 
		/// </summary>
		private System.DateTime?		  _createDate = null;
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		private object _tag;
		
		/// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    [NonSerialized] 
		private bool suppressEntityEvents = false;
		
		#endregion Variable Declarations
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="VrNurseProcessedPatientsBase"/> instance.
		///</summary>
		public VrNurseProcessedPatientsBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="VrNurseProcessedPatientsBase"/> instance.
		///</summary>
		///<param name="_statId"></param>
		///<param name="_patientCode"></param>
		///<param name="_tid"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_dob"></param>
		///<param name="_sex"></param>
		///<param name="_nationality"></param>
		///<param name="_patientStart"></param>
		///<param name="_lab"></param>
		///<param name="_chargedCodes"></param>
		///<param name="_createDate"></param>
		public VrNurseProcessedPatientsBase(System.Int64 _statId, System.String _patientCode, System.String _tid, System.String _firstName, System.String _lastName, System.DateTime _dob, System.String _sex, System.String _nationality, System.Boolean? _patientStart, System.String _lab, System.String _chargedCodes, System.DateTime? _createDate)
		{
			this._statId = _statId;
			this._patientCode = _patientCode;
			this._tid = _tid;
			this._firstName = _firstName;
			this._lastName = _lastName;
			this._dob = _dob;
			this._sex = _sex;
			this._nationality = _nationality;
			this._patientStart = _patientStart;
			this._lab = _lab;
			this._chargedCodes = _chargedCodes;
			this._createDate = _createDate;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VrNurseProcessedPatients"/> instance.
		///</summary>
		///<param name="_statId"></param>
		///<param name="_patientCode"></param>
		///<param name="_tid"></param>
		///<param name="_firstName"></param>
		///<param name="_lastName"></param>
		///<param name="_dob"></param>
		///<param name="_sex"></param>
		///<param name="_nationality"></param>
		///<param name="_patientStart"></param>
		///<param name="_lab"></param>
		///<param name="_chargedCodes"></param>
		///<param name="_createDate"></param>
		public static VrNurseProcessedPatients CreateVrNurseProcessedPatients(System.Int64 _statId, System.String _patientCode, System.String _tid, System.String _firstName, System.String _lastName, System.DateTime _dob, System.String _sex, System.String _nationality, System.Boolean? _patientStart, System.String _lab, System.String _chargedCodes, System.DateTime? _createDate)
		{
			VrNurseProcessedPatients newVrNurseProcessedPatients = new VrNurseProcessedPatients();
			newVrNurseProcessedPatients.StatId = _statId;
			newVrNurseProcessedPatients.PatientCode = _patientCode;
			newVrNurseProcessedPatients.Tid = _tid;
			newVrNurseProcessedPatients.FirstName = _firstName;
			newVrNurseProcessedPatients.LastName = _lastName;
			newVrNurseProcessedPatients.Dob = _dob;
			newVrNurseProcessedPatients.Sex = _sex;
			newVrNurseProcessedPatients.Nationality = _nationality;
			newVrNurseProcessedPatients.PatientStart = _patientStart;
			newVrNurseProcessedPatients.Lab = _lab;
			newVrNurseProcessedPatients.ChargedCodes = _chargedCodes;
			newVrNurseProcessedPatients.CreateDate = _createDate;
			return newVrNurseProcessedPatients;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the StatId property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 StatId
		{
			get
			{
				return this._statId; 
			}
			set
			{
				if (_statId == value)
					return;
					
				this._statId = value;
				this._isDirty = true;
				
				OnPropertyChanged("StatId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the PatientCode property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String PatientCode
		{
			get
			{
				return this._patientCode; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "PatientCode does not allow null values.");
				if (_patientCode == value)
					return;
					
				this._patientCode = value;
				this._isDirty = true;
				
				OnPropertyChanged("PatientCode");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the TID property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Tid
		{
			get
			{
				return this._tid; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Tid does not allow null values.");
				if (_tid == value)
					return;
					
				this._tid = value;
				this._isDirty = true;
				
				OnPropertyChanged("Tid");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the FirstName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String FirstName
		{
			get
			{
				return this._firstName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "FirstName does not allow null values.");
				if (_firstName == value)
					return;
					
				this._firstName = value;
				this._isDirty = true;
				
				OnPropertyChanged("FirstName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the LastName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String LastName
		{
			get
			{
				return this._lastName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "LastName does not allow null values.");
				if (_lastName == value)
					return;
					
				this._lastName = value;
				this._isDirty = true;
				
				OnPropertyChanged("LastName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the DOB property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime Dob
		{
			get
			{
				return this._dob; 
			}
			set
			{
				if (_dob == value)
					return;
					
				this._dob = value;
				this._isDirty = true;
				
				OnPropertyChanged("Dob");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Sex property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Sex
		{
			get
			{
				return this._sex; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Sex does not allow null values.");
				if (_sex == value)
					return;
					
				this._sex = value;
				this._isDirty = true;
				
				OnPropertyChanged("Sex");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Nationality property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Nationality
		{
			get
			{
				return this._nationality; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "Nationality does not allow null values.");
				if (_nationality == value)
					return;
					
				this._nationality = value;
				this._isDirty = true;
				
				OnPropertyChanged("Nationality");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the PatientStart property. 
		///		
		/// </summary>
		/// <value>This type is bit</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return false. It is up to the developer
		/// to check the value of IsPatientStartNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Boolean? PatientStart
		{
			get
			{
				return this._patientStart; 
			}
			set
			{
				if (_patientStart == value && PatientStart != null )
					return;
					
				this._patientStart = value;
				this._isDirty = true;
				
				OnPropertyChanged("PatientStart");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Lab property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Lab
		{
			get
			{
				return this._lab; 
			}
			set
			{
				if (_lab == value)
					return;
					
				this._lab = value;
				this._isDirty = true;
				
				OnPropertyChanged("Lab");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the ChargedCodes property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String ChargedCodes
		{
			get
			{
				return this._chargedCodes; 
			}
			set
			{
				if (_chargedCodes == value)
					return;
					
				this._chargedCodes = value;
				this._isDirty = true;
				
				OnPropertyChanged("ChargedCodes");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the CreateDate property. 
		///		
		/// </summary>
		/// <value>This type is datetime</value>
		/// <remarks>
		/// This property can be set to null. 
		/// If this column is null, this property will return DateTime.MinValue. It is up to the developer
		/// to check the value of IsCreateDateNull() and perform business logic appropriately.
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.DateTime? CreateDate
		{
			get
			{
				return this._createDate; 
			}
			set
			{
				if (_createDate == value && CreateDate != null )
					return;
					
				this._createDate = value;
				this._isDirty = true;
				
				OnPropertyChanged("CreateDate");
			}
		}
		
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this._tag;
			}
			set
			{
				if (this._tag == value)
					return;
		
				this._tag = value;
			}
		}
	
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}

		private bool _isDeleted = false;
		/// <summary>
		/// Gets a value indicating if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDeleted
		{
			get { return this._isDeleted; }
		}


		private bool _isDirty = false;
		/// <summary>
		///	Gets a value indicating  if the object has been modified from its original state.
		/// </summary>
		///<value>True if object has been modified from its original state; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsDirty
		{
			get { return this._isDirty; }
		}
		

		private bool _isNew = true;
		/// <summary>
		///	Gets a value indicating if the object is new.
		/// </summary>
		///<value>True if objectis new; otherwise False;</value>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual bool IsNew
		{
			get { return this._isNew; }
			set { this._isNew = value; }
		}

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public string ViewName
		{
			get { return "Vr_NurseProcessedPatients"; }
		}

		
		#endregion
		
		#region Methods	
		
		/// <summary>
		/// Accepts the changes made to this object by setting each flags to false.
		/// </summary>
		public virtual void AcceptChanges()
		{
			this._isDeleted = false;
			this._isDirty = false;
			this._isNew = false;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public virtual void CancelChanges()
		{
			throw new NotSupportedException("Method currently not Supported.");
		}
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			this._isDeleted = true;
		}
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed VrNurseProcessedPatientsBase Entity 
		///</summary>
		public virtual VrNurseProcessedPatientsBase Copy()
		{
			//shallow copy entity
			VrNurseProcessedPatients copy = new VrNurseProcessedPatients();
				copy.StatId = this.StatId;
				copy.PatientCode = this.PatientCode;
				copy.Tid = this.Tid;
				copy.FirstName = this.FirstName;
				copy.LastName = this.LastName;
				copy.Dob = this.Dob;
				copy.Sex = this.Sex;
				copy.Nationality = this.Nationality;
				copy.PatientStart = this.PatientStart;
				copy.Lab = this.Lab;
				copy.ChargedCodes = this.ChargedCodes;
				copy.CreateDate = this.CreateDate;
			copy.AcceptChanges();
			return (VrNurseProcessedPatients)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
		///</summary>
		public object Clone(){
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="VrNurseProcessedPatientsBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VrNurseProcessedPatientsBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="VrNurseProcessedPatientsBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VrNurseProcessedPatientsBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VrNurseProcessedPatientsBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VrNurseProcessedPatientsBase Object1, VrNurseProcessedPatientsBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.StatId != Object2.StatId)
				equal = false;
			if (Object1.PatientCode != Object2.PatientCode)
				equal = false;
			if (Object1.Tid != Object2.Tid)
				equal = false;
			if (Object1.FirstName != Object2.FirstName)
				equal = false;
			if (Object1.LastName != Object2.LastName)
				equal = false;
			if (Object1.Dob != Object2.Dob)
				equal = false;
			if (Object1.Sex != Object2.Sex)
				equal = false;
			if (Object1.Nationality != Object2.Nationality)
				equal = false;
			if (Object1.PatientStart != null && Object2.PatientStart != null )
			{
				if (Object1.PatientStart != Object2.PatientStart)
					equal = false;
			}
			else if (Object1.PatientStart == null ^ Object1.PatientStart == null )
			{
				equal = false;
			}
			if (Object1.Lab != null && Object2.Lab != null )
			{
				if (Object1.Lab != Object2.Lab)
					equal = false;
			}
			else if (Object1.Lab == null ^ Object1.Lab == null )
			{
				equal = false;
			}
			if (Object1.ChargedCodes != null && Object2.ChargedCodes != null )
			{
				if (Object1.ChargedCodes != Object2.ChargedCodes)
					equal = false;
			}
			else if (Object1.ChargedCodes == null ^ Object1.ChargedCodes == null )
			{
				equal = false;
			}
			if (Object1.CreateDate != null && Object2.CreateDate != null )
			{
				if (Object1.CreateDate != Object2.CreateDate)
					equal = false;
			}
			else if (Object1.CreateDate == null ^ Object1.CreateDate == null )
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
		}
	
		#endregion
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
      /// Event to indicate that a property has changed.
      /// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		
		/// <summary>
      /// Called when a property is changed
      /// </summary>
      /// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!SuppressEntityEvents)
			{
				if (null != PropertyChanged)
				{
					PropertyChanged(this, e);
				}
			}
		}
		
		#endregion
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static object GetPropertyValueByName(VrNurseProcessedPatients entity, string propertyName)
		{
			switch (propertyName)
			{
				case "StatId":
					return entity.StatId;
				case "PatientCode":
					return entity.PatientCode;
				case "Tid":
					return entity.Tid;
				case "FirstName":
					return entity.FirstName;
				case "LastName":
					return entity.LastName;
				case "Dob":
					return entity.Dob;
				case "Sex":
					return entity.Sex;
				case "Nationality":
					return entity.Nationality;
				case "PatientStart":
					return entity.PatientStart;
				case "Lab":
					return entity.Lab;
				case "ChargedCodes":
					return entity.ChargedCodes;
				case "CreateDate":
					return entity.CreateDate;
			}
			return null;
		}
				
		/// <summary>
		/// Gets the property value by name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public object GetPropertyValueByName(string propertyName)
		{			
			return GetPropertyValueByName(this as VrNurseProcessedPatients, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{13}{12}- StatId: {0}{12}- PatientCode: {1}{12}- Tid: {2}{12}- FirstName: {3}{12}- LastName: {4}{12}- Dob: {5}{12}- Sex: {6}{12}- Nationality: {7}{12}- PatientStart: {8}{12}- Lab: {9}{12}- ChargedCodes: {10}{12}- CreateDate: {11}{12}", 
				this.StatId,
				this.PatientCode,
				this.Tid,
				this.FirstName,
				this.LastName,
				this.Dob,
				this.Sex,
				this.Nationality,
				(this.PatientStart == null) ? string.Empty : this.PatientStart.ToString(),
			     
				(this.Lab == null) ? string.Empty : this.Lab.ToString(),
			     
				(this.ChargedCodes == null) ? string.Empty : this.ChargedCodes.ToString(),
			     
				(this.CreateDate == null) ? string.Empty : this.CreateDate.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the VrNurseProcessedPatients columns.
	/// </summary>
	[Serializable]
	public enum VrNurseProcessedPatientsColumn
	{
		/// <summary>
		/// StatId : 
		/// </summary>
		[EnumTextValue("StatId")]
		[ColumnEnum("StatId", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		StatId,
		/// <summary>
		/// PatientCode : 
		/// </summary>
		[EnumTextValue("PatientCode")]
		[ColumnEnum("PatientCode", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		PatientCode,
		/// <summary>
		/// TID : 
		/// </summary>
		[EnumTextValue("TID")]
		[ColumnEnum("TID", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		Tid,
		/// <summary>
		/// FirstName : 
		/// </summary>
		[EnumTextValue("FirstName")]
		[ColumnEnum("FirstName", typeof(System.String), System.Data.DbType.String, false, false, false, 30)]
		FirstName,
		/// <summary>
		/// LastName : 
		/// </summary>
		[EnumTextValue("LastName")]
		[ColumnEnum("LastName", typeof(System.String), System.Data.DbType.String, false, false, false, 30)]
		LastName,
		/// <summary>
		/// DOB : 
		/// </summary>
		[EnumTextValue("DOB")]
		[ColumnEnum("DOB", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		Dob,
		/// <summary>
		/// Sex : 
		/// </summary>
		[EnumTextValue("Sex")]
		[ColumnEnum("Sex", typeof(System.String), System.Data.DbType.String, false, false, false, 10)]
		Sex,
		/// <summary>
		/// Nationality : 
		/// </summary>
		[EnumTextValue("Nationality")]
		[ColumnEnum("Nationality", typeof(System.String), System.Data.DbType.String, false, false, false, 50)]
		Nationality,
		/// <summary>
		/// PatientStart : 
		/// </summary>
		[EnumTextValue("PatientStart")]
		[ColumnEnum("PatientStart", typeof(System.Boolean), System.Data.DbType.Boolean, false, false, true)]
		PatientStart,
		/// <summary>
		/// Lab : 
		/// </summary>
		[EnumTextValue("Lab")]
		[ColumnEnum("Lab", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Lab,
		/// <summary>
		/// ChargedCodes : 
		/// </summary>
		[EnumTextValue("ChargedCodes")]
		[ColumnEnum("ChargedCodes", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		ChargedCodes,
		/// <summary>
		/// CreateDate : 
		/// </summary>
		[EnumTextValue("CreateDate")]
		[ColumnEnum("CreateDate", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, true)]
		CreateDate
	}//End enum

} // end namespace
