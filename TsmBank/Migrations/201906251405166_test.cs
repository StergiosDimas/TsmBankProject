namespace TsmBank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        StreetNumber = c.Int(nullable: false),
                        PostalCode = c.String(),
                        Region = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdentificationCardNo = c.String(),
                        SSN = c.String(),
                        VatRegNumber = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PrimaryAddressId = c.Int(nullable: false),
                        SecondaryAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.PrimaryAddressId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.SecondaryAddressId)
                .Index(t => t.PrimaryAddressId)
                .Index(t => t.SecondaryAddressId);
            
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountNumber = c.String(nullable: false, maxLength: 16),
                        AccountStatus = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WithdrawalLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NickName = c.String(),
                        OpenedDate = c.DateTime(nullable: false),
                        StatusUpdatedDateTime = c.DateTime(nullable: false),
                        AccountTypeId = c.Byte(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.AccountTypeId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Description = c.Int(nullable: false),
                        InterestRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeriodicFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        TypeOfTransaction = c.Int(nullable: false),
                        TransactionDateAndTime = c.DateTime(nullable: false),
                        CreditAccountNo = c.String(nullable: false, maxLength: 16),
                        CreditIBAN = c.String(),
                        CreditAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditAccountCurrency = c.String(),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditAccountBalanceAfterTransaction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAccountNo = c.String(nullable: false, maxLength: 16),
                        DebitIBAN = c.String(),
                        DebitAccountBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAccountCurrency = c.String(),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAccountBalanceAfterTransaction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApprovedFromBankManager = c.Boolean(nullable: false),
                        PendingForApproval = c.Boolean(nullable: false),
                        TransactionApprovedReview = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        CancelledTransactionId = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Transaction", t => t.CancelledTransactionId)
                .ForeignKey("dbo.Account", t => t.CreditAccountNo, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.DebitAccountNo, cascadeDelete: true)
                .Index(t => t.CreditAccountNo)
                .Index(t => t.DebitAccountNo)
                .Index(t => t.CancelledTransactionId);
            
            CreateTable(
                "dbo.CustomerPhone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        PhoneNumber = c.String(),
                        Type = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Customer", "SecondaryAddressId", "dbo.Address");
            DropForeignKey("dbo.Customer", "PrimaryAddressId", "dbo.Address");
            DropForeignKey("dbo.CustomerPhone", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Transaction", "DebitAccountNo", "dbo.Account");
            DropForeignKey("dbo.Account", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Transaction", "CreditAccountNo", "dbo.Account");
            DropForeignKey("dbo.Transaction", "CancelledTransactionId", "dbo.Transaction");
            DropForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CustomerPhone", new[] { "CustomerId" });
            DropIndex("dbo.Transaction", new[] { "CancelledTransactionId" });
            DropIndex("dbo.Transaction", new[] { "DebitAccountNo" });
            DropIndex("dbo.Transaction", new[] { "CreditAccountNo" });
            DropIndex("dbo.Account", new[] { "CustomerId" });
            DropIndex("dbo.Account", new[] { "AccountTypeId" });
            DropIndex("dbo.Customer", new[] { "SecondaryAddressId" });
            DropIndex("dbo.Customer", new[] { "PrimaryAddressId" });
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CustomerPhone");
            DropTable("dbo.Transaction");
            DropTable("dbo.AccountType");
            DropTable("dbo.Account");
            DropTable("dbo.Customer");
            DropTable("dbo.Address");
        }
    }
}
