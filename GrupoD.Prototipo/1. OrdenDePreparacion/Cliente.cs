using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._1._OrdenDePreparacion
{
     public class Cliente
    {
        //Atributos
        public int NumeroCliente { get; set; }

        public string RazonSocialCliente { get; set; }

        public List<Producto> Productos { get; set; } = new List<Producto>();

        public Cliente(int numeroCliente, string razonSocialCliente)
        {
            NumeroCliente = numeroCliente;
            RazonSocialCliente = razonSocialCliente;
            Productos = new List<Producto>(); // Inicializar lista de productos}
        } 
       

}
}

//public class Cliente
//{
//    public int NumeroCliente { get; set; }
//    public string RazonSocialCliente { get; set; }
//    public List<Producto> Productos { get; set; } // Lista de productos por clientepublic Cliente(int numeroCliente, string razonSocial){
//    NumeroCliente = numeroCliente;
//            RazonSocialCliente = razonSocial;
//            Productos = new List<Producto>(); // Inicializar lista de productos}
//    }
