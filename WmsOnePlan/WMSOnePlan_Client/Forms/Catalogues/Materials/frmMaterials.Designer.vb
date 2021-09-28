<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaterials
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleExpression1 As DevExpress.XtraEditors.FormatConditionRuleExpression = New DevExpress.XtraEditors.FormatConditionRuleExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaterials))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_Grp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_SubTipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Client = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColum_ClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Barcodeid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CantidadDeUnidadesDeMedida = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EsCarro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManejaLote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManejaSerie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManejaMasterPack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ManejaExplosionEnRecepcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnidadPeso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Peso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ControlDeCalidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColManejaSerieCorrelativa = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColPrefixCorrelativeSerial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColExpirationTolerance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColSupplier = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNameSupplier = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.UiTabMateriales = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControlVF = New DevExpress.XtraGrid.GridControl()
        Me.GridViewFV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodigo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnFactor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiTabUnidadMedida = New DevExpress.XtraTab.XtraTabPage()
        Me.UiContenedorVistasUnidadMedida = New DevExpress.XtraGrid.GridControl()
        Me.UIVistaUnidadMedida = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colUnMEASUREMENT_UNIT_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnCLIENT_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnMATERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnMEASUREMENT_UNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnDESCRIPTION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUnALTERNATIVE_BARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.UiTabDatosGenerales = New DevExpress.XtraTab.XtraTabPage()
        Me.UiPropiedadDeDatosGenerales = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.UiListaDeClientes = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiListaClases = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiListaSubClases = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiCboPropiedadManejaCalibre = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.UiCboPropiedadManejaTono = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.DatosDeAuditoria = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.PropiedadDeDatosGenerales_ActualizadoEl = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ActualizadoPor = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.DatosGenerales = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Clase = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_SubClase = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Cliente = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Codigo = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_CodigoBarras = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Descripcion = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_DescripcionCorta = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_EsCarro = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaLote = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaSerie = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaMasterPack = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_UnidadPeso = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaTono = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_ManejaCalibre = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_UsaLineaPicking = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_LEAD_TIME = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Proveedor = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDEDatosGenerales_NombreProveedor = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.Dimensiones = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.PropiedadDeDatosGenerales_Alto = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Ancho = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_FactorVolumen = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Largo = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.PropiedadDeDatosGenerales_Peso = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.BarDockControl11 = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager2 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarDatosGenerales = New DevExpress.XtraBars.Bar()
        Me.UiBotonNuevo = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGuardar = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonExportarExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonDescargarPlantillaEnDatosGenerales = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCargarPlantillaEnDatosGenerales = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl9 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl10 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl12 = New DevExpress.XtraBars.BarDockControl()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.UiTabUbicacion = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Min = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtMinQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn_Max = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtMaxQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.BarDockControl15 = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager3 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarUbicacion = New DevExpress.XtraBars.Bar()
        Me.UiBotonNuevaUbicacion = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonEliminarUbicacion = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGrabarUbicacion = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonDescargarPlantillaEnUbicacion = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCargarPlantillaEnUbicacion = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl13 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl14 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl16 = New DevExpress.XtraBars.BarDockControl()
        Me.UiTabEmpaque = New DevExpress.XtraTab.XtraTabPage()
        Me.UiPropiedadDeEmpaque = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.UiStoragePackaging = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaterialCategoria = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.codigoDeClientePropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.codigoDeMaterialPropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.EmpaqueCategoria = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.empaquePropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.cantidadPropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.codigoPropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.codigoDeBarrasPropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.codigoDeBarrasAlternativoPropiedad = New DevExpress.XtraVerticalGrid.Rows.PGridEditorRow()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarUnidadDeMedida = New DevExpress.XtraBars.Bar()
        Me.UiBotonAgregarEmpaque = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGuardarEmpaque = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonElimnarEmpaque = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonImprimirEmpaque = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonExportarEmpaquesExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonDescargarPlantillaEnUnidadDeMedida = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCargarPlantillaEnUnidadDeMedida = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.RepositoryItemLineSpacing1 = New DevExpress.XtraRichEdit.Design.RepositoryItemLineSpacing()
        Me.UiTabMasterPack = New DevExpress.XtraTab.XtraTabPage()
        Me.UiContenedorDeVistasComponentes = New DevExpress.XtraGrid.GridControl()
        Me.UiVistaComponentesAsociados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEnEliminar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiBotonEliminarComponente = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.colComponenteAsociadoCodigo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteAsociadoMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteAsociadoDescripcionMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteAsociadoCodigoBarra = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteAsociadoCantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteAsociadoEsMasterPack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.UiEtiquetaComponenteCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.UiSpinComponenteCantidad = New DevExpress.XtraEditors.SpinEdit()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.UiEtiquetaComponenteMaterial = New DevExpress.XtraEditors.LabelControl()
        Me.UiListaComponenteMaterial = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.UiListaVistaComponenteMaterial = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colComponenteDisponibleCodigoMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteDisponbileDescripcionMaterial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteDisponibleCodigoBarra = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colComponenteDisponbileEsMasterPack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.UiBarraMangMaterPack = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarraPrincipalMasterPack = New DevExpress.XtraBars.Bar()
        Me.UiBotonAgregarCompononente = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonDescargarPlantillaEnMasterPack = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCargarPlantillaEnMasterPack = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.UiTabExcepcionesPorBodega = New DevExpress.XtraTab.XtraTabPage()
        Me.UiContenedorExcepcionesPorBodega = New DevExpress.XtraGrid.GridControl()
        Me.UiVistaExcepcionPorBodega = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColBodega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiComboBodega = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiColPropiedad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiComboPropiedad = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiColValor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiComboValor = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UiColModifico = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColMaterialPropiedad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarDockControl7 = New DevExpress.XtraBars.BarDockControl()
        Me.BarManager4 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarExcepcionesPorBodega = New DevExpress.XtraBars.Bar()
        Me.UiBotonNuevaExcepcionPorBodega = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonGuardarExcepcionPorBodega = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonElimnarExcepcionPorBodega = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla = New DevExpress.XtraBars.BarButtonItem()
        Me.BarDockControl5 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl6 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl8 = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.SmallIconsList = New System.Windows.Forms.ImageList(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.UiTabMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMateriales.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridControlVF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewFV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUnidadMedida.SuspendLayout()
        CType(Me.UiContenedorVistasUnidadMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UIVistaUnidadMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.UiTabDatosGenerales.SuspendLayout()
        CType(Me.UiPropiedadDeDatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaDeClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaClases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaSubClases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCboPropiedadManejaCalibre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiCboPropiedadManejaTono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabUbicacion.SuspendLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaxQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabEmpaque.SuspendLayout()
        CType(Me.UiPropiedadDeEmpaque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiStoragePackaging, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLineSpacing1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMasterPack.SuspendLayout()
        CType(Me.UiContenedorDeVistasComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaComponentesAsociados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBotonEliminarComponente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.UiSpinComponenteCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.UiListaComponenteMaterial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiListaVistaComponenteMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBarraMangMaterPack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabExcepcionesPorBodega.SuspendLayout()
        CType(Me.UiContenedorExcepcionesPorBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiVistaExcepcionPorBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiComboBodega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiComboPropiedad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiComboValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(389, 341)
        Me.GridControl1.TabIndex = 15
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_Grp, Me.GridColumn_SubTipo, Me.GridColumn_ID, Me.GridColumn_Desc, Me.GridColumn_Client, Me.GridColum_ClientName, Me.GridColumn_Barcodeid, Me.CantidadDeUnidadesDeMedida, Me.EsCarro, Me.ManejaLote, Me.ManejaSerie, Me.ManejaMasterPack, Me.ManejaExplosionEnRecepcion, Me.UnidadPeso, Me.Peso, Me.ControlDeCalidad, Me.UiColManejaSerieCorrelativa, Me.UiColPrefixCorrelativeSerial, Me.UiColLeadTime, Me.UiColExpirationTolerance, Me.UiColSupplier, Me.UiColNameSupplier})
        Me.GridView1.CustomizationFormBounds = New System.Drawing.Rectangle(436, 271, 210, 172)
        Me.GridView1.FixedLineWidth = 1
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView1.LevelIndent = 0
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.PreviewIndent = 0
        Me.GridView1.ViewCaption = "Ubicaciones"
        '
        'GridColumn_Grp
        '
        Me.GridColumn_Grp.Caption = "Tipo"
        Me.GridColumn_Grp.FieldName = "CLASS_NAME"
        Me.GridColumn_Grp.Name = "GridColumn_Grp"
        Me.GridColumn_Grp.OptionsColumn.AllowEdit = False
        Me.GridColumn_Grp.OptionsColumn.ReadOnly = True
        Me.GridColumn_Grp.Visible = True
        Me.GridColumn_Grp.VisibleIndex = 0
        Me.GridColumn_Grp.Width = 37
        '
        'GridColumn_SubTipo
        '
        Me.GridColumn_SubTipo.Caption = "Sub Tipo"
        Me.GridColumn_SubTipo.FieldName = "SUB_CLASS_NAME"
        Me.GridColumn_SubTipo.Name = "GridColumn_SubTipo"
        Me.GridColumn_SubTipo.OptionsColumn.AllowEdit = False
        Me.GridColumn_SubTipo.OptionsColumn.ReadOnly = True
        Me.GridColumn_SubTipo.Visible = True
        Me.GridColumn_SubTipo.VisibleIndex = 1
        Me.GridColumn_SubTipo.Width = 37
        '
        'GridColumn_ID
        '
        Me.GridColumn_ID.Caption = "ID"
        Me.GridColumn_ID.FieldName = "MATERIAL_ID"
        Me.GridColumn_ID.Name = "GridColumn_ID"
        Me.GridColumn_ID.OptionsColumn.AllowEdit = False
        Me.GridColumn_ID.OptionsColumn.FixedWidth = True
        Me.GridColumn_ID.OptionsColumn.ReadOnly = True
        Me.GridColumn_ID.Visible = True
        Me.GridColumn_ID.VisibleIndex = 2
        Me.GridColumn_ID.Width = 94
        '
        'GridColumn_Desc
        '
        Me.GridColumn_Desc.Caption = "Descripcion"
        Me.GridColumn_Desc.FieldName = "MATERIAL_NAME"
        Me.GridColumn_Desc.Name = "GridColumn_Desc"
        Me.GridColumn_Desc.OptionsColumn.AllowEdit = False
        Me.GridColumn_Desc.OptionsColumn.AllowFocus = False
        Me.GridColumn_Desc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Desc.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Desc.Visible = True
        Me.GridColumn_Desc.VisibleIndex = 3
        Me.GridColumn_Desc.Width = 92
        '
        'GridColumn_Client
        '
        Me.GridColumn_Client.Caption = "Cliente"
        Me.GridColumn_Client.FieldName = "CLIENT_OWNER"
        Me.GridColumn_Client.Name = "GridColumn_Client"
        Me.GridColumn_Client.OptionsColumn.AllowEdit = False
        Me.GridColumn_Client.Visible = True
        Me.GridColumn_Client.VisibleIndex = 4
        Me.GridColumn_Client.Width = 71
        '
        'GridColum_ClientName
        '
        Me.GridColum_ClientName.Caption = "Nombre Cliente"
        Me.GridColum_ClientName.FieldName = "CLIENT_NAME"
        Me.GridColum_ClientName.Name = "GridColum_ClientName"
        Me.GridColum_ClientName.OptionsColumn.AllowEdit = False
        Me.GridColum_ClientName.Visible = True
        Me.GridColum_ClientName.VisibleIndex = 12
        '
        'GridColumn_Barcodeid
        '
        Me.GridColumn_Barcodeid.Caption = "Código Barras"
        Me.GridColumn_Barcodeid.FieldName = "BARCODE_ID"
        Me.GridColumn_Barcodeid.Name = "GridColumn_Barcodeid"
        Me.GridColumn_Barcodeid.OptionsColumn.AllowEdit = False
        Me.GridColumn_Barcodeid.Visible = True
        Me.GridColumn_Barcodeid.VisibleIndex = 5
        Me.GridColumn_Barcodeid.Width = 31
        '
        'CantidadDeUnidadesDeMedida
        '
        Me.CantidadDeUnidadesDeMedida.Caption = "Cantidad de Unidades de Medida"
        Me.CantidadDeUnidadesDeMedida.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CantidadDeUnidadesDeMedida.FieldName = "QTY_MEASURE"
        Me.CantidadDeUnidadesDeMedida.Name = "CantidadDeUnidadesDeMedida"
        Me.CantidadDeUnidadesDeMedida.OptionsColumn.AllowEdit = False
        Me.CantidadDeUnidadesDeMedida.Visible = True
        Me.CantidadDeUnidadesDeMedida.VisibleIndex = 6
        Me.CantidadDeUnidadesDeMedida.Width = 31
        '
        'EsCarro
        '
        Me.EsCarro.Caption = "Es Carro"
        Me.EsCarro.FieldName = "IS_CAR_DESCRIPTION"
        Me.EsCarro.Name = "EsCarro"
        Me.EsCarro.OptionsColumn.AllowEdit = False
        '
        'ManejaLote
        '
        Me.ManejaLote.Caption = "Maneja Lote"
        Me.ManejaLote.FieldName = "BATCH_REQUESTED_DESCRIPTION"
        Me.ManejaLote.Name = "ManejaLote"
        Me.ManejaLote.OptionsColumn.AllowEdit = False
        '
        'ManejaSerie
        '
        Me.ManejaSerie.Caption = "Maneja Serie"
        Me.ManejaSerie.FieldName = "SERIAL_NUMBER_REQUESTS_DESCRIPTION"
        Me.ManejaSerie.Name = "ManejaSerie"
        Me.ManejaSerie.OptionsColumn.AllowEdit = False
        '
        'ManejaMasterPack
        '
        Me.ManejaMasterPack.Caption = "Maneja Master Pack"
        Me.ManejaMasterPack.FieldName = "IS_MASTER_PACK_DESCRIPTION"
        Me.ManejaMasterPack.Name = "ManejaMasterPack"
        Me.ManejaMasterPack.OptionsColumn.AllowEdit = False
        '
        'ManejaExplosionEnRecepcion
        '
        Me.ManejaExplosionEnRecepcion.Caption = "Maneja Explosion en Recepción"
        Me.ManejaExplosionEnRecepcion.FieldName = "EXPLODE_IN_RECEPTION_DESCRIPTION"
        Me.ManejaExplosionEnRecepcion.Name = "ManejaExplosionEnRecepcion"
        Me.ManejaExplosionEnRecepcion.OptionsColumn.AllowEdit = False
        '
        'UnidadPeso
        '
        Me.UnidadPeso.Caption = "Unidad Peso"
        Me.UnidadPeso.FieldName = "WEIGHT_MEASUREMENT"
        Me.UnidadPeso.Name = "UnidadPeso"
        Me.UnidadPeso.OptionsColumn.AllowEdit = False
        '
        'Peso
        '
        Me.Peso.Caption = "Peso"
        Me.Peso.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Peso.FieldName = "WEIGTH"
        Me.Peso.Name = "Peso"
        Me.Peso.OptionsColumn.AllowEdit = False
        '
        'ControlDeCalidad
        '
        Me.ControlDeCalidad.Caption = "Área de Calidad"
        Me.ControlDeCalidad.FieldName = "QUALITY_CONTROL"
        Me.ControlDeCalidad.Name = "ControlDeCalidad"
        Me.ControlDeCalidad.Visible = True
        Me.ControlDeCalidad.VisibleIndex = 7
        Me.ControlDeCalidad.Width = 31
        '
        'UiColManejaSerieCorrelativa
        '
        Me.UiColManejaSerieCorrelativa.Caption = "Maneja Serie Correlativa"
        Me.UiColManejaSerieCorrelativa.FieldName = "HANDLE_CORRELATIVE_SERIALS"
        Me.UiColManejaSerieCorrelativa.Name = "UiColManejaSerieCorrelativa"
        '
        'UiColPrefixCorrelativeSerial
        '
        Me.UiColPrefixCorrelativeSerial.Caption = "Prefijo Serie Correlativa"
        Me.UiColPrefixCorrelativeSerial.FieldName = "PREFIX_CORRELATIVE_SERIALS"
        Me.UiColPrefixCorrelativeSerial.Name = "UiColPrefixCorrelativeSerial"
        Me.UiColPrefixCorrelativeSerial.OptionsColumn.AllowEdit = False
        Me.UiColPrefixCorrelativeSerial.OptionsColumn.ReadOnly = True
        '
        'UiColLeadTime
        '
        Me.UiColLeadTime.Caption = "Tiempo de espera(Días)"
        Me.UiColLeadTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UiColLeadTime.FieldName = "LEAD_TIME"
        Me.UiColLeadTime.MinWidth = 19
        Me.UiColLeadTime.Name = "UiColLeadTime"
        Me.UiColLeadTime.OptionsColumn.AllowEdit = False
        Me.UiColLeadTime.OptionsColumn.ReadOnly = True
        Me.UiColLeadTime.Visible = True
        Me.UiColLeadTime.VisibleIndex = 8
        Me.UiColLeadTime.Width = 39
        '
        'UiColExpirationTolerance
        '
        Me.UiColExpirationTolerance.Caption = "Tolerancia días de expiración en recepción"
        Me.UiColExpirationTolerance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UiColExpirationTolerance.FieldName = "EXPIRATION_TOLERANCE"
        Me.UiColExpirationTolerance.MinWidth = 19
        Me.UiColExpirationTolerance.Name = "UiColExpirationTolerance"
        Me.UiColExpirationTolerance.OptionsColumn.AllowEdit = False
        Me.UiColExpirationTolerance.OptionsColumn.ReadOnly = True
        Me.UiColExpirationTolerance.Visible = True
        Me.UiColExpirationTolerance.VisibleIndex = 9
        Me.UiColExpirationTolerance.Width = 39
        '
        'UiColSupplier
        '
        Me.UiColSupplier.Caption = "Proveedor"
        Me.UiColSupplier.FieldName = "SUPPLIER"
        Me.UiColSupplier.MinWidth = 19
        Me.UiColSupplier.Name = "UiColSupplier"
        Me.UiColSupplier.OptionsColumn.AllowEdit = False
        Me.UiColSupplier.OptionsColumn.ReadOnly = True
        Me.UiColSupplier.Visible = True
        Me.UiColSupplier.VisibleIndex = 10
        Me.UiColSupplier.Width = 30
        '
        'UiColNameSupplier
        '
        Me.UiColNameSupplier.Caption = "Nombre Proveedor"
        Me.UiColNameSupplier.FieldName = "NAME_SUPPLIER"
        Me.UiColNameSupplier.Name = "UiColNameSupplier"
        Me.UiColNameSupplier.Visible = True
        Me.UiColNameSupplier.VisibleIndex = 11
        Me.UiColNameSupplier.Width = 111
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.UiTabMateriales)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.XtraTabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(728, 389)
        Me.SplitContainer1.SplitterDistance = 391
        Me.SplitContainer1.TabIndex = 9
        '
        'UiTabMateriales
        '
        Me.UiTabMateriales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiTabMateriales.Location = New System.Drawing.Point(0, 23)
        Me.UiTabMateriales.Name = "UiTabMateriales"
        Me.UiTabMateriales.SelectedTabPage = Me.XtraTabPage1
        Me.UiTabMateriales.Size = New System.Drawing.Size(391, 366)
        Me.UiTabMateriales.TabIndex = 10
        Me.UiTabMateriales.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.UiTabUnidadMedida})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GridControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(389, 341)
        Me.XtraTabPage1.Text = "Lista de Materiales"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridControlVF)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.PageVisible = False
        Me.XtraTabPage2.Size = New System.Drawing.Size(389, 341)
        Me.XtraTabPage2.Text = "Actualizar Volumen"
        '
        'GridControlVF
        '
        Me.GridControlVF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlVF.Location = New System.Drawing.Point(0, 0)
        Me.GridControlVF.MainView = Me.GridViewFV
        Me.GridControlVF.Name = "GridControlVF"
        Me.GridControlVF.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemSpinEdit2, Me.RepositoryItemSpinEdit3})
        Me.GridControlVF.Size = New System.Drawing.Size(389, 341)
        Me.GridControlVF.TabIndex = 1
        Me.GridControlVF.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewFV})
        '
        'GridViewFV
        '
        Me.GridViewFV.Appearance.FixedLine.BackColor = System.Drawing.Color.Black
        Me.GridViewFV.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridViewFV.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodigo, Me.GridColumnDesc, Me.GridColumn3, Me.GridColumn2, Me.GridColumn1, Me.GridColumnFactor})
        Me.GridViewFV.GridControl = Me.GridControlVF
        Me.GridViewFV.LevelIndent = 0
        Me.GridViewFV.Name = "GridViewFV"
        Me.GridViewFV.OptionsLayout.StoreAllOptions = True
        Me.GridViewFV.OptionsLayout.StoreAppearance = True
        Me.GridViewFV.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridViewFV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridViewFV.OptionsView.ColumnAutoWidth = False
        Me.GridViewFV.OptionsView.ShowAutoFilterRow = True
        Me.GridViewFV.PreviewIndent = 0
        '
        'GridColumnCodigo
        '
        Me.GridColumnCodigo.Caption = "Código"
        Me.GridColumnCodigo.FieldName = "MATERIAL_ID"
        Me.GridColumnCodigo.Name = "GridColumnCodigo"
        Me.GridColumnCodigo.OptionsColumn.AllowEdit = False
        Me.GridColumnCodigo.OptionsColumn.AllowFocus = False
        Me.GridColumnCodigo.Visible = True
        Me.GridColumnCodigo.VisibleIndex = 0
        Me.GridColumnCodigo.Width = 99
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Descripcion"
        Me.GridColumnDesc.FieldName = "MATERIAL_NAME"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnDesc.OptionsColumn.AllowFocus = False
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 1
        Me.GridColumnDesc.Width = 300
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Alto"
        Me.GridColumn3.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn3.FieldName = "ALTO"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Largo"
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemSpinEdit2
        Me.GridColumn2.FieldName = "LARGO"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Ancho"
        Me.GridColumn1.ColumnEdit = Me.RepositoryItemSpinEdit3
        Me.GridColumn1.FieldName = "ANCHO"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'RepositoryItemSpinEdit3
        '
        Me.RepositoryItemSpinEdit3.AutoHeight = False
        Me.RepositoryItemSpinEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit3.Name = "RepositoryItemSpinEdit3"
        '
        'GridColumnFactor
        '
        Me.GridColumnFactor.AppearanceCell.BackColor = System.Drawing.Color.Silver
        Me.GridColumnFactor.AppearanceCell.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GridColumnFactor.AppearanceCell.Options.UseBackColor = True
        Me.GridColumnFactor.AppearanceCell.Options.UseBorderColor = True
        Me.GridColumnFactor.Caption = "Factor"
        Me.GridColumnFactor.FieldName = "VOLUME_FACTOR"
        Me.GridColumnFactor.Name = "GridColumnFactor"
        Me.GridColumnFactor.OptionsColumn.AllowEdit = False
        Me.GridColumnFactor.OptionsColumn.AllowFocus = False
        Me.GridColumnFactor.Visible = True
        Me.GridColumnFactor.VisibleIndex = 5
        '
        'UiTabUnidadMedida
        '
        Me.UiTabUnidadMedida.Controls.Add(Me.UiContenedorVistasUnidadMedida)
        Me.UiTabUnidadMedida.Name = "UiTabUnidadMedida"
        Me.UiTabUnidadMedida.Size = New System.Drawing.Size(389, 341)
        Me.UiTabUnidadMedida.Text = "Listado de Unidad de Medida"
        Me.UiTabUnidadMedida.Tooltip = "Listado de Empaques"
        '
        'UiContenedorVistasUnidadMedida
        '
        Me.UiContenedorVistasUnidadMedida.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiContenedorVistasUnidadMedida.Location = New System.Drawing.Point(0, 0)
        Me.UiContenedorVistasUnidadMedida.MainView = Me.UIVistaUnidadMedida
        Me.UiContenedorVistasUnidadMedida.Name = "UiContenedorVistasUnidadMedida"
        Me.UiContenedorVistasUnidadMedida.Size = New System.Drawing.Size(389, 341)
        Me.UiContenedorVistasUnidadMedida.TabIndex = 0
        Me.UiContenedorVistasUnidadMedida.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UIVistaUnidadMedida})
        '
        'UIVistaUnidadMedida
        '
        Me.UIVistaUnidadMedida.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colUnMEASUREMENT_UNIT_ID, Me.colUnCLIENT_ID, Me.colUnMATERIAL_ID, Me.colUnMEASUREMENT_UNIT, Me.colUnDESCRIPTION, Me.colUnQTY, Me.colUnBARCODE, Me.colUnALTERNATIVE_BARCODE})
        Me.UIVistaUnidadMedida.GridControl = Me.UiContenedorVistasUnidadMedida
        Me.UIVistaUnidadMedida.LevelIndent = 0
        Me.UIVistaUnidadMedida.Name = "UIVistaUnidadMedida"
        Me.UIVistaUnidadMedida.OptionsSelection.MultiSelect = True
        Me.UIVistaUnidadMedida.OptionsView.ShowAutoFilterRow = True
        Me.UIVistaUnidadMedida.PreviewIndent = 0
        '
        'colUnMEASUREMENT_UNIT_ID
        '
        Me.colUnMEASUREMENT_UNIT_ID.Caption = "Código"
        Me.colUnMEASUREMENT_UNIT_ID.FieldName = "MEASUREMENT_UNIT_ID"
        Me.colUnMEASUREMENT_UNIT_ID.Name = "colUnMEASUREMENT_UNIT_ID"
        Me.colUnMEASUREMENT_UNIT_ID.OptionsColumn.AllowEdit = False
        Me.colUnMEASUREMENT_UNIT_ID.Visible = True
        Me.colUnMEASUREMENT_UNIT_ID.VisibleIndex = 0
        '
        'colUnCLIENT_ID
        '
        Me.colUnCLIENT_ID.Caption = "Código Cliente"
        Me.colUnCLIENT_ID.FieldName = "CLIENT_ID"
        Me.colUnCLIENT_ID.Name = "colUnCLIENT_ID"
        Me.colUnCLIENT_ID.OptionsColumn.AllowEdit = False
        Me.colUnCLIENT_ID.Visible = True
        Me.colUnCLIENT_ID.VisibleIndex = 1
        '
        'colUnMATERIAL_ID
        '
        Me.colUnMATERIAL_ID.Caption = "Código Material"
        Me.colUnMATERIAL_ID.FieldName = "MATERIAL_ID"
        Me.colUnMATERIAL_ID.Name = "colUnMATERIAL_ID"
        Me.colUnMATERIAL_ID.OptionsColumn.AllowEdit = False
        Me.colUnMATERIAL_ID.Visible = True
        Me.colUnMATERIAL_ID.VisibleIndex = 2
        '
        'colUnMEASUREMENT_UNIT
        '
        Me.colUnMEASUREMENT_UNIT.Caption = "Unidad de Medida"
        Me.colUnMEASUREMENT_UNIT.FieldName = "MEASUREMENT_UNIT"
        Me.colUnMEASUREMENT_UNIT.Name = "colUnMEASUREMENT_UNIT"
        Me.colUnMEASUREMENT_UNIT.OptionsColumn.AllowEdit = False
        Me.colUnMEASUREMENT_UNIT.Visible = True
        Me.colUnMEASUREMENT_UNIT.VisibleIndex = 3
        '
        'colUnDESCRIPTION
        '
        Me.colUnDESCRIPTION.Caption = "Descripción"
        Me.colUnDESCRIPTION.FieldName = "DESCRIPTION"
        Me.colUnDESCRIPTION.Name = "colUnDESCRIPTION"
        Me.colUnDESCRIPTION.OptionsColumn.AllowEdit = False
        Me.colUnDESCRIPTION.Visible = True
        Me.colUnDESCRIPTION.VisibleIndex = 4
        '
        'colUnQTY
        '
        Me.colUnQTY.Caption = "Cantidad"
        Me.colUnQTY.FieldName = "QTY"
        Me.colUnQTY.Name = "colUnQTY"
        Me.colUnQTY.OptionsColumn.AllowEdit = False
        Me.colUnQTY.Visible = True
        Me.colUnQTY.VisibleIndex = 5
        '
        'colUnBARCODE
        '
        Me.colUnBARCODE.Caption = "Código de Barras"
        Me.colUnBARCODE.FieldName = "BARCODE"
        Me.colUnBARCODE.Name = "colUnBARCODE"
        Me.colUnBARCODE.OptionsColumn.AllowEdit = False
        Me.colUnBARCODE.Visible = True
        Me.colUnBARCODE.VisibleIndex = 6
        '
        'colUnALTERNATIVE_BARCODE
        '
        Me.colUnALTERNATIVE_BARCODE.Caption = "Código de Barras Alterno"
        Me.colUnALTERNATIVE_BARCODE.FieldName = "ALTERNATIVE_BARCODE"
        Me.colUnALTERNATIVE_BARCODE.Name = "colUnALTERNATIVE_BARCODE"
        Me.colUnALTERNATIVE_BARCODE.OptionsColumn.AllowEdit = False
        Me.colUnALTERNATIVE_BARCODE.Visible = True
        Me.colUnALTERNATIVE_BARCODE.VisibleIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(391, 23)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Catalogo: Productos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.UiTabDatosGenerales
        Me.XtraTabControl1.Size = New System.Drawing.Size(333, 389)
        Me.XtraTabControl1.TabIndex = 5
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.UiTabDatosGenerales, Me.UiTabUbicacion, Me.UiTabEmpaque, Me.UiTabMasterPack, Me.UiTabExcepcionesPorBodega})
        '
        'UiTabDatosGenerales
        '
        Me.UiTabDatosGenerales.Controls.Add(Me.UiPropiedadDeDatosGenerales)
        Me.UiTabDatosGenerales.Controls.Add(Me.BarDockControl11)
        Me.UiTabDatosGenerales.Controls.Add(Me.BarDockControl12)
        Me.UiTabDatosGenerales.Controls.Add(Me.BarDockControl10)
        Me.UiTabDatosGenerales.Controls.Add(Me.BarDockControl9)
        Me.UiTabDatosGenerales.Name = "UiTabDatosGenerales"
        Me.UiTabDatosGenerales.Size = New System.Drawing.Size(331, 364)
        Me.UiTabDatosGenerales.Text = "Datos Generales"
        '
        'UiPropiedadDeDatosGenerales
        '
        Me.UiPropiedadDeDatosGenerales.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.UiPropiedadDeDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiPropiedadDeDatosGenerales.Location = New System.Drawing.Point(0, 43)
        Me.UiPropiedadDeDatosGenerales.Name = "UiPropiedadDeDatosGenerales"
        Me.UiPropiedadDeDatosGenerales.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UiListaDeClientes, Me.UiListaClases, Me.UiListaSubClases, Me.UiCboPropiedadManejaCalibre, Me.UiCboPropiedadManejaTono})
        Me.UiPropiedadDeDatosGenerales.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.DatosDeAuditoria, Me.DatosGenerales, Me.Dimensiones})
        Me.UiPropiedadDeDatosGenerales.Size = New System.Drawing.Size(331, 321)
        Me.UiPropiedadDeDatosGenerales.TabIndex = 7
        '
        'UiListaDeClientes
        '
        Me.UiListaDeClientes.AutoHeight = False
        Me.UiListaDeClientes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaDeClientes.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLIENT_CODE", "Código"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLIENT_NAME", "Cliente")})
        Me.UiListaDeClientes.DisplayMember = "CLIENT_NAME"
        Me.UiListaDeClientes.Name = "UiListaDeClientes"
        Me.UiListaDeClientes.NullText = ""
        Me.UiListaDeClientes.ValueMember = "CLIENT_CODE"
        '
        'UiListaClases
        '
        Me.UiListaClases.AutoHeight = False
        Me.UiListaClases.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaClases.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_ID", "Código"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_NAME", "Nombre"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CLASS_DESCRIPTION", "Descripción")})
        Me.UiListaClases.DisplayMember = "CLASS_DESCRIPTION"
        Me.UiListaClases.Name = "UiListaClases"
        Me.UiListaClases.NullText = ""
        Me.UiListaClases.ValueMember = "CLASS_ID"
        '
        'UiListaSubClases
        '
        Me.UiListaSubClases.AutoHeight = False
        Me.UiListaSubClases.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiListaSubClases.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SUB_CLASS_ID", "Código"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SUB_CLASS_NAME", "Nombre"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SUB_CLASS_NAME", "Descripción")})
        Me.UiListaSubClases.DisplayMember = "SUB_CLASS_NAME"
        Me.UiListaSubClases.Name = "UiListaSubClases"
        Me.UiListaSubClases.NullText = ""
        Me.UiListaSubClases.ValueMember = "SUB_CLASS_ID"
        '
        'UiCboPropiedadManejaCalibre
        '
        Me.UiCboPropiedadManejaCalibre.AutoHeight = False
        Me.UiCboPropiedadManejaCalibre.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiCboPropiedadManejaCalibre.Items.AddRange(New Object() {"SI", "NO"})
        Me.UiCboPropiedadManejaCalibre.Name = "UiCboPropiedadManejaCalibre"
        '
        'UiCboPropiedadManejaTono
        '
        Me.UiCboPropiedadManejaTono.AutoHeight = False
        Me.UiCboPropiedadManejaTono.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiCboPropiedadManejaTono.DropDownRows = 2
        Me.UiCboPropiedadManejaTono.Items.AddRange(New Object() {"SI", "NO"})
        Me.UiCboPropiedadManejaTono.Name = "UiCboPropiedadManejaTono"
        '
        'DatosDeAuditoria
        '
        Me.DatosDeAuditoria.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.PropiedadDeDatosGenerales_ActualizadoEl, Me.PropiedadDeDatosGenerales_ActualizadoPor})
        Me.DatosDeAuditoria.Expanded = False
        Me.DatosDeAuditoria.Height = 17
        Me.DatosDeAuditoria.Name = "DatosDeAuditoria"
        Me.DatosDeAuditoria.Properties.Caption = "Datos de Auditoria"
        '
        'PropiedadDeDatosGenerales_ActualizadoEl
        '
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Expanded = False
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Name = "PropiedadDeDatosGenerales_ActualizadoEl"
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.Caption = "Actualizado el"
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.FieldName = "Actualizado_el"
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.Format.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.Format.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.ReadOnly = True
        Me.PropiedadDeDatosGenerales_ActualizadoEl.Properties.ToolTip = "Ultima Actualización"
        '
        'PropiedadDeDatosGenerales_ActualizadoPor
        '
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Height = 15
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Name = "PropiedadDeDatosGenerales_ActualizadoPor"
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Properties.Caption = "Actualizado por"
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Properties.FieldName = "Actualizado_por"
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Properties.ReadOnly = True
        Me.PropiedadDeDatosGenerales_ActualizadoPor.Properties.ToolTip = "Ultimo usuario que actualizó"
        '
        'DatosGenerales
        '
        Me.DatosGenerales.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin, Me.PropiedadDeDatosGenerales_Clase, Me.PropiedadDeDatosGenerales_SubClase, Me.PropiedadDeDatosGenerales_Cliente, Me.PropiedadDeDatosGenerales_Codigo, Me.PropiedadDeDatosGenerales_CodigoBarras, Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno, Me.PropiedadDeDatosGenerales_Descripcion, Me.PropiedadDeDatosGenerales_DescripcionCorta, Me.PropiedadDeDatosGenerales_EsCarro, Me.PropiedadDeDatosGenerales_ManejaLote, Me.PropiedadDeDatosGenerales_ManejaSerie, Me.PropiedadDeDatosGenerales_ManejaMasterPack, Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion, Me.PropiedadDeDatosGenerales_UnidadPeso, Me.PropiedadDeDatosGenerales_ManejaTono, Me.PropiedadDeDatosGenerales_ManejaCalibre, Me.PropiedadDeDatosGenerales_UsaLineaPicking, Me.PropiedadDeDatosGenerales_QUALITY_CONTROL, Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS, Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS, Me.PropiedadDeDatosGenerales_LEAD_TIME, Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE, Me.PropiedadDeDatosGenerales_Proveedor, Me.PropiedadDEDatosGenerales_NombreProveedor})
        Me.DatosGenerales.Height = 17
        Me.DatosGenerales.Name = "DatosGenerales"
        Me.DatosGenerales.Properties.Caption = "Datos Generales"
        '
        'PropiedadDeDatosGenerales_CantidadMaxPorBinbin
        '
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.Name = "PropiedadDeDatosGenerales_CantidadMaxPorBinbin"
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.Properties.Caption = "Cantidad Max por Bin"
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.Properties.FieldName = "CantidadMaxPorBin"
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_CantidadMaxPorBinbin.Properties.ToolTip = "Cantidad Máxima por BIN"
        '
        'PropiedadDeDatosGenerales_Clase
        '
        Me.PropiedadDeDatosGenerales_Clase.Height = 19
        Me.PropiedadDeDatosGenerales_Clase.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_Clase.Name = "PropiedadDeDatosGenerales_Clase"
        Me.PropiedadDeDatosGenerales_Clase.Properties.Caption = "Clase"
        Me.PropiedadDeDatosGenerales_Clase.Properties.FieldName = "Clase"
        Me.PropiedadDeDatosGenerales_Clase.Properties.RowEdit = Me.UiListaClases
        Me.PropiedadDeDatosGenerales_Clase.Properties.ToolTip = "Clasificación del producto"
        '
        'PropiedadDeDatosGenerales_SubClase
        '
        Me.PropiedadDeDatosGenerales_SubClase.Height = 19
        Me.PropiedadDeDatosGenerales_SubClase.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_SubClase.Name = "PropiedadDeDatosGenerales_SubClase"
        Me.PropiedadDeDatosGenerales_SubClase.Properties.Caption = "Sub Clase"
        Me.PropiedadDeDatosGenerales_SubClase.Properties.FieldName = "SubClase"
        Me.PropiedadDeDatosGenerales_SubClase.Properties.RowEdit = Me.UiListaSubClases
        Me.PropiedadDeDatosGenerales_SubClase.Properties.ToolTip = "Sub-Clasificación del producto"
        '
        'PropiedadDeDatosGenerales_Cliente
        '
        Me.PropiedadDeDatosGenerales_Cliente.Name = "PropiedadDeDatosGenerales_Cliente"
        Me.PropiedadDeDatosGenerales_Cliente.Properties.Caption = "Cliente"
        Me.PropiedadDeDatosGenerales_Cliente.Properties.FieldName = "Cliente"
        Me.PropiedadDeDatosGenerales_Cliente.Properties.RowEdit = Me.UiListaDeClientes
        Me.PropiedadDeDatosGenerales_Cliente.Properties.ToolTip = "Cliente al que pertenece el producto"
        '
        'PropiedadDeDatosGenerales_Codigo
        '
        Me.PropiedadDeDatosGenerales_Codigo.Height = 16
        Me.PropiedadDeDatosGenerales_Codigo.Name = "PropiedadDeDatosGenerales_Codigo"
        Me.PropiedadDeDatosGenerales_Codigo.Properties.Caption = "Código"
        Me.PropiedadDeDatosGenerales_Codigo.Properties.FieldName = "Codigo"
        Me.PropiedadDeDatosGenerales_Codigo.Properties.ToolTip = "Código de producto"
        '
        'PropiedadDeDatosGenerales_CodigoBarras
        '
        Me.PropiedadDeDatosGenerales_CodigoBarras.Name = "PropiedadDeDatosGenerales_CodigoBarras"
        Me.PropiedadDeDatosGenerales_CodigoBarras.Properties.Caption = "CódigoBarras"
        Me.PropiedadDeDatosGenerales_CodigoBarras.Properties.FieldName = "CodigoBarras"
        Me.PropiedadDeDatosGenerales_CodigoBarras.Properties.ToolTip = "Código de barras para el producto"
        '
        'PropiedadDeDatosGenerales_CodigoBarrasAlterno
        '
        Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno.Name = "PropiedadDeDatosGenerales_CodigoBarrasAlterno"
        Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno.Properties.Caption = "Código Barras Alterno"
        Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno.Properties.FieldName = "CodigoBarrasAlterno"
        Me.PropiedadDeDatosGenerales_CodigoBarrasAlterno.Properties.ToolTip = "Código de barras alterno para el producto"
        '
        'PropiedadDeDatosGenerales_Descripcion
        '
        Me.PropiedadDeDatosGenerales_Descripcion.Name = "PropiedadDeDatosGenerales_Descripcion"
        Me.PropiedadDeDatosGenerales_Descripcion.Properties.Caption = "Descripción"
        Me.PropiedadDeDatosGenerales_Descripcion.Properties.FieldName = "Descripcion"
        Me.PropiedadDeDatosGenerales_Descripcion.Properties.ToolTip = "Descripción del producto (Max. 200 caracteres)"
        '
        'PropiedadDeDatosGenerales_DescripcionCorta
        '
        Me.PropiedadDeDatosGenerales_DescripcionCorta.Name = "PropiedadDeDatosGenerales_DescripcionCorta"
        Me.PropiedadDeDatosGenerales_DescripcionCorta.Properties.Caption = "Descripción Corta"
        Me.PropiedadDeDatosGenerales_DescripcionCorta.Properties.FieldName = "DescripcionCorta"
        Me.PropiedadDeDatosGenerales_DescripcionCorta.Properties.ToolTip = "Descripción corta del producto (Max. 25 caracteres)"
        '
        'PropiedadDeDatosGenerales_EsCarro
        '
        Me.PropiedadDeDatosGenerales_EsCarro.Name = "PropiedadDeDatosGenerales_EsCarro"
        Me.PropiedadDeDatosGenerales_EsCarro.Properties.Caption = "Es Carro"
        Me.PropiedadDeDatosGenerales_EsCarro.Properties.FieldName = "EsCarro"
        Me.PropiedadDeDatosGenerales_EsCarro.Properties.ToolTip = "El producto es carro?"
        '
        'PropiedadDeDatosGenerales_ManejaLote
        '
        Me.PropiedadDeDatosGenerales_ManejaLote.Name = "PropiedadDeDatosGenerales_ManejaLote"
        Me.PropiedadDeDatosGenerales_ManejaLote.Properties.Caption = "Maneja Lote"
        Me.PropiedadDeDatosGenerales_ManejaLote.Properties.FieldName = "ManejaLote"
        Me.PropiedadDeDatosGenerales_ManejaLote.Properties.ToolTip = "El número de lote es requerido ?"
        '
        'PropiedadDeDatosGenerales_ManejaSerie
        '
        Me.PropiedadDeDatosGenerales_ManejaSerie.Name = "PropiedadDeDatosGenerales_ManejaSerie"
        Me.PropiedadDeDatosGenerales_ManejaSerie.Properties.Caption = "Maneja Serie"
        Me.PropiedadDeDatosGenerales_ManejaSerie.Properties.FieldName = "ManejaSerie"
        Me.PropiedadDeDatosGenerales_ManejaSerie.Properties.ToolTip = "El número de Serie es requerido ?"
        '
        'PropiedadDeDatosGenerales_ManejaMasterPack
        '
        Me.PropiedadDeDatosGenerales_ManejaMasterPack.Name = "PropiedadDeDatosGenerales_ManejaMasterPack"
        Me.PropiedadDeDatosGenerales_ManejaMasterPack.Properties.Caption = "Maneja Master Pack"
        Me.PropiedadDeDatosGenerales_ManejaMasterPack.Properties.FieldName = "ManejaMasterPack"
        Me.PropiedadDeDatosGenerales_ManejaMasterPack.Properties.ToolTip = "Maneja Master Pack?"
        '
        'PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion
        '
        Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion.Name = "PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion"
        Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion.Properties.Caption = "Maneja Explosión en Recepción"
        Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion.Properties.FieldName = "ManejaExplosionEnRecepcion"
        Me.PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion.Properties.ToolTip = "Explota en recepción?"
        '
        'PropiedadDeDatosGenerales_UnidadPeso
        '
        Me.PropiedadDeDatosGenerales_UnidadPeso.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_UnidadPeso.Name = "PropiedadDeDatosGenerales_UnidadPeso"
        Me.PropiedadDeDatosGenerales_UnidadPeso.Properties.Caption = "Unidad Peso"
        Me.PropiedadDeDatosGenerales_UnidadPeso.Properties.FieldName = "UnidadPeso"
        Me.PropiedadDeDatosGenerales_UnidadPeso.Properties.ToolTip = "Unidad de peso"
        '
        'PropiedadDeDatosGenerales_ManejaTono
        '
        Me.PropiedadDeDatosGenerales_ManejaTono.Height = 22
        Me.PropiedadDeDatosGenerales_ManejaTono.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_ManejaTono.Name = "PropiedadDeDatosGenerales_ManejaTono"
        Me.PropiedadDeDatosGenerales_ManejaTono.Properties.Caption = "Maneja Tono"
        Me.PropiedadDeDatosGenerales_ManejaTono.Properties.FieldName = "ManejaTono"
        Me.PropiedadDeDatosGenerales_ManejaTono.Properties.ToolTip = "¿Maneja Tono?"
        '
        'PropiedadDeDatosGenerales_ManejaCalibre
        '
        Me.PropiedadDeDatosGenerales_ManejaCalibre.Height = 22
        Me.PropiedadDeDatosGenerales_ManejaCalibre.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_ManejaCalibre.Name = "PropiedadDeDatosGenerales_ManejaCalibre"
        Me.PropiedadDeDatosGenerales_ManejaCalibre.Properties.Caption = "Maneja Calibre"
        Me.PropiedadDeDatosGenerales_ManejaCalibre.Properties.FieldName = "ManejaCalibre"
        Me.PropiedadDeDatosGenerales_ManejaCalibre.Properties.ToolTip = "¿Maneja Calibre?"
        '
        'PropiedadDeDatosGenerales_UsaLineaPicking
        '
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.Height = 21
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.Name = "PropiedadDeDatosGenerales_UsaLineaPicking"
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.Properties.Caption = "Usa Linea de Picking"
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.Properties.FieldName = "UsaLineaDePicking"
        Me.PropiedadDeDatosGenerales_UsaLineaPicking.Properties.ToolTip = "¿Usa línea de picking?"
        '
        'PropiedadDeDatosGenerales_QUALITY_CONTROL
        '
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL.Name = "PropiedadDeDatosGenerales_QUALITY_CONTROL"
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL.Properties.Caption = "Área de Calidad"
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL.Properties.FieldName = "UsaControlDeCalidad"
        Me.PropiedadDeDatosGenerales_QUALITY_CONTROL.Properties.ToolTip = "Indica si el producto debe de pasar por el área de calidad en la recepción"
        '
        'PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS
        '
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Height = 21
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Name = "PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS"
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Properties.Caption = "Prefijo Series Correlativas"
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Properties.CustomizationCaption = "Prefijo Series Correlativas"
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Properties.FieldName = "PrefijoSerieCorrelativa"
        Me.PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS.Properties.ToolTip = "Prefijo de Serie Correlativa"
        '
        'PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS
        '
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Height = 21
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Name = "PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS"
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Properties.Caption = "Maneja Serie Correlativa? (SI / NO)"
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Properties.CustomizationCaption = "Maneja Serie Correlativa? (SI / NO)"
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Properties.FieldName = "ManejaSerieCorrelativa"
        Me.PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS.Properties.ToolTip = "El producto maneja series correlativas?"
        '
        'PropiedadDeDatosGenerales_LEAD_TIME
        '
        Me.PropiedadDeDatosGenerales_LEAD_TIME.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Name = "PropiedadDeDatosGenerales_LEAD_TIME"
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Properties.Caption = "Tiempo de espera(Días)"
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Properties.CustomizationCaption = "Tiempo de espera(Días)"
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Properties.FieldName = "TiempoDeEspera"
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Properties.ReadOnly = False
        Me.PropiedadDeDatosGenerales_LEAD_TIME.Properties.ToolTip = "Tiempo de espera(Días)"
        '
        'PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE
        '
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Name = "PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE"
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Properties.Caption = "Tolerancia días de expiración en recepción"
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Properties.CustomizationCaption = "Tolerancia días de expiración en recepción"
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Properties.FieldName = "ToleranciaDeExpiracion"
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Properties.ReadOnly = False
        Me.PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE.Properties.ToolTip = "Tolerancia días de expiración en recepción"
        '
        'PropiedadDeDatosGenerales_Proveedor
        '
        Me.PropiedadDeDatosGenerales_Proveedor.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_Proveedor.Name = "PropiedadDeDatosGenerales_Proveedor"
        Me.PropiedadDeDatosGenerales_Proveedor.Properties.Caption = "Proveedor"
        Me.PropiedadDeDatosGenerales_Proveedor.Properties.CustomizationCaption = "Proveedor"
        Me.PropiedadDeDatosGenerales_Proveedor.Properties.FieldName = "Proveedor"
        Me.PropiedadDeDatosGenerales_Proveedor.Properties.ReadOnly = False
        Me.PropiedadDeDatosGenerales_Proveedor.Properties.ToolTip = "Proveedor"
        '
        'PropiedadDEDatosGenerales_NombreProveedor
        '
        Me.PropiedadDEDatosGenerales_NombreProveedor.Name = "PropiedadDEDatosGenerales_NombreProveedor"
        Me.PropiedadDEDatosGenerales_NombreProveedor.Properties.Caption = "Nombre Proveedor"
        Me.PropiedadDEDatosGenerales_NombreProveedor.Properties.CustomizationCaption = "Nombre Proveedor"
        Me.PropiedadDEDatosGenerales_NombreProveedor.Properties.FieldName = "NombreProveedor"
        Me.PropiedadDEDatosGenerales_NombreProveedor.Properties.ToolTip = "Nombre Proveedor"
        '
        'Dimensiones
        '
        Me.Dimensiones.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.PropiedadDeDatosGenerales_Alto, Me.PropiedadDeDatosGenerales_Ancho, Me.PropiedadDeDatosGenerales_FactorVolumen, Me.PropiedadDeDatosGenerales_Largo, Me.PropiedadDeDatosGenerales_Peso})
        Me.Dimensiones.Name = "Dimensiones"
        Me.Dimensiones.Properties.Caption = "Dimensiones"
        '
        'PropiedadDeDatosGenerales_Alto
        '
        Me.PropiedadDeDatosGenerales_Alto.Name = "PropiedadDeDatosGenerales_Alto"
        Me.PropiedadDeDatosGenerales_Alto.Properties.Caption = "Alto"
        Me.PropiedadDeDatosGenerales_Alto.Properties.FieldName = "Alto"
        Me.PropiedadDeDatosGenerales_Alto.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_Alto.Properties.ToolTip = "Alto"
        '
        'PropiedadDeDatosGenerales_Ancho
        '
        Me.PropiedadDeDatosGenerales_Ancho.Name = "PropiedadDeDatosGenerales_Ancho"
        Me.PropiedadDeDatosGenerales_Ancho.Properties.Caption = "Ancho"
        Me.PropiedadDeDatosGenerales_Ancho.Properties.FieldName = "Ancho"
        Me.PropiedadDeDatosGenerales_Ancho.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_Ancho.Properties.ToolTip = "Ancho"
        '
        'PropiedadDeDatosGenerales_FactorVolumen
        '
        Me.PropiedadDeDatosGenerales_FactorVolumen.Name = "PropiedadDeDatosGenerales_FactorVolumen"
        Me.PropiedadDeDatosGenerales_FactorVolumen.Properties.Caption = "Factor Volumen"
        Me.PropiedadDeDatosGenerales_FactorVolumen.Properties.FieldName = "FactorVolumen"
        Me.PropiedadDeDatosGenerales_FactorVolumen.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_FactorVolumen.Properties.ToolTip = "Factor del volumen"
        '
        'PropiedadDeDatosGenerales_Largo
        '
        Me.PropiedadDeDatosGenerales_Largo.Expanded = False
        Me.PropiedadDeDatosGenerales_Largo.Name = "PropiedadDeDatosGenerales_Largo"
        Me.PropiedadDeDatosGenerales_Largo.Properties.Caption = "Largo"
        Me.PropiedadDeDatosGenerales_Largo.Properties.FieldName = "Largo"
        Me.PropiedadDeDatosGenerales_Largo.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_Largo.Properties.ToolTip = "Largo"
        '
        'PropiedadDeDatosGenerales_Peso
        '
        Me.PropiedadDeDatosGenerales_Peso.IsChildRowsLoaded = True
        Me.PropiedadDeDatosGenerales_Peso.Name = "PropiedadDeDatosGenerales_Peso"
        Me.PropiedadDeDatosGenerales_Peso.Properties.Caption = "Peso"
        Me.PropiedadDeDatosGenerales_Peso.Properties.FieldName = "Peso"
        Me.PropiedadDeDatosGenerales_Peso.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PropiedadDeDatosGenerales_Peso.Properties.ToolTip = "Peso"
        '
        'BarDockControl11
        '
        Me.BarDockControl11.CausesValidation = False
        Me.BarDockControl11.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl11.Location = New System.Drawing.Point(0, 43)
        Me.BarDockControl11.Manager = Me.BarManager2
        Me.BarDockControl11.Size = New System.Drawing.Size(0, 321)
        '
        'BarManager2
        '
        Me.BarManager2.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarDatosGenerales})
        Me.BarManager2.DockControls.Add(Me.BarDockControl9)
        Me.BarManager2.DockControls.Add(Me.BarDockControl10)
        Me.BarManager2.DockControls.Add(Me.BarDockControl11)
        Me.BarManager2.DockControls.Add(Me.BarDockControl12)
        Me.BarManager2.Form = Me.UiTabDatosGenerales
        Me.BarManager2.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonNuevo, Me.UiBotonGuardar, Me.UiBotonEliminar, Me.BarStaticItem1, Me.UiBotonImprimir, Me.UiBotonExportarExcel, Me.UiBotonDescargarPlantillaEnDatosGenerales, Me.UiBotonCargarPlantillaEnDatosGenerales})
        Me.BarManager2.MaxItemId = 8
        '
        'UiBarDatosGenerales
        '
        Me.UiBarDatosGenerales.BarName = "Tools"
        Me.UiBarDatosGenerales.DockCol = 0
        Me.UiBarDatosGenerales.DockRow = 0
        Me.UiBarDatosGenerales.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarDatosGenerales.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonNuevo), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonGuardar), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonImprimir), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonExportarExcel, DevExpress.XtraBars.BarItemPaintStyle.Standard), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonDescargarPlantillaEnDatosGenerales), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, Me.UiBotonCargarPlantillaEnDatosGenerales, "Cargar Plantilla")})
        Me.UiBarDatosGenerales.OptionsBar.AllowQuickCustomization = False
        Me.UiBarDatosGenerales.OptionsBar.AllowRename = True
        Me.UiBarDatosGenerales.OptionsBar.DisableClose = True
        Me.UiBarDatosGenerales.OptionsBar.DrawDragBorder = False
        Me.UiBarDatosGenerales.OptionsBar.UseWholeRow = True
        Me.UiBarDatosGenerales.Text = "Tools"
        '
        'UiBotonNuevo
        '
        Me.UiBotonNuevo.Caption = "Nuevo"
        Me.UiBotonNuevo.Id = 0
        Me.UiBotonNuevo.ImageOptions.ImageUri.Uri = "New"
        Me.UiBotonNuevo.Name = "UiBotonNuevo"
        '
        'UiBotonGuardar
        '
        Me.UiBotonGuardar.Caption = "Guardar"
        Me.UiBotonGuardar.Id = 1
        Me.UiBotonGuardar.ImageOptions.ImageUri.Uri = "Save"
        Me.UiBotonGuardar.Name = "UiBotonGuardar"
        '
        'UiBotonEliminar
        '
        Me.UiBotonEliminar.Caption = "Eliminar"
        Me.UiBotonEliminar.Id = 2
        Me.UiBotonEliminar.ImageOptions.ImageUri.Uri = "Delete"
        Me.UiBotonEliminar.Name = "UiBotonEliminar"
        '
        'UiBotonImprimir
        '
        Me.UiBotonImprimir.Caption = "Imprimir"
        Me.UiBotonImprimir.Id = 4
        Me.UiBotonImprimir.ImageOptions.ImageUri.Uri = "Print"
        Me.UiBotonImprimir.Name = "UiBotonImprimir"
        '
        'UiBotonExportarExcel
        '
        Me.UiBotonExportarExcel.Caption = "Exportar a Excel"
        Me.UiBotonExportarExcel.Id = 5
        Me.UiBotonExportarExcel.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.icons8_export_excel_35
        Me.UiBotonExportarExcel.Name = "UiBotonExportarExcel"
        '
        'UiBotonDescargarPlantillaEnDatosGenerales
        '
        Me.UiBotonDescargarPlantillaEnDatosGenerales.Caption = "Descargar Plantilla"
        Me.UiBotonDescargarPlantillaEnDatosGenerales.Id = 6
        Me.UiBotonDescargarPlantillaEnDatosGenerales.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.icons8_descargar_escritorio_35
        Me.UiBotonDescargarPlantillaEnDatosGenerales.Name = "UiBotonDescargarPlantillaEnDatosGenerales"
        '
        'UiBotonCargarPlantillaEnDatosGenerales
        '
        Me.UiBotonCargarPlantillaEnDatosGenerales.Caption = "Cargar Plantilla"
        Me.UiBotonCargarPlantillaEnDatosGenerales.Id = 7
        Me.UiBotonCargarPlantillaEnDatosGenerales.ImageOptions.Image = Global.WMSOnePlan_Client.My.Resources.Resources.icons8_cargar_documento_de_enlace_35
        Me.UiBotonCargarPlantillaEnDatosGenerales.Name = "UiBotonCargarPlantillaEnDatosGenerales"
        '
        'BarDockControl9
        '
        Me.BarDockControl9.CausesValidation = False
        Me.BarDockControl9.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl9.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl9.Manager = Me.BarManager2
        Me.BarDockControl9.Size = New System.Drawing.Size(331, 43)
        '
        'BarDockControl10
        '
        Me.BarDockControl10.CausesValidation = False
        Me.BarDockControl10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl10.Location = New System.Drawing.Point(0, 364)
        Me.BarDockControl10.Manager = Me.BarManager2
        Me.BarDockControl10.Size = New System.Drawing.Size(331, 0)
        '
        'BarDockControl12
        '
        Me.BarDockControl12.CausesValidation = False
        Me.BarDockControl12.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl12.Location = New System.Drawing.Point(331, 43)
        Me.BarDockControl12.Manager = Me.BarManager2
        Me.BarDockControl12.Size = New System.Drawing.Size(0, 321)
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "|"
        Me.BarStaticItem1.Id = 3
        Me.BarStaticItem1.Name = "BarStaticItem1"
        '
        'UiTabUbicacion
        '
        Me.UiTabUbicacion.Controls.Add(Me.GridControl2)
        Me.UiTabUbicacion.Controls.Add(Me.BarDockControl15)
        Me.UiTabUbicacion.Controls.Add(Me.BarDockControl16)
        Me.UiTabUbicacion.Controls.Add(Me.BarDockControl14)
        Me.UiTabUbicacion.Controls.Add(Me.BarDockControl13)
        Me.UiTabUbicacion.Name = "UiTabUbicacion"
        Me.UiTabUbicacion.Size = New System.Drawing.Size(331, 364)
        Me.UiTabUbicacion.Text = "Ubicación"
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 20)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtMinQty, Me.txtMaxQty})
        Me.GridControl2.Size = New System.Drawing.Size(331, 344)
        Me.GridControl2.TabIndex = 21
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn_Min, Me.GridColumn_Max})
        Me.GridView2.FixedLineWidth = 1
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.GroupCount = 1
        Me.GridView2.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView2.LevelIndent = 0
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsNavigation.EnterMoveNextColumn = True
        Me.GridView2.OptionsSelection.MultiSelect = True
        Me.GridView2.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.PreviewIndent = 0
        Me.GridView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView2.ViewCaption = "Ubicaciones"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Bodega"
        Me.GridColumn4.FieldName = "WAREHOUSE_PARENT"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.Width = 50
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Ubicación"
        Me.GridColumn5.FieldName = "LOCATION_SPOT"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn5.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 100
        '
        'GridColumn_Min
        '
        Me.GridColumn_Min.Caption = "Inv.Min"
        Me.GridColumn_Min.ColumnEdit = Me.txtMinQty
        Me.GridColumn_Min.FieldName = "MIN_QUANTITY"
        Me.GridColumn_Min.Name = "GridColumn_Min"
        Me.GridColumn_Min.Visible = True
        Me.GridColumn_Min.VisibleIndex = 1
        '
        'txtMinQty
        '
        Me.txtMinQty.AutoHeight = False
        Me.txtMinQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMinQty.Name = "txtMinQty"
        Me.txtMinQty.NullText = "0"
        '
        'GridColumn_Max
        '
        Me.GridColumn_Max.Caption = "Inv.Max"
        Me.GridColumn_Max.ColumnEdit = Me.txtMaxQty
        Me.GridColumn_Max.FieldName = "MAX_QUANTITY"
        Me.GridColumn_Max.Name = "GridColumn_Max"
        Me.GridColumn_Max.Visible = True
        Me.GridColumn_Max.VisibleIndex = 2
        '
        'txtMaxQty
        '
        Me.txtMaxQty.AutoHeight = False
        Me.txtMaxQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtMaxQty.Name = "txtMaxQty"
        Me.txtMaxQty.NullText = "0"
        '
        'BarDockControl15
        '
        Me.BarDockControl15.CausesValidation = False
        Me.BarDockControl15.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl15.Location = New System.Drawing.Point(0, 20)
        Me.BarDockControl15.Manager = Me.BarManager3
        Me.BarDockControl15.Size = New System.Drawing.Size(0, 344)
        '
        'BarManager3
        '
        Me.BarManager3.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarUbicacion})
        Me.BarManager3.DockControls.Add(Me.BarDockControl13)
        Me.BarManager3.DockControls.Add(Me.BarDockControl14)
        Me.BarManager3.DockControls.Add(Me.BarDockControl15)
        Me.BarManager3.DockControls.Add(Me.BarDockControl16)
        Me.BarManager3.Form = Me.UiTabUbicacion
        Me.BarManager3.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonNuevaUbicacion, Me.UiBotonEliminarUbicacion, Me.UiBotonGrabarUbicacion, Me.UiBotonDescargarPlantillaEnUbicacion, Me.UiBotonCargarPlantillaEnUbicacion})
        Me.BarManager3.MainMenu = Me.UiBarUbicacion
        Me.BarManager3.MaxItemId = 5
        '
        'UiBarUbicacion
        '
        Me.UiBarUbicacion.BarName = "Main menu"
        Me.UiBarUbicacion.DockCol = 0
        Me.UiBarUbicacion.DockRow = 0
        Me.UiBarUbicacion.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarUbicacion.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonNuevaUbicacion), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonEliminarUbicacion), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonGrabarUbicacion), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonDescargarPlantillaEnUbicacion), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonCargarPlantillaEnUbicacion)})
        Me.UiBarUbicacion.OptionsBar.AllowQuickCustomization = False
        Me.UiBarUbicacion.OptionsBar.AllowRename = True
        Me.UiBarUbicacion.OptionsBar.DisableClose = True
        Me.UiBarUbicacion.OptionsBar.DrawDragBorder = False
        Me.UiBarUbicacion.OptionsBar.UseWholeRow = True
        Me.UiBarUbicacion.Text = "Main menu"
        '
        'UiBotonNuevaUbicacion
        '
        Me.UiBotonNuevaUbicacion.Caption = "Nuevo"
        Me.UiBotonNuevaUbicacion.Id = 0
        Me.UiBotonNuevaUbicacion.Name = "UiBotonNuevaUbicacion"
        '
        'UiBotonEliminarUbicacion
        '
        Me.UiBotonEliminarUbicacion.Caption = "Eliminar"
        Me.UiBotonEliminarUbicacion.Id = 1
        Me.UiBotonEliminarUbicacion.Name = "UiBotonEliminarUbicacion"
        '
        'UiBotonGrabarUbicacion
        '
        Me.UiBotonGrabarUbicacion.Caption = "Actualizar Minimos y Maximos"
        Me.UiBotonGrabarUbicacion.Id = 2
        Me.UiBotonGrabarUbicacion.Name = "UiBotonGrabarUbicacion"
        '
        'UiBotonDescargarPlantillaEnUbicacion
        '
        Me.UiBotonDescargarPlantillaEnUbicacion.Caption = "Descargar Plantilla"
        Me.UiBotonDescargarPlantillaEnUbicacion.Id = 3
        Me.UiBotonDescargarPlantillaEnUbicacion.Name = "UiBotonDescargarPlantillaEnUbicacion"
        '
        'UiBotonCargarPlantillaEnUbicacion
        '
        Me.UiBotonCargarPlantillaEnUbicacion.Caption = "Cargar Plantilla"
        Me.UiBotonCargarPlantillaEnUbicacion.Id = 4
        Me.UiBotonCargarPlantillaEnUbicacion.Name = "UiBotonCargarPlantillaEnUbicacion"
        '
        'BarDockControl13
        '
        Me.BarDockControl13.CausesValidation = False
        Me.BarDockControl13.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl13.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl13.Manager = Me.BarManager3
        Me.BarDockControl13.Size = New System.Drawing.Size(331, 20)
        '
        'BarDockControl14
        '
        Me.BarDockControl14.CausesValidation = False
        Me.BarDockControl14.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl14.Location = New System.Drawing.Point(0, 364)
        Me.BarDockControl14.Manager = Me.BarManager3
        Me.BarDockControl14.Size = New System.Drawing.Size(331, 0)
        '
        'BarDockControl16
        '
        Me.BarDockControl16.CausesValidation = False
        Me.BarDockControl16.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl16.Location = New System.Drawing.Point(331, 20)
        Me.BarDockControl16.Manager = Me.BarManager3
        Me.BarDockControl16.Size = New System.Drawing.Size(0, 344)
        '
        'UiTabEmpaque
        '
        Me.UiTabEmpaque.Controls.Add(Me.UiPropiedadDeEmpaque)
        Me.UiTabEmpaque.Controls.Add(Me.barDockControlLeft)
        Me.UiTabEmpaque.Controls.Add(Me.barDockControlRight)
        Me.UiTabEmpaque.Controls.Add(Me.barDockControlBottom)
        Me.UiTabEmpaque.Controls.Add(Me.barDockControlTop)
        Me.UiTabEmpaque.Name = "UiTabEmpaque"
        Me.UiTabEmpaque.Size = New System.Drawing.Size(331, 364)
        Me.UiTabEmpaque.Text = "Unidad de Medida"
        '
        'UiPropiedadDeEmpaque
        '
        Me.UiPropiedadDeEmpaque.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.UiPropiedadDeEmpaque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiPropiedadDeEmpaque.Location = New System.Drawing.Point(0, 40)
        Me.UiPropiedadDeEmpaque.Name = "UiPropiedadDeEmpaque"
        Me.UiPropiedadDeEmpaque.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UiStoragePackaging})
        Me.UiPropiedadDeEmpaque.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.MaterialCategoria, Me.EmpaqueCategoria})
        Me.UiPropiedadDeEmpaque.Size = New System.Drawing.Size(331, 324)
        Me.UiPropiedadDeEmpaque.TabIndex = 5
        '
        'UiStoragePackaging
        '
        Me.UiStoragePackaging.AutoHeight = False
        Me.UiStoragePackaging.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiStoragePackaging.DisplayMember = "TEXT_VALUE"
        Me.UiStoragePackaging.Name = "UiStoragePackaging"
        Me.UiStoragePackaging.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.UiStoragePackaging.ValueMember = "PARAM_NAME"
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Unidad de medida"
        Me.GridColumn6.FieldName = "PARAM_NAME"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Descripción"
        Me.GridColumn7.FieldName = "TEXT_VALUE"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        '
        'MaterialCategoria
        '
        Me.MaterialCategoria.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.codigoDeClientePropiedad, Me.codigoDeMaterialPropiedad})
        Me.MaterialCategoria.Height = 17
        Me.MaterialCategoria.Name = "MaterialCategoria"
        Me.MaterialCategoria.Properties.Caption = "Material"
        '
        'codigoDeClientePropiedad
        '
        Me.codigoDeClientePropiedad.IsChildRowsLoaded = True
        Me.codigoDeClientePropiedad.Name = "codigoDeClientePropiedad"
        Me.codigoDeClientePropiedad.Properties.Caption = "Código de Cliente"
        Me.codigoDeClientePropiedad.Properties.FieldName = "codigoDeCliente"
        Me.codigoDeClientePropiedad.Properties.ReadOnly = True
        Me.codigoDeClientePropiedad.Properties.ToolTip = "Código de cliente"
        '
        'codigoDeMaterialPropiedad
        '
        Me.codigoDeMaterialPropiedad.IsChildRowsLoaded = True
        Me.codigoDeMaterialPropiedad.Name = "codigoDeMaterialPropiedad"
        Me.codigoDeMaterialPropiedad.Properties.Caption = "Código de Material"
        Me.codigoDeMaterialPropiedad.Properties.FieldName = "codigoDeMaterial"
        Me.codigoDeMaterialPropiedad.Properties.ReadOnly = True
        Me.codigoDeMaterialPropiedad.Properties.ToolTip = "Código de Material"
        '
        'EmpaqueCategoria
        '
        Me.EmpaqueCategoria.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.empaquePropiedad, Me.cantidadPropiedad, Me.codigoPropiedad, Me.codigoDeBarrasPropiedad, Me.codigoDeBarrasAlternativoPropiedad})
        Me.EmpaqueCategoria.Height = 17
        Me.EmpaqueCategoria.Name = "EmpaqueCategoria"
        Me.EmpaqueCategoria.Properties.Caption = "Unidad de Medida"
        '
        'empaquePropiedad
        '
        Me.empaquePropiedad.Name = "empaquePropiedad"
        Me.empaquePropiedad.Properties.Caption = "Unidad de Medida"
        Me.empaquePropiedad.Properties.FieldName = "empaque"
        Me.empaquePropiedad.Properties.RowEdit = Me.UiStoragePackaging
        Me.empaquePropiedad.Properties.ToolTip = "Unidad de Medida"
        '
        'cantidadPropiedad
        '
        Me.cantidadPropiedad.IsChildRowsLoaded = True
        Me.cantidadPropiedad.Name = "cantidadPropiedad"
        Me.cantidadPropiedad.Properties.Caption = "Cantidad"
        Me.cantidadPropiedad.Properties.FieldName = "cantidad"
        Me.cantidadPropiedad.Properties.Format.FormatString = "#,###,##0"
        Me.cantidadPropiedad.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.cantidadPropiedad.Properties.ToolTip = "Cantidad"
        '
        'codigoPropiedad
        '
        Me.codigoPropiedad.IsChildRowsLoaded = True
        Me.codigoPropiedad.Name = "codigoPropiedad"
        Me.codigoPropiedad.Properties.Caption = "Código"
        Me.codigoPropiedad.Properties.FieldName = "codigo"
        Me.codigoPropiedad.Properties.ReadOnly = True
        Me.codigoPropiedad.Properties.ToolTip = "Código"
        '
        'codigoDeBarrasPropiedad
        '
        Me.codigoDeBarrasPropiedad.IsChildRowsLoaded = True
        Me.codigoDeBarrasPropiedad.Name = "codigoDeBarrasPropiedad"
        Me.codigoDeBarrasPropiedad.Properties.Caption = "Código de Barras"
        Me.codigoDeBarrasPropiedad.Properties.FieldName = "codigoDeBarras"
        Me.codigoDeBarrasPropiedad.Properties.ToolTip = "Código de Barras"
        '
        'codigoDeBarrasAlternativoPropiedad
        '
        Me.codigoDeBarrasAlternativoPropiedad.IsChildRowsLoaded = True
        Me.codigoDeBarrasAlternativoPropiedad.Name = "codigoDeBarrasAlternativoPropiedad"
        Me.codigoDeBarrasAlternativoPropiedad.Properties.Caption = "Código de Barras alternativo"
        Me.codigoDeBarrasAlternativoPropiedad.Properties.FieldName = "codigoDeBarrasAlternativo"
        Me.codigoDeBarrasAlternativoPropiedad.Properties.ToolTip = "Código de Barras alternativo"
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 40)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 324)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarUnidadDeMedida})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonAgregarEmpaque, Me.UiBotonGuardarEmpaque, Me.UiBotonElimnarEmpaque, Me.UiBotonImprimirEmpaque, Me.UiBotonExportarEmpaquesExcel, Me.BarButtonItem1, Me.BarButtonItem2, Me.UiBotonDescargarPlantillaEnUnidadDeMedida, Me.UiBotonCargarPlantillaEnUnidadDeMedida})
        Me.BarManager1.MaxItemId = 11
        Me.BarManager1.PopupShowMode = DevExpress.XtraBars.PopupShowMode.Classic
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLineSpacing1})
        '
        'UiBarUnidadDeMedida
        '
        Me.UiBarUnidadDeMedida.BarName = "Tools"
        Me.UiBarUnidadDeMedida.DockCol = 0
        Me.UiBarUnidadDeMedida.DockRow = 0
        Me.UiBarUnidadDeMedida.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarUnidadDeMedida.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonAgregarEmpaque), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonGuardarEmpaque), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonElimnarEmpaque), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonImprimirEmpaque), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonExportarEmpaquesExcel), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonDescargarPlantillaEnUnidadDeMedida), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonCargarPlantillaEnUnidadDeMedida)})
        Me.UiBarUnidadDeMedida.OptionsBar.AllowQuickCustomization = False
        Me.UiBarUnidadDeMedida.OptionsBar.AllowRename = True
        Me.UiBarUnidadDeMedida.OptionsBar.DisableClose = True
        Me.UiBarUnidadDeMedida.OptionsBar.DrawDragBorder = False
        Me.UiBarUnidadDeMedida.OptionsBar.UseWholeRow = True
        Me.UiBarUnidadDeMedida.Text = "Tools"
        '
        'UiBotonAgregarEmpaque
        '
        Me.UiBotonAgregarEmpaque.Caption = "Agregar Empaque"
        Me.UiBotonAgregarEmpaque.Id = 1
        Me.UiBotonAgregarEmpaque.ImageOptions.ImageUri.Uri = "New"
        Me.UiBotonAgregarEmpaque.Name = "UiBotonAgregarEmpaque"
        '
        'UiBotonGuardarEmpaque
        '
        Me.UiBotonGuardarEmpaque.Caption = "Guardar Empaque"
        Me.UiBotonGuardarEmpaque.Id = 2
        Me.UiBotonGuardarEmpaque.ImageOptions.ImageUri.Uri = "Save"
        Me.UiBotonGuardarEmpaque.Name = "UiBotonGuardarEmpaque"
        '
        'UiBotonElimnarEmpaque
        '
        Me.UiBotonElimnarEmpaque.Caption = "Eliminar Empaque"
        Me.UiBotonElimnarEmpaque.Id = 3
        Me.UiBotonElimnarEmpaque.ImageOptions.ImageUri.Uri = "Delete"
        Me.UiBotonElimnarEmpaque.Name = "UiBotonElimnarEmpaque"
        '
        'UiBotonImprimirEmpaque
        '
        Me.UiBotonImprimirEmpaque.Caption = "Imprimir"
        Me.UiBotonImprimirEmpaque.Id = 5
        Me.UiBotonImprimirEmpaque.ImageOptions.ImageUri.Uri = "Print"
        Me.UiBotonImprimirEmpaque.Name = "UiBotonImprimirEmpaque"
        '
        'UiBotonExportarEmpaquesExcel
        '
        Me.UiBotonExportarEmpaquesExcel.Caption = "Exportar a Excel"
        Me.UiBotonExportarEmpaquesExcel.Id = 6
        Me.UiBotonExportarEmpaquesExcel.ImageOptions.ImageUri.Uri = "ExportToXLS"
        Me.UiBotonExportarEmpaquesExcel.Name = "UiBotonExportarEmpaquesExcel"
        '
        'UiBotonDescargarPlantillaEnUnidadDeMedida
        '
        Me.UiBotonDescargarPlantillaEnUnidadDeMedida.Caption = "Descargar Plantilla"
        Me.UiBotonDescargarPlantillaEnUnidadDeMedida.Id = 9
        Me.UiBotonDescargarPlantillaEnUnidadDeMedida.Name = "UiBotonDescargarPlantillaEnUnidadDeMedida"
        '
        'UiBotonCargarPlantillaEnUnidadDeMedida
        '
        Me.UiBotonCargarPlantillaEnUnidadDeMedida.Caption = "Cargar Plantilla Excel"
        Me.UiBotonCargarPlantillaEnUnidadDeMedida.Id = 10
        Me.UiBotonCargarPlantillaEnUnidadDeMedida.Name = "UiBotonCargarPlantillaEnUnidadDeMedida"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(331, 40)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 364)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(331, 0)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(331, 40)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 324)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 7
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 8
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'RepositoryItemLineSpacing1
        '
        Me.RepositoryItemLineSpacing1.AutoHeight = False
        Me.RepositoryItemLineSpacing1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLineSpacing1.Name = "RepositoryItemLineSpacing1"
        '
        'UiTabMasterPack
        '
        Me.UiTabMasterPack.Controls.Add(Me.UiContenedorDeVistasComponentes)
        Me.UiTabMasterPack.Controls.Add(Me.Panel1)
        Me.UiTabMasterPack.Controls.Add(Me.BarDockControl3)
        Me.UiTabMasterPack.Controls.Add(Me.BarDockControl4)
        Me.UiTabMasterPack.Controls.Add(Me.BarDockControl2)
        Me.UiTabMasterPack.Controls.Add(Me.BarDockControl1)
        Me.UiTabMasterPack.Name = "UiTabMasterPack"
        Me.UiTabMasterPack.PageVisible = False
        Me.UiTabMasterPack.Size = New System.Drawing.Size(331, 364)
        Me.UiTabMasterPack.Text = "Master Pack"
        Me.UiTabMasterPack.Tooltip = "Master Pack"
        '
        'UiContenedorDeVistasComponentes
        '
        Me.UiContenedorDeVistasComponentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiContenedorDeVistasComponentes.Location = New System.Drawing.Point(0, 126)
        Me.UiContenedorDeVistasComponentes.MainView = Me.UiVistaComponentesAsociados
        Me.UiContenedorDeVistasComponentes.MenuManager = Me.BarManager1
        Me.UiContenedorDeVistasComponentes.Name = "UiContenedorDeVistasComponentes"
        Me.UiContenedorDeVistasComponentes.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UiBotonEliminarComponente})
        Me.UiContenedorDeVistasComponentes.Size = New System.Drawing.Size(331, 238)
        Me.UiContenedorDeVistasComponentes.TabIndex = 20
        Me.UiContenedorDeVistasComponentes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiVistaComponentesAsociados})
        '
        'UiVistaComponentesAsociados
        '
        Me.UiVistaComponentesAsociados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEnEliminar, Me.colComponenteAsociadoCodigo, Me.colComponenteAsociadoMaterial, Me.colComponenteAsociadoDescripcionMaterial, Me.colComponenteAsociadoCodigoBarra, Me.colComponenteAsociadoCantidad, Me.colComponenteAsociadoEsMasterPack})
        Me.UiVistaComponentesAsociados.GridControl = Me.UiContenedorDeVistasComponentes
        Me.UiVistaComponentesAsociados.LevelIndent = 0
        Me.UiVistaComponentesAsociados.Name = "UiVistaComponentesAsociados"
        Me.UiVistaComponentesAsociados.OptionsView.ShowAutoFilterRow = True
        Me.UiVistaComponentesAsociados.PreviewIndent = 0
        '
        'colEnEliminar
        '
        Me.colEnEliminar.Caption = "Eliminar"
        Me.colEnEliminar.ColumnEdit = Me.UiBotonEliminarComponente
        Me.colEnEliminar.Name = "colEnEliminar"
        Me.colEnEliminar.Visible = True
        Me.colEnEliminar.VisibleIndex = 0
        Me.colEnEliminar.Width = 50
        '
        'UiBotonEliminarComponente
        '
        Me.UiBotonEliminarComponente.AutoHeight = False
        Me.UiBotonEliminarComponente.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.UiBotonEliminarComponente.Name = "UiBotonEliminarComponente"
        Me.UiBotonEliminarComponente.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'colComponenteAsociadoCodigo
        '
        Me.colComponenteAsociadoCodigo.Caption = "Código"
        Me.colComponenteAsociadoCodigo.ColumnEdit = Me.UiBotonEliminarComponente
        Me.colComponenteAsociadoCodigo.FieldName = "MASTER_PACK_COMPONENT_ID"
        Me.colComponenteAsociadoCodigo.Name = "colComponenteAsociadoCodigo"
        Me.colComponenteAsociadoCodigo.OptionsColumn.AllowEdit = False
        '
        'colComponenteAsociadoMaterial
        '
        Me.colComponenteAsociadoMaterial.Caption = "Código Material"
        Me.colComponenteAsociadoMaterial.FieldName = "COMPONENT_MATERIAL"
        Me.colComponenteAsociadoMaterial.Name = "colComponenteAsociadoMaterial"
        Me.colComponenteAsociadoMaterial.OptionsColumn.AllowEdit = False
        Me.colComponenteAsociadoMaterial.Visible = True
        Me.colComponenteAsociadoMaterial.VisibleIndex = 1
        Me.colComponenteAsociadoMaterial.Width = 102
        '
        'colComponenteAsociadoDescripcionMaterial
        '
        Me.colComponenteAsociadoDescripcionMaterial.Caption = "Descripción Material"
        Me.colComponenteAsociadoDescripcionMaterial.FieldName = "COMPONENT_NAME"
        Me.colComponenteAsociadoDescripcionMaterial.Name = "colComponenteAsociadoDescripcionMaterial"
        Me.colComponenteAsociadoDescripcionMaterial.OptionsColumn.AllowEdit = False
        Me.colComponenteAsociadoDescripcionMaterial.Visible = True
        Me.colComponenteAsociadoDescripcionMaterial.VisibleIndex = 2
        Me.colComponenteAsociadoDescripcionMaterial.Width = 102
        '
        'colComponenteAsociadoCodigoBarra
        '
        Me.colComponenteAsociadoCodigoBarra.Caption = "Código Barra"
        Me.colComponenteAsociadoCodigoBarra.FieldName = "COMPONENT_BARCODE"
        Me.colComponenteAsociadoCodigoBarra.Name = "colComponenteAsociadoCodigoBarra"
        Me.colComponenteAsociadoCodigoBarra.OptionsColumn.AllowEdit = False
        '
        'colComponenteAsociadoCantidad
        '
        Me.colComponenteAsociadoCantidad.Caption = "Cantidad"
        Me.colComponenteAsociadoCantidad.FieldName = "QTY"
        Me.colComponenteAsociadoCantidad.Name = "colComponenteAsociadoCantidad"
        Me.colComponenteAsociadoCantidad.OptionsColumn.AllowEdit = False
        Me.colComponenteAsociadoCantidad.Visible = True
        Me.colComponenteAsociadoCantidad.VisibleIndex = 3
        Me.colComponenteAsociadoCantidad.Width = 107
        '
        'colComponenteAsociadoEsMasterPack
        '
        Me.colComponenteAsociadoEsMasterPack.Caption = "Es Master Pack"
        Me.colComponenteAsociadoEsMasterPack.FieldName = "IS_MASTER_PACK"
        Me.colComponenteAsociadoEsMasterPack.Name = "colComponenteAsociadoEsMasterPack"
        Me.colComponenteAsociadoEsMasterPack.Visible = True
        Me.colComponenteAsociadoEsMasterPack.VisibleIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel2)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 106)
        Me.Panel1.TabIndex = 25
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.UiEtiquetaComponenteCantidad)
        Me.FlowLayoutPanel2.Controls.Add(Me.UiSpinComponenteCantidad)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 52)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(12, 13, 12, 13)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(331, 52)
        Me.FlowLayoutPanel2.TabIndex = 1
        '
        'UiEtiquetaComponenteCantidad
        '
        Me.UiEtiquetaComponenteCantidad.Location = New System.Drawing.Point(15, 16)
        Me.UiEtiquetaComponenteCantidad.Name = "UiEtiquetaComponenteCantidad"
        Me.UiEtiquetaComponenteCantidad.Size = New System.Drawing.Size(47, 13)
        Me.UiEtiquetaComponenteCantidad.TabIndex = 18
        Me.UiEtiquetaComponenteCantidad.Text = "Cantidad:"
        '
        'UiSpinComponenteCantidad
        '
        Me.UiSpinComponenteCantidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiSpinComponenteCantidad.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.UiSpinComponenteCantidad.Location = New System.Drawing.Point(20, 32)
        Me.UiSpinComponenteCantidad.Margin = New System.Windows.Forms.Padding(8, 0, 3, 3)
        Me.UiSpinComponenteCantidad.MenuManager = Me.BarManager1
        Me.UiSpinComponenteCantidad.Name = "UiSpinComponenteCantidad"
        Me.UiSpinComponenteCantidad.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiSpinComponenteCantidad.Size = New System.Drawing.Size(268, 20)
        Me.UiSpinComponenteCantidad.TabIndex = 19
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.UiEtiquetaComponenteMaterial)
        Me.FlowLayoutPanel1.Controls.Add(Me.UiListaComponenteMaterial)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(12, 13, 12, 13)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(331, 52)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'UiEtiquetaComponenteMaterial
        '
        Me.UiEtiquetaComponenteMaterial.Location = New System.Drawing.Point(15, 16)
        Me.UiEtiquetaComponenteMaterial.Name = "UiEtiquetaComponenteMaterial"
        Me.UiEtiquetaComponenteMaterial.Size = New System.Drawing.Size(42, 13)
        Me.UiEtiquetaComponenteMaterial.TabIndex = 15
        Me.UiEtiquetaComponenteMaterial.Text = "Material:"
        '
        'UiListaComponenteMaterial
        '
        Me.UiListaComponenteMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiListaComponenteMaterial.Location = New System.Drawing.Point(24, 32)
        Me.UiListaComponenteMaterial.Margin = New System.Windows.Forms.Padding(12, 0, 3, 3)
        Me.UiListaComponenteMaterial.MenuManager = Me.BarManager1
        Me.UiListaComponenteMaterial.Name = "UiListaComponenteMaterial"
        Me.UiListaComponenteMaterial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Refrescar", -1, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", "UiComponenteRefrescar", Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.UiListaComponenteMaterial.Properties.PopupView = Me.UiListaVistaComponenteMaterial
        Me.UiListaComponenteMaterial.Properties.ValueMember = "MATERIAL_ID"
        Me.UiListaComponenteMaterial.Size = New System.Drawing.Size(268, 22)
        Me.UiListaComponenteMaterial.TabIndex = 14
        '
        'UiListaVistaComponenteMaterial
        '
        Me.UiListaVistaComponenteMaterial.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colComponenteDisponibleCodigoMaterial, Me.colComponenteDisponbileDescripcionMaterial, Me.colComponenteDisponibleCodigoBarra, Me.colComponenteDisponbileEsMasterPack})
        Me.UiListaVistaComponenteMaterial.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaComponenteMaterial.Name = "UiListaVistaComponenteMaterial"
        Me.UiListaVistaComponenteMaterial.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.UiListaVistaComponenteMaterial.OptionsSelection.MultiSelect = True
        Me.UiListaVistaComponenteMaterial.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.UiListaVistaComponenteMaterial.OptionsView.ShowGroupPanel = False
        '
        'colComponenteDisponibleCodigoMaterial
        '
        Me.colComponenteDisponibleCodigoMaterial.Caption = "Código Material"
        Me.colComponenteDisponibleCodigoMaterial.FieldName = "MATERIAL_ID"
        Me.colComponenteDisponibleCodigoMaterial.Name = "colComponenteDisponibleCodigoMaterial"
        Me.colComponenteDisponibleCodigoMaterial.Visible = True
        Me.colComponenteDisponibleCodigoMaterial.VisibleIndex = 1
        '
        'colComponenteDisponbileDescripcionMaterial
        '
        Me.colComponenteDisponbileDescripcionMaterial.Caption = "Descripción Material"
        Me.colComponenteDisponbileDescripcionMaterial.FieldName = "MATERIAL_NAME"
        Me.colComponenteDisponbileDescripcionMaterial.Name = "colComponenteDisponbileDescripcionMaterial"
        Me.colComponenteDisponbileDescripcionMaterial.Visible = True
        Me.colComponenteDisponbileDescripcionMaterial.VisibleIndex = 2
        '
        'colComponenteDisponibleCodigoBarra
        '
        Me.colComponenteDisponibleCodigoBarra.Caption = "Código Barra"
        Me.colComponenteDisponibleCodigoBarra.FieldName = "BARCODE_ID"
        Me.colComponenteDisponibleCodigoBarra.Name = "colComponenteDisponibleCodigoBarra"
        '
        'colComponenteDisponbileEsMasterPack
        '
        Me.colComponenteDisponbileEsMasterPack.Caption = "Es Master Pack"
        Me.colComponenteDisponbileEsMasterPack.FieldName = "IS_MASTER_PACK"
        Me.colComponenteDisponbileEsMasterPack.Name = "colComponenteDisponbileEsMasterPack"
        Me.colComponenteDisponbileEsMasterPack.OptionsColumn.AllowEdit = False
        Me.colComponenteDisponbileEsMasterPack.Visible = True
        Me.colComponenteDisponbileEsMasterPack.VisibleIndex = 3
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 20)
        Me.BarDockControl3.Manager = Me.UiBarraMangMaterPack
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 344)
        '
        'UiBarraMangMaterPack
        '
        Me.UiBarraMangMaterPack.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarraPrincipalMasterPack})
        Me.UiBarraMangMaterPack.DockControls.Add(Me.BarDockControl1)
        Me.UiBarraMangMaterPack.DockControls.Add(Me.BarDockControl2)
        Me.UiBarraMangMaterPack.DockControls.Add(Me.BarDockControl3)
        Me.UiBarraMangMaterPack.DockControls.Add(Me.BarDockControl4)
        Me.UiBarraMangMaterPack.Form = Me.UiTabMasterPack
        Me.UiBarraMangMaterPack.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonAgregarCompononente, Me.UiBotonDescargarPlantillaEnMasterPack, Me.UiBotonCargarPlantillaEnMasterPack})
        Me.UiBarraMangMaterPack.MaxItemId = 3
        '
        'UiBarraPrincipalMasterPack
        '
        Me.UiBarraPrincipalMasterPack.BarName = "Tools"
        Me.UiBarraPrincipalMasterPack.DockCol = 0
        Me.UiBarraPrincipalMasterPack.DockRow = 0
        Me.UiBarraPrincipalMasterPack.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarraPrincipalMasterPack.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonAgregarCompononente, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonDescargarPlantillaEnMasterPack), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonCargarPlantillaEnMasterPack)})
        Me.UiBarraPrincipalMasterPack.OptionsBar.AllowQuickCustomization = False
        Me.UiBarraPrincipalMasterPack.OptionsBar.DrawDragBorder = False
        Me.UiBarraPrincipalMasterPack.OptionsBar.UseWholeRow = True
        Me.UiBarraPrincipalMasterPack.Text = "Tools"
        '
        'UiBotonAgregarCompononente
        '
        Me.UiBotonAgregarCompononente.Caption = "Agregar"
        Me.UiBotonAgregarCompononente.Id = 0
        Me.UiBotonAgregarCompononente.Name = "UiBotonAgregarCompononente"
        '
        'UiBotonDescargarPlantillaEnMasterPack
        '
        Me.UiBotonDescargarPlantillaEnMasterPack.Caption = "Descargar Plantilla"
        Me.UiBotonDescargarPlantillaEnMasterPack.Id = 1
        Me.UiBotonDescargarPlantillaEnMasterPack.Name = "UiBotonDescargarPlantillaEnMasterPack"
        '
        'UiBotonCargarPlantillaEnMasterPack
        '
        Me.UiBotonCargarPlantillaEnMasterPack.Caption = "Cargar Plantilla"
        Me.UiBotonCargarPlantillaEnMasterPack.Id = 2
        Me.UiBotonCargarPlantillaEnMasterPack.Name = "UiBotonCargarPlantillaEnMasterPack"
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Manager = Me.UiBarraMangMaterPack
        Me.BarDockControl1.Size = New System.Drawing.Size(331, 20)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 364)
        Me.BarDockControl2.Manager = Me.UiBarraMangMaterPack
        Me.BarDockControl2.Size = New System.Drawing.Size(331, 0)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(331, 20)
        Me.BarDockControl4.Manager = Me.UiBarraMangMaterPack
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 344)
        '
        'UiTabExcepcionesPorBodega
        '
        Me.UiTabExcepcionesPorBodega.Controls.Add(Me.UiContenedorExcepcionesPorBodega)
        Me.UiTabExcepcionesPorBodega.Controls.Add(Me.BarDockControl7)
        Me.UiTabExcepcionesPorBodega.Controls.Add(Me.BarDockControl8)
        Me.UiTabExcepcionesPorBodega.Controls.Add(Me.BarDockControl6)
        Me.UiTabExcepcionesPorBodega.Controls.Add(Me.BarDockControl5)
        Me.UiTabExcepcionesPorBodega.Name = "UiTabExcepcionesPorBodega"
        Me.UiTabExcepcionesPorBodega.Size = New System.Drawing.Size(331, 364)
        Me.UiTabExcepcionesPorBodega.Text = "Excepciones por Bodega"
        '
        'UiContenedorExcepcionesPorBodega
        '
        Me.UiContenedorExcepcionesPorBodega.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiContenedorExcepcionesPorBodega.Location = New System.Drawing.Point(0, 40)
        Me.UiContenedorExcepcionesPorBodega.MainView = Me.UiVistaExcepcionPorBodega
        Me.UiContenedorExcepcionesPorBodega.MenuManager = Me.BarManager1
        Me.UiContenedorExcepcionesPorBodega.Name = "UiContenedorExcepcionesPorBodega"
        Me.UiContenedorExcepcionesPorBodega.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UiComboBodega, Me.UiComboPropiedad, Me.UiComboValor})
        Me.UiContenedorExcepcionesPorBodega.Size = New System.Drawing.Size(331, 324)
        Me.UiContenedorExcepcionesPorBodega.TabIndex = 14
        Me.UiContenedorExcepcionesPorBodega.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiVistaExcepcionPorBodega})
        '
        'UiVistaExcepcionPorBodega
        '
        Me.UiVistaExcepcionPorBodega.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColBodega, Me.UiColPropiedad, Me.UiColValor, Me.UiColModifico, Me.UiColMaterialPropiedad})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.Goldenrod
        FormatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        FormatConditionRuleExpression1.Appearance.Options.UseBackColor = True
        FormatConditionRuleExpression1.Appearance.Options.UseForeColor = True
        FormatConditionRuleExpression1.Expression = "[MODIFIED] = 0"
        FormatConditionRuleExpression1.PredefinedName = "Yellow Fill, Yellow Text"
        GridFormatRule1.Rule = FormatConditionRuleExpression1
        Me.UiVistaExcepcionPorBodega.FormatRules.Add(GridFormatRule1)
        Me.UiVistaExcepcionPorBodega.GridControl = Me.UiContenedorExcepcionesPorBodega
        Me.UiVistaExcepcionPorBodega.LevelIndent = 0
        Me.UiVistaExcepcionPorBodega.Name = "UiVistaExcepcionPorBodega"
        Me.UiVistaExcepcionPorBodega.OptionsNavigation.AutoFocusNewRow = True
        Me.UiVistaExcepcionPorBodega.OptionsSelection.MultiSelect = True
        Me.UiVistaExcepcionPorBodega.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.UiVistaExcepcionPorBodega.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.[True]
        Me.UiVistaExcepcionPorBodega.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.UiVistaExcepcionPorBodega.OptionsView.ShowAutoFilterRow = True
        Me.UiVistaExcepcionPorBodega.OptionsView.ShowFooter = True
        Me.UiVistaExcepcionPorBodega.PreviewIndent = 0
        '
        'UiColBodega
        '
        Me.UiColBodega.Caption = "Bodega"
        Me.UiColBodega.ColumnEdit = Me.UiComboBodega
        Me.UiColBodega.FieldName = "WAREHOUSE_ID"
        Me.UiColBodega.Name = "UiColBodega"
        Me.UiColBodega.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.UiColBodega.Visible = True
        Me.UiColBodega.VisibleIndex = 1
        '
        'UiComboBodega
        '
        Me.UiComboBodega.AutoHeight = False
        Me.UiComboBodega.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiComboBodega.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("WAREHOUSE_ID", "Código de Bodega"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Bodega")})
        Me.UiComboBodega.DisplayMember = "NAME"
        Me.UiComboBodega.Name = "UiComboBodega"
        Me.UiComboBodega.NullText = "Seleccione Bodega"
        Me.UiComboBodega.ValueMember = "WAREHOUSE_ID"
        '
        'UiColPropiedad
        '
        Me.UiColPropiedad.Caption = "Propiedad"
        Me.UiColPropiedad.ColumnEdit = Me.UiComboPropiedad
        Me.UiColPropiedad.FieldName = "MATERIAL_PROPERTY_ID"
        Me.UiColPropiedad.Name = "UiColPropiedad"
        Me.UiColPropiedad.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.UiColPropiedad.Visible = True
        Me.UiColPropiedad.VisibleIndex = 2
        '
        'UiComboPropiedad
        '
        Me.UiComboPropiedad.AutoHeight = False
        Me.UiComboPropiedad.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiComboPropiedad.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("MATERIAL_PROPERTY_ID", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Nombre", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DATA_TYPE", "Tipo de Dato", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "Propiedad")})
        Me.UiComboPropiedad.DisplayMember = "DESCRIPTION"
        Me.UiComboPropiedad.Name = "UiComboPropiedad"
        Me.UiComboPropiedad.NullText = "Seleccione Propiedad"
        Me.UiComboPropiedad.ValueMember = "MATERIAL_PROPERTY_ID"
        '
        'UiColValor
        '
        Me.UiColValor.Caption = "Valor"
        Me.UiColValor.ColumnEdit = Me.UiComboValor
        Me.UiColValor.FieldName = "VALUE"
        Me.UiColValor.Name = "UiColValor"
        Me.UiColValor.Visible = True
        Me.UiColValor.VisibleIndex = 3
        '
        'UiComboValor
        '
        Me.UiComboValor.AutoHeight = False
        Me.UiComboValor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.UiComboValor.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Valor")})
        Me.UiComboValor.DisplayMember = "Text"
        Me.UiComboValor.Name = "UiComboValor"
        Me.UiComboValor.NullText = "Selecione Valor"
        Me.UiComboValor.ValueMember = "Value"
        '
        'UiColModifico
        '
        Me.UiColModifico.Caption = "Modificado"
        Me.UiColModifico.FieldName = "MODIFIED"
        Me.UiColModifico.Name = "UiColModifico"
        '
        'UiColMaterialPropiedad
        '
        Me.UiColMaterialPropiedad.Caption = "Material"
        Me.UiColMaterialPropiedad.FieldName = "MATERIAL_ID"
        Me.UiColMaterialPropiedad.Name = "UiColMaterialPropiedad"
        Me.UiColMaterialPropiedad.OptionsColumn.ShowInCustomizationForm = False
        '
        'BarDockControl7
        '
        Me.BarDockControl7.CausesValidation = False
        Me.BarDockControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl7.Location = New System.Drawing.Point(0, 40)
        Me.BarDockControl7.Manager = Me.BarManager4
        Me.BarDockControl7.Size = New System.Drawing.Size(0, 324)
        '
        'BarManager4
        '
        Me.BarManager4.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarExcepcionesPorBodega})
        Me.BarManager4.DockControls.Add(Me.BarDockControl5)
        Me.BarManager4.DockControls.Add(Me.BarDockControl6)
        Me.BarManager4.DockControls.Add(Me.BarDockControl7)
        Me.BarManager4.DockControls.Add(Me.BarDockControl8)
        Me.BarManager4.Form = Me.UiTabExcepcionesPorBodega
        Me.BarManager4.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem3, Me.UiBotonNuevaExcepcionPorBodega, Me.UiBotonGuardarExcepcionPorBodega, Me.UiBotonElimnarExcepcionPorBodega, Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla, Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla})
        Me.BarManager4.MainMenu = Me.UiBarExcepcionesPorBodega
        Me.BarManager4.MaxItemId = 7
        '
        'UiBarExcepcionesPorBodega
        '
        Me.UiBarExcepcionesPorBodega.BarName = "Main menu"
        Me.UiBarExcepcionesPorBodega.DockCol = 0
        Me.UiBarExcepcionesPorBodega.DockRow = 0
        Me.UiBarExcepcionesPorBodega.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarExcepcionesPorBodega.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonNuevaExcepcionPorBodega), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonGuardarExcepcionPorBodega), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonElimnarExcepcionPorBodega), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla), New DevExpress.XtraBars.LinkPersistInfo(Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla)})
        Me.UiBarExcepcionesPorBodega.OptionsBar.DisableClose = True
        Me.UiBarExcepcionesPorBodega.OptionsBar.DrawBorder = False
        Me.UiBarExcepcionesPorBodega.OptionsBar.DrawDragBorder = False
        Me.UiBarExcepcionesPorBodega.OptionsBar.UseWholeRow = True
        Me.UiBarExcepcionesPorBodega.Text = "Main menu"
        '
        'UiBotonNuevaExcepcionPorBodega
        '
        Me.UiBotonNuevaExcepcionPorBodega.Caption = "Nuevo"
        Me.UiBotonNuevaExcepcionPorBodega.Id = 1
        Me.UiBotonNuevaExcepcionPorBodega.ImageOptions.ImageUri.Uri = "New"
        Me.UiBotonNuevaExcepcionPorBodega.Name = "UiBotonNuevaExcepcionPorBodega"
        '
        'UiBotonGuardarExcepcionPorBodega
        '
        Me.UiBotonGuardarExcepcionPorBodega.Caption = "Guardar"
        Me.UiBotonGuardarExcepcionPorBodega.Id = 2
        Me.UiBotonGuardarExcepcionPorBodega.ImageOptions.ImageUri.Uri = "Save"
        Me.UiBotonGuardarExcepcionPorBodega.Name = "UiBotonGuardarExcepcionPorBodega"
        '
        'UiBotonElimnarExcepcionPorBodega
        '
        Me.UiBotonElimnarExcepcionPorBodega.Caption = "Eliminar"
        Me.UiBotonElimnarExcepcionPorBodega.Id = 3
        Me.UiBotonElimnarExcepcionPorBodega.ImageOptions.ImageUri.Uri = "Delete"
        Me.UiBotonElimnarExcepcionPorBodega.Name = "UiBotonElimnarExcepcionPorBodega"
        '
        'UiBotonDescargarPlantillaEnExcepcionesPorPlantilla
        '
        Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla.Caption = "Descargar Plantilla"
        Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla.Id = 5
        Me.UiBotonDescargarPlantillaEnExcepcionesPorPlantilla.Name = "UiBotonDescargarPlantillaEnExcepcionesPorPlantilla"
        '
        'UiBotonCargarPlantillaEnExcepcionesPorPlantilla
        '
        Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla.Caption = "Cargar Plantilla"
        Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla.Id = 6
        Me.UiBotonCargarPlantillaEnExcepcionesPorPlantilla.Name = "UiBotonCargarPlantillaEnExcepcionesPorPlantilla"
        '
        'BarDockControl5
        '
        Me.BarDockControl5.CausesValidation = False
        Me.BarDockControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl5.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl5.Manager = Me.BarManager4
        Me.BarDockControl5.Size = New System.Drawing.Size(331, 40)
        '
        'BarDockControl6
        '
        Me.BarDockControl6.CausesValidation = False
        Me.BarDockControl6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl6.Location = New System.Drawing.Point(0, 364)
        Me.BarDockControl6.Manager = Me.BarManager4
        Me.BarDockControl6.Size = New System.Drawing.Size(331, 0)
        '
        'BarDockControl8
        '
        Me.BarDockControl8.CausesValidation = False
        Me.BarDockControl8.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl8.Location = New System.Drawing.Point(331, 40)
        Me.BarDockControl8.Manager = Me.BarManager4
        Me.BarDockControl8.Size = New System.Drawing.Size(0, 324)
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "BarButtonItem3"
        Me.BarButtonItem3.Id = 0
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'SmallIconsList
        '
        Me.SmallIconsList.ImageStream = CType(resources.GetObject("SmallIconsList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SmallIconsList.TransparentColor = System.Drawing.Color.Transparent
        Me.SmallIconsList.Images.SetKeyName(0, "small_edit.png")
        Me.SmallIconsList.Images.SetKeyName(1, "about.png")
        Me.SmallIconsList.Images.SetKeyName(2, "CLSDFOLD.BMP")
        Me.SmallIconsList.Images.SetKeyName(3, "OPENFOLD.BMP")
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.miniToolStrip.Location = New System.Drawing.Point(107, 3)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.miniToolStrip.Size = New System.Drawing.Size(342, 25)
        Me.miniToolStrip.TabIndex = 20
        '
        'Bar2
        '
        Me.Bar2.BarName = "Tools"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonAgregarCompononente, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Tools"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMaterials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 389)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMaterials"
        Me.Text = "Catalogos: Productos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.UiTabMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMateriales.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridControlVF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewFV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUnidadMedida.ResumeLayout(False)
        CType(Me.UiContenedorVistasUnidadMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UIVistaUnidadMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.UiTabDatosGenerales.ResumeLayout(False)
        Me.UiTabDatosGenerales.PerformLayout()
        CType(Me.UiPropiedadDeDatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaDeClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaClases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaSubClases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCboPropiedadManejaCalibre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiCboPropiedadManejaTono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabUbicacion.ResumeLayout(False)
        Me.UiTabUbicacion.PerformLayout()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaxQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabEmpaque.ResumeLayout(False)
        Me.UiTabEmpaque.PerformLayout()
        CType(Me.UiPropiedadDeEmpaque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiStoragePackaging, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLineSpacing1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMasterPack.ResumeLayout(False)
        Me.UiTabMasterPack.PerformLayout()
        CType(Me.UiContenedorDeVistasComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiVistaComponentesAsociados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBotonEliminarComponente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        CType(Me.UiSpinComponenteCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.UiListaComponenteMaterial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiListaVistaComponenteMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBarraMangMaterPack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabExcepcionesPorBodega.ResumeLayout(False)
        Me.UiTabExcepcionesPorBodega.PerformLayout()
        CType(Me.UiContenedorExcepcionesPorBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiVistaExcepcionPorBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiComboBodega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiComboPropiedad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiComboValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Grp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_SubTipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SmallIconsList As System.Windows.Forms.ImageList
    Friend WithEvents UiTabMateriales As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControlVF As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewFV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnFactor As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumn_Client As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GridColumn_Barcodeid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiTabUnidadMedida As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UiContenedorVistasUnidadMedida As DevExpress.XtraGrid.GridControl
    Friend WithEvents UIVistaUnidadMedida As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colUnMEASUREMENT_UNIT_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnCLIENT_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnMATERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnMEASUREMENT_UNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnALTERNATIVE_BARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents UiTabUbicacion As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Min As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtMinQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn_Max As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtMaxQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents UiTabDatosGenerales As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UiTabEmpaque As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UiPropiedadDeEmpaque As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents MaterialCategoria As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents codigoDeClientePropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents EmpaqueCategoria As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents empaquePropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents codigoDeMaterialPropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents cantidadPropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents codigoPropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents codigoDeBarrasPropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents codigoDeBarrasAlternativoPropiedad As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarUnidadDeMedida As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonAgregarEmpaque As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonGuardarEmpaque As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonElimnarEmpaque As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonImprimirEmpaque As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemLineSpacing1 As DevExpress.XtraRichEdit.Design.RepositoryItemLineSpacing
    Friend WithEvents UiBotonExportarEmpaquesExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents CantidadDeUnidadesDeMedida As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiTabMasterPack As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UiContenedorDeVistasComponentes As DevExpress.XtraGrid.GridControl
    Friend WithEvents UiVistaComponentesAsociados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiSpinComponenteCantidad As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents UiEtiquetaComponenteCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaComponenteMaterial As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiListaComponenteMaterial As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents UiListaVistaComponenteMaterial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents UiBarraMangMaterPack As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarraPrincipalMasterPack As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonAgregarCompononente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colComponenteDisponibleCodigoMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteDisponbileDescripcionMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteDisponibleCodigoBarra As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoCodigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoDescripcionMaterial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoCodigoBarra As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoCantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEnEliminar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBotonEliminarComponente As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colComponenteDisponbileEsMasterPack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colComponenteAsociadoEsMasterPack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents EsCarro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ManejaLote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ManejaSerie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ManejaMasterPack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnidadPeso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Peso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarDockControl11 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl12 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl10 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl9 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager2 As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarDatosGenerales As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonNuevo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonGuardar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonExportarExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarDockControl15 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl16 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl14 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl13 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager3 As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarUbicacion As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonNuevaUbicacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonEliminarUbicacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonGrabarUbicacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonDescargarPlantillaEnMasterPack As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCargarPlantillaEnMasterPack As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonDescargarPlantillaEnDatosGenerales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCargarPlantillaEnDatosGenerales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonDescargarPlantillaEnUbicacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCargarPlantillaEnUbicacion As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiPropiedadDeDatosGenerales As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents DatosDeAuditoria As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents PropiedadDeDatosGenerales_ActualizadoEl As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ActualizadoPor As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents DatosGenerales As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents PropiedadDeDatosGenerales_CantidadMaxPorBinbin As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Clase As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_SubClase As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Cliente As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Codigo As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_CodigoBarras As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_CodigoBarrasAlterno As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Descripcion As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_DescripcionCorta As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_EsCarro As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ManejaLote As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ManejaSerie As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ManejaMasterPack As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ManejaExplosionEnRecepcion As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_UnidadPeso As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents Dimensiones As DevExpress.XtraVerticalGrid.Rows.CategoryRow
    Friend WithEvents PropiedadDeDatosGenerales_Alto As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Ancho As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_FactorVolumen As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Largo As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_Peso As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents ManejaExplosionEnRecepcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents UiListaDeClientes As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiListaClases As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiListaSubClases As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiCboPropiedadManejaCalibre As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents UiCboPropiedadManejaTono As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents PropiedadDeDatosGenerales_ManejaTono As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_ManejaCalibre As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_UsaLineaPicking As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents UiTabExcepcionesPorBodega As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents UiContenedorExcepcionesPorBodega As DevExpress.XtraGrid.GridControl
    Friend WithEvents UiVistaExcepcionPorBodega As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiColBodega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColPropiedad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColValor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarDockControl7 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl8 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl6 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl5 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager4 As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarExcepcionesPorBodega As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonNuevaExcepcionPorBodega As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonGuardarExcepcionPorBodega As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonElimnarExcepcionPorBodega As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonDescargarPlantillaEnExcepcionesPorPlantilla As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCargarPlantillaEnExcepcionesPorPlantilla As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiComboBodega As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiComboPropiedad As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiComboValor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UiColMaterialPropiedad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColModifico As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PropiedadDeDatosGenerales_QUALITY_CONTROL As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents ControlDeCalidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiStoragePackaging As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiBotonDescargarPlantillaEnUnidadDeMedida As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiBotonCargarPlantillaEnUnidadDeMedida As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnDESCRIPTION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColManejaSerieCorrelativa As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColPrefixCorrelativeSerial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PropiedadDeDatosGenerales_HANDLE_CORRELATIVE_SERIALS As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_PREFIX_CORRELATIVE_SERIALS As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_LEAD_TIME As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_EXPIRATION_TOLERANCE As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents PropiedadDeDatosGenerales_SUPPLIER As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents UiColLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColExpirationTolerance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PropiedadDeDatosGenerales_Proveedor As DevExpress.XtraVerticalGrid.Rows.PGridEditorRow
    Friend WithEvents UiColSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PropiedadDEDatosGenerales_NombreProveedor As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents UiColNameSupplier As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColum_ClientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
