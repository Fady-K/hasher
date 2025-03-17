using System;
using System.IO;
using Hasher.Core.ConfigurationLoader.ConfigurationLoadingStrategies;
using Hasher.Core.ConfigurationLoadingService.ConfigurationLoadingStrategies;
using Hasher.Core.ConfigurationSettingService.ConfigurationSettingStrategies;

namespace Hasher.WinformsApp.Properties
{
	/// <summary>
	///  This is implements the singlton design pattern.
	/// </summary>
	public class Configurations
	{
		////////////////////////////////////////////////////////// Fields ////////////////////////////////////////////////////////////////
		// Static fields
		protected static Configurations _instance;         // Signlton

		// Instance fields
		protected string _configFilePath;
		private AbstractConfigurationLoadingStrategy _configLoadStrategy;
		private AbstractConfigurationSettingStrategy _configValueSettingStrategy;
		private Action<string> _logOrMessageAction;

		////////////////////////////////////////////////////////// Constructors ////////////////////////////////////////////////////////////////
		public Configurations(Action<string> logOrMessageAction)
		{
			// Init config file path.
			_configFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Hasher", "Hasher.Config");

			// Set the delegate
			_logOrMessageAction = logOrMessageAction;

			// prepare this config file path
			ConfigurationFilePreparer.Prepare(_configFilePath, _logOrMessageAction);

			// Init config loading strategy.
			_configLoadStrategy = new LoadConfigurationFromXMLAppConfig(_configFilePath);

			// Init config value setting strategy.
			_configValueSettingStrategy = new SetConfigurationValueInXMLConfigFile(_configFilePath);
		}

		////////////////////////////////////////////////////////// Properties ////////////////////////////////////////////////////////////////
		public string ConfigFilePath { get => _configFilePath; set { _configFilePath = value; Init(); } }


		////////////////////////////////////////////////////////// Instance Methods (Settings) ////////////////////////////////////////////////////////////////
		public bool IsFirstTime 
		{
			get 
			{
				return Convert.ToBoolean(_configLoadStrategy.LoadConfiguration("is_first_time"));
			}
			set
			{
				_configValueSettingStrategy.SetConfigurationValue("is_first_time", value.ToString());
			}
		}
		public string LastSelectedFile 
		{
			get
			{
				return Convert.ToString(_configLoadStrategy.LoadConfiguration("last_selected_file"));
			}
			set 
			{
				_configValueSettingStrategy.SetConfigurationValue("last_selected_file", value.ToString());
			}
		}
		public string LastUsedHashingAlgorithm 
		{
			get
			{
				return Convert.ToString(_configLoadStrategy.LoadConfiguration("last_used_hashing_algorithm"));
			}
			set
			{
				_configValueSettingStrategy.SetConfigurationValue("last_used_hashing_algorithm", value.ToString());
			}
		}

		////////////////////////////////////////////////////////// Helper Methods ////////////////////////////////////////////////////////////////
		protected void Init() 
		{
			// Init config loading strategy.
			_configLoadStrategy = new LoadConfigurationFromXMLAppConfig(_configFilePath);

			// Init config value setting strategy.
			_configValueSettingStrategy = new SetConfigurationValueInXMLConfigFile(_configFilePath);
		}
		protected void InitWithDefaultValues() 
		{
			LastSelectedFile = string.Empty;
			LastUsedHashingAlgorithm = string.Empty;
		}

		////////////////////////////////////////////////////////// Static Methods ////////////////////////////////////////////////////////////////
		public static Configurations GetInstance(Action<string> logOrMessageAction=null)
		{
			if (_instance == null)
			{
				_instance = new Configurations(logOrMessageAction);	
			}

			if (_instance.IsFirstTime)
			{
				_instance.InitWithDefaultValues();
			}

			// Return configuraitons.
			return _instance;
		}
	}
}
