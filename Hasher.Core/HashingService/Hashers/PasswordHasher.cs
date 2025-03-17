using System;
using System.Text;
using Hasher.Core.HashingService.HashingStrategies;

namespace Hasher.Core.HashingService.Hashers
{
	public class PasswordHasher : AbstractHasher
	{
		/////////////////////////////////////////////////////////// Fields //////////////////////////////////////////////////////////////////////////
		protected Encoding _encoding;

		/////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
		public PasswordHasher()
		{
			// Use Argon2 as the hashing algorithm for hashing passwords.
			base.HashingStrategy = HashingStrategyFactory.CreateHashingStrategy(HashingAlgorithm.Argon2);

			// Init encoding.
			_encoding = Encoding.UTF8;
		}

		public PasswordHasher(IHashingStrategy hashingStrategy) : base(hashingStrategy)
		{
			_encoding = Encoding.UTF8;
		}

		public PasswordHasher(HashingAlgorithm hashingAlgorithm) : base(hashingAlgorithm)
		{
			_encoding = Encoding.UTF8;
		}

		/////////////////////////////////////////////////////////// Properties //////////////////////////////////////////////////////////////////////////
		public Encoding Encoding
		{
			get => _encoding;
			set => _encoding = value ?? throw new ArgumentNullException(nameof(value), "Encoding cannot be null.");
		}

		/////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public string Hash(string passwordToHash)
		{
			if (string.IsNullOrEmpty(passwordToHash))
			{
				throw new ArgumentException("Password cannot be null or empty.", nameof(passwordToHash));
			}

			try
			{
				var hashBytes = base.Hash(_encoding.GetBytes(passwordToHash)).Hash;
				return BitConverter.ToString(hashBytes).Replace("-", "");
			}
			catch (Exception ex)
			{
				// Log the exception here if a logging service is available.
				throw new HashingServiceException("An error occurred while hashing the password using PasswordHasher.", ex);
			}
		}
	}
}