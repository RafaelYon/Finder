using Finder.DAO;
using Finder.Helpers;
using Finder.Models;
using System;
using System.Data.Entity.Infrastructure;

namespace Finder.Services
{
    public static class UserService
    {
        private static User loggedUser; // Atribuido quando o login e bem sucedido

        private static UserDAO _userDAO;

        private static UserDAO UserDAO
        {
            get // Verifica se ja foi instanciado
            {
                if (_userDAO == null)
                    _userDAO = new UserDAO();

                return _userDAO;
            }
        }

        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <exception cref="ArgumentException">Quando o e-mail ou a senha são inválidos</exception>
        /// <exception cref="Exception">Quando as credencais são inválidas</exception>
        public static void Login(string email, string password)
        {
            Validator.CheckIsValidEMail(email, "Email");
            Validator.CheckIsEmpty(password, "Senha");

            var user = UserDAO.FindByEmail(email);

            if (!user.Password.Equals(password))
            {
                throw new Exception("Credenciais inválidas.");
            }

            loggedUser = user;
        }

        public static void UpdateUser(string email, string password, string pass, string oldPassword)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                Validator.CheckIsValidEMail(email, "Email");
                Validator.CheckEqualsOlderPassword(loggedUser.Password, oldPassword);
                UserDAO.FindNewEmail(email);
                loggedUser.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                Validator.CheckEqualsPassword(password, pass);
                loggedUser.Password = password;
            }

            UserDAO.Save(loggedUser);
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

        public static void Loggout()
        {
            loggedUser = null;
        }

        /// <summary>
        /// Registra um novo usuário, este método já "loga" o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="password">Senha do usuário</param>
        /// <exception cref="ArgumentException">Quando o e-mail ou a senha são inválidos</exception>
        /// <exception cref="Exception">Quando não foi possível inserir o novo registro</exception>
        public static void Register(string name, string email,
            string password, string pass, DateTime? born, Genre genre)
        {
            Validator.CheckIsEmpty(name, "Nome");
            Validator.CheckIsValidEMail(email, "Email");
            Validator.CheckIsEmpty(password, "Senha");
            Validator.CheckIsEmpty(pass, "Confirmar Senha");
            Validator.CheckEqualsPassword(password, pass);
            Validator.CheckIsNull(born, "Data Nasc");

            try
            {
                var user = new User
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    Born = born ?? DateTime.Now,
                    Genre = genre
                };

                UserDAO.Save(user);
                loggedUser = user;
            }
            catch (DbUpdateException ex)
            {
                throw DbExceptionsHandler.Handler(ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um problama ao salvar suas informações, por favor contate os desenvolvedores", ex);
            }
        }

        public static void RegisterPreferences(String cor, String filme, String musica, String animal, String personalidade)
        {
            Validator.CheckIsEmpty(cor, "Cor");
            Validator.CheckIsEmpty(filme, "Filme");
            Validator.CheckIsEmpty(musica, "Música");
            Validator.CheckIsEmpty(animal, "Animal");
            Validator.CheckIsEmpty(personalidade, "Personalidade");

        }
    }
}
