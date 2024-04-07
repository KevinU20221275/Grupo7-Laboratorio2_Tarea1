using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "INGRESE EL NOMBRE")]
        [Display(Name = "Nombre")]
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "INGRESE EL APELLIDO")]
        [Display(Name = "Apellido")]
        public string EmployeeLastName { get; set; }

        [Required(ErrorMessage = "INGRESE UN CORREO ELECTRONICO")]
        [EmailAddress(ErrorMessage = "INGRESE UN CORREO ELECTRONICO VALIDO")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "INGRESE SU NUMERO DE TELEFONO")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "EL FORMATO DEBE DE SER ####-####.")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "INGRESE UNA DIRECCIÓN VALIDA")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required(ErrorMessage = "INGRESE EL SALARIO")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "SOLO SE PERMITEN NUMEROS")]
        [Display(Name = "Salario")]
        public decimal Salary { get; set; }

        public string EmployeeName { get; set; }
    }
}
