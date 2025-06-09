using GrupoD.Prototipo.Almacenes;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace GrupoD.Prototipo._3._PrepararProductos;

internal class PrepararProductosModelo
{
    //Obtener OS: extrae del almacén todos los números de órdenes cuyo estado sea Pendiente.
    internal List<int> ObtenerOrdenesDeSeleccion()
    {
        return OrdenDeSeleccionAlmacen.OrdenesDeSeleccion.Where(o => o.EstadoOrdenDeSeleccion == EstadoOrdenDeSeleccionEnum.Pendiente)
                            .Select(o => o.Numero)
                            .ToList();
    }

    internal List<PosicionProducto> ObtenerListaPosiciones(int numero) // -------> PENDIENTE A CODIFICAR
    {
        // Busca en almacenOS --> Resultado: Una instancia de la entidad OrdenDeSeleccionEntidad, con su lista de IDs de órdenes de preparación asociadas.

        var ordenSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                             .First(o => o.Numero == numero);

        // Para cada prepId, busca la entidad en OrdenDePreparacionAlmacen, extraemos su colección Detalle (una lista de ProductosPorOrden) 
        // Y SelectMany “aplasta” todas esas listas en una sola secuencia de ProductosPorOrden.
        // --> Resultado: Un IEnumerable<ProductosPorOrden> que contiene todos los renglones de todos los detalles de preparación.

        var todosLosDetalles = ordenSeleccion.OrdenesPreparacion
            .SelectMany(prepId =>
                OrdenDePreparacionAlmacen.OrdenesDePreparacion
                    .First(op => op.Numero == prepId)
                    .Detalle
            );

        // Agrupar por SKU y sumar cantidades --> Resultado: Una lista de pares { Sku, Cantidad }, EJ : { Sku=111, Cantidad=7 }, { Sku=211, Cantidad=19 }.

        var totalesPorSku = todosLosDetalles
            .GroupBy(det => det.SKU)
            .Select(g => new { Sku = g.Key, Cantidad = g.Sum(d => d.Cantidad) })
            .ToList();

        var resultado = new List<PosicionProducto>();

        // Para cada SKU, repartir la demanda en posiciones:

        foreach (var item in totalesPorSku)
        {
            int sku = item.Sku;
            int restante = item.Cantidad;

            // Obtener posiciones ordenadas de mayor a menor stock, Busca el ProductoEntidad cuyo SKU coincida.
            // Accede a su lista de PosicionesPorProducto, que tienen Codigo y Stock. Usa OrderByDescending para que las posiciones con más stock aparezcan primero.
            // Resultado: Al vaciar las más grandes primero minimizamos el número de ubicaciones usadas.

            var posiciones = ProductoAlmacen.Productos
                .First(p => p.SKU == sku)
                .Posiciones
                .OrderByDescending(p => p.Stock)
                .ToList();

            // Intentar cubrir toda la demanda con una sola posición:

            var unica = posiciones.FirstOrDefault(p => p.Stock >= restante);
            if (unica != null)
            {
                resultado.Add(new PosicionProducto
                {
                    Posicion = unica.Codigo,
                    Sku = sku.ToString(),
                    Cantidad = restante
                });
                continue;
            }

            // Si no hay posición unica, vaciar posiciones de mayor a menor:

            foreach (var pos in posiciones)
            {
                if (restante == 0) break;
                int toma = Math.Min(pos.Stock, restante);
                if (toma <= 0) continue;

                resultado.Add(new PosicionProducto
                {
                    Posicion = pos.Codigo,
                    Sku = sku.ToString(), 
                    Cantidad = toma
                });
                restante -= toma;
            }

            // Verifica si quedó demanda sin cubrir:

            if (restante > 0)
                throw new InvalidOperationException(
                    $"Stock insuficiente para SKU '{sku}'. Falta {restante} unidades."); 
        }

        return resultado; // return null; ---> Para que compile, reemplazar con resultado.
    }
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
    // Sumar la cantidad de cada articulo: 7 remeras y 19 zapatillas

    // Para cada articulo:

    //  a - Buscar a la primera posicion que cubra la cantidad que quiero. Si no hay, cualquier posicion en donde haya producto
    //  b - Tomar la cantidad q se necesita o todo lo que hay si no cubre lo que se necesita. Agregar a la lista de posiciones resultado
    //  c - Si necesito más vuelvo a a)



    //Confirmar OS:Cambia el estado de OS Y OP asociadas, luego llama a 'ObtenerListaPosiciones' para ver de donde se saca el stock.
    /*internal string? ConfirmarOrdenSeleccion(int numero)
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
        var stockADescontar = ObtenerListaPosiciones(ordenSeleccion.Numero); // -------> PENDIENTE A CODIFICAR

        //TODO: descontar del stock de acuerdo a la lista stockADescontar



        return null;
    }*/

    //Confirmar OS:Cambia el estado de OS Y OP asociadas, luego llama a 'ObtenerListaPosiciones' para ver de donde se saca el stock.
    internal string? ConfirmarOrdenSeleccion(int numero)
    {
        //pasar la orden de pendiente a confirmada.

        var ordenSeleccion = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                                 .First(o => o.Numero == numero);
        ordenSeleccion.EstadoOrdenDeSeleccion = EstadoOrdenDeSeleccionEnum.Confirmada;  

        //pasar las ordenes de preparacion a EnPreparacion

        foreach (var prepId in ordenSeleccion.OrdenesPreparacion)
        {
            var entPrep = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                            .First(o => o.Numero == prepId);
            entPrep.Estado = EstadoOrdenDePreparacionEnum.EnPreparacion;
        }

     // Vuelve a llamar a ObtenerListaPosiciones(numero): devuelve una lista de PosicionProducto, con posicion, sku y cantidad.

        var stockADescontar = ObtenerListaPosiciones(numero);

        // Llama a ProductoAlmacen.RestarStock(skuInt, cantidad): Verifica que exista el producto, comprueba que haya stock suficiente 
        //Resta cantidad de la propiedad Stock de la entidad y persiste la lista actualizada en tu JSON(Grabar()).

        foreach (var mov in stockADescontar)
        {
            int skuInt = int.Parse(mov.Sku);
            int cantidad = mov.Cantidad;
            ProductoAlmacen.RestarStock(skuInt, cantidad);
        }

        // Devuelvo null = todo OK, sino arroja excepcion..

        return null;
    }
}