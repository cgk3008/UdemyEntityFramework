namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //method to preserve data in table to be deleted!!!!

            CreateTable(
               "dbo._Categories", //note underscore before name!!!!
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   Name = c.String(),
               })
               .PrimaryKey(t => t.Id);
            Sql("INSERT INTO _Categories (Name) SELECT Name FROM Categories");

            //below is existing data from add-migration
            DropTable("dbo.Categories");
        }

        public override void Down()
        {
            //below is from add-migration
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            //then add down method sql daata insert command and drop table _Categories
            Sql("INSERT INTO Categories (Name) SELECT Name FROM _Categories");
            DropTable("dbo._Categories");
            //so we can do the migration, BUT BEFORE UPDATING DATABASE ADD the extra code to preserve data!!!!
        }
    }
}
