using EF.Contrib.ModelConfiguration.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    static class Samples
    {
        public static void TestLoadConfigurations()
        {
            using(var context =   new OrderContext())
            {
                var customers = context.Customers.ToList();
            }
        }
    }
    public class OrderContext
        : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(ConfigurationSolver.FromThisAssembly());
            //modelBuilder.Configurations.Add(ConfigurationSolver.FromNamedAssembly("Samples"));
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
    }
    public class CustomerConfiguration
        : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration(int a) { }
    }
    public class OrderConfiguration
        : EntityTypeConfiguration<Order>
    {
    }
}
