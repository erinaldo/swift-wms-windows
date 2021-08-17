using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraMap;
using DevExpress.XtraPrinting.Native;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Tipos;
using DevExpress.Utils.Extensions;
using DevExpress.CodeParser;
using System.Configuration;

namespace MobilityScm.Modelo.Vistas
{
    public partial class DemandaDeDespachoVista : VistaBaseDeveExpress, IDemandaDeDespachoVista
    {
        #region Eventos

        public event EventHandler<PickingArgumento> UsuarioDeseaCrearPickingDeOrdenDeVenta;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaMarcarOrdenDeVentaConPicking;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerOrdenesDeVentaPorFecha;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerOrdenesDeEntregaPorFecha;
        public event EventHandler UsuarioDeseaObtenerRutas;
        public event EventHandler<SkuArgumento> UsuarioDeseaValidarInventarioParaOrdenDeVenta;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaDescartarEncabezado;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaDescartarTodosEncabezadosConAdvertencia;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerBodegasAsignadas;
        public event EventHandler<BodegaArgumento> UsuarioDeseaObtenerUbicacionesDeSalida;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerClientesErpCanalModerno;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerDetallesConsolidados;
        public event EventHandler<OrdenDeVentaArgumento> usuarioDeseaEliminarRegistros;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerSolicitudesDeTransferencia;
        public event EventHandler UsuarioSeleccionoFuente;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerLineasDePickingAsociadasABodega;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioSeleccionoBodega;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioSeleccionoPoligonos;
        public event EventHandler<PickingArgumento> UsuarioDeseaCambiarElOrdenDeVehiculos;
        public event EventHandler<ConsultaArgumento> UsuarioCambioValorDeSwitchDeConsolidado;
        public event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerPrioridad;
        public event EventHandler<OrdenDeVentaArgumento> UsuarioDeseaObtenerDemandasPreparadasPorFecha;
        public event EventHandler<OlaDePickingDeDemandaDespachoArgumento> UsuarioDeseaObtenerOlasDePickigGeneradas;
        public event EventHandler<ConsultaArgumento> UsuarioDeseaObtenerProyectos;

        #endregion

        #region Propiedades

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public DemandaDeDespachoVista()
        {
            InitializeComponent();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaSwiftExpressServicio, OrdenDeVentaSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<IPickingServicio, PickingServicio>();
            Mvx.Ioc.RegisterType<IRutasSwiftExpressServicio, RutasSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<IDemandaDeDespachoServicio, DemandaDeDespachoServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IUbicacionServicio, UbicacionServicio>();
            Mvx.Ioc.RegisterType<IDemandaDeDespachoControlador, DemandaDeDespachoControlador>();
            Mvx.Ioc.RegisterType<IPolizaServicio, PolizaServicio>();
            Mvx.Ioc.RegisterType<IOrdenDeVentaERPServicio, OrdenDeVentaERPServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<ISolicitudDeTrasladoServicio, SolicitudDeTrasladoServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IPoligonoServicio, PoligonoServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IManifiestoCargaServicio, ManifiestoCargaServicio>();
            Mvx.Ioc.RegisterType<IProyectoServicio, ProyectoServicio>();
            Mvx.Ioc.RegisterSingleton<IDemandaDeDespachoVista, DemandaDeDespachoVista>(this);
            Mvx.Ioc.Resolve<IDemandaDeDespachoControlador>();
        }

        public IList<OrdenDeVentaEncabezado> OrdenesDeVenta { get; set; }

        public IList<OrdenDeVentaDetalle> DetallesOrdenDeVenta { get; set; }

        public IList<Sku> Skus
        {
            get { return (IList<Sku>)UiGridControlSkusSinInventario.DataSource; }

            set { UiGridControlSkusSinInventario.DataSource = value; }
        }

        public IList<Ruta> Rutas
        {
            get { return (IList<Ruta>)UiListaRutaVendedor.Properties.DataSource; }

            set { UiListaRutaVendedor.Properties.DataSource = value; }
        }

