namespace Hasher.Core.ConfigurationLoadingService.ConfigurationLoadingStrategies
{

	public abstract class AbstractConfigurationLoadingStrategy
	{
		/* Instance Attributes */
		protected string __configurationKey;
		protected string __configurationValue;



		/* Constructors */
		public AbstractConfigurationLoadingStrategy()
		{
			// Init instance attributes 
			__configurationKey = string.Empty;
			__configurationValue = string.Empty;
		}


		/* Setters and getters (properties) */
		public string ConfigurationKey => __configurationKey;
		public string ConfigurationValue => __configurationValue;


		/* Instance Methods */
		public abstract string LoadConfiguration(string key);
		
	}
}
