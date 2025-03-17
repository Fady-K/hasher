using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Core.ConfigurationSettingService.ConfigurationSettingStrategies
{
	public abstract class AbstractConfigurationSettingStrategy
	{
		/* Instance Attributes */
		protected string __configurationKey;
		protected string __configurationValue;



		/* Constructors */
		public AbstractConfigurationSettingStrategy()
		{
			// Init instance attributes 
			__configurationKey = string.Empty;
			__configurationValue = string.Empty;
		}


		/* Setters and getters (properties) */
		public string ConfigurationKey => __configurationKey;
		public string ConfigurationValue => __configurationValue;


		/* Instance Methods */
		public abstract void SetConfigurationValue(string key, string newValue);
	}
}
