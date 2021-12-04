using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.UI;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Modelo.Tipos;


using System.Data;
using System.Data.OleDb;
using ClosedXML.Excel;

namespace MobilityScm.Modelo.Vistas
{
    public partial class SolicitudDeTrasladoVista : VistaBase, ISolicitudDeTrasladoVista
    {

        

        #region Eventos 
        public event EventHandler<SolicitudDeTrasladoArgumento> UsuarioDeseaBuscarSolicitudDeTraslado;
        public event EventHandler<SolicitudDeTrasladoArgumento> UsuarioDeseaGuardarSolicitudDeTraslado;
        public event EventHandler<SolicitudDeTrasladoArgumento> UsuarioSeleccionoCentroDeDistribucionDestino;
        public event EventHandler<SolicitudDeTrasladoArgumento> UsuarioSeleccionoCentroDeDistribucionOrigen;
        public event EventHandler<ConteoFisicoArgumento> UsuarioSeleccionoCliente;
        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler UsuarioDeseaRefrescarCentrosDeDistribucionOrigen;
        public event EventHandler UsuarioDeseaRefrescarCentrosDeDistribucionDestino;
        public event EventHandler UsuarioDeseaRefrescarClientes;
        public event EventHandler UsuarioDeseaRefrescarTipos;
        #endregion

        #region Propiedades
        public IList<Bodega> BodegasDestino
        {
            get
            {
                return (IList<Bodega>)UiListaBodegaDestino.Properties.DataSource;
            }
            set
            {
                UiListaBodegaDestino.Properties.DataSource = value;
            }
        }

        public IList<Bodega> BodegasOrigen
        {
            get
            {
                return (IList<Bodega>)UiListaBodegaOrigen.Properties.DataSource;
            }
            set
            {
                UiListaBodegaOrigen.Properties.DataSource = value;
            }
        }

        public IList<Entidades.Configuracion> CentrosDeDistribucionDestino
        {
            get
            {
                return (IList<Entidades.Configuracion>)UiListaCentroDistribucionDestino.Properties.DataSource;
            }
            set
            {
                UiListaCentroDistribucionDestino.Properties.DataSource = value;
            }
        }

        public IList<Entidades.Configuracion> CentrosDeDistribucionOrigen
        {
            get
            {
                return (IList<Entidades.Configuracion>)UiListaCentroDistribucionOrigen.Properties.DataSource;
            }
            set
            {
                UiListaCentroDistribucionOrigen.Properties.DataSource = value;
            }
        }

        public IList<Cliente> Clientes
        {
            get
            {
                return (IList<Cliente>)UiListaCliente.Properties.DataSource;
            }
            set
            {
                UiListaCliente.Properties.DataSource = value;
            }
        }

        public IList<Sku> Materiales
        {
            get
            {
                return (IList<Sku>)UiContenedorVistaSolicitudDeTraslado.DataSource;
            }
            set
            {
                UiContenedorVistaSolicitudDeTraslado.DataSource = value;
            }
        }

        public IList<SolicitudDeTrasladoDetalle> SolicitudDeTrasladoDetalle
        {
            get
            {
                return (IList<SolicitudDeTrasladoDetalle>)UiContenedorVistaSolicitudDeTraslado.DataSource;
            }

            set
            {
                UiContenedorVistaSolicitudDeTraslado.DataSource = value;
            }
        }

        public SolicitudDeTrasladoEncabezado SolicitudDeTrasladoEncabezado { get; set; }

        public IList<Entidades.Configuracion> TiposSolicitudDeTraslado
        {
            get
            {
                return (IList<Entidades.Configuracion>)UiListaTipo.Properties.DataSource;
            }
            set
            {
                UiListaTipo.Properties.DataSource = value;
            }
        }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        private bool UsuarioSeleccionoListaClientesCompleta { get; set; }
        private bool UsuarioSeleccionoListaMaterialesCompleta { get; set; }
        
