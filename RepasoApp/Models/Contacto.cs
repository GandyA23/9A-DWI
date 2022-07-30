using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace RepasoApp.Models
{
        public class Contacto /* IValidatableObject*/
    {
        public int Id {get; set;}

        [Required(ErrorMessage ="Campo {0} requerido")]
        [StringLength(maximumLength: 50,MinimumLength =2,ErrorMessage ="La longitud del  {0} debe ser entre {2} y {1} caracteres")]
        [Display(Name = "Nombre de la persona")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage ="Campo {0} requerido")]
        [Remote(action: "VerificarExisteCorreo", controller: "Contacto", AdditionalFields = nameof(Id))]
        [EmailAddress(ErrorMessage = "Formato de correo no valido")]
        public string? CorreoElectronico { get; set; }

        [Required(ErrorMessage ="Campo {0} requerido")]
        [Remote(action: "VerificarExisteTelefono", controller: "Contacto", AdditionalFields = nameof(Id))]
        [RegularExpression("^[0-9]+", ErrorMessage = "Telefono no valido")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage ="Campo {0} requerido")]
        [Range(minimum:0,maximum:120,ErrorMessage = "Edad no valida")]
        public int? Edad { get; set; }

       /* public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           if (Nombre != null && Nombre.Length > 0){
            var primeraLetra = Nombre[0].ToString();
            if (primeraLetra != primeraLetra.ToUpper()){
                yield return new ValidationResult("La primera letra debe ser mayuscula",
                new []{nameof(Nombre)});
            }     
           }
        
        }*/
    }
}