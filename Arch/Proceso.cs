using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Arch
{
    class Proceso
    {
        private int nc;
        private string Name;
        private string Mayor;
        private string Adress;
        private int PhoneNumber;
        private string Email;
        public string EM { get { return Email; } set { Email = value; } }
        public int PN { get { return PhoneNumber; } set { PhoneNumber = value; } }
        public string AD { get { return Adress; } set { Adress = value; } }
        public string MY { get { return Mayor; } set { Mayor = value; } }
        public string Nm { get { return Name; } set { Name = value; } }
        public int NC { get { return nc; } set { nc = value; } }

        public Proceso(string ruta)
        {
            try {
                using (StreamWriter Crear = File.AppendText(ruta))
                {
                    Crear.Close();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        public void AgregarRegistro(string linea, string ruta)
        {


            EscribirEnArchivo(linea, ruta);


        }
        public void LeerArchivo(string ruta)
        {
            try
            {
                string line = "";
                using (StreamReader file = new StreamReader(ruta))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }




                }
            }
            catch (Exception)
            {

                Console.WriteLine("No se puede leer el archivo");
            }

        }
        public void EscribirEnArchivo(string Datos, string ruta)
        {


            using (StreamWriter file = new StreamWriter(ruta, true))
            {
                file.WriteLine(Datos);

                file.Close();
            }
        }



        public void Consulta(string path)
        {
            
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            StreamReader Lectura;
            string Busqueda, Line;
            Busqueda = " ";
            Line = " ";
            bool ValorBuscado;
            ValorBuscado = false;
            string[] tabla = new string[6];
            char[] indicador = { ';' };
            try
            {

                using (Lectura = File.OpenText(path))
                {
                    Console.WriteLine("Ingrese el numero de control a consultar");
                    Busqueda = Console.ReadLine();
                    Line = Lectura.ReadLine();
                    while (Line != null && ValorBuscado == false)
                    {
                        tabla = Line.Split(indicador);
                        if (tabla[0].Trim().Equals(Busqueda))
                        {
                            Console.WriteLine("Número de control: {0}", tabla[0].Trim());
                            Console.WriteLine("Nombre: {0}", tabla[1].Trim());
                            Console.WriteLine("Carrea: {0}", tabla[2].Trim());
                            Console.WriteLine("Direccion: {0}", tabla[3].Trim());
                            Console.WriteLine("Número Telefonico: {0}", tabla[4].Trim());
                            Console.WriteLine("Email: {0}", tabla[5].Trim());
                            ValorBuscado = true;

                        }
                        else
                        {
                            Line = Lectura.ReadLine();
                        }
                    }
                    if (ValorBuscado == false)
                    {
                        Console.WriteLine("EL alumno con número de control {0} no está en la base ", Busqueda);
                    }
                    Lectura.Close();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("No se puede leer el archivo");
            }
        }
        public void Eliminar(string path)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            StreamReader Lectura;
            StreamWriter Tmp;
            string Busqueda, Line, res;
            Busqueda = " ";
            Line = " ";
            res = " ";
            bool ValorBuscado;
            ValorBuscado = false;
            string[] tabla = new string[6];
            char[] indicador = { ';' };
            try
            {

                using (Lectura = File.OpenText(path))
                {
                    Tmp = File.CreateText("Tmp.txt");
                    Console.WriteLine("Ingrese el numero de control a eliminar");
                    Busqueda = Console.ReadLine();
                    Line = Lectura.ReadLine();
                    
                    while (Line != null)
                    {
                        tabla = Line.Split(indicador);
                        if (tabla[0].Trim().Equals(Busqueda))
                        {
                            Console.WriteLine("Deseas eliminar el registro?");
                            res = Console.ReadLine();
                            if ((res.ToUpper()) == "S")
                            {
                                ValorBuscado = true;
                            }
                            else
                            {
                                return;
                            }
                            

                        }
                        else
                        {

                            Tmp.WriteLine(Line);
                        }
                        Line = Lectura.ReadLine();
                    }
                    if (ValorBuscado == false)
                    {
                        Console.WriteLine("EL alumno con número de control {0} no está en la base ", Busqueda);
                    }
                    else
                    {
                        Console.WriteLine("EL alumno con número de control {0} ha sido eliminado ", Busqueda);
                    }
                    Lectura.Close();
                    Tmp.Close();
                    File.Delete("miarchivo.txt");
                    File.Move("Tmp.txt", "miarchivo.txt");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("No se puede leer el archivo");
            }
        }
        public void Editar(string path)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            StreamReader Lectura;
            StreamWriter Tmp;
            int op;
            string Busqueda, Line, res, CampoNuevo;
            CampoNuevo = " ";
            Busqueda = " ";
            Line = " ";
            res = " ";
            op = 0;
            bool ValorBuscado;
            ValorBuscado = false;
            string[] tabla = new string[6];
            char[] indicador = { ';' };
            try
            {

                using (Lectura = File.OpenText(path))
                {
                    Tmp = File.CreateText("Tmp.txt");
                    Console.WriteLine("Ingrese el numero de control a modificar");
                    Busqueda = Console.ReadLine();
                    Line = Lectura.ReadLine();
                    
                    while (Line != null)
                    {
                        tabla = Line.Split(indicador);
                        if (tabla[0].Trim().Equals(Busqueda))
                        {
                            
                            Console.WriteLine("0.Número de control: {0}", tabla[0].Trim());
                            Console.WriteLine("1.Nombre: {0}", tabla[1].Trim());
                            Console.WriteLine("2.Carrea: {0}", tabla[2].Trim());
                            Console.WriteLine("3.Direccion: {0}", tabla[3].Trim());
                            Console.WriteLine("4.Número Telefonico: {0}", tabla[4].Trim());
                            Console.WriteLine("5.Email: {0}", tabla[5].Trim());
                            ValorBuscado = true;
                            Console.WriteLine("Desea editar este registro?");
                            res = Console.ReadLine();
                            if ((res.ToUpper()) == "S")
                            {
                                try{
                                Console.WriteLine("Ingrese el numero del campo que desea editar");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
	                            {
                                    case 0:
                                        Console.WriteLine("El numero de control no es editable");
                                        Tmp.WriteLine(tabla[0] + "; " + tabla[1] + ";" + tabla[2] + ";" + tabla[3] + ";" + tabla[4] + ";" + tabla[5]);
                                        break;
                                    case 1:
                                        Console.WriteLine("Ingrese el nuevo nombre");
                                        CampoNuevo = Console.ReadLine();
                                        Tmp.WriteLine(tabla[0] + ";" + CampoNuevo + ";" + tabla[2] + ";" + tabla[3] + ";" + tabla[4] + ";" + tabla[5]);
                                        Console.WriteLine("Registro editado con exito!");
                                        break;
                                    case 2:
                                         Console.WriteLine("Ingrese la nueva carrera");
                                        CampoNuevo = Console.ReadLine();
                                        Tmp.WriteLine(tabla[0] + ";" + tabla[1] + ";" + CampoNuevo + ";" + tabla[3] + ";" + tabla[4] + ";" + tabla[5]);
                                        Console.WriteLine("Registro editado con exito!");
                                        break;
                                    case 3:
                                         Console.WriteLine("Ingrese la nueva dirección");
                                        CampoNuevo = Console.ReadLine();
                                        Tmp.WriteLine(tabla[0] + ";" + tabla[1] + "; " +tabla[2] + ";" + CampoNuevo + ";" + tabla[4] + "; " + tabla[5]);
                                        Console.WriteLine("Registro editado con exito!");
                                        break;
                                    case 4:
                                         Console.WriteLine("Ingrese el nuevo número telefonico");
                                        CampoNuevo = Console.ReadLine();
                                        Tmp.WriteLine(tabla[0] + ";" + tabla[1] + ";" +tabla[2] + ";" + tabla[3] + ";" + CampoNuevo + ";" + tabla[5]);
                                        Console.WriteLine("Registro editado con exito!");
                                        break;
                                    case 5:
                                         Console.WriteLine("Ingrese el nuevo número email");
                                        CampoNuevo = Console.ReadLine();
                                        Tmp.WriteLine(tabla[0] + ";" + tabla[1] + ";" +tabla[2] + ";" + tabla[3] + ";" + tabla[4] + ";" + CampoNuevo);
                                        Console.WriteLine("Registro editado con exito!");
                                        break;
		                            default:
                                        Console.WriteLine("No existe el campo ingresado");
                                        break;
	                            }
                                }catch(FormatException e){
                                    Console.WriteLine("Entrada invalida: {0}", e.Message);
                                }
                            }
                            else
                            {
                                Tmp.WriteLine(Line);
                            }
                                                                

                        }
                        else
                        {
                            Tmp.WriteLine(Line);
                            
                        }
                        Line = Lectura.ReadLine();
                    }
                    if (ValorBuscado == false)
                    {
                        Console.WriteLine("EL alumno con número de control {0} no está en la base ", Busqueda);
                    }
                    
                    Lectura.Close();
                    Tmp.Close();
                    File.Delete("miarchivo.txt");
                    File.Move("Tmp.txt", "miarchivo.txt");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("No se puede leer el archivo");
            }

        }
        public int Validar(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!Int32.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("El dato ingresado no es valido");
                Console.WriteLine(mensaje);
            }

            return valor;
        }
        public string ValidarR(string mensaje)
        {
            string valor = "";
            Console.Write(mensaje);
            while ((valor = Console.ReadLine()) != "S" || (valor = Console.ReadLine()) != "N")
            {
                Console.WriteLine("Respuesta invalida");
                Console.WriteLine(mensaje);
            }

            return valor;
        }
        
    }
}
