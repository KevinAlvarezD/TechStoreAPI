using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStoreAPI.DTOs.Request
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatorio.")]
        [StringLength(100, ErrorMessage = "La descripcion no puede exceder los 100 caracteres.")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio tiene que ser un numero positivo mayor a 0.")]
        [DataType(DataType.Currency, ErrorMessage = "El precio tiene que estar en un formato valido.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser un número entero positivo mayor a 0.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "El Id de la categoria es requerida.")]
        [Range(1, int.MaxValue, ErrorMessage = "El Id de la categoria debe ser un número entero positivo mayor a 0.")]
        public int CategoryId { get; set; }

    }
}