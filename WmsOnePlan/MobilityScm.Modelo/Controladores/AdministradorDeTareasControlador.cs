using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.XtraEditors;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Configuracion;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;
using MoreLinq;
using Newtonsoft.Json;
using Enums = MobilityScm.Modelo.Tipos.Enums;
using Formatting = System.Xml.Formatting;

namespace MobilityScm.Modelo.Controladores
{
    public class AdministradorDeTareasControlador : IAdministradorDeTareasControlador
    {
        private readonly IAdministradorDeTareasVista _vista;
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public IUsuarioServicio UsuarioServicio { get; set; }
        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public ITareaServicio TareaServicio { get; set; }
        public IClaseServicio ClaseServicio { get; set; }
        public IOrdenDeCompraServicio OrdenDeCompraServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public ISeguridadServicio SeguridadServicio { get; set; }
        public IBaseDeDatosServicio BaseDeDatosServicio { get; set; }
        public IParametroServicio ParametroServicio { get; set; }

        public AdministradorDeTareasControlador(IAdministradorDeTareasVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }
        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaCambiarEstadoDeTarea += _vista_UsuarioDeseaCambiarEstadoDeTarea;
            _vista.UsuarioDeseaCambiarOperadorATarea += _vista_UsuarioDeseaCambiarOperadorATarea;
            _vista.UsuarioDeseaObtenerDetalleDeTarea += _vista_UsuarioDeseaObtenerDetalleDeTarea;
            _vista.UsuarioDeseaObtenerOperadores += _vista_UsuarioDeseaObtenerOperadores;
            _vista.UsuarioDeseaObtenerTareas += _vista_UsuarioDeseaObtenerTareas;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaCancelarDetallePicking += _vista_UsuarioDeseaCancelarDetallePicking;
            _vista.UsuarioDeseaCambiarOperadorDeTareaConteo += _vista_UsuarioDeseaCambiarOperadorDeTareaConteo;
            _vista.UsuarioDeseaObtenerTiposDeTarea += _vista_UsuarioDeseaObtenerTiposDeTarea;
            _vista.UsuarioDeseaOptenerOperadores += _vista_UsuarioDeseaOptenerOperadores;
            _vista.UsuarioDeseaAutorizarDocumentoErp += _vista_UsuarioDeseaAutorizarDocumentoErp;
            _vista.UsuarioDeseaDistribuirTareasTodosLosOperadores += _vista_UsuarioDeseaDistribuirTareasTodosLosOperadores;
            _vista.UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea += _vista_UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea;
            _vista.UsuarioDeseaReasignarTareaDeLineaDePicking += _vista_UsuarioDeseaReasignarTareaDeLineaDePicking;
            _vista.UsuarioDeseaCambiarDePrioridadALaTarea += _vista_UsuarioDeseaCambiarDePrioridadALaTarea;
            _vista.EnviarTareasAApi += _vista_EnviarTareasAApi;
            _vista.UsuarioDeseaCancelarDetallesDeRecepcion += _vista_UsuarioDeseaCancelarDetallesDeRecepcion;
            _vista.UsuarioDeseaObtenerTareasConDetalleDeMaterial += _vista_UsuarioDeseaObtenerTareasConDetalleDeMaterial;
            _vista.UsuarioDeseaMostrarPantallaConfirmacionRecepcion += _vista_UsuarioDeseaMostrarPantallaConfirmacionRecepcion;
            _vista.UsuarioDeseaActualizarCantidadConfirmadaManualmente += _vista_UsuarioDeseaActualizarCantidadConfirmadaManualmente;
            _vista.UsuarioDeseaGuardarConfirmacionReception += _vista_UsuarioDeseaGuardarConfirmacionReception;
            _vista.UsuarioDeseaConfirmarFilaDeRecepcionRecibida += _vista_UsuarioDeseaConfirmarFilaDeRecepcionRecibida;
            _vista.UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries += _vista_UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries;
            _vista.UsuarioDeseaLiberarInventarioConfirmado += _vista_UsuarioDeseaLiberarInventarioConfirmado;
            _vista.UsuarioDeseaLiberarTransaccionConfirmado += _vista_UsuarioDeseaLiberarTransaccionConfirmado;
            _vista.UsuarioDeseaValidarVisibilidadDeBoton += _vista_UsuarioDeseaValidarVisibilidadDeBoton;
            _vista.UsuarioDeseaAutorizarControlDeCalidad += _vista_UsuarioDeseaAutorizarControlDeCalidad;
            _vista.UsuarioDeseaRecargarGridOrdenDeCompra += _vista_UsuarioDeseaRecargarGridOrdenDeCompra;
            _vista.UsuarioDeseaObtenerDetalleOlaPicking += _vista_UsuarioDeseaObtenerDetalleOlaPicking;
            _vista.UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking += _vista_UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking;
            _vista.UsuarioDeseaReabrirTareaRecepcion += _vista_UsuarioDeseaReabrirTareaRecepcion;
            _vista.UsuarioDeseaCrearTareaDeRectificacionMP += _vista_UsuarioDeseaCreartareaDerectificacionMPConfirmado;
        }

