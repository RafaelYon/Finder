using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class PreferenceValue : Model
    {
        public int Id { get; set; }
		[StringLength(150)]
		[Index]
        public string Name { get; set; }

		public PreferenceType PreferenceType { get; set; }
		public List<User> Users { get; set; }
    }
}
