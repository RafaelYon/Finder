using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class PreferenceType : Model
    {
        public int Id { get; set; }
		[StringLength(150)]
		[Index(IsUnique = true)]
        public string Name { get; set; }

        public List<PreferenceValue> Values { get; set; }

		public PreferenceType()
		{
			Values = new List<PreferenceValue>();
		}
	}
}
