#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using ePrescription.Entities;
using ePrescription.Data;

#endregion

namespace ePrescription.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="VrLabProcessing"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlVrLabProcessingProvider: SqlVrLabProcessingProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="SqlVrLabProcessingProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlVrLabProcessingProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}