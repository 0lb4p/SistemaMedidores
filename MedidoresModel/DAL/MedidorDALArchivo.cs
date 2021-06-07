using MedidoresModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class MedidorDALArchivo : IMedidorDAL
    {
        private MedidorDALArchivo()
        {
        }

        private static MedidorDALArchivo instancia;

        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MedidorDALArchivo();
            }
            return instancia;
        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/lecturas.txt";

        public List<Medidor> ObtenerMedidores()
        {
            //leer los medidores desde archivo

            List<Medidor> lista = new List<Medidor>();
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
                            Medidor medidor= new Medidor()
                            {
                                NroMedidor = int.Parse(arr[0])   
                            };

                            bool existe = false;
                            for (int i = 0; i < lista.Count(); i++)
                            {
                                if (lista[i].NroMedidor == medidor.NroMedidor){
                                    existe = true;
                                    
                                }
                            }
                            if (!existe)
                            {
                                lista.Add(medidor);
                            }
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
