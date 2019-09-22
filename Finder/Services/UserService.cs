﻿using Finder.DAO;
using Finder.Helpers;
using Finder.Models;
using System;
using System.Data.Entity.Infrastructure;

namespace Finder.Services
{
    public static class UserService
    {
        private static User loggedUser;

		private static UserDAO _userDAO;

		private static UserDAO UserDAO
		{
			get
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
            string password, string pass)
        {
            Validator.CheckIsEmpty(name, "Nome");
            Validator.CheckIsValidEMail(email, "Email");
            Validator.CheckIsEmpty(password, "Senha");
			Validator.CheckIsEmpty(pass, "Confirmar Senha");
            Validator.CheckEqualsPassword(password, pass);

			try
			{
				var user = new User
				{
					Name = name,
					Email = email,
					Password = password
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
    }
}
