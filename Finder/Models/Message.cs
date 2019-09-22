namespace Finder.Models
{
	public class Message : Model
	{
		public Chat Chat { get; set; }
		public User User { get; set; }
		public string Text { get; set; }
	}
}
