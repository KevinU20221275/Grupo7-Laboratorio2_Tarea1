using System.ComponentModel.DataAnnotations;

namespace ClothingStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "INGRESE EL NOMBRE DEL PRODUCTO")]
        [Display(Name = "Nombre del Producto")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "INGRESE LA DESCRIPCIÓN DEL PRODUCTO")]
        [Display(Name = "Descripcion del Producto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "INGRESE EL PRECIO DEL PRODUCTO")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "SOLO SE PERMITEN NUMEROS")]
        [Display(Name = "Precio")]
        public decimal Price { get; set;}

        [Required(ErrorMessage = "SELECCIONE UNA OPCIÓN")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "SELECCIONE UNA OPCIÓN")]
        [Display(Name = "Talla")]
        public int SizeId { get; set; }

        public string ProductInfo { get; set; }

        public Category? Category { get; set; }

        public Size? Size { get; set; }


    }
}
