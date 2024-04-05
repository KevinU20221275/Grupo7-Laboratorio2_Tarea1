using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Size
    {
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        public string SizeDescription { get; set; }
    }
}
