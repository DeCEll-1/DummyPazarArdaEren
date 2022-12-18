using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DummyPazarArdaEren.Models
{
    public partial class DummyPazarModel : DbContext
    {
        public DummyPazarModel()
            : base("name=DummyPazarModel")
        {

        }

        public virtual DbSet<Manager> Managers{ get; set; }
        public virtual DbSet<ManagerType> ManagerTypes { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
