using ExperienciaApp.Models;

namespace ExperienciaApp.Services {
    // La I al principio hace referencia a la interfaz 
    public interface IHabilidadRepository 
    {
        List<Habilidad> ObtenerHabilidades ();
    }

    // Con los : es como poner implements en Java
    public class HabilidadRepository : IHabilidadRepository
    {
        public List<Habilidad> ObtenerHabilidades()
        {
            return new List<Habilidad> () {
                new Habilidad {
                    Nombre = "MVC Laravel"
                },
                new Habilidad {
                    Nombre = "Laravel API Rest"
                },
                new Habilidad {
                    Nombre = "Front-end Quasar"
                },
                new Habilidad {
                    Nombre = "Front-end Bootstrap"
                }
            };
        }
    }
}
