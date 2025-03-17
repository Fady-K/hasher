using Hasher.Core.HashingService.HashingStrategies;

namespace Hasher.Core.HashingService.Hashers
{
	public abstract class AbstractHasher
	{
		/////////////////////////////////////////////////////////// Fields //////////////////////////////////////////////////////////////////////////
		protected IHashingStrategy _hashingStrategy;


        /////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////
        public AbstractHasher()					// Default constructor
        {
			// Init class fields with default values.
			_hashingStrategy = new SHA256HashingStrategy();
        }
        public AbstractHasher(IHashingStrategy hashingStrategy)
        {
			// Init class fields
			_hashingStrategy = hashingStrategy;
        }

		public AbstractHasher(HashingAlgorithm hashingAlgorithm) 
		{
			// Init class fields
			_hashingStrategy = HashingStrategyFactory.CreateHashingStrategy(hashingAlgorithm);
		}


		/////////////////////////////////////////////////////////// Properties //////////////////////////////////////////////////////////////////////////
		public IHashingStrategy HashingStrategy { get => _hashingStrategy; set => _hashingStrategy = value; }


		/////////////////////////////////////////////////////////// Instance Methods //////////////////////////////////////////////////////////////////////////
		public HashResult Hash(byte[] data)
		{
			// Use the hashing strategy to hash the provided data.
			return _hashingStrategy.Hash(data);
		}
	}
}
