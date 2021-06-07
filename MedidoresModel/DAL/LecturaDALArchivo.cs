using MedidoresModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class LecturaDALArchivo : ILecturaDAL
    {
        private LecturaDALArchivo()
        {
        }

        private static LecturaDALArchivo instancia;

        public static ILecturaDAL GetInstancia()
        {
            if(instancia == null)
            {
                instancia = new LecturaDALArchivo();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";

        public void AgregarLectura(string entrada)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(entrada);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Lectura> ObtenerLectura()
        {
            List<Lectura> lista = new List<Lectura>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');

                            int[] fecha = arr[1].Split('-').Select(int.Parse).ToArray();

                            Lectura lectura = new Lectura()
                            {
                                NroMedidor = int.Parse(arr[0]),
                                Fecha = new DateTime(fecha[0], fecha[1], fecha[2], fecha[3], fecha[4], fecha[5]),
                                ValorConsumo = float.Parse(arr[2])
                            };
                            
                            lista.Add(lectura);
                        }
                    } while (texto != null);
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;
        }
    }
}
