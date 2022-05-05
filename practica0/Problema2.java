package practica0;

public class Problema2 {
    private final int MAXIMO_EN_CAJA = 6;
    
    public String calculaCajasySobras (int paquetes) {
        String answ = "Cajas: ";
        int cajas = paquetes/MAXIMO_EN_CAJA;
        int sobrantes = paquetes % MAXIMO_EN_CAJA; 

        answ += ""+cajas;
        answ += sobrantes > 0 ? (" - Paquetes sobrantes: " + (sobrantes)) : "";

        return answ;
    }

    public static void main(String[] args) {
        Problema2 p = new Problema2();

        System.out.println(p.calculaCajasySobras(1));
        System.out.println(p.calculaCajasySobras(6));
        System.out.println(p.calculaCajasySobras(15));
        System.out.println(p.calculaCajasySobras(18));
    }
}
