using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "INGRESE EL NOMBRE DE LA CATEGORÍA")]
        [Display(Name = "Nombre de categoría")]
        public string CategoryName { get; set; }
    }
}
