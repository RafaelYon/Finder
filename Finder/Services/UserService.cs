using Finder.DAO;
using Finder.Helpers;
using Finder.Models;
using System;

namespace Finder.Services
{
    public static class UserService
    {
        private static User loggedUser;

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <exception cref="Exception">Quando as credencais são inválidas</exception>
        public static void Login(string email, string password)
        {
			Validator.CheckIsEmpty(email, "Email");
			Validator.CheckIsEmpty(password, "Senha");

            var user = UserDAO.FindByEmail(email);

            if (!user.Password.Equals(password))
            {
                throw new Exception("Credenciais inválidas.");
            }

            loggedUser = user;
        }

        /// <summary>
        /// Obtém o usuário logado
        /// </summary>
        /// <returns>O usuário loogado</returns>
        /// <exception cref="Exception">Quando o usuário não se logou</exception>
        public static User GetLoggedUser()
        {
            if (loggedUser == null)
            {
                throw new Exception("Não há usuários logados");
            }

            return loggedUser;
        }

        public static void Register(string name, string email, 
            string password)
        {
            Validator.CheckIsEmpty(name, "Nome");
            Validator.CheckIsValidEMail(email, "Email");
            Validator.CheckIsEmpty(password, "Senha");

			UserDAO.Save(new User
			{
				Name = name,
				Email = email,
				Password = password
			});
        }
    }
}
