using System;
using System.Configuration;
using System.IO;

namespace Hasher.Core.ConfigurationSettingService.ConfigurationSettingStrategies
{
	public class SetConfigurationValueInXMLConfigFile : AbstractConfigurationSettingStrategy
	{
		protected string _fullConfigFilePath;

		/* Constructors */
		public SetConfigurationValueInXMLConfigFile(string configurationFilePath = "")
		{
			// Combine XML config file path and path it to the loading method.
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

		public override void SetConfigurationValue(string key, string newValue)
		{
			try
			{
				// Get the configuration file
				var config = GetConfiguration(_fullConfigFilePath);

				// Check if the key exists in the appSettings section
				if (config.AppSettings.Settings[key] != null)
				{
					// Update the key with the new value
					config.AppSettings.Settings[key].Value = newValue;
				}
				else
				{
					// Add the key with the new value if it does not exist
					config.AppSettings.Settings.Add(key, newValue);
				}

				// Save the configuration file
				config.Save(ConfigurationSaveMode.Modified);

				// Refresh the appSettings section so that the new value is applied immediately
				ConfigurationManager.RefreshSection("appSettings");
			}
			catch (Exception ex)
			{
				// Handle and log the exception as necessary
				// For now, return the error message
				throw new Exception($"Error setting '{key}' in the configuration file: {ex.Message}");
			}
		}
	}
}
