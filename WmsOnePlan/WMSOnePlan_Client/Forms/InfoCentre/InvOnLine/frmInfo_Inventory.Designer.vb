<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo_Inventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo_Inventory))
        Me.lookupEstados = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.Timer_Inventory = New System.Windows.Forms.Timer(Me.components)
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_CurrentWH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Linea = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Ubicacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Prod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Descripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Unidades = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClientOwner = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClientName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTermOfTrade = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdatedBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFechaLlegada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDUA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNumeroOrden = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPoliza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colALTERNATE_BARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOMMITED_QTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Serial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_FVOL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDATE_EXPIRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_CLASS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBATCH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOC_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUSED_MT2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_VIN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPENDIENTE_RECTIFICACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGRUPO_REGIMEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colREGIMEN_DOCUMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCodigoProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNombreProveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMATERIAL_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colZONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAVAILABLE_QTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColValorUnitario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColValorTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColIntentarioExterno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiGridColSkuSerie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDiasRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDiasVencimiento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColFechaVencimientoRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColEstadoRegimen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreEstado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColBloqueoInventario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColColorEstado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColTono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColCalibre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColOrdenDeVenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColProyecto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColBloqueoInterfaces = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColPeso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColUnidadPeso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColOlaPicking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_PK_LINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_BATCH_REQUESTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_STATUS_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_TONE_CALIBER_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_HANDLE_TONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_HANDLE_CALIBER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColCodigoProyecto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreProyecto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTAL_POSITION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
        Me.PrintableComponentLink1 = New DevExpress.XtraPrinting.PrintableComponentLink(Me.components)
        Me.barOpciones = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barToolOpciones = New DevExpress.XtraBars.Bar()
        Me.barBtnAutomatica = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.barBtnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.BarBtnExcel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSaveChanges = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.barBtnExel = New DevExpress.XtraBars.BarButtonItem()
        Me.BarBtnPDF = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.UiBotonRefrescar = New DevExpress.XtraBars.BarButtonItem()
        Me.OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter1 = New WMSOnePlan_Client.DS_WaveReportTableAdapters.OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.loadLayoutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.UiColAllowPicking = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.lookupEstados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.barOpciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lookupEstados
        '
        Me.lookupEstados.AutoHeight = False
        Me.lookupEstados.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lookupEstados.DisplayMember = "PARAM_NAME"
        Me.lookupEstados.Name = "lookupEstados"
        Me.lookupEstados.ValueMember = "PARAM_NAME"
        '
        'Timer_Inventory
        '
        Me.Timer_Inventory.Interval = 150000
        '
        'GridControl1
        '
        Me.GridControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 24)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(970, 497)
        Me.GridControl1.TabIndex = 17
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_CurrentWH, Me.GridColumn_Linea, Me.GridColumn_Ubicacion, Me.GridColumn_Prod, Me.GridColumn_Descripcion, Me.GridColumn_Unidades, Me.GridColumnClientOwner, Me.GridColumnClientName, Me.GridColumnTermOfTrade, Me.GridColumnLastUpdatedBy, Me.GridColumnFechaLlegada, Me.GridColumnDUA, Me.GridColumnNumeroOrden, Me.GridColumnPoliza, Me.GridColumnRegimen, Me.colFECHA_DOCUMENTO, Me.colALTERNATE_BARCODE, Me.colCOMMITED_QTY, Me.GridColumn_Serial, Me.GridColumn_FVOL, Me.colDATE_EXPIRATION, Me.GridColumn_CLASS, Me.colBATCH, Me.colDOC_ID, Me.colUSED_MT2, Me.GridColumn_VIN, Me.colPENDIENTE_RECTIFICACION, Me.colGRUPO_REGIMEN, Me.colREGIMEN_DOCUMENTO, Me.colCodigoProveedor, Me.colNombreProveedor, Me.colMATERIAL_ID, Me.colZONE, Me.UiColAllowPicking, Me.colAVAILABLE_QTY, Me.UiColValorUnitario, Me.UiColValorTotal, Me.UiColIntentarioExterno, Me.UiGridColSkuSerie, Me.UiColDiasRegimen, Me.UiColDiasVencimiento, Me.UiColFechaVencimientoRegimen, Me.UiColEstadoRegimen, Me.UiColNombreEstado, Me.UiColBloqueoInventario, Me.UiColColorEstado, Me.UiColTono, Me.UiColCalibre, Me.UiColOrdenDeVenta, Me.UiColProyecto, Me.UiColNombreCliente, Me.UiColBloqueoInterfaces, Me.UiColPeso, Me.UiColUnidadPeso, Me.UiColOlaPicking, Me.GridColumn_PK_LINE, Me.GridColumn_BATCH_REQUESTED, Me.GridColumn_STATUS_ID, Me.GridColumn_TONE_CALIBER_ID, Me.GridColumn_HANDLE_TONE, Me.GridColumn_HANDLE_CALIBER, Me.UiColCodigoProyecto, Me.UiColNombreProyecto, Me.colTOTAL_POSITION})
        Me.GridView1.DetailHeight = 284
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", Nothing, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "MATERIAL_ID", Nothing, "")})
        Me.GridView1.LevelIndent = 0
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.PreviewIndent = 0
        Me.GridView1.ViewCaption = "InventarioOnLine"
        '
        'GridColumn_CurrentWH
        '
        Me.GridColumn_CurrentWH.Caption = "Bodega"
        Me.GridColumn_CurrentWH.FieldName = "CURRENT_WAREHOUSE"
        Me.GridColumn_CurrentWH.MinWidth = 15
        Me.GridColumn_CurrentWH.Name = "GridColumn_CurrentWH"
        Me.GridColumn_CurrentWH.OptionsColumn.AllowEdit = False
        Me.GridColumn_CurrentWH.OptionsColumn.AllowFocus = False
        Me.GridColumn_CurrentWH.Visible = True
        Me.GridColumn_CurrentWH.VisibleIndex = 1
        Me.GridColumn_CurrentWH.Width = 45
        '
        'GridColumn_Linea
        '
        Me.GridColumn_Linea.Caption = "Licencia"
        Me.GridColumn_Linea.FieldName = "LICENSE_ID"
        Me.GridColumn_Linea.MinWidth = 15
        Me.GridColumn_Linea.Name = "GridColumn_Linea"
        Me.GridColumn_Linea.OptionsColumn.AllowEdit = False
        Me.GridColumn_Linea.OptionsColumn.AllowFocus = False
        Me.GridColumn_Linea.OptionsColumn.ReadOnly = True
        Me.GridColumn_Linea.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LICENSE_ID", "Registros {0}")})
        Me.GridColumn_Linea.Visible = True
        Me.GridColumn_Linea.VisibleIndex = 2
        Me.GridColumn_Linea.Width = 50
        '
        'GridColumn_Ubicacion
        '
        Me.GridColumn_Ubicacion.Caption = "Ubicacion"
        Me.GridColumn_Ubicacion.FieldName = "CURRENT_LOCATION"
        Me.GridColumn_Ubicacion.MinWidth = 15
        Me.GridColumn_Ubicacion.Name = "GridColumn_Ubicacion"
        Me.GridColumn_Ubicacion.OptionsColumn.AllowEdit = False
        Me.GridColumn_Ubicacion.OptionsColumn.FixedWidth = True
        Me.GridColumn_Ubicacion.OptionsColumn.ReadOnly = True
        Me.GridColumn_Ubicacion.Visible = True
        Me.GridColumn_Ubicacion.VisibleIndex = 3
        Me.GridColumn_Ubicacion.Width = 31
        '
        'GridColumn_Prod
        '
        Me.GridColumn_Prod.Caption = "Codigo Barras"
        Me.GridColumn_Prod.FieldName = "BARCODE_ID"
        Me.GridColumn_Prod.MinWidth = 15
        Me.GridColumn_Prod.Name = "GridColumn_Prod"
        Me.GridColumn_Prod.OptionsColumn.AllowEdit = False
        Me.GridColumn_Prod.OptionsColumn.ReadOnly = True
        Me.GridColumn_Prod.Visible = True
        Me.GridColumn_Prod.VisibleIndex = 4
        Me.GridColumn_Prod.Width = 24
        '
        'GridColumn_Descripcion
        '
        Me.GridColumn_Descripcion.Caption = "Descripcion"
        Me.GridColumn_Descripcion.FieldName = "MATERIAL_NAME"
        Me.GridColumn_Descripcion.MinWidth = 15
        Me.GridColumn_Descripcion.Name = "GridColumn_Descripcion"
        Me.GridColumn_Descripcion.OptionsColumn.AllowEdit = False
        Me.GridColumn_Descripcion.OptionsColumn.ReadOnly = True
        Me.GridColumn_Descripcion.Visible = True
        Me.GridColumn_Descripcion.VisibleIndex = 5
        Me.GridColumn_Descripcion.Width = 37
        '
        'GridColumn_Unidades
        '
        Me.GridColumn_Unidades.Caption = "Inv.Licencia"
        Me.GridColumn_Unidades.FieldName = "QTY"
        Me.GridColumn_Unidades.MinWidth = 15
        Me.GridColumn_Unidades.Name = "GridColumn_Unidades"
        Me.GridColumn_Unidades.OptionsColumn.AllowEdit = False
        Me.GridColumn_Unidades.OptionsColumn.AllowFocus = False
        Me.GridColumn_Unidades.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Unidades.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Unidades.OptionsColumn.ReadOnly = True
        Me.GridColumn_Unidades.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "QTY", "{0:0.##}")})
        Me.GridColumn_Unidades.Visible = True
        Me.GridColumn_Unidades.VisibleIndex = 7
        Me.GridColumn_Unidades.Width = 46
        '
        'GridColumnClientOwner
        '
        Me.GridColumnClientOwner.Caption = "Cliente"
        Me.GridColumnClientOwner.FieldName = "CLIENT_OWNER"
        Me.GridColumnClientOwner.MinWidth = 15
        Me.GridColumnClientOwner.Name = "GridColumnClientOwner"
        Me.GridColumnClientOwner.OptionsColumn.AllowEdit = False
        Me.GridColumnClientOwner.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnClientOwner.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumnClientOwner.Width = 19
        '
        'GridColumnClientName
        '
        Me.GridColumnClientName.Caption = "Nombre Cliente"
        Me.GridColumnClientName.FieldName = "CLIENT_NAME"
        Me.GridColumnClientName.MinWidth = 15
        Me.GridColumnClientName.Name = "GridColumnClientName"
        Me.GridColumnClientName.OptionsColumn.AllowEdit = False
        Me.GridColumnClientName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnClientName.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumnClientName.Visible = True
        Me.GridColumnClientName.VisibleIndex = 6
        Me.GridColumnClientName.Width = 50
        '
        'GridColumnTermOfTrade
        '
        Me.GridColumnTermOfTrade.Caption = "Acuerdo Comercial"
        Me.GridColumnTermOfTrade.FieldName = "TERMS_OF_TRADE"
        Me.GridColumnTermOfTrade.MinWidth = 15
        Me.GridColumnTermOfTrade.Name = "GridColumnTermOfTrade"
        Me.GridColumnTermOfTrade.OptionsColumn.AllowEdit = False
        Me.GridColumnTermOfTrade.Visible = True
        Me.GridColumnTermOfTrade.VisibleIndex = 28
        Me.GridColumnTermOfTrade.Width = 30
        '
        'GridColumnLastUpdatedBy
        '
        Me.GridColumnLastUpdatedBy.Caption = "Actualizado Por"
        Me.GridColumnLastUpdatedBy.FieldName = "LAST_UPDATED_BY"
        Me.GridColumnLastUpdatedBy.MinWidth = 15
        Me.GridColumnLastUpdatedBy.Name = "GridColumnLastUpdatedBy"
        Me.GridColumnLastUpdatedBy.OptionsColumn.AllowEdit = False
        Me.GridColumnLastUpdatedBy.Width = 50
        '
        'GridColumnFechaLlegada
        '
        Me.GridColumnFechaLlegada.Caption = "Fecha Llegada"
        Me.GridColumnFechaLlegada.DisplayFormat.FormatString = "dd/MM/yyyy HH:MM:tt"
        Me.GridColumnFechaLlegada.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumnFechaLlegada.FieldName = "FECHA_LLEGADA"
        Me.GridColumnFechaLlegada.MinWidth = 15
        Me.GridColumnFechaLlegada.Name = "GridColumnFechaLlegada"
        Me.GridColumnFechaLlegada.OptionsColumn.AllowEdit = False
        Me.GridColumnFechaLlegada.Visible = True
        Me.GridColumnFechaLlegada.VisibleIndex = 8
        Me.GridColumnFechaLlegada.Width = 50
        '
        'GridColumnDUA
        '
        Me.GridColumnDUA.Caption = "Numero DUA"
        Me.GridColumnDUA.FieldName = "NUMERO_DUA"
        Me.GridColumnDUA.MinWidth = 15
        Me.GridColumnDUA.Name = "GridColumnDUA"
        Me.GridColumnDUA.OptionsColumn.AllowEdit = False
        Me.GridColumnDUA.Width = 50
        '
        'GridColumnNumeroOrden
        '
        Me.GridColumnNumeroOrden.Caption = "Numero Orden"
        Me.GridColumnNumeroOrden.FieldName = "NUMERO_ORDEN"
        Me.GridColumnNumeroOrden.MinWidth = 15
        Me.GridColumnNumeroOrden.Name = "GridColumnNumeroOrden"
        Me.GridColumnNumeroOrden.OptionsColumn.AllowEdit = False
        Me.GridColumnNumeroOrden.Visible = True
        Me.GridColumnNumeroOrden.VisibleIndex = 9
        Me.GridColumnNumeroOrden.Width = 47
        '
        'GridColumnPoliza
        '
        Me.GridColumnPoliza.Caption = "Poliza"
        Me.GridColumnPoliza.FieldName = "CODIGO_POLIZA"
        Me.GridColumnPoliza.MinWidth = 15
        Me.GridColumnPoliza.Name = "GridColumnPoliza"
        Me.GridColumnPoliza.OptionsColumn.AllowEdit = False
        Me.GridColumnPoliza.Width = 50
        '
        'GridColumnRegimen
        '
        Me.GridColumnRegimen.Caption = "Regimen"
        Me.GridColumnRegimen.FieldName = "REGIMEN"
        Me.GridColumnRegimen.MinWidth = 15
        Me.GridColumnRegimen.Name = "GridColumnRegimen"
        Me.GridColumnRegimen.OptionsColumn.AllowEdit = False
        Me.GridColumnRegimen.Visible = True
        Me.GridColumnRegimen.VisibleIndex = 0
        Me.GridColumnRegimen.Width = 60
        '
        'colFECHA_DOCUMENTO
        '
        Me.colFECHA_DOCUMENTO.Caption = "Fecha Documento"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatString = "dd/MM/yyyy HH:MM"
        Me.colFECHA_DOCUMENTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colFECHA_DOCUMENTO.FieldName = "FECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.MinWidth = 15
        Me.colFECHA_DOCUMENTO.Name = "colFECHA_DOCUMENTO"
        Me.colFECHA_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colFECHA_DOCUMENTO.Width = 50
        '
        'colALTERNATE_BARCODE
        '
        Me.colALTERNATE_BARCODE.Caption = "Codigo Alterno"
        Me.colALTERNATE_BARCODE.FieldName = "ALTERNATE_BARCODE"
        Me.colALTERNATE_BARCODE.MinWidth = 15
        Me.colALTERNATE_BARCODE.Name = "colALTERNATE_BARCODE"
        Me.colALTERNATE_BARCODE.OptionsColumn.AllowEdit = False
        Me.colALTERNATE_BARCODE.Width = 32
        '
        'colCOMMITED_QTY
        '
        Me.colCOMMITED_QTY.Caption = "Inventario Comprometido"
        Me.colCOMMITED_QTY.FieldName = "COMMITED_QTY"
        Me.colCOMMITED_QTY.MinWidth = 15
        Me.colCOMMITED_QTY.Name = "colCOMMITED_QTY"
        Me.colCOMMITED_QTY.OptionsColumn.AllowEdit = False
        Me.colCOMMITED_QTY.Width = 32
        '
        'GridColumn_Serial
        '
        Me.GridColumn_Serial.Caption = "Serial/Chasis"
        Me.GridColumn_Serial.CustomizationCaption = "Serial/Chasis"
        Me.GridColumn_Serial.FieldName = "SERIAL_NUMBER"
        Me.GridColumn_Serial.MinWidth = 15
        Me.GridColumn_Serial.Name = "GridColumn_Serial"
        Me.GridColumn_Serial.OptionsColumn.AllowEdit = False
        Me.GridColumn_Serial.OptionsColumn.ReadOnly = True
        Me.GridColumn_Serial.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumn_Serial.Width = 39
        '
        'GridColumn_FVOL
        '
        Me.GridColumn_FVOL.Caption = "FactorVol."
        Me.GridColumn_FVOL.CustomizationCaption = "FactorVolumen"
        Me.GridColumn_FVOL.FieldName = "VOLUME_FACTOR"
        Me.GridColumn_FVOL.MinWidth = 15
        Me.GridColumn_FVOL.Name = "GridColumn_FVOL"
        Me.GridColumn_FVOL.OptionsColumn.AllowEdit = False
        Me.GridColumn_FVOL.OptionsColumn.ReadOnly = True
        Me.GridColumn_FVOL.Visible = True
        Me.GridColumn_FVOL.VisibleIndex = 12
        Me.GridColumn_FVOL.Width = 49
        '
        'colDATE_EXPIRATION
        '
        Me.colDATE_EXPIRATION.Caption = "Fecha de Expiracion"
        Me.colDATE_EXPIRATION.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colDATE_EXPIRATION.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colDATE_EXPIRATION.FieldName = "DATE_EXPIRATION"
        Me.colDATE_EXPIRATION.MinWidth = 15
        Me.colDATE_EXPIRATION.Name = "colDATE_EXPIRATION"
        Me.colDATE_EXPIRATION.Visible = True
        Me.colDATE_EXPIRATION.VisibleIndex = 16
        Me.colDATE_EXPIRATION.Width = 47
        '
        'GridColumn_CLASS
        '
        Me.GridColumn_CLASS.Caption = "Categoria"
        Me.GridColumn_CLASS.FieldName = "MATERIAL_CLASS"
        Me.GridColumn_CLASS.MinWidth = 15
        Me.GridColumn_CLASS.Name = "GridColumn_CLASS"
        Me.GridColumn_CLASS.OptionsColumn.AllowEdit = False
        Me.GridColumn_CLASS.OptionsColumn.ReadOnly = True
        Me.GridColumn_CLASS.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn_CLASS.Width = 50
        '
        'colBATCH
        '
        Me.colBATCH.Caption = "Numero de Lote"
        Me.colBATCH.FieldName = "BATCH"
        Me.colBATCH.MinWidth = 15
        Me.colBATCH.Name = "colBATCH"
        Me.colBATCH.Width = 27
        '
        'colDOC_ID
        '
        Me.colDOC_ID.Caption = "Codigo Documento"
        Me.colDOC_ID.FieldName = "DOC_ID"
        Me.colDOC_ID.MinWidth = 15
        Me.colDOC_ID.Name = "colDOC_ID"
        Me.colDOC_ID.OptionsColumn.AllowEdit = False
        Me.colDOC_ID.Width = 28
        '
        'colUSED_MT2
        '
        Me.colUSED_MT2.Caption = "Metros Cuatrados"
        Me.colUSED_MT2.FieldName = "USED_MT2"
        Me.colUSED_MT2.MinWidth = 15
        Me.colUSED_MT2.Name = "colUSED_MT2"
        Me.colUSED_MT2.OptionsColumn.AllowEdit = False
        Me.colUSED_MT2.Width = 18
        '
        'GridColumn_VIN
        '
        Me.GridColumn_VIN.Caption = "VIN"
        Me.GridColumn_VIN.FieldName = "VIN"
        Me.GridColumn_VIN.MinWidth = 15
        Me.GridColumn_VIN.Name = "GridColumn_VIN"
        Me.GridColumn_VIN.OptionsColumn.AllowEdit = False
        Me.GridColumn_VIN.Width = 33
        '
        'colPENDIENTE_RECTIFICACION
        '
        Me.colPENDIENTE_RECTIFICACION.Caption = "Pendiente de Rectificar"
        Me.colPENDIENTE_RECTIFICACION.FieldName = "PENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.MinWidth = 15
        Me.colPENDIENTE_RECTIFICACION.Name = "colPENDIENTE_RECTIFICACION"
        Me.colPENDIENTE_RECTIFICACION.OptionsColumn.AllowEdit = False
        Me.colPENDIENTE_RECTIFICACION.Width = 18
        '
        'colGRUPO_REGIMEN
        '
        Me.colGRUPO_REGIMEN.Caption = "Grupo Régimen"
        Me.colGRUPO_REGIMEN.FieldName = "GRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.MinWidth = 15
        Me.colGRUPO_REGIMEN.Name = "colGRUPO_REGIMEN"
        Me.colGRUPO_REGIMEN.OptionsColumn.AllowEdit = False
        Me.colGRUPO_REGIMEN.Width = 18
        '
        'colREGIMEN_DOCUMENTO
        '
        Me.colREGIMEN_DOCUMENTO.Caption = "Régimen Doc."
        Me.colREGIMEN_DOCUMENTO.FieldName = "REGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.MinWidth = 15
        Me.colREGIMEN_DOCUMENTO.Name = "colREGIMEN_DOCUMENTO"
        Me.colREGIMEN_DOCUMENTO.OptionsColumn.AllowEdit = False
        Me.colREGIMEN_DOCUMENTO.Width = 18
        '
        'colCodigoProveedor
        '
        Me.colCodigoProveedor.Caption = "Código Proveedor"
        Me.colCodigoProveedor.FieldName = "CODE_SUPPLIER"
        Me.colCodigoProveedor.MinWidth = 15
        Me.colCodigoProveedor.Name = "colCodigoProveedor"
        Me.colCodigoProveedor.OptionsColumn.AllowEdit = False
        Me.colCodigoProveedor.Width = 15
        '
        'colNombreProveedor
        '
        Me.colNombreProveedor.Caption = "Nombre Proveedor"
        Me.colNombreProveedor.FieldName = "NAME_SUPPLIER"
        Me.colNombreProveedor.MinWidth = 15
        Me.colNombreProveedor.Name = "colNombreProveedor"
        Me.colNombreProveedor.OptionsColumn.AllowEdit = False
        Me.colNombreProveedor.Width = 18
        '
        'colMATERIAL_ID
        '
        Me.colMATERIAL_ID.Caption = "Código Material"
        Me.colMATERIAL_ID.FieldName = "MATERIAL_ID"
        Me.colMATERIAL_ID.MinWidth = 15
        Me.colMATERIAL_ID.Name = "colMATERIAL_ID"
        Me.colMATERIAL_ID.OptionsColumn.AllowEdit = False
        Me.colMATERIAL_ID.Visible = True
        Me.colMATERIAL_ID.VisibleIndex = 10
        Me.colMATERIAL_ID.Width = 48
        '
        'colZONE
        '
        Me.colZONE.Caption = "Zona"
        Me.colZONE.FieldName = "ZONE"
        Me.colZONE.MinWidth = 15
        Me.colZONE.Name = "colZONE"
        Me.colZONE.OptionsColumn.AllowEdit = False
        Me.colZONE.Width = 18
        '
        'colAVAILABLE_QTY
        '
        Me.colAVAILABLE_QTY.Caption = "Inv.Disp."
        Me.colAVAILABLE_QTY.FieldName = "AVAILABLE_QTY"
        Me.colAVAILABLE_QTY.MinWidth = 15
        Me.colAVAILABLE_QTY.Name = "colAVAILABLE_QTY"
        Me.colAVAILABLE_QTY.OptionsColumn.AllowEdit = False
        Me.colAVAILABLE_QTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AVAILABLE_QTY", "{0:0.##}")})
        Me.colAVAILABLE_QTY.Visible = True
        Me.colAVAILABLE_QTY.VisibleIndex = 13
        Me.colAVAILABLE_QTY.Width = 45
        '
        'UiColValorUnitario
        '
        Me.UiColValorUnitario.Caption = "Valor Unitario"
        Me.UiColValorUnitario.DisplayFormat.FormatString = "###,###,##0.00"
        Me.UiColValorUnitario.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.UiColValorUnitario.FieldName = "VALOR_UNITARIO"
        Me.UiColValorUnitario.GroupFormat.FormatString = "###,###,##0.00"
        Me.UiColValorUnitario.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.UiColValorUnitario.MinWidth = 15
        Me.UiColValorUnitario.Name = "UiColValorUnitario"
        Me.UiColValorUnitario.OptionsColumn.AllowEdit = False
        Me.UiColValorUnitario.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALOR_UNITARIO", "{0:###,###,##0.00}")})
        Me.UiColValorUnitario.Visible = True
        Me.UiColValorUnitario.VisibleIndex = 15
        Me.UiColValorUnitario.Width = 49
        '
        'UiColValorTotal
        '
        Me.UiColValorTotal.Caption = "Valor Total"
        Me.UiColValorTotal.DisplayFormat.FormatString = "###,###,##0.00"
        Me.UiColValorTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.UiColValorTotal.FieldName = "TOTAL_VALOR"
        Me.UiColValorTotal.GroupFormat.FormatString = "###,###,##0.00"
        Me.UiColValorTotal.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.UiColValorTotal.MinWidth = 15
        Me.UiColValorTotal.Name = "UiColValorTotal"
        Me.UiColValorTotal.OptionsColumn.AllowFocus = False
        Me.UiColValorTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL_VALOR", "{0:###,###,##0.00}")})
        Me.UiColValorTotal.Visible = True
        Me.UiColValorTotal.VisibleIndex = 14
        Me.UiColValorTotal.Width = 59
        '
        'UiColIntentarioExterno
        '
        Me.UiColIntentarioExterno.Caption = "Inventario Externo"
        Me.UiColIntentarioExterno.FieldName = "IS_EXTERNAL_INVENTORY"
        Me.UiColIntentarioExterno.MinWidth = 15
        Me.UiColIntentarioExterno.Name = "UiColIntentarioExterno"
        Me.UiColIntentarioExterno.OptionsColumn.AllowEdit = False
        Me.UiColIntentarioExterno.Width = 18
        '
        'UiGridColSkuSerie
        '
        Me.UiGridColSkuSerie.Caption = "# De Serie"
        Me.UiGridColSkuSerie.FieldName = "SKU_SERIE"
        Me.UiGridColSkuSerie.MinWidth = 15
        Me.UiGridColSkuSerie.Name = "UiGridColSkuSerie"
        Me.UiGridColSkuSerie.OptionsColumn.AllowEdit = False
        Me.UiGridColSkuSerie.Visible = True
        Me.UiGridColSkuSerie.VisibleIndex = 11
        Me.UiGridColSkuSerie.Width = 41
        '
        'UiColDiasRegimen
        '
        Me.UiColDiasRegimen.Caption = "Días Régimen"
        Me.UiColDiasRegimen.FieldName = "DIAS_REGIMEN"
        Me.UiColDiasRegimen.MinWidth = 15
        Me.UiColDiasRegimen.Name = "UiColDiasRegimen"
        Me.UiColDiasRegimen.OptionsColumn.AllowEdit = False
        Me.UiColDiasRegimen.Width = 18
        '
        'UiColDiasVencimiento
        '
        Me.UiColDiasVencimiento.Caption = "Días para Vencimiento Régimen"
        Me.UiColDiasVencimiento.FieldName = "DIAS_PARA_VENCER"
        Me.UiColDiasVencimiento.MinWidth = 15
        Me.UiColDiasVencimiento.Name = "UiColDiasVencimiento"
        Me.UiColDiasVencimiento.OptionsColumn.AllowEdit = False
        Me.UiColDiasVencimiento.Width = 18
        '
        'UiColFechaVencimientoRegimen
        '
        Me.UiColFechaVencimientoRegimen.Caption = "Fecha Vencimiento Régimen"
        Me.UiColFechaVencimientoRegimen.FieldName = "FECHA_VENCIMIENTO"
        Me.UiColFechaVencimientoRegimen.MinWidth = 15
        Me.UiColFechaVencimientoRegimen.Name = "UiColFechaVencimientoRegimen"
        Me.UiColFechaVencimientoRegimen.OptionsColumn.AllowEdit = False
        Me.UiColFechaVencimientoRegimen.Visible = True
        Me.UiColFechaVencimientoRegimen.VisibleIndex = 17
        Me.UiColFechaVencimientoRegimen.Width = 41
        '
        'UiColEstadoRegimen
        '
        Me.UiColEstadoRegimen.Caption = "Estado Régimen"
        Me.UiColEstadoRegimen.FieldName = "ESTADO_REGIMEN"
        Me.UiColEstadoRegimen.MinWidth = 15
        Me.UiColEstadoRegimen.Name = "UiColEstadoRegimen"
        Me.UiColEstadoRegimen.OptionsColumn.AllowEdit = False
        Me.UiColEstadoRegimen.Visible = True
        Me.UiColEstadoRegimen.VisibleIndex = 18
        Me.UiColEstadoRegimen.Width = 34
        '
        'UiColNombreEstado
        '
        Me.UiColNombreEstado.Caption = "Estado"
        Me.UiColNombreEstado.ColumnEdit = Me.lookupEstados
        Me.UiColNombreEstado.FieldName = "STATUS_CODE"
        Me.UiColNombreEstado.MinWidth = 15
        Me.UiColNombreEstado.Name = "UiColNombreEstado"
        Me.UiColNombreEstado.Visible = True
        Me.UiColNombreEstado.VisibleIndex = 19
        Me.UiColNombreEstado.Width = 52
        '
        'UiColBloqueoInventario
        '
        Me.UiColBloqueoInventario.Caption = "Bloqueado"
        Me.UiColBloqueoInventario.FieldName = "BLOCKS_INVENTORY"
        Me.UiColBloqueoInventario.MinWidth = 15
        Me.UiColBloqueoInventario.Name = "UiColBloqueoInventario"
        Me.UiColBloqueoInventario.OptionsColumn.AllowEdit = False
        Me.UiColBloqueoInventario.Visible = True
        Me.UiColBloqueoInventario.VisibleIndex = 20
        Me.UiColBloqueoInventario.Width = 64
        '
        'UiColColorEstado
        '
        Me.UiColColorEstado.Caption = "Color De Estado"
        Me.UiColColorEstado.FieldName = "COLOR"
        Me.UiColColorEstado.MinWidth = 15
        Me.UiColColorEstado.Name = "UiColColorEstado"
        Me.UiColColorEstado.OptionsColumn.AllowEdit = False
        Me.UiColColorEstado.Visible = True
        Me.UiColColorEstado.VisibleIndex = 21
        Me.UiColColorEstado.Width = 48
        '
        'UiColTono
        '
        Me.UiColTono.Caption = "Tono"
        Me.UiColTono.FieldName = "TONE"
        Me.UiColTono.MinWidth = 15
        Me.UiColTono.Name = "UiColTono"
        Me.UiColTono.OptionsColumn.ReadOnly = True
        Me.UiColTono.Width = 15
        '
        'UiColCalibre
        '
        Me.UiColCalibre.Caption = "Calibre"
        Me.UiColCalibre.FieldName = "CALIBER"
        Me.UiColCalibre.MinWidth = 15
        Me.UiColCalibre.Name = "UiColCalibre"
        Me.UiColCalibre.OptionsColumn.ReadOnly = True
        Me.UiColCalibre.Visible = True
        Me.UiColCalibre.VisibleIndex = 22
        Me.UiColCalibre.Width = 56
        '
        'UiColOrdenDeVenta
        '
        Me.UiColOrdenDeVenta.Caption = "Orden De Venta"
        Me.UiColOrdenDeVenta.FieldName = "SALE_ORDER_ID"
        Me.UiColOrdenDeVenta.MinWidth = 15
        Me.UiColOrdenDeVenta.Name = "UiColOrdenDeVenta"
        Me.UiColOrdenDeVenta.OptionsColumn.AllowEdit = False
        Me.UiColOrdenDeVenta.OptionsColumn.ReadOnly = True
        Me.UiColOrdenDeVenta.Visible = True
        Me.UiColOrdenDeVenta.VisibleIndex = 23
        Me.UiColOrdenDeVenta.Width = 49
        '
        'UiColProyecto
        '
        Me.UiColProyecto.Caption = "Proyecto"
        Me.UiColProyecto.FieldName = "PROJECT"
        Me.UiColProyecto.MinWidth = 15
        Me.UiColProyecto.Name = "UiColProyecto"
        Me.UiColProyecto.OptionsColumn.AllowEdit = False
        Me.UiColProyecto.OptionsColumn.ReadOnly = True
        Me.UiColProyecto.Width = 15
        '
        'UiColNombreCliente
        '
        Me.UiColNombreCliente.Caption = "Cliente"
        Me.UiColNombreCliente.FieldName = "CUSTOMER_NAME"
        Me.UiColNombreCliente.MinWidth = 15
        Me.UiColNombreCliente.Name = "UiColNombreCliente"
        Me.UiColNombreCliente.OptionsColumn.AllowEdit = False
        Me.UiColNombreCliente.OptionsColumn.ReadOnly = True
        Me.UiColNombreCliente.Visible = True
        Me.UiColNombreCliente.VisibleIndex = 24
        Me.UiColNombreCliente.Width = 55
        '
        'UiColBloqueoInterfaces
        '
        Me.UiColBloqueoInterfaces.Caption = "Bloqueado Por Interfaz"
        Me.UiColBloqueoInterfaces.FieldName = "LOCKED_BY_INTERFACES"
        Me.UiColBloqueoInterfaces.MinWidth = 15
        Me.UiColBloqueoInterfaces.Name = "UiColBloqueoInterfaces"
        Me.UiColBloqueoInterfaces.OptionsColumn.AllowEdit = False
        Me.UiColBloqueoInterfaces.OptionsColumn.ReadOnly = True
        Me.UiColBloqueoInterfaces.Visible = True
        Me.UiColBloqueoInterfaces.VisibleIndex = 25
        Me.UiColBloqueoInterfaces.Width = 74
        '
        'UiColPeso
        '
        Me.UiColPeso.Caption = "Peso"
        Me.UiColPeso.FieldName = "WEIGTH"
        Me.UiColPeso.MinWidth = 15
        Me.UiColPeso.Name = "UiColPeso"
        Me.UiColPeso.OptionsColumn.AllowEdit = False
        Me.UiColPeso.OptionsColumn.ReadOnly = True
        Me.UiColPeso.Visible = True
        Me.UiColPeso.VisibleIndex = 26
        Me.UiColPeso.Width = 51
        '
        'UiColUnidadPeso
        '
        Me.UiColUnidadPeso.Caption = "Unidad de Peso"
        Me.UiColUnidadPeso.FieldName = "WEIGHT_MEASUREMENT"
        Me.UiColUnidadPeso.MinWidth = 15
        Me.UiColUnidadPeso.Name = "UiColUnidadPeso"
        Me.UiColUnidadPeso.OptionsColumn.AllowEdit = False
        Me.UiColUnidadPeso.OptionsColumn.ReadOnly = True
        Me.UiColUnidadPeso.Visible = True
        Me.UiColUnidadPeso.VisibleIndex = 27
        Me.UiColUnidadPeso.Width = 54
        '
        'UiColOlaPicking
        '
        Me.UiColOlaPicking.Caption = "Ola Picking"
        Me.UiColOlaPicking.FieldName = "WAVE_PICKING_ID"
        Me.UiColOlaPicking.MinWidth = 15
        Me.UiColOlaPicking.Name = "UiColOlaPicking"
        Me.UiColOlaPicking.OptionsColumn.AllowEdit = False
        Me.UiColOlaPicking.Width = 15
        '
        'GridColumn_PK_LINE
        '
        Me.GridColumn_PK_LINE.Caption = "LINE"
        Me.GridColumn_PK_LINE.FieldName = "PK_LINE"
        Me.GridColumn_PK_LINE.MinWidth = 15
        Me.GridColumn_PK_LINE.Name = "GridColumn_PK_LINE"
        Me.GridColumn_PK_LINE.OptionsColumn.ReadOnly = True
        Me.GridColumn_PK_LINE.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn_PK_LINE.Width = 56
        '
        'GridColumn_BATCH_REQUESTED
        '
        Me.GridColumn_BATCH_REQUESTED.Caption = "Maneja Lote"
        Me.GridColumn_BATCH_REQUESTED.FieldName = "BATCH_REQUESTED"
        Me.GridColumn_BATCH_REQUESTED.MinWidth = 15
        Me.GridColumn_BATCH_REQUESTED.Name = "GridColumn_BATCH_REQUESTED"
        Me.GridColumn_BATCH_REQUESTED.OptionsColumn.AllowEdit = False
        Me.GridColumn_BATCH_REQUESTED.OptionsColumn.ReadOnly = True
        Me.GridColumn_BATCH_REQUESTED.Width = 56
        '
        'GridColumn_STATUS_ID
        '
        Me.GridColumn_STATUS_ID.Caption = "STATUS_ID"
        Me.GridColumn_STATUS_ID.FieldName = "STATUS_ID"
        Me.GridColumn_STATUS_ID.MinWidth = 15
        Me.GridColumn_STATUS_ID.Name = "GridColumn_STATUS_ID"
        Me.GridColumn_STATUS_ID.OptionsColumn.AllowEdit = False
        Me.GridColumn_STATUS_ID.OptionsColumn.ReadOnly = True
        Me.GridColumn_STATUS_ID.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn_STATUS_ID.Width = 56
        '
        'GridColumn_TONE_CALIBER_ID
        '
        Me.GridColumn_TONE_CALIBER_ID.Caption = "TONE_AND_CALIBER_ID"
        Me.GridColumn_TONE_CALIBER_ID.FieldName = "TONE_AND_CALIBER_ID"
        Me.GridColumn_TONE_CALIBER_ID.MinWidth = 15
        Me.GridColumn_TONE_CALIBER_ID.Name = "GridColumn_TONE_CALIBER_ID"
        Me.GridColumn_TONE_CALIBER_ID.OptionsColumn.AllowEdit = False
        Me.GridColumn_TONE_CALIBER_ID.OptionsColumn.ReadOnly = True
        Me.GridColumn_TONE_CALIBER_ID.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumn_TONE_CALIBER_ID.Width = 56
        '
        'GridColumn_HANDLE_TONE
        '
        Me.GridColumn_HANDLE_TONE.Caption = "Maneja Tono"
        Me.GridColumn_HANDLE_TONE.FieldName = "HANDLE_TONE"
        Me.GridColumn_HANDLE_TONE.MinWidth = 15
        Me.GridColumn_HANDLE_TONE.Name = "GridColumn_HANDLE_TONE"
        Me.GridColumn_HANDLE_TONE.OptionsColumn.AllowEdit = False
        Me.GridColumn_HANDLE_TONE.OptionsColumn.ReadOnly = True
        Me.GridColumn_HANDLE_TONE.Width = 56
        '
        'GridColumn_HANDLE_CALIBER
        '
        Me.GridColumn_HANDLE_CALIBER.Caption = "Maneja Calibre"
        Me.GridColumn_HANDLE_CALIBER.FieldName = "HANDLE_CALIBER"
        Me.GridColumn_HANDLE_CALIBER.MinWidth = 15
        Me.GridColumn_HANDLE_CALIBER.Name = "GridColumn_HANDLE_CALIBER"
        Me.GridColumn_HANDLE_CALIBER.OptionsColumn.AllowEdit = False
        Me.GridColumn_HANDLE_CALIBER.OptionsColumn.ReadOnly = True
        Me.GridColumn_HANDLE_CALIBER.Width = 56
        '
        'UiColCodigoProyecto
        '
        Me.UiColCodigoProyecto.Caption = "Código Proyecto"
        Me.UiColCodigoProyecto.FieldName = "PROJECT_CODE"
        Me.UiColCodigoProyecto.Name = "UiColCodigoProyecto"
        Me.UiColCodigoProyecto.OptionsColumn.AllowEdit = False
        Me.UiColCodigoProyecto.Width = 20
        '
        'UiColNombreProyecto
        '
        Me.UiColNombreProyecto.Caption = "Nombre Proyecto"
        Me.UiColNombreProyecto.FieldName = "PROJECT_SHORT_NAME"
        Me.UiColNombreProyecto.Name = "UiColNombreProyecto"
        Me.UiColNombreProyecto.OptionsColumn.AllowEdit = False
        Me.UiColNombreProyecto.Width = 20
        '
        'colTOTAL_POSITION
        '
        Me.colTOTAL_POSITION.Caption = "Posiciones Físicas"
        Me.colTOTAL_POSITION.FieldName = "TOTAL_POSITION"
        Me.colTOTAL_POSITION.MinWidth = 18
        Me.colTOTAL_POSITION.Name = "colTOTAL_POSITION"
        Me.colTOTAL_POSITION.OptionsColumn.AllowEdit = False
        Me.colTOTAL_POSITION.Visible = True
        Me.colTOTAL_POSITION.VisibleIndex = 29
        Me.colTOTAL_POSITION.Width = 61
        '
        'PrintingSystem1
        '
        Me.PrintingSystem1.Links.AddRange(New Object() {Me.PrintableComponentLink1})
        '
        'PrintableComponentLink1
        '
        Me.PrintableComponentLink1.Component = Me.GridControl1
        Me.PrintableComponentLink1.Landscape = True
        Me.PrintableComponentLink1.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        Me.PrintableComponentLink1.PrintingSystemBase = Me.PrintingSystem1
        '
        'barOpciones
        '
        Me.barOpciones.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.barToolOpciones, Me.Bar3})
        Me.barOpciones.DockControls.Add(Me.barDockControlTop)
        Me.barOpciones.DockControls.Add(Me.barDockControlBottom)
        Me.barOpciones.DockControls.Add(Me.barDockControlLeft)
        Me.barOpciones.DockControls.Add(Me.barDockControlRight)
        Me.barOpciones.Form = Me
        Me.barOpciones.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.barBtnAutomatica, Me.barBtnSave, Me.barBtnExel, Me.barBtnPrint, Me.BarBtnExcel, Me.BarBtnPDF, Me.btnRefresh, Me.btnSaveChanges})
        Me.barOpciones.MaxItemId = 9
        Me.barOpciones.StatusBar = Me.Bar3
        '
        'barToolOpciones
        '
        Me.barToolOpciones.BarName = "Herramientas"
        Me.barToolOpciones.DockCol = 0
        Me.barToolOpciones.DockRow = 0
        Me.barToolOpciones.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.barToolOpciones.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnAutomatica, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barBtnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarBtnExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSaveChanges)})
        Me.barToolOpciones.OptionsBar.AllowQuickCustomization = False
        Me.barToolOpciones.OptionsBar.DrawDragBorder = False
        Me.barToolOpciones.OptionsBar.UseWholeRow = True
        Me.barToolOpciones.Text = "Herramientas"
        '
        'barBtnAutomatica
        '
        Me.barBtnAutomatica.Caption = "Actualización Manual"
        Me.barBtnAutomatica.Id = 0
        Me.barBtnAutomatica.ImageOptions.Image = CType(resources.GetObject("barBtnAutomatica.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnAutomatica.ImageOptions.LargeImage = CType(resources.GetObject("barBtnAutomatica.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnAutomatica.Name = "barBtnAutomatica"
        '
        'barBtnSave
        '
        Me.barBtnSave.Caption = "Guardar"
        Me.barBtnSave.Id = 1
        Me.barBtnSave.ImageOptions.Image = CType(resources.GetObject("barBtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnSave.ImageOptions.LargeImage = CType(resources.GetObject("barBtnSave.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnSave.Name = "barBtnSave"
        '
        'barBtnPrint
        '
        Me.barBtnPrint.Caption = "Print"
        Me.barBtnPrint.Id = 3
        Me.barBtnPrint.ImageOptions.Image = CType(resources.GetObject("barBtnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnPrint.ImageOptions.LargeImage = CType(resources.GetObject("barBtnPrint.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnPrint.Name = "barBtnPrint"
        '
        'BarBtnExcel
        '
        Me.BarBtnExcel.Caption = "Excel"
        Me.BarBtnExcel.Id = 4
        Me.BarBtnExcel.ImageOptions.Image = CType(resources.GetObject("BarBtnExcel.ImageOptions.Image"), System.Drawing.Image)
        Me.BarBtnExcel.ImageOptions.LargeImage = CType(resources.GetObject("BarBtnExcel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarBtnExcel.Name = "BarBtnExcel"
        '
        'btnRefresh
        '
        Me.btnRefresh.Caption = "Refrescar"
        Me.btnRefresh.Id = 6
        Me.btnRefresh.ImageOptions.Image = CType(resources.GetObject("btnRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageOptions.LargeImage = CType(resources.GetObject("btnRefresh.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Caption = "Guardar Cambios"
        Me.btnSaveChanges.Id = 7
        Me.btnSaveChanges.ImageOptions.Image = CType(resources.GetObject("btnSaveChanges.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveChanges.ImageOptions.LargeImage = CType(resources.GetObject("btnSaveChanges.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnSaveChanges.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'Bar3
        '
        Me.Bar3.BarName = "Barra de estado"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Barra de estado"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.barOpciones
        Me.barDockControlTop.Size = New System.Drawing.Size(970, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 521)
        Me.barDockControlBottom.Manager = Me.barOpciones
        Me.barDockControlBottom.Size = New System.Drawing.Size(970, 20)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Manager = Me.barOpciones
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 497)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(970, 24)
        Me.barDockControlRight.Manager = Me.barOpciones
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 497)
        '
        'barBtnExel
        '
        Me.barBtnExel.Caption = "Exel"
        Me.barBtnExel.Id = 2
        Me.barBtnExel.ImageOptions.Image = CType(resources.GetObject("barBtnExel.ImageOptions.Image"), System.Drawing.Image)
        Me.barBtnExel.ImageOptions.LargeImage = CType(resources.GetObject("barBtnExel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.barBtnExel.Name = "barBtnExel"
        '
        'BarBtnPDF
        '
        Me.BarBtnPDF.Caption = "PDF"
        Me.BarBtnPDF.Id = 5
        Me.BarBtnPDF.ImageOptions.Image = CType(resources.GetObject("BarBtnPDF.ImageOptions.Image"), System.Drawing.Image)
        Me.BarBtnPDF.ImageOptions.LargeImage = CType(resources.GetObject("BarBtnPDF.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarBtnPDF.Name = "BarBtnPDF"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Print"
        Me.BarButtonItem1.Id = 3
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'UiBotonRefrescar
        '
        Me.UiBotonRefrescar.Caption = "Refrescar"
        Me.UiBotonRefrescar.Id = 7
        Me.UiBotonRefrescar.ImageOptions.Image = CType(resources.GetObject("UiBotonRefrescar.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonRefrescar.ImageOptions.LargeImage = CType(resources.GetObject("UiBotonRefrescar.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.UiBotonRefrescar.Name = "UiBotonRefrescar"
        '
        'OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter1
        '
        Me.OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter1.ClearBeforeFill = True
        '
        'loadLayoutTimer
        '
        Me.loadLayoutTimer.Interval = 1000
        '
        'UiColAllowPicking
        '
        Me.UiColAllowPicking.Caption = "Permite Picking"
        Me.UiColAllowPicking.FieldName = "ALLOW_PICKING"
        Me.UiColAllowPicking.Name = "UiColAllowPicking"
        Me.UiColAllowPicking.Visible = True
        Me.UiColAllowPicking.VisibleIndex = 30
        '
        'frmInfo_Inventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 541)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInfo_Inventory"
        Me.Text = "Consulta: Inventario en Linea"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.lookupEstados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrintingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.barOpciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_Inventory As System.Windows.Forms.Timer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_CurrentWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Ubicacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Prod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Unidades As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Descripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Linea As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClientOwner As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClientName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTermOfTrade As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdatedBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFechaLlegada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDUA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNumeroOrden As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPoliza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintingSystem1 As DevExpress.XtraPrinting.PrintingSystem
    Friend WithEvents PrintableComponentLink1 As DevExpress.XtraPrinting.PrintableComponentLink
    Friend WithEvents GridColumnRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colALTERNATE_BARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOMMITED_QTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Serial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_FVOL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_CLASS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDATE_EXPIRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBATCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOC_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUSED_MT2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents barOpciones As DevExpress.XtraBars.BarManager
    Friend WithEvents barToolOpciones As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barBtnAutomatica As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnExel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barBtnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarBtnExcel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarBtnPDF As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn_VIN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPENDIENTE_RECTIFICACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGRUPO_REGIMEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colREGIMEN_DOCUMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCodigoProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNombreProveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMATERIAL_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colZONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAVAILABLE_QTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColValorUnitario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColValorTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColIntentarioExterno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiGridColSkuSerie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDiasRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDiasVencimiento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColFechaVencimientoRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColEstadoRegimen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreEstado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColBloqueoInventario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColColorEstado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColTono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColCalibre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColOrdenDeVenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColProyecto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColBloqueoInterfaces As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Private WithEvents UiBotonRefrescar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents UiColPeso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColUnidadPeso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColOlaPicking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSaveChanges As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn_PK_LINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_BATCH_REQUESTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_STATUS_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_TONE_CALIBER_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_HANDLE_TONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_HANDLE_CALIBER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColCodigoProyecto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreProyecto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lookupEstados As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter1 As DS_WaveReportTableAdapters.OP_WMS_VIEW_DETAIL_WAVEPICKINGTableAdapter
    Friend WithEvents colTOTAL_POSITION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents loadLayoutTimer As Timer
    Friend WithEvents UiColAllowPicking As DevExpress.XtraGrid.Columns.GridColumn
End Class
