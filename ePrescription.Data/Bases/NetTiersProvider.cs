
#region Using directives

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using ePrescription.Entities;

#endregion

namespace ePrescription.Data.Bases
{	
	///<summary>
	/// The base class to implements to create a .NetTiers provider.
	///</summary>
	public abstract class NetTiersProvider : NetTiersProviderBase
	{
		
		///<summary>
		/// Current ClinicalStatsProviderBase instance.
		///</summary>
		public virtual ClinicalStatsProviderBase ClinicalStatsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PackageProviderBase instance.
		///</summary>
		public virtual PackageProviderBase PackageProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current PackageDetailProviderBase instance.
		///</summary>
		public virtual PackageDetailProviderBase PackageDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current RouteProviderBase instance.
		///</summary>
		public virtual RouteProviderBase RouteProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UserRolesProviderBase instance.
		///</summary>
		public virtual UserRolesProviderBase UserRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UsersProviderBase instance.
		///</summary>
		public virtual UsersProviderBase UsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current MedReportProviderBase instance.
		///</summary>
		public virtual MedReportProviderBase MedReportProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FrequencyProviderBase instance.
		///</summary>
		public virtual FrequencyProviderBase FrequencyProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FavoritMasterProviderBase instance.
		///</summary>
		public virtual FavoritMasterProviderBase FavoritMasterProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DiaglistProviderBase instance.
		///</summary>
		public virtual DiaglistProviderBase DiaglistProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current DoctorRequestProviderBase instance.
		///</summary>
		public virtual DoctorRequestProviderBase DoctorRequestProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EPrescriptionProviderBase instance.
		///</summary>
		public virtual EPrescriptionProviderBase EPrescriptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EPrescriptionDetailProviderBase instance.
		///</summary>
		public virtual EPrescriptionDetailProviderBase EPrescriptionDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FavoritDetailProviderBase instance.
		///</summary>
		public virtual FavoritDetailProviderBase FavoritDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VitalSignProviderBase instance.
		///</summary>
		public virtual VitalSignProviderBase VitalSignProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current VrDoctorDoneProviderBase instance.
		///</summary>
		public virtual VrDoctorDoneProviderBase VrDoctorDoneProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrDoctorwipProviderBase instance.
		///</summary>
		public virtual VrDoctorwipProviderBase VrDoctorwipProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrEPresDetailProviderBase instance.
		///</summary>
		public virtual VrEPresDetailProviderBase VrEPresDetailProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrLabProcessingProviderBase instance.
		///</summary>
		public virtual VrLabProcessingProviderBase VrLabProcessingProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrLabReceiveProviderBase instance.
		///</summary>
		public virtual VrLabReceiveProviderBase VrLabReceiveProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrLabReqProviderBase instance.
		///</summary>
		public virtual VrLabReqProviderBase VrLabReqProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrLabResultProviderBase instance.
		///</summary>
		public virtual VrLabResultProviderBase VrLabResultProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrLabwipProviderBase instance.
		///</summary>
		public virtual VrLabwipProviderBase VrLabwipProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrMedProProviderBase instance.
		///</summary>
		public virtual VrMedProProviderBase VrMedProProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrNurseProcessedPatientsProviderBase instance.
		///</summary>
		public virtual VrNurseProcessedPatientsProviderBase VrNurseProcessedPatientsProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrReceptionProviderBase instance.
		///</summary>
		public virtual VrReceptionProviderBase VrReceptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrReceptionDoneProviderBase instance.
		///</summary>
		public virtual VrReceptionDoneProviderBase VrReceptionDoneProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrReceptionStartProviderBase instance.
		///</summary>
		public virtual VrReceptionStartProviderBase VrReceptionStartProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrTidChargedCodeProviderBase instance.
		///</summary>
		public virtual VrTidChargedCodeProviderBase VrTidChargedCodeProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current VrUnitTableProviderBase instance.
		///</summary>
		public virtual VrUnitTableProviderBase VrUnitTableProvider{get {throw new NotImplementedException();}}
		
	}
}
