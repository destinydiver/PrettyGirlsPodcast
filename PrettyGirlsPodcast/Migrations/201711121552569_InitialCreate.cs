namespace PrettyGirlsPodcast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        Host_Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Host_Id);
            
            CreateTable(
                "dbo.Podcasts",
                c => new
                    {
                        Podcast_Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        DateCasted = c.DateTime(nullable: false),
                        Description = c.String(),
                        PodcastHost_Host_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Podcast_Id)
                .ForeignKey("dbo.Hosts", t => t.PodcastHost_Host_Id, cascadeDelete: true)
                .Index(t => t.PodcastHost_Host_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Podcasts", "PodcastHost_Host_Id", "dbo.Hosts");
            DropIndex("dbo.Podcasts", new[] { "PodcastHost_Host_Id" });
            DropTable("dbo.Podcasts");
            DropTable("dbo.Hosts");
        }
    }
}
