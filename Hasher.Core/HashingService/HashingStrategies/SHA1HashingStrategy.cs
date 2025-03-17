using System;
using System.Security.Cryptography;

namespace Hasher.Core.HashingService.HashingStrategies
{
	public class SHA1HashingStrategy: IHashingStrategy
	{
        ///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
        public SHA1HashingStrategy()
        {
            
        }


		///////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			try
			{
				using (var sha1 = SHA1.Create())
				{
					// Generate the SHA-1 hash
					byte[] hash = sha1.ComputeHash(data);

					// Return the hash and the used algorithm.
					return new HashResult(hash, HashingAlgorithm.SHA1);
				}
			}
			catch(Exception ex)
			{
				// Rethrow using its own exception, including the original exception message and stack trace
				throw new HashingServiceException("An error occurred while hashing data using SHA-1.", ex);
			}
		}
	}
}
