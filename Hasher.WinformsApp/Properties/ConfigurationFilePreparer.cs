using System;
using System.IO;

namespace Hasher.WinformsApp.Properties
{
	public class ConfigurationFilePreparer
	{
		/// <summary>
		/// Prepares the configuration file by checking its existence and creating it if necessary.
		/// </summary>
		/// <param name="configFilePath">The path to the configuration file.</param>
		/// <param name="logAction">The action to log messages (e.g., append to a RichTextBox).</param>
		public static void Prepare(string configFilePath, Action<string> logAction)
		{
			try
			{
				if (File.Exists(configFilePath))
				{
					logAction?.Invoke($"The configuration file already exists at: {configFilePath}");
				}
				else
				{
					// Ensure the directory exists
					string directoryPath = Path.GetDirectoryName(configFilePath);
					if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
						logAction?.Invoke($"Created directory: {directoryPath}");
					}

					// Create the configuration file as an XML file with default values
					using (var writer = new StreamWriter(configFilePath))
					{
						writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
						writer.WriteLine("<configuration>");
						writer.WriteLine("\t<appSettings>");
						writer.WriteLine("\t\t<add key=\"last_used_hashing_algorithm\" value=\"\" />");
						writer.WriteLine("\t\t<add key=\"last_selected_file\" value=\"\" />");
						writer.WriteLine("\t\t<add key=\"is_first_time\" value=\"true\" />");
						writer.WriteLine("\t</appSettings>");
						writer.WriteLine("</configuration>");
					}

					logAction?.Invoke($"A new configuration file has been created with default values at: {configFilePath}");
				}
			}
			catch (Exception ex)
			{
				logAction?.Invoke($"An error occurred while preparing the configuration file: {ex.Message}");
			}
		}
	}
}