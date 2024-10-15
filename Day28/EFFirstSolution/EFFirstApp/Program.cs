using EFFirstApp.Contexts;
using EFFirstApp.Models;

namespace EFFirstApp
{
    internal class Program
    {


        ShoppingContext context = new ShoppingContext();
        Product CreateAndPopulateProduct()
        {
            Product product = new Product();
            Console.WriteLine("Please enter the Product Name");
            product.Name = Console.ReadLine() ?? "";
            Console.WriteLine("Please enter the Product Price");
            product.Price = float.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please enter the Product Quantity");
            product.Quantity = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Please enter the Product Image");
            product.Image = Console.ReadLine() ?? "";
            return product;
        }
        void InsertProduct()
        {
            Product product = CreateAndPopulateProduct();
            try
            {
                context.Products.Add(product);//This will add to the local collection
                context.SaveChanges();//This will execute all the DML commands
                Console.WriteLine("Product added");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Product not added");
            }
        }
        void GetProducts()
        {
            var products = context.Products.ToList();
            products = products.OrderByDescending(p => p.Price).ToList();
            PrintProducts(products);
        }
        void PrintProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Id:{product.Id}\nName:{product.Name}\nPrice:{product.Price}\nQuantity:{product.Quantity}\nImage:{product.Image}");
                Console.WriteLine("-------------------------");
            }
        }

        void CreatingRecords()
        {
            Supplier supplier = new Supplier
            {
                SupplierName = "ABC Corp",
                Email = "abccorp@gmail.com",
                Phone = "1234567890"
            };
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            Console.WriteLine("Supplier added");
            Console.WriteLine($"Supplier ID {supplier.SupplierId}");
            Category category = new Category
            {
                CategoryName = "Electronics",
                Description = "Electronic Items"
            };
           
            context.Categories.Add(category);
            context.SaveChanges();
            Console.WriteLine("Category added");
            Console.WriteLine($"Category ID {category.CategoryId}");
            Product product = new Product
            {
                Name = "Laptop",
                Price = 45000,
                Quantity = 10,
                Image = "laptop.jpg",
                CategoryId = category.CategoryId

            };
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Product Added");
            Console.WriteLine("Product Id "+product.Id);
            SupplierProduct supplierProduct = new SupplierProduct
            {
                SupplierId = supplier.SupplierId,
                ProductId = product.Id,

            };
            context.SupplierProducts.Add(supplierProduct);
            context.SaveChanges();
            Console.WriteLine("All done");


        }

        void PrintProductDetails()
        {
            var products = context.Products.ToList();
            foreach (var product in products)
            {
                Console.WriteLine($"Id:{product.Id}\nName:{product.Name}\nPrice:{product.Price}\nQuantity:{product.Quantity}\nImage:{product.Image}");
                var category = context.Categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                Console.WriteLine($"\tCategory:{category.CategoryName}");

                var suppliers = context.SupplierProducts.Where(sp => sp.ProductId == product.Id).ToList();
                foreach (var supplierProduct in suppliers)
                {
                    var supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == supplierProduct.SupplierId);
                    Console.WriteLine($"\tSupplier:{supplier.SupplierName}");

                }

            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.InsertProduct();
            //program.GetProducts();
            program.PrintProductDetails();
        }
    }
}
