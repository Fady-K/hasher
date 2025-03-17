using System;
using Konscious.Security.Cryptography;

namespace Hasher.Core.HashingService.HashingStrategies
{
	public class Argon2HashingStrategy : IHashingStrategy
	{
		///////////////////////////////////////////////////////////// Properties //////////////////////////////////////////////////////////////////////////
		private int DegreeOfParallelism { get; set; }
		private int MemorySize { get; set; }
		private int Iterations { get; set; }
		private int HashSize { get; set; }

		///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
		public Argon2HashingStrategy(int degreeOfParallelism = 4, int memorySize = 16384, int iterations = 2, int hashSize = 32)
		{
			// Use Setters to perform validation.
			DegreeOfParallelism = degreeOfParallelism;
			MemorySize = memorySize;
			Iterations = iterations;
			HashSize = hashSize;
		}

		///////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			try
			{
				using (var argon2 = new Argon2id(data))
				{
					argon2.DegreeOfParallelism = DegreeOfParallelism;
					argon2.MemorySize = MemorySize;
					argon2.Iterations = Iterations;

					// Generate a hash
					byte[] hash = argon2.GetBytes(HashSize);

					// Return the hash and the used algorithm.
					return new HashResult(hash, HashingAlgorithm.Argon2);
				}
			}
			catch (Exception ex)
			{
				// Rethrow using its own exception, including the original exception message and stack trace
				throw new HashingServiceException("An error occurred while hashing data using Argon2.", ex);
			}
		}
	}
}