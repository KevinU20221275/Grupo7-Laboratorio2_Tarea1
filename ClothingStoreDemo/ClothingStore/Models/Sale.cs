using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "SELECCIONE UN CLIENTE")]
        [Display(Name= "Cliente")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "SELECCIONE UN EMPLEADO")]
        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "SELECCIONE UN PRODUCTO")]
        [Display(Name = "Producto")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "INGRESE LA CANTIDAD")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "SOLO SE PERMITEN NUMEROS")]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "INGRESE EL PRECIO")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "SOLO SE PERMITEN NUMEROS")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "INGRESE LA FECHA")]
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
