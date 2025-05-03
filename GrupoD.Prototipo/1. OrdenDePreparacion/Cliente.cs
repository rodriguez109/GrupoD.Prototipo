using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._1._OrdenDePreparacion
{
     class Cliente
    {
        //Atributos
        public int NumeroCliente { get; set; }

        public string RazonSocialCliente { get; set; }

        public List<Producto> Productos { get; set; } = new List<Producto>();

        public Cliente(int numeroCliente, string razonSocialCliente)
        {
            NumeroCliente = numeroCliente;
            RazonSocialCliente = razonSocialCliente;
        } 
       

}
}
