using Finder.Helpers;
using Finder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Finder.DAO
{
	public static class UserDAO
	{
		public static void Save(User model)
		{
			if (model.Id == 0)
			{
				Context.Instance.Users.Add(model);
			}
			else
			{
				Context.Instance.Entry(model).State = EntityState.Modified;
				model.UpdateDate();
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

		/// <summary>
		/// Obtém uma lista de usuários disponíveis para dar "Match"
		/// </summary>
		/// <param name="user">O usuário que vai "receber" esta lista</param>
		/// <returns>A lista de usuário com preferenciais compatíveis</returns>
		public static List<User> GetUsersAvaliableToMatch(User user)
		{
			if (user.Preferences.Count() < 1)
			{
				throw new Exception("Você precisa definir suas preferencias para obter recomendações de pessoas.");
			}

			var usersIdsToExclude = new List<int>(user.UsersMatched.Select(x => x.Id));
			usersIdsToExclude.Add(user.Id);

			var preferencesValues = new SqlParameter("@preferencesValues", 
				string.Join(", ", user.Preferences.Select(x => x.Id.ToString())));
			var excludeUserIds = new SqlParameter("@excludeUserIds", 
				string.Join(", ", usersIdsToExclude.Select(x => x.ToString())));

			return Context.Instance.Database.SqlQuery<User>(
				"SELECT [Users].[Id], [Users].[Name], [Users].[Email], [Users].[Password], [Users].[CreatedAt], [Users].[UpdatedAt] " +
				"FROM [dbo].[Users] AS [Users] INNER JOIN [dbo].[UserPreferenceValues] AS [Preferences] " +
				"ON [Users].[Id] = [Preferences].[User_id] AND [Preferences].[PreferenceValue_Id] IN (@preferencesValues) " +
				"AND [Preferences].[User_id] NOT IN (@excludeUserIds) " +
				"GROUP BY [Users].[Id], [Users].[Name], [Users].[Email], [Users].[Password], [Users].[CreatedAt], [Users].[UpdatedAt] " +
				"ORDER BY COUNT([Preferences].[PreferenceValue_Id]) DESC",
				preferencesValues, excludeUserIds).ToList();
		}

		public static void SaveMatch(User currentUser, User usertToMatch)
		{
			if (currentUser.UsersMatched.Contains(usertToMatch))
			{
				return;
			}

			currentUser.UsersMatched.Add(usertToMatch);
			Save(currentUser);
		}
	}
}
