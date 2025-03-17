namespace Hasher.Core.HashingService.HashingStrategies
{
	public interface IHashingStrategy
	{
		HashResult Hash(byte[] data);
	}
}