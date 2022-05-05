# Práctica 0. Desarrollando la lógica

## Restricción para resolver los problemas
Todos los problemas deben de ser resueltos con el lenguaje Java.


## Problema 1

Desarrolla un programa en Java que dada una cadena de caracteres determine la suma total de productos comprados en la papelería.

## Casos
| Entrada | Salida |
| ------- | :------: |
| ``` 32 lápices, 10 plumas, 7 cuadernos, 1 goma ``` | ``` 50 ``` | 
| ``` carpetas 8, plumones 10, 3marca textos ``` | ``` 21 ``` | 
| ``` Gomas, 9 sacapuntas, plumas2 ``` | ``` 11 ``` | 

## Problema 2

La panificadora "Malvisco" solicita diariamente cajas de cartón a una empresa para empacar los paquetes de galletas de chocolate que produce. Sin embargo, no siempre solicita correctamente el número de cajas porque sobran o faltan cartones.

Considerando que en una caja caben 6 paquetes de galletas, desarrolla un programa en Java que permita conocer la cantidad de cajas necesarias para embalar "x" cifra de paquetes y si es el caso mostrar los sobrantes, es decir, aquellos que no pudieron ser empaquetados. El número de cajas debe ser un entero.

## Casos
| Entrada | Salida |
| :-------: | ------ |
| ``` 1 ``` | ``` Cajas: 0 - Paquetes sobrantes: 1 ```| 
| ``` 6 ``` | ``` Cajas: 1 ```| 
| ``` 15 ``` | ``` Cajas: 2 - Paquetes sobrantes: 3 ```| 
| ``` 18 ``` | ``` Cajas 3 ```| 

## Problema 3

Dada una matriz de cadenas con nombres de archivos verificar que éstos no se repitan. En caso de que existir nombres duplicados se deberán renombrar agregando (x) al final, donde x es el entero más pequeño que aún no ha sido utilizado.

## Casos
| Entrada | Salida |
| ------- | ------ |
| ``` ["txt", "txt", "image", "txt"] ``` | ``` ["txt", "txt(1)", "image", "text(2)"] ```  | 
| ``` ["file", "file", "video", "video"] ``` | ``` ["file", "file(1)", "video", "video(1)"] ``` | 
| ``` ["b", "b", "b", "b", "img", "b", "img"] ``` | ``` ["b", "b(1)", "b(2)", "b(3)", "img", "b(4)", "img(1)"] ``` | 