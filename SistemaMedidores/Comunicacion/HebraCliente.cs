using MedidoresModel.DAL;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedidores.Comunicacion
{
    public class HebraCliente
    {
        private ClienteCom clienteCom;
        private ILecturaDAL lecturaDAL = LecturaDALArchivo.GetInstancia();


        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese nroMedidor|yyyy-MM-dd-hh-mm-ss|consumo:");
            string entrada = clienteCom.Leer();



            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLectura(entrada);
            }

            clienteCom.Desconectar();
        }
    }
}

