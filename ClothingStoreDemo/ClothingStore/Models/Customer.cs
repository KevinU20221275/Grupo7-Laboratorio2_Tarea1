using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Apellido")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        public string CustomerName { get; set; }


    }
}
