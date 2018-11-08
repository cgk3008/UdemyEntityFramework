namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false)); // add nullable: false
            //dangerous migration, could lose all data in column!!!! if we don't add code below!
            //or use sql line below!!!
            Sql("UPDATE Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
            //below replaces top two lines!!! better
            //RenameColumn("dbo.Courses", "Title", "Name"); //did not use this in final
        }
        
        public override void Down()
        {
            // now check Down method!!!
            AddColumn("dbo.Courses", "Title", c => c.String( nullable: false)); //nullable: false
            //copy line from above and switch column names!!!
            Sql("UPDATE Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
