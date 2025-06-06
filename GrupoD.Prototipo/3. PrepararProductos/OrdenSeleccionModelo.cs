using GrupoD.Prototipo._3._PrepararProductos;   
using GrupoD.Prototipo.Almacenes;              
using Prototipo.PrepararProductos;              
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Prototipo.PrepararProductos.PrepararProductos
{
    public class PrepararProductosPresenter
    {
        private readonly IPrepararProductosView _view;
        private List<OrdenesDeSeleccion> _ordenesPendientes = new List<OrdenesDeSeleccion>();

        public PrepararProductosPresenter(IPrepararProductosView view)
        {
            _view = view;
        }

        /// Paso 1: Carga todas las OS pendientes y las envía a la vista.
        
        public void CargarOrdenes()
        {
            // 1.a) Traer entidades de OS y filtrar solo “Pendiente”
            var osEntidades = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                                .Where(e => e.EstadoOrdenDeSeleccion == EstadoOrdenDeSeleccionEnum.Pendiente)
                                .ToList();

            // 1.b) Mapear cada entidad a nuestro POCO OrdenesDeSeleccion (sin OP cargadas todavía)
            _ordenesPendientes.Clear();
            foreach (var osEnt in osEntidades)
            {
                var pocoOS = new OrdenesDeSeleccion
                {
                    NumeroOrdenSeleccion = osEnt.Numero,
                    FechaGeneracion = osEnt.FechaGeneracion,
                    EstadoOrdenDeSeleccion = osEnt.EstadoOrdenDeSeleccion.ToString(),
                    OrdenesPreparacion = new List<OrdenesDePreparacion>() // se llenará al seleccionar
                };
                _ordenesPendientes.Add(pocoOS);
            }

            // 1.c) Mandar la lista a la vista
            _view.MostrarOrdenes(_ordenesPendientes);
        }

        
        /// Paso 2, 3, 4: Cuando el usuario elige una OS en el combo.
        
        public void OrdenSeleccionadaCambiada()
        {
            // 1) Obtener la POCO de la OS seleccionada
            var osPOCO = _view.ObtenerOrdenSeleccionada();
            if (osPOCO == null)
            {
                _view.MostrarProductosEnListView(new List<OrdenesDePreparacion>());
                _view.HabilitarBotonConfirmar(false);
                return;
            }

            int idOS = osPOCO.NumeroOrdenSeleccion;

            // 2) Recuperar la entidad completa de esta OS para acceder a su lista de IDs de OP
            var osEntidad = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                              .FirstOrDefault(o => o.Numero == idOS);
            if (osEntidad == null)
            {
                _view.MostrarProductosEnListView(new List<OrdenesDePreparacion>());
                _view.HabilitarBotonConfirmar(false);
                return;
            }

            // 3) Filtrar las OP que estén en “Pendiente” (0)
            var opEntidades = OrdenDePreparacionAlmacen.OrdenesDePreparacion
                                  .Where(op =>
                                      osEntidad.OrdenesPreparacion.Contains(op.Numero) &&
                                      op.Estado == EstadoOrdenDePreparacionEnum.Pendiente)
                                  .ToList();

            // 4) Mapear cada línea de detalle de esas OP a tu POCO OrdenesDePreparacion,
            //    buscando la POSICIÓN real en ProductoAlmacen según el SKU.
            var listaPOCO_OP = new List<OrdenesDePreparacion>();
            foreach (var opEnt in opEntidades)
            {
                foreach (var linea in opEnt.Detalle)
                {
                    // 4.a) Intentar encontrar el ProductoEntidad correspondiente a este SKU
                    var prodEnt = ProductoAlmacen.Productos
                                    .FirstOrDefault(p => p.SKU == linea.SKU);

                    string posicion;
                    if (prodEnt != null && prodEnt.Posiciones != null && prodEnt.Posiciones.Count > 0)
                    {
                        // Tomamos la primera posición disponible.
                        posicion = prodEnt.Posiciones[0].Codigo;
                    }
                    else
                    {
                        // Si por alguna razón no existe esa entidad o no tiene posiciones, dejamos un placeholder:
                        posicion = "(sin_posición)";
                    }

                    listaPOCO_OP.Add(new OrdenesDePreparacion(
                        opEnt.Numero,            // Id de la orden de preparación
                        posicion,                // Ahora sí la ubicación real, p.ej. "01-10-1"
                        linea.SKU.ToString(),    // SKUProducto (string)
                        linea.Cantidad           // Cantidad
                    ));
                }
            }

            // 5) Asignar la lista de OP al POCO OS (opcional)
            osPOCO.OrdenesPreparacion = listaPOCO_OP;

            // 6) Mostrar en el ListView
            _view.MostrarProductosEnListView(listaPOCO_OP);

            // 7) Habilitar o deshabilitar el botón Confirmar
            _view.HabilitarBotonConfirmar(listaPOCO_OP.Any());
        }

        
        /// Paso 5 y 6: Cuando el usuario hace clic en “Confirmar”:
        ///   - Cambia estado de OS a “Confirmada”
        ///   - Cambia estado de cada OP de “Procesamiento” a “EnPreparacion”
        ///   - restarStock
        ///   - Graba todos los cambios en JSON
        ///   - Refresca la lista de OS y limpia ListView
        
        public void ConfirmarSeleccion()
        {
            // 5.1) Tomar la POCO OS seleccionada
            var osPOCO = _view.ObtenerOrdenSeleccionada();
            if (osPOCO == null)
            {
                _view.MostrarAdvertencia("Debe seleccionar una orden antes de confirmar.", "Atención");
                return;
            }

            int idOS = osPOCO.NumeroOrdenSeleccion;

            // 5.2) Cambiar estado de la OS en el almacén JSON a "Confirmada"
            OrdenDeSeleccionAlmacen.cambiarEstadoOS(idOS, EstadoOrdenDeSeleccionEnum.Confirmada);
            OrdenDeSeleccionAlmacen.Grabar();

            // 5.3) Recuperar nuevamente la entidad OS para obtener su lista de IDs de OP
            var osEntidad = OrdenDeSeleccionAlmacen.OrdenesDeSeleccion
                              .FirstOrDefault(o => o.Numero == idOS);
            if (osEntidad != null)
            {
                // 5.4) Para cada ID de OP en osEntidad.OrdenesPreparacion:
                var todasOpEntidades = OrdenDePreparacionAlmacen.OrdenesDePreparacion;
                foreach (var idOp in osEntidad.OrdenesPreparacion)
                {
                    var opEnt = todasOpEntidades.FirstOrDefault(o => o.Numero == idOp);
                    if (opEnt != null && opEnt.Estado == EstadoOrdenDePreparacionEnum.Procesamiento)
                    {
                        //// 5.4.a) Reducir stock en ProductoAlmacen (comentado porque no existe restarStock)
                        //foreach (var linea in opEnt.Detalle)
                        //{
                        //    ProductoAlmacen.restarStock(linea.SKU, linea.Cantidad);
                        //}

                        // 5.4.b) Cambiar estado de OP a "EnPreparacion"
                        OrdenDePreparacionAlmacen.cambiarEstado(idOp, EstadoOrdenDePreparacionEnum.EnPreparacion);
                    }
                }

                // 5.5) Grabar cambios en las OP
                OrdenDePreparacionAlmacen.Grabar();

                // 5.6) Si hubiera modificado stock, se haría ProductoAlmacen.Grabar();
                //ProductoAlmacen.Grabar();
            }

            // 5.7) Mensaje de confirmación
            _view.MostrarMensaje($"¡Orden de selección #{idOS} CONFIRMADA!", "Éxito");

            // 5.8) Quitar esa POCO OS de la lista interna y recargar combo
            _ordenesPendientes.RemoveAll(o => o.NumeroOrdenSeleccion == idOS);
            CargarOrdenes();

            // 5.9) Limpiar ListView y deshabilitar el botón Confirmar
            _view.MostrarProductosEnListView(new List<OrdenesDePreparacion>());
            _view.HabilitarBotonConfirmar(false);
        }
    }
}

