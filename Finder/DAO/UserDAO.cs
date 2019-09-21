using Finder.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Finder.DAO
{
	public static class UserDAO
	{
		public static void Save(User model)
		{
            model.UpdateDate();

			if (model.Id == 0)
			{
				Context.Instance.Users.Add(model);
			}
			else
			{
				Context.Instance.Entry(model).State = EntityState.Modified;
			}

			Context.Instance.SaveChanges();
		}

		/// <summary>
		/// Busca um Usuário pelo seu e-mail.
		/// </summary>
		/// <param name="email">O e-mail associado a ele</param>
		/// <returns>O usuário encontrado</returns>
		/// <exception cref="Exception">
		/// Quando nenhum usuário com e-mail especificado é encontrado.
		/// </exception>
		public static User FindByEmail(string email)
		{
			var result = Context.Instance.Users.FirstOrDefault(x => x.Email.Equals(email));

			if (result == null)
			{
				throw new Exception("Credenciais inválidas.");
			}

			return result;
		}
	}
}
