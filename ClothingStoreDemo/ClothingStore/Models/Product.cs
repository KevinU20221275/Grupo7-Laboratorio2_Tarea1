using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }

        [Display(Name = "Descripcion del Producto")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set;}

        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Display(Name = "Talla")]
        public int SizeId { get; set; }

        public Category? Category { get; set; }

        public Size? Size { get; set; }


    }
}