        public string Usuario { get; set; }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UIListaBodega.Properties.DataSource; }
            set { UIListaBodega.Properties.DataSource = value; }
        }

        public IList<Ubicacion> Ubicaciones
        {
            get { return (IList<Ubicacion>)UiListaUbicacionDeSalida.Properties.DataSource; }
            set { UiListaUbicacionDeSalida.Properties.DataSource = value; }
        }

        public string BodegaSeleccionda => UIListaBodega.EditValue?.ToString() ?? "";
        public string UbicacionSeleccionda => UiListaUbicacionDeSalida.EditValue?.ToString() ?? "";

        private bool UsuarioSeleccionoListaRutaVendedorCompleta { get; set; }

        private bool UsuarioSeleccionoListaClienteErpCanalModernoCompleta { get; set; }

        public TipoFuenteDemandaDespacho TipoFuente { get; set; }

        public TipoDeInventario TipoInventario { get; set; }


        public IList<Cliente> ClientesErpCanalModerno
        {
            get { return (IList<Cliente>)UiListaClienteErpCanalModerno.Properties.DataSource; }

            set { UiListaClienteErpCanalModerno.Properties.DataSource = value; }
        }

        public bool EsConsolidado => UiSwiftConsolidado.Checked;

        public bool UsaNext { get; set; }

        public bool UsuarioSeleccionoVistaConsolidadoCompleta { get; set; }

        public bool UsuarioSeleccionoVistaEncabezadoCompleta { get; set; }

        public IList<OrdenDeVentaDetalle> DetallesOrdenDeVentaConsolidado { get; set; }

        public IList<MaterialConTonoYCalibre> MaterialesConTonoYCalibres
        {
            get { return (IList<MaterialConTonoYCalibre>)UiGridControlTonosYCalibres.DataSource; }
            set { UiGridControlTonosYCalibres.DataSource = value; }
        }

        public IList<Entidades.Configuracion> Permisos { get; set; }

        public IList<Entidades.Configuracion> LineasDePicking
        {
            get { return (IList<Entidades.Configuracion>)UiListaLineasDePicking.Properties.DataSource; }
            set { UiListaLineasDePicking.Properties.DataSource = value; }
        }

        public bool EsPorTonoOCalibre => UiSwiftTonosYCalibres.Checked;

        public bool ManejaLineaDePicking => !(UiListaLineasDePicking.EditValue == null
                                              || UiListaLineasDePicking.EditValue.ToString() == string.Empty);

        public IList<Poligono> Poligonos { get; set; }

        public IList<Parametro> Parametros { get; set; }

        private bool PermisoLineaDePicking;

        private IList<Poligono> PoligonosSeleccionados { get; set; }

        public IList<VehiculoManifiesto> Vehiculos
        {
            get { return (IList<VehiculoManifiesto>)UiContenedorVehiculos.DataSource; }
            set { UiContenedorVehiculos.DataSource = value; }
        }

        public IList<Entidades.Configuracion> PrioridadDeTarea
        {
            get { return (IList<Entidades.Configuracion>)UiListaPrioridad.Properties.DataSource; }
            set
            {
                UiListaPrioridad.Properties.DataSource = value;
                UiListaPrioridad.EditValue = (int)Prioridad.Media;
            }
        }

        private GeoPoint _puntoInicial;

        GridHitInfo _downHitInfoVistaVehiculos = null;

        public int FiltroDeUsaLineaDePicking { get; set; }

        public bool EsDemandaParaEntregaInmediata
        {
            get { return UiSwitchEntregaInmediata.Checked; }
            set { UiSwitchEntregaInmediata.Checked = value; }
        }

        public bool MuestraSwitchDeEntregaInmediata
        {
            set { UiSwitchEntregaInmediata.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.Never; }
        }

        public IList<InventarioParaPickingPorEstado> InvnetarioDisponiblePorEstado
        {
            get { return (IList<InventarioParaPickingPorEstado>)UiGridControlInvnetarioDisponible.DataSource; }

            set
            {
                UiGridControlInvnetarioDisponible.DataSource = value;
            }
        }

        public IList<InventarioParaPickingPorEstado> EstadosDeMaterial
        {
            get { return (IList<InventarioParaPickingPorEstado>)UiListaDeEstadosDetalleDocumento.DataSource; }

            set
            {
                UiListaDeEstadosDetalleDocumento.DataSource = value;
                UiListaDeEstadosDeMaterialConsolidado.DataSource = value;
            }
        }

        public Entidades.Configuracion EstadoPredeterminadoDeMaterial { get; set; }

        public IList<OlaDePickingDeDemandaDespacho> OlasDePikingCreadas
        {
            get { return (IList<OlaDePickingDeDemandaDespacho>)UiGridControlOlas.DataSource; }

            set
            {
                UiGridControlOlas.DataSource = value;
            }
        }

        public IList<Proyecto> Proyectos
        {
            get { return (IList<Proyecto>)UIListaProyecto.Properties.DataSource; }

            set
            {
                UIListaProyecto.Properties.DataSource = value;
            }
        }

        public Proyecto ProyectoSeleccionado { get; set; }

        public string NumeroOrden
        {
            get { return UiTextoNumeroOrden.Text; }
            set { UiTextoNumeroOrden.Text = value; }
        }

        #endregion

        #region Metodos de Pagina       

        private void DemandaDeDespachoVista_Load(object sender, EventArgs e)
        {
            try
            {
                PoligonosSeleccionados = new List<Poligono>();
                UiFechaInicial.EditValue = DateTime.Today;
                UiFechaFin.EditValue = DateTime.Today;
                VistaCargandosePorPrimeraVez?.Invoke(sender, e);
                UIListaBodega.Properties.PopupFormWidth = UIListaBodega.Width - 10;
                UiListaLineasDePicking.Properties.PopupFormWidth = UiListaLineasDePicking.Width + 200;
                UiListaRutaVendedor.Properties.PopupFormWidth = UiListaRutaVendedor.Width + 450;
                UiListaClienteErpCanalModerno.Properties.PopupFormWidth = UiListaClienteErpCanalModerno.Width + 450;

                //OBTIENE LOS TIPOS DE FUENTE PARA LA DEMANDA DE DESPACHO                
                var fuenteSO_ERP = Parametros?.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(TipoFuenteDemandaDespacho.OrdenVentaErp));
                var fuenteSO_SONDA = Parametros?.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(TipoFuenteDemandaDespacho.OrdenVentaSonda));
                var fuenteWT_SWIFT = Parametros?.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(TipoFuenteDemandaDespacho.SolicitudTrasladoWms));
                var fuenteWT_ERP = Parametros?.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(TipoFuenteDemandaDespacho.SolicitudTrasladoErp));
                var fuenteDO_ERP = Parametros?.FirstOrDefault(p => p.PARAMETER_ID == "DO - ERP");

                if (fuenteSO_SONDA != null && Convert.ToInt32(fuenteSO_SONDA.VALUE.ToString()) == (int)SiNo.Si) UiComboFuente.Properties.Items.Add(fuenteSO_SONDA.PARAMETER_ID);
                if (fuenteSO_ERP != null && Convert.ToInt32(fuenteSO_ERP.VALUE.ToString()) == (int)SiNo.Si) UiComboFuente.Properties.Items.Add(fuenteSO_ERP.PARAMETER_ID);
                if (fuenteWT_SWIFT != null && Convert.ToInt32(fuenteWT_SWIFT.VALUE.ToString()) == (int)SiNo.Si) UiComboFuente.Properties.Items.Add(fuenteWT_SWIFT.PARAMETER_ID);
                if (fuenteWT_ERP != null && Convert.ToInt32(fuenteWT_ERP.VALUE.ToString()) == (int)SiNo.Si) UiComboFuente.Properties.Items.Add(fuenteWT_ERP.PARAMETER_ID);
                if (fuenteDO_ERP != null && Convert.ToInt32(fuenteDO_ERP.VALUE.ToString()) == (int)SiNo.Si) UiComboFuente.Properties.Items.Add(fuenteDO_ERP.PARAMETER_ID);

                var permisoTonoYCalibre =
                    Permisos?.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.ManejaTonoYCalibre));
                var permisoLineadePicking =
                    Permisos?.FirstOrDefault(
                        p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.ManejaLineaDePicking));
                var puntoGps =
                    Permisos?.FirstOrDefault(p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.Gps));

                if (permisoTonoYCalibre != null && permisoTonoYCalibre.NUMERIC_VALUE == (int)SiNo.Si)
                    UiSwiftTonosYCalibres.Visibility = BarItemVisibility.Always;
                UiPaginaTonoCalibre.PageVisible = permisoTonoYCalibre != null &&
                                                  permisoTonoYCalibre.NUMERIC_VALUE == (int)SiNo.Si;
                if (permisoLineadePicking != null && permisoLineadePicking.NUMERIC_VALUE == (int)SiNo.Si)
                {
                    PermisoLineaDePicking = true;
                }

                var fuenteInicial = Parametros?.FirstOrDefault(p => p.GROUP_ID == Enums.GetStringValue(GrupoParametro.FuenteDemandaDespacho) && Convert.ToInt32(p.VALUE.ToString()) == (int)SiNo.Si);
                if (fuenteInicial != null)
                {
                    UiComboFuente.EditValue = fuenteInicial.PARAMETER_ID.ToString();
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje("No tiene configurado ninguna fuente.");
                }
                UiComboTipoInventario.EditValue = Enums.GetStringValue(TipoDeInventario.General);


                CargarOGuardarDisenios(UiContenerdoVistaOrdenEncabezado, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiContenedorVistaOrdenDetalle, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiGridControlSkusSinInventario, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiGridControlTonosYCalibres, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiContenedorVehiculos, false, Usuario, GetType().Name);
                CargarOGuardarDisenios(UiGridControlOlas, false, Usuario, GetType().Name);
                MostrarInventarioPorTonoOCalibre();
                var parametroNext =
                    Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.TieneNext));



                var imageTilesLayer = new ImageTilesLayer();
                UiMapControlPoligonos.Layers.Add(imageTilesLayer);
                var vectorLayer = new VectorItemsLayer();
                vectorLayer.SelectedItemStyle.Fill = Color.FromArgb(95, 250, 10, 10);
                vectorLayer.SelectedItemStyle.Stroke = Color.DarkOrange;
                vectorLayer.Name = "Poligonos";
                UiMapControlPoligonos.Layers.Add(vectorLayer);
                UsaNext = parametroNext != null && int.Parse(parametroNext.VALUE) == (int)SiNo.Si;

                CargarFiltrosDemandaSegunTipo();

                if (ValidarPuentoGps(parametroNext, puntoGps))
                {
                    _puntoInicial = GeoPoint.Parse(puntoGps.TEXT_VALUE);
                }
                else
                {
                    //punto defecto Guatemala
                    _puntoInicial = new GeoPoint(14.62, -90.47);
                }
                UiMapControlPoligonos.ZoomLevel = 7;
                UiMapControlPoligonos.CenterPoint = _puntoInicial;

                var parametroTipoDespacho =
                    Parametros.FirstOrDefault(
                        p =>
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda) &&
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking));
                var mostrarTipoDespacho = (parametroTipoDespacho != null &&
                                           int.Parse(parametroTipoDespacho.VALUE) == (int)SiNo.Si);

                UiColCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;

                Dictionary<int, string> list = new Dictionary<int, string>();
                list.Add((int)Tipos.UsaLineaDePicking.NoManejanBanda,
                    Enums.GetStringValue(Tipos.UsaLineaDePicking.NoManejanBanda));
                list.Add((int)Tipos.UsaLineaDePicking.ManejanBanda,
                    Enums.GetStringValue(Tipos.UsaLineaDePicking.ManejanBanda));
                list.Add((int)Tipos.UsaLineaDePicking.Ambas, Enums.GetStringValue(Tipos.UsaLineaDePicking.Ambas));


                UiListaUsaLineaDePicking.Properties.DataSource = list.ToList();
                FiltroDeUsaLineaDePicking = (int)Tipos.UsaLineaDePicking.Ambas;
                UiListaUsaLineaDePicking.EditValue = FiltroDeUsaLineaDePicking;


                var despachoConEstado =
                    Parametros.FirstOrDefault(
                        p =>
                            p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking) &&
                            p.PARAMETER_ID == Enums.GetStringValue(IdParametro.DespachoPorEstadoDematerial));

                bool despacharConEstadoDeMaterial = despachoConEstado != null && despachoConEstado.VALUE.Equals("1");

                UiColEstadoDetalleDocumento.Visible = despacharConEstadoDeMaterial;
                UiColEstadoDetalleDocumento.OptionsColumn.ShowInCustomizationForm = despacharConEstadoDeMaterial;
                UiColEstadoSkuSinInventario.Visible = despacharConEstadoDeMaterial;
                UiColEstadoSkuSinInventario.OptionsColumn.ShowInCustomizationForm = despacharConEstadoDeMaterial;
                UiColEstadoDeMaterialConsolidado.Visible = despacharConEstadoDeMaterial;
                UiColEstadoDeMaterialConsolidado.OptionsColumn.ShowInCustomizationForm = despacharConEstadoDeMaterial;
                UiPaginaInventarioDisponible.PageVisible = despacharConEstadoDeMaterial;

                this.UiControDeHeramientas.OptionsMinimizing.State = DevExpress.XtraToolbox.ToolboxState.Normal;

                UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
                UiElementoProyecto.Visibility = LayoutVisibility.Never;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiMenuItemNuevo_ItemClick(object sender, ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void UiMenuItemGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            GuardarPicking(sender);
            UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
        }

        private void UiMenuItemValidar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ValidarSkusConInventario(sender);
            UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
        }

        private void UiMenuItemRefrescar_ItemClick(object sender, ItemClickEventArgs e)
        {
            CargarOrdenesDeVenta(sender);
            UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
        }

        #endregion

        #region Eventos

        private void UiComboFuente_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CargarFiltrosDemandaSegunTipo();
            Cursor.Current = Cursors.Default;
        }

        private void UiNavegacionPaginasPricipal_StateChanged(object sender,
            DevExpress.XtraBars.Navigation.StateChangedEventArgs e)
        {
            ExpandirNavegacionPaginas(sender);
        }

        private void UiNavegacionPaginasPricipal_Leave(object sender, EventArgs e)
        {
            ExpandirNavegacionPaginas(sender);
        }

        private void UiNavegacionPaginasPricipal_DoubleClick(object sender, EventArgs e)
        {
            ExpandirNavegacionPaginas(sender);
        }

        private void UiBotonEliminarOrdenesSinInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColapsarMaestroDetalleVehiculos();
                UsuarioDeseaDescartarTodosEncabezadosConAdvertencia?.Invoke(sender, new OrdenDeVentaArgumento());
                UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();
                LLenarContenedorOrdenDeVentaEncabezado();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenerdoVistaOrdenEncabezado_Click(object sender, EventArgs e)
        {
            UsuarioDeseaVerDetalle();
        }

        private void DemandaDeDespachoVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenerdoVistaOrdenEncabezado, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiContenedorVistaOrdenDetalle, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiGridControlSkusSinInventario, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiGridControlTonosYCalibres, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiContenedorVehiculos, true, Usuario, GetType().Name);
            CargarOGuardarDisenios(UiGridControlOlas, true, Usuario, GetType().Name);
        }

        private void UiContenerdoVistaOrdenEncabezado_FocusedViewChanged(object sender,
            DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            UsuarioDeseaVerDetalle();
        }

        private void UiContenerdoVistaOrdenEncabezado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                UsuarioDeseaVerDetalle();
            }
        }

        private void UiBotonEliminarEncabezado_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (UiVistaOrdenEncabezado.FocusedRowHandle < 0) return;

            var ordenEncabezado =
                (OrdenDeVentaEncabezado)UiVistaOrdenEncabezado.GetRow(UiVistaOrdenEncabezado.FocusedRowHandle);
            UsuarioDeseaDescartarEncabezado?.Invoke(sender,
                new OrdenDeVentaArgumento { OrdenDeVentaEncabezado = ordenEncabezado });

            UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();
        }

        private void UiListaVistaRuntaVendedor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaRutaVendedorCompleta)
                {
                    for (var i = 0; i < UiListaVistaRuntaVendedor.RowCount; i++)
                    {
                        var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaVistaRuntaVendedor.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaRutaVendedorCompleta = false;
                }
            }

            var edit = UiListaRutaVendedor;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaRutas();
        }

        private void UiListaRutaVendedor_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaRutas();
        }

        private void UiListaVistaRuntaVendedor_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;


            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaRutaVendedorCompleta = true;
            }
        }

        private void UiListaVistaRuntaVendedor_BeforeLeaveRow(object sender,
            DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaRuntaVendedor.RowCount; i++)
            {
                var registro = (Ruta)UiListaVistaRuntaVendedor.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaVistaRuntaVendedor.SelectRow(i);
                }
            }
        }

        private void UiListaVistaClienteErpCanalModerno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Cliente)UiListaVistaClienteErpCanalModerno.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaClienteErpCanalModernoCompleta)
                {
                    for (var i = 0; i < UiListaVistaClienteErpCanalModerno.RowCount; i++)
                    {
                        var registro = (Cliente)UiListaVistaClienteErpCanalModerno.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaVistaClienteErpCanalModerno.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaClienteErpCanalModernoCompleta = false;
                }
            }

            var edit = UiListaClienteErpCanalModerno;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaClienteErpCanalModerno();
        }

        private void UiListaClienteErpCanalModerno_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaClienteErpCanalModerno();
        }

        private void UiListaVistaClienteErpCanalModerno_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;


            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClienteErpCanalModernoCompleta = true;
            }
        }

        private void UiListaVistaClienteErpCanalModerno_BeforeLeaveRow(object sender,
            DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVistaClienteErpCanalModerno.RowCount; i++)
            {
                var registro = (Cliente)UiListaVistaClienteErpCanalModerno.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaVistaClienteErpCanalModerno.SelectRow(i);
                }
            }
        }

        private void RefrescarRutaVendedor(object sender)
        {
            if (PoligonosSeleccionados == null || PoligonosSeleccionados.Count == 0)
                UsuarioDeseaObtenerRutas?.Invoke(null, new EventArgs());
            else
                UsuarioSeleccionoPoligonos?.Invoke(sender, new OrdenDeVentaArgumento()
                {
                    CodigosPoligonos =
                        string.Join("|", PoligonosSeleccionados.Select(ps => ps.POLYGON_ID.ToString()).ToArray())
                    ,
                    FuenteExternaPoligonos =
                        string.Join("|", PoligonosSeleccionados.Select(ps => ps.EXTERNAL_SOURCE_ID.ToString()).ToArray())
                    ,
                    FechaInicio = UiFechaInicial.DateTime
                    ,
                    FechaFin = UiFechaFin.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59)
                });
        }

        private void RefrescarClientesErp()
        {
            if (BodegaSeleccionda != string.Empty)
            {
                UsuarioDeseaObtenerClientesErpCanalModerno?.Invoke(null, new OrdenDeVentaArgumento()
                {
                    FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                    FechaFin = Convert.ToDateTime(UiFechaFin.EditValue).AddHours(23).AddMinutes(59).AddSeconds(59),
                    CodigoBodega = BodegaSeleccionda,
                });
            } else
            {
                InteraccionConUsuarioServicio.Mensaje("Cargar clientes requiere al menos una bodega seleccinada.");
            }
        }

        private void UiLista_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBotonRefrescarBodega":
                    UiError.SetError(UIListaBodega, "", ErrorType.None);
                    UsuarioDeseaObtenerBodegasAsignadas?.Invoke(null, new OrdenDeVentaArgumento());
                    break;
                case "UiBotonRefrescarRuntaVendedor":

                    RefrescarRutaVendedor(sender);
                    break;
                case "UiBotonRefrescarUbicacionDeSalida":
                    try 
                    {
                        UiError.SetError(UiListaUbicacionDeSalida, "", ErrorType.None);
                        CargarUbicacionesDeSalida(sender);

                    }
                    catch(System.NullReferenceException)
                    {
                        UiError.SetError(UiListaUbicacionDeSalida, "Por favor seleccionar bodega antes de refrescar ubicaciones");
                    }

                    break;
                case "UiBotonRefrescarClienteErpCanalModerno":
                    RefrescarClientesErp();
                    break;
                case "UiBotonRefrescarLineasDePicking":
                    if (UIListaBodega.EditValue == null) return;
                    UsuarioDeseaObtenerLineasDePickingAsociadasABodega?.Invoke(sender, new OrdenDeVentaArgumento()
                    {
                        CodigoBodega = UIListaBodega.EditValue.ToString()
                    });
                    break;
                case "UiBotonRefrescarListaDePrioridad":
                    UsuarioDeseaObtenerPrioridad?.Invoke(null, new ClaseArgumento());
                    break;
                case "UiBotonRefrescarListaProyecto":
                    UIListaProyecto.EditValue = null;
                    UsuarioDeseaObtenerProyectos?.Invoke(null, new ClaseArgumento());
                    break;
            }
            Cursor.Current = Cursors.Default;
        }

        private void UIListaBodega_EditValueChanged(object sender, EventArgs e)
        {
            CargarUbicacionesDeSalida(sender);
            try
            {
                if (UIListaBodega.EditValue != null)
                {
                    UsuarioDeseaObtenerLineasDePickingAsociadasABodega?.Invoke(sender, new OrdenDeVentaArgumento()
                    {
                        CodigoBodega = UIListaBodega.EditValue.ToString()
                    });


                    if (TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaErp || TipoFuente == TipoFuenteDemandaDespacho.OrdenDeEntrega)
                    {
                        UsuarioDeseaObtenerClientesErpCanalModerno?.Invoke(null, new OrdenDeVentaArgumento()
                        {
                            FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                            FechaFin =
                                Convert.ToDateTime(UiFechaFin.EditValue).AddHours(23).AddMinutes(59).AddSeconds(59),
                            CodigoBodega = BodegaSeleccionda,
                        });
                    }
                    else
                    {
                        UsuarioSeleccionoBodega?.Invoke(sender, new OrdenDeVentaArgumento()
                        {
                            CodigoBodega = UIListaBodega.EditValue.ToString()
                        });
                        CargarPoligonos();
                        ValidarSkusConInventario(null);
                        CargarOrdenesDeVenta(sender);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaOrdenDetalle_ShowingEditor(object sender, CancelEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            var registro = (OrdenDeVentaDetalle)UiVistaOrdenDetalle.GetRow(view.FocusedRowHandle);
            if (registro.QTY_PENDING == 0)
            {
                e.Cancel = true;
            }
        }

        private void UiVistaOrdenDetalle_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            ColapsarMaestroDetalleVehiculos();
            var view = sender as GridView;
            if (view == null) return;

            var registro = (OrdenDeVentaDetalle)UiVistaOrdenDetalle.GetRow(view.FocusedRowHandle);
            var fecha = DateTime.Now;
            var orden = new OrdenDeVentaEncabezado();
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "QTY":
                        var qty = decimal.Parse(e.Value.ToString());
                        if (qty <= registro.QTY_PENDING && qty >= 0)
                        {

                            foreach (
                                var detalle in DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == registro.SALES_ORDER_ID))
                            {
                                detalle.fechaModificacion = fecha;
                            }
                            registro.QTY = qty;
                            orden = OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == registro.SALES_ORDER_ID);
                            ValidarSkusConInventario(null, orden);
                            return;
                        }
                        break;
                    case "STATUS_CODE":
                        foreach (
                            var detalle in DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == registro.SALES_ORDER_ID))
                        {
                            detalle.fechaModificacion = fecha;
                        }
                        registro.STATUS_CODE = e.Value.ToString();
                        orden = OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == registro.SALES_ORDER_ID);
                        ValidarSkusConInventario(null, orden);
                        return;
                        break;
                }


            }
            catch (Exception)
            {
                e.Valid = false;
                e.ErrorText = "Cantidad inválida.";
            }

            e.Valid = false;
            e.ErrorText = "La cantidad sobrepasa lo pendiente o tiene que ser mayor a cero.";
        }

        private void UiBotonDarPrioridadEncabezado_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (UiVistaOrdenEncabezado.FocusedRowHandle < 0) return;

            var ordenEncabezado =
                (OrdenDeVentaEncabezado)UiVistaOrdenEncabezado.GetRow(UiVistaOrdenEncabezado.FocusedRowHandle);

            var fecha = DateTime.Now;
            foreach (
                var detalle in DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == ordenEncabezado.SALES_ORDER_ID))
            {
                detalle.fechaModificacion = fecha;
            }

            ValidarSkusConInventario(null);
            RecargarSeleccionOrdenesDeVentaEncabezado();
        }

        private void UiVistaOrdenEncabezado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (OrdenDeVentaEncabezado)UiVistaOrdenEncabezado.GetRow(e.ControllerRow);
                documento.IS_SELECTD = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaEncabezadoCompleta)
                {
                    for (var i = 0; i < UiVistaOrdenEncabezado.RowCount; i++)
                    {
                        var documento = (OrdenDeVentaEncabezado)UiVistaOrdenEncabezado.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTD = (UiVistaOrdenEncabezado.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaEncabezadoCompleta = false;
                }
            }
        }

        private void UiVistaOrdenEncabezado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaEncabezadoCompleta = true;
            }
        }

        private void UiVistaOrdenEncabezado_BeforeLeaveRow(object sender,
            DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            RecargarSeleccionOrdenesDeVentaEncabezado();
        }

        private void UiVistaOrdenEncabezado_ColumnFilterChanged(object sender, EventArgs e)
        {
            RecargarSeleccionOrdenesDeVentaEncabezado();
        }

        private void UiBtnVerTonosYCalibres_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            MostrarInventarioPorTonoOCalibre();
        }


        private void UiMapControlPoligonos_SelectionChanged(object sender, MapSelectionChangedEventArgs e)
        {
            try
            {
                PoligonosSeleccionados = new List<Poligono>();
                if (e.Selection == null || e.Selection.Count == 0) return;
                foreach (var sel in e.Selection)
                {
                    var p = (Poligono)sel;
                    PoligonosSeleccionados.Add(p);
                }

                UsuarioSeleccionoPoligonos?.Invoke(sender, new OrdenDeVentaArgumento()
                {
                    CodigosPoligonos =
                        string.Join("|", PoligonosSeleccionados.Select(ps => ps.POLYGON_ID.ToString()).ToArray())
                    ,
                    FuenteExternaPoligonos =
                        string.Join("|", PoligonosSeleccionados.Select(ps => ps.EXTERNAL_SOURCE_ID.ToString()).ToArray())
                    ,
                    FechaInicio = UiFechaInicial.DateTime
                    ,
                    FechaFin = UiFechaFin.DateTime.AddHours(23).AddMinutes(59).AddSeconds(59)
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        #region Metodos

        private void CargarPoligonos()
        {
            UiMapControlPoligonos.CenterPoint = _puntoInicial;
            var vectorLayer = (VectorItemsLayer)UiMapControlPoligonos.Layers["Poligonos"];
            var storage = new MapItemStorage();
            storage.Items.AddRange(Poligonos.ToList());
            vectorLayer.Data = storage;
        }


        private void ExpandirNavegacionPaginas(object sender)
        {
            try
            {
                ((NavigationPane)sender).State = NavigationPaneState.Expanded;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Navegación cambia de estado: " + ex.Message);
            }
        }

        private void RecargarSeleccionOrdenesDeVentaEncabezado()
        {
            for (var i = 0; i < UiVistaOrdenEncabezado.RowCount; i++)
            {
                var documento = (OrdenDeVentaEncabezado)UiVistaOrdenEncabezado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTD)
                {
                    UiVistaOrdenEncabezado.SelectRow(i);
                }
            }
        }

        private void CargarUbicacionesDeSalida(object sender)
        {
            UsuarioDeseaObtenerUbicacionesDeSalida?.Invoke(sender, new BodegaArgumento { BodegaId = UIListaBodega.EditValue.ToString() }) ;
        }

        private bool ValidarBodega()
        {

            if (UIListaBodega.EditValue != null) return true;
            UiError.SetError(UIListaBodega, "Seleccione la bodega");
            return false;
        }

        private bool ValidarClienteErpCanalModerno()
        {
            UiError.SetError(UiListaClienteErpCanalModerno, "", ErrorType.None);

            if (ClientesErpCanalModerno.ToList().Exists(c => c.IS_SELECTED)) return true;

            return false;
        }

        private void LimpiarCampos()
        {
            UiListaUbicacionDeSalida.EditValue = null;
            UiListaLineasDePicking.EditValue = null;
            UIListaBodega.EditValue = null;
            UiContenedorVistaOrdenDetalle.DataSource = null;
            UiContenerdoVistaOrdenEncabezado.DataSource = null;
            UiGridControlSkusSinInventario.DataSource = null;
            UiGridControlTonosYCalibres.DataSource = null;
            UiListaClienteErpCanalModerno.Properties.DataSource = null;
            RefrescarRutaVendedor(null);
            UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
            UiSpinNumeroDocumentoControl.EditValue = 0;
            UiTextoNumeroOrden.EditValue = null;
            UIListaProyecto.EditValue = null;
            UIListaProyecto.Properties.DataSource = null;
        }

        private void CargarOrdenesDeVenta(object sender)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                switch (TipoInventario)
                {
                    case TipoDeInventario.General:
                        ColapsarMaestroDetalleVehiculos();
                        if (!ValidarBodega()) return;
                        var codigosFuesteRutas = new StringBuilder();
                        var codigosRutas = new StringBuilder();
                        var codigosClientesErpCanalModerno = new StringBuilder();
                        UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();

                        if (TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaSonda)
                        {
                            foreach (var ruta in Rutas.Where(r => r.IS_SELECTED))
                            {
                                if (codigosFuesteRutas.Length > 0)
                                {
                                    codigosFuesteRutas.Append("|");
                                }
                                codigosFuesteRutas.Append(ruta.EXTERNAL_SOURCE_ID);

                                if (codigosRutas.Length > 0)
                                {
                                    codigosRutas.Append("|");
                                }
                                codigosRutas.Append(ruta.CODE_ROUTE);
                            }
                        }
                        if (TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaErp)
                        {

                            UiError.SetError(UiSpinNumeroDocumentoControl, "", ErrorType.None);
                            if (!ValidarClienteErpCanalModerno())
                            {
                                if (int.Parse(UiSpinNumeroDocumentoControl.EditValue.ToString()) <= 0)
                                {
                                    UiError.SetError(UiListaClienteErpCanalModerno, "Seleccione un cliente.");
                                    UiError.SetError(UiSpinNumeroDocumentoControl, "Ingrese un Numero de Documento.");
                                    return;
                                }

                            }

                            foreach (var cliente in ClientesErpCanalModerno.Where(r => r.IS_SELECTED &&
                                                                                       (ProyectoSeleccionado.ID == Guid.Empty ||
                                                                                        ProyectoSeleccionado.CUSTOMER_CODE.Equals(r.MASTER_ID))))
                            {
                                if (codigosClientesErpCanalModerno.Length > 0)
                                {
                                    codigosClientesErpCanalModerno.Append("|");
                                }
                                codigosClientesErpCanalModerno.Append(cliente.MASTER_ID);
                            }
                        }


                        switch (TipoFuente)
                        {
                            case TipoFuenteDemandaDespacho.OrdenDeEntrega:
                                UsuarioDeseaObtenerOrdenesDeEntregaPorFecha?.Invoke(sender, new OrdenDeVentaArgumento
                                {
                                    FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                                    FechaFin =
                                        Convert.ToDateTime(UiFechaFin.EditValue)
                                            .AddHours(23)
                                            .AddMinutes(59)
                                            .AddSeconds(59),
                                    CodigoBodega = BodegaSeleccionda,
                                    CodigosClientesErpCanalModerno = codigosClientesErpCanalModerno.ToString(),
                                    DocNum = UiSpinNumeroDocumentoControl.EditValue.ToString()
                                });
                                break;
                            case TipoFuenteDemandaDespacho.OrdenVentaSonda:
                            case TipoFuenteDemandaDespacho.OrdenVentaErp:
                                UsuarioDeseaObtenerOrdenesDeVentaPorFecha?.Invoke(sender, new OrdenDeVentaArgumento
                                {
                                    FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                                    FechaFin =
                                        Convert.ToDateTime(UiFechaFin.EditValue)
                                            .AddHours(23)
                                            .AddMinutes(59)
                                            .AddSeconds(59),
                                    CodigosFuenteRuta = codigosFuesteRutas.ToString(),
                                    CodigosRuta = codigosRutas.ToString(),
                                    CodigoBodega = BodegaSeleccionda,
                                    CodigosClientesErpCanalModerno = codigosClientesErpCanalModerno.ToString(),
                                    CodigosPoligonos =
                                        string.Join("|",
                                            PoligonosSeleccionados.Select(ps => ps.POLYGON_ID.ToString()).ToArray()),
                                    FuenteExternaPoligonos =
                                        string.Join("|",
                                            PoligonosSeleccionados.Select(ps => ps.EXTERNAL_SOURCE_ID.ToString())
                                                .ToArray())
                                    ,
                                    UsaLineaDePicking = Convert.ToInt32(UiListaUsaLineaDePicking.EditValue)
                                    ,
                                    DocNum = UiSpinNumeroDocumentoControl.EditValue.ToString()
                                });
                                UsuarioDeseaObtenerProyectos?.Invoke(null, new ClaseArgumento());
                                break;
                            case TipoFuenteDemandaDespacho.SolicitudTrasladoErp:
                            case TipoFuenteDemandaDespacho.SolicitudTrasladoWms:
                                UsuarioDeseaObtenerSolicitudesDeTransferencia?.Invoke(sender, new OrdenDeVentaArgumento
                                {
                                    FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                                    FechaFin = Convert.ToDateTime(UiFechaFin.EditValue).AddHours(23),
                                    CodigosFuenteRuta = codigosFuesteRutas.ToString(),
                                    CodigosRuta = codigosRutas.ToString(),
                                    CodigoBodega = BodegaSeleccionda,
                                    CodigosClientesErpCanalModerno = codigosClientesErpCanalModerno.ToString()
                                });
                                break;
                        }

                        if (Skus.Count > 0)
                        {
                            UiNavegacionPaginasPricipal.SelectedPage = UiPaginaInventario;
                            UiControDeHeramientas.Show();
                        }
                        LLenarContenedorOrdenDeVentaEncabezado();
                        UsuarioDeseaVerDetalle();
                        break;

                    case TipoDeInventario.Preparado:
                        RefrescarListadoDeOrdenesDeVentaPreparadasPorFecha(sender);
                        break;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void ValidarSkusConInventario(object sender, OrdenDeVentaEncabezado orden = null)
        {
            try
            {
                if (!ValidarBodega()) return;
                UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();
                UsuarioDeseaValidarInventarioParaOrdenDeVenta?.Invoke(sender, new SkuArgumento());
                LLenarContenedorOrdenDeVentaEncabezado();
                UsuarioDeseaVerDetalle(orden);

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void GuardarPicking(object sender)
        {
            try
            {
                UiError.SetError(UiListaUbicacionDeSalida, "", ErrorType.None);
                UiError.SetError(UiListaPrioridad, "", ErrorType.None);
                if (UiSwitchEntregaInmediata.Checked &&
                    (UiListaUbicacionDeSalida.EditValue == null || UiListaUbicacionDeSalida.EditValue.ToString() == ""))
                {
                    UiError.SetError(UiListaUbicacionDeSalida, "Seleccione la Ubicación de Salida");
                    InteraccionConUsuarioServicio.Mensaje(
                        "Debe de elegir una Ubicación de salida para poder realizar un Picking");
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
                    UiListaUbicacionDeSalida.Focus();
                    return;
                }

                if (UiListaPrioridad.EditValue == null ||
                    (UiSwitchEntregaInmediata.Checked && UiListaUbicacionDeSalida.EditValue.ToString() == ""))
                {
                    UiError.SetError(UiListaPrioridad, "Seleccione la prioridad de la tarea");
                    InteraccionConUsuarioServicio.Mensaje("Debe de elegir una prioridad para poder realizar un Picking");
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
                    UiListaPrioridad.Focus();
                    return;
                }

                UiError.SetError(UiListaUbicacionDeSalida, "", ErrorType.None);

                UiError.SetError(UiListaLineasDePicking, "", ErrorType.None);
                UsuarioDeseaValidarInventarioParaOrdenDeVenta?.Invoke(sender, new SkuArgumento());
                if (OrdenesDeVenta.ToList().Exists(o => o.AdvertenciaFaltaInventario == 1) || Skus.Count > 0)
                {
                    InteraccionConUsuarioServicio.Mensaje(
                        "No se cuenta con suficiente inventario para realizar Pickings");
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaInventario;
                    return;
                }
                if (OrdenesDeVenta.Count <= 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("No hay documentos para guardar.");
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
                    return;
                }
                UsuarioDeseaCrearPickingDeOrdenDeVenta?.Invoke(sender, new PickingArgumento
                {
                    ManejaLineaDePicking =
                        !(UiListaLineasDePicking.EditValue == null || UiListaLineasDePicking.EditValue.ToString() == ""),
                    LineaDePicking = UiListaLineasDePicking.EditValue?.ToString()
                    ,
                    PrioridadDeTarea = int.Parse(UiListaPrioridad.EditValue.ToString())
                });
                UiTextoNumeroOrden.EditValue = null;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message) ;
            }
        }

        private void UsuarioDeseaVerDetalle(OrdenDeVentaEncabezado orden = null)
        {
            if (UiVistaOrdenEncabezado.FocusedRowHandle < 0)
            {
                UiContenedorVistaOrdenDetalle.DataSource = null;
                return;
            }

            var ordenEncabezado = orden ??
                                  (OrdenDeVentaEncabezado)
                                  UiVistaOrdenEncabezado.GetRow(UiVistaOrdenEncabezado.FocusedRowHandle);

            bool pAlt = bool.Parse(ConfigurationManager.AppSettings["PaseDeSalidaAlt"]);
            
            if (pAlt)
            {
                UiContenedorVistaOrdenDetalle.DataSource = DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == ordenEncabezado.SALES_ORDER_ID).ToList();

            }
            else
            {
                UiContenedorVistaOrdenDetalle.DataSource = TipoFuente != TipoFuenteDemandaDespacho.SolicitudTrasladoErp
               ? DetallesOrdenDeVenta.Where(
                   det =>
                       det.SALES_ORDER_ID == ordenEncabezado.SALES_ORDER_ID &&
                       det.MATERIAL_OWNER == ordenEncabezado.OWNER &&
                       det.EXTERNAL_SOURCE_ID == ordenEncabezado.EXTERNAL_SOURCE_ID &&
               (FiltroDeUsaLineaDePicking == (int)Tipos.UsaLineaDePicking.Ambas ||
                det.USE_PICKING_LINE == FiltroDeUsaLineaDePicking)).ToList()
               : DetallesOrdenDeVenta.Where(
                   det =>
                       det.SALES_ORDER_ID == ordenEncabezado.SALES_ORDER_ID &&
                       det.EXTERNAL_SOURCE_ID == ordenEncabezado.EXTERNAL_SOURCE_ID &&
                       det.SOURCE == ordenEncabezado.OWNER).ToList();
            }           
        }

        private string ObtenerTextoAMostrarListaRutas()
        {
            if (Rutas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Rutas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0)
                {
                    cadena.Append(",");
                }
                cadena.Append(documento.CODE_ROUTE + "|" + documento.SELLER_CODE);
            }

            return cadena.ToString();
        }

        private string ObtenerTextoAMostrarListaClienteErpCanalModerno()
        {
            if (ClientesErpCanalModerno == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in ClientesErpCanalModerno.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0)
                {
                    cadena.Append(",");
                }
                cadena.Append(documento.CLIENT_ID + "|" + documento.CLIENT_NAME);
            }

            return cadena.ToString();
        }

        public void RefrescarVistaOrdenes()
        {
            CargarOrdenesDeVenta(null);
        }

        private bool ValidarPuentoGps(Parametro parametroNext, Entidades.Configuracion puntoGps)
        {
            return parametroNext != null && int.Parse(parametroNext.VALUE) == (int)SiNo.Si && puntoGps != null
                   && puntoGps.TEXT_VALUE != string.Empty && puntoGps.TEXT_VALUE.Split(',').Length > 1 &&
                   GeoPoint.Parse(puntoGps.TEXT_VALUE) != null;
        }

        #endregion

        #region Consolidado

        #region Eventos de Controles

        private void UiSwiftConsolidado_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            UIListaBodega.Focus();
            DetallesOrdenDeVentaConsolidado.ForEach(dc =>
            {
                dc.TONE = string.Empty;
                dc.CALIBER = string.Empty;
            });
            DetallesOrdenDeVenta.ForEach(dt =>
            {
                dt.TONE = string.Empty;
                dt.CALIBER = string.Empty;
            });

            if (UiSwiftConsolidado.Checked)
            {
                DetallesOrdenDeVenta.ForEach(dt =>
                {
                    dt.STATUS_CODE_CONSOLIDATED = dt.STATUS_CODE;
                    dt.STATUS_CODE = EstadoPredeterminadoDeMaterial.PARAM_NAME;
                });
            }
            else
            {
                DetallesOrdenDeVenta.ForEach(dt =>
                {
                    dt.STATUS_CODE = dt.STATUS_CODE_CONSOLIDATED;
                });
            }

            ValidarSkusConInventario(null);
            LLenarContenedorOrdenDeVentaEncabezado();

            UsuarioCambioValorDeSwitchDeConsolidado?.Invoke(sender, new ConsultaArgumento
            {
                SiNo = UiSwiftConsolidado.Checked
            });
        }

        private void UiVistaOrdenesDeCompraConsolidado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (OrdenDeVentaDetalle)UiVistaOrdenesDeCompraConsolidado.GetRow(e.ControllerRow);
                documento.IS_SELECTD = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoVistaConsolidadoCompleta)
                {
                    for (var i = 0; i < UiVistaOrdenesDeCompraConsolidado.RowCount; i++)
                    {
                        var documento = (OrdenDeVentaDetalle)UiVistaOrdenesDeCompraConsolidado.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTD = (UiVistaOrdenesDeCompraConsolidado.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoVistaConsolidadoCompleta = false;
                }
            }
        }

        private void UiVistaOrdenesDeCompraConsolidado_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoVistaConsolidadoCompleta = true;
            }
        }

        private void UiVistaOrdenesDeCompraConsolidado_BeforeLeaveRow(object sender,
            DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaOrdenesDeCompraConsolidado.RowCount; i++)
            {
                var documento = (OrdenDeVentaDetalle)UiVistaOrdenesDeCompraConsolidado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTD)
                {
                    UiVistaOrdenesDeCompraConsolidado.SelectRow(i);
                }
            }
        }

        private void UiVistaOrdenesDeCompraConsolidado_ColumnFilterChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < UiVistaOrdenesDeCompraConsolidado.RowCount; i++)
            {
                var documento = (OrdenDeVentaDetalle)UiVistaOrdenesDeCompraConsolidado.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTD)
                {
                    UiVistaOrdenesDeCompraConsolidado.SelectRow(i);
                }
            }
        }

        private void UiVistaOrdenesDeCompraConsolidado_ValidatingEditor(object sender,
            BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) ;

            var registro = (OrdenDeVentaDetalle)UiVistaOrdenesDeCompraConsolidado.GetRow(view.FocusedRowHandle);
            decimal qty = 0;
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "QTY":
                        qty = decimal.Parse(e.Value.ToString());
                        if (qty <= registro.QTY_PENDING && qty >= 0)
                        {
                            AjustarDetallePorConsolidado(registro.SKU, qty, registro.TONE, registro.CALIBER, registro.STATUS_CODE);
                            return;
                        }
                        e.Valid = false;
                        e.ErrorText = "La cantidad sobrepasa lo pendiente o tiene que ser mayor o igual cero.";
                        break;
                    case "STATUS_CODE":
                        registro.STATUS_CODE = e.Value.ToString();
                        AjustarDetallePorConsolidado(registro.SKU, registro.QTY, registro.TONE, registro.CALIBER, registro.STATUS_CODE);
                        return;
                }
            }
            catch (Exception)
            {
                e.Valid = false;
                e.ErrorText = "La cantidad inválida.";
            }

        }

        private void UiBotonEliminar_ItemClick(object sender, ItemClickEventArgs e)
        {
            ColapsarMaestroDetalleVehiculos();
            EliminarRegistros(true);
            UsuarioDeseaVerDetalle();
        }

        #endregion

        #region Metodos

        private void LLenarContenedorOrdenDeVentaEncabezado()
        {
            try
            {
                UiContenerdoVistaOrdenEncabezado.DataSource = null;
                if (EsConsolidado)
                {
                    UiEtiquetaEncabezado.Text = @"Consolidado";
                    UiContenerdoVistaOrdenEncabezado.MainView = UiVistaOrdenesDeCompraConsolidado;
                    UiControlSplitOrdenes.PanelVisibility = SplitPanelVisibility.Panel1;
                    var MIN_DAYS_EXPIRATION_DATE = OrdenesDeVenta.Max(d => d.MIN_DAYS_EXPIRATION_DATE); ;
                    DetallesOrdenDeVentaConsolidado.ForEach(d => d.MIN_DAYS_EXPIRATION_DATE = MIN_DAYS_EXPIRATION_DATE);
                    UiContenerdoVistaOrdenEncabezado.DataSource = DetallesOrdenDeVentaConsolidado;
                }
                else
                {
                    UiContenerdoVistaOrdenEncabezado.Focus();
                    switch (TipoFuente)
                    {
                        case TipoFuenteDemandaDespacho.OrdenVentaErp:
                            UiEtiquetaEncabezado.Text = @"Órdenes De Venta";
                            break;
                        case TipoFuenteDemandaDespacho.OrdenVentaSonda:
                            UiEtiquetaEncabezado.Text = @"Órdenes De Venta";
                            break;
                        case TipoFuenteDemandaDespacho.SolicitudTrasladoWms:
                            UiEtiquetaEncabezado.Text = @"Solicitudes de Traslado";
                            break;
                        case TipoFuenteDemandaDespacho.SolicitudTrasladoErp:
                            UiEtiquetaEncabezado.Text = @"Solicitudes de Traslado";
                            break;
                    }
                    DetallesOrdenDeVentaConsolidado.ForEach(d => d.MIN_DAYS_EXPIRATION_DATE = 0);
                    UiContenerdoVistaOrdenEncabezado.MainView = UiVistaOrdenEncabezado;
                    UiControlSplitOrdenes.PanelVisibility = SplitPanelVisibility.Both;
                    UiContenerdoVistaOrdenEncabezado.DataSource = OrdenesDeVenta;
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void AjustarDetallePorConsolidado(string sku, decimal qty, string tone, string caliber, string statusCode)
        {
            try
            {
                var cantidad = qty;
                foreach (
                    var registro in
                    DetallesOrdenDeVenta.Where(detOr => detOr.SKU == sku)
                        .OrderByDescending(det => det.fechaModificacion))
                {
                    registro.STATUS_CODE = statusCode;
                    registro.TONE = tone;
                    registro.CALIBER = caliber;
                    registro.QTY = registro.QTY_PENDING;
                    if (cantidad <= 0)
                    {
                        registro.QTY = 0;
                    }

                    if (registro.QTY_PENDING < cantidad)
                    {
                        cantidad = cantidad - Convert.ToDecimal(registro.QTY_PENDING);
                    }
                    else
                    {
                        registro.QTY = cantidad;
                        cantidad = 0;
                    }
                }
                ValidarSkusConInventario(null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void EliminarRegistros(bool boorarSeleccionados)
        {
            try
            {
                usuarioDeseaEliminarRegistros?.Invoke(null, new OrdenDeVentaArgumento { BorrarSeleccionados = boorarSeleccionados });
                LLenarContenedorOrdenDeVentaEncabezado();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void MostrarInventarioPorTonoOCalibre()
        {
            try
            {
                UiColTonoDetalle.Visible = EsPorTonoOCalibre;
                UiColTonoDetalle.OptionsColumn.ShowInCustomizationForm = EsPorTonoOCalibre;
                UiColCalibreDetalle.Visible = EsPorTonoOCalibre;
                UiColCalibreDetalle.OptionsColumn.ShowInCustomizationForm = EsPorTonoOCalibre;
                UiColTonoConsolidado.Visible = EsPorTonoOCalibre;
                UiColTonoConsolidado.OptionsColumn.ShowInCustomizationForm = EsPorTonoOCalibre;
                UiColCailbreConsolidado.Visible = EsPorTonoOCalibre;
                UiColCailbreConsolidado.OptionsColumn.ShowInCustomizationForm = EsPorTonoOCalibre;
                UiPaginaTonoCalibre.PageVisible = EsPorTonoOCalibre;
                if (UiNavegacionPaginasPricipal.SelectedPage == UiPaginaTonoCalibre && !EsPorTonoOCalibre)
                {
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
                }

                DetallesOrdenDeVentaConsolidado.ForEach(dc =>
                {
                    dc.TONE = string.Empty;
                    dc.CALIBER = string.Empty;
                });

                DetallesOrdenDeVenta.ForEach(dt =>
                {
                    dt.TONE = string.Empty;
                    dt.CALIBER = string.Empty;
                });
                ValidarSkusConInventario(null);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        #endregion

        #endregion

        GridHitInfo downHitInfo = null;

        private void UiVistaTonosYCalibres_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                downHitInfo = null;

                if (view == null) return;
                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));

                if (Control.ModifierKeys != Keys.None) return;

                if (e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)

                    downHitInfo = hitInfo;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaTonosYCalibres_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var view = sender as GridView;

                if (e.Button != MouseButtons.Left || downHitInfo == null) return;
                Size dragSize = SystemInformation.DragSize;

                var dragRect =
                    new Rectangle(
                        new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                            downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);


                if (dragRect.Contains(new Point(e.X, e.Y))) return;
                if (view != null)
                {
                    var row = view.GetRow(downHitInfo.RowHandle);

                    view.GridControl.DoDragDrop(row, DragDropEffects.Copy);
                }

                downHitInfo = null;

                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
            }

            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenedorVistaOrdenDetalle_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var materialConTonoYCalibre = (MaterialConTonoYCalibre)e.Data.GetData(typeof(MaterialConTonoYCalibre));
                if (UiContenedorVistaOrdenDetalle.MainView.Name != "UiVistaOrdenDetalle") return;
                AsociaMaterialConTonoOCalibreParaDetalle(materialConTonoYCalibre);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenedorVistaOrdenDetalle_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(MaterialConTonoYCalibre))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void UiContenedorVistaOrdenDetalle_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void AsociaMaterialConTonoOCalibreParaDetalle(MaterialConTonoYCalibre materialConTonoYCalibre)
        {
            try
            {
                var registro = (OrdenDeVentaDetalle)UiVistaOrdenDetalle.GetRow(UiVistaOrdenDetalle.FocusedRowHandle);
                if (registro == null || !registro.SKU.Equals(materialConTonoYCalibre.MATERIAL_ID)) return;
                registro.TONE = materialConTonoYCalibre.TONE;
                registro.CALIBER = materialConTonoYCalibre.CALIBER;

                var fecha = DateTime.Now;
                DetallesOrdenDeVenta.Where(det => det.SALES_ORDER_ID == registro.SALES_ORDER_ID).ForEach(d =>
                {
                    d.fechaModificacion = fecha;
                });

                var orden = OrdenesDeVenta.FirstOrDefault(x => x.SALES_ORDER_ID == registro.SALES_ORDER_ID);
                ValidarSkusConInventario(null, orden);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenerdoVistaOrdenEncabezado_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var materialConTonoYCalibre = (MaterialConTonoYCalibre)e.Data.GetData(typeof(MaterialConTonoYCalibre));
                if (UiContenerdoVistaOrdenEncabezado.MainView.Name != "UiVistaOrdenesDeCompraConsolidado") return;
                AsociaMaterialConTonoOCalibreParaConsolidado(materialConTonoYCalibre);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiContenerdoVistaOrdenEncabezado_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(MaterialConTonoYCalibre))
                ? DragDropEffects.Copy
                : DragDropEffects.None;
        }

        private void UiContenerdoVistaOrdenEncabezado_DragLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void AsociaMaterialConTonoOCalibreParaConsolidado(MaterialConTonoYCalibre materialConTonoYCalibre)
        {
            try
            {
                var registro =
                    (OrdenDeVentaDetalle)
                    UiVistaOrdenesDeCompraConsolidado.GetRow(UiVistaOrdenesDeCompraConsolidado.FocusedRowHandle);
                if (registro == null || !registro.SKU.Equals(materialConTonoYCalibre.MATERIAL_ID)) return;
                registro.TONE = materialConTonoYCalibre.TONE;
                registro.CALIBER = materialConTonoYCalibre.CALIBER;

                var cantidad =
                    DetallesOrdenDeVentaConsolidado.Where(dc => dc.SKU == materialConTonoYCalibre.MATERIAL_ID)
                        .Sum(d => d.QTY);

                AjustarDetallePorConsolidado(registro.SKU, cantidad, materialConTonoYCalibre.TONE,
                    materialConTonoYCalibre.CALIBER, registro.STATUS_CODE);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void UiVistaVehiculos_MouseDown(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            _downHitInfoVistaVehiculos = null;

            if (view == null) return;
            var hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                _downHitInfoVistaVehiculos = hitInfo;
        }

        private void UiVistaVehiculos_MouseMove(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;
            if (e.Button != MouseButtons.Left || _downHitInfoVistaVehiculos == null) return;

            var dragSize = SystemInformation.DragSize;
            var dragRect = new Rectangle(new Point(_downHitInfoVistaVehiculos.HitPoint.X - dragSize.Width / 2,
                _downHitInfoVistaVehiculos.HitPoint.Y - dragSize.Height / 2), dragSize);

            if (dragRect.Contains(new Point(e.X, e.Y))) return;

            view.GridControl.DoDragDrop(_downHitInfoVistaVehiculos, DragDropEffects.All);
            _downHitInfoVistaVehiculos = null;
        }

        private void UiContenedorVehiculos_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GridHitInfo))) return;

            var _downHitInfoVistaVehiculos = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            if (_downHitInfoVistaVehiculos == null)
                return;

            var grid = sender as GridControl;
            var view = grid?.MainView as GridView;
            if (view == null) return;

            var hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            if (hitInfo.InRow && hitInfo.RowHandle != _downHitInfoVistaVehiculos.RowHandle &&
                hitInfo.RowHandle != GridControl.NewItemRowHandle)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void UiContenedorVehiculos_DragDrop(object sender, DragEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid?.MainView as GridView;
            if (view == null) return;

            var srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            if (srcHitInfo == null || srcHitInfo.HitTest == GridHitTest.CellButton) return;

            var hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            var sourceRow = srcHitInfo.RowHandle;
            var targetRow = hitInfo.RowHandle;
            ReordenarVehiculos(sourceRow, targetRow, sender);
        }

        private void ReordenarVehiculos(int sourceRow, int targetRow, object sender)
        {
            if (sourceRow < 0 || targetRow < 0 || targetRow >= Vehiculos.Count || sourceRow >= Vehiculos.Count)
                return;

            var vehiculoFuente = Vehiculos[sourceRow];
            var vehiculoDestino = Vehiculos[targetRow];

            if (vehiculoFuente.PRIORITY == 9999 || vehiculoDestino.PRIORITY == 9999) return;

            ColapsarMaestroDetalleVehiculos();

            UsuarioDeseaCambiarElOrdenDeVehiculos?.Invoke(sender, new PickingArgumento()
            {
                Vehiculos = Vehiculos,
                Vehiculo = vehiculoFuente,
                PrioridadNueva = vehiculoDestino.PRIORITY
            });
        }
        public void CargarFiltrosDemandaSegunTipo()
        {
            try
            {
                if (UiComboFuente.EditValue != null) { 
                    var fuente =
                        EnumsOperations.GetEnumValueFromStringValue<TipoFuenteDemandaDespacho>(
                            UiComboFuente.EditValue.ToString());
                    var usaNext =
                        Parametros.FirstOrDefault(x => x.PARAMETER_ID == Enums.GetStringValue(IdParametro.TieneNext));
                    TipoFuente = fuente == 0 ? TipoFuenteDemandaDespacho.OrdenDeEntrega : fuente;
                    switch (TipoFuente)
                    {
                        case TipoFuenteDemandaDespacho.OrdenDeEntrega:
                        case TipoFuenteDemandaDespacho.OrdenVentaErp:
                            UiEspacioCliente.Visibility = LayoutVisibility.Always;
                            UiSeparadorCliente.Visibility = LayoutVisibility.Always;
                            UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Always;
                            UiEspacioRuta.Visibility = LayoutVisibility.Never;
                            UiSeparadorRutaYVendedor.Visibility = LayoutVisibility.Never;
                            UiSwiftConsolidado.Visibility = BarItemVisibility.Always;
                            UiEspacioLinea.Visibility = PermisoLineaDePicking
                                ? LayoutVisibility.Always
                                : LayoutVisibility.Never;
                            UiSeparadorLineaPicking.Visibility = PermisoLineaDePicking
                                ? LayoutVisibility.Always
                                : LayoutVisibility.Never;
                            UiEspacioMapa.Visibility = LayoutVisibility.Never;

                            UiEtiquetaEncabezado.Text = @"Órdenes De Venta";

                            UiPaginaVehiculos.PageVisible = (usaNext != null && usaNext.VALUE == ((int)SiNo.Si).ToString());
                            UiSpinNumeroDocumento.Visibility = LayoutVisibility.Always;
                            UiElementoProyecto.Visibility = LayoutVisibility.Always;
                            ProyectoSeleccionado = new Proyecto();

                            break;
                        case TipoFuenteDemandaDespacho.OrdenVentaSonda:
                            UiEtiquetaEncabezado.Text = @"Órdenes De Venta";
                            UiEspacioRuta.Visibility = LayoutVisibility.Always;
                            UiSeparadorRutaYVendedor.Visibility = LayoutVisibility.Always;
                            UiEspacioCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Always;
                            UiSwiftConsolidado.Visibility = BarItemVisibility.Always;
                            UiEspacioLinea.Visibility = PermisoLineaDePicking
                                ? LayoutVisibility.Always
                                : LayoutVisibility.Never;
                            UiSeparadorLineaPicking.Visibility = PermisoLineaDePicking
                                ? LayoutVisibility.Always
                                : LayoutVisibility.Never;
                            UiEspacioMapa.Visibility = (usaNext != null && usaNext.VALUE == ((int)SiNo.Si).ToString()
                                ? LayoutVisibility.Always
                                : LayoutVisibility.Never);

                            UiPaginaVehiculos.PageVisible = (usaNext != null && usaNext.VALUE == ((int)SiNo.Si).ToString());
                            UiSpinNumeroDocumento.Visibility = LayoutVisibility.Never;

                            UiElementoProyecto.Visibility = LayoutVisibility.Never;
                            ProyectoSeleccionado = new Proyecto();
                            break;
                        case TipoFuenteDemandaDespacho.SolicitudTrasladoWms:
                            UiEtiquetaEncabezado.Text = @"Solicitudes de Traslado";

                            UiSwiftConsolidado.Visibility = BarItemVisibility.Never;
                            UiEspacioRuta.Visibility = LayoutVisibility.Never;
                            UiSeparadorRutaYVendedor.Visibility = LayoutVisibility.Never;
                            UiEspacioCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Always;
                            UiEspacioLinea.Visibility = LayoutVisibility.Never;
                            UiSeparadorLineaPicking.Visibility = LayoutVisibility.Never;
                            UiEspacioMapa.Visibility = LayoutVisibility.Never;
                            FiltroDeUsaLineaDePicking = (int)Tipos.UsaLineaDePicking.Ambas;
                            UiListaUsaLineaDePicking.EditValue = FiltroDeUsaLineaDePicking;

                            UiPaginaVehiculos.PageVisible = false;
                            UiSpinNumeroDocumento.Visibility = LayoutVisibility.Never;
                            UiElementoProyecto.Visibility = LayoutVisibility.Never;
                            ProyectoSeleccionado = new Proyecto();
                            break;
                        case TipoFuenteDemandaDespacho.SolicitudTrasladoErp:
                            UiEtiquetaEncabezado.Text = @"Solicitudes de Traslado";
                            UiEspacioCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorCliente.Visibility = LayoutVisibility.Never;
                            UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Always;
                            UiEspacioLinea.Visibility = LayoutVisibility.Never;
                            UiSeparadorLineaPicking.Visibility = LayoutVisibility.Never;
                            UiEspacioRuta.Visibility = LayoutVisibility.Never;
                            UiSeparadorRutaYVendedor.Visibility = LayoutVisibility.Never;
                            UiEspacioMapa.Visibility = LayoutVisibility.Never;
                            UiSwiftConsolidado.Visibility = BarItemVisibility.Never;
                            FiltroDeUsaLineaDePicking = (int)Tipos.UsaLineaDePicking.Ambas;
                            UiListaUsaLineaDePicking.EditValue = FiltroDeUsaLineaDePicking;

                            UiPaginaVehiculos.PageVisible = false;
                            UiSpinNumeroDocumento.Visibility = LayoutVisibility.Never;
                            UiElementoProyecto.Visibility = LayoutVisibility.Never;
                            ProyectoSeleccionado = new Proyecto();
                            break;
                    }
                    CambiarVisualizacionEntregaNoInmediata();
                    CambiarVisibilidadDeEntregaInmediata(null);
                    OrdenesDeVenta = new List<OrdenDeVentaEncabezado>();
                    DetallesOrdenDeVenta = new List<OrdenDeVentaDetalle>();
                    Skus = new List<Sku>();
                    UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();
                    UiContenerdoVistaOrdenEncabezado.DataSource = new List<OrdenDeVentaEncabezado>();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
        public void ColapsarMaestroDetalleVehiculos()
        {
            var view = UiContenedorVehiculos?.MainView as GridView;
            if (view == null) return;
            view.BeginUpdate();
            try
            {
                var dataRowCount = view.DataRowCount;
                for (var rHandle = 0; rHandle < dataRowCount; rHandle++)
                    view.SetMasterRowExpanded(rHandle, false);
            }
            finally
            {
                view.EndUpdate();
            }
        }

        private void UiListaLineasDePicking_EditValueChanged(object sender, EventArgs e)
        {
            UiEspacioUsaLineaDePicking.Visibility = string.IsNullOrEmpty(UiListaLineasDePicking.EditValue?.ToString())
                ? LayoutVisibility.Never
                : LayoutVisibility.Always;
        }

        private void UiListaUsaLineaDePicking_EditValueChanged(object sender, EventArgs e)
        {
            FiltroDeUsaLineaDePicking = Convert.ToInt32(UiListaUsaLineaDePicking.EditValue);
        }

        private void UiSwitchEntregaInmediata_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            try
            {
                CambiarVisualizacionEntregaNoInmediata();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void CambiarVisualizacionEntregaNoInmediata()
        {
            if (UiSwitchEntregaInmediata.Checked)
            {
                UiSwiftConsolidado.Visibility = BarItemVisibility.Always;
                UiEspacioUbicacion.Visibility = LayoutVisibility.Always;
                UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Always;
                if (UsaNext)
                {
                    UiPaginaVehiculos.PageVisible = true;
                }

            }
            else
            {
                UiSwiftConsolidado.Visibility = BarItemVisibility.Never;
                UiEspacioUbicacion.Visibility = LayoutVisibility.Never;
                UiSeparadorUbicacionSalida.Visibility = LayoutVisibility.Never;
                if (UsaNext)
                {
                    UiPaginaVehiculos.PageVisible = false;
                    UiNavegacionPaginasPricipal.SelectedPage = UiPaginaFiltro;
                }
            }
        }

        private void UiComboTipoInventario_SelectedValueChanged(object sender, EventArgs e)
        {
            TipoInventario = UiComboTipoInventario.EditValue.ToString() != string.Empty ?
                EnumsOperations.GetEnumValueFromStringValue<TipoDeInventario>(UiComboTipoInventario.EditValue.ToString())
                : TipoDeInventario.General;
            CambiarVisibilidadDeEntregaInmediata(sender);
        }

        public void CambiarVisibilidadDeEntregaInmediata(object sender)
        {
            var permisoTonoYCalibre =
                   Permisos?.FirstOrDefault(
                       p => p.PARAM_NAME == Enums.GetStringValue(NombreDeClasificaciones.ManejaTonoYCalibre));

            switch (TipoInventario)
            {
                case TipoDeInventario.General:
                    UiSwitchEntregaInmediata.Checked = true;
                    UiSwitchEntregaInmediata.Visibility = BarItemVisibility.Always;
                    UiSwiftConsolidado.Visibility = BarItemVisibility.Always;

                    if (permisoTonoYCalibre != null && permisoTonoYCalibre.NUMERIC_VALUE == (int)SiNo.Si)
                    {
                        UiSwiftTonosYCalibres.Visibility = BarItemVisibility.Always;
                        UiPaginaTonoCalibre.PageVisible = UiSwiftTonosYCalibres.Checked;
                    }
                    break;

                case TipoDeInventario.Preparado:
                    UiSwitchEntregaInmediata.Visibility = BarItemVisibility.Never;
                    UiSwitchEntregaInmediata.Checked = true;

                    if (permisoTonoYCalibre != null && permisoTonoYCalibre.NUMERIC_VALUE == (int)SiNo.Si)
                    {
                        UiSwiftTonosYCalibres.Checked = false;
                        UiSwiftTonosYCalibres.Visibility = BarItemVisibility.Never;
                        UiPaginaTonoCalibre.PageVisible = UiSwiftTonosYCalibres.Checked;
                    }
                    UiSwiftConsolidado.Visibility = BarItemVisibility.Never;
                    UiSwiftConsolidado.Checked = false;

                    RefrescarListadoDeOrdenesDeVentaPreparadasPorFecha(sender);

                    break;

                default:
                    UiSwitchEntregaInmediata.Checked = true;
                    UiSwitchEntregaInmediata.Visibility = BarItemVisibility.Always;
                    UiSwiftConsolidado.Visibility = BarItemVisibility.Always;

                    if (permisoTonoYCalibre != null && permisoTonoYCalibre.NUMERIC_VALUE == (int)SiNo.Si)
                    {
                        UiSwiftTonosYCalibres.Checked = false;
                        UiSwiftTonosYCalibres.Visibility = BarItemVisibility.Never;
                        UiPaginaTonoCalibre.PageVisible = UiSwiftTonosYCalibres.Checked;
                    }
                    break;
            }
        }

        public void RefrescarListadoDeOrdenesDeVentaPreparadasPorFecha(object sender)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                ColapsarMaestroDetalleVehiculos();
                if (!ValidarBodega()) return;
                var codigosFuenteRutas = string.Empty;
                var codigosRutas = string.Empty;
                var codigosClientesErpCanalModerno = string.Empty;
                UiContenedorVistaOrdenDetalle.DataSource = new List<OrdenDeVentaDetalle>();

                if (TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaSonda)
                {
                    codigosFuenteRutas = string.Join("|",
                        Rutas.Where(ruta => ruta.IS_SELECTED)
                            .Select(ruta => ruta.EXTERNAL_SOURCE_ID.ToString())
                    );

                    codigosRutas = string.Join("|",
                        Rutas.Where(ruta => ruta.IS_SELECTED).Select(ruta => ruta.CODE_ROUTE));
                }

                if (TipoFuente == TipoFuenteDemandaDespacho.OrdenVentaErp)
                {
                    if (!ValidarClienteErpCanalModerno()) return;

                    codigosClientesErpCanalModerno = string.Join("|",
                        ClientesErpCanalModerno.Where(cliente => cliente.IS_SELECTED)
                            .Select(cliente => cliente.MASTER_ID));
                }

                UsuarioDeseaObtenerDemandasPreparadasPorFecha?.Invoke(sender, new OrdenDeVentaArgumento
                {
                    FechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue),
                    FechaFin =
                               Convert.ToDateTime(UiFechaFin.EditValue).AddHours(23).AddMinutes(59).AddSeconds(59),
                    CodigosFuenteRuta = codigosFuenteRutas,
                    CodigosRuta = codigosRutas,
                    CodigoBodega = BodegaSeleccionda,
                    CodigosClientesErpCanalModerno = codigosClientesErpCanalModerno,
                    CodigosPoligonos = string.Join("|", PoligonosSeleccionados.Select(ps => ps.POLYGON_ID.ToString()).ToArray()),
                    FuenteExternaPoligonos = string.Join("|", PoligonosSeleccionados.Select(ps => ps.EXTERNAL_SOURCE_ID.ToString()).ToArray())
                           ,
                    UsaLineaDePicking = Convert.ToInt32(UiListaUsaLineaDePicking.EditValue)
                });

                LLenarContenedorOrdenDeVentaEncabezado();
                UsuarioDeseaVerDetalle();

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void UiBotonEliminarSeleccionados_ItemClick(object sender, ItemClickEventArgs e)
        {
            ColapsarMaestroDetalleVehiculos();
            EliminarRegistros(false);
            UsuarioDeseaVerDetalle();
        }

        private void UiSpinNumeroDocumentoControl_Properties_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarOrdenesDeVenta(null);
            }
        }

        private void UiBotonRefrescarOlas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
        }

        private void UiBotonContraerOlas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaOlas.CollapseAllGroups();
        }

        private void UiBotonExpandirOlas_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaOlas.ExpandAllGroups();
        }

        private void UiBotonExcelOlas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (UiGridControlOlas.DataSource == null) return;
            if (UiVistaOlas.RowCount <= 0) return;

            var dialog = new SaveFileDialog
            {
                DefaultExt = "xlsx",
                Filter = @"Archivos de excel (*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            UiGridControlOlas.ExportToXls(dialog.FileName);
        }

        private void UIListaProyecto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var proyecto = UIListaProyecto.GetSelectedDataRow();
                if (proyecto != null)
                {
                    ProyectoSeleccionado = (Proyecto)proyecto;
                    CargarOrdenesDeVenta(sender);
                    UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
                }
                else
                {
                    ProyectoSeleccionado = new Proyecto();
                    CargarOrdenesDeVenta(sender);
                    UsuarioDeseaObtenerOlasDePickigGeneradas?.Invoke(null, new OlaDePickingDeDemandaDespachoArgumento { Fecha = DateTime.Today });
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }

        private void UiBtnImportarExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UiVistaOrdenEncabezado.ShowPrintPreview();
        }
    }
}