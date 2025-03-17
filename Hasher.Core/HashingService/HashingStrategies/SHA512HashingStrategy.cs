using System;
using System.Security.Cryptography;

namespace Hasher.Core.HashingService.HashingStrategies
{
	public class SHA512HashingStrategy : IHashingStrategy
	{
		///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
		public SHA512HashingStrategy()
		{
		}

		///////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			try
			{
				using (var sha512 = SHA512.Create())
				{
					// Generate the SHA-512 hash
					byte[] hash = sha512.ComputeHash(data);

					// Return the hash and the used algorithm.
					return new HashResult(hash, HashingAlgorithm.SHA512);
				}
			}
			catch (Exception ex)
			{
				// Rethrow using its own exception, including the original exception message and stack trace
				throw new HashingServiceException("An error occurred while hashing data using SHA-512.", ex);
			}
		}
	}
}
