using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinqPractice
{
    internal class LinqEFCore
    {
        public void EFCoreGetData()
        {
            using var dbContext = new CustomerDBContext();
            IQueryable<string> query = from c in dbContext.Customers
                                       where c.Name.Contains("a")
                                       orderby c.Name.Length
                                       select c.Name.ToUpper();

            IQueryable<int> productQuery = from p in dbContext.Products
                                           where p.ProductName == "Led"
                                           orderby p.CustomerID
                                           select p.CustomerID;


            Console.WriteLine("---------------");
            Console.WriteLine("Customers");
            foreach (string name in query) Console.WriteLine(name);
            Console.WriteLine("---------------");
            Console.WriteLine("Products");

            foreach (int cId in productQuery) Console.WriteLine(cId);

}

        public void InsertCustomerData()
        {
            using var dbContext = new CustomerDBContext();
            Customer customer = new Customer();
            customer.Name = "Ania";
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

        }
    }

    
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CustomerID { get; set; }
    }

    public class CustomerDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        => builder.UseSqlServer(MySettings.Default.connection);

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //=> modelBuilder.Entity<Customer>().ToTable("Customer")
        //.HasKey(c => c.ID);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer")
                        .HasKey(c => c.ID);
            modelBuilder.Entity<Product>().ToTable("Product")
                        .HasKey(p => p.ProductID);
                           
        }
    }
}