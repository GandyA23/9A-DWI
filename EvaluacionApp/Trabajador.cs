namespace EvaluacionApp {
    public class Trabajador {
        public Trabajador (string nombre, int edad, double estatura, char sexo, bool estadoCivil) {
            Nombre = nombre;
            Edad = edad;
            Estatura = estatura;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
        }

        public string Nombre {
            get; set;
        }

        public int Edad {
            get; set;
        }

        public double Estatura {
            get; set;
        }

        public char Sexo {
            get; set;
        }

        public bool EstadoCivil {
            get; set;
        }
        
    }
}