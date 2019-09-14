using System;

namespace Finder.Models
{
    public abstract class Model
    {
        public Model()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
