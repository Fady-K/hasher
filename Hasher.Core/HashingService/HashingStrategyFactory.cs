using Hasher.Core.HashingService.HashingStrategies;

namespace Hasher.Core.HashingService
{
	public class HashingStrategyFactory
	{
		public static IHashingStrategy CreateHashingStrategy(HashingAlgorithm hashingAlgorithm)
		{
			if (hashingAlgorithm.Equals(HashingAlgorithm.Argon2))
			{
				return new Argon2HashingStrategy();
			}
			else if (hashingAlgorithm.Equals(HashingAlgorithm.SHA512))
			{
				return new SHA512HashingStrategy();
			}
			else if (hashingAlgorithm.Equals(HashingAlgorithm.SHA256))
			{
				return new SHA256HashingStrategy();
			}
			else if (hashingAlgorithm.Equals(HashingAlgorithm.SHA1))
			{
				return new SHA1HashingStrategy();
			}
			else if (hashingAlgorithm.Equals(HashingAlgorithm.MD5))
			{
				return new MD5HashingStrategy();
			}
			else
			{
				throw new HashingServiceException("An error occurred while trying to create hashing strategy using HashingStrategyFactory.");
			}
		}
	}
}
