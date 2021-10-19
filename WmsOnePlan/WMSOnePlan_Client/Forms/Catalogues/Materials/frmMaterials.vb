Imports System.ComponentModel
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports System.Text
Imports DevExpress.CodeParser
Imports DevExpress.Data.Helpers
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraRichEdit.Fields
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Rows
Imports MobilityScm.Modelo
Imports DevExpress.XtraEditors
Imports ClosedXML.Excel
Imports DevExpress.XtraDiagram.Utils
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Vertical.Entidades

Public Class frmMaterials

    Dim SelectedsKU As String
    Dim ListaDeBodegas As DataTable
    Dim ListaDePropiedades As DataTable
    Dim PropiedadesDelMaterialSelecionado As DataTable

    Private Function ObtenerUnidadDePesoPorDefecto() As String
        Try
            Dim settingsService As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
            Dim ds As New DataSet
            Dim unidadPorDefecto = ""
            Dim pResult As String = ""


            ds = settingsService.GetParam_ByParamKey("SISTEMA", "UNIDAD_PESO", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each row In ds.Tables(0).Rows
                    If row("SPARE1").ToString() = "1" Then
                        unidadPorDefecto = row("PARAM_NAME").ToString()
                    End If
                Next

                If unidadPorDefecto <> "" Then
                    Return unidadPorDefecto
                Else
                    NotifyStatus("No hay unidad de peso por defecto", True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Function

    Private Sub ClearBag_Materials()
        Dim defaultWeight = ObtenerUnidadDePesoPorDefecto()

        '19-Jul-10 se creo campo Max_X_BIN
        With Bag_Materials_Class
            .CodigoBarras = ""
            .CodigoBarrasAlterno = ""
            .Descripcion = ""
            .DescripcionCorta = ""
            .FactorVolumen = 0
            .Clase = ""
            .SubClase = ""
            .CantidadMaxPorBin = 0
            .Actualizado_el = ""
            .Actualizado_por = ""
            .Alto = 0
            .Ancho = 0
            .Cliente = ""
            .Codigo = ""
            .Largo = 0
            .Peso = 0
            .UnidadPeso = defaultWeight
            .EsCarro = "NO"
            .ManejaExplosionEnRecepcion = "NO"
            .ManejaMasterPack = "NO"
            .ManejaSerie = "NO"
            .ManejaLote = "NO"
            .ManejaTono = 0
            .ManejaCalibre = 0
            .UsaLineaDePicking = "NO"
            .UsaControlDeCalidad = "NO"
            .ManejaSerieCorrelativa = "NO"
            .PrefijoSerieCorrelativa = ""
            .TiempoDeEspera = 0
            .Proveedor = ""
            .NombreProveedor = ""
            .ToleranciaDeExpiracion = 0
            UiPropiedadDeDatosGenerales.SelectedObject = Bag_Materials_Class
            UiPropiedadDeDatosGenerales.Refresh()
        End With

    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""

        If Not IsNothing(Bag_Materials_Class.Cliente) AndAlso Not IsNothing(Bag_Materials_Class.Codigo) Then
            If Bag_Materials_Class.Grabar(pResult) Then
                CargarMasterPack()
                FilListView(False)
                UiPropiedadDeDatosGenerales.Refresh()
            Else
                If pResult.Contains("Violation of PRIMARY KEY") Then
                    pResult = "Error de duplicidad: cliente, " + Bag_Materials_Class.Cliente + " ya tiene un SKU con codigo, " + Bag_Materials_Class.Codigo
                End If
                NotifyStatus(pResult, True, True)
            End If
        End If

    End Sub

    Private Sub frmMaterials_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        VisibleFields()
        FilListView(True)

        CargarBodegas()
        CargarPropiedades()
    End Sub

    Public Sub VisibleFields()
        Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim parameterValue As String

        Try
            xds = xserv.ObtenerParametros("MATERIAL_SUB_FAMILY", "USE_MATERIAL_SUB_FAMILY", PublicLoginInfo.Environment)
            xdr = xds.Tables(0).Rows(0)
            parameterValue = xdr("VALUE").ToString
        Catch ex As Exception
            parameterValue = "0"
        End Try

        If parameterValue = "0" Then
            GridView1.Columns("SUB_CLASS_NAME").Visible = False
            DatosGenerales.ChildRows("PropiedadDeDatosGenerales_SubClase").Visible = False
        End If
    End Sub

    Public Sub CargarBodegas()
        Dim servicioBodegas As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
        Dim pResult As String = String.Empty
        ListaDeBodegas = servicioBodegas.GetAvailableWarehouseByUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
        If pResult <> "OK" Then
            NotifyStatus(pResult, True, True)
        Else
            UiComboBodega.DataSource = ListaDeBodegas
        End If
    End Sub

    Public Sub CargarPropiedades()
        Dim wsMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            ListaDePropiedades = wsMaterial.ObtenerPropiedadesDeMateriales(PublicLoginInfo.Environment)
            If ListaDePropiedades.TableName = "Operacion" Then
                MessageBox.Show(ListaDePropiedades(0)("Mensaje"))
            Else

                Dim xList = {New With {.Value = Tipos.Enums.GetStringValue(Estados.SiNo.No),
                       .Text = Estados.SiNo.No}, New With {.Value = Tipos.Enums.GetStringValue(Estados.SiNo.Si),
                       .Text = Estados.SiNo.Si}}.ToList()
                UiComboPropiedad.DataSource = ListaDePropiedades
                UiComboValor.DataSource = xList
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        Finally
            wsMaterial = Nothing
        End Try
    End Sub

    Public Function FilListView(limpiarPropiedadDeMaterial As Boolean)
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        GetUnitMesurement()
        CargarClientes()
        CargarClases()
        CargarSubClases()


        If limpiarPropiedadDeMaterial Then
            ClearBag_Materials()
        End If

        Me.Cursor = Cursors.Default
        Return True
    End Function

    Public Function GetUnitMesurement()
        Dim ListaDeUnidadesDeMedida As New DataTable

        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            ListaDeUnidadesDeMedida = xserv.GetUnitMesurement(Nothing, Nothing, PublicLoginInfo.Environment)
            If ListaDeUnidadesDeMedida.TableName = "Operacion" Then
                MessageBox.Show(ListaDeUnidadesDeMedida(0)("Mensaje"))
            Else
                UiContenedorVistasUnidadMedida.DataSource = ListaDeUnidadesDeMedida
            End If

        Catch ex As Exception
            ListaDeUnidadesDeMedida = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        ListaDeUnidadesDeMedida = Nothing
        xserv = Nothing
        Return True
    End Function

    Sub CalcVolume()
        Dim pFactor As Double
        Dim pAlto As Double
        Dim pLargo As Double
        Dim pAncho As Double
        Dim pMaterial As String = ""
        Dim pResult As String = ""
        Try
            pMaterial = GridViewFV.GetRowCellValue(GridViewFV.FocusedRowHandle, "MATERIAL_ID")
            pAlto = GridViewFV.GetRowCellValue(GridViewFV.FocusedRowHandle, "ALTO")
            pLargo = GridViewFV.GetRowCellValue(GridViewFV.FocusedRowHandle, "LARGO")
            pAncho = GridViewFV.GetRowCellValue(GridViewFV.FocusedRowHandle, "ANCHO")

        Catch ex As Exception

        End Try

        Try
            If pAlto >= 0.01 And pLargo >= 0.01 And pAncho >= 0.01 Then
                Cursor = Cursors.WaitCursor
                pFactor = pAlto * pLargo * pAncho
                Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

                xserv.UpdateVolumeFactor(pMaterial, pAlto, pLargo, pAncho, pFactor, pResult, PublicLoginInfo.Environment)

                If pResult = "OK" Then
                    GridViewFV.SetRowCellValue(GridViewFV.FocusedRowHandle, "VOLUME_FACTOR", pFactor)
                Else
                    NotifyStatus(pResult, True, True)
                End If
                Cursor = Cursors.Default

            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            NotifyStatus(ex.Message, True, True)

        End Try

        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pBIN As String = xdatarow(0).ToString
            ShowMaterial(pBIN)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim pResult As String = ""
        Dim xdataset As New DataSet
        Dim xgrp As New ListViewGroup

        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")


        Try
            xdataset = xserv.SearchPartialMaterials("", "", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControl1.DataSource = xdataset.Tables(0)
                GridControlVF.DataSource = xdataset.Tables(0)
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Try
            If (GridView1.FocusedRowHandle >= 0) Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pMaterial As String = xdatarow(1).ToString
                SelectedsKU = xdatarow("MATERIAL_ID").ToString
                ShowMaterial(SelectedsKU)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pID As String = xdatarow("MATERIAL_ID").ToString
                SelectedsKU = xdatarow("MATERIAL_ID").ToString
                ShowMaterial(SelectedsKU)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Sub ShowMaterial(ByVal pid As String)
        'ClearBag_Materials()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim settingsService As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim settingsDataSet As New DataSet
        Dim manejaMasterPackSettings As String = "0"

        settingsDataSet = settingsService.GetParam_ByParamKey("SISTEMA", "MASTER_PACK_SETTINGS", "HANDLE_MASTER_PACK", pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            manejaMasterPackSettings = settingsDataSet.Tables(0).Rows(0)("NUMERIC_VALUE")
        End If


        Dim xdata As DataSet = xserv.SearchByKeyMaterials(pid, pResult, PublicLoginInfo.Environment)


        If pResult = "OK" Then

            If manejaMasterPackSettings = 1 Then
                Bag_Materials_Class.SetBrowsableProperty("ManejaMasterPack", True)
                Bag_Materials_Class.SetBrowsableProperty("ManejaExplosionEnRecepcion", True)
            Else
                Bag_Materials_Class.SetBrowsableProperty("ManejaMasterPack", False)
                Bag_Materials_Class.SetBrowsableProperty("ManejaExplosionEnRecepcion", False)
            End If

            If xdata.Tables(0).Rows(0)("WEIGHT_MEASUREMENT").ToString <> "" Then
                Bag_Materials_Class.SetReadOnlyProperty("Peso", False)
            Else
                Bag_Materials_Class.SetReadOnlyProperty("Peso", True)
            End If

            '19-Jul-10 se creo campo Max_X_BIN
            With Bag_Materials_Class
                .Codigo = pid
                .CodigoBarras = xdata.Tables(0).Rows(0)("BARCODE_ID").ToString
                .Clase = xdata.Tables(0).Rows(0)("MATERIAL_CLASS").ToString
                .SubClase = xdata.Tables(0).Rows(0)("MATERIAL_SUB_CLASS").ToString
                .CodigoBarrasAlterno = xdata.Tables(0).Rows(0)("ALTERNATE_BARCODE").ToString
                .Descripcion = xdata.Tables(0).Rows(0)("MATERIAL_NAME").ToString
                .DescripcionCorta = xdata.Tables(0).Rows(0)("SHORT_NAME").ToString
                .FactorVolumen = IIf(IsDBNull(xdata.Tables(0).Rows(0)("VOLUME_FACTOR")), "0.00", xdata.Tables(0).Rows(0)("VOLUME_FACTOR"))
                .CantidadMaxPorBin = IIf(IsDBNull(xdata.Tables(0).Rows(0)("MAX_X_BIN")), "0.00", xdata.Tables(0).Rows(0)("MAX_X_BIN"))
                .Actualizado_el = xdata.Tables(0).Rows(0)("LAST_UPDATED").ToString
                .Actualizado_por = xdata.Tables(0).Rows(0)("LAST_UPDATED_BY").ToString
                .Alto = Val(xdata.Tables(0).Rows(0)("HIGH").ToString)
                .Ancho = Val(xdata.Tables(0).Rows(0)("WIDTH").ToString)
                .Cliente = xdata.Tables(0).Rows(0)("CLIENT_OWNER").ToString
                .Largo = Val(xdata.Tables(0).Rows(0)("LENGTH").ToString)
                .Peso = Val(xdata.Tables(0).Rows(0)("WEIGTH").ToString)
                .EsCarro = xdata.Tables(0).Rows(0)("IS_CAR").ToString
                .ManejaLote = xdata.Tables(0).Rows(0)("BATCH_REQUESTED").ToString
                .ManejaSerie = xdata.Tables(0).Rows(0)("SERIAL_NUMBER_REQUESTS").ToString
                .ManejaMasterPack = xdata.Tables(0).Rows(0)("IS_MASTER_PACK").ToString
                .UnidadPeso = xdata.Tables(0).Rows(0)("WEIGHT_MEASUREMENT").ToString
                .ManejaExplosionEnRecepcion = xdata.Tables(0).Rows(0)("EXPLODE_IN_RECEPTION").ToString
                .ManejaTono = xdata.Tables(0).Rows(0)("HANDLE_TONE").ToString
                .ManejaCalibre = xdata.Tables(0).Rows(0)("HANDLE_CALIBER").ToString
                .UsaLineaDePicking = xdata.Tables(0).Rows(0)("USE_PICKING_LINE").ToString
                .UsaControlDeCalidad = xdata.Tables(0).Rows(0)("QUALITY_CONTROL").ToString
                .ManejaSerieCorrelativa = xdata.Tables(0).Rows(0)("HANDLE_CORRELATIVE_SERIALS").ToString
                .PrefijoSerieCorrelativa = xdata.Tables(0).Rows(0)("PREFIX_CORRELATIVE_SERIALS").ToString
                .TiempoDeEspera = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LEAD_TIME")), "0.00", xdata.Tables(0).Rows(0)("LEAD_TIME"))
                .Proveedor = xdata.Tables(0).Rows(0)("SUPPLIER").ToString
                .NombreProveedor = xdata.Tables(0).Rows(0)("NAME_SUPPLIER").ToString
                .ToleranciaDeExpiracion = IIf(IsDBNull(xdata.Tables(0).Rows(0)("EXPIRATION_TOLERANCE")), "0.00", xdata.Tables(0).Rows(0)("EXPIRATION_TOLERANCE"))


            End With

                CargarEmpaqueDeMaterial(0, xdata.Tables(0).Rows(0)("CLIENT_OWNER").ToString, pid, "", 1, "", "")

                UiPropiedadDeDatosGenerales.SelectedObject = Bag_Materials_Class
                UiPropiedadDeDatosGenerales.Refresh()
                xdata = xserv.GetRelatedLocations(pid, pResult, PublicLoginInfo.Environment)

                CargarMasterPack()
                CargarExcepcionesPorBodega(pid)

                'Manejo visibilidad de pestania Unidad de medida (Empaque)
                If (Bag_Materials_Class.ManejaMasterPack.Equals("SI") Or Bag_Materials_Class._IS_CAR.Equals("SI") Or Bag_Materials_Class.ManejaSerie.Equals("SI")) Then
                    UiTabEmpaque.PageVisible = False
                Else
                    UiTabEmpaque.PageVisible = True
                End If

                If pResult = "OK" Then
                    Me.GridControl2.DataSource = xdata.Tables(0)
                    GridView2.ExpandAllGroups()
                Else
                    Me.GridControl2.DataSource = Nothing
                End If
                'Empaques de almacenamiento

            Else
                MessageBox.Show(pResult)
        End If
    End Sub

    Private Sub LoadStoragePackagingList(ByVal materialId As String, ByVal paramName As String)
        Dim packSer As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim packageDataTable As DataTable = packSer.GetStoragePackaging(materialId, paramName, PublicLoginInfo.Environment)
        UiStoragePackaging.DataSource = packageDataTable
    End Sub

    Private Sub GridControlVF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControlVF.Click
        Try
            Dim xdatarow As DataRow = GridViewFV.GetDataRow(GridView1.FocusedRowHandle)
            Dim pBIN As String = xdatarow("MATERIAL_ID").ToString
            ShowMaterial(pBIN)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Private Sub GridViewFV_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridViewFV.KeyUp
        Try
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                Dim xdatarow As DataRow = GridViewFV.GetDataRow(GridView1.FocusedRowHandle)
                Dim pID As String = xdatarow("MATERIAL_ID").ToString
                ShowMaterial(pID)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RepositoryItemSpinEdit1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.Leave
        CalcVolume()
    End Sub

    Private Sub RepositoryItemSpinEdit2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit2.Leave
        CalcVolume()
    End Sub

    Private Sub RepositoryItemSpinEdit3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit3.Leave
        CalcVolume()
    End Sub

    Private Sub CalcStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GridControl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub lnkDeleteLocationSpot_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub



    Private Sub btnDeleteMatXLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim pMaterial As String = ""
        Try

            Dim pLocation As String, pWarehouse As String
            Dim pResult As String = ""

            If GridView2.IsFilterRow(Me.GridView2.FocusedRowHandle) Then
                Exit Sub
            End If

            If Me.GridView2.SelectedRowsCount <= 0 Then
                Exit Sub
            End If
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")


            'If MessageBox.Show("Confirma eliminar la relacion producto-ubicacion?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, False) = DialogResult.No Then
            '    Exit Sub
            'End If

            If XtraMessageBox.Show("Confirma eliminar la relacion producto-ubicacion?", "Swift 3PL", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                For i = 0 To Me.GridView2.RowCount - 1
                    If GridView2.IsRowSelected(i) Then

                        pLocation = GridView2.GetRowCellValue(i, "LOCATION_SPOT")
                        pWarehouse = GridView2.GetRowCellValue(i, "WAREHOUSE_PARENT")

                        If Not xserv.DeleteMaterials_X_Location(Bag_Materials_Class.Codigo, pWarehouse, pLocation, pResult, PublicLoginInfo.Environment) Then
                            MessageBox.Show(pResult)
                        End If

                    End If
                Next
                ShowMaterial(Bag_Materials_Class.Codigo)
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xfrm As New frmAddNewLocation
        xfrm.lblProd.Text = Bag_Materials_Class.Codigo
        xfrm.lblProdDesc.Text = Bag_Materials_Class.Descripcion
        xfrm.ShowDialog()
        ShowMaterial(Bag_Materials_Class.Codigo)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xrow As DataRow
        Dim j As Integer = 0
        Try
            If GridView1.SelectedRowsCount >= 1 Then
                Dim xfrmPrt As New frmPrintLabels
                frmPrintLabels.ShowDialog()

                Dim pd As New PrintDialog()
                pd.PrinterSettings = New PrinterSettings()
                If (pd.ShowDialog() = DialogResult.OK) Then
                    For i = 0 To GridView1.RowCount - 1
                        If GridView1.IsRowSelected(i) Then
                            xrow = GridView1.GetDataRow(i)
                            Dim pCode As String = IIf(IsDBNull(xrow("BARCODE_ID")), "", xrow("BARCODE_ID"))
                            Dim pDesc As String = IIf(IsDBNull(xrow("MATERIAL_NAME")), "", xrow("MATERIAL_NAME"))
                            For j = 1 To pd.PrinterSettings.Copies
                                PrintGroupLabel(gLabelSize, pCode, pDesc, pd.PrinterSettings.PrinterName)
                            Next

                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnUpdateJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim xdatarow As DataRow = Nothing

        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            Cursor = Cursors.WaitCursor
            For i = 0 To GridView2.RowCount - 1
                xdatarow = GridView2.GetDataRow(i)
                Try
                    If Not xserv.Update_Join_SpotLocations(xdatarow("MATERIAL_ID"), xdatarow("WAREHOUSE_PARENT"), xdatarow("LOCATION_SPOT"),
                                                           PublicLoginInfo.LoginID, IIf(IsDBNull(xdatarow("MIN_QUANTITY")), 0, xdatarow("MIN_QUANTITY")),
                                                           IIf(IsDBNull(xdatarow("MAX_QUANTITY")), 0, xdatarow("MAX_QUANTITY")),
                                                           pResult, PublicLoginInfo.Environment) Then
                        MessageBox.Show(pResult)
                        Exit For
                    End If
                Catch ex As Exception

                End Try
            Next

            MessageBox.Show("Proceso Completado, registros actualizados", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message + " " + pResult)
        End Try
    End Sub


    Sub PrintGroupLabel(ByVal pSize As String, ByVal pCode As String, ByVal pName As String, ByVal pPrinterName As String)
        Dim pStr As String = ""

        ObtenerFormatoDeImprecion(pSize, pStr, pName, pCode)
        RawPrinterHelper1.SendStringToPrinter(pPrinterName, pStr)
    End Sub

    Public Function GetPrintLines(ByVal pSize As String, ByRef pLine1 As String, ByRef pLine2 As String, ByRef pLine3 As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_ETIQUETAS", pSize, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                pLine1 = xds.Tables(0).Rows(0)("TEXT_VALUE")
                pLine2 = xds.Tables(0).Rows(0)("SPARE1")
                pLine3 = xds.Tables(0).Rows(0)("SPARE2")
            Else
                pLine1 = "^LH40,2^LL250"
                pLine2 = "^F10,10^ADN,2,03^FN2^FS(Producto#)"
                pLine3 = "^F10,50^BY2^B2N,N,30,N,N^FN4^FS(barcode)"
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function

    Sub ObtenerFormatoDeImprecion(ByVal pSize As String, ByRef pStr As String, ByVal pName As String, ByVal pCode As String)
        'Cambio parametros de impresion
        Dim pLine1 As String = "", pLine2 As String = "", pLine3 As String = ""

        pStr = "^XA"
        pStr = pStr + " ^DFR:SAMPLE.GRF"
        pStr = pStr + " ^FS"

        Call GetPrintLines(pSize, pLine1, pLine2, pLine3)

        pStr = pStr + pLine1
        pStr = pStr + pLine2
        pStr = pStr + pLine3

        pStr = pStr + " ^XZ"
        pStr = pStr + " ^XA"
        pStr = pStr + " ^XFR:SAMPLE.GRF"
        pStr = pStr + " ^FN2^FD" + pName + "^FS"
        pStr = pStr + " ^FN4^FD" + pCode + "^FS"
        pStr = pStr + " ^XZ"
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs)
        Try

            Try
                SaveFileDialog1.DefaultExt = "xlsx"
                SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    GridView1.ExportToXlsx(SaveFileDialog1.FileName)
                End If

            Catch ex As Exception
                NotifyStatus("Error : " & ex.Message, True, True)
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XtraTabPage3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub UiContenedorVistasUnidadMedida_Click(sender As Object, e As EventArgs) Handles UiContenedorVistasUnidadMedida.Click

    End Sub

    Private Sub UIVistaUnidadMedida_Click(sender As Object, e As EventArgs) Handles UIVistaUnidadMedida.Click
        Try
            If (UIVistaUnidadMedida.FocusedRowHandle >= 0) Then
                Dim fila As DataRow = UIVistaUnidadMedida.GetDataRow(UIVistaUnidadMedida.FocusedRowHandle)
                ShowMaterial(fila(2).ToString)

                CargarEmpaqueDeMaterial(fila)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarEmpaqueDeMaterial(fila As DataRow)
        Try
            Dim empaque As Empaque = New Empaque()

            'Cargar empaque de material (unidad de medida por parametros generales (PARAM_TYPE: ALMACENAMIENTO, PARAM_GROUP: TIPOS_EMPAQUE))
            LoadStoragePackagingList(fila(2).ToString, fila(3).ToString)

            empaque.codigo = fila(0).ToString
            empaque.codigoDeCliente = fila(1).ToString
            empaque.codigoDeMaterial = fila(2).ToString
            empaque.empaque = fila(3).ToString

            empaque.cantidad = fila(5).ToString
            empaque.codigoDeBarras = fila(6).ToString
            empaque.codigoDeBarrasAlternativo = fila(7).ToString

            UiPropiedadDeEmpaque.SelectedObject = empaque

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarEmpaqueDeMaterial(codigo As Int32, codigoDeCliente As String, codigoDeMaterial As String, empaque As String, cantidad As Int32, codigoDeBarras As String, codigoDeBarrasAlternativo As String)
        Try
            Dim _empaque As Empaque = New Empaque()

            'Cargar empaque de material (unidad de medida por parametros generales (PARAM_TYPE: ALMACENAMIENTO, PARAM_GROUP: TIPOS_EMPAQUE))
            LoadStoragePackagingList(codigoDeMaterial, empaque)

            _empaque.codigo = codigo
            _empaque.codigoDeCliente = codigoDeCliente
            _empaque.codigoDeMaterial = codigoDeMaterial
            _empaque.empaque = empaque
            _empaque.cantidad = cantidad
            _empaque.codigoDeBarras = codigoDeBarras
            _empaque.codigoDeBarrasAlternativo = codigoDeBarrasAlternativo

            UiPropiedadDeEmpaque.SelectedObject = _empaque

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarEmpaqueDeMaterial(empaque As Empaque)
        Try
            UiPropiedadDeEmpaque.SelectedObject = empaque
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function UsuarioDeseaGuardarEmpaque(empaque As Empaque)
        Dim Operacion As New DataTable

        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

        Try
            Dim number As Integer
            Dim isNumeric As Boolean = Int32.TryParse(empaque.cantidad, number)
            If Not isNumeric Then
                MessageBox.Show("no es entero")
            End If

            If empaque.codigo = 0 Then
                Operacion = xserv.CreateMaterialUnitMesurement(empaque.codigoDeCliente, empaque.codigoDeMaterial, empaque.empaque, empaque.cantidad, empaque.codigoDeBarras, empaque.codigoDeBarrasAlternativo, PublicLoginInfo.Environment)
                If Operacion(0)("Resultado") = 1 Then
                    empaque.codigo = Convert.ToInt32(Operacion(0)("DbData"))
                End If
            Else
                Operacion = xserv.UpdateMaterialUnitMesurement(empaque.codigo, empaque.codigoDeCliente, empaque.codigoDeMaterial, empaque.empaque, empaque.cantidad, empaque.codigoDeBarras, empaque.codigoDeBarrasAlternativo, PublicLoginInfo.Environment)
            End If

            If Operacion(0)("Resultado") = 1 Then
                GetUnitMesurement()
            Else
                MessageBox.Show(Operacion(0)("Mensaje"))
            End If

        Catch ex As Exception
            Operacion = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        Operacion = Nothing
        xserv = Nothing
        Return True
    End Function

    Public Function UsuarioDeseaEliminarEmpaque(empaque As Empaque)
        Dim Operacion As New DataTable

        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            Operacion = xserv.DeleteMaterialUnitMesurement(empaque.codigo, PublicLoginInfo.Environment)

            If Operacion(0)("Resultado") = 1 Then
                CargarEmpaqueDeMaterial(0, empaque.codigoDeCliente, empaque.codigoDeMaterial, "", 1, "", "")
                GetUnitMesurement()
                SearchByPartial()
            Else
                MessageBox.Show(Operacion(0)("Mensaje"))
            End If
        Catch ex As Exception
            Operacion = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        Operacion = Nothing
        xserv = Nothing
        Return True
    End Function

    Private Sub UiBotonAgregarEmpaque_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonAgregarEmpaque.ItemClick
        NuevoEmpaque()
    End Sub

    Private Sub NuevoEmpaque()

        Try
            Dim empaque As Empaque = UiPropiedadDeEmpaque.SelectedObject

            If empaque Is Nothing Then
                MessageBox.Show("Debe de selecionar un material para asociarle un empaque")
            Else
                CargarEmpaqueDeMaterial(0, empaque.codigoDeCliente, empaque.codigoDeMaterial, "", 1, "", "")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UiBotonElimnarEmpaque_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonElimnarEmpaque.ItemClick
        Try
            Dim empaque As Empaque = UiPropiedadDeEmpaque.SelectedObject

            If empaque Is Nothing Then
                MessageBox.Show("Debe de selecionar un material y empaque para desasociarle un empaque")
            Else
                UsuarioDeseaEliminarEmpaque(empaque)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UiBotonGuardarEmpaque_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGuardarEmpaque.ItemClick
        Dim empaque As Empaque = UiPropiedadDeEmpaque.SelectedObject
        Try
            If ValidarEmpaqueParaGuardar(empaque, UiPropiedadDeEmpaque.ActiveEditor.ErrorText) Then
                UsuarioDeseaGuardarEmpaque(empaque)
            End If
        Catch ex As NullReferenceException
            If ValidarEmpaqueParaGuardar(empaque, "") Then
                UsuarioDeseaGuardarEmpaque(empaque)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ValidarEmpaqueParaGuardar(ByVal empaque As Empaque, ByVal errorEnPropiedad As String) As Boolean
        If empaque Is Nothing Then
            MessageBox.Show("Debe de selecionar un material para asociarle un empaque")
            Return False
        End If

        If errorEnPropiedad <> "" Then
            MessageBox.Show("Debe ingresar una cantidad con valor numerico entero y mayor a cero")
            Return False
        End If

        If empaque.cantidad < 1 Then
            MessageBox.Show("La cantidad debe de ser mayor o igual a 1")
            Return False
        End If

        'If empaque.empaque.Trim() = "" Then
        If UiStoragePackaging.ValueMember.ToString() = "" Then
            MessageBox.Show("Debe de ingresar el empaque")
            Return False
        End If

        If empaque.codigoDeBarras.Trim() = "" Then
            MessageBox.Show("Debe de ingresar el codigo de barras")
            Return False
        End If

        Return True
    End Function

    Private Sub UiBotonExportarEmpaquesExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExportarEmpaquesExcel.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                UIVistaUnidadMedida.ExportToXlsx(SaveFileDialog1.FileName)
            End If

        Catch ex As Exception
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub UiBotonImprimirEmpaque_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonImprimirEmpaque.ItemClick
        Try
            Dim xrow As DataRow
            Dim j As Integer = 0
            Dim imprimirCodigoDeBarrasAlternativo As Boolean = False


            If UIVistaUnidadMedida.SelectedRowsCount >= 1 Then

                Dim escogerCodigodEbARRAS As New frmChooseMeasurement
                frmChooseMeasurement.ShowDialog()
                imprimirCodigoDeBarrasAlternativo = (gLabelSize = "codigoDeBarrasAlternativo")

                Dim xfrmPrt As New frmPrintLabels
                frmPrintLabels.ShowDialog()

                Dim pd As New PrintDialog()
                pd.PrinterSettings = New PrinterSettings()
                If (pd.ShowDialog() = DialogResult.OK) Then
                    For i = 0 To UIVistaUnidadMedida.RowCount - 1
                        If UIVistaUnidadMedida.IsRowSelected(i) Then
                            xrow = UIVistaUnidadMedida.GetDataRow(i)
                            Dim pCode As String = IIf(imprimirCodigoDeBarrasAlternativo, xrow(6).ToString, xrow(5).ToString)
                            Dim pDesc As String = xrow(3).ToString
                            For j = 1 To pd.PrinterSettings.Copies
                                PrintGroupLabel(gLabelSize, pCode, pDesc, pd.PrinterSettings.PrinterName)
                            Next

                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs)

        If e.ChangedItem.Label.ToString = "UnidadPeso" Then
            If e.ChangedItem.Value <> "" Then
                Bag_Materials_Class.SetReadOnlyProperty("Peso", False)
                UiPropiedadDeDatosGenerales.Refresh()
            End If
        End If

    End Sub

    Private Sub UiBotonNuevo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonNuevo.ItemClick
        ClearBag_Materials()
    End Sub

    Private Sub UiBotonGuardar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGuardar.ItemClick
        SaveAndRefresh()
    End Sub

    Private Sub UiBotonEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonEliminar.ItemClick
        Dim pResult As String = ""
        Dim pResponse As DialogResult = DialogResult.No

        If Not IsNothing(Bag_Materials_Class.Cliente) And Not IsNothing(Bag_Materials_Class.Codigo) Then
            pResponse = MessageBox.Show("Confirma eliminacion?", "Confirme accion", MessageBoxButtons.YesNo)
            If pResponse = DialogResult.Yes Then


                Dim xrow As DataRow
                Try
                    If GridView1.SelectedRowsCount >= 1 Then

                        For i = 0 To GridView1.RowCount - 1
                            If GridView1.IsRowSelected(i) Then
                                xrow = GridView1.GetDataRow(i)
                                Bag_Materials_Class.Cliente = IIf(IsDBNull(xrow("CLIENT_OWNER")), "", xrow("CLIENT_OWNER"))
                                Bag_Materials_Class.Codigo = IIf(IsDBNull(xrow("MATERIAL_ID")), "", xrow("MATERIAL_ID"))
                                If Not Bag_Materials_Class.Delete(pResult) Then
                                    Cursor = Cursors.Default
                                    MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            End If
                        Next
                        FilListView(True)
                        ClearBag_Materials()
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try


            End If
        End If
    End Sub

    Private Sub UiBotonImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonImprimir.ItemClick
        Dim xrow As DataRow
        Dim j As Integer = 0
        Try
            If GridView1.SelectedRowsCount >= 1 Then
                Dim xfrmPrt As New frmPrintLabels
                frmPrintLabels.ShowDialog()

                Dim pd As New PrintDialog()
                pd.PrinterSettings = New PrinterSettings()
                If (pd.ShowDialog() = DialogResult.OK) Then
                    For i = 0 To GridView1.RowCount - 1
                        If GridView1.IsRowSelected(i) Then
                            xrow = GridView1.GetDataRow(i)
                            Dim pCode As String = IIf(IsDBNull(xrow("BARCODE_ID")), "", xrow("BARCODE_ID"))
                            Dim pDesc As String = IIf(IsDBNull(xrow("MATERIAL_NAME")), "", xrow("MATERIAL_NAME"))
                            For j = 1 To pd.PrinterSettings.Copies
                                PrintGroupLabel(gLabelSize, pCode, pDesc, pd.PrinterSettings.PrinterName)
                            Next

                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UiBotonExportarExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExportarExcel.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                GridView1.ExportToXlsx(SaveFileDialog1.FileName)
            End If

            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
            args.AutoCloseOptions.Delay = 3000
            args.Caption = "Operación exitosa"
            args.Text = "Archivo generado exitósamente, ¿Desea abrir el archivo?"
            args.Buttons = {DialogResult.Yes, DialogResult.No}
            args.Icon = System.Drawing.SystemIcons.Question
            args.DefaultButtonIndex = 0
            args.AutoCloseOptions.ShowTimerOnDefaultButton = True

            If (XtraMessageBox.Show(args) = DialogResult.Yes) Then
                Process.Start(SaveFileDialog1.FileName)
            End If

        Catch ex As Exception
            NotifyStatus("Error : " & ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonNuevaUbicacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonNuevaUbicacion.ItemClick
        Dim xfrm As New frmAddNewLocation
        Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        xfrm.lblProd.Text = xdatarow("MATERIAL_ID")
        xfrm.lblProdDesc.Text = xdatarow("MATERIAL_NAME")
        xfrm.ShowDialog()
        SelectedsKU = xdatarow("MATERIAL_ID").ToString
        ShowMaterial(SelectedsKU)
    End Sub

    Private Sub UiBotonEliminarUbicacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonEliminarUbicacion.ItemClick
        Dim pMaterial As String = ""
        Try

            Dim pLocation As String, pWarehouse As String
            Dim pResult As String = ""

            If GridView2.IsFilterRow(Me.GridView2.FocusedRowHandle) Then
                Exit Sub
            End If

            If Me.GridView2.SelectedRowsCount <= 0 Then
                Exit Sub
            End If
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

            If XtraMessageBox.Show("Confirma eliminar la relacion producto-ubicacion?", "Swift 3PL", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GridView2.ExpandAllGroups()
                For i = 0 To Me.GridView2.RowCount - 1
                    If GridView2.IsRowSelected(i) Then

                        pLocation = GridView2.GetRowCellValue(i, "LOCATION_SPOT")
                        pWarehouse = GridView2.GetRowCellValue(i, "WAREHOUSE_PARENT")

                        If Not xserv.DeleteMaterials_X_Location(SelectedsKU, pWarehouse, pLocation, pResult, PublicLoginInfo.Environment) Then
                            MessageBox.Show(pResult)
                        End If

                    End If
                Next
                ShowMaterial(SelectedsKU)
                Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub UiBotonGrabarUbicacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGrabarUbicacion.ItemClick
        Dim xdatarow As DataRow = Nothing
        Dim errorFlag As Boolean = True
        Dim pResult As String = ""
        Dim dataMala = 0
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            Cursor = Cursors.WaitCursor
            GridView2.ExpandAllGroups()
            For i = 0 To GridView2.RowCount - 1
                xdatarow = GridView2.GetDataRow(i)
                Try
                    If Not xdatarow Is Nothing Then
                        If IIf(IsDBNull(xdatarow("MIN_QUANTITY")), 0, xdatarow("MIN_QUANTITY")) <= IIf(IsDBNull(xdatarow("MAX_QUANTITY")), 0, xdatarow("MAX_QUANTITY")) Then
                            If Not xserv.Update_Join_SpotLocations(xdatarow("MATERIAL_ID"), xdatarow("WAREHOUSE_PARENT"),
                                                                xdatarow("LOCATION_SPOT"), PublicLoginInfo.LoginID, IIf(IsDBNull(xdatarow("MIN_QUANTITY")), 0,
                                                                   xdatarow("MIN_QUANTITY")), IIf(IsDBNull(xdatarow("MAX_QUANTITY")), 0, xdatarow("MAX_QUANTITY")),
                                                                 pResult, PublicLoginInfo.Environment) Then
                                errorFlag = False
                                MessageBox.Show(pResult)
                                Exit For
                            End If
                        Else
                            dataMala = 1
                        End If

                    End If


                Catch ex As Exception
                    errorFlag = False
                    MessageBox.Show("Error inesperado: " + ex.Message)
                    Exit For
                End Try
            Next

            If dataMala = 1 Then
                errorFlag = False
                Dim lineas = ""
                For j = 0 To GridView2.RowCount - 1
                    xdatarow = GridView2.GetDataRow(j)
                    If Not xdatarow Is Nothing Then
                        If Not IIf(IsDBNull(xdatarow("MIN_QUANTITY")), 0, xdatarow("MIN_QUANTITY")) <= IIf(IsDBNull(xdatarow("MAX_QUANTITY")), 0, xdatarow("MAX_QUANTITY")) Then
                            If lineas = "" Then
                                lineas = j + 1
                            Else
                                lineas = lineas & ", " & (j + 1)
                            End If

                        End If
                    End If
                Next
                If lineas <> "" Then
                    MessageBox.Show("Error, Inv. Min debe ser menor a Inv Max linea: " + lineas)
                End If

            End If

            If errorFlag Then
                MessageBox.Show("Proceso Completado, registros actualizados", "3PL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ShowMaterial(SelectedsKU)
            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message + " " + pResult)
        End Try
    End Sub

    Private Sub UiBotonDescargarPlantillaEnDatosGenerales_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDescargarPlantillaEnDatosGenerales.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBotonCargarPlantillaEnDatosGenerales_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCargarPlantillaEnDatosGenerales.ItemClick
        CargarPlantilla()
    End Sub

    Private Sub UiBotonDescargarPlantillaEnUbicacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDescargarPlantillaEnUbicacion.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBotonCargarPlantillaEnUbicacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCargarPlantillaEnUbicacion.ItemClick
        CargarPlantilla()
    End Sub

    Private Sub UiBotonDescargarPlantillaEnMasterPack_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDescargarPlantillaEnMasterPack.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBotonCargarPlantillaEnMasterPack_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCargarPlantillaEnMasterPack.ItemClick
        CargarPlantilla()
    End Sub

    Private Sub CargarClientes()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""

        Try
            xdataset = xserv.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiListaDeClientes.DataSource = xdataset.Tables(0)
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarClases()
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

        Dim xtable As DataTable
        Dim pResult = ""

        Try
            xtable = xserv.ObtenerClasesParaMaterial(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiListaClases.DataSource = xtable
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarSubClases()
        Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")

        Dim xtable As DataTable
        Dim pResult = ""

        Try
            xtable = xserv.ObtenerSubClasesParaMaterial(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                UiListaSubClases.DataSource = xtable
            Else
                NotifyStatus(pResult, False, True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarExcepcionesPorBodega(material)
        Dim wsMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Try
            PropiedadesDelMaterialSelecionado = wsMaterial.ObtenerPropiedadesDeMaterialPorBodega(material, PublicLoginInfo.Environment)
            If PropiedadesDelMaterialSelecionado.TableName = "Operacion" Then
                MessageBox.Show(PropiedadesDelMaterialSelecionado(0)("Mensaje"))
            Else
                UiContenedorExcepcionesPorBodega.DataSource = PropiedadesDelMaterialSelecionado
                UiVistaExcepcionPorBodega.ActiveFilter.Clear()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        Finally
            wsMaterial = Nothing
        End Try
    End Sub
#Region "Master Pack"

    Private Sub CargarMasterPack()
        Dim pResult As String
        Dim settingsService As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim settingsDataSet As New DataSet
        Dim manejaMasterPackSettings As String = "0"

        settingsDataSet = settingsService.GetParam_ByParamKey("SISTEMA", "MASTER_PACK_SETTINGS", "HANDLE_MASTER_PACK", pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            manejaMasterPackSettings = settingsDataSet.Tables(0).Rows(0)("NUMERIC_VALUE")
        End If

        If manejaMasterPackSettings = 1 Then
            If Bag_Materials_Class.ManejaMasterPack.Equals("NO") Then
                UiTabMasterPack.PageVisible = False
            Else
                UiTabMasterPack.PageVisible = True
                CargarComponentesDisponibles()
                CargarComponentesAsociados()
            End If
        Else
            UiTabMasterPack.PageVisible = False
            UiTabEmpaque.PageVisible = True
        End If
    End Sub

    Private Sub CargarComponentesDisponibles()
        Dim serviceMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim resultado As String
        UiListaComponenteMaterial.Properties.DataSource = serviceMaterial.GetMaterialsForMasterPackComponentByClient(Bag_Materials_Class.Cliente, Bag_Materials_Class.Codigo, resultado, PublicLoginInfo.Environment)
        If Not resultado.Equals("OK") Then
            NotifyStatus(resultado, False, True)
        End If
    End Sub

    Private Sub CargarComponentesAsociados()
        Dim serviceMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim resultado As String
        UiContenedorDeVistasComponentes.DataSource = serviceMaterial.GetMaterialsComponentsMasterPack(Bag_Materials_Class.Codigo, resultado, PublicLoginInfo.Environment)
        If Not resultado.Equals("OK") Then
            NotifyStatus(resultado, False, True)
        End If
    End Sub

    Private Sub UiListaComponenteMaterial_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaComponenteMaterial.ButtonClick
        Select Case e.Button.Tag
            Case "UiComponenteRefrescar"
                CargarComponentesDisponibles()
                Exit Select
        End Select

    End Sub


    Dim usuarioSeleccionoListaComponentesCompleta As Boolean = False

    Private Sub UiListaVistaComponenteMaterial_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles UiListaVistaComponenteMaterial.SelectionChanged
        If e.ControllerRow >= 0 Then
            Dim fila As DataRow
            fila = UiListaVistaComponenteMaterial.GetDataRow(e.ControllerRow)
            fila("IS_SELECT") = (e.Action = CollectionChangeAction.Add)
        Else
            If usuarioSeleccionoListaComponentesCompleta Then
                For i = 0 To UiListaVistaComponenteMaterial.RowCount - 1
                    Dim fila As DataRow
                    fila = UiListaVistaComponenteMaterial.GetDataRow(i)
                    If Not fila Is Nothing Then
                        fila("IS_SELECT") = (Not UiListaVistaComponenteMaterial.SelectedRowsCount = 0)
                    End If
                Next
                usuarioSeleccionoListaComponentesCompleta = False
            End If
        End If

        Dim edit = TryCast(ActiveControl, DevExpress.XtraEditors.SearchLookUpEdit)
        If Not edit Is Nothing Then
            edit.Text = ObtenerTextoAMostrarListaComponentes()
        End If
    End Sub

    Private Sub UiListaComponenteMaterial_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles UiListaComponenteMaterial.CustomDisplayText
        e.DisplayText = ObtenerTextoAMostrarListaComponentes()
    End Sub

    Private Sub UiListaVistaComponenteMaterial_MouseUp(sender As Object, e As MouseEventArgs) Handles UiListaVistaComponenteMaterial.MouseUp

        Dim view As GridView = TryCast(sender, GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))
        If (hi.HitTest = GridHitTest.Column OrElse hi.HitTest = GridHitTest.GroupPanelColumn) AndAlso hi.Column.Name.Equals("DX$CheckboxSelectorColumn") Then
            usuarioSeleccionoListaComponentesCompleta = True
        End If
    End Sub

    Private Sub UiListaVistaComponenteMaterial_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles UiListaVistaComponenteMaterial.BeforeLeaveRow
        For i = 0 To UiListaVistaComponenteMaterial.RowCount - 1
            Dim fila As DataRow
            fila = UiListaVistaComponenteMaterial.GetDataRow(i)
            If Not fila Is Nothing Then
                If fila("IS_SELECT") = 1 Then
                    UiListaVistaComponenteMaterial.SelectRow(i)
                End If
            End If
        Next
    End Sub

    Private Function ObtenerTextoAMostrarListaComponentes() As String
        Dim cadena As New StringBuilder
        cadena.Append("")
        If Not UiListaComponenteMaterial.Properties.DataSource Is Nothing Then

            For i = 0 To UiListaVistaComponenteMaterial.RowCount - 1
                Dim fila As DataRow
                fila = UiListaVistaComponenteMaterial.GetDataRow(i)
                If Not fila Is Nothing Then
                    If fila("IS_SELECT") = 1 Then
                        If cadena.Length > 0 Then
                            cadena.Append(",")
                        End If
                        cadena.Append(fila("MATERIAL_ID"))
                    End If
                End If
            Next
        End If
        Return cadena.ToString()
    End Function

    Private Sub UiBotonAgregarCompononente_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonAgregarCompononente.ItemClick
        If Not UiListaComponenteMaterial.Properties.DataSource Is Nothing Then
            If UiSpinComponenteCantidad.Value <= 0 Then
                NotifyStatus("La cantidad tiene que se mayor a cero.", True, True)
                UiSpinComponenteCantidad.Focus()
            Else
                AgregarComponentes()
            End If
        End If
    End Sub

    Private Sub AgregarComponentes()
        Try
            Dim resultado As String = ""
            Dim serviceMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            Dim dt As DataTable
            dt = TryCast(UiListaComponenteMaterial.Properties.DataSource, DataTable)
            If (From fila As DataRow In dt.Rows Where Not fila Is Nothing Where fila("IS_SELECT") = 1 Where serviceMaterial.InsertMasterPackComponent(Bag_Materials_Class.Codigo, fila("MATERIAL_ID"), UiSpinComponenteCantidad.Value, resultado, PublicLoginInfo.Environment)).Any(Function(fila) Not resultado.Equals("OK")) Then
                NotifyStatus(resultado, True, True)
                Return
            End If
            CargarComponentesDisponibles()
            CargarComponentesAsociados()
            UiSpinComponenteCantidad.Value = 0
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonEliminarComponente_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiBotonEliminarComponente.ButtonClick
        EliminarComponente()
    End Sub


    Private Sub EliminarComponente()
        Try
            If (UiVistaComponentesAsociados.FocusedRowHandle >= 0) Then
                Dim resultado As String = ""
                Dim serviceMaterial As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
                Dim fila As DataRow
                fila = UiVistaComponentesAsociados.GetDataRow(UiVistaComponentesAsociados.FocusedRowHandle)

                If serviceMaterial.DeleteMasterPackComponent(fila("MASTER_PACK_COMPONENT_ID"), resultado, PublicLoginInfo.Environment) Then
                    If Not resultado.Equals("OK") Then
                        NotifyStatus(resultado, True, True)
                    Else
                        CargarComponentesDisponibles()
                        CargarComponentesAsociados()
                    End If
                Else
                    NotifyStatus(resultado, True, True)
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub


#End Region

#Region "Plantilla"
    Private Sub DescargarPlantilla()
        Try
            Dim dialogoGuardar As New SaveFileDialog()
            dialogoGuardar.Filter = "Excel xlsx (*.xlsx)|*.xlsx"
            dialogoGuardar.FilterIndex = 2
            dialogoGuardar.RestoreDirectory = True
            dialogoGuardar.Title = "Guardar plantilla"

            If dialogoGuardar.ShowDialog() = DialogResult.OK Then
                Dim path As String = dialogoGuardar.FileName

                Dim workbook = New XLWorkbook()
                Dim hojaDeMaterial As IXLWorksheet = workbook.Worksheets.Add("Material")
                Dim hojaDeUbicacion As IXLWorksheet = workbook.Worksheets.Add("Ubicacion")
                Dim hojaDeUnidadDeMedida As IXLWorksheet = workbook.Worksheets.Add("UnidadDeMedida")
                Dim hojaDeMasterPack As IXLWorksheet = workbook.Worksheets.Add("MasterPack")
                Dim hojaDePropiedades As IXLWorksheet = workbook.Worksheets.Add("PropiedadesPorBodega")
                'worksheet.Protect("Mobility2016$$")

                Dim inicioEncabezadoX As Integer = 1
                Dim inicioEncabezadoY As Integer = 1
                Dim numeroDeFilas As Integer = 500

                GenerarHojaDeDatosGenerales(hojaDeMaterial, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                GenerarHojaDeUbicacion(hojaDeUbicacion, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                GenerarHojaDeUnidadDeMedida(hojaDeUnidadDeMedida, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                GenerarHojaDeMasterPack(hojaDeMasterPack, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                GenerarHojaDePropiedadesDeMateriales(hojaDePropiedades, inicioEncabezadoX, inicioEncabezadoY, numeroDeFilas)
                'Guardar Excel
                If (File.Exists(path)) Then
                    System.IO.File.Delete(path)
                End If
                workbook.SaveAs(path)

                ' Abrir excel
                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                args.AutoCloseOptions.Delay = 3000
                args.Caption = "Operación exitosa"
                args.Text = "Archivo generado exitósamente, ¿Desea abrir el archivo?"
                args.Buttons = {DialogResult.Yes, DialogResult.No}
                args.Icon = System.Drawing.SystemIcons.Question
                args.DefaultButtonIndex = 0
                args.AutoCloseOptions.ShowTimerOnDefaultButton = True

                If (XtraMessageBox.Show(args) = DialogResult.Yes) Then
                    Process.Start(path)
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GenerarHojaDeDatosGenerales(hojaDeMaterial As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try
            Dim columnas = New String() {"CantidadMaxPorBin", "Clase", "Cliente", "Codigo", "CodigoBarras", "CodigoBarrasAlterno", "Descripcion", "DescripcionCorta", "EsCarro", "ManejaExplosionEnRecepcion", "ManejaLote", "ManejaMasterPack", "ManejaSerie", "UnidadPeso", "Alto", "Ancho", "FactorVolumen", "Largo", "Peso", "UsaLineaPicking",
                "ManejaSerieCorrelativa", "PrefijoSerieCorrelativa", "TiempoEsperaEnDias", "Proveedor", "NombreProveedor", "SubClase"}
            Dim unidadDePesoPorDefecto = ObtenerUnidadDePesoPorDefecto()

            'Encabezado Tabla
            For j = 0 To columnas.Count - 1
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hojaDeMaterial.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            'Se agregan los valores para la validacion SI y NO
            hojaDeMaterial.Cell("BZ1").Value = MobilityScm.Modelo.Estados.SiNo.Si
            hojaDeMaterial.Cell("BZ2").Value = MobilityScm.Modelo.Estados.SiNo.No

            'Se agregan los valores para la validacion de UnidadPeso
            Dim listaDeUnidadPeso = Bag_Materials_Class.ObtenerUnidadPeso()
            For y As Integer = 0 To listaDeUnidadPeso.Count - 1
                hojaDeMaterial.Cell("BY" + (y + 1).ToString()).Value = listaDeUnidadPeso(y)
            Next

            'Se agregan los valores para la validacion de UnidadPeso
            Dim listaDeClaseDeMaterial = Bag_Materials_Class.ObtenerClaseDeMaterial()
            For x As Integer = 0 To listaDeClaseDeMaterial.Count - 1
                hojaDeMaterial.Cell("BX" + (x + 1).ToString()).Value = listaDeClaseDeMaterial(x)
            Next

            'Se agregan los valores para la validacion de UnidadPeso
            Dim listaDeSubClaseDeMaterial = Bag_Materials_Class.ObtenerSubClaseDeMaterial()
            For x As Integer = 0 To listaDeSubClaseDeMaterial.Count - 1
                hojaDeMaterial.Cell("BW" + (x + 1).ToString()).Value = listaDeSubClaseDeMaterial(x)
            Next

            'Validacion de datos
            'CantidadMaxPorBin	
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = True
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0)
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Clase
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BX1:BX" + listaDeClaseDeMaterial.Count.ToString()))
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Cliente
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Codigo
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoBarras
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoBarrasAlterno
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(0, 25)
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Descripcion
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 200)
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 200 caracteres."
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 200 caracteres."
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("G2:G" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'DescripcionCorta
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 25 caracteres."
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("H2:H" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'EsCarro	ManejaExplosionEnRecepcion	ManejaLote	ManejaMasterPack	ManejaSerie
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).Value = "NO"
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BZ1:BZ2"))
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("I2:M" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'UnidadPeso
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).Value = unidadDePesoPorDefecto
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BY1:BY" + listaDeUnidadPeso.Count.ToString()))
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar una opción."
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar una opción."
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("N2:N" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Alto	Ancho	FactorVolumen	Largo	Peso
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).Value = 0
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = True
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0.000000)
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor númerico mayor o igual a cero."
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor númerico mayor o igual a cero."
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("O2:S" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'UsaLineaPicking
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).Value = "NO"
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BZ1:BZ2"))
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("T2:T" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'ManejaSerieCorrelativa
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).Value = "NO"
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BZ1:BZ2"))
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar SI o NO. Es obligatorio."
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("U2:U" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoBarrasAlterno
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(0, 25)
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 20 caracteres."
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 20 caracteres."
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("V2:V" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'TiempoEsperaEnDias
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).Value = 0
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0.000000)
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un número mayor que 0."
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un número mayor que 0."
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("W2:W" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Proveedor
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 64)
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 60 caracteres."
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 60 caracteres."
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("X2:X" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Nombre Proveedor
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 64)
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un máximo de 250 caracteres."
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un máximo de 60 caracteres."
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("Y2:Y" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'SubClase
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).Value = ""
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = True
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().List(hojaDeMaterial.Range("BW1:BW" + listaDeSubClaseDeMaterial.Count.ToString()))
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Opcional"
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Opcional"
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar una opcion."
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMaterial.Range("Z2:Z" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Convertir en tabla de excel
            Dim rngTable As IXLRange = hojaDeMaterial.Range(
                hojaDeMaterial.Cell(inicioEncabezadoX, inicioEncabezadoY),
                hojaDeMaterial.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))

            Dim excelTable = rngTable.CreateTable("Material")
            excelTable.ShowAutoFilter = False
        Catch ex As Exception
            Throw New Exception("Error al formar hoja de DatosGenerales:" + ex.Message)
        End Try
    End Sub

    Private Sub GenerarHojaDeUbicacion(hojaDeUbicacion As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try
            Dim columnas = New String() {"Cliente", "CodigoDeMaterial", "Ubicacion", "CantidadMinima", "CantidadMaxima"}

            'Encabezado Tabla
            For j = 0 To columnas.Count - 1
                hojaDeUbicacion.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaDeUbicacion.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaDeUbicacion.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaDeUbicacion.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hojaDeUbicacion.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            'Validacion de datos
            'Cliente
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).Value = ""
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUbicacion.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Codigo
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUbicacion.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Ubicacion
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).Value = ""
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUbicacion.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CantidadMaxima	
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).Value = 0
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0)
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUbicacion.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CantidadMaxPorBin	
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).Value = 1
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(1)
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor numerico mayor a cero."
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor numerico mayor a cero."
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUbicacion.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Convertir en tabla de excel
            Dim rngTable As IXLRange = hojaDeUbicacion.Range(
                hojaDeUbicacion.Cell(inicioEncabezadoX, inicioEncabezadoY),
                hojaDeUbicacion.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))

            Dim excelTable = rngTable.CreateTable("Ubicacion")
            excelTable.ShowAutoFilter = False
        Catch ex As Exception
            Throw New Exception("Error al formar hoja de Ubicacion:" + ex.Message)
        End Try
    End Sub

    Private Sub GenerarHojaDeUnidadDeMedida(hojaDeUnidadDeMedida As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try
            Dim columnas = New String() {"CodigoDeCliente", "CodigoDeMaterial", "Cantidad", "CodigoDeBarras", "CodigoDeBarrasAlternativo", "UnidadDeMedida"}

            'Encabezado de Tabla
            For j = 0 To columnas.Count - 1
                hojaDeUnidadDeMedida.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaDeUnidadDeMedida.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaDeUnidadDeMedida.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaDeUnidadDeMedida.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            'Validacion de datos
            'Codigo de Cliente
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).Value = ""
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Codigo de Material
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Cantidad
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).Value = 0
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0)
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor numerico mayor o igual a cero."
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Codigo de Barras
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).Value = ""
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 100)
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 100 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 100 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Codigo de Barras Alternativo
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).Value = ""
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 100)
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 100 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 100 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("E2:E" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Unidad de Medida
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).Value = ""
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeUnidadDeMedida.Range("F2:F" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            Dim rngTable As IXLRange = hojaDeUnidadDeMedida.Range(hojaDeUnidadDeMedida.Cell(inicioEncabezadoX, inicioEncabezadoY), hojaDeUnidadDeMedida.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))

            Dim excelTable = rngTable.CreateTable("Unicacion")
            excelTable.ShowAutoFilter = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GenerarHojaDeMasterPack(hojaDeMasterPack As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try
            Dim columnas = New String() {"Cliente", "CodigoMasterPack", "CodigoComponente", "Cantidad"}

            'Encabezado Tabla
            For j = 0 To columnas.Count - 1
                hojaDeMasterPack.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaDeMasterPack.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaDeMasterPack.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaDeMasterPack.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hojaDeMasterPack.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            'Validacion de datos
            'Cliente
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).Value = ""
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 25)
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 25 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMasterPack.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoDeMaterial
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMasterPack.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoDeComponente
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).Value = ""
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMasterPack.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Cantidad	
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Number)
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).Value = 1
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.WholeNumber
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().Decimal.EqualOrGreaterThan(0.0001)
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un valor numerico mayor o igual a 0.0001. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un valor numerico mayor o igual a 0.0001. De no tener este campo se ignorara el registro."
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaDeMasterPack.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Convertir en tabla de excel
            Dim rngTable As IXLRange = hojaDeMasterPack.Range(
                hojaDeMasterPack.Cell(inicioEncabezadoX, inicioEncabezadoY),
                hojaDeMasterPack.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))

            Dim excelTable = rngTable.CreateTable("MasterPack")
            excelTable.ShowAutoFilter = False
        Catch ex As Exception
            Throw New Exception("Error al formar hoja de MasterPack:" + ex.Message)
        End Try
    End Sub

    Private Sub GenerarHojaDePropiedadesDeMateriales(hojaPropiedades As IXLWorksheet, inicioEncabezadoX As Integer, inicioEncabezadoY As Integer, numeroDeFilas As Integer)
        Try
            Dim columnas = New String() {"Propiedad", "Bodega", "Material", "Valor"}
            Dim y As Integer
            Dim z As Integer
            Dim servicioMateriales As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")


            'Encabezado Tabla
            For j = 0 To columnas.Count - 1
                hojaPropiedades.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Value = columnas(j)
                hojaPropiedades.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Font.Bold = True
                hojaPropiedades.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Fill.BackgroundColor = XLColor.BabyBlueEyes
                hojaPropiedades.Cell(inicioEncabezadoX, inicioEncabezadoY + j).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                hojaPropiedades.Column(j + 1).Width = (columnas(j).Length * 2)
            Next

            hojaPropiedades.Cell("BW1").Value = "Si"
            hojaPropiedades.Cell("BW2").Value = "No"
            'Propiedades
            Dim propiedades = servicioMateriales.ObtenerPropiedadesDeMateriales(PublicLoginInfo.Environment)

            For z = 0 To propiedades.Rows.Count - 1
                hojaPropiedades.Cell("BZ" + (z + 1).ToString()).Value = propiedades.Rows(z)(3).ToString()
            Next

            'Bodegas
            For y = 0 To ListaDeBodegas.Rows.Count - 1
                hojaPropiedades.Cell("BY" + (y + 1).ToString()).Value = ListaDeBodegas.Rows(y)(2).ToString()
            Next

            'Validacion de datos
            'Propiedad 
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).Value = ""
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().List(hojaPropiedades.Range("BZ1:BZ" + z.ToString()))
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar la propiedad. Es obligatorio."
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar la propiedad. Es obligatorio."
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaPropiedades.Range("A2:A" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Bodegas 
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).Value = ""
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().List(hojaPropiedades.Range("BY1:BY" + y.ToString()))
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar la bodega. Es obligatorio."
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar la bodega. Es obligatorio."
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaPropiedades.Range("B2:B" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'CodigoDeMaterial
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataType(XLCellValues.Text)
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).Value = ""
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = False
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.TextLength
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().TextLength.Between(1, 50)
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe ingresar un maximo de 50 caracteres. De no tener este campo se ignorara el registro."
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaPropiedades.Range("C2:C" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Valor
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).Value = ""
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().IgnoreBlanks = False
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InCellDropdown = True
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().AllowedValues = XLAllowedValues.List
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().List(hojaPropiedades.Range("BW1:BW2"))
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputTitle = "Obligatorio"
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().InputMessage = "Debe seleccionar la opcion Si No. Es obligatorio."
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowInputMessage = True
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorTitle = "Obligatorio"
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorMessage = "Debe seleccionar la opcion Si No. Es obligatorio."
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ErrorStyle = XLErrorStyle.Stop
            hojaPropiedades.Range("D2:D" + numeroDeFilas.ToString()).SetDataValidation().ShowErrorMessage = True

            'Convertir en tabla de excel
            Dim rngTable As IXLRange = hojaPropiedades.Range(
                hojaPropiedades.Cell(inicioEncabezadoX, inicioEncabezadoY),
                hojaPropiedades.Cell(inicioEncabezadoX + (numeroDeFilas - 1), inicioEncabezadoY + columnas.Count - 1))

            Dim excelTable = rngTable.CreateTable("Propiedad")
            excelTable.ShowAutoFilter = False
        Catch ex As Exception
            Throw New Exception("Error al formar hoja de Propiedades por bodega:" + ex.Message)
        End Try
    End Sub

    Private Sub CargarPlantilla()
        Try
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            Dim dialogo As New OpenFileDialog()
            dialogo.Filter = "Excel xlsx (*.xlsx)|*.xlsx"
            dialogo.FilterIndex = 2
            dialogo.RestoreDirectory = True
            dialogo.Title = "Cargar plantilla"

            If dialogo.ShowDialog() = DialogResult.OK Then
                Dim workbook = New XLWorkbook(dialogo.FileName)
                Dim hojaDeMaterial, hojaDeUbicacion, hojaDeUnidadDeMedida, hojaDeMasterPack, hojaDePropiedades
                Dim existeHojaDeMaterial, existeHojaDeUbicacio, existeHojaDeUnidadDeMedida, existeHojaDeMasterPack, existeHojaDePropiedades
                Dim xmlDeMaterial As String = Nothing, xmlDeUbicacion As String = Nothing, xmlDeMasterPack As String = Nothing,
                xmlDePropiedades As String = Nothing, xmlDeUnidadDeMedida As String = Nothing

                existeHojaDeMaterial = workbook.TryGetWorksheet("Material", hojaDeMaterial)
                existeHojaDeUbicacio = workbook.TryGetWorksheet("Ubicacion", hojaDeUbicacion)
                existeHojaDeUnidadDeMedida = workbook.TryGetWorksheet("UnidadDeMedida", hojaDeUnidadDeMedida)
                existeHojaDeMasterPack = workbook.TryGetWorksheet("MasterPack", hojaDeMasterPack)
                existeHojaDePropiedades = workbook.TryGetWorksheet("PropiedadesPorBodega", hojaDePropiedades)

                If existeHojaDeMaterial Then
                    xmlDeMaterial = ObtenerXmlDeMaterial(hojaDeMaterial)
                End If

                If existeHojaDeUbicacio Then
                    xmlDeUbicacion = ObtenerXmlDeUbicacion(hojaDeUbicacion)
                End If

                If existeHojaDeUnidadDeMedida Then
                    xmlDeUnidadDeMedida = ObtenerXmlDeUnidadDeMedida(hojaDeUnidadDeMedida)
                End If

                If existeHojaDeMasterPack Then
                    xmlDeMasterPack = ObtenerXmlDeMasterPack(hojaDeMasterPack)
                End If
                If existeHojaDePropiedades Then
                    xmlDePropiedades = ObtenerXmlDePropiedadesDeMaterialesExcel(hojaDePropiedades)
                End If

                Dim pResult As String = ""
                Dim xdata As DataSet = xserv.LoadMaterialByXml(xmlDeMaterial, xmlDeUbicacion, xmlDeUnidadDeMedida, xmlDeMasterPack, xmlDePropiedades, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

                If pResult = "OK" Then
                    FilListView(True)
                    ClearBag_Materials()
                    NuevoEmpaque()
                    GridControl2.DataSource = Nothing
                    XtraTabControl1.SelectedTabPage = UiTabDatosGenerales
                    NotifyStatus("Carga realizada con éxito", True, False)
                Else
                    Dim listaDeErrores(xdata.Tables(1).Rows.Count) As String
                    For i As Integer = 0 To xdata.Tables(1).Rows.Count - 1
                        listaDeErrores(i) = ("En la hoja de " + xdata.Tables(1).Rows(i)(1).ToString() + " linea " + (xdata.Tables(1).Rows(i)(2) + 1).ToString() + ": " + xdata.Tables(1).Rows(i)(3).ToString())
                    Next
                    If xdata.Tables(1).Rows.Count = 0 Then
                        NotifyStatus(pResult, False, True)
                    Else
                        Dim popup As New popupList("Listado de Errores", listaDeErrores)
                        popup.ShowDialog()
                    End If

                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
#End Region

    Private Function ObtenerXmlDeMaterial(hoja As IXLWorksheet) As String
        Try
            Dim tabla = hoja.Table("Material")
            Dim esPrimeraFila As Boolean = True
            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"CantidadMaxPorBin", "Clase", "Cliente", "Codigo", "CodigoBarras", "CodigoBarrasAlterno", "Descripcion", "DescripcionCorta", "EsCarro", "ManejaExplosionEnRecepcion", "ManejaLote", "ManejaMasterPack", "ManejaSerie", "UnidadPeso", "Alto", "Ancho", "FactorVolumen", "Largo", "Peso", "UsaLineaDePicking",
                "ManejaSerieCorrelativa", "PrefijoSerieCorrelativa", "TiempoEsperaEnDias", "Proveedor", "NombreProveedor", "SubClase"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each fila In tabla.Rows
                If esPrimeraFila = False Then

                    If fila.Cell(3).Value.ToString() <> "" And fila.Cell(4).Value.ToString() <> "" Then
                        xml = xml + FormarLineaDeXml(fila, "Material", columnas)
                        tieneFilas = True
                    End If
                Else
                    esPrimeraFila = False
                End If
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer hoja de Material: " + ex.Message)
        End Try
    End Function

    Private Function ObtenerXmlDeUbicacion(hoja As IXLWorksheet) As String
        Try
            Dim tabla = hoja.Table("Ubicacion")
            Dim esPrimeraFila As Boolean = True
            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"Cliente", "CodigoDeMaterial", "Ubicacion", "CantidadMinima", "CantidadMaxima"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each fila In tabla.Rows
                If esPrimeraFila = False Then

                    If fila.Cell(1).Value.ToString() <> "" And fila.Cell(2).Value.ToString() <> "" And fila.Cell(3).Value.ToString() <> "" Then
                        xml = xml + FormarLineaDeXml(fila, "Ubicacion", columnas)
                        tieneFilas = True
                    End If
                Else
                    esPrimeraFila = False
                End If
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer hoja de Ubicacion: " + ex.Message)
        End Try
    End Function

    Private Function ObtenerXmlDePropiedadesDeMaterialesExcel(hoja As IXLWorksheet) As String
        Try
            Dim tabla = hoja.Table("Propiedad")
            Dim esPrimeraFila As Boolean = True
            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"Propiedad", "Bodega", "Material", "Valor"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each fila In tabla.Rows
                If esPrimeraFila = False Then

                    If fila.Cell(1).Value.ToString() <> "" And fila.Cell(2).Value.ToString() <> "" And fila.Cell(3).Value.ToString() <> "" And fila.Cell(4).Value.ToString() <> "" Then
                        xml = xml + FormarLineaDeXml(fila, "PropiedadesPorBodega", columnas)
                        tieneFilas = True
                    End If
                Else
                    esPrimeraFila = False
                End If
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer hoja de MasterPack: " + ex.Message)
        End Try
    End Function

    Private Function ObtenerXmlDePropiedadesDeMateriales(hoja As DataView) As String
        Try

            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"Propiedad", "Bodega", "Material", "Valor"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each vista As DataRowView In hoja
                Dim fila As DataRow = vista.Row
                xml = xml + FormarLineaDeXml(fila, "PropiedadesPorBodega", columnas)
                tieneFilas = True
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer propiedades: " + ex.Message)
        End Try
    End Function

    Private Function ObtenerXmlDeUnidadDeMedida(hoja As IXLWorksheet) As String
        Try
            Dim tabla = hoja.Table(0)
            Dim esPrimeraFila As Boolean = True
            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"CodigoDeCliente", "CodigoDeMaterial", "Cantidad", "CodigoDeBarras", "CodigoDeBarrasAlternativo", "UnidadDeMedida"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each fila In tabla.Rows
                If esPrimeraFila = False Then

                    If fila.Cell(1).Value.ToString() <> "" And fila.Cell(2).Value.ToString() <> "" And fila.Cell(3).Value.ToString() <> "" And fila.Cell(4).Value.ToString() <> "" And fila.Cell(6).Value.ToString() <> "" Then
                        xml = xml + FormarLineaDeXml(fila, "UnidadDeMedida", columnas)
                        tieneFilas = True
                    End If
                Else
                    esPrimeraFila = False
                End If
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer hoja de UnidadDeMedida: " + ex.Message)
        End Try
    End Function

    Private Function ObtenerXmlDeMasterPack(hoja As IXLWorksheet) As String
        Try
            Dim tabla = hoja.Table("MasterPack")
            Dim esPrimeraFila As Boolean = True
            Dim tieneFilas As Boolean = False
            Dim columnas = New String() {"Cliente", "CodigoMasterPack", "CodigoComponente", "Cantidad"}

            Dim xml As String = "<?xml version='1.0'?><Data>"
            For Each fila In tabla.Rows
                If esPrimeraFila = False Then

                    If fila.Cell(1).Value.ToString() <> "" And fila.Cell(2).Value.ToString() <> "" And fila.Cell(3).Value.ToString() <> "" Then
                        xml = xml + FormarLineaDeXml(fila, "MasterPack", columnas)
                        tieneFilas = True
                    End If
                Else
                    esPrimeraFila = False
                End If
            Next
            xml = xml + "</Data>"

            If Not tieneFilas Then
                xml = ""
            End If

            Return xml
        Catch ex As Exception
            Throw New Exception("Error al leer hoja de MasterPack: " + ex.Message)
        End Try
    End Function

    Private Function FormarLineaDeXml(fila As IXLRangeRow, nodo As String, columnas As String()) As String
        Try
            Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            Dim xtable As DataTable
            Dim pResult As String = ""
            Dim valorCelda As String
            Dim linea = "<" + nodo + ">"
            For i As Integer = 0 To columnas.Count - 1

                If nodo = "Material" And columnas(i) = "Clase" Then
                    valorCelda = IIf(fila.Cell(i + 1).IsEmpty(), "", fila.Cell(i + 1).Value.ToString())
                    xtable = xserv.ObtenerClasePorNombre(pResult, valorCelda, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        valorCelda = xtable.Rows(0)(0).ToString
                    Else
                        valorCelda = ""
                    End If
                ElseIf nodo = "Material" And columnas(i) = "SubClase" Then
                    valorCelda = IIf(fila.Cell(i + 1).IsEmpty(), "", fila.Cell(i + 1).Value.ToString())
                    xtable = xserv.ObtenerSubClasePorNombre(pResult, valorCelda, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        valorCelda = xtable.Rows(0)(0).ToString
                    Else
                        valorCelda = ""
                    End If
                Else
                    valorCelda = IIf(fila.Cell(i + 1).IsEmpty(), "", fila.Cell(i + 1).Value.ToString())
                End If

                linea = linea + "<" + columnas(i) + ">" + valorCelda + "</" + columnas(i) + ">"
            Next

            linea = linea + "</" + nodo + ">"
            Return linea
        Catch ex As Exception
            Throw New Exception("Error al formar XML de " + nodo + ": " + ex.Message)
        End Try
    End Function

    Private Function FormarLineaDeXml(fila As DataRow, nodo As String, columnas As String()) As String
        Try
            Dim linea = "<" + nodo + ">"
            For i As Integer = 0 To columnas.Count - 1
                linea = linea + "<" + columnas(i) + ">" + fila(i).ToString() + "</" + columnas(i) + ">"
            Next
            linea = linea + "</" + nodo + ">"
            Return linea
        Catch ex As Exception
            Throw New Exception("Error al formar XML de " + nodo + ": " + ex.Message)
        End Try
    End Function

    Private Sub UiListaDeClientes_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaDeClientes.EditValueChanged
        Dim material As clsMaterials = UiPropiedadDeDatosGenerales.SelectedObject
        Dim lista As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        material.Cliente = lista.EditValue
        UiPropiedadDeDatosGenerales.SelectedObject = material
        UiPropiedadDeDatosGenerales.Refresh()
    End Sub

    Private Sub UiListaClases_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaClases.EditValueChanged
        Dim material As clsMaterials = UiPropiedadDeDatosGenerales.SelectedObject
        Dim lista As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        material.Clase = lista.EditValue
        UiPropiedadDeDatosGenerales.SelectedObject = material
        UiPropiedadDeDatosGenerales.Refresh()
    End Sub

    Private Sub UiListaSubClases_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaSubClases.EditValueChanged
        Dim material As clsMaterials = UiPropiedadDeDatosGenerales.SelectedObject
        Dim lista As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        material.SubClase = lista.EditValue
        UiPropiedadDeDatosGenerales.SelectedObject = material
        UiPropiedadDeDatosGenerales.Refresh()
    End Sub

    Private Sub UiBotonGuardarExcepcionPorBodega_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGuardarExcepcionPorBodega.ItemClick
        UiVistaExcepcionPorBodega.PostEditor()
        UiVistaExcepcionPorBodega.CloseEditor()
        UiVistaExcepcionPorBodega.UpdateCurrentRow()
        
        
        Dim data As DataView = UiVistaExcepcionPorBodega.DataSource
        Try
            Dim servicio As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            Dim xmlDeMaterial As String = Nothing, xmlDeUbicacion As String = Nothing, xmlDeMasterPack As String = Nothing, xmlDeUnidadDeMedida As String = Nothing,
            xmlDePropiedades As String = Nothing
            xmlDePropiedades = ObtenerXmlDePropiedadesDeMateriales(data)

            Dim pResult As String = ""
            Dim xdata As DataSet = servicio.LoadMaterialByXml(xmlDeMaterial, xmlDeUbicacion, xmlDeUnidadDeMedida, xmlDeMasterPack, xmlDePropiedades, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                CargarExcepcionesPorBodega(SelectedsKU)
                NotifyStatus("Carga realizada con éxito", True, False)
            Else
                Dim listaDeErrores(xdata.Tables(1).Rows.Count) As String
                For i As Integer = 0 To xdata.Tables(1).Rows.Count - 1
                    listaDeErrores(i) = ("En la linea " + (xdata.Tables(1).Rows(i)(2) + 1).ToString() + ": " + xdata.Tables(1).Rows(i)(3).ToString())
                Next
                If xdata.Tables(1).Rows.Count = 0 Then
                    NotifyStatus(pResult, False, True)
                Else
                    Dim popup As New popupList("Listado de Errores", listaDeErrores)
                    popup.ShowDialog()
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonElimnarExcepcionPorBodega_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonElimnarExcepcionPorBodega.ItemClick
        Try


            Dim dataRow As DataRow
            Dim servicio As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
            For index = 0 To UiVistaExcepcionPorBodega.SelectedRowsCount - 1
                dataRow = UiVistaExcepcionPorBodega.GetDataRow(UiVistaExcepcionPorBodega.GetSelectedRows()(index))
                Dim resultado = servicio.EliminarPropiedadPorBodegaDeMaterial(Convert.ToInt32(dataRow("MATERIAL_PROPERTY_ID")),
                                                                              dataRow("MATERIAL_ID").ToString(), dataRow("WAREHOUSE_ID").ToString(), PublicLoginInfo.Environment)
                If resultado.TableName = "Operacion" And resultado(0)("Resultado") = CType(ResultadoOperacionTipo.Error, Integer) Then
                    NotifyStatus(resultado(0)("Mensaje"), False, True)
                    Exit For
                End If
            Next
            CargarExcepcionesPorBodega(SelectedsKU)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonDescargarPlantillaEnExcepcionesPorPlantilla_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDescargarPlantillaEnExcepcionesPorPlantilla.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBotonCargarPlantillaEnExcepcionesPorPlantilla_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCargarPlantillaEnExcepcionesPorPlantilla.ItemClick
        CargarPlantilla()
    End Sub

    Private Sub UiVistaExcepcionPorBodega_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles UiVistaExcepcionPorBodega.InitNewRow

        Dim view As GridView = TryCast(sender, GridView)
        view.SetRowCellValue(e.RowHandle, "MATERIAL_ID", SelectedsKU)
        view.SetRowCellValue(e.RowHandle, "MODIFIED", 0)
    End Sub

    Private Sub UiBotonDescargarPlantillaEnUnidadDeMedida_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonDescargarPlantillaEnUnidadDeMedida.ItemClick
        DescargarPlantilla()
    End Sub

    Private Sub UiBotonCargarPlantillaEnUnidadDeMedida_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCargarPlantillaEnUnidadDeMedida.ItemClick
        CargarPlantilla()
    End Sub
End Class


Public Class RawPrinterHelper1
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW = Nothing ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return ""
    End Function


End Class

Public Class Empaque
    Dim _codigo As Int32
    Dim _codigoDeCliente As String
    Dim _codigoDeMaterial As String
    Dim _empaque As String
    Dim _cantidad As Int32
    Dim _codigoDeBarras As String
    Dim _codigoDeBarrasAlternativo As String

    <Category("Empaque"), Description("Codigo de Empaque")>
    Public Property codigo() As Int32
        Get
            Return _codigo
        End Get
        Set(ByVal Value As Int32)
            _codigo = Value
        End Set
    End Property

    <Category("Material"), Description("Codigo de Cliente")>
    Public Property codigoDeCliente() As String
        Get
            Return _codigoDeCliente
        End Get
        Set(ByVal Value As String)
            _codigoDeCliente = Value
        End Set
    End Property

    <Category("Material"), Description("Codigo de Producto")>
    Public Property codigoDeMaterial() As String
        Get
            Return _codigoDeMaterial
        End Get
        Set(ByVal Value As String)
            _codigoDeMaterial = Value
        End Set
    End Property

    <Category("Empaque"), Description("Empaque")>
    Public Property empaque() As String
        Get
            Return _empaque
        End Get
        Set(ByVal Value As String)
            _empaque = Value
        End Set
    End Property

    <Category("Empaque"), Description("Cantidad")>
    Public Property cantidad() As Int32
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Int32)
            _cantidad = Value
        End Set
    End Property

    <Category("Empaque"), Description("Codigo de Barras")>
    Public Property codigoDeBarras() As String
        Get
            Return _codigoDeBarras
        End Get
        Set(ByVal Value As String)
            _codigoDeBarras = Value
        End Set
    End Property

    <Category("Empaque"), Description("Codigo de Barras alternativo")>
    Public Property codigoDeBarrasAlternativo() As String
        Get
            Return _codigoDeBarrasAlternativo
        End Get
        Set(ByVal Value As String)
            _codigoDeBarrasAlternativo = Value
        End Set
    End Property
End Class