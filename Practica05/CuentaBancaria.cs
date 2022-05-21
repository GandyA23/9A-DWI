namespace Practica05 {
    class CuentaBancaria {
        // Internal constants
        private const int MIN_VALUE = 1111;
        private const int MAX_VALUE = 9999;

        // Constructor
        public CuentaBancaria (string nombre, double saldo, string nip) {
            NombreTitular = nombre;
            Saldo = saldo;
            Nip = nip;
            Numero = GetRandomAccountNumber();
        }

        // Getters and setters
        public string NombreTitular {
            get; internal set;
        }

        public double Saldo {
            get; internal set;
        }
        
        public string Numero {
            get; internal set;
        }
        
        public string Nip {
            get; internal set;
        }

        // Methods
        private string GetRandomAccountNumber () {
            Random rand = new Random();
            return Convert.ToString(rand.Next(MIN_VALUE, MAX_VALUE)) + " " + Convert.ToString(rand.Next(MIN_VALUE, MAX_VALUE));
        }

        public void Deposit (double mount) {
            Saldo += mount;
        }

        public void Withdrawal (double amount) {
            Saldo -= amount;
        }

        public void Transfer (double amount, CuentaBancaria cuentaBancaria) {
            Withdrawal(amount);
            cuentaBancaria.Deposit(amount);
        }

        private void ChangeNip (string nip) {
            Nip = nip;
        }
    }
}
