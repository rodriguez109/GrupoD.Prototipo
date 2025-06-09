using GrupoD.Prototipo.Almacenes;

namespace GrupoD.Prototipo._3._PrepararProductos;

internal class PrepararProductosModelo
{
    internal List<int> ObtenerOrdenesDeSeleccion()
    {
        return OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Where(o => o.EstadoOrdenDeSeleccion == EstadoOrdenDeSeleccionEnum.Pendiente)
                            .Select(o => o.Numero)
                            .ToList();
    }

    internal List<PosicionProducto> ObtenerListaPosiciones(int numero)
    {
        // Ejemplo:

        // Orden prep 1: 2 remeras(SKU = reme) 3 zapas(SKU = zapa)
        // Orden prep 2: 4 remeras 7 zapas
        // Orden prep 3: 1 remeras 9 zapas

        // Lo que hay en el almacen:
        // 111 - 4 remeras
        // 112 - 100 remeras
        // 211 - 8 zapatillas
        // 212 - 11 zapatillas

        //Resultado esperado:
        //Posicion SKU         Cantidad
        //112         reme        7
        //211         zapa        8
        //212         zapa        11

        //Y en el stock final tiene que quedar:
        // 111 - 4 remeras
        // 112 - 93 remeras
        // 211 - 0 zapatillas
        // 212 - 0 zapatillas

        //Pasos:
        // Sumar la cantidad de cada articulo:
        //   7 remeras
        //   19 zapatillas
        //
        // Para cada articulo
        //  a - Buscar a la primera posicion que cubra la cantidad que quiero. Si no hay, cualquier posicion en donde haya producto
        //  b - Tomar la cantidad q se necesita o todo lo que hay si no cubre lo que se necesita. Agregar a la lista de posiciones resultado
        //  c - Si necesito más vuelvo a a)
        //  

        return null; //Lo pongo para que compile, reemplazar con resultado.
    }

    internal string? ConfirmarOrdenSeleccion(int numero)
    {
        var ordenSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.First(o => o.Numero == numero);

        //pasar la orden de pendiente a confirmada.
        ordenSeleccion.EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Confirmada;

        //pasar las ordenes de preparacion a EnPreparacion
        foreach (var ordenPrep in ordenSeleccion.OrdenesPreparacion)
        {
            var ordenPrepEntidad = OrdenDePreparacionAlmacen.OrdenesDePreparacion.First(o => o.Numero == ordenPrep);
            ordenPrepEntidad.Estado = EstadoOrdenDePreparacionEnum.EnPreparacion;
        }

        //descontar stock.
        var stockADescontar = ObtenerListaPosiciones(ordenSeleccion.Numero);

        //TODO: descontar del stock de acuerdo a la lista stockADescontar



        return null;
    }
}