        public int IdSolicitudDeTraslado
        {
            get
            {
                return int.Parse(UiTextoIdSolicitud.EditValue.ToString());
            }
            set
            {
                UiTextoIdSolicitud.EditValue = value.ToString();
            }
        }

        private IList<SolicitudDeTrasladoDetalle> SolicitudTrasladoExportarDetalle
        {
            set
            {
                UiContenedorExportar.DataSource = value;
            }
        }

        public IList<Seguridad> ListaDeSeguridad {get; set; }

        #endregion

        #region Contructor y Eventos de Carga
        public SolicitudDeTrasladoVista()
        {
            InitializeComponent();

            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<ISolicitudDeTrasladoServicio, SolicitudDeTrasladoServicio>();
            Mvx.Ioc.RegisterType<IClienteServicio, ClienteServicio>();
            Mvx.Ioc.RegisterType<IConfiguracionServicio, ConfiguracionServicio>();
            Mvx.Ioc.RegisterType<IBodegaServicio, BodegaServicio>();
            Mvx.Ioc.RegisterType<IMaterialServicio, MaterialServicio>();
            Mvx.Ioc.RegisterType<ISeguridadServicio, SeguridadServicio>();

            Mvx.Ioc.RegisterSingleton<ISolicitudDeTrasladoVista, SolicitudDeTrasladoVista>(this);
            Mvx.Ioc.RegisterType<ISolicitudDeTrasladoControlador, SolicitudDeTrasladoControlador>();
            Mvx.Ioc.Resolve<ISolicitudDeTrasladoControlador>();
        }
        private void SolicitudDeTrasladoVista_Load(object sender, EventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiContenedorVistaSolicitudDeTraslado, false, InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);
            ManejarColumnaDeInventarioDisponible();
        }
        #endregion

        #region Metodos
        private bool ValidarCargaMateriales()
        {
            var resultado = false;
            UiError.SetError(UiListaBodegaOrigen, string.Empty, ErrorType.None);


            if (UiListaBodegaOrigen.EditValue == null)
            {
                UiError.SetError(UiListaBodegaOrigen, "Campo Obligatorio");
                resultado = true;
            }

            return resultado;
        }

        private string ObtenerTextoAMostrarListaCliente()
        {
            return Clientes == null ? string.Empty : string.Join(",", Clientes.Where(cl => cl.IS_SELECTED).Select(cl => cl.CLIENT_NAME));
        }

        private void ObtenerMateriales(object sender)
        {
            if (ValidarCargaMateriales()) return;

            var cadena = string.Join("|", Clientes.Where(cl => cl.IS_SELECTED).Select(cl => cl.CLIENT_CODE));

            UsuarioSeleccionoCliente?.Invoke(sender, new ConteoFisicoArgumento
            {
                Bodegas = UiListaBodegaOrigen.EditValue.ToString(),
                Regimen = "GENERAL",
                Clientes = cadena,
                Login = InteraccionConUsuarioServicio.ObtenerUsuario()
            });
        }

        private void LimpiarCampos()
        {
            Materiales = null;
            BodegasOrigen = null;
            BodegasDestino = null;
            Clientes.ToList().ForEach(cl => cl.IS_SELECTED = false);
            UiListaBodegaOrigen.EditValue = null;
            UiListaBodegaDestino.EditValue = null;
            UiListaCliente.EditValue = null;
            UiListaCentroDistribucionOrigen.EditValue = null;
            UiListaCentroDistribucionDestino.EditValue = null;
            UiListaTipo.EditValue = null;
            UiFechaEntrega.EditValue = null;
            UiTextoComentario.Text = string.Empty;

            UiVistaCliente.ClearSelection();
            UiListaCliente.Text = string.Empty;
            UiError.ClearErrors();

            DeshabilitarCampos(false);
        }

