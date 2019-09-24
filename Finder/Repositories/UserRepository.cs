using Finder.DAO;
using Finder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Finder.Repositories
{
	public class UserRepository
	{
		protected UserDAO _userDAO;
		protected ChatDAO _chatDAO;

		protected UserDAO UserDAO
		{
			get
			{
				if (_userDAO == null)
					_userDAO = new UserDAO();

				return _userDAO;
			}
		}

		protected ChatDAO ChatDAO
		{
			get
			{
				if (_chatDAO == null)
					_chatDAO = new ChatDAO();

				return _chatDAO;
			}
		}
		
		/// <summary>
		/// Obtém uma lista de usuários disponíveis para dar "Match"
		/// </summary>
		/// <param name="user">O usuário que vai "receber" esta lista</param>
		/// <returns>A lista de usuário com preferenciais compatíveis</returns>
		public List<User> GetUsersAvaliableToMatch(User user)
		{
			if (user.Preferences.Count() < 1)
			{
				throw new Exception("Você precisa definir suas preferências para obter recomendações de pessoas.");
			}

			var usersIdsToExclude = new List<int>(user.UsersMatched.Select(x => x.Id));
			usersIdsToExclude.Add(user.Id);

			var preferencesValues = new SqlParameter("@preferencesValues",
				string.Join(", ", user.Preferences.Select(x => x.Id.ToString())));
			var excludeUserIds = new SqlParameter("@excludeUserIds",
				string.Join(", ", usersIdsToExclude.Select(x => x.ToString())));

			return Context.Instance.Database.SqlQuery<User>(
				"SELECT [Users].[Id], [Users].[Name], [Users].[Email], [Users].[Password], [Users].[CreatedAt], [Users].[UpdatedAt] " +
				"FROM [dbo].[Users] AS [Users] INNER JOIN [dbo].[PreferenceValueUsers] AS [Preferences] " +
				"ON [Users].[Id] = [Preferences].[User_id] AND [Preferences].[PreferenceValue_Id] IN (@preferencesValues) " +
				"AND [Preferences].[User_id] NOT IN (@excludeUserIds) " +
				"GROUP BY [Users].[Id], [Users].[Name], [Users].[Email], [Users].[Password], [Users].[CreatedAt], [Users].[UpdatedAt] " +
				"ORDER BY COUNT([Preferences].[PreferenceValue_Id]) DESC",
				preferencesValues, excludeUserIds).ToList();
		}

		protected Chat GetChatByUsers(User a, User b)
		{
            return Context.Instance.Chats
                .Where(x => x.Users.Intersect(new List<User> { a, b }).Count() == 2)
                .FirstOrDefault();
		}

		/// <summary>
		/// Salva o match e cria um chat entre os usuário se ambos deram um match um no outro
		/// </summary>
		/// <param name="currentUser">O usuário que deu match</param>
		/// <param name="usertToMatch">O usuário "alvo" do match</param>
		public void CreateMatch(User currentUser, User usertToMatch)
		{
			UserDAO.SaveMatch(currentUser, usertToMatch);

			if (currentUser.MatchedUsers.Contains(usertToMatch))
			{
				if (GetChatByUsers(currentUser, usertToMatch) == null)
				{
					ChatDAO.Save(new Chat
					{
						Users = new List<User>
                        {
                            currentUser, usertToMatch
                        }
					});
				}
			}
		}
	}
}
