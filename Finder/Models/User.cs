using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class User : Model
    {
        public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(254)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
        public string Password { get; set; }

        public List<PreferenceValue> Preferences { get; set; }

        /// <summary>
        /// Lista de usuário que o usuário deu match
        /// </summary>
        public List<User> UsersMatched { get; set; }

        /// <summary>
        /// Lista de usuário que deram match neste usuário
        /// </summary>
        public List<User> MatchedUsers { get; set; }

        public User()
        {
            Preferences = new List<PreferenceValue>();
            MatchedUsers = new List<User>();
			UsersMatched = new List<User>();
        }
    }
}
