namespace Finder.Models
{
	public class Message : Model
	{
		public Chat Chat { get; set; }
		public User User { get; set; }
		public string Text { get; set; }

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(Message message)
		{
			if (message == null)
				return false;

			return message.Id == this.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var sameTypeObj = obj as Message;

			if (sameTypeObj == null)
				return false;

			return Equals(sameTypeObj);
		}
	}
}
