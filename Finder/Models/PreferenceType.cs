using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class PreferenceType : Model
    {
		[StringLength(150)]
		[Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual List<PreferenceValue> Values { get; set; }

		public PreferenceType()
		{
			Values = new List<PreferenceValue>();
		}
	}
}
