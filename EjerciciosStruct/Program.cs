using System;

namespace EjerciciosStruct
{
    class Program
    {

        //Nuestra estructura
        public struct Empleado
        {
            public String nombre;
            public String sexo;
            public double salario;
        }

        //Método main
        static void Main(string[] args)
        {
            Console.Write("Inserte cuantos empleados tiene su empresa: ");
            int numEmpleado = 0;
            bool inserccionNumEmpleadoCorrecta = false;

            do
            {
                try
                {
                    numEmpleado = Convert.ToInt32(Console.ReadLine());
                    inserccionNumEmpleadoCorrecta = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Por favor inserte un número");
                }
                
            } while (!inserccionNumEmpleadoCorrecta);
            
            Empleado[] empleadosListado = new Empleado[numEmpleado];
            //Rellenamos los datos
            rellenarEmpleados(empleadosListado);

            //Imprimimos
            Console.WriteLine("\n*****************************");
            Console.WriteLine("Datos de nuestros empleados");
            imprimirDatosEmpleados(empleadosListado);

            //Empleado con Mayor y Menor Salario
            Console.WriteLine("\n*****************************");
            Console.WriteLine("Empleado con Mayor y Menor salario");
            salarioMayorMEnorEmpleado(empleadosListado);

            //
            Console.ReadLine();
        }

        /// <summary>
        /// Nos imprimirá cuales son los empleados con mayor y menor salario
        /// </summary>
        /// <param name="empleadosListado"></param>
        private static void salarioMayorMEnorEmpleado(Empleado[] empleadosListado)
        {

            //Primero Ordenamos de menor a mayor los salarios
            for (int i=0; i < empleadosListado.Length -1; i++)
            {
                bool cambiosPosicion = false;
                do
                {
                    cambiosPosicion = false;
                    double aux = 0;
                    if (empleadosListado[i].salario > empleadosListado[i + 1].salario)
                    {
                        aux = empleadosListado[i].salario;
                        empleadosListado[i].salario = empleadosListado[i + 1].salario;
                        empleadosListado[i + 1].salario = aux;
                    }

                } while (cambiosPosicion);   
            }

            //Imprmimos los datos
            Console.WriteLine("El empleado con menor sueldo es " + empleadosListado[0].nombre + ", con un salario de \'" + empleadosListado[0].salario + "\'-Euros");
            Console.WriteLine("El empleado con mayor sueldo es " + empleadosListado[empleadosListado.Length-1].nombre + ", con un salario de \'" + empleadosListado[empleadosListado.Length - 1].salario + "\'-Euros");
        }


        /// <summary>
        /// Nos imprimirá con el formato deseado todos los datos de los empleados
        /// </summary>
        /// <param name="empleadosListado"></param>
        private static void imprimirDatosEmpleados(Empleado[] empleadosListado)
        {
            for (int i = 0; i < empleadosListado.Length; i++)
            {
                Console.WriteLine("\nNombre [" +(i+1) + "] = " +empleadosListado[i].nombre + "\n" +
                    "Sexo [" +(i+1)+ "] = " + empleadosListado[i].sexo + "\n" +
                    "Salario [" +(i+1)+ "] = " + empleadosListado[i].salario);
            }
        }

        /// <summary>
        /// Método que nos facilitará para rellenar a mano los datos de los empleados
        /// </summary>
        /// <param name="empleadosListado"></param>
        private static void rellenarEmpleados(Empleado[] empleadosListado)
        {
            //For para recorrer todas los elementos e insertar los empleados
            for (int i=0; i < empleadosListado.Length; i++)
            {
                bool inserccionDatosEmpleadoCorrecta = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\nNúm-Empleado-" + (i + 1));
                        Console.Write("\nNombre: ");
                        empleadosListado[i].nombre = Console.ReadLine();

                        Console.Write("\nSexo: ");
                        empleadosListado[i].sexo = Console.ReadLine();

                        Console.Write("\nSalario: ");
                        empleadosListado[i].salario = Convert.ToDouble(Console.ReadLine());
                        inserccionDatosEmpleadoCorrecta = true;

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("¡INSERTE CORRECTAMENTE LOS DATOS!");
                    }

                } while (!inserccionDatosEmpleadoCorrecta) ;
            }
        }
    }
}
