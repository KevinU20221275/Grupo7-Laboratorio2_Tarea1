using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "INGRESE EL NOMBRE")]
        [Display(Name = "Nombre")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "INGRESE EL APELLIDO")]
        [Display(Name = "Apellido")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "INGRESE UN CORREO ELECTRONICO")]
        [EmailAddress(ErrorMessage = "INGRESE UN CORREO ELECTRONICO VALIDO")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "INGRESE SU NUMERO DE TELÉFONO")]
        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "EL FORMATO DEBE DE SER ####-####.")]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "INGRESE UNA DIRECCIÓN VALIDA")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        public string CustomerName { get; set; }


    }
}
