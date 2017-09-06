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
