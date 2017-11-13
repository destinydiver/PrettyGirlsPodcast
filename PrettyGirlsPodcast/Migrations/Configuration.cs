namespace PrettyGirlsPodcast.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PrettyGirlsPodcast.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PrettyGirlsPodcast.DAL.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PrettyGirlsPodcast.DAL.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Host host1 = new Host
            {
                Host_Id = 1,
                FirstName = "Chuck",
                LastName = "Winters",
                Bio = "He's the greatest!"
            };

            Host host2 = new Host
            {
                Host_Id = 2,
                FirstName = "Mindy",
                LastName = "Reed",
                Bio = "She's much greater than the greatest!!!"
            };

            context.Hosts.AddOrUpdate(h => h.Host_Id,
                host1,
                host2
            );

            context.Podcasts.AddOrUpdate(p => p.Podcast_Id,
                new Podcast() {  Podcast_Id = 1, Title = "Test Podcast", Description = "First test of first podcast.", PodcastHost = host1 },
                new Podcast() {  Podcast_Id = 2, Title = "Second Test", Description = "Second test of best podcast in the world.", PodcastHost = host2 },
                new Podcast() {  Podcast_Id = 3, Title = "Real Life", Description = "Finally talking about real life!", PodcastHost = host1 },
                new Podcast() {  Podcast_Id = 4, Title = "Life Goes On", Description = "The meaning of life is; Shit Happens!", PodcastHost = host2 }
            );
        }
    }
}
