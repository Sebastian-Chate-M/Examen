using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] precio = new double[max];
        static double[] cantidad = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("Sistemas de Precios y cantidades");
            Console.WriteLine("*****************************");
        }
        static public void Registrar_usuario()
        {
            Console.WriteLine("Registro de usuario nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a  la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double precio;
            double cantidad;
            while (true)
            {
                Console.Write("Ingresar precio: ");
                precio = double.Parse(Console.ReadLine());
                if (precio >= 0 && precio <= 100000)
                {
                    Console.WriteLine("Ingresar cantidad: ");
                    cantidad = double.Parse(Console.ReadLine());
                    if (cantidad >= 0 && cantidad <= 100000)
                    {
                        Console.WriteLine("Guardado correctamente...");   
                    }
                    break;
                    
                }
                Console.WriteLine("Error: La monto debe ser [0-100000]:");
            }


        }
        static public void mostrar()
        {
            Console.WriteLine("*******Listado de usuarios*********");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i] + "-´Precio:" + precio[i] + "-Cantidad:" + cantidad[i]);
            }
        }
        static public void buscar_usuario()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("*****BUSCAR USUARIO********");
            Console.WriteLine("************************************");
            if (contador == 0)
            {
                Console.WriteLine("No hay Usuario registrados");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("usuario encontrado: ");
                    Console.WriteLine(nombres[i] + "tiene " + precio[i] + "su cantidad es:" + cantidad[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Usuario no encontrado...");
        }
        static public void modificar_precio_y_cantidad()
        {
            Console.WriteLine("*******MODIFICAR PRECIO Y CANTIDAD***********");
            if (contador == 0)
            {
                Console.WriteLine("No hay usuario registrados");
                return;
            }
            Console.Write("Ingresar nombre del usuario: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + "tiene " + precio[i] + "su cantidad es:" + cantidad[i]);
                    double nuevo_precio;
                    double nueva_cantidad;
                    while (true)
                    {
                        Console.Write("Ingresar el nuevo precio: ");
                        nuevo_precio = double.Parse(Console.ReadLine());
                        Console.Write("Ingresar la nueva cantidad: ");
                        nueva_cantidad = double.Parse(Console.ReadLine());
                        if (nuevo_precio >= 0 && nuevo_precio <= 100000)
                            if (nueva_cantidad >= 0 && nueva_cantidad <= 100000)
                        {
                            precio[i] = nuevo_precio;
                                cantidad[i] = nueva_cantidad;
                            Console.WriteLine("precio y cantidad modificados correctamente");
                            return;
                        }
                        Console.WriteLine("fuera de rango [0-100000]");
                    }
                }
                Console.WriteLine("Usuario no encontrado...");
            }

        }
        static void Main(string[] args)
        {
            int opcion;
            opcion = 5;
            Titulo();
            while (opcion !=0)
            {
                Console.WriteLine("1.-Registrar usuario");
                Console.WriteLine("2.-Mostrar usuarios");
                Console.WriteLine("3.-Buscar usuario");
                Console.WriteLine("4.-Modificar precio y cantidad");
                Console.WriteLine("5.-Salir");
                Console.Write("Ingrese una opcion: ");
                switch (opcion)
                {
                    case 1:
                        Registrar_usuario();
                        break;
                    case 2:
                        mostrar();
                        break;
                    case 3:
                        buscar_usuario();
                        break;
                    case 4:
                        modificar_precio_y_cantidad();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opcion invalidada, intente de nuevo...");
                        break;


                }
            }
        }
    }
}

