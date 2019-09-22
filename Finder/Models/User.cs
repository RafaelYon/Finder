using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class User : Model
    {
		public string Name { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(254)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<PreferenceValue> Preferences { get; set; }

        /// <summary>
        /// Lista de usuário que o usuário deu match
        /// </summary>
        public virtual List<User> UsersMatched { get; set; }

        /// <summary>
        /// Lista de usuário que deram match neste usuário
        /// </summary>
        public virtual List<User> MatchedUsers { get; set; }

		public virtual List<Chat> Chats { get; set; }
		public virtual List<Message> Messages { get; set; }

		public User()
        {
            Preferences = new List<PreferenceValue>();
            MatchedUsers = new List<User>();
			UsersMatched = new List<User>();
        }

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(User user)
		{
			if (user == null)
				return false;

			return user.Id == this.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			User sameTypeObj = obj as User;

			if (sameTypeObj == null)
				return false;

			return Equals(sameTypeObj);
		}
	}
}
