namespace AppASM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User14 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TraineeClasses", new[] { "Trainee_Id" });
            DropColumn("dbo.TraineeClasses", "ApplicationUserId");
            RenameColumn(table: "dbo.TraineeClasses", name: "Trainee_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.TraineeClasses", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TraineeClasses", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TraineeClasses", new[] { "ApplicationUserId" });
            AlterColumn("dbo.TraineeClasses", "ApplicationUserId", c => c.Int());
            RenameColumn(table: "dbo.TraineeClasses", name: "ApplicationUserId", newName: "Trainee_Id");
            AddColumn("dbo.TraineeClasses", "ApplicationUserId", c => c.Int());
            CreateIndex("dbo.TraineeClasses", "Trainee_Id");
        }
    }
}
