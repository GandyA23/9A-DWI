namespace Practica04 {
    class Candidato {
        public string Nombre {
            get; set;
        } 

        public int NumeroVotos {
            get; set;
        }

        public Candidato (string nombre) {
            Nombre = nombre;
            NumeroVotos = 0;
        }
    }
}