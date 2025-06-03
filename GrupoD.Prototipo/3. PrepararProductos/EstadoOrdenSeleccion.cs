using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoD.Prototipo._3._PrepararProductos
{
    public enum EstadoOrdenSeleccion
    {
        Pendiente,
        Confirmada,
        EnPreparacion,
        Preparada,
        EnDespacho,
        Despachada
    }
    public enum Prioridad
    {
        Alta = 1,
        Media = 2,
        Baja = 3
    }
}
