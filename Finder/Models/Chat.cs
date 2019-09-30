using Finder.Services;
using System.Collections.Generic;
using System.Linq;

namespace Finder.Models
{
	public class Chat : Model
	{
        public virtual List<User> Users { get; set; }

        public virtual List<Message> Messages { get; set; }

		public Chat()
		{
			Users = new List<User>();
			Messages = new List<Message>();
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(Chat chat)
		{
			if (chat == null)
				return false;

			return chat.Id == this.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var sameTypeObj = obj as Chat;

			if (sameTypeObj == null)
				return false;

			return Equals(sameTypeObj);
		}

        public override string ToString()
        {
            return Users.Where(x => x.Id != UserService.GetLoggedUser().Id).FirstOrDefault().Name;
        }
    }
}
