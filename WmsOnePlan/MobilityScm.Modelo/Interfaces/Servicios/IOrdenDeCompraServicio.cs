using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Vertical.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IOrdenDeCompraServicio
    {
        IList<OrdenDeCompraDetalle> ObtenerDetalleRecepcionOrdenDeCompra(TareaArgumento tareaArgumento);
        Operacion GuardarConfirmacionRecepcionErp(IList<OrdenDeCompraDetalle> detalle, IList<SerieRecepcionDetalle> detalleSeries, string login, int taskId);
        IList<SerieRecepcionDetalle> ObtenerDetalleRecepcionSerieDetalle(TareaArgumento tareaArgumento);
        Operacion ObtenerUltimoCorrelativoAsignado();

        Operacion ValidarSiTodosLosDocumentosHanSidoEnviadosAErp(int taskId);

        Operacion DesbloquearInventarioParaTareasEnviadasAErpFallidas(TareaArgumento tareaArgumento);

        Operacion DesbloquearTransaccionOperacionManual(TareaArgumento tareaArgumento);

        Operacion CrearTareaRectificacionMP(TareaArgumento tareaArgumento);

        Operacion AutorizarControlDeCalidad(TareaArgumento tareaArgumento);

    }
}
