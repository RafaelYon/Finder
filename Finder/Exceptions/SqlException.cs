using System;

namespace Finder.Exceptions
{
	public class SqlException : Exception
	{
		public string ServerMessage { get; protected set; }

		public SqlException(Exception originalException, string message) : base(message, originalException)
		{
			ServerMessage = originalException.Message;
		}
	}
}
