#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ePrescription.Entities;
using ePrescription.Data;

#endregion

namespace ePrescription.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="VrLabReceiveProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class VrLabReceiveProviderBase : VrLabReceiveProviderBaseCore
	{
	} // end class
} // end namespace
