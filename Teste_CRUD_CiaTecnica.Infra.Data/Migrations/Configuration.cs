namespace Teste_CRUD_CiaTecnica.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Teste_CRUD_CiaTecnica.Infra.Data.Context.DBContext_Teste_CRUD>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Teste_CRUD_CiaTecnica.Infra.Data.Context.DBContext_Teste_CRUD context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
