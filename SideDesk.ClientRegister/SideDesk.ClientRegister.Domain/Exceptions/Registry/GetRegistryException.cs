using System.Runtime.Serialization;

namespace SideDesk.ClientRegister.Infrastructure.Exceptions.Registry
{
	public class GetRegistryException : Exception
	{
		public GetRegistryException()
		{
		}

		public GetRegistryException(string? message) : base(message)
		{
		}

		public GetRegistryException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected GetRegistryException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
