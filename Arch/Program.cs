using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arch
{
    class Program
    {
        static void Main(string[] args)
        
        {
            //Cambiar por ruta relativa para evitar errores
            string path = @"E:\Users\Daniel\Documents\Visual Studio 2010\Projects\Final\Arch\bin\Debug\miarchivo.txt";
            string[,] Datos = new string[6, 5];
            Proceso ob = new Proceso(path);
            string res = "";
            int op = 0;
            do
            {
                try
                {
                    
                        Console.WriteLine("1.Agregar Registro" + Environment.NewLine + "2.Mostrar indformacion en el arhivo" + Environment.NewLine + "3.Consulta" + Environment.NewLine +
                        "4.Eliminar Registro" + Environment.NewLine + "5.Editar registro" + Environment.NewLine + "6.Salir");
                        op = Convert.ToInt32(Console.ReadLine());
                        switch (op)
                        {
                            case 1:
                                string line;

                                ob.NC = ob.Validar("Ingrese número de control: ");
                                Console.Write("Ingrese Nombre: ");
                                ob.Nm = Console.ReadLine();
                                Console.Write("Ingrese su carrera: ");
                                ob.MY = Console.ReadLine();
                                Console.Write("Ingrese su direccion: ");
                                ob.AD = Console.ReadLine();
                                ob.PN = ob.Validar("Ingrese su numero telefonico: ");
                                Console.Write("Ingrese su Email: ");
                                ob.EM = Console.ReadLine();
                                line = ob.NC.ToString() + "; " + ob.Nm + "; " + ob.MY + "; " + ob.AD + "; " + ob.PN.ToString() + "; " + ob.EM;
                                ob.EscribirEnArchivo(line, path);

                                break;
                            case 2:

                                ob.LeerArchivo(path);
                                break;

                            case 3:
                                ob.Consulta(path);
                                break;
                            case 4:
                                ob.Eliminar(path);
                                break;
                            case 5:
                                ob.Editar(path);
                                break;
                            case 6:
                                Console.WriteLine("Saliendo de la aplicacón...");
                                
                                break;
                            default:

                                Console.WriteLine("Opción inexistente");
                                break;
                        }

                   

                }
                catch(FormatException e)
                {
                    Console.WriteLine("Entrada invalida: {0}", e.Message);
                }
                
                 } while (op != 6);


        }
    }
}
