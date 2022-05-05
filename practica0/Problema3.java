package practica0;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class Problema3 {
    public void printFilenames (List<String> filenames) {
        for (String name : filenames)
            System.out.print(name + " ");
        System.out.println();
    }

    public List<String> changeName (String[] files) {
        Map<String, Integer> repet = new TreeMap<>(); 
        List<String> newNames = new ArrayList<>();

        for (String name : files) {
            int noRepet = 0;
            String newName = name;

            // Verifica si el nombre ya existe en el mapa
            if (repet.containsKey(name)) {
                // En caso de que exista, entonces obtén el número de veces que se ha repetido y lo concatenamos al nombre 
                noRepet = repet.get(name);
                newName += "("+  noRepet +")";
            }

            // Añade el nuevo nombre a la nueva lista
            newNames.add(newName);

            // Añade el nuevo nombre al mapa con su número de repeticiones + 1
            repet.put(name, noRepet+1);
        } 

        return newNames;
    }
    
    public static void main(String[] args) {
        Problema3 p = new Problema3();
        
        String[] caso1 = {"txt", "txt", "image", "txt"};
        String[] caso2 = {"file", "file", "video", "video"};
        String[] caso3 = {"b", "b", "B", "b", "img", "b", "img"};

        p.printFilenames(p.changeName(caso1));
        p.printFilenames(p.changeName(caso2));
        p.printFilenames(p.changeName(caso3));
    }
}
