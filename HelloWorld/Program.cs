// System es para entrada y salida de datos
using System;

// Para serializar un objeto a json
using Newtonsoft.Json;

namespace HelloWorld {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine("Hello, World!");

            // Serialización del arreglo 
            Console.WriteLine(JsonConvert.SerializeObject(args));

            // Lectura en consola
            Console.Write("¿Cuál es tu nombre?: ");

            /*
            Definición de variables
                Asignarle el valor escrito en la consola
                var es como un tipo de dato comodín para asignarle cualquier tipo de dato
                Tipos de dato en C#: https://www.geeksforgeeks.org/c-sharp-data-types/
            */
            var name = Console.ReadLine();

            // Declaración de una constante
            const int num1 = 1; 
            
            // Obtener la fecha actual
            var currentDate = DateTime.Now;

            /*            
            Uso de template strings 
                Environment.NewLine ayuda a colocar un salto de línea, también funciona \n
                currentDate:t Imprime el tiempo de la variable de DateTime
            */
            Console.WriteLine($"{Environment.NewLine}Hola {name} - {currentDate:t}");

            /*
            Nota: El casteo y la promoción de tipos de datos es automático, 
            no es necesario aplicar un método especial ni nada por el estilo
            */
            
            // Leer el tipo de dato entero en consola
            Console.Write("\nIngrese un número: ");
            int num = Convert.ToInt32(Console.ReadLine());
        }
    }
}
