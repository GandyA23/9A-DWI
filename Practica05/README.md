## Planteamiento del problema

Se requiere de un sistema que simule el funcionamiento de un cajero automático. 

## Desarrollo de la actividad individual

Crea la clase CuentaBancaria con los siguientes atributos y sus respectivos métodos get y set:

 - NombreTitular, **string**
 - SaldoCuenta, **double**
 - NumeroCuenta, **string**
 - Nip, **string**

Genera para la clase CuentaBancaria, un método constructor que permita inicializar el nombre del titular, saldo y NIP de su cuenta. Considera que a través del método constructor se realizará lo siguiente:

 - Establecer un nombre para el titular de la cuenta corriente.
 - Abrir su cuenta con un saldo inicial.
 - Establecer un NIP para la cuenta como medio de autenticación.
 - Asignar un número de cuenta aleatorio de 8 dígitos; éste no lo define el usuario sino que lo asigna el banco automáticamente.

Escribe los siguientes métodos para la clase CuentaBancaria:
 - **depositar()** //Permite aumentar al saldo de la cuenta el monto ingresado.
 - **retirar()** //Admite retirar de la cuenta el monto solicitado.
 - **transferir()** //Permite transferir entre las dos cuentas el monto indicado; una de ellas disminuye su saldo (quien envía) y la otra, lo aumenta (quien recibe).

Nota: Toma en cuenta que los depósitos, retiros y transferencias deben ser mayores a $0.00 pesos. Asimismo, validar que las cuentas bancarias tengan el saldo suficiente para realizar las transacciones solicitadas. NO DEBE HABER SALDOS NEGATIVOS.

Genera la clase TestOperacionesBancarias (main) y solicita por teclado los datos de 2 cuentahabientes del banco. Toma en cuenta que por cada uno deberás hacer una instancia de la clase CuentaBancaria a través del método constructor que se creo anteriormente. 

 - Muestra enseguida, el siguiente menú para que el usuario seleccione la cuenta bancaria desde la que se harán las transacciones:
 - Número de cuenta "XXXX XXXX" 
 - Número de cuenta "XXXX XXXX"
 - Salir del cajero

Nota: Mostrar en lugar de "XXXX XXXX" el número de cuenta que se asignó para cada cuentahabiente.

Considera que cuando el usuario elija una de las cuentas mostradas se deberá validar su identidad mediante el NIP. Para ello, se tendrá un máximo de 3 intentos, de lo contrario se tendrá que mostrar de nueva cuenta el menú para que el usuario selecciones otra opción. Si la autenticación es correcta se saludará al usuario por su nombre y se le mostrará el siguiente submenú:
 - Consultar saldo.
 - Depositar efectivo.
 - Retirar efectivo.
 - Transferir entre cuentas.
 - Cambiar NIP.
 - Cerrar sesión.

Nota: Ten presente que cuando el usuario seleccione la opción de "Transferir entre cuentas" se deberá descontar de la cuenta actual el monto indicado para sumárselo a la otra cuenta bancaria. 