// PANTALLA:
// 1: Cargar en memoria las órdenes de selección disponibles en el almacén [OS Almacen], Filtrar y devolver aquellas órdenes de selección que están en estado “Pendiente”.
// 2: El usuario selecciona una OS (Pendiente) del CmBox e invoca (por id) las ordenes de preparacion [Almacen OP] asociadas a esta.
// 3: El ListView muestra los productos de las órdenes de preparación asociadas a la OS seleccionada (SKUproducto y cantidad necesarios) y posición de depósito (ProductoAlmacen -> JsonProducto) y lo deserializa en una colección de objetos ProductoEntidad. 
// NOTA: Si al elegir la Orden de Selección no hay ninguna Orden de Preparación en estado “Pendiente”, el listado queda vacío y el botón de “Confirmar” aparece deshabilitado, porque no hay nada que procesar.
// 4: Al confirmar orden Seleccion: Cambio estado de "pendiente" a "confirmada" Y orden de preparacion de "en proceamiento" a "en preparacion" --> Ambos con boton "confirmar"
// 5: Y Modifica cambio de stock --> Impacta en ProductoAlmacen -> Datos\Producto.json

//JSon = OrdenDePreparacion, OrdenDeSeleccion y Productos 
//Almacenes: OrdenDePreparacionAlmacen, OrdenDeSeleccionAlmacen y ProductoAlmacen
//Entidad: OrdenDeSeleccionEntidad, OrdenDePreparacionEntidad y ProductoEntidad

//Resumen: La Pantalla permite ver rápidamente qué productos y su ubicaciones se requieren (buscar) para cumplir una Orden de Selección, y al confirmar ese trabajo se actualizan automáticamente los estados de selección y preparación, así como el stock disponible en el depósito.