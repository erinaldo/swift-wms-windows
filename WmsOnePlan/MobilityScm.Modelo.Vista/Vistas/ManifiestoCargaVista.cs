using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public partial class ManifiestoCargaVista : VistaBase, IManifiestoCargaVista
    {
        #region Eventos

        public event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarPickingEncabezado;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarPickingDetalle;
        public event EventHandler UsuarioDeseaConsultarBodegas;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarRutas;
        public event EventHandler UsuarioDeseaConsultarPilotos;
        public event EventHandler UsuarioDeseaConsultarVehiculos;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaGrabarManifiesto;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaConsultarManifiesto;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerManifiestoDeCarga;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerCajasEnManifiestoDeCarga;
        public event EventHandler<VehiculoArgumento> UsuarioDeseaObtenerVehiculosPorPeso;
        public event EventHandler<PilotoArgumento> UsuarioDeseaObtenerPilotoPorVehiculo;
        public event EventHandler<ManifiestoArgumento> UsuarioDeseaObtenerReporteDeCajasPorCliente;
        #endregion

        #region Propiedades
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IList<Bodega> Bodegas
        {
            get { return (IList<Bodega>)UiListaBodega.Properties.DataSource; }
            set { UiListaBodega.Properties.DataSource = value; }
        }

        public IList<Vehiculo> Vehiculos
        {
            get; set;
        }

        public void EstablecerVehiculosEnBaseAPesoDePickings(decimal peso)
        {
            var listaVehiculosFiltrados = Vehiculos.Where(vehiculo => vehiculo.WEIGHT >= peso).OrderBy(vehiculo => vehiculo.WEIGHT).ToList();
            UiListaVehiculo.Properties.DataSource = listaVehiculosFiltrados;

        }

        public IList<Entidades.Configuracion> Configuracion { get; set; }
        public IList<PickingDetalle> PickingDetalle
        {
            get { return (IList<PickingDetalle>)UiContenedorVistaPicking.DataSource; }
            set { UiContenedorVistaPicking.DataSource = value; }
        }
        public IList<Picking> PickingEncabezado
        {
            get { return (IList<Picking>)UiListaPickingHeader.Properties.DataSource; }
            set { UiListaPickingHeader.Properties.DataSource = value; }
        }

        public IList<Ruta> Rutas
        {
            get { return (IList<Ruta>)UiListaRuta.Properties.DataSource; }
            set { UiListaRuta.Properties.DataSource = value; }
        }
        private bool UsuarioSeleccionoListaDeDetalleCompleta { get; set; }
        private bool UsuarioSeleccionoListaPickingEncabezadoCompleta { get; set; }
        private bool UsuarioSeleccionoListaBodegaCompleta { get; set; }
        private bool UsuarioSeleccionoListaRutaCompleta { get; set; }
        public string Usuario { get; set; }
        public IList<ManifiestoCarga> ManifiestoCarga { get; set; }
        public IList<Cliente> ClientesManifiesto { get; set; }
        public IList<Caja> Cajas { get; set; }
        public string LastManifestHeaderId
        {
            get
            {
                return UiTextoManifiestoDeCargaId.EditValue?.ToString() ?? string.Empty;
            }
            set { UiTextoManifiestoDeCargaId.EditValue = value; }
        }

        public Point PuntoDeEtiquetaDeRuta { get; set; }
        public Point PuntoDeEtiquetaDePicking { get; set; }
        public Point PuntoDeListaDeRutas { get; set; }
        public Point PuntoDeListaDePickings { get; set; }

        public ManifiestoEncabezado ManifiestoDeCargaEncabezado { get; set; }

        public bool EstaBuscando { get; set; }

        public Vehiculo Vehiculo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Piloto Piloto
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<Parametro> Parametros { get; set; }
        public bool EstaModificando { get; set; }

        public IList<CajaPorCliente> CajasPorClientes { get; set; }

        public IEnumerable<int?> DetallesEliminados { get; set; }

        #endregion

        #region Contructor y Eventos de Carga

        public ManifiestoCargaVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IManifiestoCargaServicio, ManifiestoCargaServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IPickingServicio, PickingServicio>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IRutasSwiftExpressServicio, RutasSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<ILineaDePickingServicio, LineaDePickingServicio>();
            Mvx.Ioc.RegisterType<IConsultaDeManifiestoServicio, ConsultaDeManifiestoServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();

            Mvx.Ioc.RegisterSingleton<IManifiestoCargaVista, ManifiestoCargaVista>(this);
            Mvx.Ioc.RegisterType<IManifiestoCargaControlador, ManifiestoCargaControlador>();
            Mvx.Ioc.Resolve<IManifiestoCargaControlador>();
        }

        public ManifiestoCargaVista(string manifiesto = "")
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();

            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IManifiestoCargaServicio, ManifiestoCargaServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IPickingServicio, PickingServicio>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<IRutasSwiftExpressServicio, RutasSwiftExpressServicio>();
            Mvx.Ioc.RegisterType<ILineaDePickingServicio, LineaDePickingServicio>();
            Mvx.Ioc.RegisterType<IConsultaDeManifiestoServicio, ConsultaDeManifiestoServicio>();
            Mvx.Ioc.RegisterType<IParametroServicio, ParametroServicio>();

            Mvx.Ioc.RegisterSingleton<IManifiestoCargaVista, ManifiestoCargaVista>(this);
            Mvx.Ioc.RegisterType<IManifiestoCargaControlador, ManifiestoCargaControlador>();
            Mvx.Ioc.Resolve<IManifiestoCargaControlador>();

            LastManifestHeaderId = manifiesto;
        }
        private void ManifiestoCargaVista_Load(object sender, EventArgs e)
        {
           
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            UiFechaInicial.EditValue = DateTime.Now.AddDays(-7);
            UiFechaFinal.EditValue = DateTime.Now;
            UsuarioSeleccionoListaPickingEncabezadoCompleta = false;
            UsuarioSeleccionoListaBodegaCompleta = false;
            UsuarioSeleccionoListaRutaCompleta = false;
            UiBarButtonReporteDeCajas.Visibility = BarItemVisibility.Never;

            UiListaBodega.Properties.PopupFormWidth = UiListaBodega.Width;
            UiListaPickingHeader.Properties.PopupFormWidth = UiListaPickingHeader.Width;
            UiListaRuta.Properties.PopupFormWidth = UiListaRuta.Width;

            CargarOGuardarDisenios(UiContenedorVistaPicking, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);

            UiListaTipo.Properties.DataSource = Enum.GetValues(typeof(Tipos.TipoDeManifiestoDeCarga));
            UiListaTipo.EditValue = Tipos.TipoDeManifiestoDeCarga.Venta;

            var tipoManifiestoDeCarga = ObtenerConfiguracion(Enums.GetStringValue(NombreParametroGeneral.TipoManifiestoDeCarga));
            if (tipoManifiestoDeCarga.TEXT_VALUE == Enums.GetStringValue(TipoDeGeneracionDeManifiestoDeCarga.PorOla))
            {
                UiBarButtonReporteDeCajas.Visibility = BarItemVisibility.Always;
            }

            LlenarListaPickingEncabezado(true);
            UiListaPickingHeader.ShowPopup();
            ManifiestoDeCargaEncabezado = new ManifiestoEncabezado();
            MostrarColumnasTipoDespacho();

            if (!string.IsNullOrEmpty(LastManifestHeaderId))
            {
                LimpiarControles();
                BuscarManifiestoDeCarga(sender);
            }
        }

        #endregion

        #region Eventos de controles
        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "REFRESCAR-BODEGA":
                    UsuarioDeseaConsultarBodegas?.Invoke(sender, e);
                    break;
                case "REFRESCAR-RUTA":

                    UsuarioDeseaConsultarRutas?.Invoke(sender, new ManifiestoArgumento
                    {
                        Bodegas = PrepararBodegas()
                    });
                    break;
                case "REFRESCAR-PICKING":
                    LlenarListaPickingEncabezado();

                    break;
                case "AGREGAR-PICKING":

                    if (ValidarPickings())
                        UiBotonManifiestoConsolidado.Enabled = false;
                    UiManifiestoDetallado.Enabled = false;
                    UiBarButtonReporteDeCajas.Enabled = false;
                    UiBotonReporteCajasPorCliente.Enabled = false;
                    LlenarDetallePicking();
                    break;
                case "REFRESCAR-VEHICULO":
                    UsuarioDeseaObtenerVehiculosPorPeso?.Invoke(sender, new VehiculoArgumento { Vehiculo = new Vehiculo() });
                    EstablecerVehiculosEnBaseAPesoDePickings(ObtenerPesoTotalDelDetalleDePicking());
                    break;
            }
        }

        private void UiBotonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ManifiestoDeCargaEncabezado = new ManifiestoEncabezado();
            DetallesEliminados = new List<int?>();
            LimpiarControles();
            DeshabilitarCampos(false);
        }

        private void UiListaRuta_EditValueChanged(object sender, EventArgs e)
        {
            LlenarListaPickingEncabezado();
        }

        private void UiListaBodega_EditValueChanged(object sender, EventArgs e)
        {
            if (Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue) == Enums.GetStringValue(TipoDeManifiestoDeCarga.Venta))
            {
                UsuarioDeseaConsultarRutas?.Invoke(sender, new ManifiestoArgumento
                {
                    Bodegas = PrepararBodegas()
                });
            }

            if (UiListaBodega.EditValue == null) return;

            LlenarListaPickingEncabezado();
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!ValidarCamposObligatorios() || UiVistaPickingDetalle.RowCount <= 0 || !ValidarPesoYVolumen()) return;
            int? transferRequestId = PickingDetalle[0].TRANSFER_REQUEST_ID;

            IList<ManifiestoDetalle> manifiestoDetalle = PickingDetalle.Select(x => x.PICKING_DEMAND_HEADER_ID).Distinct().Select(pickingDetalle => new ManifiestoDetalle { PICKING_DEMAND_HEADER_ID = pickingDetalle }).ToList();

            var manifiestoArgumento = new ManifiestoArgumento
            {
                ManifiestoEncabezado = new ManifiestoEncabezado
                {
                    VEHICLE = Convert.ToInt32(UiListaVehiculo.EditValue.ToString())
                    ,
                    MANIFEST_TYPE = Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue)
                    ,
                    TRANSFER_REQUEST_ID = transferRequestId
                    ,
                    MANIFEST_HEADER_ID = ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID
                },
                ManifiestoDetalle = manifiestoDetalle,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario(),
                DemandasDespacho = string.Join("|", DetallesEliminados)
            };

            UsuarioDeseaGrabarManifiesto?.Invoke(sender, manifiestoArgumento);
        }

        private void UiBotonExpandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPickingDetalle.ExpandAllGroups();
        }

        private void UiBotonContraer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UiVistaPickingDetalle.CollapseAllGroups();
        }

        private void UiBotonManifiestoConsolidado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaConsultarManifiesto?.Invoke(sender, new ManifiestoArgumento
                {
                    ManifiestoEncabezado = new ManifiestoEncabezado { MANIFEST_HEADER_ID = Convert.ToInt32(ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID) }
                });

                var configuracionMontos = ObtenerConfiguracion(Enums.GetStringValue(NombreParametroGeneral.MostrarMontos));
                bool mostrarMontos = configuracionMontos != null && configuracionMontos.TEXT_VALUE.ToUpper() == SiNo.Si.ToString().ToUpper();

                var reporte = new Reportes.ManifiestoDeCargaConsolidado(mostrarMontos)
                {
                    DataSource = ListToDataTableClass.ListToDataTable(ManifiestoCarga.ToList()),
                    DataMember = "MANIFIEST_REPORT",
                    RequestParameters = false
                };

                var rutas = string.Join(",", ManifiestoCarga.Select(manifiesto => manifiesto.CODE_ROUTE).Distinct());

                reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
                reporte.Parameters["ParametroManifiestoCargaID"].Value = $"{ManifiestoDeCargaEncabezado.DOCUMENT_PREFIX}-{ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID}";
                reporte.Parameters["ParametroCentroDistribucion"].Value = ManifiestoCarga[0].DISTRIBUTION_CENTER ?? "N/A";
                reporte.Parameters["ParametroRuta"].Value = rutas;
                reporte.Parameters["ParametroPiloto"].Value = (ManifiestoCarga[0].DRIVER?.ToString() ?? "0" ) + ( " - " + ManifiestoCarga[0].PILOT_NAME);
                reporte.Parameters["ParametroVehiculo"].Value = ManifiestoCarga[0].VEHICLE ?? "N/A";
                reporte.Parameters["SolicitudDeTraslado"].Value = ManifiestoCarga[0].TRANSFER_REQUEST_ID?.ToString() ?? "N/A";
                reporte.Parameters["ParametroBodegaDestino"].Value = ManifiestoCarga[0].WAREHOUSE_TO?.ToString();
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message + ex.StackTrace);
            }
        }

        private void UiManifiestoDetallado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaConsultarManifiesto?.Invoke(sender, new ManifiestoArgumento
                {
                    ManifiestoEncabezado = new ManifiestoEncabezado { MANIFEST_HEADER_ID = Convert.ToInt32(ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID) }
                });

                foreach (var mc in ManifiestoCarga)
                {
                    var docNum = mc.ERP_REFERENCE_DOC_NUM;
                    if (docNum == null)
                    {
                        mc.Olas = mc.WAVE_PICKING_ID.ToString();
                    }
                    else
                    {
                        var listaOlas = ManifiestoCarga
                             .OrderBy(m => m.WAVE_PICKING_ID)
                             .Where(m => m.ERP_REFERENCE_DOC_NUM == docNum)
                             .Select(m => m.WAVE_PICKING_ID);

                        mc.Olas = string.Join(", ", listaOlas.Distinct());
                    }
                }

                var manifiestosReporte = ManifiestoCarga
                    .GroupBy(m => new { m.ERP_REFERENCE_DOC_NUM, m.MATERIAL_ID, m.MATERIAL_NAME, m.Olas, m.STATUS_CODE })
                    .Select(mc => new ManifiestoCarga
                    {
                        MATERIAL_ID = mc.Key.MATERIAL_ID,
                        MATERIAL_NAME = mc.Key.MATERIAL_NAME,
                        QTY = mc.Sum(m => m.QTY),
                        CLIENT_CODE = mc.First().CLIENT_CODE,
                        CLIENT_NAME = mc.First().CLIENT_NAME,
                        DOCUMENT_DATE = mc.First().DOCUMENT_DATE,
                        DISTRIBUTION_CENTER = mc.First().DISTRIBUTION_CENTER,
                        DRIVER = mc.First().DRIVER,
                        VEHICLE = mc.First().VEHICLE,
                        HEADER_STATUS = mc.First().HEADER_STATUS,
                        MANIFEST_HEADER_ID = mc.First().MANIFEST_HEADER_ID,
                        CODE_ROUTE = mc.First().CODE_ROUTE,
                        TRANSFER_REQUEST_ID = mc.First().TRANSFER_REQUEST_ID,
                        WEIGHT = mc.Sum(m => m.WEIGHT),
                        ADDRESS_CUSTOMER = mc.First().ADDRESS_CUSTOMER,
                        ERP_REFERENCE_DOC_NUM = mc.Key.ERP_REFERENCE_DOC_NUM,
                        SHOWN_DOCUMENT = mc.First().SHOWN_DOCUMENT,
                        HEADER_DISCOUNT = mc.First().HEADER_DISCOUNT,
                        PRICE = mc.First().PRICE,
                        LINE_DISCOUNT = mc.First().LINE_DISCOUNT,
                        LINE_DISCOUNT_TYPE = mc.First().LINE_DISCOUNT_TYPE,
                        DOCUMENT_TOTAL = mc.Sum(m => m.FINAL_PRICE),
                        Olas = mc.Key.Olas,
                        STATUS_CODE = mc.First().STATUS_CODE
                    });
                var configuracionMontos = ObtenerConfiguracion(Enums.GetStringValue(NombreParametroGeneral.MostrarMontos));
                bool mostrarMontos = configuracionMontos != null && configuracionMontos.TEXT_VALUE.ToUpper() == SiNo.Si.ToString().ToUpper();

                var reporte = new Reportes.ManifiestoDeCargaDetallado(mostrarMontos)
                {
                    DataSource = manifiestosReporte.ToList(),
                    RequestParameters = false
                };
                var rutas = string.Join(",", ManifiestoCarga.Select(manifiesto => manifiesto.CODE_ROUTE).Distinct());

                reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
                reporte.Parameters["ParametroManifiestoCargaID"].Value = $"{ManifiestoDeCargaEncabezado.DOCUMENT_PREFIX}-{ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID}";
                reporte.Parameters["ParametroCentroDistribucion"].Value = ManifiestoCarga[0].DISTRIBUTION_CENTER ?? "N/A";
                reporte.Parameters["ParametroRuta"].Value = rutas;
                reporte.Parameters["ParametroPiloto"].Value = (ManifiestoCarga[0].DRIVER?.ToString() ?? "0") + (" - " + ManifiestoCarga[0].PILOT_NAME);
                reporte.Parameters["ParametroVehiculo"].Value = ManifiestoCarga[0].VEHICLE ?? "N/A";
                reporte.Parameters["SolicitudDeTraslado"].Value = ManifiestoCarga[0].TRANSFER_REQUEST_ID?.ToString() ?? "N/A";
                reporte.Parameters["ParametroBodegaDestino"].Value = ManifiestoCarga[0].WAREHOUSE_TO?.ToString();
                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message + ex.StackTrace);
            }
        }

        private void ManifiestoCargaVista_FormClosing(object sender, FormClosingEventArgs e)
        {
            CargarOGuardarDisenios(UiContenedorVistaPicking, true, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
        }

        private void UiListaTipo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue) == Enums.GetStringValue(TipoDeManifiestoDeCarga.Venta))
                {
                    UiLabelRuta.Visible = true;
                    UiListaRuta.Visible = true;

                    UiEtiquetaDePicking.Location = PuntoDeEtiquetaDePicking;
                    UiListaPickingHeader.Location = PuntoDeListaDePickings;

                    UiListaPickingHeader.Properties.View.OptionsSelection.MultiSelect = true;
                    UiListaPickingHeader.Properties.View.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
                }
                else
                {
                    UiLabelRuta.Visible = false;
                    UiListaRuta.Visible = false;

                    UiEtiquetaDePicking.Location = PuntoDeEtiquetaDeRuta;
                    UiListaPickingHeader.Location = PuntoDeListaDeRutas;
                    UiListaPickingHeader.Properties.View.OptionsSelection.MultiSelect = false;
                    UiListaPickingHeader.Properties.View.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
                }
                if (!EstaBuscando)
                {
                    LimpiarSeleccion();
                    LlenarListaPickingEncabezado(true);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message + ex.StackTrace);
            }
        }


        private void UiBarButtonReporteDeCajas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerCajasEnManifiestoDeCarga?.Invoke(sender, new ManifiestoArgumento()
                {
                    IdManifiestoDeCarga = ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID.ToString()
                });

                UsuarioDeseaConsultarManifiesto?.Invoke(sender, new ManifiestoArgumento
                {
                    ManifiestoEncabezado = new ManifiestoEncabezado { MANIFEST_HEADER_ID = Convert.ToInt32(ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID) }
                });

                if (Cajas == null || Cajas.Count == 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("Las olas de picking en el manifiesto de carga no manejan línea de picking.");
                    return;
                }

                var reporte = new Reportes.ConsultaLineaPicking(true)
                {
                    DataSource = ListToDataTableClass.ListToDataTable(Cajas.ToList()),
                    RequestParameters = false
                };
                var rutas = string.Join(",", ManifiestoCarga.Select(manifiesto => manifiesto.CODE_ROUTE).Distinct());

                reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
                reporte.Parameters["ParametroManifiestoCargaID"].Value = $"{ManifiestoDeCargaEncabezado.DOCUMENT_PREFIX}-{ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID}";
                reporte.Parameters["ParametroCentroDistribucion"].Value = ManifiestoCarga[0].DISTRIBUTION_CENTER ?? "N/A";
                reporte.Parameters["ParametroRuta"].Value = rutas;
                reporte.Parameters["ParametroPiloto"].Value = ManifiestoCarga[0].DRIVER ?? 0;
                reporte.Parameters["ParametroVehiculo"].Value = ManifiestoCarga[0].VEHICLE ?? "N/A";
                reporte.Parameters["SolicitudDeTraslado"].Value = (ManifiestoCarga[0].TRANSFER_REQUEST_ID == null ? "N/A" : ManifiestoCarga[0].TRANSFER_REQUEST_ID.ToString());

                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message + ex.StackTrace);
            }
        }

        private void UiTextoManifiestoId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LastManifestHeaderId = (sender as TextEdit).Text;
                LimpiarControles();
                BuscarManifiestoDeCarga(sender);
            }
        }

        private void UiBotonReporteCajasPorCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                UsuarioDeseaObtenerReporteDeCajasPorCliente?.Invoke(sender, new ManifiestoArgumento()
                {
                    IdManifiestoDeCarga = ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID.ToString()
                });

                if (CajasPorClientes == null || CajasPorClientes.Count == 0)
                {
                    InteraccionConUsuarioServicio.Mensaje("Las olas de picking en el manifiesto de carga no manejan línea de picking.");
                    return;
                }

                var reporte = new Reportes.ReporteCajasPorVendedor()
                {
                    DataSource = ListToDataTableClass.ListToDataTable(CajasPorClientes.ToList()),
                    RequestParameters = false
                };

                reporte.Parameters["ParametroUsuario"].Value = InteraccionConUsuarioServicio.ObtenerUsuario();
                reporte.Parameters["ParametroManifiestoCargaID"].Value = $"{ManifiestoDeCargaEncabezado.DOCUMENT_PREFIX}-{ManifiestoDeCargaEncabezado.MANIFEST_HEADER_ID}";
                reporte.Parameters["ParametroCentroDistribucion"].Value = CajasPorClientes.FirstOrDefault().DISTRIBUTION_CENTER ?? "N/A";
                reporte.Parameters["ParametroPiloto"].Value = CajasPorClientes.FirstOrDefault().PILOT_FULL_NAME ?? "N/A";
                reporte.Parameters["ParametroVehiculo"].Value = CajasPorClientes.FirstOrDefault().PLATE_NUMBER ?? "N/A";

                reporte.Parameters["ImagenLogo"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region Métodos

        private void MostrarColumnasTipoDespacho()
        {
            try
            {
                var parametroTipoDespacho = Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.ObtieneTipoDeDemanda) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.DemandaDePicking));
                var mostrarTipoDespacho = (parametroTipoDespacho != null && int.Parse(parametroTipoDespacho.VALUE) == (int)SiNo.Si);

                UiColListaCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColListaCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColListaNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColListaNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;

                UiColVistaCodigoTipoDespacho.Visible = mostrarTipoDespacho;
                UiColVistaCodigoTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;
                UiColVistaNombreTipoDespacho.Visible = mostrarTipoDespacho;
                UiColVistaNombreTipoDespacho.OptionsColumn.ShowInCustomizationForm = mostrarTipoDespacho;

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message + ex.StackTrace);
            }
        }

        private bool ValidarPickings()
        {
            var resultado = true;

            UiError.SetError(UiListaPickingHeader, "", ErrorType.None);

            if (UiVistaPickingHeader.SelectedRowsCount == 0)
            {
                UiError.SetError(UiListaPickingHeader, "Seleccione al menos un picking");
                resultado = false;
            }

            if (EstaModificando && ManifiestoDeCargaEncabezado != null
                && ManifiestoDeCargaEncabezado.STATUS == Enums.GetStringValue(EstadosManifiesto.Certificado))
            {
                UiError.SetError(UiListaPickingHeader, "No puede agregar más pickings a este manifiesto de carga debido a que ya se encuentra como certificado.");
                resultado = false;
            }
            return resultado;
        }

        private bool ValidarCamposObligatorios()
        {
            var resultado = true;
            UiError.SetError(UiListaVehiculo, "", ErrorType.None);

            if (UiListaVehiculo.EditValue == null)
            {
                UiError.SetError(UiListaVehiculo, "Campo Obligatorio");
                resultado = false;
            }

            return resultado;
        }

        private bool ValidarPesoYVolumen()
        {
            var vehiculo = (Vehiculo)UiListaVehiculo.GetSelectedDataRow();
            var pesoDePickings = ObtenerPesoDePickings();
            var volumenDePickings = ObtenerVolumenDePickings();

            if (pesoDePickings > vehiculo.WEIGHT * (vehiculo.FILL_RATE / 100))
            {
                InteraccionConUsuarioServicio.Mensaje("El peso del manifiesto de carga es mayor a la capacidad del vehículo");
                return false;
            }

            if (volumenDePickings > vehiculo.VOLUME_FACTOR * (vehiculo.FILL_RATE / 100))
            {
                InteraccionConUsuarioServicio.Mensaje("El volumen del manifiesto de carga es mayor a la capacidad del vehículo");
                return false;
            }
            return true;
        }

        private void LlenarDetallePicking(bool todosLosDetalles = false)
        {
            var cadena = new StringBuilder();
            foreach (var documento in PickingEncabezado.Where(doc => doc.IS_SELECTED || todosLosDetalles))
            {
                if (cadena.Length > 0) { cadena.Append("|"); }

                var tipoManifiestoDeCarga = ObtenerConfiguracion(Enums.GetStringValue(NombreParametroGeneral.TipoManifiestoDeCarga));

                cadena.Append(
                    tipoManifiestoDeCarga != null && tipoManifiestoDeCarga.TEXT_VALUE == Enums.GetStringValue(TipoDeGeneracionDeManifiestoDeCarga.PorPedido)
                        ? documento.PICKING_DEMAND_HEADER_ID
                        : documento.WAVE_PICKING_ID
                        );
            }

            if (string.IsNullOrEmpty(cadena.ToString())) return;
            UsuarioDeseaConsultarPickingDetalle?.Invoke(null, new ManifiestoArgumento
            {
                EncabezadosSeleccionados = cadena.ToString()
            });

        }

        private string PrepararRutas(bool todasLasRutas = false)
        {
            if (Rutas == null) return "";
            var rutas = new StringBuilder();
            if (Rutas.Count == 0 || (Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue) == Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia)))
            {
                rutas.Append('|');
            }
            else
            {
                foreach (var documento in Rutas.Where(doc => doc.IS_SELECTED || todasLasRutas))
                {
                    if (rutas.Length > 0)
                    {
                        rutas.Append("|");
                    }
                    rutas.Append(documento.CODE_ROUTE);

                }
                if (rutas.Length == 0)
                {
                    rutas.Append("|");
                }
            }
            return rutas.ToString();
        }

        private string PrepararBodegas(bool todasLasBodegas = false)
        {
            if (Bodegas == null) return "";
            var bodegas = new StringBuilder();
            foreach (var documento in Bodegas.Where(doc => doc.IS_SELECTED || todasLasBodegas))
            {
                if (bodegas.Length > 0) { bodegas.Append("|"); }
                bodegas.Append(documento.WAREHOUSE_ID);
            }
            return bodegas.ToString();
        }

        private bool ValidarFechasYBodegas()
        {
            var resultado = true;

            UiError.SetError(UiListaBodega, "", ErrorType.None);

            if (UiFechaInicial.EditValue == null || UiFechaFinal.EditValue == null)
            {
                MessageBox.Show(@"Las fechas no pueden ir vacías.", @"Error");
                return false;
            }

            if (Convert.ToDateTime(UiFechaInicial.EditValue.ToString()) > Convert.ToDateTime(UiFechaFinal.EditValue))
            {
                MessageBox.Show(@"Fecha Inicial debe de ser menor a Fecha Final.", @"Error");
                return false;
            }

            return resultado;
        }

        private void LlenarListaPickingEncabezado(bool obtenerTodos = false)
        {
            if (obtenerTodos || ValidarFechasYBodegas())
            {
                var fechaInicio = Convert.ToDateTime(UiFechaInicial.EditValue);
                var fechaFinal = Convert.ToDateTime(UiFechaFinal.EditValue);

                UsuarioDeseaConsultarPickingEncabezado?.Invoke(null, new ManifiestoArgumento
                {
                    FechaFinal = fechaFinal.Date + (new TimeSpan(23, 59, 59))
                    ,
                    FechaInicial = fechaInicio.Date
                    ,
                    Bodegas = PrepararBodegas(obtenerTodos)
                    ,
                    Rutas = PrepararRutas(obtenerTodos)
                    ,
                    Tipo = Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue)
                });
            }
        }
        public void LimpiarControles()
        {
            EstaModificando = false;
            UiListaPickingHeader.Properties.DataSource = null;
            UiContenedorVistaPicking.DataSource = null;

            UiListaVehiculo.EditValue = null;
            UiListaVehiculo.Text = null;

            LimpiarSeleccion();

            LlenarListaPickingEncabezado(true);
        }

        private void LimpiarSeleccion()
        {
            PickingEncabezado = null;
            UiListaPickingHeader.EditValue = null;
            UiListaPickingHeader.Properties.DataSource = null;


            PickingDetalle = null;
            UiContenedorVistaPicking.DataSource = null;
        }

        public void ObtenerPuntosDeControles()
        {
            PuntoDeEtiquetaDeRuta = UiLabelRuta.Location;
            PuntoDeListaDeRutas = UiListaRuta.Location;
            PuntoDeEtiquetaDePicking = UiEtiquetaDePicking.Location;
            PuntoDeListaDePickings = UiListaPickingHeader.Location;
        }

        public void TerminarProceso(object sender)
        {
            LimpiarControles();
            BuscarManifiestoDeCarga(sender);
        }

        private void BuscarManifiestoDeCarga(object sender)
        {
            if (string.IsNullOrEmpty(LastManifestHeaderId) || LastManifestHeaderId == "0") return;

            UsuarioDeseaObtenerManifiestoDeCarga?.Invoke(sender, new ManifiestoArgumento
            {
                IdManifiestoDeCarga = LastManifestHeaderId
            });
            if (ManifiestoDeCargaEncabezado == null)
            {
                InteraccionConUsuarioServicio.Mensaje("Manifiesto de carga no encontrado.");
                return;
            }
            EstaBuscando = true;
            UiListaTipo.EditValue = EnumsOperations.GetEnumValueFromStringValue<TipoDeManifiestoDeCarga>(ManifiestoDeCargaEncabezado.MANIFEST_TYPE);

            UiListaVehiculo.EditValue = ManifiestoDeCargaEncabezado.VEHICLE;

            PickingDetalle = new List<PickingDetalle>();

            var detallePicking = ManifiestoDeCargaEncabezado.Detalle.Select(manifiestoDetalle => new PickingDetalle
            {
                MATERIAL_ID = manifiestoDetalle.MATERIAL_ID,
                MATERIAL_NAME = manifiestoDetalle.MATERIAL_NAME,
                QTY = manifiestoDetalle.QTY,
                CLIENT_CODE = manifiestoDetalle.CLIENT_CODE,
                CLIENT_NAME = manifiestoDetalle.CLIENT_NAME,
                WAVE_PICKING_ID = manifiestoDetalle.WAVE_PICKING_ID,
                WEIGHT = manifiestoDetalle.WEIGHT,
                ADDRESS_CUSTOMER = manifiestoDetalle.ADDRESS_CUSTOMER,
                PICKING_DEMAND_HEADER_ID = manifiestoDetalle.PICKING_DEMAND_HEADER_ID,
                COMPLETED_DATE = manifiestoDetalle.DOCUMENT_DATE,
                EsNuevo = false,
                TOTAL_VOLUME = manifiestoDetalle.TOTAL_VOLUME,
                TYPE_DEMAND_CODE = manifiestoDetalle.TYPE_DEMAND_CODE,
                TYPE_DEMAND_NAME = manifiestoDetalle.TYPE_DEMAND_NAME,
                PRICE = manifiestoDetalle.PRICE,
                LINE_DISCOUNT = manifiestoDetalle.LINE_DISCOUNT,
                LINE_DISCOUNT_TYPE = manifiestoDetalle.LINE_DISCOUNT_TYPE,
                HEADER_DISCOUNT = manifiestoDetalle.HEADER_DISCOUNT,
                STATUS_CODE = manifiestoDetalle.STATUS_CODE
            }).ToList();

            PickingDetalle = detallePicking;

            DeshabilitarCampos(!EstaModificando);

            if (EstaModificando)
            {
                LlenarListaPickingEncabezado(true);
            }

            EstaBuscando = false;
        }

        private void DeshabilitarCampos(bool activar)
        {
            UiBotonManifiestoConsolidado.Enabled = (activar || EstaModificando);
            UiManifiestoDetallado.Enabled = (activar || EstaModificando);
            UiBarButtonReporteDeCajas.Enabled = (activar || EstaModificando);
            UiBotonReporteCajasPorCliente.Enabled = (activar || EstaModificando);
            UiBotonGrabar.Enabled = !activar;

            UiBtnEliminarDetallesDeManifiesto.Enabled =
                !EstaModificando && !activar
                || !activar && EstaModificando
                && ManifiestoDeCargaEncabezado.MANIFEST_TYPE != Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia);

            UiListaTipo.ReadOnly = (activar || EstaModificando);
            UiListaBodega.ReadOnly = (activar || (EstaModificando && ManifiestoDeCargaEncabezado.MANIFEST_TYPE == Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia)));
            UiListaRuta.ReadOnly = (activar || (EstaModificando && ManifiestoDeCargaEncabezado.MANIFEST_TYPE == Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia)));
            UiListaPickingHeader.ReadOnly = activar ||
                                            EstaModificando &&
                                            (ManifiestoDeCargaEncabezado.MANIFEST_TYPE == Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia) || ManifiestoDeCargaEncabezado.STATUS == Enums.GetStringValue(Estados.EstadosManifiesto.Certificado));
            UiListaVehiculo.ReadOnly = activar;

            colCOMPLETED_DATE.FieldName = activar ? Enums.GetStringValue(CampoFecha.FechaDocumento) : Enums.GetStringValue(CampoFecha.FechaCompletado);
        }

        private Entidades.Configuracion ObtenerConfiguracion(string nombreParametro)
        {
            return Configuracion.FirstOrDefault(c => c.PARAM_NAME == nombreParametro);
        }

        private void UiListaVehiculo_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            try
            {
                if (EstaBuscando)
                {
                    var vehiculo = (Vehiculo)ObtenerFilaSelecciondaDeLaVista(UiListaVistaVehiculos);
                    if (vehiculo != null)
                    {
                        e.DisplayText = (vehiculo.VEHICLE_CODE + ", " + vehiculo.BRAND + ", " + vehiculo.PLATE_NUMBER + ", " + vehiculo.PILOT_NAME);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message + ex.StackTrace);
            }
        }

        private void MarcarPickingDetalleSeleccionado()
        {
            try
            {
                for (var i = 0; i < UiVistaPickingDetalle.RowCount; i++)
                {
                    var documento = (PickingDetalle)UiVistaPickingDetalle.GetRow(i);
                    if (documento == null) continue;
                    if (documento.IS_SELECTED)
                    {
                        UiVistaPickingDetalle.SelectRow(i);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message + ex.StackTrace);
            }
        }

        private void UiVistaPickingDetalle_ColumnFilterChanged(object sender, EventArgs e)
        {
            MarcarPickingDetalleSeleccionado();
        }

        private void UiVistaPickingDetalle_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            MarcarPickingDetalleSeleccionado();
        }

        private void UiVistaPickingDetalle_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaDeDetalleCompleta = true;
            }
        }

        private void UiVistaPickingDetalle_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (PickingDetalle)UiVistaPickingDetalle.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaDeDetalleCompleta) return;
                for (var i = 0; i < UiVistaPickingDetalle.RowCount; i++)
                {
                    var documento = (PickingDetalle)UiVistaPickingDetalle.GetRow(i);
                    if (documento == null) continue;
                    documento.IS_SELECTED = (UiVistaPickingDetalle.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaDeDetalleCompleta = false;
            }
        }

        public decimal ObtenerPesoTotalDelDetalleDePicking()
        {
            return VerificarSiExisteDetalleDePickingParaProcesar() ? ObtenerPesoDePickings() : 0;
        }

        private bool VerificarSiExisteDetalleDePickingParaProcesar()
        {
            return PickingDetalle != null && PickingDetalle.Any();
        }

        private decimal ObtenerPesoDePickings()
        {
            var pesoTotal = PickingDetalle.Aggregate<PickingDetalle, decimal?>(0, (current, pickingDetalle) => current + pickingDetalle.WEIGHT);
            return pesoTotal ?? 0;
        }

        private decimal ObtenerVolumenDePickings()
        {
            var volumenTotal = PickingDetalle.Aggregate<PickingDetalle, decimal?>(0, (current, pickingDetalle) => current + pickingDetalle.TOTAL_VOLUME);
            return volumenTotal ?? 0;
        }

        private void UiBtnEliminarDetallesDeManifiesto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<PickingDetalle> listaDetallesSeleccionados;

            UiBotonManifiestoConsolidado.Enabled = false;
            UiManifiestoDetallado.Enabled = false;
            UiBarButtonReporteDeCajas.Enabled = false;
            UiBotonReporteCajasPorCliente.Enabled = false;

            if (EstaModificando && ManifiestoDeCargaEncabezado.STATUS == Enums.GetStringValue(EstadosManifiesto.Certificando))
            {
                listaDetallesSeleccionados =
                (from detalle in
                    ((IList<PickingDetalle>)UiVistaPickingDetalle.DataSource).Where(detalle => detalle.IS_SELECTED && detalle.EsNuevo)
                 select detalle).ToList();
            }
            else
            {
                listaDetallesSeleccionados =
                (from detalle in
                    ((IList<PickingDetalle>)UiVistaPickingDetalle.DataSource).Where(detalle => detalle.IS_SELECTED)
                 select detalle).ToList();
            }

            DetallesEliminados = listaDetallesSeleccionados.Select(d => d.PICKING_DEMAND_HEADER_ID).Distinct();

            var listaFinal = ((IList<PickingDetalle>)UiVistaPickingDetalle.DataSource).Where(
                detalle =>
                    listaDetallesSeleccionados.All(detalleEliminado => detalleEliminado.PICKING_DEMAND_HEADER_ID != detalle.PICKING_DEMAND_HEADER_ID)).ToList();

            PickingDetalle = listaFinal;
            EstablecerVehiculosEnBaseAPesoDePickings(ObtenerPesoTotalDelDetalleDePicking());
        }

        #endregion


        #region Metodos para manejo de Propiedades en Listas
        private void UiVistaPickingHeader_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Picking)UiVistaPickingHeader.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaPickingEncabezadoCompleta)
                {
                    for (var i = 0; i < UiVistaPickingHeader.RowCount; i++)
                    {
                        var documento = (Picking)UiVistaPickingHeader.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaPickingHeader.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaPickingEncabezadoCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaPickingHeader();
        }
        private void UiListaPickingHeader_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (UiListaTipo.EditValue != null)
            {
                if ((Enums.GetStringValue((TipoDeManifiestoDeCarga)UiListaTipo.EditValue) == Enums.GetStringValue(TipoDeManifiestoDeCarga.Transferencia)) && e.Value != null)
                {
                    var documentoSeleccionado = (Picking)e.Value;
                    foreach (var documento in PickingEncabezado)
                    {
                        if (documento.WAVE_PICKING_ID == documentoSeleccionado.WAVE_PICKING_ID)
                        {
                            documento.IS_SELECTED = true;
                            UiListaPickingHeader.EditValue = documentoSeleccionado;
                        }
                        else
                        {
                            documento.IS_SELECTED = false;
                        }
                    }
                }
            }

            e.DisplayText = ObtenerTextoAMostrarListaPickingHeader();
        }
        private void UiVistaPickingHeader_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaPickingEncabezadoCompleta = true;
            }
        }

        private void UiVistaPickingHeader_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaPickingHeader.RowCount; i++)
            {
                var documento = (Picking)UiVistaPickingHeader.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaPickingHeader.SelectRow(i);
                }
            }
        }

        private string ObtenerTextoAMostrarListaPickingHeader()
        {
            if (PickingEncabezado == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in PickingEncabezado.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.WAVE_PICKING_ID);
            }
            return cadena.ToString();
        }

        private void UiVistaBodega_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Bodega)UiVistaBodega.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaBodegaCompleta)
                {
                    for (var i = 0; i < UiVistaBodega.RowCount; i++)
                    {
                        var documento = (Bodega)UiVistaBodega.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaBodega.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaBodegaCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaBodega();
        }

        private void UiListaBodega_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaBodega();
        }

        private void UiVistaBodega_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaBodegaCompleta = true;
            }
        }

        private void UiVistaBodega_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaBodega.RowCount; i++)
            {
                var documento = (Bodega)UiVistaBodega.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaBodega.SelectRow(i);
                }
            }
        }

        private string ObtenerTextoAMostrarListaBodega()
        {
            if (Bodegas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Bodegas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.WAREHOUSE_ID);
            }
            return cadena.ToString();
        }

        private void UiVistaRuta_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var documento = (Ruta)UiVistaRuta.GetRow(e.ControllerRow);
                documento.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaRutaCompleta)
                {
                    for (var i = 0; i < UiVistaRuta.RowCount; i++)
                    {
                        var documento = (Ruta)UiVistaRuta.GetRow(i);
                        if (documento == null) continue;
                        documento.IS_SELECTED = (UiVistaRuta.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaRutaCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaRuta();
        }

        private void UiListaRuta_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaRuta();
        }

        private void UiVistaRuta_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;
            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaRutaCompleta = true;
            }
        }

        private void UiVistaRuta_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiVistaRuta.RowCount; i++)
            {
                var documento = (Ruta)UiVistaRuta.GetRow(i);
                if (documento == null) continue;
                if (documento.IS_SELECTED)
                {
                    UiVistaRuta.SelectRow(i);
                }
            }
        }

        private string ObtenerTextoAMostrarListaRuta()
        {
            if (Rutas == null) return "";
            var cadena = new StringBuilder();
            foreach (var documento in Rutas.Where(doc => doc.IS_SELECTED))
            {
                if (cadena.Length > 0) { cadena.Append(","); }
                cadena.Append(documento.CODE_ROUTE);
            }
            return cadena.ToString();
        }


        public void CargarManifiesto(string manifiestoId)
        {
            try
            {
                if (!string.IsNullOrEmpty(manifiestoId))
                {
                    LastManifestHeaderId = manifiestoId;
                    LimpiarControles();
                    BuscarManifiestoDeCarga(null);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta("Error al cargar el manifiesto: " + ex.Message + ex.StackTrace);
            }
        }


        #endregion


    }
}
