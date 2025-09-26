namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountType = c.String(nullable: false, maxLength: 50, unicode: false),
                        Balance = c.Double(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                        Income = c.Double(nullable: false),
                        EId = c.Int(nullable: false),
                        CreditScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employments", t => t.EId, cascadeDelete: true)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.Employments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanType = c.String(nullable: false, maxLength: 50, unicode: false),
                        PrincipalAmmount = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        Status = c.String(nullable: false, maxLength: 50, unicode: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanApplications", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BankAccounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "EId", "dbo.Employments");
            DropIndex("dbo.LoanApplications", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "EId" });
            DropIndex("dbo.BankAccounts", new[] { "CustomerId" });
            DropTable("dbo.LoanApplications");
            DropTable("dbo.Employments");
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccounts");
        }
    }
}
