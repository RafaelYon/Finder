using Finder.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Finder.DAO
{
	public static class PreferenceTypeDAO
	{
		public static void Save(PreferenceType model)
		{
			model.UpdateDate();

			if (model.Id == 0)
			{
				Context.Instance.PreferenceTypes.Add(model);
			}
			else
			{
				model.UpdateDate();
				Context.Instance.Entry(model).State = EntityState.Modified;
			}

			Context.Instance.SaveChanges();
		}

		public static PreferenceType GetByName(string name)
		{
			var result = Context.Instance.PreferenceTypes.FirstOrDefault(x => x.Name.Equals(name));

			if (result == null)
			{
				throw new Exception($"Tipo de preferência \"{name}\" não encontrada");
			}

			return result;
		}

		public static List<PreferenceType> SearchByName(string name)
			=> Context.Instance.PreferenceTypes.Where(x => x.Name.Contains(name)).ToList();

		public static List<PreferenceType> GetAll()
			=> Context.Instance.PreferenceTypes.ToList();
	}
}
