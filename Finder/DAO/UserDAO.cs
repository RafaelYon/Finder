using Finder.Models;
using System;
using System.Linq;

namespace Finder.DAO
{
	public class UserDAO : ModelDAO, IDAO<User>
	{
		/// <summary>
		/// Busca um Usuário pelo seu e-mail.
		/// </summary>
		/// <param name="email">O e-mail associado a ele</param>
		/// <returns>O usuário encontrado</returns>
		/// <exception cref="Exception">
		/// Quando nenhum usuário com e-mail especificado é encontrado.
		/// </exception>
		public User FindByEmail(string email)
		{
			var result = Context.Instance.Users.FirstOrDefault(x => x.Email.Equals(email));

			if (result == null)
			{
				throw new Exception("Credenciais inválidas.");
			}

			return result;
		}

        public void FindNewEmail(string email)
        {
            var result = Context.Instance.Users.FirstOrDefault(x => x.Email.Equals(email));

            if (result != null)
            {
                throw new Exception("Esse email já está cadastrado!\n" +
                    "Tente outro email.");
            }
        }

		public void Save(User model)
		{
			SaveModel(model);
		}

		/// <summary>
		/// Salva o match
		/// </summary>
		/// <param name="currentUser">O usuário que deu match</param>
		/// <param name="usertToMatch">O usuário "alvo" do match</param>
		public void SaveMatch(User currentUser, User usertToMatch)
		{
			if (currentUser.UsersMatched.Contains(usertToMatch))
			{
				return;
			}

			currentUser.UsersMatched.Add(Context.Instance.Users.Find(usertToMatch.Id));
			Save(currentUser);
		}

		protected override void IncludeModelInDbSet(Model model)
		{
			Context.Instance.Users.Add(model as User);
		}

		protected override void RemoveModelInDbSet(Model model)
		{
			Context.Instance.Users.Remove(model as User);
		}
	}
}
