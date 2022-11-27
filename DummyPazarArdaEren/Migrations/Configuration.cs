namespace DummyPazarArdaEren.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DummyPazarArdaEren.Models.DummyPazarModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DummyPazarArdaEren.Models.DummyPazarModel context)
        {
            context.ManagerTypes.AddOrUpdate(m => m.ID, new Models.ManagerType() { ID=1, Name="Admin"});
            context.ManagerTypes.AddOrUpdate(m => m.ID, new Models.ManagerType() { ID=2, Name="Moderatör"});
            context.Managers.AddOrUpdate(m => m.ID, new Models.Manager() { ID=1, Name="Arda",Surname="Eren",Username="DeCell",Mail="Poedx2@gmail.com", ManagerType_ID=1,IsActive=true,Passworld="123456789"});
        }
    }
}
