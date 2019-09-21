using FExceptions = Finder.Exceptions;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Finder.Helpers
{
	public static class DbExceptionsHandler
	{
		public static FExceptions.SqlException Handler(DbUpdateException originalException)
		{
			Exception exception = originalException.InnerException;
			FExceptions.SqlException result = null;

			while (exception != null)
			{
				if (exception.GetType().Equals(typeof(SqlException)))
				{
					if (exception.Message.Contains("duplicate key"))
					{
						result = FExceptions.DuplicateKeyException.Create(exception);
					}

					break;
				}

				exception = exception.InnerException;
			}

			if (result == null)
			{
				result = new FExceptions.SqlException(originalException,
					"Houve um problema durante a comunicação com banco de dados, , por favor contate os desenvolvedores");
			}

			return result;
		}
	}
}
