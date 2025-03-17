using System;
using System.Security.Cryptography;

namespace Hasher.Core.HashingService.HashingStrategies
{
	public class MD5HashingStrategy : IHashingStrategy
	{
		///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
		public MD5HashingStrategy()
		{
		}

		///////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			try
			{
				using (var md5 = MD5.Create())
				{
					// Generate the MD5 hash
					byte[] hash = md5.ComputeHash(data);

					// Return the hash and the used algorithm.
					return new HashResult(hash, HashingAlgorithm.MD5);
				}
			}
			catch (Exception ex)
			{
				// Rethrow using its own exception, including the original exception message and stack trace
				throw new HashingServiceException("An error occurred while hashing data using MD5.", ex);
			}
		}
	}
}
