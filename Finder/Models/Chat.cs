using System.Collections.Generic;

namespace Finder.Models
{
	public class Chat : Model
	{
		public User FirstUser { get; set; }
		public User SecondUser { get; set; }

		public virtual List<Message> Messages { get; set; }

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
            return SecondUser.Name;
        }
    }
}
