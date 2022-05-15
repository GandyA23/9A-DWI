using System;

namespace Practica04 {
    class TestCandidato {
        private const int LIMIT_ATTEMPTS = 3;
        private string PASSWORD = "tVotacion";
        private int votes = 0;
        
        public Candidato[] Candidates {
            get; set;
        }

        public Candidato[] ReadCandidates () {
            Candidates = new Candidato[3];
            for (int i=0; i<3; i++) {
                Console.Write($"Ingresa el nombre del candidato {i+1}: ");
                Candidates[i] = new Candidato(Console.ReadLine());
            }
            return Candidates;
        }

        public int Menu () {
            int n = Candidates.Length;
            
            Console.WriteLine("VOTACIÓN 2022\nCandidatos: ");
            for(int i=0; i<n; i++)
                Console.WriteLine($"{i+1} - {Candidates[i].Nombre}");
            Console.WriteLine($"{n+1} - Cerrar votaciones");
            Console.Write($"Elige una opción [1-{n+1}]: ");

            return Convert.ToInt32(Console.ReadLine());
        }

        public void Vote (int candidate) {
            votes++;
            Candidates[candidate].NumeroVotos++;
        }

        public bool EndVotation () {
            bool flag = false;
            int attempts = 0;

            do {
                Console.Write("Escribe la contraseña para terminar con las elecciones: ");
                string? password = Console.ReadLine();

                flag = PASSWORD.Equals(password);
                
                if (!flag) {
                    attempts++;
                    Console.WriteLine("Contraeña incorrecta, favor de verificarla e intentarlo de nuevo");
                } else 
                    Console.WriteLine("Acceso correcto, las votaciones han terminado");

            } while (attempts < LIMIT_ATTEMPTS && !flag);

            if (attempts == LIMIT_ATTEMPTS)
                Console.WriteLine("Se ha equivocado tres veces, las votaciones continuan");

            return flag;
        }

        public void ShowWinner () {
            int n = Candidates.Length;

            // Sort descending by NumeroVotos
            Array.Sort<Candidato>(Candidates, new Comparison<Candidato>(
                (c1, c2) => c2.NumeroVotos.CompareTo(c1.NumeroVotos)
            ));

            // Check Draw
            if (n > 1 && Candidates[0].NumeroVotos != Candidates[1].NumeroVotos) {
                Console.WriteLine("Resultados finales");
                for (int i=0; i<n; i++)
                    Console.WriteLine($"{i+1}.- {Candidates[i].Nombre} {(Candidates[i].NumeroVotos * 100 / votes).ToString("F2")}%");
                Console.WriteLine($"El ganador es: {Candidates[0].Nombre}");
            } else
                Console.WriteLine("Se cayo el sistema :(");
        }
        
        static void Main (string[] args) {
            TestCandidato tc = new TestCandidato();
            tc.ReadCandidates();

            int terminateVotes = tc.Candidates.Length + 1;
            bool continueVotations = true;

            do {
                int opc = tc.Menu();
                if (opc == terminateVotes)
                    continueVotations = !tc.EndVotation(); 
                else if (opc > 0 && opc < terminateVotes)
                    tc.Vote(opc-1);
                else 
                    Console.WriteLine("Opción incorrecta, favor de verificarlo e intentarlo de nuevo");

            } while (continueVotations) ;

            tc.ShowWinner();
        }
    }
}
