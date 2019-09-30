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
		public List<Match> GetUsersAvaliableToMatch(User user)
		{
			if (user.Preferences.Count() < 1)
			{
				throw new ArgumentException("Você precisa definir suas preferências para obter recomendações de pessoas.");
			}

			var usersIdsToExclude = new List<int>(user.UsersMatched.Select(x => x.Id));
			usersIdsToExclude.Add(user.Id);

			var preferencesValues = string.Join(", ", user.Preferences.Select(x => x.Id.ToString()));
			var excludeUserIds = string.Join(", ", usersIdsToExclude.Select(x => x.ToString()));

			var result = Context.Instance.Database.SqlQuery<Match>(
				"SELECT [Users].[Id] AS UserId, COUNT(0) AS Score " +
				"FROM [dbo].[Users] AS [Users] INNER JOIN [dbo].[PreferenceValueUsers] AS [Preferences] " +
				"ON [Users].[Id] = [Preferences].[User_id] AND [Preferences].[PreferenceValue_Id] IN (" + preferencesValues + ") " +
				"AND [Preferences].[User_id] NOT IN (" + excludeUserIds + ") " +
				"GROUP BY [Users].[Id]" +
				"ORDER BY COUNT([Preferences].[PreferenceValue_Id]) DESC").ToList();

            return result;
        }

		protected Chat GetChatByUsers(User a, User b)
		{
			return a.Chats.Where(x => x.Users.Contains(b)).FirstOrDefault();
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
