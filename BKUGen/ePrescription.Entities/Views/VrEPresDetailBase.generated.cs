﻿/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VrEPresDetail.cs instead.
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
	/// An object representation of the 'VR_ePresDetail' view. [No description found in the database]	
	///</summary>
	[Serializable]
	[CLSCompliant(true)]
	[ToolboxItem("VrEPresDetailBase")]
	public abstract partial class VrEPresDetailBase : System.IComparable, System.ICloneable, INotifyPropertyChanged
	{
		
		#region Variable Declarations
		
		/// <summary>
		/// PrescriptionDetailId : 
		/// </summary>
		private System.Int64		  _prescriptionDetailId = (long)0;
		
		/// <summary>
		/// PrescriptionID : 
		/// </summary>
		private System.String		  _prescriptionId = string.Empty;
		
		/// <summary>
		/// Sq : 
		/// </summary>
		private System.Int32		  _sq = (int)0;
		
		/// <summary>
		/// DrugId : 
		/// </summary>
		private System.String		  _drugId = null;
		
		/// <summary>
		/// DrugName : 
		/// </summary>
		private System.String		  _drugName = string.Empty;
		
		/// <summary>
		/// Unit : 
		/// </summary>
		private System.String		  _unit = null;
		
		/// <summary>
		/// UnitVN : 
		/// </summary>
		private System.String		  _unitVn = null;
		
		/// <summary>
		/// Remark : 
		/// </summary>
		private System.String		  _remark = null;
		
		/// <summary>
		/// Dosage : 
		/// </summary>
		private System.String		  _dosage = null;
		
		/// <summary>
		/// Frequency : 
		/// </summary>
		private System.String		  _frequency = null;
		
		/// <summary>
		/// VN_meaning : 
		/// </summary>
		private System.String		  _vnMeaning = null;
		
		/// <summary>
		/// Duration : 
		/// </summary>
		private System.String		  _duration = null;
		
		/// <summary>
		/// TotalUnit : 
		/// </summary>
		private System.String		  _totalUnit = null;
		
		/// <summary>
		/// Expr1 : 
		/// </summary>
		private System.String		  _expr1 = null;
		
		/// <summary>
		/// meaning : 
		/// </summary>
		private System.String		  _meaning = null;
		
		/// <summary>
		/// abbre : 
		/// </summary>
		private System.String		  _abbre = null;
		
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
		/// Creates a new <see cref="VrEPresDetailBase"/> instance.
		///</summary>
		public VrEPresDetailBase()
		{
		}		
		
		///<summary>
		/// Creates a new <see cref="VrEPresDetailBase"/> instance.
		///</summary>
		///<param name="_prescriptionDetailId"></param>
		///<param name="_prescriptionId"></param>
		///<param name="_sq"></param>
		///<param name="_drugId"></param>
		///<param name="_drugName"></param>
		///<param name="_unit"></param>
		///<param name="_unitVn"></param>
		///<param name="_remark"></param>
		///<param name="_dosage"></param>
		///<param name="_frequency"></param>
		///<param name="_vnMeaning"></param>
		///<param name="_duration"></param>
		///<param name="_totalUnit"></param>
		///<param name="_expr1"></param>
		///<param name="_meaning"></param>
		///<param name="_abbre"></param>
		public VrEPresDetailBase(System.Int64 _prescriptionDetailId, System.String _prescriptionId, System.Int32 _sq, System.String _drugId, System.String _drugName, System.String _unit, System.String _unitVn, System.String _remark, System.String _dosage, System.String _frequency, System.String _vnMeaning, System.String _duration, System.String _totalUnit, System.String _expr1, System.String _meaning, System.String _abbre)
		{
			this._prescriptionDetailId = _prescriptionDetailId;
			this._prescriptionId = _prescriptionId;
			this._sq = _sq;
			this._drugId = _drugId;
			this._drugName = _drugName;
			this._unit = _unit;
			this._unitVn = _unitVn;
			this._remark = _remark;
			this._dosage = _dosage;
			this._frequency = _frequency;
			this._vnMeaning = _vnMeaning;
			this._duration = _duration;
			this._totalUnit = _totalUnit;
			this._expr1 = _expr1;
			this._meaning = _meaning;
			this._abbre = _abbre;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="VrEPresDetail"/> instance.
		///</summary>
		///<param name="_prescriptionDetailId"></param>
		///<param name="_prescriptionId"></param>
		///<param name="_sq"></param>
		///<param name="_drugId"></param>
		///<param name="_drugName"></param>
		///<param name="_unit"></param>
		///<param name="_unitVn"></param>
		///<param name="_remark"></param>
		///<param name="_dosage"></param>
		///<param name="_frequency"></param>
		///<param name="_vnMeaning"></param>
		///<param name="_duration"></param>
		///<param name="_totalUnit"></param>
		///<param name="_expr1"></param>
		///<param name="_meaning"></param>
		///<param name="_abbre"></param>
		public static VrEPresDetail CreateVrEPresDetail(System.Int64 _prescriptionDetailId, System.String _prescriptionId, System.Int32 _sq, System.String _drugId, System.String _drugName, System.String _unit, System.String _unitVn, System.String _remark, System.String _dosage, System.String _frequency, System.String _vnMeaning, System.String _duration, System.String _totalUnit, System.String _expr1, System.String _meaning, System.String _abbre)
		{
			VrEPresDetail newVrEPresDetail = new VrEPresDetail();
			newVrEPresDetail.PrescriptionDetailId = _prescriptionDetailId;
			newVrEPresDetail.PrescriptionId = _prescriptionId;
			newVrEPresDetail.Sq = _sq;
			newVrEPresDetail.DrugId = _drugId;
			newVrEPresDetail.DrugName = _drugName;
			newVrEPresDetail.Unit = _unit;
			newVrEPresDetail.UnitVn = _unitVn;
			newVrEPresDetail.Remark = _remark;
			newVrEPresDetail.Dosage = _dosage;
			newVrEPresDetail.Frequency = _frequency;
			newVrEPresDetail.VnMeaning = _vnMeaning;
			newVrEPresDetail.Duration = _duration;
			newVrEPresDetail.TotalUnit = _totalUnit;
			newVrEPresDetail.Expr1 = _expr1;
			newVrEPresDetail.Meaning = _meaning;
			newVrEPresDetail.Abbre = _abbre;
			return newVrEPresDetail;
		}
				
		#endregion Constructors
		
		#region Properties	
		/// <summary>
		/// 	Gets or Sets the PrescriptionDetailId property. 
		///		
		/// </summary>
		/// <value>This type is bigint</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int64 PrescriptionDetailId
		{
			get
			{
				return this._prescriptionDetailId; 
			}
			set
			{
				if (_prescriptionDetailId == value)
					return;
					
				this._prescriptionDetailId = value;
				this._isDirty = true;
				
				OnPropertyChanged("PrescriptionDetailId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the PrescriptionID property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String PrescriptionId
		{
			get
			{
				return this._prescriptionId; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "PrescriptionId does not allow null values.");
				if (_prescriptionId == value)
					return;
					
				this._prescriptionId = value;
				this._isDirty = true;
				
				OnPropertyChanged("PrescriptionId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Sq property. 
		///		
		/// </summary>
		/// <value>This type is int</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.Int32 Sq
		{
			get
			{
				return this._sq; 
			}
			set
			{
				if (_sq == value)
					return;
					
				this._sq = value;
				this._isDirty = true;
				
				OnPropertyChanged("Sq");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the DrugId property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String DrugId
		{
			get
			{
				return this._drugId; 
			}
			set
			{
				if (_drugId == value)
					return;
					
				this._drugId = value;
				this._isDirty = true;
				
				OnPropertyChanged("DrugId");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the DrugName property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String DrugName
		{
			get
			{
				return this._drugName; 
			}
			set
			{
				if ( value == null )
					throw new ArgumentNullException("value", "DrugName does not allow null values.");
				if (_drugName == value)
					return;
					
				this._drugName = value;
				this._isDirty = true;
				
				OnPropertyChanged("DrugName");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Unit property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Unit
		{
			get
			{
				return this._unit; 
			}
			set
			{
				if (_unit == value)
					return;
					
				this._unit = value;
				this._isDirty = true;
				
				OnPropertyChanged("Unit");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the UnitVN property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String UnitVn
		{
			get
			{
				return this._unitVn; 
			}
			set
			{
				if (_unitVn == value)
					return;
					
				this._unitVn = value;
				this._isDirty = true;
				
				OnPropertyChanged("UnitVn");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Remark property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Remark
		{
			get
			{
				return this._remark; 
			}
			set
			{
				if (_remark == value)
					return;
					
				this._remark = value;
				this._isDirty = true;
				
				OnPropertyChanged("Remark");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Dosage property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Dosage
		{
			get
			{
				return this._dosage; 
			}
			set
			{
				if (_dosage == value)
					return;
					
				this._dosage = value;
				this._isDirty = true;
				
				OnPropertyChanged("Dosage");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Frequency property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Frequency
		{
			get
			{
				return this._frequency; 
			}
			set
			{
				if (_frequency == value)
					return;
					
				this._frequency = value;
				this._isDirty = true;
				
				OnPropertyChanged("Frequency");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the VN_meaning property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String VnMeaning
		{
			get
			{
				return this._vnMeaning; 
			}
			set
			{
				if (_vnMeaning == value)
					return;
					
				this._vnMeaning = value;
				this._isDirty = true;
				
				OnPropertyChanged("VnMeaning");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Duration property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Duration
		{
			get
			{
				return this._duration; 
			}
			set
			{
				if (_duration == value)
					return;
					
				this._duration = value;
				this._isDirty = true;
				
				OnPropertyChanged("Duration");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the TotalUnit property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String TotalUnit
		{
			get
			{
				return this._totalUnit; 
			}
			set
			{
				if (_totalUnit == value)
					return;
					
				this._totalUnit = value;
				this._isDirty = true;
				
				OnPropertyChanged("TotalUnit");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the Expr1 property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Expr1
		{
			get
			{
				return this._expr1; 
			}
			set
			{
				if (_expr1 == value)
					return;
					
				this._expr1 = value;
				this._isDirty = true;
				
				OnPropertyChanged("Expr1");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the meaning property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Meaning
		{
			get
			{
				return this._meaning; 
			}
			set
			{
				if (_meaning == value)
					return;
					
				this._meaning = value;
				this._isDirty = true;
				
				OnPropertyChanged("Meaning");
			}
		}
		
		/// <summary>
		/// 	Gets or Sets the abbre property. 
		///		
		/// </summary>
		/// <value>This type is nvarchar</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		public virtual System.String Abbre
		{
			get
			{
				return this._abbre; 
			}
			set
			{
				if (_abbre == value)
					return;
					
				this._abbre = value;
				this._isDirty = true;
				
				OnPropertyChanged("Abbre");
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
			get { return "VR_ePresDetail"; }
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
		///  Returns a Typed VrEPresDetailBase Entity 
		///</summary>
		public virtual VrEPresDetailBase Copy()
		{
			//shallow copy entity
			VrEPresDetail copy = new VrEPresDetail();
				copy.PrescriptionDetailId = this.PrescriptionDetailId;
				copy.PrescriptionId = this.PrescriptionId;
				copy.Sq = this.Sq;
				copy.DrugId = this.DrugId;
				copy.DrugName = this.DrugName;
				copy.Unit = this.Unit;
				copy.UnitVn = this.UnitVn;
				copy.Remark = this.Remark;
				copy.Dosage = this.Dosage;
				copy.Frequency = this.Frequency;
				copy.VnMeaning = this.VnMeaning;
				copy.Duration = this.Duration;
				copy.TotalUnit = this.TotalUnit;
				copy.Expr1 = this.Expr1;
				copy.Meaning = this.Meaning;
				copy.Abbre = this.Abbre;
			copy.AcceptChanges();
			return (VrEPresDetail)copy;
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
		///<returns>true if toObject is a <see cref="VrEPresDetailBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(VrEPresDetailBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="VrEPresDetailBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="VrEPresDetailBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="VrEPresDetailBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(VrEPresDetailBase Object1, VrEPresDetailBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;

			bool equal = true;
			if (Object1.PrescriptionDetailId != Object2.PrescriptionDetailId)
				equal = false;
			if (Object1.PrescriptionId != Object2.PrescriptionId)
				equal = false;
			if (Object1.Sq != Object2.Sq)
				equal = false;
			if (Object1.DrugId != null && Object2.DrugId != null )
			{
				if (Object1.DrugId != Object2.DrugId)
					equal = false;
			}
			else if (Object1.DrugId == null ^ Object1.DrugId == null )
			{
				equal = false;
			}
			if (Object1.DrugName != Object2.DrugName)
				equal = false;
			if (Object1.Unit != null && Object2.Unit != null )
			{
				if (Object1.Unit != Object2.Unit)
					equal = false;
			}
			else if (Object1.Unit == null ^ Object1.Unit == null )
			{
				equal = false;
			}
			if (Object1.UnitVn != null && Object2.UnitVn != null )
			{
				if (Object1.UnitVn != Object2.UnitVn)
					equal = false;
			}
			else if (Object1.UnitVn == null ^ Object1.UnitVn == null )
			{
				equal = false;
			}
			if (Object1.Remark != null && Object2.Remark != null )
			{
				if (Object1.Remark != Object2.Remark)
					equal = false;
			}
			else if (Object1.Remark == null ^ Object1.Remark == null )
			{
				equal = false;
			}
			if (Object1.Dosage != null && Object2.Dosage != null )
			{
				if (Object1.Dosage != Object2.Dosage)
					equal = false;
			}
			else if (Object1.Dosage == null ^ Object1.Dosage == null )
			{
				equal = false;
			}
			if (Object1.Frequency != null && Object2.Frequency != null )
			{
				if (Object1.Frequency != Object2.Frequency)
					equal = false;
			}
			else if (Object1.Frequency == null ^ Object1.Frequency == null )
			{
				equal = false;
			}
			if (Object1.VnMeaning != null && Object2.VnMeaning != null )
			{
				if (Object1.VnMeaning != Object2.VnMeaning)
					equal = false;
			}
			else if (Object1.VnMeaning == null ^ Object1.VnMeaning == null )
			{
				equal = false;
			}
			if (Object1.Duration != null && Object2.Duration != null )
			{
				if (Object1.Duration != Object2.Duration)
					equal = false;
			}
			else if (Object1.Duration == null ^ Object1.Duration == null )
			{
				equal = false;
			}
			if (Object1.TotalUnit != null && Object2.TotalUnit != null )
			{
				if (Object1.TotalUnit != Object2.TotalUnit)
					equal = false;
			}
			else if (Object1.TotalUnit == null ^ Object1.TotalUnit == null )
			{
				equal = false;
			}
			if (Object1.Expr1 != null && Object2.Expr1 != null )
			{
				if (Object1.Expr1 != Object2.Expr1)
					equal = false;
			}
			else if (Object1.Expr1 == null ^ Object1.Expr1 == null )
			{
				equal = false;
			}
			if (Object1.Meaning != null && Object2.Meaning != null )
			{
				if (Object1.Meaning != Object2.Meaning)
					equal = false;
			}
			else if (Object1.Meaning == null ^ Object1.Meaning == null )
			{
				equal = false;
			}
			if (Object1.Abbre != null && Object2.Abbre != null )
			{
				if (Object1.Abbre != Object2.Abbre)
					equal = false;
			}
			else if (Object1.Abbre == null ^ Object1.Abbre == null )
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
		public static object GetPropertyValueByName(VrEPresDetail entity, string propertyName)
		{
			switch (propertyName)
			{
				case "PrescriptionDetailId":
					return entity.PrescriptionDetailId;
				case "PrescriptionId":
					return entity.PrescriptionId;
				case "Sq":
					return entity.Sq;
				case "DrugId":
					return entity.DrugId;
				case "DrugName":
					return entity.DrugName;
				case "Unit":
					return entity.Unit;
				case "UnitVn":
					return entity.UnitVn;
				case "Remark":
					return entity.Remark;
				case "Dosage":
					return entity.Dosage;
				case "Frequency":
					return entity.Frequency;
				case "VnMeaning":
					return entity.VnMeaning;
				case "Duration":
					return entity.Duration;
				case "TotalUnit":
					return entity.TotalUnit;
				case "Expr1":
					return entity.Expr1;
				case "Meaning":
					return entity.Meaning;
				case "Abbre":
					return entity.Abbre;
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
			return GetPropertyValueByName(this as VrEPresDetail, propertyName);
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{17}{16}- PrescriptionDetailId: {0}{16}- PrescriptionId: {1}{16}- Sq: {2}{16}- DrugId: {3}{16}- DrugName: {4}{16}- Unit: {5}{16}- UnitVn: {6}{16}- Remark: {7}{16}- Dosage: {8}{16}- Frequency: {9}{16}- VnMeaning: {10}{16}- Duration: {11}{16}- TotalUnit: {12}{16}- Expr1: {13}{16}- Meaning: {14}{16}- Abbre: {15}{16}", 
				this.PrescriptionDetailId,
				this.PrescriptionId,
				this.Sq,
				(this.DrugId == null) ? string.Empty : this.DrugId.ToString(),
			     
				this.DrugName,
				(this.Unit == null) ? string.Empty : this.Unit.ToString(),
			     
				(this.UnitVn == null) ? string.Empty : this.UnitVn.ToString(),
			     
				(this.Remark == null) ? string.Empty : this.Remark.ToString(),
			     
				(this.Dosage == null) ? string.Empty : this.Dosage.ToString(),
			     
				(this.Frequency == null) ? string.Empty : this.Frequency.ToString(),
			     
				(this.VnMeaning == null) ? string.Empty : this.VnMeaning.ToString(),
			     
				(this.Duration == null) ? string.Empty : this.Duration.ToString(),
			     
				(this.TotalUnit == null) ? string.Empty : this.TotalUnit.ToString(),
			     
				(this.Expr1 == null) ? string.Empty : this.Expr1.ToString(),
			     
				(this.Meaning == null) ? string.Empty : this.Meaning.ToString(),
			     
				(this.Abbre == null) ? string.Empty : this.Abbre.ToString(),
			     
				System.Environment.NewLine, 
				this.GetType());
		}
	
	}//End Class
	
	
	/// <summary>
	/// Enumerate the VrEPresDetail columns.
	/// </summary>
	[Serializable]
	public enum VrEPresDetailColumn
	{
		/// <summary>
		/// PrescriptionDetailId : 
		/// </summary>
		[EnumTextValue("PrescriptionDetailId")]
		[ColumnEnum("PrescriptionDetailId", typeof(System.Int64), System.Data.DbType.Int64, false, false, false)]
		PrescriptionDetailId,
		/// <summary>
		/// PrescriptionID : 
		/// </summary>
		[EnumTextValue("PrescriptionID")]
		[ColumnEnum("PrescriptionID", typeof(System.String), System.Data.DbType.String, false, false, false, 20)]
		PrescriptionId,
		/// <summary>
		/// Sq : 
		/// </summary>
		[EnumTextValue("Sq")]
		[ColumnEnum("Sq", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		Sq,
		/// <summary>
		/// DrugId : 
		/// </summary>
		[EnumTextValue("DrugId")]
		[ColumnEnum("DrugId", typeof(System.String), System.Data.DbType.String, false, false, true, 20)]
		DrugId,
		/// <summary>
		/// DrugName : 
		/// </summary>
		[EnumTextValue("DrugName")]
		[ColumnEnum("DrugName", typeof(System.String), System.Data.DbType.String, false, false, false, 250)]
		DrugName,
		/// <summary>
		/// Unit : 
		/// </summary>
		[EnumTextValue("Unit")]
		[ColumnEnum("Unit", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Unit,
		/// <summary>
		/// UnitVN : 
		/// </summary>
		[EnumTextValue("UnitVN")]
		[ColumnEnum("UnitVN", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		UnitVn,
		/// <summary>
		/// Remark : 
		/// </summary>
		[EnumTextValue("Remark")]
		[ColumnEnum("Remark", typeof(System.String), System.Data.DbType.String, false, false, true, 250)]
		Remark,
		/// <summary>
		/// Dosage : 
		/// </summary>
		[EnumTextValue("Dosage")]
		[ColumnEnum("Dosage", typeof(System.String), System.Data.DbType.String, false, false, true, 20)]
		Dosage,
		/// <summary>
		/// Frequency : 
		/// </summary>
		[EnumTextValue("Frequency")]
		[ColumnEnum("Frequency", typeof(System.String), System.Data.DbType.String, false, false, true, 150)]
		Frequency,
		/// <summary>
		/// VN_meaning : 
		/// </summary>
		[EnumTextValue("VN_meaning")]
		[ColumnEnum("VN_meaning", typeof(System.String), System.Data.DbType.String, false, false, true, 250)]
		VnMeaning,
		/// <summary>
		/// Duration : 
		/// </summary>
		[EnumTextValue("Duration")]
		[ColumnEnum("Duration", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Duration,
		/// <summary>
		/// TotalUnit : 
		/// </summary>
		[EnumTextValue("TotalUnit")]
		[ColumnEnum("TotalUnit", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		TotalUnit,
		/// <summary>
		/// Expr1 : 
		/// </summary>
		[EnumTextValue("Expr1")]
		[ColumnEnum("Expr1", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Expr1,
		/// <summary>
		/// meaning : 
		/// </summary>
		[EnumTextValue("meaning")]
		[ColumnEnum("meaning", typeof(System.String), System.Data.DbType.String, false, false, true, 250)]
		Meaning,
		/// <summary>
		/// abbre : 
		/// </summary>
		[EnumTextValue("abbre")]
		[ColumnEnum("abbre", typeof(System.String), System.Data.DbType.String, false, false, true, 50)]
		Abbre
	}//End enum

} // end namespace