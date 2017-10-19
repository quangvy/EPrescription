#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using ePrescription.Entities;
using ePrescription.Data;
using ePrescription.Data.Bases;

#endregion

namespace ePrescription.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <see cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("ePrescription.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.10.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
					// use default ConnectionStrings if _section has already been discovered
					if ( _config == null && _section != null )
					{
						return WebConfigurationManager.ConnectionStrings;
					}
					
					return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region ClinicalStatsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ClinicalStats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ClinicalStatsProviderBase ClinicalStatsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ClinicalStatsProvider;
			}
		}
		
		#endregion
		
		#region PackageProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Package"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PackageProviderBase PackageProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PackageProvider;
			}
		}
		
		#endregion
		
		#region PackageDetailProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="PackageDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static PackageDetailProviderBase PackageDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.PackageDetailProvider;
			}
		}
		
		#endregion
		
		#region RouteProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Route"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RouteProviderBase RouteProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RouteProvider;
			}
		}
		
		#endregion
		
		#region UserRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="UserRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UserRolesProviderBase UserRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UserRolesProvider;
			}
		}
		
		#endregion
		
		#region UsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Users"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static UsersProviderBase UsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.UsersProvider;
			}
		}
		
		#endregion
		
		#region MedReportProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MedReport"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MedReportProviderBase MedReportProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MedReportProvider;
			}
		}
		
		#endregion
		
		#region FrequencyProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Frequency"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FrequencyProviderBase FrequencyProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FrequencyProvider;
			}
		}
		
		#endregion
		
		#region FavoritMasterProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="FavoritMaster"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FavoritMasterProviderBase FavoritMasterProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FavoritMasterProvider;
			}
		}
		
		#endregion
		
		#region DiaglistProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Diaglist"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DiaglistProviderBase DiaglistProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DiaglistProvider;
			}
		}
		
		#endregion
		
		#region DoctorRequestProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DoctorRequest"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DoctorRequestProviderBase DoctorRequestProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DoctorRequestProvider;
			}
		}
		
		#endregion
		
		#region EPrescriptionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EPrescription"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EPrescriptionProviderBase EPrescriptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EPrescriptionProvider;
			}
		}
		
		#endregion
		
		#region EPrescriptionDetailProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EPrescriptionDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EPrescriptionDetailProviderBase EPrescriptionDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EPrescriptionDetailProvider;
			}
		}
		
		#endregion
		
		#region FavoritDetailProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="FavoritDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FavoritDetailProviderBase FavoritDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FavoritDetailProvider;
			}
		}
		
		#endregion
		
		#region VitalSignProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VitalSign"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VitalSignProviderBase VitalSignProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VitalSignProvider;
			}
		}
		
		#endregion
		
		
		#region VrDoctorDoneProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrDoctorDone"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrDoctorDoneProviderBase VrDoctorDoneProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrDoctorDoneProvider;
			}
		}
		
		#endregion
		
		#region VrDoctorwipProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrDoctorwip"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrDoctorwipProviderBase VrDoctorwipProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrDoctorwipProvider;
			}
		}
		
		#endregion
		
		#region VrEPresDetailProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrEPresDetail"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrEPresDetailProviderBase VrEPresDetailProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrEPresDetailProvider;
			}
		}
		
		#endregion
		
		#region VrLabProcessingProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrLabProcessing"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrLabProcessingProviderBase VrLabProcessingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrLabProcessingProvider;
			}
		}
		
		#endregion
		
		#region VrLabReceiveProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrLabReceive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrLabReceiveProviderBase VrLabReceiveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrLabReceiveProvider;
			}
		}
		
		#endregion
		
		#region VrLabReqProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrLabReq"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrLabReqProviderBase VrLabReqProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrLabReqProvider;
			}
		}
		
		#endregion
		
		#region VrLabResultProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrLabResult"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrLabResultProviderBase VrLabResultProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrLabResultProvider;
			}
		}
		
		#endregion
		
		#region VrLabwipProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrLabwip"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrLabwipProviderBase VrLabwipProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrLabwipProvider;
			}
		}
		
		#endregion
		
		#region VrMedProProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrMedPro"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrMedProProviderBase VrMedProProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrMedProProvider;
			}
		}
		
		#endregion
		
		#region VrNurseProcessedPatientsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrNurseProcessedPatients"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrNurseProcessedPatientsProviderBase VrNurseProcessedPatientsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrNurseProcessedPatientsProvider;
			}
		}
		
		#endregion
		
		#region VrReceptionProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrReception"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrReceptionProviderBase VrReceptionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrReceptionProvider;
			}
		}
		
		#endregion
		
		#region VrReceptionDoneProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrReceptionDone"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrReceptionDoneProviderBase VrReceptionDoneProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrReceptionDoneProvider;
			}
		}
		
		#endregion
		
		#region VrReceptionStartProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrReceptionStart"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrReceptionStartProviderBase VrReceptionStartProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrReceptionStartProvider;
			}
		}
		
		#endregion
		
		#region VrTidChargedCodeProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrTidChargedCode"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrTidChargedCodeProviderBase VrTidChargedCodeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrTidChargedCodeProvider;
			}
		}
		
		#endregion
		
		#region VrUnitTableProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="VrUnitTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static VrUnitTableProviderBase VrUnitTableProvider
		{
			get 
			{
				LoadProviders();
				return _provider.VrUnitTableProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region ClinicalStatsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsFilters : ClinicalStatsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilters class.
		/// </summary>
		public ClinicalStatsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClinicalStatsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClinicalStatsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClinicalStatsFilters
	
	#region ClinicalStatsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ClinicalStatsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ClinicalStats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ClinicalStatsQuery : ClinicalStatsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsQuery class.
		/// </summary>
		public ClinicalStatsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ClinicalStatsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ClinicalStatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ClinicalStatsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ClinicalStatsQuery
		
	#region PackageFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageFilters : PackageFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageFilters class.
		/// </summary>
		public PackageFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageFilters
	
	#region PackageQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PackageParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Package"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageQuery : PackageParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageQuery class.
		/// </summary>
		public PackageQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageQuery
		
	#region PackageDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailFilters : PackageDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilters class.
		/// </summary>
		public PackageDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageDetailFilters
	
	#region PackageDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="PackageDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="PackageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class PackageDetailQuery : PackageDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PackageDetailQuery class.
		/// </summary>
		public PackageDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public PackageDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the PackageDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public PackageDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion PackageDetailQuery
		
	#region RouteFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteFilters : RouteFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteFilters class.
		/// </summary>
		public RouteFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RouteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RouteFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RouteFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RouteFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RouteFilters
	
	#region RouteQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RouteParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Route"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RouteQuery : RouteParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RouteQuery class.
		/// </summary>
		public RouteQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RouteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RouteQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RouteQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RouteQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RouteQuery
		
	#region UserRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="UserRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserRolesFilters : UserRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserRolesFilters class.
		/// </summary>
		public UserRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserRolesFilters
	
	#region UserRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UserRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="UserRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UserRolesQuery : UserRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UserRolesQuery class.
		/// </summary>
		public UserRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UserRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UserRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UserRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UserRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UserRolesQuery
		
	#region UsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersFilters : UsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		public UsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersFilters
	
	#region UsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="UsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Users"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class UsersQuery : UsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		public UsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public UsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the UsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public UsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion UsersQuery
		
	#region MedReportFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportFilters : MedReportFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportFilters class.
		/// </summary>
		public MedReportFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MedReportFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MedReportFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MedReportFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MedReportFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MedReportFilters
	
	#region MedReportQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MedReportParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MedReport"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MedReportQuery : MedReportParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MedReportQuery class.
		/// </summary>
		public MedReportQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MedReportQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MedReportQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MedReportQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MedReportQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MedReportQuery
		
	#region FrequencyFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyFilters : FrequencyFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyFilters class.
		/// </summary>
		public FrequencyFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FrequencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FrequencyFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FrequencyFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FrequencyFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FrequencyFilters
	
	#region FrequencyQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FrequencyParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Frequency"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FrequencyQuery : FrequencyParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FrequencyQuery class.
		/// </summary>
		public FrequencyQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FrequencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FrequencyQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FrequencyQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FrequencyQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FrequencyQuery
		
	#region FavoritMasterFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterFilters : FavoritMasterFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilters class.
		/// </summary>
		public FavoritMasterFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritMasterFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritMasterFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritMasterFilters
	
	#region FavoritMasterQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FavoritMasterParameterBuilder"/> class
	/// that is used exclusively with a <see cref="FavoritMaster"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritMasterQuery : FavoritMasterParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritMasterQuery class.
		/// </summary>
		public FavoritMasterQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritMasterQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritMasterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritMasterQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritMasterQuery
		
	#region DiaglistFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistFilters : DiaglistFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistFilters class.
		/// </summary>
		public DiaglistFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiaglistFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiaglistFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiaglistFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiaglistFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiaglistFilters
	
	#region DiaglistQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DiaglistParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Diaglist"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DiaglistQuery : DiaglistParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiaglistQuery class.
		/// </summary>
		public DiaglistQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DiaglistQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DiaglistQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DiaglistQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DiaglistQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DiaglistQuery
		
	#region DoctorRequestFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestFilters : DoctorRequestFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilters class.
		/// </summary>
		public DoctorRequestFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DoctorRequestFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DoctorRequestFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DoctorRequestFilters
	
	#region DoctorRequestQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DoctorRequestParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DoctorRequest"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DoctorRequestQuery : DoctorRequestParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DoctorRequestQuery class.
		/// </summary>
		public DoctorRequestQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DoctorRequestQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DoctorRequestQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DoctorRequestQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DoctorRequestQuery
		
	#region EPrescriptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionFilters : EPrescriptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilters class.
		/// </summary>
		public EPrescriptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionFilters
	
	#region EPrescriptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EPrescriptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EPrescription"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionQuery : EPrescriptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionQuery class.
		/// </summary>
		public EPrescriptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionQuery
		
	#region EPrescriptionDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailFilters : EPrescriptionDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilters class.
		/// </summary>
		public EPrescriptionDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionDetailFilters
	
	#region EPrescriptionDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EPrescriptionDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EPrescriptionDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EPrescriptionDetailQuery : EPrescriptionDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailQuery class.
		/// </summary>
		public EPrescriptionDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EPrescriptionDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EPrescriptionDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EPrescriptionDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EPrescriptionDetailQuery
		
	#region FavoritDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailFilters : FavoritDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilters class.
		/// </summary>
		public FavoritDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritDetailFilters
	
	#region FavoritDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FavoritDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="FavoritDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FavoritDetailQuery : FavoritDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FavoritDetailQuery class.
		/// </summary>
		public FavoritDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FavoritDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FavoritDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FavoritDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FavoritDetailQuery
		
	#region VitalSignFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignFilters : VitalSignFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignFilters class.
		/// </summary>
		public VitalSignFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VitalSignFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VitalSignFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VitalSignFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VitalSignFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VitalSignFilters
	
	#region VitalSignQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VitalSignParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VitalSign"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VitalSignQuery : VitalSignParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VitalSignQuery class.
		/// </summary>
		public VitalSignQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VitalSignQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VitalSignQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VitalSignQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VitalSignQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VitalSignQuery
		
	#region VrDoctorDoneFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneFilters : VrDoctorDoneFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilters class.
		/// </summary>
		public VrDoctorDoneFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorDoneFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorDoneFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorDoneFilters
	
	#region VrDoctorDoneQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrDoctorDoneParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrDoctorDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorDoneQuery : VrDoctorDoneParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneQuery class.
		/// </summary>
		public VrDoctorDoneQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorDoneQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorDoneQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorDoneQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorDoneQuery
		
	#region VrDoctorwipFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrDoctorwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorwipFilters : VrDoctorwipFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipFilters class.
		/// </summary>
		public VrDoctorwipFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorwipFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorwipFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorwipFilters
	
	#region VrDoctorwipQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrDoctorwipParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrDoctorwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrDoctorwipQuery : VrDoctorwipParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipQuery class.
		/// </summary>
		public VrDoctorwipQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrDoctorwipQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrDoctorwipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrDoctorwipQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrDoctorwipQuery
		
	#region VrEPresDetailFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailFilters : VrEPresDetailFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilters class.
		/// </summary>
		public VrEPresDetailFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrEPresDetailFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrEPresDetailFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrEPresDetailFilters
	
	#region VrEPresDetailQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrEPresDetailParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrEPresDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrEPresDetailQuery : VrEPresDetailParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailQuery class.
		/// </summary>
		public VrEPresDetailQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrEPresDetailQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrEPresDetailQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrEPresDetailQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrEPresDetailQuery
		
	#region VrLabProcessingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabProcessing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabProcessingFilters : VrLabProcessingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingFilters class.
		/// </summary>
		public VrLabProcessingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabProcessingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabProcessingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabProcessingFilters
	
	#region VrLabProcessingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrLabProcessingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrLabProcessing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabProcessingQuery : VrLabProcessingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingQuery class.
		/// </summary>
		public VrLabProcessingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabProcessingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabProcessingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabProcessingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabProcessingQuery
		
	#region VrLabReceiveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReceive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReceiveFilters : VrLabReceiveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveFilters class.
		/// </summary>
		public VrLabReceiveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabReceiveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabReceiveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabReceiveFilters
	
	#region VrLabReceiveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrLabReceiveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrLabReceive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReceiveQuery : VrLabReceiveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveQuery class.
		/// </summary>
		public VrLabReceiveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabReceiveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabReceiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabReceiveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabReceiveQuery
		
	#region VrLabReqFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabReq"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReqFilters : VrLabReqFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReqFilters class.
		/// </summary>
		public VrLabReqFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabReqFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabReqFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabReqFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabReqFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabReqFilters
	
	#region VrLabReqQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrLabReqParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrLabReq"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabReqQuery : VrLabReqParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabReqQuery class.
		/// </summary>
		public VrLabReqQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabReqQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabReqQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabReqQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabReqQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabReqQuery
		
	#region VrLabResultFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultFilters : VrLabResultFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilters class.
		/// </summary>
		public VrLabResultFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabResultFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabResultFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabResultFilters
	
	#region VrLabResultQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrLabResultParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrLabResult"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabResultQuery : VrLabResultParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabResultQuery class.
		/// </summary>
		public VrLabResultQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabResultQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabResultQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabResultQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabResultQuery
		
	#region VrLabwipFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrLabwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabwipFilters : VrLabwipFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabwipFilters class.
		/// </summary>
		public VrLabwipFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabwipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabwipFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabwipFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabwipFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabwipFilters
	
	#region VrLabwipQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrLabwipParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrLabwip"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrLabwipQuery : VrLabwipParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrLabwipQuery class.
		/// </summary>
		public VrLabwipQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrLabwipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrLabwipQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrLabwipQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrLabwipQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrLabwipQuery
		
	#region VrMedProFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProFilters : VrMedProFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProFilters class.
		/// </summary>
		public VrMedProFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrMedProFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrMedProFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrMedProFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrMedProFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrMedProFilters
	
	#region VrMedProQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrMedProParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrMedPro"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrMedProQuery : VrMedProParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrMedProQuery class.
		/// </summary>
		public VrMedProQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrMedProQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrMedProQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrMedProQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrMedProQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrMedProQuery
		
	#region VrNurseProcessedPatientsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsFilters : VrNurseProcessedPatientsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilters class.
		/// </summary>
		public VrNurseProcessedPatientsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrNurseProcessedPatientsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrNurseProcessedPatientsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrNurseProcessedPatientsFilters
	
	#region VrNurseProcessedPatientsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrNurseProcessedPatientsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrNurseProcessedPatients"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrNurseProcessedPatientsQuery : VrNurseProcessedPatientsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsQuery class.
		/// </summary>
		public VrNurseProcessedPatientsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrNurseProcessedPatientsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrNurseProcessedPatientsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrNurseProcessedPatientsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrNurseProcessedPatientsQuery
		
	#region VrReceptionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionFilters : VrReceptionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilters class.
		/// </summary>
		public VrReceptionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionFilters
	
	#region VrReceptionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrReceptionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrReception"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionQuery : VrReceptionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionQuery class.
		/// </summary>
		public VrReceptionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionQuery
		
	#region VrReceptionDoneFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneFilters : VrReceptionDoneFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilters class.
		/// </summary>
		public VrReceptionDoneFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionDoneFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionDoneFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionDoneFilters
	
	#region VrReceptionDoneQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrReceptionDoneParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrReceptionDone"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionDoneQuery : VrReceptionDoneParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneQuery class.
		/// </summary>
		public VrReceptionDoneQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionDoneQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionDoneQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionDoneQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionDoneQuery
		
	#region VrReceptionStartFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartFilters : VrReceptionStartFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilters class.
		/// </summary>
		public VrReceptionStartFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionStartFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionStartFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionStartFilters
	
	#region VrReceptionStartQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrReceptionStartParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrReceptionStart"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrReceptionStartQuery : VrReceptionStartParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartQuery class.
		/// </summary>
		public VrReceptionStartQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrReceptionStartQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrReceptionStartQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrReceptionStartQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrReceptionStartQuery
		
	#region VrTidChargedCodeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeFilters : VrTidChargedCodeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilters class.
		/// </summary>
		public VrTidChargedCodeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrTidChargedCodeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrTidChargedCodeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrTidChargedCodeFilters
	
	#region VrTidChargedCodeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrTidChargedCodeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrTidChargedCode"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrTidChargedCodeQuery : VrTidChargedCodeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeQuery class.
		/// </summary>
		public VrTidChargedCodeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrTidChargedCodeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrTidChargedCodeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrTidChargedCodeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrTidChargedCodeQuery
		
	#region VrUnitTableFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableFilters : VrUnitTableFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilters class.
		/// </summary>
		public VrUnitTableFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrUnitTableFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrUnitTableFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrUnitTableFilters
	
	#region VrUnitTableQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="VrUnitTableParameterBuilder"/> class
	/// that is used exclusively with a <see cref="VrUnitTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class VrUnitTableQuery : VrUnitTableParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the VrUnitTableQuery class.
		/// </summary>
		public VrUnitTableQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public VrUnitTableQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the VrUnitTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public VrUnitTableQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion VrUnitTableQuery
	#endregion

	
}
