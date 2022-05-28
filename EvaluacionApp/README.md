# Desarrollo de la actividad individual

 - Crea una aplicación de consola .NET llamada EvaluacionApp.

 - Crea la clase Trabajador con los siguientes atributos:
    - Nombre: string
    - Edad: int
    - Estatura: double
    - Sexo: char
    - EstadoCivil (bool) true  = casado, false = soltero
    <br><br>
 
 - Genera para la clase anterior, el método constructor que permita inicializar todos sus atributos. 

 - Escribe los métodos necesarios en la clase Trabajador para obtener y modificar el valor de sus atributos (get y set).

 - Genera la clase TestTrabajador (main) y solicita por teclado los datos de la Trabjador para crear un nuevo objeto por medio del constructor antes creado.
    Nota: Al usuario se le preguntará su estado civil con un pequeño menú: (C.- Casado o S.- Soltero)
    <br>

 - Muestra enseguida el siguiente menú:
    - 1. Mostrar los Datos
    - 2. Cambiar Datos
    - 3. Salir
    <br><br>

 - Considera que cuando el usuario selecciona la opción "Cambiar datos" se debe preguntar ¿Qué dato se desea modificar?. Por lo tanto, se debería mostrar el siguiente submenú:
    - 1. Modificar nombre
    - 2. Modificar edad
    - 3. Modificar estatura
    - 4. Modificar sexo
    - 5. Modificar estado civil (C.- Casado o S.- Soltero)
    - 6. Regresar al menú principal

    <br>

    **Nota:** Antes de cambiar los datos se hará la pregunta de confirmación ¿Está seguro de realizar el cambio? Asimismo, valida que solo se permita la entrada de los valores permitidos para cada menú.
