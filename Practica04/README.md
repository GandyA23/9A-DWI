# Práctica 04

## Problema 

Se requiere de un sistema que permita registrar los votos emitidos para cada uno de los tres candidatos a presidente municipal de Emiliano Zapata.  

### Desarrollo de la actividad individual

 - Crea la clase Candidato con los siguientes atributos e interfaces públicas (get y set):
    - Nombre
    - Número de votos

 - Genera para la clase Candidato, un método constructor que permita inicializar el atributo nombre.

 - Genera la clase TestCandidatos (Main) y solicita por teclado el nombre de los 3 candidatos a participar en la contienda. Toma en cuenta que por cada competidor deberás hacer una instancia de la clase Candidato a través del constructor que se creó previamente. 

 -  Muestra enseguida este menú a los usuarios:

    - Votar por candidato "nombre1" 
    - Votar por candidato "nombre2"
    - Votar por candidato "nombre3"
    - Cerrar casilla

 - <b>Nota:</b> Recuerda que la votación sigue abierta siempre y cuando el usuario con permisos de "Representante de casilla" no la cierre.

 - Desarrolla un mecanismo de seguridad de tal manera que solo el representante de casilla que conoce la contraseña pueda terminar la votación. Para ello deberás declarar la contraseña en una constante y solicitarla cuando se intente cerrar la casilla. Considera que se tiene un máximo de tres intentos para ingresar la clave correcta, de lo contrario se deberá mostrar de nueva cuenta el menú para que la jornada electoral continúe. 

 - Imprime al termino de la elección, el ganador y la cantidad de votos obtenidos por cada candidato junto con su respectivo porcentaje. En caso de un empate muestra el mensaje "Se cayó el sistema".
