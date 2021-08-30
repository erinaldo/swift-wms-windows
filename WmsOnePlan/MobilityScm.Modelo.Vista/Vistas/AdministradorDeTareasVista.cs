using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.DataAccess.Native.Sql.QueryBuilder;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Drawing.Imaging;
using MobilityScm.Modelo.Estados;
using DevExpress.XtraLayout;
using MobilityScm.Modelo.Popups;
using MobilityScm.Modelo.Tipos;
using DevExpress.XtraGrid;

namespace MobilityScm.Modelo.Vistas
{
    public partial class AdministradorDeTareasVista : VistaBase, IAdministradorDeTareasVista
    {

        #region Eventos

        public event EventHandler<TareaArgumento> UsuarioDeseaAutorizarDocumentoErp;
        public event EventHandler<TareaArgumento> UsuarioDeseaCambiarEstadoDeTarea;
        public event EventHandler<TareaArgumento> UsuarioDeseaCambiarOperadorATarea;
        public event EventHandler<TareaArgumento> UsuarioDeseaCambiarOperadorDeTareaConteo;
        public event EventHandler<TareaArgumento> UsuarioDeseaCancelarDetallePicking;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerDetalleDeTarea;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerOperadores;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerTareas;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerTiposDeTarea;
        public event EventHandler<TareaArgumento> UsuarioDeseaOptenerOperadores;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<TareaArgumento> UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea;
        public event EventHandler<TareaArgumento> UsuarioDeseaDistribuirTareasTodosLosOperadores;
        public event EventHandler<TareaArgumento> UsuarioDeseaReasignarTareaDeLineaDePicking;
        public event EventHandler<TareaArgumento> UsuarioDeseaCambiarDePrioridadALaTarea;
        public event EventHandler<TareaArgumento> EnviarTareasAApi;
        public event EventHandler<TareaArgumento> UsuarioDeseaCancelarDetallesDeRecepcion;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerTareasConDetalleDeMaterial;

        public event EventHandler<TareaArgumento> UsuarioDeseaMostrarPantallaConfirmacionRecepcion;
        public event EventHandler<TareaArgumento> UsuarioDeseaGuardarConfirmacionReception;
        public event EventHandler<TareaArgumento> UsuarioDeseaConfirmarFilaDeRecepcionRecibida;
        public event EventHandler<TareaArgumento> UsuarioDeseaActualizarCantidadConfirmadaManualmente;
        public event EventHandler<TareaArgumento> UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries;
        public event EventHandler<TareaArgumento> UsuarioDeseaLiberarInventarioConfirmado;
        public event EventHandler<TareaArgumento> UsuarioDeseaLiberarTransaccionConfirmado;
        public event EventHandler<TareaArgumento> UsuarioDeseaValidarVisibilidadDeBoton;
        public event EventHandler<TareaArgumento> UsuarioDeseaAutorizarControlDeCalidad;
        public event EventHandler<TareaArgumento> UsuarioDeseaRecargarGridOrdenDeCompra;
        public event EventHandler<TareaArgumento> UsuarioDeseaObtenerDetalleOlaPicking;
        public event EventHandler<TareaArgumento> UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking;
        public event EventHandler<TareaArgumento> UsuarioDeseaReabrirTareaRecepcion;
        public event EventHandler<TareaArgumento> UsuarioDeseaCrearTareaDeRectificacionMP;

        #endregion

        #region Propiedades
        bool isAsignoTodo = false;

        public bool DebeMostrarBotonParaLiberarInventario
        {
            get { return UIBotonLiberarInventario.Visibility == DevExpress.XtraBars.BarItemVisibility.Always; }
            set
            {
                if (value)
                {
                    UIBotonLiberarInventario.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    UIBotonLiberarInventario.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }


        public bool DebeMostrarBotonParaLiberarTransaccion
        {
            get { return UIBotonLiberarTransaccion.Visibility == DevExpress.XtraBars.BarItemVisibility.Always; }
            set
            {
                if (value)
                {
                    UIBotonLiberarTransaccion.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    UIBotonLiberarTransaccion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        public bool DebeMostrarBotonCrearTareaDeRectificacion
        {
            get { return UIBotonCrearTareaRectificacion.Visibility == DevExpress.XtraBars.BarItemVisibility.Always; }
            set
            {
                if (value)
                {
                    UIBotonCrearTareaRectificacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    UIBotonCrearTareaRectificacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        public bool DebeMostrarBotonParaAutorizarQA
        {
            get { return UIBotonAutorizarQA.Visibility == DevExpress.XtraBars.BarItemVisibility.Always; }
            set
            {
                if (value)
                {
                    UIBotonAutorizarQA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    UIBotonAutorizarQA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        public bool PermisoPuedeLiberarInventario
        {
            get; set;
        }

        public bool PermisoPuedeConfirmarRecepcion
        {
            get; set;
        }

        public bool PermisoPuedeAutorizarControlDeCalidad
        {
            get; set;
        }

        public IList<Tarea> DetalleLicenciasOla
        {
            get { return (IList<Tarea>)UIContenedorOla.DataSource; }
            set
            {
                UIContenedorOla.DataSource = value;
            }
        }

        public IList<TareaDetalle> DetalleConfirmacionRecepcion
        {
            get { return (IList<TareaDetalle>)UiContenedorVistaConfirmacionDetalleRecepcion.DataSource; }
            set
            {
                UiContenedorVistaConfirmacionDetalleRecepcion.DataSource = value;
            }
        }

        public IList<SerieRecepcionDetalle> DetalleRecepcionSeries
        {
            get { return (IList<SerieRecepcionDetalle>)UIContenedorVistaConfirmacionSeries.DataSource; }
            set
            {
                UIContenedorVistaConfirmacionSeries.DataSource = value;
            }
        }

        public IList<OrdenDeCompraDetalle> DetalleOrdenCompra
        {
            get { return (IList<OrdenDeCompraDetalle>)UiContenedorVistaConfirmacionOrdenDeCompra.DataSource; }
            set
            {
                UiContenedorVistaConfirmacionOrdenDeCompra.DataSource = value;
            }
        }

        public IList<Usuario> Operadores
        {
            get { return (IList<Usuario>)UiListaOperadores.DataSource; }
            set
            {
                UiListaOperadores.DataSource = value;
            }
        }

        public IList<Bodega> BodegasUsuario
        {
            get { return (IList<Bodega>)UiLookUpEditBodegaERP.DataSource; }
            set
            {
                UiLookUpEditBodegaERP.DataSource = value;
            }
        }


        public IList<BodegaERP> BodegasERP
        {
            get { return (IList<BodegaERP>)UiLookUpEditBodegaERP.DataSource; }
            set
            {
                UiLookUpEditBodegaERP.DataSource = value;
            }
        }
        public int UltimoCorrelativo
        {
            get { return UIUltimoCorrelativo.Caption == "" ? -1 : Convert.ToInt32(UIUltimoCorrelativo.Caption); }
            set { UIUltimoCorrelativo.Caption = value.ToString(); }
        }

        public IList<Usuario> ListaDeOperadores
        {
            get { return (IList<Usuario>)UiListaDeOperadores.Properties.DataSource; }
            set
            {
                UiListaOperadoresEncabezado.DataSource = value;
                UiListaOperadoresParaPickingDetalle.DataSource = value;
                UiListaOperadoresParaReubicacionDetalle.DataSource = value;
                UiListaOperadoresParaConteo.DataSource = value;
                UiListaDeOperadores.Properties.DataSource = value;
            }
        }

        public IList<Tarea> Tarea
        {
            get { return (List<Tarea>)UiContenedorVistaTareasEncabezado.DataSource; }
            set
            {
                UiContenedorVistaTareasEncabezado.DataSource = value;

            }
        }

        public IList<TareaDetalle> TareaDetalle
        {
            get { return (IList<TareaDetalle>)UiContenedorDetalle.DataSource; }
            set
            {
                UiContenedorDetalle.DataSource = value;
            }
        }

        public IList<Entidades.Configuracion> TiposTareas
        {
            get { return (IList<Entidades.Configuracion>)UIListaTiposDeTarea.Properties.DataSource; }
            set { UIListaTiposDeTarea.Properties.DataSource = value; }
        }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public bool UsuarioSeleccionoListaTiposDeTareaCompleta { get; set; }

        public bool UsuarioSeleccionoListaDeOperadoresCompleta { get; set; }

        public bool UsuarioSeleccionoListaDeClasesCompleta { get; set; }

        public bool UsuarioSeleccionoVistaTareaEncabezadoCompleta { get; set; }

        public bool UsuarioSeleccionoVistaTareaDetalleCompleta { get; set; }

        public bool UsuarioSeleccionoVistaTareaDetalleCompletaDeRecepcion { get; set; }

        public bool UsuarioSeleccionoVistaEncabezadoDetalladoCompleta { get; set; }

        public bool TieneKitsIncompletos { get; set; }

        private Series selectedSeries { get; set; }

        Dictionary<string, Image> photos = new Dictionary<string, Image>();

        public IList<Tarea> TareaGraficas { get; set; }

        private Usuario operadorSeleccionado = null;
        private Tarea ultimoRegistro = null;
        private Tarea registroConfirmacionRecepcion = null;
        private TareaDetalle tareaParaConfirmarSeleccionada = null;

        public bool EsDetallePicking => UiContenedorDetalle.MainView.Name.Equals("UiVistaDetallePicking");
        public bool EsDetalleRecepcion => UiContenedorDetalle.MainView.Name.Equals("UiVistaDetalleRecepcion");

        public IList<Clase> Clases
        {
            get { return (IList<Clase>)UiListaDeClases.Properties.DataSource; }
            set { UiListaDeClases.Properties.DataSource = value; }
        }

        public IList<Entidades.Configuracion> Lineas { get; set; }

        public IList<Entidades.Configuracion> Prioridades { get; set; }

        public IList<Seguridad> Permisos { get; set; }
        public IList<Seguridad> PermisosPantalla { get; set; }

        public IList<Parametro> ParametrosDeSistema { get; set; }
        public IList<Parametro> ParametrosAutorizacionTraslado { get; set; }


        public IList<Entidades.Configuracion> RazonesDetalleCanceladoDeRecepcion
        {
            get; set;

        }

        public IList<Entidades.Configuracion> RazonesDetalleLiberarInventarioConfirmado
        {
            get; set;
        }

        #endregion

        #region Contructor y Eventos de Carga

        public AdministradorDeTareasVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<ITareaServicio, TareaServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeCompraServicio, OrdenDeCompraServicio>();
            Mvx.Ioc.RegisterType<IUsuarioServicio, UsuarioServicio>();
            Mvx.Ioc.RegisterType<IClaseServicio, ClaseServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<ISeguridadServicio, SeguridadServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();

            Mvx.Ioc.RegisterSingleton<IAdministradorDeTareasVista, AdministradorDeTareasVista>(this);
            Mvx.Ioc.RegisterType<IAdministradorDeTareasControlador, AdministradorDeTareasControlador>();
            Mvx.Ioc.Resolve<IAdministradorDeTareasControlador>();
        }

        private void AdministradorDeTareasVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaInicial.EditValue = DateTime.Now.Date + (new TimeSpan(0, 0, 0));
            UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
            CargarOGuardarDisenios(UiContenedorVistaTareasEncabezado, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorDetalle, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiVistaEncabezadoConDetalle, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaConfirmacionDetalleRecepcion, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaConfirmacionOrdenDeCompra, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UIContenedorOla, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);

            if (Permisos != null || Permisos.Count != 0)
            {
                var permisoPrioridad = Permisos.FirstOrDefault(p => p.CHECK_ID == Enums.GetStringValue(Permiso.CambiarPrioridadDeTareas));
                if (permisoPrioridad != null) UiBotonCambiarPrioridad.Visible = true;
                var permisoLiberarInventario = Permisos.FirstOrDefault(p => p.CHECK_ID == Enums.GetStringValue(Permiso.PuedeLiberarInventario));
                if (permisoLiberarInventario != null)
                {
                    PermisoPuedeLiberarInventario = true;
                }
                else
                {
                    PermisoPuedeLiberarInventario = false;
                }

                var permisoAutorizarControlDeCalidad = Permisos.FirstOrDefault(p => p.CHECK_ID == Enums.GetStringValue(Permiso.PuedeAutorizarControlDeCalidad));
                if (permisoAutorizarControlDeCalidad != null)
                {
                    PermisoPuedeAutorizarControlDeCalidad = true;
                }
                else
                {
                    PermisoPuedeAutorizarControlDeCalidad = false;
                }
            }


            if (PermisosPantalla != null || PermisosPantalla.Count != 0)
            {
                var permisoConfirmarTareaRecepcion = PermisosPantalla.FirstOrDefault(p => p.CHECK_ID == Enums.GetStringValue(Permiso.PuedeConfirmarRecepcion));
                if (permisoConfirmarTareaRecepcion != null)
                {
                    PermisoPuedeConfirmarRecepcion = true;
                }
                else
                {
                    PermisoPuedeConfirmarRecepcion = false;
                }
            }

        }




        #endregion

        #region Tareas

        #region Eventos de Controles

        private void UiListaVistaTipoDeTarea_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Entidades.Configuracion)UiListaVistaTipoDeTarea.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaTiposDeTareaCompleta)
                {
                    for (var i = 0; i < UiListaVistaTipoDeTarea.RowCount; i++)
                    {
                        var documento = (Entidades.Configuracion)UiListaVistaTipoDeTarea.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaTipoDeTarea.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaTiposDeTareaCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaTiposDeTarea();
        }

        private void UiListaVistaTipoDeTarea_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaTiposDeTareaCompleta = true;
            }
        }

        private void UiListaVistaTipoDeTarea_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaTipoDeTarea.RowCount; i++)
            {
                var documento = (Entidades.Configuracion)UiListaVistaTipoDeTarea.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaTipoDeTarea.SelectRow(i);
                }
            }
        }

        private void UIListaTiposDeTarea_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaTiposDeTarea();
        }

        private void UILista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBotonRefrescar-TiposDeTarea":
                    UsuarioDeseaObtenerTiposDeTarea?.Invoke(sender, new TareaArgumento());
                    break;
                case "UiBotonRefrescar-Operadores":
                    UsuarioDeseaObtenerTiposDeTarea?.Invoke(sender, new TareaArgumento());
                    break;
            }
        }

