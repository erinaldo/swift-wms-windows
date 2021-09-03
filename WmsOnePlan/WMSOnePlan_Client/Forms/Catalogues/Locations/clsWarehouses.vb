Imports System.ComponentModel
Public Class ERPWarehousesEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private ERPWarehousesEnumClass() As String = GetERPWarehouses()

    Public Function GetERPWarehouses()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.SelectERPWarehouses(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)

                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function


    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetERPWarehouses())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class

Public Class DistributionCentersEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private DistributionCentersEnumClass() As String = GetDistributionCenters()

    Public Function GetDistributionCenters()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            'xds = xserv.get(pResult, PublicLoginInfo.Environment)
            xds = xserv.GetDistributionCenters(PublicLoginInfo.Environment, pResult)
            For Each xdr In xds.Tables(0).Rows
                XStr(I) = xdr("PARAM_NAME").ToString
                I = I + 1
                ReDim Preserve XStr(I)
            Next

        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function


    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetDistributionCenters())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class

Public Class ClimaWarehousesEnumClass
    Inherits StringConverter

    Public Sub New()
        MyBase.New()
    End Sub
    Private ClimaWarehousesEnumClass() As String = GetClimaWarehouses()

    Public Function GetClimaWarehouses()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Try
            xds = xserv.SelectClimaWarehouses(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    XStr(I) = xdr("PARAM_NAME").ToString
                    I = I + 1
                    ReDim Preserve XStr(I)

                Next
            End If
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function


    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(GetClimaWarehouses())
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return False
    End Function

End Class

Public Class ActivaInactiva
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Private ActivaInactiva() As String = {"Activa", "Inactiva"}
    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        'True = Se despliega la lista
        'False = No se despliega la lista y el ususario debe escribir un valor
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(ActivaInactiva)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        'True = el combo no admite más items que los de la lista
        'False = el combo admite un item que no esté en la lista
        Return True
    End Function
End Class

Public Class AscendenteDescendente
    Inherits StringConverter
    Public Sub New()
        MyBase.New()
    End Sub
    Private AscendenteDescendente() As String = GetAscendenteDescendente()
    Public Function GetAscendenteDescendente()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New  OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Try
            xds = xserv.ObtenerParametros("PICKING_TYPE", Nothing, PublicLoginInfo.Environment)
            For Each xdr In xds.Tables(0).Rows
                XStr(I) = xdr("VALUE").ToString
                I = I + 1
                ReDim Preserve XStr(I)

            Next
        Catch ex As Exception
            XStr(0) = ex.Message
        End Try
        Return XStr
    End Function

    Public Overloads Overrides Function GetStandardValuesSupported(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overloads Overrides Function GetStandardValues(ByVal context As ITypeDescriptorContext) As StandardValuesCollection
        Return New StandardValuesCollection(AscendenteDescendente)
    End Function
    Public Overloads Overrides Function GetStandardValuesExclusive(ByVal context As ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class

Public Class clsWarehouse
    Public _WAREHOUSE_ID As String
    Public _NAME As String
    Public _COMMENTS As String
    Public _ERP_WAREHOUSE As String

    Public _SHUNT_NAME As String
    Public _WAREHOUSE_WEATHER As String
    Public _WAREHOUSE_STATUS As String
    Public _IS_3PL_WAREHUESE As String
    Public _WAHREHOUSE_ADDRESS As String
    Public _GPS_URL As String
    Public _DISTRIBUTION_CENTER As String
    Public _PICKING_TYPE As String

    <Category("Datos Generales"), Description("Codigo de bodega -maximo 25 caracteres-"),DisplayName("Código Bodega")>
    Public Property CodigoBodega() As String
        Get
            Return _WAREHOUSE_ID
        End Get
        Set(ByVal Value As String)
            _WAREHOUSE_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Nombre de bodega -maximo 50 caracteres-"),DisplayName("Nombre Bodega")>
    Public Property NombreBodega() As String
        Get
            Return _NAME
        End Get
        Set(ByVal Value As String)
            _NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Comentario -maximo 150 caracteres-"),DisplayName("Comentarios")>
    Public Property Comentarios() As String
        Get
            Return _COMMENTS
        End Get
        Set(ByVal Value As String)
            _COMMENTS = Value
        End Set
    End Property
    <Category("Datos Generales"), TypeConverter(GetType(ERPWarehousesEnumClass)), Description("Codigo de bodega relacionada en SAP-maximo 50 caracteres-"),DisplayName("Codigo Bodega SAP")>
    Public Property CodigoBodegaSAP() As String
        Get
            Return _ERP_WAREHOUSE
        End Get
        Set(ByVal Value As String)
            _ERP_WAREHOUSE = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Descripcion corta -maximo 25 caracteres-"),DisplayName("Descripción Corta")>
    Public Property DescripcionCorta() As String
        Get
            Return _SHUNT_NAME
        End Get
        Set(ByVal Value As String)
            _SHUNT_NAME = Value
        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(ClimaWarehousesEnumClass)), Description("Clima -maximo 50 caracteres-"),DisplayName("Clima")>
    Public Property Clima() As String
        Get
            Return _WAREHOUSE_WEATHER
        End Get
        Set(ByVal Value As String)
            _WAREHOUSE_WEATHER = Value
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(ActivaInactiva)), Description("Estado de la bodega? (1=Activo / 0=Inactivo)"),DisplayName("Estado")>
    Public Property Estatus() As String
        Get
            Select Case _WAREHOUSE_STATUS
                Case "0"
                    Return "Inactiva"
                Case "1"
                    Return "Activa"
                Case "Inactiva"
                    Return "Inactiva"
                Case Else
                    Return "Activa"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _WAREHOUSE_STATUS = "Inactiva"
                Case "1"
                    _WAREHOUSE_STATUS = "Activa"
                Case "Inactiva"
                    _WAREHOUSE_STATUS = "Inactiva"
                Case Else
                    _WAREHOUSE_STATUS = "Activa"
            End Select
        End Set
    End Property

    <Category("Caracteristicas"), TypeConverter(GetType(SioNo)), Description("La Bodega esta habilitada? (1=SI / 0=NO)"),DisplayName("¿Es Bodega Habilitada?")>
    Public Property EsBodegaHabilitada() As String
        Get
            Select Case _IS_3PL_WAREHUESE
                Case "0"
                    Return "NO"
                Case "1"
                    Return "SI"
                Case "NO"
                    Return "NO"
                Case Else
                    Return "SI"
            End Select
        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "0"
                    _IS_3PL_WAREHUESE = "NO"
                Case "1"
                    _IS_3PL_WAREHUESE = "SI"
                Case "NO"
                    _IS_3PL_WAREHUESE = "NO"
                Case Else
                    _IS_3PL_WAREHUESE = "SI"
            End Select
        End Set
    End Property

    <Category("Datos Generales"), Description("Direccion fisica de la bodega -maximo 250 caracteres-"),DisplayName("Dirección Física De Bodega")>
    Public Property DireccionFisicaDeBodega() As String
        Get
            Return _WAHREHOUSE_ADDRESS
        End Get
        Set(ByVal Value As String)
            _WAHREHOUSE_ADDRESS = Value
        End Set
    End Property

    <Category("Datos Generales"), Description("Punto de Gps -maximo 100 caracteres-"),DisplayName("Punto GPS")>
    Public Property PuntoGps() As String
        Get
            Return _GPS_URL
        End Get
        Set(ByVal Value As String)
            _GPS_URL = Value
        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(DistributionCentersEnumClass)), Description("Centro de Distribucion -maximo 50 caracteres-"),DisplayName("Centro De Distribución")>
    Public Property CentroDeDistribucion() As String
        Get
            Return _DISTRIBUTION_CENTER
        End Get
        Set(ByVal Value As String)
            _DISTRIBUTION_CENTER = Value
        End Set
    End Property

    <Category("Datos Generales"), TypeConverter(GetType(AscendenteDescendente)), Description("Tipo de Picking -maximo 50 caracteres-"),DisplayName("Tipo de Picking")>
    Public Property TipoDePicking() As String
        Get
            Return _PICKING_TYPE
        End Get
        Set(ByVal Value As String)
            _PICKING_TYPE = Value
        End Set
    End Property





    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
            xserv.SearchByKeyWarehouse(CodigoBodega, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record

                If IIf(EsBodegaHabilitada = "NO", True, False) Then
                    If xserv.EnabledShelfSpots(CodigoBodega, pLocalResult, PublicLoginInfo.Environment) Then
                        If pLocalResult = "OK" Then
                            If xserv.UpdateWarehouse(CodigoBodega, NombreBodega, Comentarios, CodigoBodegaSAP, DescripcionCorta, Clima, IIf(Estatus = "Inactiva", 0, 1), IIf(EsBodegaHabilitada = "NO", 0, 1), DireccionFisicaDeBodega, PuntoGps, CentroDeDistribucion, TipoDePicking, pLocalResult, PublicLoginInfo.Environment) Then
                                Return True
                            Else
                                pResult = pLocalResult
                                Return False
                            End If
                        Else
                            pResult = pLocalResult
                            Return False
                        End If
                    Else
                        pResult = pLocalResult
                        Return False
                    End If
                Else
                    If xserv.UpdateWarehouse(CodigoBodega, NombreBodega, Comentarios, CodigoBodegaSAP, DescripcionCorta, Clima, IIf(Estatus = "Inactiva", 0, 1), IIf(EsBodegaHabilitada = "NO", 0, 1), DireccionFisicaDeBodega, PuntoGps, CentroDeDistribucion, TipoDePicking, pLocalResult, PublicLoginInfo.Environment) Then
                        Return True
                    Else
                        If (pLocalResult = "Procedure or function 'OP_WMS_SP_UPDATE_WAREHOUSE' expects parameter '@DISTRIBUTION_CENTER_ID', which was not supplied.") Then
                            pResult = "El campo centro de distribucion esta vacio, no puede ingresar datos nulos"
                            Return False
                        Else
                            pResult = pLocalResult
                            Return False
                        End If


                    End If
                End If

            Else 'Add new record
                If xserv.CreateWarehouse(CodigoBodega, NombreBodega, Comentarios, CodigoBodegaSAP, DescripcionCorta, Clima, IIf(Estatus = "Inactiva", 0, 1), IIf(EsBodegaHabilitada = "NO", 0, 1), DireccionFisicaDeBodega, PuntoGps, CentroDeDistribucion, TipoDePicking, pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

    Public Function Delete(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
            If xserv.EnabledShelfSpots(CodigoBodega, pLocalResult, PublicLoginInfo.Environment) Then
                If pLocalResult = "OK" Then
                    If xserv.DeleteWarehouse(CodigoBodega, pLocalResult, PublicLoginInfo.Environment) Then
                        Return True
                    Else
                        pResult = pLocalResult
                        Return False
                    End If
                End If
            Else
                pResult = pLocalResult
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function
End Class
