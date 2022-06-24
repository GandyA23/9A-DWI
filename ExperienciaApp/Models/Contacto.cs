using System.ComponentModel.DataAnnotations;

/**
[Required]: Validación de que es necesario que el campo tenga un valor
[StringLength]: Validación de string indicando una longitud mínima, máxima 
[StringAddress]: Validación de correo electrónico 

{0} hace referencia al nombre del campo
{1} hace referencia al primer parámetro que colocaste
{2} hace referencia al segundo parámetro que colocaste
*/

namespace ExperienciaApp.Models {
    public class Contacto : IValidatableObject {
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe ser entre {1} y {2}")]
        [Display(Name = "Nombre:")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [RegularExpression("^[0-9]+", ErrorMessage = "Formato de {0} invalido")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [Range(minimum:10, maximum:120, ErrorMessage = "El rango de {0} debe de ser entre {1} y {2}")]
        public int Edad { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (Nombre != null && Nombre.Length > 0) {
                var primeraLetra = Nombre[0].ToString();
                
                // Verifica si la primera letra no es mayuscula
                if (!primeraLetra.Equals(primeraLetra.ToUpper()))
                    yield return new ValidationResult("La primera letra debe de ser mayuscula", new[] { nameof(Nombre) });
            }
        }
    }
}
