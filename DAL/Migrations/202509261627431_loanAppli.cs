namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loanAppli : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanApplications", "StartDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.LoanApplications", "DueDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanApplications", "DueDate");
            DropColumn("dbo.LoanApplications", "StartDate");
        }
    }
}
