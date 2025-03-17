using System;
using System.Security.Cryptography;

namespace Hasher.Core.HashingService.HashingStrategies
{
	public class SHA256HashingStrategy : IHashingStrategy
	{
		///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
		public SHA256HashingStrategy()
		{
		}

		///////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			try
			{
				using (var sha256 = SHA256.Create())
				{
					// Generate the SHA-256 hash
					byte[] hash = sha256.ComputeHash(data);

					// Return the hash and the used algorithm.
					return new HashResult(hash, HashingAlgorithm.SHA256);
				}
			}
			catch (Exception ex)
			{
				// Rethrow using its own exception, including the original exception message and stack trace
				throw new HashingServiceException("An error occurred while hashing data using SHA-256.", ex);
			}
		}
	}
}
