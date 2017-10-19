﻿using System;
using System.ComponentModel;

namespace ePrescription.Entities
{
	/// <summary>
	///		The data structure representation of the 'ClinicalStats' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IClinicalStats 
	{
		/// <summary>			
		/// StatId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ClinicalStats"</remarks>
		System.Int64 StatId { get; set; }
				
		
		
		/// <summary>
		/// PatientCode : 
		/// </summary>
		System.String  PatientCode  { get; set; }
		
		/// <summary>
		/// TID : 
		/// </summary>
		System.String  Tid  { get; set; }
		
		/// <summary>
		/// FirstName : 
		/// </summary>
		System.String  FirstName  { get; set; }
		
		/// <summary>
		/// LastName : 
		/// </summary>
		System.String  LastName  { get; set; }
		
		/// <summary>
		/// DOB : 
		/// </summary>
		System.DateTime  Dob  { get; set; }
		
		/// <summary>
		/// Sex : 
		/// </summary>
		System.String  Sex  { get; set; }
		
		/// <summary>
		/// Nationality : 
		/// </summary>
		System.String  Nationality  { get; set; }
		
		/// <summary>
		/// PatientStart : 
		/// </summary>
		System.Boolean?  PatientStart  { get; set; }
		
		/// <summary>
		/// VitalSign : 
		/// </summary>
		System.String  VitalSign  { get; set; }
		
		/// <summary>
		/// Lab : 
		/// </summary>
		System.String  Lab  { get; set; }
		
		/// <summary>
		/// Xray : 
		/// </summary>
		System.String  Xray  { get; set; }
		
		/// <summary>
		/// UltraSound : 
		/// </summary>
		System.String  UltraSound  { get; set; }
		
		/// <summary>
		/// Cardiology : 
		/// </summary>
		System.String  Cardiology  { get; set; }
		
		/// <summary>
		/// MedReport : 
		/// </summary>
		System.String  MedReport  { get; set; }
		
		/// <summary>
		/// ChargedCodes : 
		/// </summary>
		System.String  ChargedCodes  { get; set; }
		
		/// <summary>
		/// IsCompleted : 
		/// </summary>
		System.Boolean?  IsCompleted  { get; set; }
		
		/// <summary>
		/// CreateDate : 
		/// </summary>
		System.DateTime?  CreateDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

