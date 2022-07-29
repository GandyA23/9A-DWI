using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExperienciaApp.Models
{
    public class ContactoViewModel : Contacto
    {
        public IEnumerable<Contacto>? Contactos { get; set; }
    }
}