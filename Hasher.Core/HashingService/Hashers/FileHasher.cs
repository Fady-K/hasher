using System;
using System.IO;
using Hasher.Core.HashingService.HashingStrategies;

namespace Hasher.Core.HashingService.Hashers
{
	public class FileHasher: AbstractHasher
	{
        /////////////////////////////////////////////////////////// Fields //////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
        public FileHasher()
        {
			// Use Argon2 as the hashing algorithm for hashing files.
			base.HashingStrategy = HashingStrategyFactory.CreateHashingStrategy(HashingAlgorithm.Argon2);
		}

        public FileHasher(IHashingStrategy hashingStrategy): base(hashingStrategy)
        {
            
        }
        public FileHasher(HashingAlgorithm hashingAlgorithm): base(hashingAlgorithm)
        {
            
        }
        /////////////////////////////////////////////////////////// Instance Methods  //////////////////////////////////////////////////////////////////////////
        public HashResult Hash(string filePath)
        {
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentException("file path cannot be null or empty.", nameof(filePath));
			}

			try
			{
				// Load file bytes
				byte[] fileByes = File.ReadAllBytes(filePath);

				// Hash the file bytes and return it.
				return base.Hash(fileByes);
			}
			catch(IOException ex)
			{
				// Log the exception here if a logging service is available.
				throw new HashingServiceException("An error occurred while hashing the file using FileHasher.", ex);
			}
			catch (Exception ex)
			{
				// Log the exception here if a logging service is available.
				throw new HashingServiceException("An error occurred while hashing the file using FileHasher.", ex);
			}
		}
    }
}
