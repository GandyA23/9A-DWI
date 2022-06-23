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
    public class Contacto {
        [Required(ErrorMessage = "Campo {0} Requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe ser entre {1} y {2}")]
        public string? Nombre { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Formato de correo invalido")]
        public string? Email { get; set; }
        [Required]
        public string? Telefono { get; set; }
        [Required]
        [Range(minimum:10, maximum:120, ErrorMessage = "El rango de {0} debe de ser entre {1} y {2}")]
        public int Edad { get; set; }
    }
}