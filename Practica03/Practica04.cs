namespace Practica03 {
    class Ejercicio4 {
        private const double PI = Math.PI;

        private Tuple<double, double> areaPerimetroCirculo (double r) {
            double area, perimetro;
            area = PI * Math.Pow(r, 2);
            perimetro = 2 * PI * r;
            return Tuple.Create(area, perimetro);
        }   

        private Tuple<double, double> areaPerimetroHexagono (double l) {
            double area, perimetro, apotema; 
            apotema = Math.Pow(l, 2) - Math.Pow(l / 2, 2);
            apotema = Math.Sqrt(apotema);
            perimetro = l * 6;
            area = perimetro * apotema / 2;
            return Tuple.Create(area, perimetro);
        }   

        private Tuple<double, double> areaPerimetroRombo (double dMayor, double dMenor) {
            double area, perimetro, l;
            l = Math.Pow(dMayor / 2, 2) + Math.Pow(dMenor / 2, 2);
            l = Math.Sqrt(l);
            area = dMayor * dMenor / 2;
            perimetro = l * 4;
            return Tuple.Create(area, perimetro);
        }   
        
        public void MenuOperaciones () {
            int n;
            string figura;
            Tuple<double, double> operaciones;
            double aux1, aux2;
            do {
                Console.WriteLine("\n\nÁreas y Perimetros");
                Console.WriteLine("1.-Círculo\n2.-Hexágono\n3.-Rombo\n4.-Salir");
                Console.Write("Elige una de las opciones [1-4]: ");
                n = Convert.ToInt32(Console.ReadLine());

                figura = "";
                operaciones = null;

                switch (n) {
                    case 1:
                        figura = "círculo";
                        Console.Write("Escribe el radio del círculo: ");
                        aux1 = Convert.ToDouble(Console.ReadLine());
                        operaciones = areaPerimetroCirculo(aux1);
                        break;
                    
                    case 2:
                        figura = "hexágono";
                        Console.Write("Escribe cuánto mide uno de los lados del hexágono: ");
                        aux1 = Convert.ToDouble(Console.ReadLine());
                        operaciones = areaPerimetroHexagono(aux1);
                        break;
                    
                    case 3:
                        figura = "rombo";
                        Console.Write("Escribe cuánto mide una diagonal del rombo: ");
                        aux1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Escribe cuánto mide la otra diagonal del rombo: ");
                        aux2 = Convert.ToDouble(Console.ReadLine());
                        operaciones = areaPerimetroRombo(aux1, aux2);
                        break;

                    case 4:
                        break;

                    default: 
                        Console.WriteLine("Opción invalida, seleccione una opción correcta");
                        break;
                }

                if (operaciones != null) {
                    Console.WriteLine($"Figura: {figura}");
                    Console.WriteLine($"Área: {operaciones.Item1.ToString("F2")}");
                    Console.WriteLine($"Perimetro: {operaciones.Item2.ToString("F2")}");
                }

            } while (n != 4); 
        }
    }
}