using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de categoría")]
        public string CategoryName { get; set; }
    }
}
