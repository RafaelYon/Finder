using System.Data.Entity;

namespace Finder.Models
{
    public class Context : DbContext
    {
        private static Context instance;

        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }

                return instance;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PreferenceType> PreferenceTypes { get; set; }
        public DbSet<PreferenceValue> PreferenceValues { get; set; }
		public DbSet<Chat> Chats { get; set; }

		public Context() : base("FinderDB") { }
    }
}
