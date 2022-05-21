using System;

namespace Practica05 {
    class TestOperacionesBancarias {
        private const int LIMIT_ACCOUNTS = 2;
        private const int LIMIT_OPERATIONS = 5;

        private readonly CuentaBancaria[] ACCOUNTS = new CuentaBancaria[LIMIT_ACCOUNTS];

        public CuentaBancaria GetAccount (int i) {
            return ACCOUNTS[i];
        }
        
        public int LimitAccounts {
            get { return LIMIT_ACCOUNTS; }
        }

        public int LimitOperations {
            get { return LIMIT_OPERATIONS; }
        }

        private bool ItsValidAmount (double amount) {
            return amount > 0;
        }

        private bool ItsPossibleWithdrawal (double amount, int account) {
            return ItsValidAmount(amount) && ACCOUNTS[account].Saldo - amount >= 0;
        }

        public void ReadNewAccounts () {
            string? nombre, nip;
            double saldo;

            for (int i=0; i<LIMIT_ACCOUNTS; i++) {
                Console.Write($"Escriba el nombre del usuario {i+1}: ");
                nombre = Console.ReadLine();
                Console.Write($"Escriba el saldo inicial del usuario {i+1}: ");
                saldo = Convert.ToDouble(Console.ReadLine());
                Console.Write($"Escriba el nip para la tarjeta del usuario {i+1}: ");
                nip = Console.ReadLine();

                ACCOUNTS[i] = new CuentaBancaria(nombre, saldo, nip);
            }
        }

        public int SelectAccount () {
            int opc;
            bool flag;
            
            do {
                Console.WriteLine("Seleccione una cuenta para realizar operaciones");
                for (int i=0; i<LIMIT_ACCOUNTS; i++)
                    Console.WriteLine($"{i+1}.- {ACCOUNTS[i].Numero}");
                Console.WriteLine($"{LIMIT_ACCOUNTS+1}.- Salir del cajero");
                Console.Write($"Seleccione una opción [1-{LIMIT_ACCOUNTS+1}]: ");
                opc = Convert.ToInt32(Console.ReadLine());
                flag = opc < 1 || opc > LIMIT_ACCOUNTS+1;  

                if (flag) 
                    Console.WriteLine("Error, seleccione una opción correcta");
            } while (flag);
            return opc;
        }

        public int SelectOperation () {
            int opc;
            bool flag;
            do {
                Console.WriteLine("Seleccione una operación");
                Console.WriteLine("1. Consultar saldo.");
                Console.WriteLine("2. Depositar efectivo.");
                Console.WriteLine("3. Retirar efectivo.");
                Console.WriteLine("4. Transferir entre cuentas.");
                Console.WriteLine("5. Cambiar NIP.");
                Console.WriteLine("6. Cerrar sesión.");
                Console.Write("Seleccione una opción [1-6]: ");
                opc = Convert.ToInt32(Console.ReadLine());
                flag = opc < 1 || opc > LIMIT_OPERATIONS+1;  

                if (flag) 
                    Console.WriteLine("Error, seleccione una opción correcta");
            } while (flag);
            return opc;
        }

        public bool Login (int account) {
            int attemps = 0;

            while (attemps < 3) {
                Console.Write("Ingrese su NIP: ");
                if (Console.ReadLine().Equals(ACCOUNTS[account].Nip))
                    break;
                attemps++;
                Console.WriteLine("NIP Incorrecto, intentelo de nuevo");
            }

            return attemps < 3;
        }
        
        static void Main (string[] args) {
            TestOperacionesBancarias tcb = new TestOperacionesBancarias();

            tcb.ReadNewAccounts();
            int opcAccount, opcOperation;
            double amount;

            do {
                opcAccount = tcb.SelectAccount();

                if (opcAccount < 1 || opcAccount > tcb.LimitAccounts)
                    Console.WriteLine("Ingresa una opción correcta");
                else {
                    opcAccount--;

                    if (!tcb.Login(opcAccount)) {
                        Console.WriteLine("Se ha equivocado 3 veces, regresando al menú principal");
                        continue;
                    }

                    do {
                        opcOperation = tcb.SelectOperation();

                        switch (opcOperation) {
                            case 1:
                                Console.WriteLine("Consulta de saldo");
                                Console.WriteLine($"Saldo: ${tcb.GetAccount(opcAccount).Saldo}");
                                break;
                            case 2:
                                Console.WriteLine("Depositar efectivo");
                                Console.Write("Ingresa la cantidad a depositar: ");
                                amount = Convert.ToDouble(Console.ReadLine());

                                if (tcb.ItsValidAmount(amount)) {
                                    tcb.GetAccount(opcAccount).Deposit(amount);
                                    Console.WriteLine("Se ha hecho el deposito satisfactoriamente");
                                } else 
                                    Console.WriteLine("Lo sentimos, monto invalido"); 
                                break;
                            case 3:
                                Console.WriteLine("Retirar efectivo");
                                Console.Write("Ingresa la cantidad a retirar: ");
                                amount = Convert.ToDouble(Console.ReadLine());

                                if (tcb.ItsPossibleWithdrawal(amount, opcAccount)) {
                                    tcb.GetAccount(opcAccount).Withdrawal(amount);
                                    Console.WriteLine("Se ha hecho el retiro satisfactoriamente");
                                } else 
                                    Console.WriteLine("Lo sentimos, no es posible retirar esa cantidad"); 
                                break;
                            case 4:
                                Console.WriteLine("Transferencia entre cuentas");
                                Console.Write("Ingresa la cantidad a transferir: ");
                                amount = Convert.ToDouble(Console.ReadLine());

                                if (tcb.ItsPossibleWithdrawal(amount, opcAccount)) {
                                    CuentaBancaria cb = opcAccount == 0 ? tcb.GetAccount(opcAccount+1) : tcb.GetAccount(opcAccount-1);
                                    tcb.GetAccount(opcAccount).Transfer(amount, cb);
                                    Console.WriteLine("Se ha hecho el retiro satisfactoriamente");
                                } else 
                                    Console.WriteLine("Lo sentimos, no es posible hacer transferencia de esa cantidad");
                                break;
                            case 5:
                                Console.WriteLine("Cambiar nip");
                                Console.Write("Ingresa la nuevo nip: ");
                                tcb.GetAccount(opcAccount).Nip = Console.ReadLine();
                                Console.WriteLine("Se ha cambiado el NIP satisfactoriamente");
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Selecciona una opción valida");
                                break;
                        }
                    } while (opcOperation != tcb.LimitOperations+1);
                }
            } while (opcAccount != tcb.LimitAccounts+1);
        }
    }
}
