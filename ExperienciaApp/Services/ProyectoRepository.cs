using ExperienciaApp.Models;

namespace ExperienciaApp.Services {
    // La I al principio hace referencia a la interfaz 
    public interface IProyectoRepository 
    {
        List<Proyecto> ObtenerProyectos ();
    }

    // Con los : es como poner implements en Java
    public class ProyectoRepository : IProyectoRepository
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
                new Proyecto {
                    Titulo = "Amazon",
                    Descripcion = "E-commerce en .NET",
                    Imagen = "image1.jpg",
                    Enlace = "https://www.amazon.com"
                },
                new Proyecto {
                    Titulo = "Farmacia",
                    Descripcion = "Plataforma que administra medicamentos creada con Laravel 7",
                    Imagen = "image2.jpg",
                    Enlace = "https://www.farmacia.com"
                },
                new Proyecto {
                    Titulo = "Educación",
                    Descripcion = "Plataforma que administra alumnos en una escuela creada con Laravel 7 (Back-end) y Quasar 2 (Front-end)",
                    Imagen = "image3.jpg",
                    Enlace = "https://www.escuela.com"
                },
                new Proyecto {
                    Titulo = "Ferias Virtuales",
                    Descripcion = "Plataforma que administra Ferias Virtuales creada con Laravel 4",
                    Imagen = "image4.jpg",
                    Enlace = "https://www.ferias.com"
                }
            };
        }
    }
}