        private void DeshabilitarCampos(bool accion)
        {
            UiListaBodegaOrigen.ReadOnly = accion;
            UiListaBodegaDestino.ReadOnly = accion;
            UiListaCentroDistribucionOrigen.ReadOnly = accion;
            UiListaCentroDistribucionDestino.ReadOnly = accion;
            UiFechaEntrega.ReadOnly = accion;
            UiTextoComentario.ReadOnly = accion;
            UiListaTipo.ReadOnly = accion;
            UiListaCliente.ReadOnly = accion;

            UiContenedorVistaSolicitudDeTraslado.MainView = accion? UiVistaSolicitudDeTrasladoDetalle : UiVistaSolicitudTraslado;

            UiBotonReporte.Enabled = accion;
            UiBotonExportar.Enabled = accion;
            UiBotonGrabar.Enabled = !accion;
            UiBotonRefrescar.Enabled = !accion;

            UiTextoBodegaOrigen.Visible = accion;
            UiTextoBodegaDestino.Visible = accion;
            UiListaBodegaOrigen.Visible = !accion;
            UiListaBodegaDestino.Visible = !accion;
        }

        private bool ValidarCamposGuardar()
        {
            var resultado = false;
            UiError.SetError(UiListaBodegaOrigen, string.Empty, ErrorType.None);


            if (UiListaBodegaOrigen.EditValue == null)
            {
                UiError.SetError(UiListaBodegaOrigen, "Campo Obligatorio");
                resultado = true;
            }
            if (UiListaBodegaDestino.EditValue == null)
            {
                UiError.SetError(UiListaBodegaDestino, "Campo Obligatorio");
                resultado = true;
            }
            if (UiFechaEntrega.EditValue == null)
            {
                UiError.SetError(UiFechaEntrega, "Campo Obligatorio");
                resultado = true;
            }
            if (UiListaTipo.EditValue == null)
            {
                UiError.SetError(UiListaTipo, "Campo Obligatorio");
                resultado = true;
            }
            if (UiFechaEntrega.DateTime < DateTime.Now.Date)
            {
                InteraccionConUsuarioServicio.Mensaje("La fecha de entrega del documento no puede ser menor a la del día.");
                resultado = true;
            }
            if (UiListaBodegaDestino.EditValue != null && UiListaBodegaOrigen.EditValue != null)
            {
                var bodDestino = UiListaBodegaDestino.Text;
                var bodOrigen = UiListaBodegaOrigen.Text;
                if (bodDestino == bodOrigen)
                {
                    InteraccionConUsuarioServicio.Mensaje("La bodega origen y destino no pueden ser las mismas.");
                    resultado = true;
                }
            }

            return resultado;
        }

        private void BuscarSolicitudDeTraslado(object sender, int id)
        {
            LimpiarCampos();

            UsuarioDeseaBuscarSolicitudDeTraslado?.Invoke(sender, new SolicitudDeTrasladoArgumento
            {
                SolicitudDeTrasladoEncabezado = new SolicitudDeTrasladoEncabezado
                {
                    TRANSFER_REQUEST_ID = id
                }
            });
            if (SolicitudDeTrasladoEncabezado == null)
            {
                InteraccionConUsuarioServicio.Mensaje("Registro no encontrado");
                return;
            }
            UiListaCentroDistribucionOrigen.EditValue = SolicitudDeTrasladoEncabezado.DISTRIBUTION_CENTER_FROM;
            UiListaCentroDistribucionDestino.EditValue = SolicitudDeTrasladoEncabezado.DISTRIBUTION_CENTER_TO;

            UiTextoBodegaOrigen.Text = SolicitudDeTrasladoEncabezado.WAREHOUSE_FROM;
            UiTextoBodegaDestino.Text = SolicitudDeTrasladoEncabezado.WAREHOUSE_TO;
            UiListaTipo.EditValue = SolicitudDeTrasladoEncabezado.REQUEST_TYPE;
            
            if (SolicitudDeTrasladoEncabezado.DELIVERY_DATE != null)
                UiFechaEntrega.DateTime = SolicitudDeTrasladoEncabezado.DELIVERY_DATE.Value;
            UiTextoComentario.Text = SolicitudDeTrasladoEncabezado.COMMENT;

            DeshabilitarCampos(true);
        }

