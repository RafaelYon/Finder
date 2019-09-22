using Finder.Models;
using System.Data.Entity;

namespace Finder.DAO
{
	public abstract class ModelDAO
	{
		protected virtual void SaveModel(Model model)
		{
			if (model.Id == 0)
			{
				IncludeModelInDbSet(model);
			}
			else
			{
				Context.Instance.Entry(model).State = EntityState.Modified;
				model.UpdateDate();
			}

			Context.Instance.SaveChanges();
		}

		protected abstract void IncludeModelInDbSet(Model model);
	}
}
