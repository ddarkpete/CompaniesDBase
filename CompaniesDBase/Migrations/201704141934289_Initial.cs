namespace CompaniesDBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        NIPNumber = c.String(nullable: false, maxLength: 10),
                        KRSNumber = c.String(nullable: false, maxLength: 10),
                        REGONNumber = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
        }
    }
}
