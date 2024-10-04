using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechStoreAPI.DTOs.Request;

public class OrderDTO
{

    [Required(ErrorMessage = "El estado es obligatorio.")]
    [StringLength(50, ErrorMessage = "El estado no puede exceder los 50 caracteres.")]
    public required string Status { get; set; }


    [Required(ErrorMessage = "La fecha del pedido es requerida.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha del Pedido")]
    [FutureDateValidation(ErrorMessage = "La fecha del pedido no puede ser una fecha futura.")]
    public DateTime OrderDate { get; set; }


    [Required(ErrorMessage = "El total es requerido.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El total tiene que ser un numero positivo mayor a 0.")]
    [DataType(DataType.Currency, ErrorMessage = "El total tiene que estar en un formato valido.")]
    public double TotalAmount { get; set; }



    [Required(ErrorMessage = "El Id del cliente es requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El Id del cliente debe ser un número entero positivo mayor a 0.")]
    [Display(Name = "Id del Cliente")]
    public int CustomerId { get; set; }

}

public class FutureDateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date > DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    }
}