using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStoreAPI.DTOs.Request;

public class CategoryDTO
{

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
    public required string Name { get; set; }


    [Required(ErrorMessage = "La descripcion es obligatorio.")]
    [StringLength(100, ErrorMessage = "La descripcion no puede exceder los 100 caracteres.")]
    public required string Description { get; set; }
}
