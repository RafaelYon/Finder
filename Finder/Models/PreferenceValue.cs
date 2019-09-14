using System.Collections.Generic;

namespace Finder.Models
{
    public class PreferenceValue : Model
    {
        public int Id { get; set; }
        public PreferenceType PreferenceType { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
