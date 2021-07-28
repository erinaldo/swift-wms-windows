using MobilityScm.Modelo.Argumentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Vistas
{
    public interface IAdministradorDeTareasVista
    {
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerTareas;
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerTareasConDetalleDeMaterial;
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerDetalleDeTarea;
        event EventHandler<TareaArgumento> UsuarioDeseaCambiarEstadoDeTarea;
        event EventHandler<TareaArgumento> UsuarioDeseaCambiarOperadorATarea;
        event EventHandler<TareaArgumento> UsuarioDeseaCancelarDetallePicking;
        event EventHandler<TareaArgumento> UsuarioDeseaCambiarOperadorDeTareaConteo;
        event EventHandler<TareaArgumento> UsuarioDeseaAutorizarDocumentoErp;
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerTiposDeTarea;
        event EventHandler<TareaArgumento> UsuarioDeseaOptenerOperadores;
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerOperadores;
        event EventHandler<TareaArgumento> UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea;
        event EventHandler<TareaArgumento> UsuarioDeseaDistribuirTareasTodosLosOperadores;
        event EventHandler<TareaArgumento> UsuarioDeseaReasignarTareaDeLineaDePicking;
        event EventHandler<TareaArgumento> UsuarioDeseaCambiarDePrioridadALaTarea;
        event EventHandler<TareaArgumento> EnviarTareasAApi;
        event EventHandler<TareaArgumento> UsuarioDeseaCancelarDetallesDeRecepcion;
        event EventHandler VistaCargandosePorPrimeraVez;

        event EventHandler<TareaArgumento> UsuarioDeseaMostrarPantallaConfirmacionRecepcion;
        event EventHandler<TareaArgumento> UsuarioDeseaGuardarConfirmacionReception;
        event EventHandler<TareaArgumento> UsuarioDeseaConfirmarFilaDeRecepcionRecibida;
        event EventHandler<TareaArgumento> UsuarioDeseaActualizarCantidadConfirmadaManualmente;
        event EventHandler<TareaArgumento> UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries;
        event EventHandler<TareaArgumento> UsuarioDeseaLiberarInventarioConfirmado;
        event EventHandler<TareaArgumento> UsuarioDeseaLiberarTransaccionConfirmado;
        event EventHandler<TareaArgumento> UsuarioDeseaValidarVisibilidadDeBoton;
        event EventHandler<TareaArgumento> UsuarioDeseaAutorizarControlDeCalidad;
        event EventHandler<TareaArgumento> UsuarioDeseaRecargarGridOrdenDeCompra;
        event EventHandler<TareaArgumento> UsuarioDeseaObtenerDetalleOlaPicking;
        event EventHandler<TareaArgumento> UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking;
        event EventHandler<TareaArgumento> UsuarioDeseaReabrirTareaRecepcion;
        event EventHandler<TareaArgumento> UsuarioDeseaCrearTareaDeRectificacionMP;

        IList<TareaDetalle> DetalleConfirmacionRecepcion { get; set; }
        IList<OrdenDeCompraDetalle> DetalleOrdenCompra { get; set; }
        IList<SerieRecepcionDetalle> DetalleRecepcionSeries { get; set; }
        IList<Tarea> DetalleLicenciasOla { get; set; }

        IList<Tarea> Tarea { get; set; }
        IList<Tarea> TareaGraficas { get; set; }
        IList<TareaDetalle> TareaDetalle { get; set; }
        IList<Usuario> Operadores { get; set; }
        IList<Entidades.Configuracion> TiposTareas { get; set; }
        IList<Usuario> ListaDeOperadores { get; set; }
        IList<Clase> Clases { get; set; }
        IList<Entidades.Configuracion> Lineas { get; set; }
        IList<Entidades.Configuracion> Prioridades { get; set; }
        IList<Seguridad> Permisos { get; set; }
        IList<Seguridad> PermisosPantalla { get; set; }
        IList<Parametro> ParametrosDeSistema { get; set; }
        IList<Parametro> ParametrosAutorizacionTraslado { get; set; }

        IList<Bodega> BodegasUsuario { get; set; }
        IList<BodegaERP> BodegasERP { get; set; }

        IList<Entidades.Configuracion> RazonesDetalleCanceladoDeRecepcion { get; set; }
        IList<Entidades.Configuracion> RazonesDetalleLiberarInventarioConfirmado { get; set; }
        int UltimoCorrelativo { get; set; }
        bool EsDetallePicking { get; }
        bool EsDetalleRecepcion { get; }
        bool DebeMostrarBotonParaLiberarInventario { get; set; }
        bool DebeMostrarBotonParaLiberarTransaccion { get; set; }
        bool DebeMostrarBotonCrearTareaDeRectificacion { get; set; }
        bool DebeMostrarBotonParaAutorizarQA { get; set; }
        bool PermisoPuedeLiberarInventario { get; set; }
        void RecargarVistas();
    }
}

