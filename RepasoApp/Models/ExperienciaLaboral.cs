using System.ComponentModel.DataAnnotations;

namespace RepasoApp.Models
{
    public class ExperienciaLaboral {
        
        public long Id { get; set;}
        [Required(ErrorMessage ="Campo {0} requerido")]
        public string? Cargo {get; set;}
        [Required(ErrorMessage ="Campo {0} requerido")]
        public string? NombreEmpresa {get; set;}
        [Required(ErrorMessage ="Campo {0} requerido")]
        public string? Descripcion {get; set;}
        public long TipoEmpleoId { get; set;}
        public long EntidadFederativaId {get; set;}
    }
}