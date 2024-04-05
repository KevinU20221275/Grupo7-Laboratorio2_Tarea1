using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Display(Name= "Cliente")]
        public int CustomerId { get; set; }

        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Display(Name = "Producto")]
        public int ProductId { get; set; }

        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        [Display(Name = "Fecha")]
        public DateTime SaleDate { get; set; }

        public decimal Total { get; set; }

        public string CustomerName { get; set; }

        public string EmployeeName { get; set; }

        public Customer? Customer { get; set; }

        public Employee? Employee { get; set; }

        public Product? Product { get; set; }
    }
}
