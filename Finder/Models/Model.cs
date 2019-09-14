using System;

namespace Finder.Models
{
    public abstract class Model : IUpdateAt
    {
        public Model()
        {
            CreatedAt = DateTime.Now;

			UpdateDate();
        }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

		public void UpdateDate()
		{
			UpdatedAt = DateTime.Now;
		}
	}
}
