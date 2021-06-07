using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Lectura
    {
        private int nroMedidor;
        private DateTime fecha;
        private float valorConsumo;

        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float ValorConsumo { get => valorConsumo; set => valorConsumo = value; }
    }
}
