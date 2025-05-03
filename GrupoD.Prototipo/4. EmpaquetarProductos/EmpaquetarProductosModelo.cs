
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._4._EmpaquetarProductos
{
    class EmpaquetarProductosModelo
    {
        public List<OrdenPreparacion> OrdenesEnPreparacionDisponibles { get; set; }
        //public List<OrdenesDeSeleccion> OrdenesDeSeleccion { get; set; }  // Agregar esta propiedad

        public EmpaquetarProductosModelo()
        {
            OrdenesEnPreparacionDisponibles = new List<OrdenPreparacion>
            {
            
                
            
            };  

            //OrdenesAgregadas = new List<OrdenesDePreparacion>(); // Inicializar la nueva lista
            //OrdenesDeSeleccion = new List<OrdenesDeSeleccion>();  // Lista de órdenes de selección
        }
    }
}

