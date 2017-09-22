
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using ePrescription.Entities;
using ePrescription.Data;
using ePrescription.Data.Bases;

#endregion

namespace ePrescription.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : ePrescription.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <see cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "ClinicalStatsProvider"
			
		private SqlClinicalStatsProvider innerSqlClinicalStatsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ClinicalStats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ClinicalStatsProviderBase ClinicalStatsProvider
		{
			get
			{
				if (innerSqlClinicalStatsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlClinicalStatsProvider == null)
						{
							this.innerSqlClinicalStatsProvider = new SqlClinicalStatsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlClinicalStatsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlClinicalStatsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlClinicalStatsProvider SqlClinicalStatsProvider
		{
			get {return ClinicalStatsProvider as SqlClinicalStatsProvider;}
		}
		
		#endregion
		
		
		#region "MedReportProvider"
			
		private SqlMedReportProvider innerSqlMedReportProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MedReport"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MedReportProviderBase MedReportProvider
		{
			get
			{
				if (innerSqlMedReportProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMedReportProvider == null)
						{
							this.innerSqlMedReportProvider = new SqlMedReportProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMedReportProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlMedReportProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMedReportProvider SqlMedReportProvider
		{
			get {return MedReportProvider as SqlMedReportProvider;}
		}
		
		#endregion
		
		
		#region "RouteProvider"
			
		private SqlRouteProvider innerSqlRouteProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Route"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RouteProviderBase RouteProvider
		{
			get
			{
				if (innerSqlRouteProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRouteProvider == null)
						{
							this.innerSqlRouteProvider = new SqlRouteProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRouteProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlRouteProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRouteProvider SqlRouteProvider
		{
			get {return RouteProvider as SqlRouteProvider;}
		}
		
		#endregion
		
		
		#region "UserRolesProvider"
			
		private SqlUserRolesProvider innerSqlUserRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="UserRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UserRolesProviderBase UserRolesProvider
		{
			get
			{
				if (innerSqlUserRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUserRolesProvider == null)
						{
							this.innerSqlUserRolesProvider = new SqlUserRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUserRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUserRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUserRolesProvider SqlUserRolesProvider
		{
			get {return UserRolesProvider as SqlUserRolesProvider;}
		}
		
		#endregion
		
		
		#region "UsersProvider"
			
		private SqlUsersProvider innerSqlUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Users"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override UsersProviderBase UsersProvider
		{
			get
			{
				if (innerSqlUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlUsersProvider == null)
						{
							this.innerSqlUsersProvider = new SqlUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlUsersProvider SqlUsersProvider
		{
			get {return UsersProvider as SqlUsersProvider;}
		}
		
		#endregion
		
		
		#region "FrequencyProvider"
			
		private SqlFrequencyProvider innerSqlFrequencyProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Frequency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FrequencyProviderBase FrequencyProvider
		{
			get
			{
				if (innerSqlFrequencyProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFrequencyProvider == null)
						{
							this.innerSqlFrequencyProvider = new SqlFrequencyProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFrequencyProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlFrequencyProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFrequencyProvider SqlFrequencyProvider
		{
			get {return FrequencyProvider as SqlFrequencyProvider;}
		}
		
		#endregion
		
		
		#region "FavoritMasterProvider"
			
		private SqlFavoritMasterProvider innerSqlFavoritMasterProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="FavoritMaster"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FavoritMasterProviderBase FavoritMasterProvider
		{
			get
			{
				if (innerSqlFavoritMasterProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFavoritMasterProvider == null)
						{
							this.innerSqlFavoritMasterProvider = new SqlFavoritMasterProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFavoritMasterProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlFavoritMasterProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFavoritMasterProvider SqlFavoritMasterProvider
		{
			get {return FavoritMasterProvider as SqlFavoritMasterProvider;}
		}
		
		#endregion
		
		
		#region "FavoritDetailProvider"
			
		private SqlFavoritDetailProvider innerSqlFavoritDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="FavoritDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FavoritDetailProviderBase FavoritDetailProvider
		{
			get
			{
				if (innerSqlFavoritDetailProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFavoritDetailProvider == null)
						{
							this.innerSqlFavoritDetailProvider = new SqlFavoritDetailProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFavoritDetailProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlFavoritDetailProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFavoritDetailProvider SqlFavoritDetailProvider
		{
			get {return FavoritDetailProvider as SqlFavoritDetailProvider;}
		}
		
		#endregion
		
		
		#region "DiaglistProvider"
			
		private SqlDiaglistProvider innerSqlDiaglistProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Diaglist"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DiaglistProviderBase DiaglistProvider
		{
			get
			{
				if (innerSqlDiaglistProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDiaglistProvider == null)
						{
							this.innerSqlDiaglistProvider = new SqlDiaglistProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDiaglistProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDiaglistProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDiaglistProvider SqlDiaglistProvider
		{
			get {return DiaglistProvider as SqlDiaglistProvider;}
		}
		
		#endregion
		
		
		#region "DoctorRequestProvider"
			
		private SqlDoctorRequestProvider innerSqlDoctorRequestProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DoctorRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DoctorRequestProviderBase DoctorRequestProvider
		{
			get
			{
				if (innerSqlDoctorRequestProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDoctorRequestProvider == null)
						{
							this.innerSqlDoctorRequestProvider = new SqlDoctorRequestProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDoctorRequestProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlDoctorRequestProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDoctorRequestProvider SqlDoctorRequestProvider
		{
			get {return DoctorRequestProvider as SqlDoctorRequestProvider;}
		}
		
		#endregion
		
		
		#region "EPrescriptionProvider"
			
		private SqlEPrescriptionProvider innerSqlEPrescriptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EPrescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EPrescriptionProviderBase EPrescriptionProvider
		{
			get
			{
				if (innerSqlEPrescriptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEPrescriptionProvider == null)
						{
							this.innerSqlEPrescriptionProvider = new SqlEPrescriptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEPrescriptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEPrescriptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEPrescriptionProvider SqlEPrescriptionProvider
		{
			get {return EPrescriptionProvider as SqlEPrescriptionProvider;}
		}
		
		#endregion
		
		
		#region "EPrescriptionDetailProvider"
			
		private SqlEPrescriptionDetailProvider innerSqlEPrescriptionDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EPrescriptionDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EPrescriptionDetailProviderBase EPrescriptionDetailProvider
		{
			get
			{
				if (innerSqlEPrescriptionDetailProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEPrescriptionDetailProvider == null)
						{
							this.innerSqlEPrescriptionDetailProvider = new SqlEPrescriptionDetailProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEPrescriptionDetailProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlEPrescriptionDetailProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEPrescriptionDetailProvider SqlEPrescriptionDetailProvider
		{
			get {return EPrescriptionDetailProvider as SqlEPrescriptionDetailProvider;}
		}
		
		#endregion
		
		
		#region "VitalSignProvider"
			
		private SqlVitalSignProvider innerSqlVitalSignProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VitalSign"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VitalSignProviderBase VitalSignProvider
		{
			get
			{
				if (innerSqlVitalSignProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVitalSignProvider == null)
						{
							this.innerSqlVitalSignProvider = new SqlVitalSignProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVitalSignProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVitalSignProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVitalSignProvider SqlVitalSignProvider
		{
			get {return VitalSignProvider as SqlVitalSignProvider;}
		}
		
		#endregion
		
		
		
		#region "VrEPresDetailProvider"
		
		private SqlVrEPresDetailProvider innerSqlVrEPresDetailProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrEPresDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrEPresDetailProviderBase VrEPresDetailProvider
		{
			get
			{
				if (innerSqlVrEPresDetailProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrEPresDetailProvider == null)
						{
							this.innerSqlVrEPresDetailProvider = new SqlVrEPresDetailProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrEPresDetailProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrEPresDetailProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrEPresDetailProvider SqlVrEPresDetailProvider
		{
			get {return VrEPresDetailProvider as SqlVrEPresDetailProvider;}
		}
		
		#endregion
		
		
		#region "VrLabProcessingProvider"
		
		private SqlVrLabProcessingProvider innerSqlVrLabProcessingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrLabProcessing"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrLabProcessingProviderBase VrLabProcessingProvider
		{
			get
			{
				if (innerSqlVrLabProcessingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrLabProcessingProvider == null)
						{
							this.innerSqlVrLabProcessingProvider = new SqlVrLabProcessingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrLabProcessingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrLabProcessingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrLabProcessingProvider SqlVrLabProcessingProvider
		{
			get {return VrLabProcessingProvider as SqlVrLabProcessingProvider;}
		}
		
		#endregion
		
		
		#region "VrLabReqProvider"
		
		private SqlVrLabReqProvider innerSqlVrLabReqProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrLabReq"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrLabReqProviderBase VrLabReqProvider
		{
			get
			{
				if (innerSqlVrLabReqProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrLabReqProvider == null)
						{
							this.innerSqlVrLabReqProvider = new SqlVrLabReqProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrLabReqProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrLabReqProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrLabReqProvider SqlVrLabReqProvider
		{
			get {return VrLabReqProvider as SqlVrLabReqProvider;}
		}
		
		#endregion
		
		
		#region "VrLabResultProvider"
		
		private SqlVrLabResultProvider innerSqlVrLabResultProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrLabResult"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrLabResultProviderBase VrLabResultProvider
		{
			get
			{
				if (innerSqlVrLabResultProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrLabResultProvider == null)
						{
							this.innerSqlVrLabResultProvider = new SqlVrLabResultProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrLabResultProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrLabResultProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrLabResultProvider SqlVrLabResultProvider
		{
			get {return VrLabResultProvider as SqlVrLabResultProvider;}
		}
		
		#endregion
		
		
		#region "VrMedProProvider"
		
		private SqlVrMedProProvider innerSqlVrMedProProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrMedPro"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrMedProProviderBase VrMedProProvider
		{
			get
			{
				if (innerSqlVrMedProProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrMedProProvider == null)
						{
							this.innerSqlVrMedProProvider = new SqlVrMedProProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrMedProProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrMedProProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrMedProProvider SqlVrMedProProvider
		{
			get {return VrMedProProvider as SqlVrMedProProvider;}
		}
		
		#endregion
		
		
		#region "VrReceptionProvider"
		
		private SqlVrReceptionProvider innerSqlVrReceptionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrReception"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrReceptionProviderBase VrReceptionProvider
		{
			get
			{
				if (innerSqlVrReceptionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrReceptionProvider == null)
						{
							this.innerSqlVrReceptionProvider = new SqlVrReceptionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrReceptionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrReceptionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrReceptionProvider SqlVrReceptionProvider
		{
			get {return VrReceptionProvider as SqlVrReceptionProvider;}
		}
		
		#endregion
		
		
		#region "VrReceptionStartProvider"
		
		private SqlVrReceptionStartProvider innerSqlVrReceptionStartProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrReceptionStart"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrReceptionStartProviderBase VrReceptionStartProvider
		{
			get
			{
				if (innerSqlVrReceptionStartProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrReceptionStartProvider == null)
						{
							this.innerSqlVrReceptionStartProvider = new SqlVrReceptionStartProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrReceptionStartProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrReceptionStartProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrReceptionStartProvider SqlVrReceptionStartProvider
		{
			get {return VrReceptionStartProvider as SqlVrReceptionStartProvider;}
		}
		
		#endregion
		
		
		#region "VrTidChargedCodeProvider"
		
		private SqlVrTidChargedCodeProvider innerSqlVrTidChargedCodeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrTidChargedCode"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrTidChargedCodeProviderBase VrTidChargedCodeProvider
		{
			get
			{
				if (innerSqlVrTidChargedCodeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrTidChargedCodeProvider == null)
						{
							this.innerSqlVrTidChargedCodeProvider = new SqlVrTidChargedCodeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrTidChargedCodeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrTidChargedCodeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrTidChargedCodeProvider SqlVrTidChargedCodeProvider
		{
			get {return VrTidChargedCodeProvider as SqlVrTidChargedCodeProvider;}
		}
		
		#endregion
		
		
		#region "VrUnitTableProvider"
		
		private SqlVrUnitTableProvider innerSqlVrUnitTableProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="VrUnitTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override VrUnitTableProviderBase VrUnitTableProvider
		{
			get
			{
				if (innerSqlVrUnitTableProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlVrUnitTableProvider == null)
						{
							this.innerSqlVrUnitTableProvider = new SqlVrUnitTableProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlVrUnitTableProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <see cref="SqlVrUnitTableProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlVrUnitTableProvider SqlVrUnitTableProvider
		{
			get {return VrUnitTableProvider as SqlVrUnitTableProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
