using Finder.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Finder.DAO
{
	public class PreferenceTypeDAO : ModelDAO, IDAO<PreferenceType>
	{
		public PreferenceType GetByName(string name)
		{
			var result = Context.Instance.PreferenceTypes.FirstOrDefault(x => x.Name.Equals(name));

			if (result == null)
			{
				throw new Exception($"Tipo de preferência \"{name}\" não encontrada");
			}

			return result;
		}

		public List<PreferenceType> SearchByName(string name)
			=> Context.Instance.PreferenceTypes.Where(x => x.Name.Contains(name)).ToList();

		public List<PreferenceType> GetAll()
			=> Context.Instance.PreferenceTypes.ToList();

		public void Save(PreferenceType model)
		{
			SaveModel(model);
		}

		protected override void IncludeModelInDbSet(Model model)
		{
			Context.Instance.PreferenceTypes.Add(model as PreferenceType);
		}
	}
}
