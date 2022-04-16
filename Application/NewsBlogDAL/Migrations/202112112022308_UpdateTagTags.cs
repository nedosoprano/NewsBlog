namespace NewsBlogDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTagTags : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Tag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Tag", c => c.String());
        }
    }
}
