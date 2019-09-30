namespace Finder.Models
{
	public class Match
	{
		private User _user;

		public int UserId { get; set; }
		public int Score { get; set; }

		public User User
		{
			get
			{
				if (_user == null)
				{
					_user = Context.Instance.Users.Find(UserId);
				}

				return _user;
			}
		}
	}
}
