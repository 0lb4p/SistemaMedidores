using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Simulador
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress direccion = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(direccion, 3000);

            socket.Connect(remoteEP);

            byte[] byData = Encoding.ASCII.GetBytes("13|2019-01-01-04-02-00|234.4");
            socket.Send(byData);


            //Esta simulacion no realiza envio de informacion o el servidor no la recepciona
            //
            //PERO LA CONECCION CON EL SERVIDOR FUNCIONA.




              

        }
    }
}
    
