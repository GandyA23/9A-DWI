using AutoMapper;
using RepasoApp.Models;

namespace RepasoApp.Services 
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles ()
        {
            CreateMap<ExperienciaLaboral, ExperienciaLaboralViewModel>();
        }
    }
}
