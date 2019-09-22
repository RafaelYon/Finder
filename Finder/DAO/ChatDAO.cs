using Finder.Models;

namespace Finder.DAO
{
	public class ChatDAO : ModelDAO, IDAO<Chat>
	{
		public void Save(Chat model)
		{
			SaveModel(model);
		}

		protected override void IncludeModelInDbSet(Model model)
		{
			Context.Instance.Chats.Add(model as Chat);
		}
	}
}
