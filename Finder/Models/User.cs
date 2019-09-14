using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finder.Models
{
    public class User : Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PreferenceValue> Preferences { get; set; }

        public User()
        {
            Preferences = new List<PreferenceValue>();
        }
    }
}
