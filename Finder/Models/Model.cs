using System;

namespace Finder.Models
{
    public abstract class Model : IUpdateAt
    {
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		public Model()
        {
            CreatedAt = DateTime.Now;

			UpdateDate();
        }

		public void UpdateDate()
		{
			UpdatedAt = DateTime.Now;
		}
	}
}
