using EFFirstApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFFirstApp.Contexts
{
    public class ShoppingContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=G3SLAPTOP\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEFCode15Oct24;TrustServerCertificate=True");
        }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
    }
}
