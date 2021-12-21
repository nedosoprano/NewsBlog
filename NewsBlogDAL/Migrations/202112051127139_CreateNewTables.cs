namespace NewsBlogDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(nullable: false, maxLength: 20),
                        ReviewText = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionnaireResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Text", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
            DropTable("dbo.QuestionnaireResults");
            DropTable("dbo.Feedbacks");
        }
    }
}
