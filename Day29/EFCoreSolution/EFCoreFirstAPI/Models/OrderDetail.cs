using System.ComponentModel.DataAnnotations;

namespace EFCoreFirstAPI.Models
{
    public class OrderDetail
    {
        [Key]
        public int SNo { get; set; }
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderDetail()
        {
            Order = new Order();
            Product = new Product();
        }
    }
}
