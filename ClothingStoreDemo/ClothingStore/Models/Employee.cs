using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Apellido")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Salario")]
        public decimal Salary { get; set; }

        public string EmployeeName { get; set; }
    }
}
