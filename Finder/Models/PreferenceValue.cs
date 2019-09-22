using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class PreferenceValue : Model
    {
		[StringLength(150)]
		[Index]
        public string Name { get; set; }

		public virtual PreferenceType PreferenceType { get; set; }
		public virtual List<User> Users { get; set; }

		public override int GetHashCode()
		{
			return Id;
		}

		public bool Equals(PreferenceValue v)
		{
			if (v == null)
				return false;

			return v.Id == this.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var sameTypeObj = obj as PreferenceValue;

			if (sameTypeObj == null)
				return false;

			return Equals(sameTypeObj);
		}
	}
}
