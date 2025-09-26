namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BankAccounts", "AccTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.LoanApplications", "LoanTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.LoanApplications", "StatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.BankAccounts", "AccTypeId");
            CreateIndex("dbo.LoanApplications", "LoanTypeId");
            CreateIndex("dbo.LoanApplications", "StatusId");
            AddForeignKey("dbo.BankAccounts", "AccTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanApplications", "LoanTypeId", "dbo.LoanTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.LoanApplications", "StatusId", "dbo.Statuses", "Id", cascadeDelete: true);
            DropColumn("dbo.BankAccounts", "AccountType");
            DropColumn("dbo.LoanApplications", "LoanType");
            DropColumn("dbo.LoanApplications", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LoanApplications", "Status", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.LoanApplications", "LoanType", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AddColumn("dbo.BankAccounts", "AccountType", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropForeignKey("dbo.LoanApplications", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.LoanApplications", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.BankAccounts", "AccTypeId", "dbo.AccountTypes");
            DropIndex("dbo.LoanApplications", new[] { "StatusId" });
            DropIndex("dbo.LoanApplications", new[] { "LoanTypeId" });
            DropIndex("dbo.BankAccounts", new[] { "AccTypeId" });
            DropColumn("dbo.LoanApplications", "StatusId");
            DropColumn("dbo.LoanApplications", "LoanTypeId");
            DropColumn("dbo.BankAccounts", "AccTypeId");
            DropTable("dbo.Statuses");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.AccountTypes");
        }
    }
}
