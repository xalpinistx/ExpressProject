namespace ExpressProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ReleaseDate = c.String(),
                        Director = c.String(),
                        Budget = c.Double(),
                        AgeLimit = c.String(),
                        Length = c.String(),
                        WorldWideGross = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Age = c.Byte(),
                        Sex = c.Boolean(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Movie_MovieId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.UserMovies", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.UserMovies", new[] { "User_UserId" });
            DropTable("dbo.UserMovies");
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
        }
    }
}