        private void UiListaVistaDeOperadores_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Usuario)UiListaVistaDeOperadores.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaDeOperadoresCompleta)
                {
                    for (var i = 0; i < UiListaVistaDeOperadores.RowCount; i++)
                    {
                        var documento = (Usuario)UiListaVistaDeOperadores.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiListaVistaDeOperadores.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaDeOperadoresCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaDeOperadores();
        }

        private void UiListaVistaDeOperadores_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeOperadoresCompleta = true;
            }
        }

        private void UiListaVistaDeOperadores_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaDeOperadores.RowCount; i++)
            {
                var documento = (Usuario)UiListaVistaDeOperadores.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiListaVistaDeOperadores.SelectRow(i);
                }
            }
        }

        private void UiListaDeOperadores_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaDeOperadores();
        }

        private void UiGrupoRadioFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UiGrupoRadioFechas.SelectedIndex)
            {
                case 0:
                    UiFechaInicial.EditValue = DateTime.Now.Date + (new TimeSpan(0, 0, 0));
                    UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
                    break;
                case 1:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddDays(-1) + (new TimeSpan(0, 0, 0));
                    UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
                    break;
                case 2:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddDays(-7) + (new TimeSpan(0, 0, 0));
                    UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
                    break;
                case 3:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-1) + (new TimeSpan(0, 0, 0));
                    UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
                    break;
                case 4:
                    UiFechaInicial.EditValue = DateTime.Now.Date.AddMonths(-3) + (new TimeSpan(0, 0, 0));
                    UiFechaFinal.EditValue = DateTime.Now.Date + (new TimeSpan(23, 59, 59));
                    break;
            }
        }

        private void UiBotonAceptarRangoFecha_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerTareas();
                UiVistaEncabezado.ExpandAllGroups();
                UiVistaEncabezadoConDetalle.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaEncabezado_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0) return;
                var registro = (Tarea)UiVistaEncabezado.GetRow(e.RowHandle);
                ultimoRegistro = registro;
                CargarDetalles();

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void UiVistaEncabezado_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Column.Name == "UiColAsignadoEncabezado")
            {
                string nombre = e.Value.ToString();
                var lstOperador = Operadores.FirstOrDefault(x => x.LOGIN_ID == e.Value.ToString());
                if (lstOperador != null)
                {
                    nombre = lstOperador.LOGIN_NAME;
                }
                e.DisplayText = nombre;
            }
        }
        private void UiListaOperadoresEncabezado_QueryPopUp(object sender, CancelEventArgs e)
        {

            if (UiVistaEncabezado.FocusedRowHandle < 0) return;
            var registro = (Tarea)UiVistaEncabezado.GetRow(UiVistaEncabezado.FocusedRowHandle);
            e.Cancel = !(registro.TASK_TYPE.Equals("TAREA_RECEPCION") && !registro.IS_COMPLETED.Equals("COMPLETA"));
        }

        private void UiListaOperadoresEncabezado_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                var listaOperadores = new List<string>();

                if (UiVistaEncabezado.FocusedRowHandle < 0) return;

                if (!ConfirmacionReAsignarTarea())
                {
                    e.Cancel = true;
                    return;
                }
                var registro = (Tarea)UiVistaEncabezado.GetRow(UiVistaEncabezado.FocusedRowHandle);
                registro.TASK_ASSIGNEDTO = e.NewValue.ToString();
                CambiarOperadorATarea(registro);
                if (!string.IsNullOrEmpty(e.OldValue.ToString()))
                    listaOperadores.Add(e.OldValue.ToString());
                listaOperadores.Add(e.NewValue.ToString());


                EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }

        }

        private void UiListaOperadoresParaPickingDetalle_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (UiVistaDetallePicking.FocusedRowHandle < 0) return;
            var registro = (TareaDetalle)UiVistaDetallePicking.GetRow(UiVistaDetallePicking.FocusedRowHandle);
            e.Cancel = registro.STATUS.Equals("COMPLETA");
        }

        private void UiListaOperadoresParaPickingDetalle_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (UiVistaDetallePicking.FocusedRowHandle < 0) return;

            if (!ConfirmacionReAsignarTarea())
            {
                e.Cancel = true;
                return;
            }
            var registro = (TareaDetalle)UiVistaDetallePicking.GetRow(UiVistaDetallePicking.FocusedRowHandle);
            if (registro.IN_PICKING_LINE == (int)SiNo.No)
            {
                var tarea = new Tarea
                {
                    WAVE_PICKING_ID = registro.WAVE_PICKING_ID
                       ,
                    MATERIAL_ID = registro.MATERIAL_ID
                       ,
                    TASK_ASSIGNEDTO = e.NewValue.ToString()
                };

                var listaOperadores = new List<string>();

                if (!string.IsNullOrEmpty(e.OldValue.ToString()))
                    listaOperadores.Add(e.OldValue.ToString());
                listaOperadores.Add(e.NewValue.ToString());

                CambiarOperadorATarea(tarea);
                EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
            }

        }

        private void UiListaOperadoresParaReubicacionDetalle_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (UiVistaDetalleReubicacion.FocusedRowHandle < 0) return;
            var registro = (TareaDetalle)UiVistaDetalleReubicacion.GetRow(UiVistaDetalleReubicacion.FocusedRowHandle);
            e.Cancel = registro.STATUS.Equals("COMPLETA");
        }

        public void UiListaOperadoresParaReubicacionDetalle_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (UiVistaDetalleReubicacion.FocusedRowHandle < 0) return;

            if (!ConfirmacionReAsignarTarea())
            {
                e.Cancel = true;
                return;
            }
            var registro = (TareaDetalle)UiVistaDetalleReubicacion.GetRow(UiVistaDetalleReubicacion.FocusedRowHandle);
            var tarea = new Tarea
            {
                WAVE_PICKING_ID = registro.WAVE_PICKING_ID
                ,
                MATERIAL_ID = registro.MATERIAL_ID
                ,
                TASK_ASSIGNEDTO = e.NewValue.ToString()
            };

            var listaOperadores = new List<string>();

            if (!string.IsNullOrEmpty(e.OldValue.ToString()))
                listaOperadores.Add(e.OldValue.ToString());
            listaOperadores.Add(e.NewValue.ToString());

            CambiarOperadorATarea(tarea);
            EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
        }

        private void UiListaOperadoresParaConteo_QueryPopUp(object sender, CancelEventArgs e)
        {
            if (UiVistaDetalleCounting.FocusedRowHandle < 0) return;
            var registro = (TareaDetalle)UiVistaDetalleCounting.GetRow(UiVistaDetalleCounting.FocusedRowHandle);
            e.Cancel = (registro.STATUS.Equals("COMPLETA") || registro.STATUS.Equals("EN_PROGRESO"));
        }

        private void UiListaOperadoresParaConteo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (UiVistaDetalleCounting.FocusedRowHandle < 0) return;

            if (!ConfirmacionReAsignarTarea())
            {
                e.Cancel = true;
                return;
            }
            var registro = (TareaDetalle)UiVistaDetalleCounting.GetRow(UiVistaDetalleCounting.FocusedRowHandle);
            var tarea = new Tarea
            {
                TASK_ID = registro.PHYSICAL_COUNT_DETAIL_ID
                ,
                TASK_ASSIGNEDTO = e.NewValue.ToString()
            };

            var listaOperadores = new List<string>();

            if (!string.IsNullOrEmpty(e.OldValue.ToString()))
                listaOperadores.Add(e.OldValue.ToString());
            listaOperadores.Add(e.NewValue.ToString());

            UsuarioDeseaCambiarOperadorDeTareaConteo?.Invoke(null, new TareaArgumento { Tarea = tarea });
        }

        private void UiBotonExpandirEncabezado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaEncabezado.ExpandAllGroups();
            RecargarSeleccionTareaEncabezado();
        }

        private void UiBotonContraerEncabezado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaEncabezado.CollapseAllGroups();
        }

        private void UiVistaEncabezado_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Tarea)UiVistaEncabezado.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaTareaEncabezadoCompleta)
                {
                    for (var i = 0; i < UiVistaEncabezado.RowCount; i++)
                    {
                        var documento = (Tarea)UiVistaEncabezado.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaEncabezado.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaTareaEncabezadoCompleta = false;
                }
            }
        }

        private void UiVistaEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaTareaEncabezadoCompleta = true;
            }
        }

        private void UiVistaEncabezado_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionTareaEncabezado();
        }

        private void UiVistaEncabezado_ColumnFilterChanged(object sender, EventArgs e)
        {
            UiVistaEncabezado.ExpandAllGroups();
            RecargarSeleccionTareaEncabezado();
        }

        private void UiBotonReanudarTarea_Click(object sender, EventArgs e)
        {
            PausarTarea(0);
        }

        private void UiBotonPausarTarea_Click(object sender, EventArgs e)
        {
            PausarTarea(1);
        }

        private void UiVistaDetallePicking_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var vista = (GridView)sender;
            if (e.ControllerRow >= 0)
            {
                var documento = (TareaDetalle)vista.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaTareaDetalleCompleta)
                {
                    for (var i = 0; i < vista.RowCount; i++)
                    {
                        var documento = (TareaDetalle)vista.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (vista.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaTareaDetalleCompleta = false;
                }
            }

        }

        private void UiVistaDetallePicking_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaTareaDetalleCompleta = true;
            }
        }

        private void UiVistaDetallePicking_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionTareaDetalle();
        }

        private void UiVistaDetallePicking_ColumnFilterChanged(object sender, EventArgs e)
        {
            RecargarSeleccionTareaDetalle();
        }

        private void UiBotonCancelarTarea_Click(object sender, EventArgs e)
        {
            if (!SeleccionarRazonDeCancelacionDetalleRecepcion())
            {
                EliminarTareas();
            }

        }

        private void UiListaOperadores_MouseDown(object sender, MouseEventArgs e)
        {

            int index = UiListaOperadores.IndexFromPoint(new Point(e.X, e.Y));
            if (index >= 0)
                operadorSeleccionado = (Usuario)UiListaOperadores.GetItem(index);
        }


        private void UiListaOperadores_MouseMove(object sender, MouseEventArgs e)
        {
            if (operadorSeleccionado == null || e.Button != MouseButtons.Left) return;
            UiListaOperadores.DoDragDrop(operadorSeleccionado, DragDropEffects.Copy);
        }

        private void UiListaOperadores_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {

        }

        private void UiBotonEnviarAErp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EnviarTareaAErp();
        }

        private void UiBotonDistribuirAOperadores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaDistribuirTareasTodosLosOperadores?.Invoke(null, null);
        }

        private void UiBotonDistribuirOperadoresSinTarea_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsuarioDeseaDistribuirTareasTodosLosOperadoresSinTarea?.Invoke(null, null);
        }

        private void UiBotonExportarAExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaEncabezado.ShowPrintPreview();
        }

        private void UiSwitchActualizarAutomaticamente_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TimerTask.Enabled = (!TimerTask.Enabled);
            ObtenerTareas();
            UiVistaEncabezado.ExpandAllGroups();
            //CargarDetalles();
        }

        private void CargarDetalles()
        {
            var mostrarColumnasComparacion = false;
            if (!string.IsNullOrEmpty(ultimoRegistro.IS_FROM_SONDA) && !string.IsNullOrEmpty(ultimoRegistro.IS_FROM_ERP))
            {
                mostrarColumnasComparacion = (ultimoRegistro.IS_FROM_SONDA.ToUpper().Equals("SI") ||
                                              ultimoRegistro.IS_FROM_ERP.ToUpper().Equals("SI"));
            }
            switch (ultimoRegistro.TASK_TYPE.ToUpper())
            {
                case "TAREA_RECEPCION":
                    LlenarVistaDetalleRecepcion(ultimoRegistro, mostrarColumnasComparacion);
                    break;
                case "TAREA_PICKING":
                    LlenarVistaDetallePicking(ultimoRegistro, mostrarColumnasComparacion);
                    break;
                case "TAREA_CONTEO_FISICO":
                    LlenarVistaConteo(ultimoRegistro);
                    break;
                case "TAREA_REUBICACION":
                    LlenarVistaDetalleReubicacion(ultimoRegistro);
                    break;
            }
        }

        private void TimerTask_Tick(object sender, EventArgs e)
        {
            ObtenerTareas();
            UiVistaEncabezado.ExpandAllGroups();
            //CargarDetalles();
        }

        private void UiContenedorDetalle_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;

        }

        private void UiContenedorVistaTareasEncabezado_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var usuario = (Usuario)e.Data.GetData(typeof(Usuario));

                if (UiContenedorVistaTareasEncabezado.MainView == UiVistaEncabezado)
                {
                    if (
                        Tarea.Count(
                            x =>
                                x.IS_SELECTED && x.TASK_TYPE == "TAREA_RECEPCION"
                                && (x.IS_COMPLETED.ToUpper().Equals("INCOMPLETA")
                                    || x.IS_COMPLETED.ToUpper().Equals("ACEPTADA"))) > 0 && ConfirmacionReAsignarTarea())
                    {
                        CambiarOperadorDeTareaRecepcion(usuario.LOGIN_ID);
                        UiContenedorVistaTareasEncabezado.RefreshDataSource();
                    }
                }
                else
                {
                    if (Tarea.Count(x => x.IS_SELECTED && (x.IS_COMPLETED == "INCOMPLETA" || x.IS_COMPLETED == "ACEPTADA")) > 0 && ConfirmacionReAsignarTarea())
                    {
                        CambiarOperadorDeTareasDesdeEncabezadoDetallado(usuario.LOGIN_ID);
                        UiContenedorVistaTareasEncabezado.RefreshDataSource();
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenedorDetalle_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var usuario = (Usuario)e.Data.GetData(typeof(Usuario));
                if (UiContenedorDetalle.MainView.Name != "UiVistaDetalleRecepcion")
                {
                    if (TareaDetalle.Count(x => x.IS_SELECTED && (x.STATUS == "INCOMPLETA" || x.STATUS == "ACEPTADA")) > 0 && ConfirmacionReAsignarTarea())
                    {
                        CambiarOperadorADetalleDeTarea(usuario.LOGIN_ID);
                        //ObtenerTareas();
                        UiContenedorDetalle.RefreshDataSource();
                    } else if (TareaDetalle.Count(x => x.IS_SELECTED && (x.STATUS == "INCOMPLETA" || x.STATUS == "ACEPTADA")) == 0)
                    {
                        InteraccionConUsuarioServicio.Mensaje("No hay lineas seleccionadas disponibles para asignación");
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenedorVistaTareasEncabezado_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(Usuario)) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void UiContenedorDetalle_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(Usuario)) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void UiListaOperadores_DragOver(object sender, DragEventArgs e)
        {
        }

        private void UiContenedorDetalle_DragOver(object sender, DragEventArgs e)
        {
        }

        private void AdministradorDeTareasVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorVistaTareasEncabezado, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiVistaEncabezadoConDetalle, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorDetalle, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaConfirmacionDetalleRecepcion, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaConfirmacionOrdenDeCompra, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            CargarOGuardarDisenios(UIContenedorOla, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void UiEtiquetaOperadores_Click(object sender, EventArgs e)
        {

        }

        private void UiListaDeOperadores_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void UiVistaDetallePicking_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Column.Name == "UiColOperadorDetallePicking")
            {
                string nombre = e.Value.ToString();
                var lstOperador = Operadores.FirstOrDefault(x => x.LOGIN_ID == e.Value.ToString());
                if (lstOperador != null)
                {
                    nombre = lstOperador.LOGIN_NAME;
                }
                e.DisplayText = nombre;
            }
        }

        private void UiVistaDetalleCounting_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Column.Name == "colASSIGNED_TO")
            {
                string nombre = e.Value.ToString();
                var lstOperador = Operadores.FirstOrDefault(x => x.LOGIN_ID == e.Value.ToString());
                if (lstOperador != null)
                {
                    nombre = lstOperador.LOGIN_NAME;
                }
                e.DisplayText = nombre;
            }
        }

        private void UiVistaDetalleReubicacion_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Column.Name == "UiListaOperadoresParaReubicacionDetalle")
            {
                string nombre = e.Value.ToString();
                var lstOperador = Operadores.FirstOrDefault(x => x.LOGIN_ID == e.Value.ToString());
                if (lstOperador != null)
                {
                    nombre = lstOperador.LOGIN_NAME;
                }
                e.DisplayText = nombre;
            }
        }

        private void UiVistaDetalleRecepcion_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value != null && e.Column.Name == "UiColAsignadoEncabezado")
            {
                string nombre = e.Value.ToString();
                var lstOperador = Operadores.FirstOrDefault(x => x.LOGIN_ID == e.Value.ToString());
                if (lstOperador != null)
                {
                    nombre = lstOperador.LOGIN_NAME;
                }
                e.DisplayText = nombre;
            }
        }

        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ObtenerTareas();
            UiVistaEncabezado.ExpandAllGroups();
            UiVistaEncabezadoConDetalle.ExpandAllGroups();
        }

        private void UiListaDeClases_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (Clases == null)
            {
                e.DisplayText = string.Empty;
                return;
            }
            e.DisplayText = string.Join(",", Clases.Where(c => c.IS_SELECTED).Select(c => c.CLASS_NAME));
        }

        private void UiVistaClases_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaClases.RowCount; i++)
            {
                var clase = (Clase)UiVistaClases.GetRow(i);
                if (clase == null) continue;
                if (clase.IS_SELECTED)
                {
                    UiVistaClases.SelectRow(i);
                }
            }
        }

        private void UiVistaClases_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeClasesCompleta = true;
            }
        }

        private void UiVistaClases_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var clase = (Clase)UiVistaClases.GetRow(e.ControllerRow);
                clase.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaDeClasesCompleta)
                {
                    for (var i = 0; i < UiVistaClases.RowCount; i++)
                    {
                        var clase = (Clase)UiVistaClases.GetRow(i);
                        if (clase == null) continue;
                        clase.IS_SELECTED = (UiVistaClases.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaDeOperadoresCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = string.Join(",", Clases.Where(c => c.IS_SELECTED).Select(c => c.CLASS_NAME));
        }

        private void UiVistaDetalleRecepcion_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (TareaDetalle)UiVistaDetalleRecepcion.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaTareaDetalleCompletaDeRecepcion)
                {
                    for (var i = 0; i < UiVistaDetalleRecepcion.RowCount; i++)
                    {
                        var documento = (TareaDetalle)UiVistaDetalleRecepcion.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaDetalleRecepcion.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaTareaDetalleCompletaDeRecepcion = false;
                }
            }
        }

        private void UiVistaDetalleRecepcion_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            if (UsuarioSeleccionoColumnaDeSeleccion(view.CalcHitInfo(new Point(e.X, e.Y))))
            {
                UsuarioSeleccionoVistaTareaDetalleCompletaDeRecepcion = true;
            }
        }

        private static bool UsuarioSeleccionoColumnaDeSeleccion(GridHitInfo column)
        {
            return (column.HitTest == GridHitTest.Column || column.HitTest == GridHitTest.GroupPanelColumn) &&
                   column.Column.Name.Equals("DX$CheckboxSelectorColumn");
        }

        private void UiVistaDetalleRecepcion_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionTareaDetalleRecepcion();
        }

        private void UiVistaDetalleRecepcion_ColumnFilterChanged(object sender, EventArgs e)
        {
            RecargarSeleccionTareaDetalleRecepcion();
        }
        #endregion

        #region Metodos

        private string ObtenerTextoAMostrarListaTiposDeTarea()
        {
            if (TiposTareas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in TiposTareas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.PARAM_CAPTION);
            }

            return cadena.ToString();
        }

        private string ObtenerTextoAMostrarListaDeOperadores()
        {
            if (ListaDeOperadores == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in ListaDeOperadores.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.LOGIN_ID);
            }

            return cadena.ToString();
        }

        private string ObtenerOperadoresSeleccionados()
        {
            if (ListaDeOperadores == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in ListaDeOperadores.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(documento.LOGIN_ID);
            }

            return cadena.ToString();
        }

        private string ObtenerTipoDeTareaSeleccionados()
        {
            if (TiposTareas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in TiposTareas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }
                cadena.Append(documento.PARAM_NAME);
            }

            return cadena.ToString();
        }

        private bool ValidarParaObtnerTareas()
        {

            var validacion = true;
            UiError.SetError(UIListaTiposDeTarea, "", ErrorType.None);
            UiError.SetError(UiListaDeOperadores, "", ErrorType.None);
            UiError.SetError(UiFechaInicial, "", ErrorType.None);
            UiError.SetError(UiFechaFinal, "", ErrorType.None);

            if (!TiposTareas.ToList().Exists(t => t.IS_SELECTED))
            {
                UiError.SetError(UIListaTiposDeTarea, "Seleccione un tipo de tarea");
                validacion = false;
            }

            if (!ListaDeOperadores.ToList().Exists(t => t.IS_SELECTED))
            {
                UiError.SetError(UiListaDeOperadores, "Seleccione un operador");
                validacion = false;
            }

            if (UiFechaInicial.EditValue == null)
            {
                UiError.SetError(UiFechaInicial, "Ingrese la fecha inicial");
                validacion = false;
            }

            if (UiFechaFinal.EditValue == null)
            {
                UiError.SetError(UiFechaFinal, "Ingrese la fecha final");
                validacion = false;
            }

            if (UiFechaInicial.EditValue != null && UiFechaFinal.EditValue != null && UiFechaInicial.DateTime > UiFechaFinal.DateTime)
            {
                UiError.SetError(UiFechaInicial, "La fecha inicial es mayor a la fecha final");
                validacion = false;
            }

            return validacion;
        }

        private void ObtenerTareas()
        {
            try
            {
                if (!ValidarParaObtnerTareas()) return;

                var tareaArgumento = new TareaArgumento
                {
                    FechaInicial = UiFechaInicial.DateTime
                    ,
                    FechaFinal = UiFechaFinal.DateTime
                    ,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    Users = ObtenerOperadoresSeleccionados()
                    ,
                    Types = ObtenerTipoDeTareaSeleccionados()
                    ,
                    Clases = string.Join("|", Clases.Where(c => c.IS_SELECTED).Select(c => c.CLASS_ID))
                };
                if (!UiToggleDetallado.Checked)
                {
                    UsuarioDeseaObtenerTareas?.Invoke(null, tareaArgumento);
                }
                else
                {
                    UsuarioDeseaObtenerTareasConDetalleDeMaterial?.Invoke(null, tareaArgumento);
                }
                InitializePhotos();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void LlenarVistaDetalleRecepcion(Tarea tarea, bool mostrarColumnasComparacion)
        {
            try
            {
                UiContenedorDetalle.MainView = UiVistaDetalleRecepcion;
                UsuarioDeseaObtenerDetalleDeTarea?.Invoke(null, new TareaArgumento { Tarea = tarea, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                UiColCantidadDocumentoRecepcion.Visible = mostrarColumnasComparacion;
                UiColDiferenciaCantidadRecepcion.Visible = mostrarColumnasComparacion;
                UiColCantidadDocumentoRecepcion.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion;
                UiColDiferenciaCantidadRecepcion.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion;

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void LlenarVistaDetallePicking(Tarea tarea, bool mostrarColumnasComparacion)
        {
            try
            {
                UiContenedorDetalle.MainView = UiVistaDetallePicking;
                UsuarioDeseaObtenerDetalleDeTarea?.Invoke(null, new TareaArgumento { Tarea = tarea, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                UiColCantidadDocumento.Visible = mostrarColumnasComparacion;
                UiColCantidadDocumento.OptionsColumn.ShowInCustomizationForm = mostrarColumnasComparacion;
                if ((TareaDetalle.Count(x => x.FROM_MASTERPACK == 1 && x.QTY != 0)) > 0 && tarea.SOURCE_TYPE == "SALES_ORDER" && tarea.IS_AUTHORIZED_DESCRIPTION != "ENVIADA")
                {
                    TieneKitsIncompletos = true;
                }else
                {
                    TieneKitsIncompletos = false;
                }

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void LlenarVistaConteo(Tarea tarea)
        {
            try
            {
                UiContenedorDetalle.MainView = UiVistaDetalleCounting;
                UsuarioDeseaObtenerDetalleDeTarea?.Invoke(null, new TareaArgumento { Tarea = tarea, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }
        private void LlenarVistaDetalleReubicacion(Tarea tarea)
        {
            try
            {
                UiContenedorDetalle.MainView = UiVistaDetalleReubicacion;
                UsuarioDeseaObtenerDetalleDeTarea?.Invoke(null, new TareaArgumento { Tarea = tarea, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private bool ConfirmacionReAsignarTarea()
        {
            return XtraMessageBox.Show("Confirma re-asignar la tarea?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmacionCambiarEstadoTarea()
        {
            return XtraMessageBox.Show("Confirma cambiar el estado de la tareas?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmacionCancelarTarea()
        {
            return XtraMessageBox.Show("Confirma cancelar la tarea?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmacionCancelarDetalleTarea(string mensaje)
        {
            return XtraMessageBox.Show(mensaje, "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void CambiarOperadorATarea(Tarea tarea)
        {
            UsuarioDeseaCambiarOperadorATarea?.Invoke(null, new TareaArgumento { Tarea = tarea });
        }

        private void CambiarOperadorDeTareaRecepcion(string login)
        {
            var listaOperadores = new List<string>();
            listaOperadores.Add(login);
            var listaDeTareas = Tarea.Where(x => x.IS_SELECTED && x.TASK_TYPE == "TAREA_RECEPCION" && (x.IS_COMPLETED.ToUpper().Equals("INCOMPLETA") || x.IS_COMPLETED.ToUpper().Equals("ACEPTADA"))).ToList();

            foreach (var item in listaDeTareas)
            {
                listaOperadores.Add(item.TASK_ASSIGNEDTO);

                UsuarioDeseaCambiarOperadorATarea?.Invoke(null, new TareaArgumento
                {
                    Tarea = new Tarea
                    {
                        WAVE_PICKING_ID = item.WAVE_PICKING_ID,
                        SERIAL_NUMBER = item.SERIAL_NUMBER,
                        TASK_ASSIGNEDTO = login
                    }
                });

                item.TASK_ASSIGNEDTO = login;
            }
            EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
        }

        private void CambiarOperadorDeTareasDesdeEncabezadoDetallado(string login)
        {
            var listaOperadores = new List<string>();
            listaOperadores.Add(login);
            var listaDeTareas = Tarea.Where(x => x.IS_SELECTED && (x.IS_COMPLETED.ToUpper().Equals("INCOMPLETA") || x.IS_COMPLETED.ToUpper().Equals("ACEPTADA"))).ToList();

            foreach (var item in listaDeTareas)
            {
                listaOperadores.Add(item.TASK_ASSIGNEDTO);

                UsuarioDeseaCambiarOperadorATarea?.Invoke(null, new TareaArgumento
                {
                    Tarea = new Tarea
                    {
                        WAVE_PICKING_ID = item.WAVE_PICKING_ID,
                        SERIAL_NUMBER = item.TASK_TYPE == "TAREA_RECEPCION" ? item.SERIAL_NUMBER : 0,
                        TASK_ASSIGNEDTO = login,
                        MATERIAL_ID = item.MATERIAL_ID
                    }
                });

                item.TASK_ASSIGNEDTO = login;
            }
            EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
        }

        private void CambiarOperadorADetalleDeTarea(string login)
        {
            var listaOperadores = new List<string>();
            listaOperadores.Add(login);
            var listaDeTareas = new List<Tarea>();
            foreach (var item in TareaDetalle.Where(x => x.IS_SELECTED && x.IN_PICKING_LINE == (int)SiNo.No && (x.STATUS == "INCOMPLETA" || x.STATUS == "ACEPTADA")))
            {
                listaOperadores.Add(item.ASSIGNED_TO);
                var tarea = new Tarea
                {
                    WAVE_PICKING_ID = item.WAVE_PICKING_ID,
                    MATERIAL_ID = item.MATERIAL_ID,
                    TASK_ASSIGNEDTO = login
                };
                UsuarioDeseaCambiarOperadorATarea?.Invoke(null, new TareaArgumento
                {
                    Tarea = tarea
                });

                item.ASSIGNED_TO = login;
                listaDeTareas.Add(tarea);
            }

            EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
        }

        private void RecargarSeleccionTareaEncabezado()
        {
            for (var i = 0; i < UiVistaEncabezado.RowCount; i++)
            {
                var documento = (Tarea)UiVistaEncabezado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaEncabezado.SelectRow(i);
                }
            }
        }

        private void RecargarSeleccionTareaDetalle()
        {
            GridView vista = null;
            switch (UiContenedorDetalle.MainView.Name)
            {
                case "UiVistaDetallePicking":
                    vista = UiVistaDetallePicking;
                    break;
                case "UiVistaDetalleCounting":
                    vista = UiVistaDetalleCounting;
                    break;
                case "UiVistaDetalleReubicacion":
                    vista = UiVistaDetalleReubicacion;
                    break;
                case "UiVistaDetalleRecepcion":
                    return;
            }
            if (vista == null) return;

            for (var i = 0; i < vista.RowCount; i++)
            {
                var documento = (TareaDetalle)vista.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    vista.SelectRow(i);
                }
            }
        }

        private void PausarTarea(int estado)
        {
            try
            {

                var listaTareas = (Tarea.ToList().Where(t => t.IS_SELECTED)).ToList();
                if (!listaTareas.Any()) return;
                if (!ConfirmacionCambiarEstadoTarea()) return;
                UsuarioDeseaCambiarEstadoDeTarea?.Invoke(null, new TareaArgumento { Tarea = new Tarea { IS_PAUSED = estado } });
                UiVistaEncabezado.CollapseAllGroups();
                UiVistaEncabezado.ExpandAllGroups();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void EliminarTareas()
        {
            try
            {
                if (!TareaDetalle.ToList().Exists(t => t.IS_SELECTED) && !Tarea.ToList().Exists(t => t.IS_SELECTED)) return;
                if (!ConfirmacionCancelarTarea()) return;
                UsuarioDeseaCancelarDetallePicking?.Invoke(null, null);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        public void RecargarVistas()
        {
            ObtenerTareas();
            UiVistaEncabezado.ExpandAllGroups();
        }

        private void EnviarTareaAErp()
        {
            try
            {
                if (!Tarea.ToList().Exists(t => t.IS_SELECTED
                    && ((t.TASK_TYPE.ToUpper().Equals("TAREA_PICKING") && !t.TASK_SUBTYPE.Equals("DESPACHO_WT")) || t.TASK_TYPE.ToUpper().Equals("TAREA_RECEPCION") || t.TASK_TYPE.ToUpper().Equals("TAREA_CONTEO_FISICO"))
                    && (t.TASK_SUBTYPE.ToUpper().Equals("TAREA_CONTEO_FISICO") || t.IS_FROM_SONDA.ToUpper().Equals("SI") || t.TASK_SUBTYPE == "RECEPCION_TRASLADO" || t.IS_FROM_ERP.ToUpper().Equals("SI"))
                    && (t.IS_COMPLETED.ToUpper().Equals("COMPLETA") || (t.TASK_SUBTYPE.ToUpper().Equals("TAREA_CONTEO_FISICO") && t.STATUS.ToUpper().Equals("COMPLETA")))
                    && t.DetalleErp.Exists(td => td.IS_POSTED_ERP != 1 || td.ATTEMPTED_WITH_ERROR == td.MAX_ATTEMPTS)
                    //&& !TieneKitsIncompletos
                    )) return;
                UsuarioDeseaAutorizarDocumentoErp?.Invoke(null, null);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void RecargarSeleccionTareaDetalleRecepcion()
        {
            for (var i = 0; i < UiVistaDetalleRecepcion.RowCount; i++)
            {
                var documento = (TareaDetalle)UiVistaDetalleRecepcion.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaDetalleRecepcion.SelectRow(i);
                }
            }
        }

        private bool SeleccionarRazonDeCancelacionDetalleRecepcion()
        {
            try
            {
                if (NoSePermiteCancelacionDeDetalleDeRecepcion()) return false;
                if (!ConfirmacionCancelarDetalleTarea("¿Está seguro que desea cancelar el detalle seleccionado?" + System.Environment.NewLine
                    + " (Esto revertirá el ingreso y eliminara todas las licencias del material.)")) return true;
                var popup = new ListaParaParametrosGeneralesPopup(RazonesDetalleCanceladoDeRecepcion.ToList());

                var respuesta = XtraDialog.Show(popup, "Seleccione una razón.", MessageBoxButtons.YesNo);

                if (respuesta != DialogResult.Yes) return true;
                var layout = (LayoutControl)popup.Controls["Layout"];
                if (layout == null) return true;
                var nuevaPrioridad = (TextEdit)layout.Controls["Listado"];
                var prioridad = nuevaPrioridad.EditValue;
                if (prioridad == null) return true;

                var configuracion = RazonesDetalleCanceladoDeRecepcion.FirstOrDefault(p => Equals(p.PARAM_NAME, prioridad));
                if (configuracion == null) return true;

                UsuarioDeseaCancelarDetallesDeRecepcion?.Invoke(null, new TareaArgumento { Razon = configuracion.TEXT_VALUE });

                return true;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
                return true;
            }
        }

        private bool NoSePermiteCancelacionDeDetalleDeRecepcion()
        {
            return (!EsDetalleRecepcion || !TareaDetalle.ToList().Exists(t => t.IS_SELECTED) ||
                    (ultimoRegistro.IS_COMPLETED !=
                     Enums.GetStringValue(EstadoTarea.Completa)));
        }

        #endregion

        #endregion

        #region Graficas
        private void UiContenedorTab_Click(object sender, EventArgs e)
        {
            try
            {
                if (TareaGraficas != null && UiContenedorTab.SelectedTabPageIndex == 1)
                {
                    UiChartTiposTareas.DataSource = TareaGraficas.Where(x => x.TIME > 0).ToList();
                    UiChartTareasPorOperador.DataSource = Tarea.ToList();
                    UiCheckMostrarPorcentaje.Checked = UiChartTareasPorOperador.Series.Count > 0 && UiChartTareasPorOperador.Series[0].Label.TextPattern.Contains("VP");
                }
                if (UiContenedorTab.SelectedTabPageIndex == 2)
                {
                    if (!(DetalleConfirmacionRecepcion != null && DetalleOrdenCompra != null))
                    {
                        UiBotonRefrescarConfirmacionRecepcion.Enabled = false;
                        UiBotonGuardarConfirmacionRecepcion.Enabled = false;
                        UIBtnReAbrirTask.Enabled = false;
                        UiBotonExportarConfirmacionRecepcion.Enabled = false;
                        UIBotonAsignarTodo.Enabled = false;
                        UIBotonLiberarInventario.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                if (UiContenedorTab.SelectedTabPageIndex == 2)
                {
                    if (registroConfirmacionRecepcion != null && registroConfirmacionRecepcion.TASK_TYPE == "TAREA_PICKING")
                    {
                        UITabOlaPicking.Text = "Ola de Picking(" + registroConfirmacionRecepcion.TASK_OR_WAVE_ID + ")";
                    }
                    else
                    {
                        UITabOlaPicking.Text = "Ola de Picking";
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
                throw;
            }
        }

        private void UiChartTiposTareas_CustomDrawSeries(object sender, DevExpress.XtraCharts.CustomDrawSeriesEventArgs e)
        {
            try
            {
                bool isSelected = selectedSeries != null && e.Series.Name == selectedSeries.Name;
                Bitmap image = new Bitmap(45, 45);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    if (isSelected)
                        graphics.FillRectangle(new HatchBrush(HatchStyle.DarkUpwardDiagonal, e.LegendDrawOptions.Color,
                        e.LegendDrawOptions.ActualColor2), new Rectangle(new Point(), image.Size));
                    else
                        graphics.FillRectangle(new LinearGradientBrush(new Rectangle(new Point(), image.Size),
                        e.LegendDrawOptions.Color, e.LegendDrawOptions.ActualColor2,
                        LinearGradientMode.BackwardDiagonal),
                        new Rectangle(new Point(), image.Size));
                    if (photos.ContainsKey(e.Series.Name))
                        graphics.DrawImage(photos[e.Series.Name], new Rectangle(new Point(5, 5), new Size(35, 35)));
                }
                e.LegendMarkerImage = image;
                e.DisposeLegendMarkerImage = true;
                if (isSelected && e.SeriesDrawOptions is BarDrawOptions)
                {
                    ((BarDrawOptions)e.SeriesDrawOptions).FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
                    ((HatchFillOptions)((BarDrawOptions)e.SeriesDrawOptions).FillStyle.Options).HatchStyle =
                    HatchStyle.DarkUpwardDiagonal;
                }
            }
            catch
            {
            }
        }

        private void UiChartTiposTareas_MouseLeave(object sender, EventArgs e)
        {

            selectedSeries = null;
        }

        private void UiChartTiposTareas_ObjectHotTracked(object sender, DevExpress.XtraCharts.HotTrackEventArgs e)
        {
            selectedSeries = e.HitInfo.InSeries ? (Series)e.HitInfo.Series : null;
            UiChartTiposTareas.Invalidate();
        }

        void InitializePhotos()
        {
            try
            {
                photos.Clear();
                if (TareaGraficas != null)
                {
                    foreach (Tarea row in TareaGraficas)
                    {
                        string lastName = row.TASK_ASSIGNEDTO;
                        if (!photos.ContainsKey(lastName))
                            photos.Add(lastName, Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "Men.png")));

                    }
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiChartTareasPorOperador_PieSeriesPointExploded(object sender, PieSeriesPointExplodedEventArgs e)
        {

        }

        private void UiBotonRefreshGraficas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tareaArgumento = new TareaArgumento
            {
                FechaInicial = UiFechaInicial.DateTime
            ,
                FechaFinal = UiFechaFinal.DateTime
            ,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            ,
                Users = ObtenerOperadoresSeleccionados()
             ,
                Types = ObtenerTipoDeTareaSeleccionados()
            };
            UsuarioDeseaObtenerTareas?.Invoke(null, tareaArgumento);
            InitializePhotos();
        }

        private void UiCheckMostrarPorcentaje_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TareaGraficas.Count > 0)
                UiChartTareasPorOperador.Series[0].Label.TextPattern = this.UiCheckMostrarPorcentaje.Checked ? "{A}: {VP:P0}" : "{A}: {V:F1}";
        }

        private void UiBotonExportarGraficas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var link1 = new PrintableComponentLink();
            var link2 = new PrintableComponentLink();
            var compositeLink = new DevExpress.XtraPrintingLinks.CompositeLink(new PrintingSystem());
            link1.Component = this.UiChartTareasPorOperador;
            link2.Component = this.UiChartTiposTareas;
            compositeLink.Links.Add(link1);
            compositeLink.Links.Add(link2);
            compositeLink.ShowPreview();
        }

        #endregion

        #region Confirmar Recepcion
        #region Eventos de Controles

        #endregion

        #region Metodos

        #endregion



        private void UiBotonReasignarBanda_Click(object sender, EventArgs e)
        {
            if (Lineas == null || Tarea == null || Tarea.Count < 1) return;
            if (!Tarea.ToList().Exists(
                        t =>
                            t.IS_SELECTED && t.IS_AUTHORIZED == (int)SiNo.No && t.IS_COMPLETE == (int)SiNo.No && t.IS_ACCEPTED == (int)SiNo.No
                            && t.TASK_TYPE == Enums.GetStringValue(TareasTipo.TareaPicking) && t.USE_PICKING_LINE == 1))
                return;

            var popup = new ReasignarTareaLineaDePickingPopup(Lineas.Select(l => l.PARAM_NAME).ToList());
            XtraDialog.Show(popup, "Seleccione nueva Banda.", MessageBoxButtons.OK);

            var layout = (LayoutControl)popup.Controls["Layout"];
            if (layout == null) return;
            var nuevaBanda = (TextEdit)layout.Controls["Banda"];
            var banda = nuevaBanda.EditValue;
            if (banda == null) return;

            UsuarioDeseaReasignarTareaDeLineaDePicking?.Invoke(sender, new TareaArgumento()
            {
                Linea = banda.ToString()
            });
        }

        private void UiBotonCambiarPrioridad_Click(object sender, EventArgs e)
        {
            if (Prioridades == null || Tarea == null || Tarea.Count < 1) return;
            if (!Tarea.ToList().Exists(
                t => t.IS_SELECTED && t.IS_AUTHORIZED == (int)SiNo.No && t.IS_COMPLETED != Enums.GetStringValue(EstadoTarea.Completa))) return;

            var popup = new CambiarPrioridadDeTareaPopup(Prioridades.Select(l => l.PARAM_CAPTION).ToList());
            var respuesta = XtraDialog.Show(popup, "Seleccione nueva Prioridad.", MessageBoxButtons.YesNo);

            if (respuesta != DialogResult.Yes) return;
            var layout = (LayoutControl)popup.Controls["Layout"];
            if (layout == null) return;
            var nuevaPrioridad = (TextEdit)layout.Controls["Prioridad"];
            var prioridad = nuevaPrioridad.EditValue;
            if (prioridad == null) return;

            var objetoPrioridad = Prioridades.FirstOrDefault(p => Equals(p.PARAM_CAPTION, prioridad));
            var valorPrioridad = objetoPrioridad?.NUMERIC_VALUE;
            if (valorPrioridad == null) return;

            UsuarioDeseaCambiarDePrioridadALaTarea?.Invoke(sender, new TareaArgumento()
            {
                Priority = (int)valorPrioridad.Value
            });
        }

        private void UiToggleDetallado_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiContenedorVistaTareasEncabezado.MainView = UiToggleDetallado.Checked
                ? UiVistaEncabezadoConDetalle
                : UiVistaEncabezado;

            ObtenerTareas();
            UiVistaEncabezadoConDetalle.ExpandAllGroups();
            UiVistaEncabezado.ExpandAllGroups();

            UiContenedorDetalle.Visible = !UiToggleDetallado.Checked;
            UiSplitControlTareas.SetPanelCollapsed(UiToggleDetallado.Checked);
        }

        private void UiVistaEncabezadoConDetalle_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaEncabezadoDetalladoCompleta = true;
            }
        }

        private void UiVistaEncabezadoConDetalle_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            var vista = (GridView)sender;
            if (e.ControllerRow >= 0)
            {
                var documento = (Tarea)vista.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaEncabezadoDetalladoCompleta)
                {
                    for (var i = 0; i < vista.RowCount; i++)
                    {
                        var documento = (Tarea)vista.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (vista.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaEncabezadoDetalladoCompleta = false;
                }
            }
        }

        private void UiVistaEncabezadoConDetalle_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaEncabezadoConDetalle.RowCount; i++)
            {
                var documento = (Tarea)UiVistaEncabezadoConDetalle.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaEncabezadoConDetalle.SelectRow(i);
                }
            }
        }

        private void UiVistaEncabezado_RowDoubleClick(object sender, EventArgs e)
        {
            try
            {
                registroConfirmacionRecepcion = ultimoRegistro;
                if (registroConfirmacionRecepcion.IS_COMPLETED == Enums.GetStringValue(EstadoTarea.Completa) && registroConfirmacionRecepcion.TASK_TYPE == "TAREA_RECEPCION" && registroConfirmacionRecepcion.IS_FROM_ERP == "Si" )
                {
                    UITabOlaPicking.Text = "Ola de Picking";
                    UiColQtyConfirmado.OptionsColumn.AllowEdit = UiColERP_BODEGA.OptionsColumn.AllowEdit = UIBtnReAbrirTask.Enabled = UIBotonRefrescarConfirmacionSerie.Enabled = UIBotonGuardarConfirmacionSerie.Enabled = UiBotonRefrescarConfirmacionRecepcion.Enabled = UiBotonGuardarConfirmacionRecepcion.Enabled = UIBotonAsignarTodo.Enabled = (registroConfirmacionRecepcion.IS_AUTHORIZED != 1);
                    UiContenedorTab.SelectedTabPageIndex = 2;
                    this.DebeMostrarBotonParaLiberarInventario = false;
                    UsuarioDeseaMostrarPantallaConfirmacionRecepcion?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion });
                    UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                    UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();
                    UIContenedorVistaConfirmacionSeries.RefreshDataSource();
                    if (DetalleConfirmacionRecepcion == null || DetalleConfirmacionRecepcion.Count == 0)
                    {
                        UiBotonGuardarConfirmacionRecepcion.Enabled = false;
                        UiBotonRefrescarConfirmacionRecepcion.Enabled = false;
                        UiBotonExportarConfirmacionRecepcion.Enabled = false;
                        UIBotonAsignarTodo.Enabled = false;
                        UiColQtyConfirmado.OptionsColumn.AllowEdit = false;
                        UiColERP_BODEGA.OptionsColumn.AllowEdit = false;
                        UIBotonGuardarConfirmacionSerie.Enabled = false;
                    }
                    if (!(DetalleRecepcionSeries == null || DetalleRecepcionSeries.Count == 0))
                    {
                        UITabConfirmarSeries.PageVisible = true;
                        UiBotonGuardarConfirmacionRecepcion.Enabled = false;
                    }
                    else
                    {
                        UITabConfirmarSeries.PageVisible = false;
                    }
                    if (!UIBotonAsignarTodo.Enabled && PermisoPuedeLiberarInventario)
                    {
                        UsuarioDeseaValidarVisibilidadDeBoton?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER });
                    }
                    if (!UIBotonAsignarTodo.Enabled && PermisoPuedeAutorizarControlDeCalidad)
                    {
                        DebeMostrarBotonParaAutorizarQA = true;
                    }
                    if (registroConfirmacionRecepcion.IS_AUTHORIZED == 0 && !PermisoPuedeConfirmarRecepcion)
                    {
                        UiBotonGuardarConfirmacionRecepcion.Enabled = false;
                        if (UITabConfirmarSeries.PageVisible)
                        {
                            UIBotonGuardarConfirmacionSerie.Enabled = false;
                        }
                    }
                }
                else if (registroConfirmacionRecepcion.TASK_TYPE == "TAREA_PICKING")
                {
                    //if (registroConfirmacionRecepcion.SOURCE_TYPE == "SO - ERP" && registroConfirmacionRecepcion.IS_COMPLETED == "COMPLETA" && registroConfirmacionRecepcion.IS_FROM_ERP == "Si" && (registroConfirmacionRecepcion.STATUS_POSTED_ERP == "Autorizada" || registroConfirmacionRecepcion.STATUS_POSTED_ERP == "Fallido"))
                    //{
                    //    DebeMostrarBotonParaLiberarTransaccion = true;
                    //}
                    //else
                    //{
                    //    DebeMostrarBotonParaLiberarTransaccion = false;
                    //}

                    if (TieneKitsIncompletos)
                    {
                        DebeMostrarBotonCrearTareaDeRectificacion = true;
                    }
                    else
                    {
                        DebeMostrarBotonCrearTareaDeRectificacion = false;
                    }
                    UsuarioDeseaObtenerDetalleOlaPicking?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion });
                    UiContenedorTab.SelectedTabPageIndex = 4;
                    UIBtnReAbrirTask.Enabled = false;
                    UITabOlaPicking.Text = "Ola de Picking(" + registroConfirmacionRecepcion.TASK_OR_WAVE_ID + ")";
                }
                else
                {
                    UiColQtyConfirmado.OptionsColumn.AllowEdit = false;
                    UiColERP_BODEGA.OptionsColumn.AllowEdit = false;
                    UIBtnReAbrirTask.Enabled = false;
                    UITabOlaPicking.Text = "Ola de Picking";
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void UiContenedorVistaConfirmacionOrdenDeCompra_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void UiContenedorVistaConfirmacionOrdenDeCompra_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(TareaDetalle)) ? DragDropEffects.Copy : DragDropEffects.None;
        }
        private void UiContenedorVistaConfirmacionOrdenDeCompra_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var tareaSeleccionada = (TareaDetalle)e.Data.GetData(typeof(TareaDetalle));
                if (UiContenedorVistaConfirmacionOrdenDeCompra.MainView.Name != "UiVistaConfirmacionOrdenDeCompra")
                {
                    OrdenDeCompraDetalle detalleOrdenCompra;
                    if (DetalleOrdenCompra.Count == 0)
                    {
                        detalleOrdenCompra = new OrdenDeCompraDetalle
                        {
                            ERP_RECEPTION_DOCUMENT_DETAIL_ID = -50,
                            ERP_RECEPTION_DOCUMENT_HEADER_ID = -50,
                            QTY = 0,
                            QTY_CONFIRMED = 0,
                            MATERIAL_ID = "",
                            QTY_FACTOR = 0,
                            UNIT = "",
                            UNIT_DESCRIPTION = "",
                            PENDING = 0,
                            LINE_NUM = -50
                        };
                    }
                    else
                    {
                        var grid = sender as GridControl;
                        var view = grid?.MainView as GridView;
                        if (view == null) return;
                        var hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                        var targetRow = hitInfo.RowHandle;
                        if (targetRow < 0) return;
                        detalleOrdenCompra = DetalleOrdenCompra[targetRow];
                    }

                    UsuarioDeseaConfirmarFilaDeRecepcionRecibida?.Invoke(sender, new TareaArgumento { FilaTareaDetalle = tareaSeleccionada, FilaOrdenDeCompraDetalle = detalleOrdenCompra });
                    UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                    UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenedorVistaConfirmacionDetalleRecepcion_MouseMove(object sender, MouseEventArgs e)
        {
            if (UIBotonAsignarTodo.Enabled)
            {
                if (tareaParaConfirmarSeleccionada == null || e.Button != MouseButtons.Left || tareaParaConfirmarSeleccionada.ASIGNADO == tareaParaConfirmarSeleccionada.QTY) return;
                UiContenedorVistaConfirmacionDetalleRecepcion.DoDragDrop(tareaParaConfirmarSeleccionada, DragDropEffects.Copy);
            }
        }

        private void UiContenedorVistaConfirmacionDetalleRecepcion_MouseDown(object sender, MouseEventArgs e)
        {
            if (UIBotonAsignarTodo.Enabled)
            {
                var grid = sender as GridControl;
                var view = grid?.MainView as GridView;
                if (view == null) return;

                var hitInfo = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));

                var targetRow = hitInfo.RowHandle;

                if (targetRow >= 0 && this.DetalleConfirmacionRecepcion[targetRow].ASIGNADO < this.DetalleConfirmacionRecepcion[targetRow].QTY)
                {
                    tareaParaConfirmarSeleccionada = this.DetalleConfirmacionRecepcion[targetRow];
                }
            }
        }

        private void UiBotonRefrescarConfirmacionRecepcion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DetalleConfirmacionRecepcion.Where(detalle => detalle.ASIGNADO > 0).Count() > 0 && ConfirmacionRefrescarAsignacionReception())
            {
                UsuarioDeseaMostrarPantallaConfirmacionRecepcion?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion });
                UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();
            }
        }

        private void UiBotonGuardarConfirmacionRecepcion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ConfirmacionAsignacionReception())
            {
                if (DetalleConfirmacionRecepcion.Where(detalle => detalle.ASIGNADO != detalle.QTY).Count() > 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe asignar todos los materiales recepcionados para continuar");
                    return;
                }
                if (DetalleOrdenCompra.Where(detalle => (detalle.WAREHOUSE_CODE == null || detalle.WAREHOUSE_CODE == "") && detalle.QTY_CONFIRMED > 0).Count() > 0)
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo("Debe asignar las bodegas en el documento que tienen cantidad confirmada mayor a 0 para continular");
                    return;
                }
                try
                {
                    UsuarioDeseaGuardarConfirmacionReception?.Invoke(sender, new TareaArgumento { Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                    UiBotonGuardarConfirmacionRecepcion.Enabled = false;
                    UiBotonRefrescarConfirmacionRecepcion.Enabled = false;
                    UIBotonAsignarTodo.Enabled = false;
                    UiColQtyConfirmado.OptionsColumn.AllowEdit = false;
                    UiColERP_BODEGA.OptionsColumn.AllowEdit = false;
                    UIBotonGuardarConfirmacionSerie.Enabled = false;
                    UIBotonRefrescarConfirmacionSerie.Enabled = false;
                    if (!UIBotonAsignarTodo.Enabled && PermisoPuedeLiberarInventario)
                    {
                        UsuarioDeseaValidarVisibilidadDeBoton?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER });
                    }
                }
                catch (Exception ex)
                {
                    InteraccionConUsuarioServicio.Mensaje(ex.Message);
                    UiBotonRefrescarConfirmacionRecepcion.Enabled = true;
                    UIBotonAsignarTodo.Enabled = false;
                    UiColQtyConfirmado.OptionsColumn.AllowEdit = true;
                    UiColERP_BODEGA.OptionsColumn.AllowEdit = true;
                }
            }
        }

        private bool ConfirmacionAsignacionReception()
        {
            return XtraMessageBox.Show("Desea finalizar la operación de Confirmación de Recepción de Orden de Compra ERP?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmacionRefrescarAsignacionReception()
        {
            return XtraMessageBox.Show("Desea reiniciar el proceso de Confirmación de Recepción de Orden de Compra ERP?", "Swift 3PL", MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void UiBotonExportarConfirmacionRecepcion_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            exportarResultadoDeConfirmacionReceptionOrdenDeCompraAXls();
        }

        private void exportarResultadoDeConfirmacionReceptionOrdenDeCompraAXls()
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Exportar Orden de Compra recepcionada";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UIVistaConfirmacionOrdenDeCompra.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UIBotonAsignarTodo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UIBotonAsignarTodo.Enabled)
            {
                try
                {
                    var detalleOrden = DetalleOrdenCompra.ToList();
                    UsuarioDeseaMostrarPantallaConfirmacionRecepcion?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion });
                    UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                    UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();

                    foreach (var det in DetalleOrdenCompra)
                    {
                        det.WAREHOUSE_CODE = detalleOrden.FirstOrDefault(x => x.ERP_RECEPTION_DOCUMENT_DETAIL_ID == det.ERP_RECEPTION_DOCUMENT_DETAIL_ID).WAREHOUSE_CODE;
                    }
                    OrdenDeCompraDetalle detalleOrdenCompra;
                    if (DetalleOrdenCompra == null || DetalleOrdenCompra.Count == 0)
                    {
                        //asignamos objeto dummy
                        detalleOrdenCompra = new OrdenDeCompraDetalle
                        {
                            ERP_RECEPTION_DOCUMENT_DETAIL_ID = -50,
                            ERP_RECEPTION_DOCUMENT_HEADER_ID = -50,
                            QTY = 0,
                            QTY_CONFIRMED = 0,
                            MATERIAL_ID = "",
                            QTY_FACTOR = 0,
                            UNIT = "",
                            UNIT_DESCRIPTION = "",
                            PENDING = 0,
                            LINE_NUM = -1
                        };
                    }
                    else
                    {
                        detalleOrdenCompra = DetalleOrdenCompra[0];
                    }
                    for (int i = 0; i < DetalleConfirmacionRecepcion.Count; i++)
                    {
                        var tareaSeleccionada = DetalleConfirmacionRecepcion[i];
                        UsuarioDeseaConfirmarFilaDeRecepcionRecibida?.Invoke(sender, new TareaArgumento { FilaTareaDetalle = tareaSeleccionada, FilaOrdenDeCompraDetalle = detalleOrdenCompra });
                    }
                    UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                    UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();
                    isAsignoTodo = true;
                }
                catch (Exception ex)
                {
                    InteraccionConUsuarioServicio.Mensaje(ex.Message);
                }
            }
        }

        #endregion

        #region Confirmar Series
        private void UIBtnExportarConfirmacionSeries_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoParaGuardar.DefaultExt = "xlsx";
                UiDialogoParaGuardar.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoParaGuardar.FilterIndex = 2;
                UiDialogoParaGuardar.RestoreDirectory = true;
                UiDialogoParaGuardar.Title = @"Exportar Confirmación de Series con sus correlativos";
                if (UiDialogoParaGuardar.ShowDialog() == DialogResult.OK)
                {
                    UIVistaConfirmacionSeries.ExportToXlsx(UiDialogoParaGuardar.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UIBtnImprimirConfirmacionSerie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UIVistaConfirmacionSeries.ShowPrintPreview();
        }

        private void UIBotonRefrescarConfirmacionSerie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaRefrescarGridConfirmacionRecepcionSeries?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion });
                UIContenedorVistaConfirmacionSeries.RefreshDataSource();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UIBotonGuardarConfirmacionSerie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiBotonGuardarConfirmacionRecepcion_ItemClick(sender, e);
        }

        #endregion

        private void UIBotonLiberarInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var popup = new ListaParaParametrosGeneralesPopup(RazonesDetalleLiberarInventarioConfirmado.ToList(), "Referencia:");

                var respuesta = XtraDialog.Show(popup, "Seleccione una razón.", MessageBoxButtons.YesNo);

                if (respuesta != DialogResult.Yes) return;
                var layout = (LayoutControl)popup.Controls["Layout"];
                if (layout == null) return;
                var nuevaPrioridad = (TextEdit)layout.Controls["Listado"];
                var prioridad = nuevaPrioridad.EditValue;
                if (prioridad == null)
                {
                    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                    return;
                }
                var referencia = (TextEdit)layout.Controls["txtReference"];

                var configuracion = RazonesDetalleLiberarInventarioConfirmado.FirstOrDefault(p => Equals(p.PARAM_NAME, prioridad));
                if (configuracion == null)
                {
                    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                    return;
                }

                UsuarioDeseaLiberarInventarioConfirmado?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER, Login = InteraccionConUsuarioServicio.ObtenerUsuario(), reference = referencia.EditValue?.ToString(), reason = configuracion.PARAM_NAME });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UIBotonLiberarTransaccion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var popup = new ListaParaParametrosGeneralesPopup(RazonesDetalleLiberarInventarioConfirmado.ToList(), "Referencia:");

                var respuesta = XtraDialog.Show(popup, "Seleccione una razón.", MessageBoxButtons.YesNo);

                if (respuesta != DialogResult.Yes) return;
                var layout = (LayoutControl)popup.Controls["Layout"];
                if (layout == null) return;
                var nuevaPrioridad = (TextEdit)layout.Controls["Listado"];
                var prioridad = nuevaPrioridad.EditValue;
                if (prioridad == null)
                {
                    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                    return;
                }
                var referencia = (TextEdit)layout.Controls["txtReference"];

                var configuracion = RazonesDetalleLiberarInventarioConfirmado.FirstOrDefault(p => Equals(p.PARAM_NAME, prioridad));
                if (configuracion == null)
                {
                    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                    return;
                }

                UsuarioDeseaLiberarTransaccionConfirmado?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER, Login = InteraccionConUsuarioServicio.ObtenerUsuario(), reference = referencia.EditValue?.ToString(), reason = configuracion.PARAM_NAME });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UIBotonCrearTareaRectificacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                 var respuesta = MessageBox.Show(@"Se creará una tarea de recepción para devolver el material y se restaran las licencias de despacho", @"Operación exitosa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (result == DialogResult.Yes)
                //{
                //    Process.Start(path);
                //}

                if (respuesta != DialogResult.Yes) return;
                //var layout = (LayoutControl)popup.Controls["Layout"];
                //if (layout == null) return;
                //var nuevaPrioridad = (TextEdit)layout.Controls["Listado"];
                //var prioridad = nuevaPrioridad.EditValue;
                //if (prioridad == null)
                //{
                //    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                //    return;
                //}
                //var referencia = (TextEdit)layout.Controls["txtReference"];

                //var configuracion = RazonesDetalleLiberarInventarioConfirmado.FirstOrDefault(p => Equals(p.PARAM_NAME, prioridad));
                //if (configuracion == null)
                //{
                //    InteraccionConUsuarioServicio.Alerta("Debe seleccionar una razón");
                //    return;
                //}

                UsuarioDeseaCrearTareaDeRectificacionMP?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER, WAVE_PICKING_ID = (int)registroConfirmacionRecepcion.WAVE_PICKING_ID, Login = InteraccionConUsuarioServicio.ObtenerUsuario()});
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UIBotonAutorizarQA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaAutorizarControlDeCalidad?.Invoke(sender, new TareaArgumento { taskId = (int)registroConfirmacionRecepcion.SERIAL_NUMBER, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UIVistaConfirmacionOrdenDeCompra_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            if (UIVistaConfirmacionOrdenDeCompra.FocusedRowHandle < 0) return;
            var filaOrdenDetalle =
                                          (OrdenDeCompraDetalle)
                                          UIVistaConfirmacionOrdenDeCompra.GetRow(UIVistaConfirmacionOrdenDeCompra.FocusedRowHandle);
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "QTY_CONFIRMED":
                        var qty = decimal.Parse(e.Value.ToString());
                        filaOrdenDetalle.QTY_CONFIRMED_READ_ONLY = filaOrdenDetalle.QTY_CONFIRMED;
                        filaOrdenDetalle.QTY_CONFIRMED = qty;


                        UsuarioDeseaActualizarCantidadConfirmadaManualmente?.Invoke(sender, new TareaArgumento { FilaOrdenDeCompraDetalle = filaOrdenDetalle, indiceFilaModificadaManualmente = UIVistaConfirmacionOrdenDeCompra.FocusedRowHandle });
                        UiContenedorVistaConfirmacionDetalleRecepcion.RefreshDataSource();
                        UiContenedorVistaConfirmacionOrdenDeCompra.RefreshDataSource();
                        return;
                        break;
                    default: return;
                }
            }
            catch (Exception ex)
            {
                e.Valid = false;
                e.ErrorText = ex.Message;
                filaOrdenDetalle.QTY_CONFIRMED = filaOrdenDetalle.QTY_CONFIRMED_READ_ONLY;
                return;
            }

            e.Valid = false;
            e.ErrorText = "La cantidad sobrepasa lo pendiente o tiene que ser mayor a cero.";
        }

        private void UIBtnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UIViewOlaPicking.FocusedRowHandle < 0)
            {
                InteraccionConUsuarioServicio.Mensaje("Debe seleccionar una tarea");
                return;
            }
            Tarea tarea = DetalleLicenciasOla[UIViewOlaPicking.FocusedRowHandle];
            if (tarea.STATUS == "CANCELADA")
            {
                InteraccionConUsuarioServicio.Mensaje("No puede cambiar líneas de la ola que fueron canceladas");
                return;
            }
            if (tarea.STATUS == "COMPLETADA")
            {
                InteraccionConUsuarioServicio.Mensaje("No puede cambiar líneas que ya fueron completadas");
                return;
            }
            UsuarioDeseaCambiarLicenciaEnLineaDeTareaDePicking?.Invoke(sender, new TareaArgumento { Tarea = tarea, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
        }

        private void UIBtnReAbrirTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (registroConfirmacionRecepcion == null)
            {
                InteraccionConUsuarioServicio.Mensaje("No hay tarea seleccionada para reabrir");
                return;
            }
            if (registroConfirmacionRecepcion.IS_AUTHORIZED == 1 || registroConfirmacionRecepcion.IS_POSTED_ERP == 1)
            {
                InteraccionConUsuarioServicio.Mensaje("No se puede reabrir una tarea que ya fue confirmada o enviada a erp");
                return;
            }
            UsuarioDeseaReabrirTareaRecepcion?.Invoke(sender, new TareaArgumento { Tarea = registroConfirmacionRecepcion, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
            var listaOperadores = new List<string>();
            listaOperadores.Add(registroConfirmacionRecepcion.TASK_ASSIGNED_TO);
            EnviarTareasAApi?.Invoke(null, new TareaArgumento { ListaDeOperadores = listaOperadores });
            UiBotonGuardarConfirmacionRecepcion.Enabled = false;
            UiBotonRefrescarConfirmacionRecepcion.Enabled = false;
            UIBotonAsignarTodo.Enabled = false;
            UiColQtyConfirmado.OptionsColumn.AllowEdit = false;
            UiColERP_BODEGA.OptionsColumn.AllowEdit = false;
            UIBotonGuardarConfirmacionSerie.Enabled = false;
            UIBotonRefrescarConfirmacionSerie.Enabled = false;
            UiContenedorTab.SelectedTabPageIndex = 0;
            UIBtnReAbrirTask.Enabled = false;
            UiBotonRefrescar_ItemClick(sender, e);
        }

        private void UiContenedorVistaTareasEncabezado_Click(object sender, EventArgs e)
        {

        }
    }
}
