namespace Finder.Migrations
{

    using System.Data.Entity.Migrations;
    using System.Linq;
	using Finder.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Finder.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Finder.Models.Context context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.

			if (context.PreferenceTypes.ToArray().Length > 0)
			{
				return;
			}

			context.PreferenceTypes.Add(new PreferenceType
			{
				Name = "Cor",
				Values = new System.Collections.Generic.List<PreferenceValue>
					{
						new PreferenceValue { Name = "Amarelo" },
						new PreferenceValue { Name = "Azul" },
						new PreferenceValue { Name = "Laranja" },
						new PreferenceValue { Name = "Vermelho" },
						new PreferenceValue { Name = "Roxo" },
						new PreferenceValue { Name = "Preto" },
						new PreferenceValue { Name = "Branco" },
						new PreferenceValue { Name = "Marrom" },
					}
			});

			context.PreferenceTypes.Add(new PreferenceType
			{
				Name = "Genêro de filme",
				Values = new System.Collections.Generic.List<PreferenceValue>
					{
						new PreferenceValue { Name = "Ação" },
						new PreferenceValue { Name = "Aventura" },
						new PreferenceValue { Name = "Romance" },
						new PreferenceValue { Name = "Comédia" },
						new PreferenceValue { Name = "Terror" },
						new PreferenceValue { Name = "Suspense" },
						new PreferenceValue { Name = "Drama" },
						new PreferenceValue { Name = "Ficção científica" },
					}
			});

			context.PreferenceTypes.Add(new PreferenceType
			{
				Name = "Genêro de música",
				Values = new System.Collections.Generic.List<PreferenceValue>
					{
						new PreferenceValue { Name = "Axé" },
						new PreferenceValue { Name = "Blues" },
						new PreferenceValue { Name = "Country" },
						new PreferenceValue { Name = "Eletrônica" },
						new PreferenceValue { Name = "Forró" },
						new PreferenceValue { Name = "Funk" },
						new PreferenceValue { Name = "Gospel" },
						new PreferenceValue { Name = "Hip Hop" },
						new PreferenceValue { Name = "Jazz" },
						new PreferenceValue { Name = "MPB" },
						new PreferenceValue { Name = "Clássica" },
						new PreferenceValue { Name = "Pagode" },
						new PreferenceValue { Name = "Pop" },
						new PreferenceValue { Name = "Rap" },
						new PreferenceValue { Name = "Reggae" },
						new PreferenceValue { Name = "Rock" },
						new PreferenceValue { Name = "Samba" },
						new PreferenceValue { Name = "Sertanejo" },
					}
			});

			context.PreferenceTypes.Add(new PreferenceType
			{
				Name = "Animal",
				Values = new System.Collections.Generic.List<PreferenceValue>
					{
						new PreferenceValue { Name = "Passaro" },
						new PreferenceValue { Name = "Peixe" },
						new PreferenceValue { Name = "Gato" },
						new PreferenceValue { Name = "Cachorro" },
					}
			});

			context.PreferenceTypes.Add(new PreferenceType
			{
				Name = "Personalidade",
				Values = new System.Collections.Generic.List<PreferenceValue>
					{
						new PreferenceValue { Name = "Introvertido" },
						new PreferenceValue { Name = "Extrovertido" },
						new PreferenceValue { Name = "Gótico" },
					}
			});

			context.SaveChanges();
		}
    }
}
