using Microsoft.AspNetCore.Mvc.Rendering;

namespace RepasoApp.Models
{
    public class ExperienciaLaboralViewModel : ExperienciaLaboral
    {
        public IEnumerable<ExperienciaLaboral>? ExperienciaLaborales { get; set;}
        public IEnumerable<SelectListItem>? TiposEmpleos { get; set;}
        public IEnumerable<SelectListItem>? EntidadesFederativas {get; set;}
        public int AbrirModel {get; set;} = 0;
    }
}