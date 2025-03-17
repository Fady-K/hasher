using Hasher.Core.ConfigurationLoadingService.ConfigurationLoadingStrategies;
using System;
using System.Configuration;
using System.IO;

namespace Hasher.Core.ConfigurationLoader.ConfigurationLoadingStrategies
{
	public class LoadConfigurationFromXMLAppConfig : AbstractConfigurationLoadingStrategy
	{
		protected string _fullConfigFilePath;

		/* Constructors */
		public LoadConfigurationFromXMLAppConfig(string configurationFilePath="")
		{

			// Combine xml config file path and path it to the loading method.
			_fullConfigFilePath = Path.GetFullPath(Environment.ExpandEnvironmentVariables(configurationFilePath));
		}


		/* Method to Load Log File Path from Config File */

	
		protected System.Configuration.Configuration GetConfiguration(string configFilePath)
		{
			// Create a configuration file map
			var configFileMap = new ExeConfigurationFileMap
			{
				ExeConfigFilename = configFilePath
			};

			// Load the configuration from the specified file
			return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
		}

		public override string LoadConfiguration(string key)
		{
			// Update the key
			__configurationKey = key;

			// Retrieve the log file path from appSettings
			string value = GetConfiguration(_fullConfigFilePath).AppSettings.Settings[key]?.Value;

			// Resolve any Environment variables in the path.
			__configurationValue = Environment.ExpandEnvironmentVariables(value);

			// return the value
			return __configurationValue;
		}
	}
}
