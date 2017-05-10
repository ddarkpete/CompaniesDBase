namespace CompaniesDBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CompaniesDBase.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CompaniesDBase.Models.CompaniesDBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompaniesDBase.Models.CompaniesDBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Companies.AddOrUpdate(
                c => c.Id,
               new Company
               {
                   Id = 1,
                   CompanyName = "Biedra",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               },
               new Company
               {
                   Id = 2,
                   CompanyName = "Lewiatan",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               },
               new Company
               {
                   Id = 3,
                   CompanyName = "Øaba",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               },
               new Company
               {
                   Id = 4,
                   CompanyName = "Sam",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               },
               new Company
               {
                   Id = 5,
                   CompanyName = "Brutto",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               },
               new Company
               {
                   Id = 6,
                   CompanyName = "èdzichu kopara sp. z.o.o.",
                   NIPNumber = "1",
                   REGONNumber = "2",
                   KRSNumber = "3"
               }
               );
        }
    }
}
