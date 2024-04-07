using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Size
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "INGRESE LA DESCRIPCIÓN")]
        [Display(Name = "Talla")]
        public string SizeDescription { get; set; }
    }
}