        private void _vista_UsuarioDeseaReabrirTareaRecepcion(object sender, TareaArgumento e)
        {
            try
            {
                Operacion op = TareaServicio.ReabrirTareaRecepcion(e);
                if (op.Resultado != ResultadoOperacionTipo.Exito)
                {
                    InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeExito("Se reabrio la tarea, vuelva a buscarla en el listado de tareas");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking(object sender, TareaArgumento e)
        {
            try
            {
                Operacion op = TareaServicio.CambiarLicenciaEnLineaDeTareaPicking(e);
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    ObtenerDetalleLicenciasOla(e);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDetalleOlaPicking(object sender, TareaArgumento e)
        {
            ObtenerDetalleLicenciasOla(e);
        }

        private void ObtenerDetalleLicenciasOla(TareaArgumento e)
        {
            try
            {
                _vista.DetalleLicenciasOla = TareaServicio.ObtenerDetalleLicenciasOla(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaRecargarGridOrdenDeCompra(object sender, TareaArgumento e)
        {
            ObtenerDetalleOrdenDeCompra(e);
        }

        private void _vista_UsuarioDeseaAutorizarControlDeCalidad(object sender, TareaArgumento e)
        {
            try
            {
                Operacion resultado = OrdenDeCompraServicio.AutorizarControlDeCalidad(e);
                if (resultado.Resultado == ResultadoOperacionTipo.Exito)
                {
                    InteraccionConUsuarioServicio.MensajeExito("Operación de autorización de Control de Calidad exitosa", true);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaValidarVisibilidadDeBoton(object sender, TareaArgumento e)
        {
            try
            {
                Operacion resultado = OrdenDeCompraServicio.ValidarSiTodosLosDocumentosHanSidoEnviadosAErp(e.taskId);
                if (resultado.Resultado == ResultadoOperacionTipo.Exito)
                {
                    if (resultado.DbData == "1")
                    {
                        _vista.DebeMostrarBotonParaLiberarInventario = false;
                    }
                    else
                    {
                        _vista.DebeMostrarBotonParaLiberarInventario = true;
                    }
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaLiberarInventarioConfirmado(object sender, TareaArgumento e)
        {
            try
            {
                Operacion resultado = OrdenDeCompraServicio.DesbloquearInventarioParaTareasEnviadasAErpFallidas(e);
                if (resultado.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.DebeMostrarBotonParaLiberarInventario = false;
                    InteraccionConUsuarioServicio.MensajeExito("Operación de liberación de inventario exitosa", true);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaLiberarTransaccionConfirmado(object sender, TareaArgumento e)
        {
            try
            {
                Operacion resultado = OrdenDeCompraServicio.DesbloquearTransaccionOperacionManual(e);
                if (resultado.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.DebeMostrarBotonParaLiberarTransaccion = false;
                    InteraccionConUsuarioServicio.MensajeExito("Operación de liberación de transaccion exitosa", true);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCreartareaDerectificacionMPConfirmado(object sender, TareaArgumento e)
        {
            try
            {
                Operacion resultado = OrdenDeCompraServicio.CrearTareaRectificacionMP(e);
                if (resultado.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.DebeMostrarBotonCrearTareaDeRectificacion = false;
                    InteraccionConUsuarioServicio.MensajeExito("Tareas creadas exitosamente", true);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries(object sender, TareaArgumento e)
        {
            try
            {
                ObtenerDetalleRecepcionSeries(e);
                ObtenerUltimoCorrelativo();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarCantidadConfirmadaManualmente(object sender, TareaArgumento e)
        {
            var filaOrdenDeCompra = e.FilaOrdenDeCompraDetalle;
            decimal cantidadConfirmadaAnterior = filaOrdenDeCompra.QTY_CONFIRMED_READ_ONLY;
            try
            {
                if (filaOrdenDeCompra.QTY_CONFIRMED < 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("La cantidad modificada no puede ser menor a 0");
                    throw new Exception("La cantidad modificada no puede ser menor a 0");
                }
                if (filaOrdenDeCompra.QTY_CONFIRMED > filaOrdenDeCompra.QTY)
                {
                    InteraccionConUsuarioServicio.Mensaje("La cantidad debe ser menor o igual a la cantidad en la orden de compra");
                    throw new Exception("La cantidad debe ser menor o igual a la cantidad en la orden de compra");
                }
                if (_vista.DetalleConfirmacionRecepcion.Where(det => det.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID).Count() == 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("No se puede actualizar la cantidad confirmada porque el material no fue recepcionado");
                    throw new Exception("La cantidad debe ser menor o igual a la cantidad en la orden de compra");
                }
                //debo saber si la nueva cantidad confirmada fue incrementada o reducida respecto del valor anterior

                var cantidadConfirmadaPorReasignar = (filaOrdenDeCompra.QTY_CONFIRMED - cantidadConfirmadaAnterior) * filaOrdenDeCompra.QTY_FACTOR;
                if (cantidadConfirmadaPorReasignar > _vista.DetalleConfirmacionRecepcion.Sum(x => x.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID ? x.QTY - x.ASIGNADO : 0))
                {
                    throw new Exception("La cantidad sobrepasa lo pendiente de asignar.");
                }

                if (cantidadConfirmadaPorReasignar > 0)
                {
                    //para valor positivo aumentamos lo asignado para tener menos producto disponible para asignar
                    if (_vista.DetalleConfirmacionRecepcion.Where(det => det.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID && det.QTY - det.ASIGNADO > 0).Count() > 0)
                    {
                        foreach (var filaRecepcionada in _vista.DetalleConfirmacionRecepcion.Where(det => det.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID && det.QTY - det.ASIGNADO > 0).ToList())
                        {
                            //lo mas que podemos reducir es la cantidad asignada
                            var cantidadReasignable = filaRecepcionada.QTY - filaRecepcionada.ASIGNADO;
                            if (cantidadConfirmadaPorReasignar > cantidadReasignable)
                            {
                                filaRecepcionada.ASIGNADO += cantidadReasignable;
                                cantidadConfirmadaPorReasignar -= cantidadReasignable;
                            }
                            else
                            {
                                filaRecepcionada.ASIGNADO += cantidadConfirmadaPorReasignar;
                                cantidadConfirmadaPorReasignar = 0;
                            }
                            if (cantidadConfirmadaPorReasignar == 0)
                            {
                                break;
                            }
                        }
                        if (cantidadConfirmadaPorReasignar > 0)
                        {
                            //si nos queda sobrante debemos reducir el valor modificado por el usuario
                            filaOrdenDeCompra.QTY_CONFIRMED = filaOrdenDeCompra.QTY_CONFIRMED - cantidadConfirmadaPorReasignar * filaOrdenDeCompra.QTY_FACTOR;
                        }
                        filaOrdenDeCompra.PENDING = filaOrdenDeCompra.QTY - filaOrdenDeCompra.QTY_CONFIRMED;
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.Mensaje("No queda material recepcionado para asignar");
                        throw new Exception("No queda material recepcionado para asignar");
                    }
                }
                else
                {
                    cantidadConfirmadaPorReasignar *= -1;
                    //para valor negativo disminuimos lo asignado para tener mas producto disponible para asignar
                    if (_vista.DetalleConfirmacionRecepcion.Where(det => det.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID && det.ASIGNADO > 0).Count() > 0)
                    {
                        foreach (var filaRecepcionada in _vista.DetalleConfirmacionRecepcion.Where(det => det.MATERIAL_ID == filaOrdenDeCompra.MATERIAL_ID && det.ASIGNADO > 0).ToList())
                        {
                            var cantidadReasignable = filaRecepcionada.ASIGNADO;
                            if (cantidadConfirmadaPorReasignar > cantidadReasignable)
                            {
                                filaRecepcionada.ASIGNADO = 0;
                                cantidadConfirmadaPorReasignar -= cantidadReasignable;
                            }
                            else
                            {
                                filaRecepcionada.ASIGNADO -= cantidadConfirmadaPorReasignar;
                                cantidadConfirmadaPorReasignar = 0;
                            }
                            if (cantidadConfirmadaPorReasignar == 0)
                            {
                                break;
                            }
                        }
                        if (cantidadConfirmadaPorReasignar > 0)
                        {
                            //si nos queda sobrante debemos reducir el valor modificado por el usuario
                            filaOrdenDeCompra.QTY_CONFIRMED = filaOrdenDeCompra.QTY_CONFIRMED - cantidadConfirmadaPorReasignar * filaOrdenDeCompra.QTY_FACTOR;
                        }
                        filaOrdenDeCompra.PENDING = filaOrdenDeCompra.QTY - filaOrdenDeCompra.QTY_CONFIRMED;
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.Mensaje("No queda material recepcionado para re-asignar");
                        throw new Exception("No queda material recepcionado para re-asignar");
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConfirmarFilaDeRecepcionRecibida(object sender, TareaArgumento e)
        {
            var filaTarea = e.FilaTareaDetalle;
            var filaOrdenDeCompra = e.FilaOrdenDeCompraDetalle;
            decimal cantidadNoAsignada = filaTarea.QTY - filaTarea.ASIGNADO;
            if (filaTarea.MATERIAL_ID.ToUpper() == filaOrdenDeCompra.MATERIAL_ID.ToUpper())
            {
                if (filaOrdenDeCompra.PENDING > 0)
                {
                    //match para cantidades en recepcion y cantidad pendiente en orden de compra erp
                    if (cantidadNoAsignada <= filaOrdenDeCompra.PENDING * filaOrdenDeCompra.QTY_FACTOR)
                    {
                        filaTarea.ASIGNADO += cantidadNoAsignada;
                        filaOrdenDeCompra.PENDING -= cantidadNoAsignada / (decimal)filaOrdenDeCompra.QTY_FACTOR;
                        filaOrdenDeCompra.QTY_CONFIRMED += cantidadNoAsignada / (decimal)filaOrdenDeCompra.QTY_FACTOR;
                    }
                    else
                    {
                        asignarCantidadEnFilaDiferenteADragDrop(ref filaTarea, ref filaOrdenDeCompra);
                    }
                }
                else
                {
                    asignarCantidadEnFilaDiferenteADragDrop(ref filaTarea, ref filaOrdenDeCompra);
                }
            }
            else
            {
                var linea = _vista.DetalleOrdenCompra.Where(detalle => detalle.MATERIAL_ID.ToUpper() == filaTarea.MATERIAL_ID.ToUpper());
                if (linea == null)
                {
                    filaTarea.ASIGNADO = filaTarea.QTY;
                    _vista.DetalleOrdenCompra.Add(new OrdenDeCompraDetalle
                    {
                        ERP_RECEPTION_DOCUMENT_DETAIL_ID = -1,
                        ERP_RECEPTION_DOCUMENT_HEADER_ID = filaOrdenDeCompra.ERP_RECEPTION_DOCUMENT_DETAIL_ID,
                        QTY = filaTarea.QTY,
                        QTY_CONFIRMED = filaTarea.QTY,
                        MATERIAL_ID = filaTarea.MATERIAL_ID,
                        QTY_FACTOR = 1,
                        UNIT = "Unidad Base",
                        UNIT_DESCRIPTION = "Unidad Base",
                        PENDING = 0,
                        LINE_NUM = -1
                    });
                }
                else
                {
                    asignarCantidadEnFilaDiferenteADragDrop(ref filaTarea, ref filaOrdenDeCompra);
                }
            }
        }

        private void asignarCantidadEnFilaDiferenteADragDrop(ref TareaDetalle filaTarea, ref OrdenDeCompraDetalle filaOrdenDeCompra)
        {
            //primero asignamos lo solicitado en pending a la fila en cuestion, con el sobrante buscamos otra fila que haga match
            //si no hace match asignamos en la misma fila todo el contenido
            //si pending es 0 primero recorremos las otras filas de la orden de compra
            if (filaOrdenDeCompra.PENDING > 0 && filaTarea.MATERIAL_ID.ToUpper() == filaOrdenDeCompra.MATERIAL_ID.ToUpper())
            {
                decimal cantidadNoAsignada = (filaTarea.QTY - filaTarea.ASIGNADO) / (decimal)filaOrdenDeCompra.QTY_FACTOR;
                if (cantidadNoAsignada > filaOrdenDeCompra.PENDING)
                {
                    filaOrdenDeCompra.QTY_CONFIRMED = filaOrdenDeCompra.QTY_CONFIRMED + filaOrdenDeCompra.PENDING;
                    filaTarea.ASIGNADO = filaTarea.ASIGNADO + filaOrdenDeCompra.PENDING * (decimal)filaOrdenDeCompra.QTY_FACTOR;
                    filaOrdenDeCompra.PENDING = 0;
                }
                else
                {
                    filaOrdenDeCompra.QTY_CONFIRMED = filaOrdenDeCompra.QTY_CONFIRMED + cantidadNoAsignada - filaOrdenDeCompra.PENDING;
                    filaOrdenDeCompra.PENDING = filaOrdenDeCompra.PENDING - cantidadNoAsignada;
                    filaTarea.ASIGNADO = filaTarea.ASIGNADO + cantidadNoAsignada * (decimal)filaOrdenDeCompra.QTY_FACTOR;
                    if (filaTarea.QTY - filaTarea.ASIGNADO == 0)
                    {
                        return;
                    }
                }
            }

            //recorremos el array de orden de compra para llenar las filas que concuerden con la fila de la tarea de recepcion
            int iterator = 0;
            while (filaTarea.QTY - filaTarea.ASIGNADO > 0 && iterator < _vista.DetalleOrdenCompra.Count)
            {
                OrdenDeCompraDetalle detalleActualOrdenDeCompra = _vista.DetalleOrdenCompra[iterator];
                //debemos asignar cantidades a una o varias filas diferentes a la fila dropeada
                if (filaTarea.MATERIAL_ID.ToUpper() == detalleActualOrdenDeCompra.MATERIAL_ID.ToUpper()
                        && detalleActualOrdenDeCompra.ERP_RECEPTION_DOCUMENT_DETAIL_ID != filaOrdenDeCompra.ERP_RECEPTION_DOCUMENT_DETAIL_ID)
                {
                    var qty = (filaTarea.QTY - filaTarea.ASIGNADO) / (decimal)detalleActualOrdenDeCompra.QTY_FACTOR;
                    //tratamos de llegar el pendiente a 0 y sumamos a la cantidad confirmada
                    if (qty <= (detalleActualOrdenDeCompra.PENDING))
                    {
                        //despues de esta operacion quedara algun faltante o la columna completa quedara sin faltante
                        detalleActualOrdenDeCompra.PENDING = detalleActualOrdenDeCompra.PENDING - qty;
                        detalleActualOrdenDeCompra.QTY_CONFIRMED += qty;
                        filaTarea.ASIGNADO += qty * (decimal)detalleActualOrdenDeCompra.QTY_FACTOR;
                    }
                    else
                    {
                        //el faltante queda en 0, aumentamos la cantidad confirmada y la cantidad asignada
                        filaTarea.ASIGNADO += detalleActualOrdenDeCompra.PENDING * (decimal)detalleActualOrdenDeCompra.QTY_FACTOR;
                        detalleActualOrdenDeCompra.QTY_CONFIRMED += detalleActualOrdenDeCompra.PENDING;
                        detalleActualOrdenDeCompra.PENDING = 0;
                    }
                }
                iterator++;
            }

            //si despues del proceso nos quedo material que asignar aumentamos la fila actual
            if (filaTarea.QTY - filaTarea.ASIGNADO > 0)
            {
                string materialEnFilaTarea = filaTarea.MATERIAL_ID;
                if (_vista.DetalleOrdenCompra.Where(detalle => detalle.MATERIAL_ID == materialEnFilaTarea && detalle.ERP_RECEPTION_DOCUMENT_DETAIL_ID == -1).Count() == 0)
                {
                    _vista.DetalleOrdenCompra.Add(new OrdenDeCompraDetalle
                    {
                        ERP_RECEPTION_DOCUMENT_DETAIL_ID = -1,
                        LINE_NUM = -1,
                        ERP_RECEPTION_DOCUMENT_HEADER_ID = filaOrdenDeCompra.ERP_RECEPTION_DOCUMENT_DETAIL_ID,
                        QTY = filaTarea.QTY - filaTarea.ASIGNADO,
                        QTY_CONFIRMED = filaTarea.QTY - filaTarea.ASIGNADO,
                        MATERIAL_ID = filaTarea.MATERIAL_ID,
                        MATERIAL_NAME = filaTarea.MATERIAL_NAME,
                        QTY_FACTOR = 1,
                        UNIT = "Unidad Base",
                        UNIT_DESCRIPTION = "Unidad Base",
                        PENDING = 0
                    });
                    filaTarea.ASIGNADO = filaTarea.QTY;
                }
                else
                {
                    var detalleExistente = _vista.DetalleOrdenCompra.Where(detalle => detalle.MATERIAL_ID == materialEnFilaTarea && detalle.ERP_RECEPTION_DOCUMENT_DETAIL_ID == -1).FirstOrDefault();
                    filaTarea.ASIGNADO = filaTarea.QTY;
                    detalleExistente.QTY += filaTarea.QTY;
                    detalleExistente.QTY_CONFIRMED += filaTarea.QTY;
                }

            }
        }

        private void _vista_UsuarioDeseaGuardarConfirmacionReception(object sender, TareaArgumento e)
        {
            try
            {
                int taskId = _vista.DetalleConfirmacionRecepcion[0].SERIAL_NUMBER;
                Operacion resultado = OrdenDeCompraServicio.GuardarConfirmacionRecepcionErp(_vista.DetalleOrdenCompra, _vista.DetalleRecepcionSeries, e.Login, taskId);
                if (resultado.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(resultado.Mensaje);
                }
                else
                {
                    _vista.RecargarVistas();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaMostrarPantallaConfirmacionRecepcion(object sender, TareaArgumento e)
        {
            ObtenerMaterialesRecepcionadosEnTarea(e);
            ObtenerDetalleOrdenDeCompra(e);
            ObtenerDetalleRecepcionSeries(e);
            ObtenerUltimoCorrelativo();
            ObtenerBodegasUsuario(e);
        }

        private void ObtenerBodegasUsuario(TareaArgumento e)
        {
            _vista.BodegasUsuario = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
        }

        private void ObtenerBodegasERP(TareaArgumento e)
        {
            _vista.BodegasERP = BodegaServicio.ObtenerBodegasDeERP(e.Tarea.CLIENT_OWNER);
        }

        private void ObtenerMaterialesRecepcionadosEnTarea(TareaArgumento e)
        {
            _vista.DetalleConfirmacionRecepcion = TareaServicio.ObtenerDetalleTareaRecepcionParaConfirmacion(e);
            foreach (var detalleTarea in _vista.DetalleConfirmacionRecepcion)
            {
                detalleTarea.MATERIAL_ID = detalleTarea.MATERIAL_ID.ToUpper();
                if (e.Tarea.IS_AUTHORIZED == 1)
                {
                    detalleTarea.ASIGNADO = detalleTarea.QTY;
                }
            }
        }

        private void ObtenerDetalleOrdenDeCompra(TareaArgumento e)
        {
            _vista.DetalleOrdenCompra = OrdenDeCompraServicio.ObtenerDetalleRecepcionOrdenDeCompra(e);
            foreach (var detalleOrdenCompra in _vista.DetalleOrdenCompra)
            {
                detalleOrdenCompra.MATERIAL_ID = detalleOrdenCompra.MATERIAL_ID.ToUpper();
                if (e.Tarea.IS_AUTHORIZED == 1)
                {
                    detalleOrdenCompra.PENDING = 0;
                }
            }
        }

        private void ObtenerDetalleRecepcionSeries(TareaArgumento e)
        {
            _vista.DetalleRecepcionSeries = OrdenDeCompraServicio.ObtenerDetalleRecepcionSerieDetalle(e);
        }

        private void ObtenerUltimoCorrelativo()
        {
            Operacion op = OrdenDeCompraServicio.ObtenerUltimoCorrelativoAsignado();
            if (op.Resultado == ResultadoOperacionTipo.Exito)
            {
                _vista.UltimoCorrelativo = Convert.ToInt32(op.DbData);
            }
            else
            {
                throw new Exception(op.Mensaje);
            }
        }

        private void _vista_UsuarioDeseaObtenerTareasConDetalleDeMaterial(object sender, TareaArgumento e)
        {
            try
            {
                ObtenerTareasConDetalleDeMaterial(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCancelarDetallesDeRecepcion(object sender, TareaArgumento e)
        {
            try
            {
                var tareaDetalle = _vista.TareaDetalle.FirstOrDefault();
                if (tareaDetalle == null) return;
                var op = TareaServicio.CancelarDetalleDeRecepcion(new TareaArgumento
                {

                    Tarea = new Tarea
                    {
                        CODIGO_POLIZA_SOURCE2 = tareaDetalle.CODIGO_POLIZA_SOURCE,
                        SERIAL_NUMBER = tareaDetalle.SERIAL_NUMBER
                    },
                    Razon = e.Razon,
                    Xml = ObtenerXmlDeListadoDeTareas(_vista.TareaDetalle.Where(td => td.IS_SELECTED).ToList())
                });
                if (op.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.RecargarVistas();
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_EnviarTareasAApi(object sender, TareaArgumento e)
        {
            try
            {
                e.ListaDeOperadores = e.ListaDeOperadores.Distinct().ToList();
                EnviarTareasAApi(e.ListaDeOperadores);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaCambiarDePrioridadALaTarea(object sender, TareaArgumento e)
        {
            try
            {
                var listaDeOperadores = new List<string>();
                BaseDeDatosServicio.BeginTransaction();
                foreach (var tarea in _vista.Tarea.ToList()
                    .Where(t => t.IS_SELECTED && t.IS_AUTHORIZED == (int)SiNo.No && t.IS_COMPLETED != Enums.GetStringValue(EstadoTarea.Completa)))
                {
                    var operacion = TareaServicio.CambiarPrioridadDeLaTarea(new TareaArgumento()
                    {
                        Tarea = tarea
                        ,
                        Priority = e.Priority
                    });

                    if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(operacion.Mensaje);
                    }
                    listaDeOperadores.Add(tarea.TASK_ASSIGNEDTO);
                }
                EnviarTareasAApi(listaDeOperadores);
                BaseDeDatosServicio.Commit();
                _vista.RecargarVistas();
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaReasignarTareaDeLineaDePicking(object sender, TareaArgumento e)
        {
            try
            {
                BaseDeDatosServicio.BeginTransaction();
                foreach (var tarea in _vista.Tarea.ToList()
                    .Where(
                        t =>
                            t.IS_SELECTED && t.IS_AUTHORIZED == (int)SiNo.No && t.IS_COMPLETE == (int)SiNo.No && t.IS_ACCEPTED == (int)SiNo.No
                            && t.TASK_TYPE == Enums.GetStringValue(TareasTipo.TareaPicking) && t.USE_PICKING_LINE == 1))
                {
                    var t = new Tarea
                    {
                        WAVE_PICKING_ID = tarea.WAVE_PICKING_ID
                    };

                    var op = TareaServicio.ReasignarTareaLineaDePicking(new TareaArgumento()
                    {
                        Linea = e.Linea
                        ,
                        Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                        ,
                        Tarea = t
                    });

                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(op.Mensaje);
                    }
                }
                BaseDeDatosServicio.Commit();
                _vista.RecargarVistas();
            }
            catch (Exception ex)
            {
                BaseDeDatosServicio.Rollback();
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea(object sender, TareaArgumento e)
        {
            try
            {
                var op =
                    TareaServicio.DistribuirTareaATodosLosOperadoresSinTarea(new TareaArgumento
                    {
                        Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    });

                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                }
                else
                {
                    _vista.RecargarVistas();
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaDistribuirTareasTodosLosOperadores(object sender, TareaArgumento e)
        {
            try
            {
                var op =
                    TareaServicio.DistribuirTareaATodosLosOperadores(new TareaArgumento
                    {
                        Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    });

                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                }
                else
                {
                    _vista.RecargarVistas();
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaAutorizarDocumentoErp(object sender, TareaArgumento e)
        {
            AutorizarDocumentosErp();
        }

        private void _vista_UsuarioDeseaOptenerOperadores(object sender, Argumentos.TareaArgumento e)
        {
            ObtenerOperadores();
        }

        private void _vista_UsuarioDeseaObtenerTiposDeTarea(object sender, Argumentos.TareaArgumento e)
        {
            ObtenerTipoDeTarea();
        }

        private void _vista_UsuarioDeseaAutorizarDocumentoErpRecepcion(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                TareaServicio.AutorizarDocumentoErpRecepcion(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaAutorizarDocumentoErpPicking(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                TareaServicio.AutorizarDocumentoErpPicking(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCambiarOperadorDeTareaConteo(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                var op = TareaServicio.CambiarOperadorDeTareaConteo(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCancelarDetallePicking(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                CancelarTarea();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                ObtenerTipoDeTarea();
                ObtenerOperadores();
                ObtenerClases();

                _vista.Lineas = BodegaServicio.ObtenerLineasDePickingAsociadasABodegaDelUsuario(new Bodega
                {
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                });

                _vista.Prioridades = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion()
                {
                    PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema),
                    PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.Prioridad)
                });

                _vista.Permisos = SeguridadServicio.ObtenerPermisosDeSeguridad(new SeguridadArgumento()
                {
                    Seguridad = new Seguridad()
                    {
                        PARENT = Swift3PlOpcionesWms.ADMIN_TAREAS.ToString()
                        ,
                        CATEGORY = Enums.GetStringValue(CategoriaPermisos.SeguridadDePantalla)
                        ,
                        LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                    }
                });

                _vista.PermisosPantalla = SeguridadServicio.ObtenerPermisosDeSeguridad(new SeguridadArgumento()
                {
                    Seguridad = new Seguridad()
                    {
                        PARENT = Swift3PlOpcionesWms.CS_ADMINISTRADOR_TAREA.ToString()
                        ,
                        CATEGORY = Enums.GetStringValue(CategoriaPermisos.SeguridadDePantalla)
                        ,
                        LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario()
                    }

                });

                _vista.ParametrosDeSistema =
                    ParametroServicio.ObtenerParametro(new ConsultaArgumento
                    {
                        GrupoParametro = Enums.GetStringValue(GrupoParametro.Sistema),
                        IdParametro = Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl)
                    });

                _vista.ParametrosAutorizacionTraslado =
                    ParametroServicio.ObtenerParametro(new ConsultaArgumento
                    {
                        GrupoParametro = Enums.GetStringValue(GrupoParametro.DemandaDePicking),
                        IdParametro = Enums.GetStringValue(IdParametro.AutorizacionEnvioErpTraslado)
                    });
                _vista.RazonesDetalleCanceladoDeRecepcion =
                    ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                    {
                        PARAM_GROUP = Enums.GetStringValue(GrupoParametro.Recepcion),
                        PARAM_TYPE = Enums.GetStringValue(IdParametro.RazonDetalleCancelado)
                    });
                _vista.RazonesDetalleLiberarInventarioConfirmado =
                    ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                    {
                        PARAM_GROUP = Enums.GetStringValue(GrupoParametro.RazonDetalleLiberacion),
                        PARAM_TYPE = Enums.GetStringValue(IdParametro.LiberacionInventario)
                    });

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerTareas(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                ObtenerTareas(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerOperadores(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                ObtenerOperadores();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDetalleDeTarea(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                _vista.TareaDetalle = TareaServicio.ObtenerTareaDetalle(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }


        private void _vista_UsuarioDeseaCambiarOperadorATarea(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                TareaServicio.CambiarOperadorDeTarea(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCambiarEstadoDeTarea(object sender, Argumentos.TareaArgumento e)
        {
            try
            {
                CambiarEstadoTarea(e.Tarea.IS_PAUSED);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }



        private void ObtenerClases()
        {
            try
            {
                var listaClases = ClaseServicio.ObtenerClases();
                listaClases.ForEach(c => c.IS_SELECTED = false);
                _vista.Clases = listaClases;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void ObtenerOperadores()
        {
            try
            {
                var listaOperadores = UsuarioServicio.ObtenerUsuariosTipoBodegaAsignadosAlUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
                foreach (var operador in listaOperadores)
                {
                    operador.IS_SELECTED = true;
                }
                _vista.Operadores = listaOperadores;
                _vista.ListaDeOperadores = listaOperadores;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void ObtenerTipoDeTarea()
        {
            try
            {
                var listaTiposDeTarea = ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                {
                    PARAM_GROUP = "TASK_TYPES"
                    ,
                    PARAM_TYPE = "SISTEMA"
                });
                foreach (var tipoDeTarea in listaTiposDeTarea)
                {
                    tipoDeTarea.IS_SELECTED = true;
                }
                _vista.TiposTareas = listaTiposDeTarea;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void ObtenerTareas(TareaArgumento e)
        {
            try
            {
                var listaDeTareasTemp = TareaServicio.ObtenerTareas(e);

                var listaTareas = new List<Tarea>();
                foreach (var tarea in listaDeTareasTemp)
                {
                    if (listaTareas.ToList()
                        .Exists(
                            t =>
                                ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null || tarea.SERIAL_NUMBER != 0) ?
                                ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null)
                                    ? t.WAVE_PICKING_ID == tarea.WAVE_PICKING_ID
                                    : t.SERIAL_NUMBER == tarea.SERIAL_NUMBER) : t.TASK_ID == tarea.TASK_ID))) continue;
                    {
                        tarea.DetalleErp = new List<TareaDetalleErp>();

                        foreach (var det in listaDeTareasTemp.Where(t => ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null || tarea.SERIAL_NUMBER != 0) ?
                                ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null)
                                    ? t.WAVE_PICKING_ID == tarea.WAVE_PICKING_ID
                                    : t.SERIAL_NUMBER == tarea.SERIAL_NUMBER) : t.TASK_ID == tarea.TASK_ID)))
                        {
                            if (tarea.DOC_ID == "") continue;
                            var detalleErp = new TareaDetalleErp
                            {
                                NO_DOC = det.NO_DOC
                                ,
                                PICKING_DEMAND_HEADER_ID = det.PICKING_DEMAND_HEADER_ID
                                ,
                                WMS_DOCUMENT_HEADER_ID = det.WMS_DOCUMENT_HEADER_ID
                                ,
                                DOC_ID = det.DOC_ID
                                ,
                                ATTEMPTED_WITH_ERROR = det.ATTEMPTED_WITH_ERROR
                                ,
                                IS_POSTED_ERP = det.IS_POSTED_ERP
                                ,
                                STATUS_POSTED_ERP = det.STATUS_POSTED_ERP
                                ,
                                POSTED_ERP = det.POSTED_ERP
                                ,
                                POSTED_RESPONSE = det.POSTED_RESPONSE
                                ,
                                ERP_REFERENCE = det.ERP_REFERENCE
                                ,
                                IS_AUTHORIZED = det.IS_AUTHORIZED
                                ,
                                MAX_ATTEMPTS = det.MAX_ATTEMPTS
                                ,
                                CODE_ROUTE = det.CODE_ROUTE
                                ,
                                USE_PICKING_LINE = det.USE_PICKING_LINE
                            };
                            tarea.DetalleErp.Add(detalleErp);
                        }
                        if (tarea.DetalleErp.Count() > 1)
                        {
                            tarea.DOC_ID_GRID = "";
                        }
                        else
                        {
                            if (tarea.DOC_ID == null)
                            {
                                tarea.DOC_ID_GRID = "";
                            }
                            else
                            {
                                tarea.DOC_ID_GRID = tarea.DOC_ID.ToString();
                            }
                        }
                        listaTareas.Add(tarea);
                    }
                }

                foreach (var tarea in listaTareas)
                {
                    if (tarea.DetalleErp.Count > 0)
                    {
                        tarea.COMPLETED_DOC_ERP = tarea.DetalleErp.Min(dE => dE.IS_POSTED_ERP);
                    }
                    tarea.COMPLETED_DOC_ERP = 0;
                }


                _vista.Tarea = listaTareas;
                _vista.TareaGraficas = TareaServicio.ObtenerTareasParaGraficas(e);
                _vista.TareaDetalle = new List<TareaDetalle>();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void ObtenerTareasConDetalleDeMaterial(TareaArgumento e)
        {
            try
            {
                var listaDeTareasTemp = TareaServicio.ObtenerTareasConDetalleDeMaterial(e);

                var listaTareas = new List<Tarea>();
                foreach (var tarea in listaDeTareasTemp)
                {
                    if (listaTareas.ToList()
                        .Exists(
                            t =>
                                ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null || tarea.SERIAL_NUMBER != 0) ?
                                ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null)
                                    ? t.WAVE_PICKING_ID == tarea.WAVE_PICKING_ID && t.MATERIAL_ID == tarea.MATERIAL_ID
                                    : t.SERIAL_NUMBER == tarea.SERIAL_NUMBER) : t.TASK_ID == tarea.TASK_ID))) continue;

                    tarea.DetalleErp = new List<TareaDetalleErp>();

                    foreach (var det in listaDeTareasTemp.Where(t => ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null || tarea.SERIAL_NUMBER != 0) ?
                            ((tarea.WAVE_PICKING_ID != 0 && tarea.WAVE_PICKING_ID != null)
                                ? t.WAVE_PICKING_ID == tarea.WAVE_PICKING_ID
                                : t.SERIAL_NUMBER == tarea.SERIAL_NUMBER) : t.TASK_ID == tarea.TASK_ID)))
                    {
                        if (tarea.DOC_ID == "") continue;
                        if (tarea.DetalleErp.Count() > 1)
                        {
                            tarea.DOC_ID_GRID = "";
                        }
                        else
                        {
                            tarea.DOC_ID_GRID = tarea.DOC_ID.ToString();
                        }
                        listaTareas.Add(tarea);
                    }
                }

                foreach (var tarea in listaTareas)
                {
                    if (tarea.DetalleErp.Count > 0)
                    {
                        tarea.COMPLETED_DOC_ERP = tarea.DetalleErp.Min(dE => dE.IS_POSTED_ERP);
                    }
                    tarea.COMPLETED_DOC_ERP = 0;
                }

                _vista.Tarea = listaTareas.Distinct().ToList();
                _vista.TareaGraficas = TareaServicio.ObtenerTareasParaGraficas(e);
                _vista.TareaDetalle = new List<TareaDetalle>();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void CambiarEstadoTarea(decimal estado)
        {
            try
            {
                var listaOperadores = new List<string>();

                var listaTareas = (_vista.Tarea.ToList().Where(t => t.IS_SELECTED)).ToList();
                foreach (var tarea in listaTareas)
                {
                    listaOperadores.Add(tarea.TASK_ASSIGNEDTO);
                    var op = new Operacion();
                    switch (tarea.TASK_TYPE.ToUpper())
                    {
                        case "TAREA_RECEPCION":
                            if (tarea.IS_PAUSED != estado)
                            {
                                var tar = new Tarea
                                {
                                    SERIAL_NUMBER = tarea.SERIAL_NUMBER,
                                    IS_PAUSED = estado
                                };
                                op = TareaServicio.CambiarEstadoDeTarea(new TareaArgumento { Tarea = tar });
                            }
                            break;
                        //case "TAREA_REUBICACION":
                        case "TAREA_PICKING":
                            if (tarea.IS_PAUSED != estado)
                            {
                                var tar = new Tarea
                                {
                                    WAVE_PICKING_ID = tarea.WAVE_PICKING_ID,
                                    IS_PAUSED = estado
                                };
                                op = TareaServicio.CambiarEstadoDeTarea(new TareaArgumento { Tarea = tar });

                            }
                            break;
                        case "TAREA_CONTEO_FISICO":
                            if (tarea.IS_COMPLETED.Equals("INCOMPLETA") || tarea.IS_COMPLETED.Equals("EN PROCESO"))
                            {
                                var tar = new Tarea
                                {
                                    TASK_ID = tarea.TASK_ID
                                    ,
                                    IS_PAUSED = estado
                                };
                                op = TareaServicio.CambiarEstadoTareaConteno(new TareaArgumento { Tarea = tar });

                            }
                            break;
                    }
                    if (op.Resultado != ResultadoOperacionTipo.Error)
                    {
                        tarea.IS_PAUSED = estado;
                        tarea.IS_PAUSED_DESCRIPTION = (estado == 0) ? "NO" : "SI";
                    }
                    else
                    {
                        InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                        break;
                    }
                }

                listaOperadores = listaOperadores.Distinct().ToList();
                EnviarTareasAApi(listaOperadores);

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void CancelarTarea()
        {
            try
            {
                var listaOperadores = new List<string>();

                var contador = 0;
                if (_vista.EsDetallePicking && _vista.TareaDetalle.ToList().Exists(t => t.IS_SELECTED))
                {
                    if (_vista.EsDetallePicking)
                    {
                        foreach (
                            var tarea in
                            _vista.TareaDetalle.ToList()
                                .Where(
                                    t =>
                                        t.IS_SELECTED && (t.STATUS.Equals("INCOMPLETA") || t.STATUS.Equals("ACEPTADA")) &&
                                        t.IN_PICKING_LINE != 1))
                        {
                            var t = new Tarea
                            {
                                WAVE_PICKING_ID = tarea.WAVE_PICKING_ID
                                ,
                                MATERIAL_ID = tarea.MATERIAL_ID
                            };
                            var op =
                                TareaServicio.CancelarDetallePicking(new TareaArgumento
                                {
                                    Tarea = t,
                                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                                });
                            if (op.Resultado == ResultadoOperacionTipo.Error)
                            {
                                throw new Exception(op.Mensaje);
                            }
                            contador++;
                            listaOperadores.Add(tarea.ASSIGNED_TO);
                        }
                    }

                }
                else if (_vista.Tarea.ToList().Exists(t => t.IS_SELECTED))
                {
                    foreach (var tarea in _vista.Tarea.ToList().Where(t => t.IS_SELECTED && t.IS_AUTHORIZED == (int)SiNo.No && (t.IS_ACCEPTED == (int)SiNo.No || t.TASK_SUBTYPE == Enums.GetStringValue(SubTipoTarea.DevolucionDeFactura))))
                    {
                        var op = new Operacion();
                        var t = new Tarea();
                        switch (tarea.TASK_TYPE.ToUpper())
                        {
                            case "TAREA_RECEPCION":
                                t.SERIAL_NUMBER = tarea.SERIAL_NUMBER;
                                op = tarea.TASK_SUBTYPE == Enums.GetStringValue(SubTipoTarea.DevolucionDeFactura)
                                    ? TareaServicio.CancelarTareaDeRecepcionPorDevolucionDeFactura(new TareaArgumento { Tarea = t, Login = InteraccionConUsuarioServicio.ObtenerUsuario() })
                                    : TareaServicio.CancelarTareaRecepcion(new TareaArgumento { Tarea = t, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                                listaOperadores.Add(tarea.TASK_ASSIGNEDTO);
                                break;

                            case "TAREA_PICKING":
                            case "TAREA_REUBICACION":
                                if (tarea.IS_PAUSED <= (int)SiNo.Si && tarea.USE_PICKING_LINE != (int)SiNo.Si)
                                {
                                    t.WAVE_PICKING_ID = tarea.WAVE_PICKING_ID;
                                    op = TareaServicio.CancelarTareaPorOla(new TareaArgumento { Tarea = t, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                                    listaOperadores.Add(tarea.TASK_ASSIGNEDTO);
                                }
                                else if (tarea.IS_PAUSED <= (int)SiNo.Si && tarea.USE_PICKING_LINE == (int)SiNo.Si)
                                {
                                    t.WAVE_PICKING_ID = tarea.WAVE_PICKING_ID;
                                    op = TareaServicio.CancelarTareaLineaDePicking(new TareaArgumento { Tarea = t, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                                    listaOperadores.Add(tarea.TASK_ASSIGNEDTO);
                                }
                                break;
                            case "TAREA_CONTEO_FISICO":
                                if (tarea.IS_COMPLETED.Equals("INCOMPLETA"))
                                {
                                    t.TASK_ID = tarea.TASK_ID;
                                    op = TareaServicio.CancelarTareaConteo(new TareaArgumento { Tarea = t, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                                    listaOperadores.Add(tarea.TASK_ASSIGNEDTO);
                                }
                                break;
                        }
                        if (op.Resultado == ResultadoOperacionTipo.Error)
                        {
                            throw new Exception(op.Mensaje);
                        }
                        contador++;
                    }
                }

                listaOperadores = listaOperadores.Distinct().ToList();
                EnviarTareasAApi(listaOperadores);

                if (contador > 0)
                {
                    _vista.RecargarVistas();
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private bool ConfirmacionEnviarERP()
        {
            return XtraMessageBox.Show("¿Está seguro de que desea enviar la tarea a ERP?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void AutorizarDocumentosErp()
        {
            try
            {
                var contador = 0;
                foreach (var tarea in _vista.Tarea.ToList().Where(t => t.IS_SELECTED
                    && (t.TASK_TYPE.ToUpper().Equals("TAREA_PICKING") || t.TASK_TYPE.ToUpper().Equals("TAREA_RECEPCION") || t.TASK_TYPE.ToUpper().Equals("TAREA_CONTEO_FISICO"))
                    && (t.TASK_SUBTYPE == "TAREA_CONTEO_FISICO" || t.IS_FROM_SONDA.ToUpper().Equals("SI") || t.TASK_SUBTYPE == "RECEPCION_TRASLADO" || t.IS_FROM_ERP.ToUpper().Equals("SI"))
                    && (t.IS_COMPLETED.ToUpper().Equals("COMPLETA") || t.TASK_SUBTYPE == "TAREA_CONTEO_FISICO")
                    && t.DetalleErp.Exists(td => td.IS_POSTED_ERP != 1 || td.ATTEMPTED_WITH_ERROR == td.MAX_ATTEMPTS || t.TASK_SUBTYPE == "TAREA_CONTEO_FISICO")))
                {
                    var op = new Operacion() { Resultado = ResultadoOperacionTipo.Exito };
                    switch (tarea.TASK_TYPE.ToUpper())
                    {
                        case "TAREA_PICKING":
                            op = TareaServicio.AutorizarDocumentoErpPicking(
                                new TareaArgumento
                                {
                                    Tarea = tarea,
                                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                                });
                            break;
                        case "TAREA_RECEPCION":
                            if (tarea.TASK_SUBTYPE == Enums.GetStringValue(SubTipoTarea.DevolucionDeFactura))
                            {
                                op = TareaServicio.ValidarAutorizacionDeRecepcionPorDevolucion(
                                    new TareaArgumento
                                    {
                                        Tarea = tarea,
                                        Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                                    });
                                if (op.Resultado == ResultadoOperacionTipo.Error)
                                {
                                    throw new Exception(op.Mensaje);
                                }
                            }

                            op = TareaServicio.AutorizarDocumentoErpRecepcion(
                                new TareaArgumento
                                {
                                    Tarea = tarea,
                                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                                });
                            break;
                        case "TAREA_CONTEO_FISICO":

                            if (ConfirmacionEnviarERP())
                            {
                                op = TareaServicio.AutorizarDocumentoErpConteoFisico(
                               new TareaArgumento
                               {
                                   Tarea = tarea,
                                   Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                               });
                            }

                            break;
                    }
                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(op.Mensaje);
                    }
                    contador++;
                }
                if (contador > 0)
                {
                    _vista.RecargarVistas();
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void EnviarTareasAApi(IList<string> listaDeOperadores)
        {
            if (!SeEnvianTareasAlApi()) return;
            if (listaDeOperadores.Count <= 0) return;

            var op =
                Rest.ExecutePost<Operacion>(
                    $"{InteraccionConUsuarioServicio.ObtenerDireccionBaseDeApi()}{RutasApi.Tareas.EnviarTareas}",
                    new ListaOperadorParaActualizacionDeTarea
                    {
                        loginId = InteraccionConUsuarioServicio.ObtenerUsuarioYDominio(),
                        password = InteraccionConUsuarioServicio.ObtenerClaveDeUsuario(),
                        dbUser = InteraccionConUsuarioServicio.ObtenerUsuarioDeBaseDeDatos(),
                        dbPassword = InteraccionConUsuarioServicio.ObtenerContraseniaDeBaseDeDatos(),
                        serverIp = InteraccionConUsuarioServicio.ObtenerServerIp(),
                        operators = listaDeOperadores
                    });

            if (op.Resultado == ResultadoOperacionTipo.Error)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al enviar las tareas hacia el dispositivo móvil debido a: {op.Mensaje}");
            }
        }

        private bool SeEnvianTareasAlApi()
        {
            var parametro =
                _vista.ParametrosDeSistema.FirstOrDefault(p => p.GROUP_ID == Enums.GetStringValue(GrupoParametro.Sistema) && p.PARAMETER_ID == Enums.GetStringValue(IdParametro.TipoDeClienteMovilDe3Pl));
            return (parametro != null && int.Parse(parametro.VALUE) == 1);
        }

        private static string ObtenerXmlDeListadoDeTareas(List<TareaDetalle> listaTareaDetalles)
        {
            var serializador = new XmlSerializer(typeof(List<TareaDetalle>));
            var escritorDeDocumentos = new StringWriter();
            var escritorXml = new XmlTextWriter(escritorDeDocumentos) { Formatting = Formatting.Indented };
            serializador.Serialize(escritorXml, listaTareaDetalles);
            return escritorDeDocumentos.ToString();
        }

    }
}
