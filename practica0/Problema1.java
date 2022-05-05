package practica0;

public class Problema1 {
    public Long sumaCantidadLista (String lista)  {
        Long cantidad = 0L;

        // Divide la cadena en un arreglo donde solo existan los números
        String[] nums = lista.split("[^0-9]");

        for(String n : nums) {
            // Verifica que la posición que recorre no se encuentra vacía
            if (!n.isEmpty())
                // Realiza el parseo a Long y lo añade a la cantidad total
                cantidad += Long.parseLong(n.trim());
        }

        return cantidad;
    }
    
    public static void main(String[] args) {
        Problema1 p = new Problema1();
        
        System.out.println(p.sumaCantidadLista("32 lápices, 10 plumas, 7 cuadernos, 1 goma"));
        System.out.println(p.sumaCantidadLista("carpetas 8, plumones 10, 7 cuadernos, 1 goma"));
        System.out.println(p.sumaCantidadLista("Gomas, 9 sacapuntas, pluma2"));
    }
}
