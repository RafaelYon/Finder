using System;
using System.Text.RegularExpressions;

namespace Finder.Exceptions
{
	public class DuplicateKeyException : SqlException
	{
		public string Table { get; protected set; }
		public string Index { get; protected set; }
		public string Value { get; protected set; }

		protected DuplicateKeyException(string table, string index, string value, 
			Exception originalException, string message) 
			: base(originalException, message)
		{
			Table = table;
			Index = index;
			Value = value;
		}

		public static DuplicateKeyException Create(Exception originalException)
		{
			string pattern = @"(object \'[A-Za-z0-9.]+\')|(index \'\w+\')|(value is \(.+\))";
			int count = 0;

			string table = string.Empty;
			string index = string.Empty;
			string value = string.Empty;

			foreach (Match match in Regex.Matches(originalException.Message, pattern, RegexOptions.Multiline))
			{
				switch (count)
				{
					case 0:
						table = ClearData(match.Value, "'", 7);
						break;
					case 1:
						index = ClearData(match.Value, "'", 6);
						break;
					case 2:
						value = ClearData(match.Value.Replace(")", ""), "(", 9);
						break;
				}

				count++;
			}

			return new DuplicateKeyException(table, index, value, originalException, 
				$"O valor \"{value}\" já está em uso, por favor utilize outro.");
		}

		protected static string ClearData(string data, string replace, int removeCount)
		{
			data = data.Replace(replace, "");
			data = data.Remove(0, removeCount);

			return data;
		}
	}
}
