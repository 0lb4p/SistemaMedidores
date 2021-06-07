using MedidoresModel.DAL;
using MedidoresModel.DTO;
using Mensajero.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaMedidores
{
    class Program
    {
        private static ILecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();
        private static IMedidorDAL medidorDAL = MedidorDALArchivo.GetInstancia();


        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Bienvenido al Sistema de Medidores");
            Console.WriteLine(" 1. Ingresar \n 2. Mostrar Lecturas \n 3. Mostrar Medidores \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    MostrarLecturas();
                    break;
                case "3":
                    MostrarMedidores();
                    break;
                case "0":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }

        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();

            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (Menu()) ;
        }

        static void Ingresar()
        {
            string valorConsumo = "";
            string nroMedidor = "";

            bool esNumero = true;
            do
            {
                Console.WriteLine("Ingrese Nro de medidor: ");
                nroMedidor = Console.ReadLine().Trim();
                int aux;

                esNumero = int.TryParse(nroMedidor, out aux);

                if (!esNumero)
                {
                    Console.WriteLine("Debe ser un numero");
                }

            } while (!esNumero);



            Console.WriteLine("Ingresar fecha: ");
            string fecha = Console.ReadLine().Trim();



            do { 
            Console.WriteLine("Ingresar valor de consumo:");
            valorConsumo = Console.ReadLine().Trim();
            float aux;

            esNumero = float.TryParse(valorConsumo, out aux);
            if (!esNumero)
            {
                Console.WriteLine("Debe ser un numero");
            }

            } while (!esNumero);



            string entrada = nroMedidor + "|" + fecha + "|" + valorConsumo;

            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLectura(entrada);
            }
        }

        static void MostrarLecturas()
        {
            List<Lectura> lecturas = null;
            lock (lecturaDAL)
            {
                lecturas = lecturaDAL.ObtenerLectura();
            };

            foreach (Lectura lectura in lecturas)
            {
                Console.WriteLine("\nNro. Medidor: " + lectura.NroMedidor);
                Console.WriteLine("Fecha: " + lectura.Fecha.ToString("dd/MM/yyyy HH:mm:ss"));
                Console.WriteLine("Valor Consumo " + lectura.ValorConsumo);
                Console.WriteLine("\n==================O================\n");
            }
        }
        
        static void MostrarMedidores()
        {
            List<Medidor> medidores = null;
            lock (medidorDAL)
            {
                medidores = medidorDAL.ObtenerMedidores();
            };

            Console.WriteLine("");
            foreach (Medidor medidor in medidores)
            {
                Console.WriteLine(medidor.NroMedidor);
            }
        }
        
    }
}

