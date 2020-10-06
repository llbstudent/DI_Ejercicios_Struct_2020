using System;

namespace EjerciciosStruct
{
    class Program
    {

        //Nuestra estructura Ej 1. Empleado
        public struct Empleado
        {
            public String nombre;
            public String sexo;
            public double salario;
        }


        //Nuestra estructura Ej 2. Deportistas
        //Datos deportista
        public struct DatosDeportista
        {
            public String nombre;
            public String pais;
        }

        //Atleta
        public struct Atleta
        {
            public String deporte;
            public DatosDeportista datos;
            public int numMedallas;
        }

        //Método main
        static void Main(string[] args)
        {
            //Hemos decidido hacerlo más dinámico con un menú, un bucle y un switch
            bool menuActivo = true;

            do
            {
                menuActivo = true;
                Console.WriteLine("**********************" +
                "\n1. Ejercicio Persona" +
                "\n2. Ejercicio Atleta" +
                "\n3. Ejercicio Funciones-Factorial" +
                "\nOtra tecla. SALIR");

                Console.Write("\nElija una opción: ");
                int opcionMenu = Convert.ToInt32(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:
                        //PRIMER EJERCICIO - PERSONA
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("1. Ejercicio - Persona");
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
                        break;


                    case 2:
                        //************************************************
                        //SEGUNDO EJERCICIO - ATLETA
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("2. Ejercicio - Atleta");
                        Console.Write("Inserte un número de atletas: ");
                        int numAtletas = 0;
                        bool inserccionNumAtletasCorrecta = false;

                        do
                        {
                            try
                            {
                                numAtletas = Convert.ToInt32(Console.ReadLine());
                                inserccionNumAtletasCorrecta = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Por favor inserte un número");
                            }

                        } while (!inserccionNumAtletasCorrecta);

                        //Creamos Array
                        Atleta[] atletasArr = new Atleta[numAtletas];

                        //Rellenamos los datos
                        rellenarArrayatletas(atletasArr);

                        //Saber quién es el atleta que ha ganado más medallas
                        mayorNumMedallas(atletasArr);

                        //
                        Console.ReadLine();
                        break;

                    case 3:
                        //************************************************
                        //TERCER EJERCICIO - FACTORIAL
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("3. Ejercicio - Factorial");
                        Console.Write("Introduce un número para calcular lel factorial: ");
                        int num = Convert.ToInt32(Console.ReadLine());

                        //Llamada dentro
                        Console.WriteLine("El factorial de \'" + num + "\' es \'" + calcularFactorial(num) + "\'");
                        break;

                    default:
                        menuActivo = false; 
                        Console.WriteLine("Hasta pronto");
                        break;
                }
            } while (menuActivo);
            Console.ReadLine();
        }

        //==================================
        // MÉTODOS DE LA CLASE
        //==================================

        //Método
        public static int calcularFactorial(int num)
        {
            int numLim = num;
            for (int i = 1; i < numLim; i++)
            {
                num *= i;
            }

            return num;
        }



        /// <summary>
        /// Métodoq ue nos hace conocer quién es el atleta que ha ganado mayor número de medallas
        /// </summary>
        /// <param name="atletas"></param>
        private static void mayorNumMedallas(Atleta[] atletas)
        {
            //var de atleta que nos servirá para guardar el resultado
            //Me obliga ainicializarlo
            Atleta aux;
            aux.numMedallas = 0;
            aux.datos.nombre = "";

            for (int i = 0; i < atletas.Length; i++)
            {
                if (i == 0)
                    aux = atletas[i];

                if(aux.numMedallas < atletas[i].numMedallas)
                    aux = atletas[i];
            }

            Console.WriteLine("El atleta \'" + aux.datos.nombre + "\', ha ganado " + aux.numMedallas);
        }


        /// <summary>
        /// Método que nos rellenará el Array de 'Atletas'
        /// </summary>
        /// <param name="atletasArr"></param>
        private static void rellenarArrayatletas(Atleta[] atletas)
        {
            for (int i=0; i < atletas.Length; i++)
            {
                bool inserccionDatosEmpleadoCorrecta = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n****************\nNúm-Atleta-" + (i + 1));
                        Console.Write("\nDeporte/Modalidad: ");
                        atletas[i].deporte = Console.ReadLine();

                        Console.Write("\nNúmero de medallas: ");
                        atletas[i].numMedallas = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nNombre del atleta: ");
                        atletas[i].datos.nombre = Console.ReadLine();
                        Console.Write("\nPaís: ");
                        atletas[i].datos.pais = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("¡INSERTE CORRECTAMENTE LOS DATOS!");
                    }

                } while (!inserccionDatosEmpleadoCorrecta);
            }
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
                        Console.WriteLine("\n****************\nNúm-Empleado-" + (i + 1));
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
