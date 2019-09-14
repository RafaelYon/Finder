namespace Finder.Models
{
	public class Chat : Model
	{
		public User FirstUser { get; set; }
		public User SecondUser { get; set; }
	}
}
