using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStoreAPI.DTOs.Request
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public required string Name { get; set; }


        [Required(ErrorMessage = "La direccion es obligatoria.")]
        [StringLength(80, ErrorMessage = "La direcccion no puede exceder los 80 caracteres.")]
        public required string Address { get; set; }


        [Required(ErrorMessage = "El telefono es obligatorio.")]
        [StringLength(20, ErrorMessage = "El telefono no puede exceder los 20 caracteres.")]
        public required string Phone { get; set; }


        [Required(ErrorMessage = "El email es obligatorio.")]
        [StringLength(80, ErrorMessage = "El email no puede exceder los 80 caracteres.")]
        public required string Email { get; set; }
    }
}