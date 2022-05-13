using System;

namespace Practica01 {
    class Program {
        const double DESCUENTO = 0.1;
        const double PRECIO = 15.9;
        const int CANTIDAD = 5;
        static void Main (string[] args) {
            Console.Write("Inserte la cantidad de productos que compró: ");
            int cantidadProducto = Convert.ToInt32(Console.ReadLine());

            double total = 0.0;
            int noPluma = cantidadProducto / CANTIDAD;

            total += noPluma * CANTIDAD * PRECIO;

            double descuentoTotal = total * DESCUENTO;
            total += (cantidadProducto - (noPluma * CANTIDAD)) * PRECIO;

            Console.WriteLine($"Se han regalado {noPluma} plumas");
            Console.WriteLine($"Total: ${total} - Descuento (10% por cada 5 productos): ${descuentoTotal} - Total Neto: ${(total-descuentoTotal)}");
        } 
    }
}
