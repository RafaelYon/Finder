using System.Collections.Generic;

namespace Finder.Models
{
    public class PreferenceType : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PreferenceValue> Values { get; set; }

		public PreferenceType()
		{
			Values = new List<PreferenceValue>();
		}
	}
}
