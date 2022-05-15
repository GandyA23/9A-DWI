using System;

namespace Encapsulamiento {
    public class Alumno {
        // property, getter and setter
        public long Id {
            get; 
            set;
        }

        // El simbolo ? nos ayudará a indicar que nuestra propiedad puede admitir nulos. 
        public string? Nombre {
            get; 
            set;
        }

        public int Edad {
            get;
            set;
        } 

        // El simbolo ? nos ayudará a indicar que nuestra propiedad puede admitir nulos. 
        public Carrera? Carrera {
            get;
            set;
        }
    }
}
