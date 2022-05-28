using System;

namespace EvaluacionApp {
    class TestTrabajador {
        private Trabajador t = null;

        private bool ReadCivilStatus () {
            string res;
            bool flag;
            
            do {
                Console.Write("Escribe el estado cívil del trabajador [C: Casado | S: Soltero]: ");
                res = Console.ReadLine();
                res = res.ToUpper();
                flag = !res.Equals("C") && !res.Equals("S"); 

                if (flag)
                    Console.WriteLine("Seleccione una opción válida");

            } while (flag);

            return res.Equals("C");
        }

        private char ReadSex () {
            string res;
            bool flag;
            
            do {
                Console.Write("Escribe el sexo del trabajador [M: Masculino | F: Femenino]: ");
                res = Console.ReadLine();
                res = res.ToUpper();

                flag = !res.Equals("M") && !res.Equals("F"); 

                if (flag)
                    Console.WriteLine("Seleccione una opción válida");

            } while (flag);

            return  Convert.ToChar(res);
        }


        private bool Confirm () {
            string res;
            bool flag;
            
            do {
                Console.Write("¿Esta seguro de continuar? [1.-SI|2.-NO]: ");
                res = Console.ReadLine();
                flag = !res.Equals("1") && !res.Equals("2"); 

                if (flag)
                    Console.WriteLine("Seleccione una opción válida");

            } while (flag);

            return res.Equals("1");
        }

        public void ReadData () {
            string nombre;
            int edad;
            double estatura;
            char sexo;
            bool estadoCivil;
            do {
                Console.Write("Escribe el nombre del trabajador: ");
                nombre = Console.ReadLine();

                Console.Write("Escribe la edad del trabajador: ");
                edad = Convert.ToInt32(Console.ReadLine());
                
                Console.Write("Escribe la estatura del trabajador: ");
                estatura = Convert.ToDouble(Console.ReadLine());

                sexo = ReadSex();

                estadoCivil = ReadCivilStatus();
            } while (!Confirm());

            t = new Trabajador(nombre, edad, estatura, sexo, estadoCivil);
        }

        private void MenuEditar () {
            string opc = "";
            do {
                Console.WriteLine("MENU EDITAR");
                Console.WriteLine("1.- Modificar nombre\n2.- Modificar edad\n3.- Modificar estatura\n4.- Modificar sexo\n5.- Modificar estado civil (C.- Casado o S.- Soltero)\n6.- Regresar al menú principal");
                Console.Write("Escoge una opción: ");

                opc = Console.ReadLine();

                switch (opc) {
                    case "1":
                        Console.WriteLine("Editar el nombre");
                        
                        Console.Write("Ingrese el nuevo nombre: ");
                        string nombre = Console.ReadLine();
                        
                        if (Confirm()) {
                            t.Nombre = nombre;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Editar la edad");

                        Console.Write("Ingrese la nueva edad: ");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        
                        if (Confirm()) {
                            t.Edad = edad;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Editar la estatura");

                        Console.Write("Ingrese la nueva estatura: ");
                        double estatura = Convert.ToDouble(Console.ReadLine());
                        
                        if (Confirm()) {
                            t.Estatura = estatura;
                        }
                        break;

                    case "4":
                        Console.WriteLine("Editar el sexo");

                        char sexo = ReadSex();
                        
                        if (Confirm()) {
                            t.Sexo = sexo;
                        }
                        break;

                    case "5":
                        Console.WriteLine("Editar el estado cívil");

                        Console.Write("Ingrese el nuevo estado cívil [C: Casado | S: Soltero]: ");
                        bool estadoCivil = ReadCivilStatus();
                        
                        if (Confirm()) {
                            t.EstadoCivil = estadoCivil;
                        }
                        break;

                    case "6":
                        break; 

                    default: 
                        Console.WriteLine("Seleccione una opción válida");
                        break;
                }

            } while (!opc.Equals("6"));
        }

        public void Menu () {
            string opc = "";
            do {
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("1. Mostrar los Datos\n2. Cambiar Datos\n3. Salir");
                Console.Write("Escoge una opción: ");

                opc = Console.ReadLine();

                switch (opc) {
                    case "1":
                        Console.WriteLine("MOSTRAR LOS DATOS");
                        Console.WriteLine($"Nombre: {t.Nombre}\nEdad: {t.Edad}\nEstatura: {t.Estatura}\nSexo: {t.Sexo}");
                        Console.WriteLine("Estado cívil: " + (t.EstadoCivil ? "Casado" : "Soltero"));
                        break;

                    case "2":
                        MenuEditar();
                        break;

                    case "3":
                        break;

                    default: 
                        Console.WriteLine("Seleccione una opción válida");
                        break;
                }

            } while (!opc.Equals("3"));
        }

        static void Main () {
            TestTrabajador tt = new TestTrabajador();

            tt.ReadData();
            tt.Menu();
        }
    }
}