using System;
using System.Text.RegularExpressions;

namespace Finder.Helpers
{
    public static class Validator
    {
        private static void ThrowFieldExcetion(string field, string message)
        {
            throw new ArgumentException($"O campo \"{field}\" {message}.");
        }

        public static void CheckIsEmpty(string data, string field)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                ThrowFieldExcetion(field, "não pode estar vazio");
            }
        }

        public static void CheckIsNull(object data, string field)
        {
            if (data == null)
            {
                ThrowFieldExcetion(field, "deve ser definido");
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
        
        public static void CheckEqualsPassword(string password, string confirm)
        {
            if (!password.Equals(confirm))
                throw new Exception("Senhas incompatíveis");
        }
        public static void CheckEqualsOlderPassword(string password, string confirm)
        {
            if (!password.Equals(confirm))
                throw new Exception("Senhas antiga está incorreta");
        }
    }
}
