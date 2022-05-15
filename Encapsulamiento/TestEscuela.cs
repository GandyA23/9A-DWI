using System;

namespace Encapsulamiento {
    class TestEscuela {
        static void Main (string[] args) {
            Carrera Tic = new Carrera();
            
            // Setear los datos en una instancia de clase
            Tic.Id = 1;
            Tic.Nombre = "TIC";

            // Obtener los datos
            Console.WriteLine($"Id: {Tic.Id} - Nombre: {Tic.Nombre}");

            Alumno Jose = new Alumno();

            // Setear los datos en una instancia de clase
            Jose.Id = 1;
            Jose.Nombre = "Jose";
            Jose.Carrera = Tic;

            // Obtener los datos
            Console.WriteLine($"Id: {Jose.Id} - Nombre: {Jose.Nombre} - Carrera: {Jose.Carrera.Nombre}");

        }
    }
}
