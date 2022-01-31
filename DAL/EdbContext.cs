using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EdbContext: DbContext
    {
        public EdbContext() : base("dbcon")
        {
            
        }

        public DbSet<categoryMaster> categoryMasters { get; set; }
        public DbSet<subCategoryMaster> subCategoryMasters { get; set; }
        public DbSet<thirdcategoryMaster> thirdcategoryMasters { get; set; }
        public DbSet<productMaster> productMasters { get; set; }
        public DbSet<CartMaster> CartMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<ShippingAdderessMaster> ShippingAdderessMasters { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }




     
   protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
