using System;

namespace Hasher.Core.HashingService
{
	public class HashingServiceException : Exception
	{
		///////////////////////////////////////////////////////////// Constants //////////////////////////////////////////////////////////////////////////////
		public const string EXCEPTION_SUFFIX = nameof(HashingServiceException) + ": ";


		///////////////////////////////////////////////////////////// Constructors //////////////////////////////////////////////////////////////////////////////
		public HashingServiceException(string message) : base(AddExceptionSuffix(message))
		{

		}

		public HashingServiceException(string message, Exception innerException) : base(AddExceptionSuffix(message), innerException)
		{

		}


		///////////////////////////////////////////////////////////// Helper Methods //////////////////////////////////////////////////////////////////////////////
		private static string AddExceptionSuffix(string message)
		{
			// Add the suffix of the excption class to every exception if doesn't already exist in it.
			if (!message.StartsWith(EXCEPTION_SUFFIX))
			{
				// Add the suffix to the beginning of the message.
				message = EXCEPTION_SUFFIX + message;
			}

			// Return the message.
			return message;
		}
	}
}