        private void ManejarColumnaDeInventarioDisponible()
        {
            var permiso = ListaDeSeguridad.FirstOrDefault(p => p.CHECK_ID == Enums.GetStringValue(Tipos.OpcionPermisos.TrasladosEntreCd));
            var mostrarColumna = (permiso != null);

            colINVENTORY.Visible = mostrarColumna;
            colINVENTORY.OptionsColumn.ShowInCustomizationForm = mostrarColumna;
        }

        #endregion

        #region Eventos de Controles
        private void UiLista_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "REFRESCAR-CD-ORIGEN":
                    UsuarioDeseaRefrescarCentrosDeDistribucionOrigen?.Invoke(sender, e);
                    break;
                case "REFRESCAR-CD-DESTINO":
                    UsuarioDeseaRefrescarCentrosDeDistribucionDestino?.Invoke(sender, e);
                    break;
                case "REFRESCAR-CLIENTE":
                    UsuarioDeseaRefrescarClientes?.Invoke(sender, e);
                    break;
                case "REFRESCAR-TIPO":
                    UsuarioDeseaRefrescarTipos?.Invoke(sender, e);
                    break;
                case "REFRESCAR-BODEGA-ORIGEN":
                    if (UiListaCentroDistribucionOrigen.EditValue == null) return;
                    UsuarioSeleccionoCentroDeDistribucionOrigen?.Invoke(sender, new SolicitudDeTrasladoArgumento
                    {
                        CentroDeDistribucion = UiListaCentroDistribucionOrigen.EditValue.ToString()
                    });
                    break;
                case "REFRESCAR-BODEGA-DESTINO":
                    if (UiListaCentroDistribucionDestino.EditValue == null) return;
                    UsuarioSeleccionoCentroDeDistribucionDestino?.Invoke(sender, new SolicitudDeTrasladoArgumento
                    {
                        CentroDeDistribucion = UiListaCentroDistribucionDestino.EditValue.ToString()
                    });
                    break;
            }
        }

        private void UiListaCentroDistribucionOrigen_EditValueChanged(object sender, EventArgs e)
        {
            if (UiListaCentroDistribucionOrigen.EditValue == null) return;
            UiListaBodegaOrigen.EditValue = null;
            UsuarioSeleccionoCentroDeDistribucionOrigen?.Invoke(sender, new SolicitudDeTrasladoArgumento
            {
                CentroDeDistribucion = UiListaCentroDistribucionOrigen.EditValue.ToString()
            });
        }

        private void UiListaCentroDistribucionDestino_EditValueChanged(object sender, EventArgs e)
        {
            if (UiListaCentroDistribucionDestino.EditValue == null) return;
            UiListaBodegaDestino.EditValue = null;
            UsuarioSeleccionoCentroDeDistribucionDestino?.Invoke(sender, new SolicitudDeTrasladoArgumento
            {
                CentroDeDistribucion = UiListaCentroDistribucionDestino.EditValue.ToString()
            });
        }

        private void UiListaBodegaOrigen_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerMateriales(sender);
        }

        private void UiListaCliente_EditValueChanged(object sender, EventArgs e)
        {
            ObtenerMateriales(sender);
        }

        private void UiListaCliente_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarListaCliente();
        }

        private void UiVistaSolicitudTraslado_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var material = (Sku)UiVistaSolicitudTraslado.GetRow(e.ControllerRow);
                material.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (!UsuarioSeleccionoListaMaterialesCompleta) return;

                for (var i = 0; i < UiVistaSolicitudTraslado.RowCount; i++)
                {
                    var material = (Sku)UiVistaSolicitudTraslado.GetRow(i);
                    if (material == null) continue;
                    material.IS_SELECTED = (UiVistaSolicitudTraslado.SelectedRowsCount != 0);
                }
                UsuarioSeleccionoListaMaterialesCompleta = false;
            }
        }

        private void UiVistaCliente_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var cliente = (Cliente)UiVistaCliente.GetRow(e.ControllerRow);
                cliente.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaClientesCompleta)
                {
                    for (var i = 0; i < UiVistaCliente.RowCount; i++)
                    {
                        var cliente = (Cliente)UiVistaCliente.GetRow(i);
                        if (cliente == null) continue;
                        cliente.IS_SELECTED = (UiVistaCliente.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaClientesCompleta = false;
                }
            }

            var edit = ActiveControl as DevExpress.XtraEditors.SearchLookUpEdit;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarListaCliente();
        }

        private void UiVistaCliente_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaClientesCompleta = true;
            }
        }

        private void UiVistaSolicitudTraslado_MouseUp(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view == null)
                return;
            var hi = view.CalcHitInfo(new Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) && hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaMaterialesCompleta = true;
            }
        }

        private void UiVistaSolicitudTraslado_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var view = sender as GridView;
            if (view == null || view.FocusedColumn.FieldName != "QTY") return;
            var registro = (Sku)UiVistaSolicitudTraslado.GetRow(view.FocusedRowHandle);

            try
            {
                var qty = double.Parse(e.Value.ToString());
                registro.QTY = qty;
                Materiales.Where(mt => mt.MATERIAL_ID == registro.MATERIAL_ID).ToList().ForEach(mt => mt.QTY = qty);
                if (!(qty <= 0)) return;
                e.Valid = false;
                e.ErrorText = "La cantidad debe de ser mayor a 0";
            }
            catch (Exception)
            {
                e.Valid = false;
                e.ErrorText = "Cantidad inválida.";
            }
        }
        private void UiBotonNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            LimpiarCampos();
        }
        private void UiBotonRefrescar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ObtenerMateriales(sender);
        }

        private void UiBotonBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (UiTextoIdSolicitud.EditValue == null) return;
            BuscarSolicitudDeTraslado(sender, int.Parse(UiTextoIdSolicitud.EditValue.ToString()));
        }
        
        private void UiVistaSolicitudTraslado_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colQTY) return;
            try
            {
                if (decimal.Parse(e.Value.ToString()) >= 0) return;
                var qty = double.Parse(e.Value.ToString());
                var materialId = UiVistaSolicitudTraslado.GetRowCellValue(e.RowHandle, colMATERIAL_ID);
                Materiales.Where(mt => mt.MATERIAL_ID == materialId.ToString()).ToList().ForEach(mt => mt.QTY = qty);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void UiBotonGrabar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidarCamposGuardar()) return;
            var listadoNegativos = Materiales.Where(mt => mt.IS_SELECTED && mt.QTY <= 0).ToList();
            if (listadoNegativos.Count > 0)
            {
                InteraccionConUsuarioServicio.Mensaje("La cantidad de los materiales debe ser mayor a 0.");
                return;
            }
            var listadoMateriales = Materiales.Where(mt => mt.IS_SELECTED && mt.QTY > 0).ToList();
            if (listadoMateriales.Count == 0)
            {
                InteraccionConUsuarioServicio.Mensaje("Debe de seleccionar al menos un material para la solicitud de traslado.");
                return;
            }
            UsuarioDeseaGuardarSolicitudDeTraslado?.Invoke(sender, new SolicitudDeTrasladoArgumento
            {
                SolicitudDeTrasladoEncabezado = new SolicitudDeTrasladoEncabezado
                {
                    REQUEST_TYPE = UiListaTipo.EditValue.ToString(),
                    WAREHOUSE_FROM = UiListaBodegaOrigen.EditValue.ToString(),
                    WAREHOUSE_TO = UiListaBodegaDestino.EditValue.ToString(),
                    DELIVERY_DATE = UiFechaEntrega.DateTime,
                    COMMENT = UiTextoComentario.Text,
                    STATUS = EstadoSolicitudDeTraslado.OPEN.ToString(),
                    CREATED_BY = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    IS_FROM_ERP = UiCheckEnviarErp.Checked ? (int)SiNo.Si : (int)SiNo.No
                },
                ListadoMateriales = listadoMateriales
            });


            BuscarSolicitudDeTraslado(sender, IdSolicitudDeTraslado);
        }

        private void UiBotonExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SolicitudDeTrasladoDetalle.ToList().ForEach(dt =>
            {
                dt.WAREHOUSE_FROM = SolicitudDeTrasladoEncabezado.WAREHOUSE_FROM;
                dt.WAREHOUSE_TO = SolicitudDeTrasladoEncabezado.WAREHOUSE_TO;
                dt.DELIVERY_DATE = SolicitudDeTrasladoEncabezado.DELIVERY_DATE;
                dt.REQUEST_TYPE = SolicitudDeTrasladoEncabezado.REQUEST_TYPE;
                dt.COMMENT = SolicitudDeTrasladoEncabezado.COMMENT;
            });
            SolicitudTrasladoExportarDetalle = SolicitudDeTrasladoDetalle;

            UiContenedorExportar.Visible = true;

            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UiVistaExportar.ExportToXlsx(saveFileDialog1.FileName);
            }

            UiContenedorExportar.Visible = false;
        }

        private void UiBotonReporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdSolicitudDeTraslado == 0)
            {
                InteraccionConUsuarioServicio.Mensaje("Debe de cargar una solicitud de traslado para generar el reporte.");
            }
            else
            {
                UsuarioDeseaBuscarSolicitudDeTraslado?.Invoke(sender, new SolicitudDeTrasladoArgumento
                {
                    SolicitudDeTrasladoEncabezado = new SolicitudDeTrasladoEncabezado
                    {
                        TRANSFER_REQUEST_ID = IdSolicitudDeTraslado
                    }
                });

                var listaDetalleParaReporte =
                    SolicitudDeTrasladoDetalle.GroupBy(
                        b =>
                            new
                            {
                                b.MATERIAL_ID,
                                b.MATERIAL_NAME,
                                b.IS_MASTERPACK,
                                b.IS_MASTERPACK_DESCRIPTION,
                                b.QTY,
                                b.STATUS,
                                b.STATUS_DESCRIPTION
                            }).Select(b => new SolicitudDeTrasladoDetalle
                            {
                                MATERIAL_ID = b.Key.MATERIAL_ID,
                                MATERIAL_NAME = b.Key.MATERIAL_NAME,
                                IS_MASTERPACK = b.Key.IS_MASTERPACK,
                                IS_MASTERPACK_DESCRIPTION = b.Key.IS_MASTERPACK_DESCRIPTION,
                                QTY = b.Key.QTY,
                                STATUS = b.Key.STATUS,
                                STATUS_DESCRIPTION = b.Key.STATUS_DESCRIPTION
                            }).ToList();


                var reporte = new Reportes.SolicitudDeTraslado
                {
                    DataSource = ListToDataTableClass.ListToDataTable(listaDetalleParaReporte),
                    RequestParameters = false
                };                                                 

                reporte.Parameters["COMMENT"].Value = SolicitudDeTrasladoEncabezado.COMMENT;
                reporte.Parameters["DELIVERY_DATE"].Value = SolicitudDeTrasladoEncabezado.DELIVERY_DATE;
                reporte.Parameters["LOGIN"].Value = InteraccionConUsuarioServicio.ObtenerNombreUsuario();
                reporte.Parameters["REQUEST_TYPE"].Value = SolicitudDeTrasladoEncabezado.REQUEST_TYPE_DESCRIPTION;
                reporte.Parameters["TRANSFER_REQUEST_ID"].Value = IdSolicitudDeTraslado;
                reporte.Parameters["WAREHOUSE_FROM"].Value = SolicitudDeTrasladoEncabezado.WAREHOUSE_FROM;
                reporte.Parameters["WAREHOUSE_TO"].Value = SolicitudDeTrasladoEncabezado.WAREHOUSE_TO;
                reporte.Parameters["STATUS_HEADER"].Value = SolicitudDeTrasladoEncabezado.STATUS_DESCRIPTION;

                reporte.Parameters["LOGO"].Value = InteraccionConUsuarioServicio.ObtenerLogo();
                reporte.FillDataSource();

                using (var printTool = new ReportPrintTool(reporte))
                {
                    printTool.ShowRibbonPreviewDialog();
                }
            }
        }

        private void UiControlTextoIdSolicitud_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyCode == Keys.Enter)
                {
                    var numeroDeSolicitudDeTraslado = (sender as TextEdit).Text;
                    BuscarSolicitudDeTraslado(sender, int.Parse(numeroDeSolicitudDeTraslado));
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        public void importarExcel( String nameSheet){
            OleDbConnection connect;
            OleDbDataAdapter dataAdapter;
            DataTable dTable = new DataTable();
            string path = ""; 
            var idCDOrigen = UiListaCentroDistribucionOrigen.EditValue;
            var idBodegaOrigen = UiListaBodegaOrigen.EditValue;
            var idCDDestino = UiListaCentroDistribucionDestino.EditValue;
            var idBodegaDestino = UiListaBodegaDestino.EditValue;
            var idCliente = UiListaCliente.Text;
            var idTipo = UiListaTipo.EditValue;
            var fechaEntrega = UiFechaEntrega.EditValue;

            if (idCDOrigen == null || idBodegaOrigen == null || idCDDestino == null || idBodegaDestino == null || idCliente == "" || idTipo == null || fechaEntrega == null)
            {
                MessageBox.Show("Debe ingresar todos los datos del encabezado", "Error al cargar archivo excel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // limpiar los skus seleccionados previamente
            
            for (int i = 0; i < UiVistaSolicitudTraslado.RowCount; i++){
                string qty = UiVistaSolicitudTraslado.GetRowCellValue( i, colINVENTORY).ToString();
                int qTY = int.Parse(qty);
                UiVistaSolicitudTraslado.UnselectRow(i);
                UiVistaSolicitudTraslado.SetRowCellValue(i, colQTY, qTY);
            }

            try
            {
                //CONFIGURACION PARA LA VENTANA DE BUSQUEDA
                OpenFileDialog oFileDialog = new OpenFileDialog();
                oFileDialog.Filter = "Excel Files |*.xlsx";
                oFileDialog.Title = "Cargar Archivo";

                //VALIDA SI PRESIONA EL BOTON ABRIR Y SI LA RUTA DEL ARCHIVO NO ES NULA
                if (oFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (oFileDialog.FileName.Equals("") == false) path = oFileDialog.FileName;
                    else MessageBox.Show("Debe seleccionar un archivo .xlsx para continuar con la operacion", "Error al cargar el excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else return;

                //CREACION DE LA CONEXION
                connect = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; data source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                dataAdapter = new OleDbDataAdapter("select * from [" + nameSheet + "$]", connect);  // selecciona toda la informacion de la hoja de trabajo del archivo

                //INGRESA DATOS AL DATA TABLE    
                dataAdapter.Fill(dTable);

                // INGRESA LA INFORMACION DEL DATA TABLE AL GRIDVIEW
                foreach (DataRow row in dTable.Rows)
                {
                    string codM = row[0].ToString(); // id producto para validacion en if
                    string cant = row[2].ToString();
                    bool existe = false;
                    
                    for (int j = 0; j < UiVistaSolicitudTraslado.RowCount; j++)
                    {

                        string txtIdMaterial = UiVistaSolicitudTraslado.GetRowCellValue(j, colMATERIAL_ID).ToString(); 
                        string txtInventario = UiVistaSolicitudTraslado.GetRowCellValue(j, colINVENTORY).ToString();

                        if (txtIdMaterial == codM)
                        {
                            int disponible = int.Parse(txtInventario);
                            int solicitado = int.Parse(cant);

                            if (solicitado <= disponible)
                            {
                                UiVistaSolicitudTraslado.SelectRow(j);
                                UiVistaSolicitudTraslado.SetRowCellValue(j, colQTY, cant);
                            }
                            else MessageBox.Show("La cantidad que solicita del producto: " + txtIdMaterial + " no esta disponible", "Error al modificar la tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                        System.Diagnostics.Debug.WriteLine(existe);
                        //System.Diagnostics.Debug.WriteLine("{ ID: " + txtIdMaterial + " || Material: " + txtNombreMaterial + " ||Es Master Pack: " + txtEsMasterPack + " Cantidad: " + txtCantidad + " Inventario Disponible: " + txtInventario + " }");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            dTable.Rows.Clear();
            dTable.AcceptChanges();
        }

        public void guardarExcel() {

            XLWorkbook book = new XLWorkbook();
            var sheet = book.Worksheets.Add("Hoja 1");  //se crea una nueva hoja
            var rango = sheet.Range("A1:C1");
            SaveFileDialog saveF = new SaveFileDialog(); //instancia para cuadro de dialogo
            saveF.Filter = "Excel Files |*.xlsx";
            var ra = sheet.Range(2, 1, 500, 3);
            var c1 = sheet.Column(1);
            var c2 = sheet.Column(2);
            var c3 = sheet.Column(3);

            //agregando valores de encabezado
            sheet.Cell("A1").Value = "Código de material";
            sheet.Cell("B1").Value = "Descripción";
            sheet.Cell("C1").Value = "Cantidad";

            //agregando validaciones a las columnas
            c1.Width = 23;
            c2.Width = 45;
            c3.Width = 24;

            c1.SetDataValidation().TextLength.EqualOrLessThan(25);
            c1.SetDataValidation().ErrorStyle = ClosedXML.Excel.XLErrorStyle.Stop;
            c1.SetDataValidation().ErrorTitle = "El texto supera el limite";
            c1.SetDataValidation().ErrorMessage = "solo puede ingresar un maximo de 25 caracteres";

            c2.SetDataValidation().TextLength.EqualOrLessThan(50);
            c2.SetDataValidation().ErrorStyle = ClosedXML.Excel.XLErrorStyle.Stop;
            c2.SetDataValidation().ErrorTitle = "El texto supera el limite";
            c2.SetDataValidation().ErrorMessage = "solo puede ingresar un maximo de 50 caracteres";

            c3.SetDataValidation().TextLength.EqualOrLessThan(25);
            c3.SetDataValidation().ErrorStyle = ClosedXML.Excel.XLErrorStyle.Stop;
            c3.SetDataValidation().ErrorTitle = "El texto supera el limite";
            c3.SetDataValidation().ErrorMessage = "solo puede ingresar un maximo de 25 caracteres";

            //configuracion y formato de la tabla
            rango.Style.Fill.BackgroundColor = XLColor.LightCornflowerBlue;
            rango.Style.Font.FontColor = XLColor.White;
            rango.Style.Font.SetBold();
            rango.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rango.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ra.Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin).Border.SetOutsideBorderColor(XLColor.BlueBell);
            ra.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin).Border.SetBottomBorderColor(XLColor.BlueBell);
            

            if (saveF.ShowDialog() == DialogResult.OK) book.SaveAs(saveF.FileName);
            else return;
            
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            importarExcel("Hoja 1");
        }

        private void UiContenedorVistaSolicitudDeTraslado_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            guardarExcel();
        }
    }
}
