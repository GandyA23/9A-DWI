namespace Practica03 {
    class Ejercicio3 {
        const double SALARIO_MINIMO = 120.0;
        const double REGALO_HIJOS = 150;

        readonly int[] ANTIGUEDADES = {24, 36, 60};
        readonly List<Tuple<int, int>> SALARIOS_MINIMOS = new List<Tuple<int, int>> {
            Tuple.Create(5, 8), 
            Tuple.Create(9, 12),
            Tuple.Create(14, 17)
        };

        public void Salarios () {
            Console.Write("Escribe el departamento del empleado: ");
            char departamento = Convert.ToChar(Console.ReadLine());

            Console.Write("Escribe la antiguedad del empleado: ");
            int antiguedad = Convert.ToInt32(Console.ReadLine());

            Console.Write("Escribe la cantidad de hijos del empleado: ");
            int noHijos = Convert.ToInt32(Console.ReadLine());

            double bonoHijos = noHijos * REGALO_HIJOS;
            int pos = Char.ToUpper(departamento) - 'A';
            int salariosMinimos = antiguedad < ANTIGUEDADES[pos] ? SALARIOS_MINIMOS[pos].Item1 : SALARIOS_MINIMOS[pos].Item2; 

            if (noHijos > 0)
                Console.WriteLine($"Bono por número de hijos: ${bonoHijos}");
            
            Console.WriteLine($"Salarios Mínimos: {salariosMinimos} * ${SALARIO_MINIMO}");
            Console.WriteLine($"Total: ${salariosMinimos * SALARIO_MINIMO + bonoHijos}");
        }
    }
}