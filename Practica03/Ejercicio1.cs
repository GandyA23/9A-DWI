namespace Practica03 {
    class Ejercicio1 {
        public string ConvertToLower () {
            Console.Write("Ingrese un string: ");
            string str = Console.ReadLine();

            if (str.Length > 10)
                str = str.ToLower();

            return $"str: {str}";
        }
    }
}