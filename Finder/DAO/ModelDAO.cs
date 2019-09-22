using Finder.Models;
using System;
using System.Data.Entity;

namespace Finder.DAO
{
	public abstract class ModelDAO
	{
		protected virtual void SaveModel(Model model)
		{
			try
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
			catch (Exception ex)
			{
				if (model.Id == 0)
				{
					RemoveModelInDbSet(model);
				}

				throw ex;
			}
		}

		protected abstract void RemoveModelInDbSet(Model model);
		protected abstract void IncludeModelInDbSet(Model model);
	}
}
