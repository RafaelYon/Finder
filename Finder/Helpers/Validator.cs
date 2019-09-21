using System;
using System.Text.RegularExpressions;

namespace Finder.Helpers
{
    public static class Validator
    {
        private static void ThrowFieldExcetion(string field, string message)
        {
            throw new Exception($"O campo \"{field}\" {message}.");
        }

        public static void CheckIsEmpty(string data, string field)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                ThrowFieldExcetion(field, "não pode estar vazio");
            }
        }

        public static void CheckIsValidEMail(string data, string field)
        {
            CheckIsEmpty(data, field);

            if (!Regex.IsMatch(data, @"^(.+)(\@)((\w+)(\.)(\w+)+)$"))
            {
                ThrowFieldExcetion(field, "não é um e-mail válido");
            }
        }
    }
}
