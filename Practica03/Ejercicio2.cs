namespace Practica03 {
    class Ejercicio2 {
        readonly double[] PRECIOS = {150.0, 155.0, 145.0, 168.0, 159.0};
        const double SERVICIO_DOMICILIO = 45.0;
        const double CARGO_TARJETA = 0.03;
        public void Menu () {
            Console.Write("Elija el sabor de su pizza:\n1.-Hawaiana:\n2.-Pepperoni:\n3.-Quesos:\n4.-Margarita:\n5.-Salami\nSeleccione una opción [1-5]: ");
            int opcPizza = Convert.ToInt32(Console.ReadLine());

            Console.Write("¿Su pago es con tarjeta? [1.-SI|2.-NO]: ");
            int opcPago = Convert.ToInt32(Console.ReadLine());

            double precioPizza = PRECIOS[opcPizza-1];
            double cargoAdicional = opcPago == 1 ? precioPizza * CARGO_TARJETA : 0.0;

            
            Console.WriteLine($"\nPizza: ${precioPizza}");
            if (cargoAdicional > 0)
                Console.WriteLine($"Cargo adicional por pago tarjeta: ${cargoAdicional}");
            Console.WriteLine($"Servicio a domicilio: ${SERVICIO_DOMICILIO}");
            Console.WriteLine($"El cliente debe de pagar ${(precioPizza+cargoAdicional+SERVICIO_DOMICILIO)}");
        }
    }
}