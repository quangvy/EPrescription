
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
		/// Current UserRolesProviderBase instance.
		///</summary>
		public virtual UserRolesProviderBase UserRolesProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EPrescriptionProviderBase instance.
		///</summary>
		public virtual EPrescriptionProviderBase EPrescriptionProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current FavoritMasterProviderBase instance.
		///</summary>
		public virtual FavoritMasterProviderBase FavoritMasterProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current UsersProviderBase instance.
		///</summary>
		public virtual UsersProviderBase UsersProvider{get {throw new NotImplementedException();}}
		
		///<summary>
		/// Current EPrescriptionDetailProviderBase instance.
		///</summary>
		public virtual EPrescriptionDetailProviderBase EPrescriptionDetailProvider{get {throw new NotImplementedException();}}
		
		
		///<summary>
		/// Current VrEPresDetailProviderBase instance.
		///</summary>
		public virtual VrEPresDetailProviderBase VrEPresDetailProvider{get {throw new NotImplementedException();}}
		
	}
}
