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

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(PreferenceType p)
		{
			if (p == null)
				return false;

			return p.Id == this.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var sameTypeObj = obj as PreferenceType;

			if (sameTypeObj == null)
				return false;

			return Equals(sameTypeObj);
		}
	}
}
