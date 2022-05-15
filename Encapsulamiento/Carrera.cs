using System;

namespace Encapsulamiento {
    public class Carrera {
        // private long id;
        
        // Esta variable la va a trabajar de manera interna
        private string nombre;

        // property, getter and setter de Id
        // No requiere una variable extra
        public long Id {
            get;
            set;
        }

        // getter y setter de Nombre (Es posible asignar valores default)
        // Necesita de una variable para trabajar de manera interna
        public string Nombre {
            get { return this.nombre; }
            set { nombre = value; }
        }

        // Constructores
        public Carrera () {
            //
        }

        public Carrera (long id, string nombre) {
            Id = id;
            Nombre = nombre;
        }
    }
}
