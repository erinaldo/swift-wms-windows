Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader
Imports WMSOnePlan_BusinessServices.ModuleServices
Imports System.Web.Script.Services


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<System.Web.Script.Services.ScriptService()>
<ToolboxItem(False)>
Public Class WMS_Materials
    Inherits System.Web.Services.WebService

    <BrowsableAttribute(True)>
    Public EnvironmentName As String

    '19-Jul-10 J.R se agrego campo Max_X_Bin
    <WebMethod(Description:="Create a Material")>
    Public Function CreateMaterials(ByVal pCLIENT_OWNER As String,
                                    ByVal pMATERIAL_ID As String,
                                    ByVal pBARCODE_ID As String,
                                    ByVal pALTERNATE_BARCODE As String,
                                    ByVal pMATERIAL_NAME As String,
                                    ByVal pSHORT_NAME As String,
                                    ByVal pVOLUME_FACTOR As Double,
                                    ByVal pMATERIAL_CLASS As String,
                                    ByVal pMATERIAL_SUB_CLASS As String,
                                    ByVal pHIGH As Double,
                                    ByVal pLENGTH As Double,
                                    ByVal pWIDTH As Double,
                                    ByVal pMAX_X_BIN As Integer,
                                    ByVal pSCAN_BY_ONE As Integer,
                                    ByVal pREQUIRES_LOGISTICS_INFO As Integer,
                                    ByVal pWEIGTH As Double,
                                    ByVal pLAST_UPDATED_BY As String,
                                    ByVal pIS_CAR As Integer,
                                    ByVal pBatchRequested As Integer,
                                    ByRef resultado As String,
                                    ByVal ambiente As String,
                                    ByVal serialNumberRequests As Integer,
                                    isMasterPack As Integer,
                                    ByVal weightMeasurement As String,
                                     explodeInReception As Integer,
                                    handleTone As Integer,
                                    handleCaliber As Integer,
                                    ByVal usePickingLine As String,
                                    ByVal pQUALITY_CONTROL As Integer,
                                    ByVal PREFIX_CORRELATIVE_SERIALS As String,
                                    ByVal HANDLE_CORRELATIVE_SERIALS As Integer,
                                    ByVal LEAD_TIME As Integer,
                                    ByVal SUPPLIER As String,
                                    ByVal NAME_SUPPLIER As String,
                                    ByVal EXPIRATION_TOLERANCE As Integer) As Boolean
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@ALTERNATE_BARCODE", SqlDbType.VarChar, 24)
            cmd.Parameters.Add("@MATERIAL_NAME", SqlDbType.VarChar, 200)
            cmd.Parameters.Add("@SHORT_NAME", SqlDbType.VarChar, 200)
            cmd.Parameters.Add("@VOLUME_FACTOR", SqlDbType.Decimal)
            cmd.Parameters.Add("@MATERIAL_CLASS", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@MATERIAL_SUB_CLASS", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@HIGH", SqlDbType.Decimal)
            cmd.Parameters.Add("@LENGTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@WIDTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@MAX_X_BIN", SqlDbType.Int)
            cmd.Parameters.Add("@SCAN_BY_ONE", SqlDbType.Int)
            cmd.Parameters.Add("@REQUIRES_LOGISTICS_INFO", SqlDbType.Int)
            cmd.Parameters.Add("@WEIGTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@IS_CAR", SqlDbType.Int)
            cmd.Parameters.Add("@MT3", SqlDbType.Decimal)
            cmd.Parameters.Add("@BATCH_REQUESTED", SqlDbType.Int)
            cmd.Parameters.Add("@SERIAL_NUMBER_REQUESTS", SqlDbType.Int)
            cmd.Parameters.Add("@IS_MASTER_PACK", SqlDbType.Int)
            cmd.Parameters.Add("@ERP_AVERAGE_PRICE", SqlDbType.Decimal)
            cmd.Parameters.Add("@WEIGHT_MEASUREMENT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@EXPLODE_IN_RECEPTION", SqlDbType.Int)
            cmd.Parameters.Add("@HANDLE_TONE", SqlDbType.Int)
            cmd.Parameters.Add("@HANDLE_CALIBER", SqlDbType.Int)
            cmd.Parameters.Add("@USE_PICKING_LINE", SqlDbType.Int)
            cmd.Parameters.Add("@QUALITY_CONTROL", SqlDbType.Int)
            cmd.Parameters.Add("@PREFIX_CORRELATIVE_SERIALS", SqlDbType.VarChar)
            cmd.Parameters.Add("@HANDLE_CORRELATIVE_SERIALS", SqlDbType.Int)
            cmd.Parameters.Add("@LEAD_TIME", SqlDbType.Int)
            cmd.Parameters.Add("@SUPPLIER", SqlDbType.VarChar, 64)
            cmd.Parameters.Add("@NAME_SUPPLIER", SqlDbType.VarChar, 250)
            cmd.Parameters.Add("@EXPIRATION_TOLERANCE", SqlDbType.Int)


            cmd.Parameters("@CLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@BARCODE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@ALTERNATE_BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@SHORT_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@VOLUME_FACTOR").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_CLASS").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_SUB_CLASS").Direction = ParameterDirection.Input
            cmd.Parameters("@HIGH").Direction = ParameterDirection.Input
            cmd.Parameters("@LENGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@WIDTH").Direction = ParameterDirection.Input
            cmd.Parameters("@MAX_X_BIN").Direction = ParameterDirection.Input
            cmd.Parameters("@SCAN_BY_ONE").Direction = ParameterDirection.Input
            cmd.Parameters("@REQUIRES_LOGISTICS_INFO").Direction = ParameterDirection.Input
            cmd.Parameters("@WEIGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@IS_CAR").Direction = ParameterDirection.Input
            cmd.Parameters("@MT3").Direction = ParameterDirection.Input
            cmd.Parameters("@BATCH_REQUESTED").Direction = ParameterDirection.Input
            cmd.Parameters("@SERIAL_NUMBER_REQUESTS").Direction = ParameterDirection.Input
            cmd.Parameters("@IS_MASTER_PACK").Direction = ParameterDirection.Input
            cmd.Parameters("@ERP_AVERAGE_PRICE").Direction = ParameterDirection.Input
            cmd.Parameters("@WEIGHT_MEASUREMENT").Direction = ParameterDirection.Input
            cmd.Parameters("@EXPLODE_IN_RECEPTION").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_TONE").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_CALIBER").Direction = ParameterDirection.Input
            cmd.Parameters("@USE_PICKING_LINE").Direction = ParameterDirection.Input
            cmd.Parameters("@QUALITY_CONTROL").Direction = ParameterDirection.Input
            cmd.Parameters("@PREFIX_CORRELATIVE_SERIALS").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_CORRELATIVE_SERIALS").Direction = ParameterDirection.Input
            cmd.Parameters("@LEAD_TIME").Direction = ParameterDirection.Input
            cmd.Parameters("@SUPPLIER").Direction = ParameterDirection.Input
            cmd.Parameters("@NAME_SUPPLIER").Direction = ParameterDirection.Input
            cmd.Parameters("@EXPIRATION_TOLERANCE").Direction = ParameterDirection.Input



            cmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            cmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            cmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            cmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            cmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            cmd.Parameters("@SHORT_NAME").Value = pSHORT_NAME
            cmd.Parameters("@VOLUME_FACTOR").Value = pVOLUME_FACTOR
            cmd.Parameters("@MATERIAL_CLASS").Value = pMATERIAL_CLASS
            cmd.Parameters("@MATERIAL_SUB_CLASS").Value = pMATERIAL_SUB_CLASS
            cmd.Parameters("@HIGH").Value = pHIGH
            cmd.Parameters("@LENGTH").Value = pLENGTH
            cmd.Parameters("@WIDTH").Value = pWIDTH
            cmd.Parameters("@MAX_X_BIN").Value = pMAX_X_BIN
            cmd.Parameters("@SCAN_BY_ONE").Value = pSCAN_BY_ONE
            cmd.Parameters("@REQUIRES_LOGISTICS_INFO").Value = pREQUIRES_LOGISTICS_INFO
            cmd.Parameters("@WEIGTH").Value = pWEIGTH
            cmd.Parameters("@LOGIN").Value = pLAST_UPDATED_BY
            cmd.Parameters("@IS_CAR").Value = pIS_CAR
            cmd.Parameters("@MT3").Value = pVOLUME_FACTOR
            cmd.Parameters("@BATCH_REQUESTED").Value = pBatchRequested
            cmd.Parameters("@SERIAL_NUMBER_REQUESTS").Value = serialNumberRequests
            cmd.Parameters("@IS_MASTER_PACK").Value = isMasterPack
            cmd.Parameters("@ERP_AVERAGE_PRICE").Value = 0
            cmd.Parameters("@WEIGHT_MEASUREMENT").Value = weightMeasurement
            cmd.Parameters("@EXPLODE_IN_RECEPTION").Value = explodeInReception
            cmd.Parameters("@HANDLE_TONE").Value = handleTone
            cmd.Parameters("@HANDLE_CALIBER").Value = handleCaliber
            cmd.Parameters("@USE_PICKING_LINE").Value = usePickingLine
            cmd.Parameters("@QUALITY_CONTROL").Value = pQUALITY_CONTROL
            cmd.Parameters("@PREFIX_CORRELATIVE_SERIALS").Value = PREFIX_CORRELATIVE_SERIALS
            cmd.Parameters("@HANDLE_CORRELATIVE_SERIALS").Value = HANDLE_CORRELATIVE_SERIALS
            cmd.Parameters("@LEAD_TIME").Value = LEAD_TIME
            cmd.Parameters("@SUPPLIER").Value = SUPPLIER
            cmd.Parameters("@NAME_SUPPLIER").Value = NAME_SUPPLIER
            cmd.Parameters("@EXPIRATION_TOLERANCE").Value = EXPIRATION_TOLERANCE



            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_INSERT_MATERIAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteReader()
            resultado = "OK"
            Return True
        Catch ex As Exception
            resultado = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Get a Material by Key that are related with multiple clients")>
    Public Function SearchByBarCodeMultipleClients(ByVal pBARCODE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim xbarcode As String = ""
        xbarcode = pBARCODE_ID.Replace(" ", "")

        XSQL = "SELECT A.*,  B.CLIENT_CODE, B.CLIENT_NAME FROM  " + DefaultSchema + "OP_WMS_MATERIALS A,  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS B "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " (A.BARCODE_ID = '" + xbarcode.ToUpper.Trim + "' OR A.alternate_barcode = '" + xbarcode.ToUpper.Trim + "') AND B.CLIENT_CODE =  A.CLIENT_OWNER COLLATE DATABASE_DEFAULT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByBarCodeMultipleClients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing

        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe SKU: " + pBARCODE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get a Material by Key that are related with multiple clients (only for ajax request)")>
    Public Function SearchByBarCodeMultipleClientsJava(ByVal pBARCODE_ID As String) As String

        Dim XSQL As String = ""
        Dim pResult As String
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim xbarcode As String = ""
        xbarcode = pBARCODE_ID.Replace(" ", "")

        XSQL = "SELECT A.*, B.CLIENT_CODE, B.CLIENT_NAME  FROM  " + DefaultSchema + "OP_WMS_MATERIALS A,  " + DefaultSchema + "OP_WMS_VIEW_CLIENTS B "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " (A.BARCODE_ID = '" + xbarcode.ToUpper.Trim + "' OR A.alternate_barcode = '" + xbarcode.ToUpper.Trim + "') AND B.CLIENT_CODE =  A.CLIENT_OWNER COLLATE DATABASE_DEFAULT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByBarCodeMultipleClients")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return pResult

        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe SKU: " + pBARCODE_ID
            Return pResult
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If

    End Function
    Public Function GetJson(ByVal dt As DataTable) As String

        Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))
        Dim row As Dictionary(Of String, Object)

        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next

        Return serializer.Serialize(rows)
    End Function
    <WebMethod(Description:="Get a Material by Key")>
    Public Function SearchByBarCode(ByVal pBARCODE_ID As String, ByVal pCLIENT_OWNER As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim xbarcode As String = ""
        xbarcode = pBARCODE_ID.Replace(" ", "")

        XSQL = "SELECT TOP 1 * FROM  " + DefaultSchema + "OP_WMS_MATERIALS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " (BARCODE_ID = '" + xbarcode.ToUpper.Trim + "' OR alternate_barcode = '" + xbarcode.ToUpper.Trim + "') AND CLIENT_OWNER = '" & pCLIENT_OWNER & "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByBarCode")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe SKU: " + pBARCODE_ID + " Cliente: " & pCLIENT_OWNER
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function


    <WebMethod(Description:="Obtiene el material por código de barra y licencia.")>
    Public Function ObtenerMaterialPorCodigoDeBarraYLicencia(ByVal codigoBarra As String, ByVal cliente As String,
                                                          ByVal licencia As Integer, ByVal tarea As Integer,
                                                          ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        conexion.Open()
        Try
            Dim comando As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            comando.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar, 25)
            comando.Parameters("@BARCODE_ID").Direction = ParameterDirection.Input
            comando.Parameters("@BARCODE_ID").Value = codigoBarra

            comando.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar, 25)
            comando.Parameters("@CLIENT_OWNER").Direction = ParameterDirection.Input
            comando.Parameters("@CLIENT_OWNER").Value = cliente

            comando.Parameters.Add("@LICENSE_ID", SqlDbType.Decimal)
            comando.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            comando.Parameters("@LICENSE_ID").Value = licencia

            comando.Parameters.Add("@TASK_ID", SqlDbType.Decimal)
            comando.Parameters("@TASK_ID").Direction = ParameterDirection.Input
            comando.Parameters("@TASK_ID").Value = tarea

            comando.CommandText = DefaultSchema + "[OP_WMS_GET_SCANNED_MATERIAL_BY_LICENSE_IN_RECEPTION_TASK]"
            comando.CommandType = CommandType.StoredProcedure
            comando.Connection = conexion
            reader = comando.ExecuteReader()
            dt.Load(reader)
            If dt.Rows.Count <= 0 Then
                pResult = "ERROR, No existe SKU: " + codigoBarra
                Return Nothing
            Else
                pResult = "OK"
                Return dt
            End If
        Catch ex As Exception
            pResult = ex.Message
        Finally
            conexion.Close()
            conexion.Dispose()
            conexion = Nothing
        End Try
    End Function

    '19-Jul-10 J.R se agrego campo Max_X_Bin
    <WebMethod(Description:="Update a Material")>
    Public Function UpdateMaterials(ByVal pCLIENT_OWNER As String,
                                    ByVal pMATERIAL_ID As String,
                                    ByVal pBARCODE_ID As String,
                                    ByVal pALTERNATE_BARCODE As String,
                                    ByVal pMATERIAL_NAME As String,
                                    ByVal pSHORT_NAME As String,
                                    ByVal pVOLUME_FACTOR As Double,
                                    ByVal pMATERIAL_CLASS As String,
                                    ByVal pMATERIAL_SUB_CLASS As String,
                                    ByVal pHIGH As Double,
                                    ByVal pLENGTH As Double,
                                    ByVal pWIDTH As Double,
                                    ByVal pMAX_X_BIN As Integer,
                                    ByVal pSCAN_BY_ONE As Integer,
                                    ByVal pREQUIRES_LOGISTICS_INFO As Integer,
                                    ByVal pWEIGTH As Decimal,
                                    ByVal pLAST_UPDATED_BY As String,
                                    ByVal IS_CAR As Integer,
                                    ByVal pBatchRequested As Integer,
                                    ByRef resultado As String,
                                    ByVal ambiente As String,
                                    ByVal serialNumberRequests As Integer,
                                    isMasterPack As Integer,
                                    ByVal weightMeasurement As String,
                                     explodeInReception As Integer,
                                    handleTone As Integer,
                                    handleCaliber As Integer,
                                    ByVal usePickingLine As String,
                                    ByVal pQUALITY_CONTROL As Integer,
                                    ByVal PREFIX_CORRELATIVE_SERIALS As String,
                                    ByVal HANDLE_CORRELATIVE_SERIALS As Integer,
                                    ByVal LEAD_TIME As Integer,
                                    ByVal SUPPLIER As String,
                                    ByVal NAME_SUPPLIER As String,
                                    ByVal EXPIRATION_TOLERANCE As Integer
                                    ) As Boolean
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@ALTERNATE_BARCODE", SqlDbType.VarChar, 24)
            cmd.Parameters.Add("@MATERIAL_NAME", SqlDbType.VarChar, 200)
            cmd.Parameters.Add("@SHORT_NAME", SqlDbType.VarChar, 200)
            cmd.Parameters.Add("@VOLUME_FACTOR", SqlDbType.Decimal)
            cmd.Parameters.Add("@MATERIAL_CLASS", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@MATERIAL_SUB_CLASS", SqlDbType.VarChar, 25)
            cmd.Parameters.Add("@HIGH", SqlDbType.Decimal)
            cmd.Parameters.Add("@LENGTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@WIDTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@MAX_X_BIN", SqlDbType.Int)
            cmd.Parameters.Add("@SCAN_BY_ONE", SqlDbType.Int)
            cmd.Parameters.Add("@REQUIRES_LOGISTICS_INFO", SqlDbType.Int)
            cmd.Parameters.Add("@WEIGTH", SqlDbType.Decimal)
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@IS_CAR", SqlDbType.Int)
            cmd.Parameters.Add("@MT3", SqlDbType.Decimal)
            cmd.Parameters.Add("@BATCH_REQUESTED", SqlDbType.Int)
            cmd.Parameters.Add("@SERIAL_NUMBER_REQUESTS", SqlDbType.Int)
            cmd.Parameters.Add("@IS_MASTER_PACK", SqlDbType.Int)
            cmd.Parameters.Add("@ERP_AVERAGE_PRICE", SqlDbType.Decimal)
            cmd.Parameters.Add("@WEIGHT_MEASUREMENT", SqlDbType.VarChar, 50)
            cmd.Parameters.Add("@EXPLODE_IN_RECEPTION", SqlDbType.Int)
            cmd.Parameters.Add("@HANDLE_TONE", SqlDbType.Int)
            cmd.Parameters.Add("@HANDLE_CALIBER", SqlDbType.Int)
            cmd.Parameters.Add("@USE_PICKING_LINE", SqlDbType.Int)
            cmd.Parameters.Add("@QUALITY_CONTROL", SqlDbType.Int)
            cmd.Parameters.Add("@PREFIX_CORRELATIVE_SERIALS", SqlDbType.VarChar)
            cmd.Parameters.Add("@HANDLE_CORRELATIVE_SERIALS", SqlDbType.Int)
            cmd.Parameters.Add("@LEAD_TIME", SqlDbType.Int)
            cmd.Parameters.Add("@SUPPLIER", SqlDbType.VarChar, 64)
            cmd.Parameters.Add("@NAME_SUPPLIER", SqlDbType.VarChar, 250)
            cmd.Parameters.Add("@EXPIRATION_TOLERANCE", SqlDbType.Int)


            cmd.Parameters("@CLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@BARCODE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@ALTERNATE_BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@SHORT_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@VOLUME_FACTOR").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_CLASS").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_SUB_CLASS").Direction = ParameterDirection.Input
            cmd.Parameters("@HIGH").Direction = ParameterDirection.Input
            cmd.Parameters("@LENGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@WIDTH").Direction = ParameterDirection.Input
            cmd.Parameters("@MAX_X_BIN").Direction = ParameterDirection.Input
            cmd.Parameters("@SCAN_BY_ONE").Direction = ParameterDirection.Input
            cmd.Parameters("@REQUIRES_LOGISTICS_INFO").Direction = ParameterDirection.Input
            cmd.Parameters("@WEIGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@IS_CAR").Direction = ParameterDirection.Input
            cmd.Parameters("@MT3").Direction = ParameterDirection.Input
            cmd.Parameters("@BATCH_REQUESTED").Direction = ParameterDirection.Input
            cmd.Parameters("@SERIAL_NUMBER_REQUESTS").Direction = ParameterDirection.Input
            cmd.Parameters("@IS_MASTER_PACK").Direction = ParameterDirection.Input
            cmd.Parameters("@ERP_AVERAGE_PRICE").Direction = ParameterDirection.Input
            cmd.Parameters("@WEIGHT_MEASUREMENT").Direction = ParameterDirection.Input
            cmd.Parameters("@EXPLODE_IN_RECEPTION").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_TONE").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_CALIBER").Direction = ParameterDirection.Input
            cmd.Parameters("@USE_PICKING_LINE").Direction = ParameterDirection.Input
            cmd.Parameters("@QUALITY_CONTROL").Direction = ParameterDirection.Input
            cmd.Parameters("@PREFIX_CORRELATIVE_SERIALS").Direction = ParameterDirection.Input
            cmd.Parameters("@HANDLE_CORRELATIVE_SERIALS").Direction = ParameterDirection.Input
            cmd.Parameters("@LEAD_TIME").Direction = ParameterDirection.Input
            cmd.Parameters("@SUPPLIER").Direction = ParameterDirection.Input
            cmd.Parameters("@NAME_SUPPLIER").Direction = ParameterDirection.Input
            cmd.Parameters("@EXPIRATION_TOLERANCE").Direction = ParameterDirection.Input

            cmd.Parameters("@CLIENT_OWNER").Value = pCLIENT_OWNER
            cmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID
            cmd.Parameters("@BARCODE_ID").Value = pBARCODE_ID
            cmd.Parameters("@ALTERNATE_BARCODE").Value = pALTERNATE_BARCODE
            cmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME
            cmd.Parameters("@SHORT_NAME").Value = pSHORT_NAME
            cmd.Parameters("@VOLUME_FACTOR").Value = pVOLUME_FACTOR
            cmd.Parameters("@MATERIAL_CLASS").Value = pMATERIAL_CLASS
            cmd.Parameters("@MATERIAL_SUB_CLASS").Value = pMATERIAL_SUB_CLASS
            cmd.Parameters("@HIGH").Value = pHIGH
            cmd.Parameters("@LENGTH").Value = pLENGTH
            cmd.Parameters("@WIDTH").Value = pWIDTH
            cmd.Parameters("@MAX_X_BIN").Value = pMAX_X_BIN
            cmd.Parameters("@SCAN_BY_ONE").Value = pSCAN_BY_ONE
            cmd.Parameters("@REQUIRES_LOGISTICS_INFO").Value = pREQUIRES_LOGISTICS_INFO
            cmd.Parameters("@WEIGTH").Value = pWEIGTH
            cmd.Parameters("@LOGIN").Value = pLAST_UPDATED_BY
            cmd.Parameters("@IS_CAR").Value = IS_CAR
            cmd.Parameters("@MT3").Value = pVOLUME_FACTOR
            cmd.Parameters("@BATCH_REQUESTED").Value = pBatchRequested
            cmd.Parameters("@SERIAL_NUMBER_REQUESTS").Value = serialNumberRequests
            cmd.Parameters("@IS_MASTER_PACK").Value = isMasterPack
            cmd.Parameters("@ERP_AVERAGE_PRICE").Value = 0
            cmd.Parameters("@WEIGHT_MEASUREMENT").Value = weightMeasurement
            cmd.Parameters("@EXPLODE_IN_RECEPTION").Value = explodeInReception
            cmd.Parameters("@HANDLE_TONE").Value = handleTone
            cmd.Parameters("@HANDLE_CALIBER").Value = handleCaliber
            cmd.Parameters("@USE_PICKING_LINE").Value = usePickingLine
            cmd.Parameters("@QUALITY_CONTROL").Value = pQUALITY_CONTROL
            cmd.Parameters("@PREFIX_CORRELATIVE_SERIALS").Value = PREFIX_CORRELATIVE_SERIALS
            cmd.Parameters("@HANDLE_CORRELATIVE_SERIALS").Value = HANDLE_CORRELATIVE_SERIALS
            cmd.Parameters("@LEAD_TIME").Value = LEAD_TIME
            cmd.Parameters("@SUPPLIER").Value = SUPPLIER
            cmd.Parameters("@NAME_SUPPLIER").Value = NAME_SUPPLIER
            cmd.Parameters("@EXPIRATION_TOLERANCE").Value = EXPIRATION_TOLERANCE

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_MATERIAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteReader()
            resultado = "OK"
            Return True
        Catch ex As Exception
            resultado = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Delete a Material")>
    Public Function DeleteMaterials(ByVal pBARCODE_ID As String, ByVal pCLIENT_OWNER As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE " & DefaultSchema & "OP_WMS_MATERIALS"
        XSQL = XSQL + " WHERE MATERIAL_ID = '" + pBARCODE_ID + "'"
        XSQL = XSQL + " AND CLIENT_OWNER = '" + pCLIENT_OWNER + "'"
        Try
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Get a Material by Key")>
    Public Function SearchByKeyMaterials(ByVal pMATERIAL_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_MATERIALS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " MATERIAL_ID = '" + pMATERIAL_ID.ToUpper + "'"
        'XSQL = XSQL + " ORDER BY "
        'SQL = XSQL + "MATERIAL_ID"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_Materials")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            'LogSQLErrors("SearchByKeyMaterials", XSQL, "")
            pResult = "ERROR,No existe Material: " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Materials by partial search")>
    Public Function SearchPartialMaterials(ByVal pMATERIAL_ID As String, ByVal pMATERIAL_NAME As String, ByVal pSHORT_NAME As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Try
            Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldb_conexion.Open()

            Dim miscDS As DataSet = New DataSet()
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Resultado")

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = pMATERIAL_ID

            cmd.Parameters.Add("@MATERIAL_NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_NAME").Value = pMATERIAL_NAME

            cmd.Parameters.Add("@SHORT_NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@SHORT_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@SHORT_NAME").Value = pSHORT_NAME

            cmd.CommandText = DefaultSchema + "[OP_WMS_SEARCH_PARTIAL_MATERIALS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldb_conexion.Close()

            miscDS.Tables.Add(dt)

            If miscDS.Tables(0).Rows.Count <= 0 Then
                pResult = "ERROR,No existe Materials : " + pMATERIAL_ID
                Return Nothing
            Else
                pResult = "OK"
                Return miscDS
            End If
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
    End Function
    <WebMethod(Description:="Get Materials by partial search sector 1")>
    Public Function GetMaterialsSector1(ByVal pMATERIAL_ID As String, ByVal pMATERIAL_NAME As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_MATERIALS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " (UPPER(MATERIAL_ID) LIKE '%" + pMATERIAL_ID.ToUpper + "%' OR "
        XSQL = XSQL + " UPPER(MATERIAL_NAME) LIKE '%" + pMATERIAL_NAME.ToUpper + "%' "
        XSQL = XSQL + " OR BARCODE_ID = '" + pMATERIAL_ID + "' "
        XSQL = XSQL + " OR ALTERNATE_BARCODE = '" + pMATERIAL_ID + "') "
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "MATERIAL_ID, "
        XSQL = XSQL + "MATERIAL_NAME, "
        XSQL = XSQL + "SHORT_NAME"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_Materials")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Materials : " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function


    <WebMethod(Description:="Update a Volume Factor for a specific material")>
    Public Function UpdateVolumeFactor(ByVal pMATERIAL_ID As String, ByVal pALTO As Double, ByVal pLARGO As Double, ByVal pANCHO As Double, ByVal pVOLUME_FACTOR As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_MATERIALS SET "
            XSQL = XSQL + "VOLUME_FACTOR = " + pVOLUME_FACTOR.ToString + ","
            XSQL = XSQL + "ALTO = " + pALTO.ToString + ","
            XSQL = XSQL + "LARGO= " + pLARGO.ToString + ","
            XSQL = XSQL + "ANCHO= " + pANCHO.ToString + ""
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "MATERIAL_ID = '" + pMATERIAL_ID + "'"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then

                Return True
            Else

                Return False
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function
    <WebMethod(Description:="Update a Volume Factor for multiple SKUs")>
    Public Function UpdateVolumeFactorMultipleSKUs(ByVal pBARCODE_SKU As String, ByVal pALTO As String, ByVal pLARGO As String, ByVal pANCHO As String, ByVal pVOLUME_FACTOR As String, ByVal pPESO As String, ByVal pMT3 As String) As String

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings("DESARROLLO").ToString)
        Dim XSQL As String = ""
        Dim pResult As String = ""

        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_MATERIALS SET "
            XSQL = XSQL + "VOLUME_FACTOR = " + pVOLUME_FACTOR + ","
            XSQL = XSQL + "HIGH = " + pALTO + ","
            XSQL = XSQL + "LENGTH= " + pLARGO + ","
            XSQL = XSQL + "WIDTH= " + pANCHO + ","
            XSQL = XSQL + "WEIGTH= " + pPESO + ","
            XSQL = XSQL + "MT3= " + pMT3 + ""
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + "(BARCODE_ID = '" + pBARCODE_SKU.ToUpper.Trim + "' OR alternate_barcode = '" + pBARCODE_SKU.ToUpper.Trim + "')"

            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return "OK"
            Else
                Return "ERROR," + pResult
            End If

        Catch ex As Exception
            pResult = ex.Message
            Return "ERROR," + pResult
        End Try

    End Function
    <WebMethod(Description:="Get the list of related locations where to store the material")>
    Public Function GetRelatedLocations(ByVal pMATERIAL_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(MATERIAL_ID) = '" + pMATERIAL_ID.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "WAREHOUSE_PARENT, LOCATION_SPOT"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetRelatedLocations")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Material: " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Delete a Material")>
    Public Function DeleteMaterials_X_Location(ByVal pMATERIAL_ID As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "DELETE " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "MATERIAL_ID = '" + pMATERIAL_ID + "' AND "
        XSQL = XSQL + "WAREHOUSE_PARENT = '" + pWAREHOUSE_PARENT + "' AND "
        XSQL = XSQL + "LOCATION_SPOT = '" + pLOCATION_SPOT + "'"

        Try
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function

    <WebMethod(Description:="Join Material with Locations")>
    Public Function CreateMaterial_Join_SpotLocations(ByVal pMATERIAL_ID As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByVal pUSER_ID As String, ByVal pMIN_QTY As Integer, ByVal pMAX_QTY As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Dim pSQL As String = ""
        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS("
            XSQL = XSQL + "MATERIAL_ID,"
            XSQL = XSQL + "WAREHOUSE_PARENT,"
            XSQL = XSQL + "LOCATION_SPOT,"
            XSQL = XSQL + "LAST_UPDATED_BY, MIN_QUANTITY, MAX_QUANTITY)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pMATERIAL_ID + "',"
            XSQL = XSQL + "'" + pWAREHOUSE_PARENT + "',"
            XSQL = XSQL + "'" + pLOCATION_SPOT + "',"
            XSQL = XSQL + "'" + pUSER_ID + "', " + pMIN_QTY.ToString + "," + pMAX_QTY.ToString + ")"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
        Return True
    End Function

    <WebMethod(Description:="Update Min and Max for the Material and Locations join")>
    Public Function Update_Join_SpotLocations(ByVal pMATERIAL_ID As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByVal pUSER_ID As String, ByVal pMIN_QTY As Double, ByVal pMAX_QTY As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS SET "
            XSQL = XSQL + " LAST_UPDATED = CURRENT_TIMESTAMP, LAST_UPDATED_BY = '" + pUSER_ID + "', MIN_QUANTITY = " + pMIN_QTY.ToString + ", MAX_QUANTITY = " + pMAX_QTY.ToString
            XSQL = XSQL + " WHERE MATERIAL_ID = '" + pMATERIAL_ID + "' AND "
            XSQL = XSQL + " WAREHOUSE_PARENT = '" + pWAREHOUSE_PARENT + "' AND "
            XSQL = XSQL + " LOCATION_SPOT = '" + pLOCATION_SPOT + "'"
            If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try

    End Function


    <WebMethod(Description:="Get the list of related locations where to store the material")>
    Public Function GetLocationsAvailableToRelate(ByVal pMATERIAL_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = "SELECT A.WAREHOUSE_PARENT, A.LOCATION_SPOT, A.ZONE FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS A "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " A.LOCATION_SPOT NOT IN "
        XSQL = XSQL + " (SELECT B.LOCATION_SPOT FROM " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS B "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " B.MATERIAL_ID = '" + pMATERIAL_ID.ToUpper + "' AND B.WAREHOUSE_PARENT = A.WAREHOUSE_PARENT AND B.LOCATION_SPOT = A.LOCATION_SPOT)"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "A.WAREHOUSE_PARENT, A.LOCATION_SPOT"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetRelatedLocations")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Material: " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="QuickSKU_Mantainance")>
    Public Function QuickSKU_Mantainance(ByVal pCLIENT_OWNER As String, ByVal pMATERIAL_NAME As String, ByVal pBARCODE As String, ByVal pLAST_LOGIN As String, ByVal pIMAGE_1 As Byte(), ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
            cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

            cmd.Parameters.Add("@pMATERIAL_NAME", SqlDbType.VarChar, 150)
            cmd.Parameters("@pMATERIAL_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@pMATERIAL_NAME").Value = pMATERIAL_NAME

            cmd.Parameters.Add("@pBARCODE", SqlDbType.VarChar, 25)
            cmd.Parameters("@pBARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@pBARCODE").Value = pBARCODE

            cmd.Parameters.Add("@pLAST_LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLAST_LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@pLAST_LOGIN").Value = pLAST_LOGIN

            cmd.Parameters.Add("@pIMAGE_1", SqlDbType.Image)
            cmd.Parameters("@pIMAGE_1").Direction = ParameterDirection.Input
            cmd.Parameters("@pIMAGE_1").Value = pIMAGE_1


            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_QUICK_SKU_MANTENAINCE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()
            
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Get the list of related locations where to store the material")>
    Public Function GetTotalFactorVolumeLicense(ByVal pLicenseId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim XSQL As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        XSQL = " SELECT isnull(sum(m.VOLUME_FACTOR), 0) AS Total from " & DefaultSchema & "OP_WMS_INV_X_LICENSE il "
        XSQL = XSQL + " INNER JOIN " & DefaultSchema & "OP_WMS_MATERIALS m ON il.MATERIAL_ID = m.MATERIAL_ID "
        XSQL = XSQL + " where LICENSE_ID = " + pLicenseId.ToString()

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetTotalFactorVolumeLicense")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existe Material: " + pLicenseId
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="GetIfExistsMaterialByClient")>
    Public Function GetIfExistsMaterialByClient(ByVal clientOwner As String, ByVal materialId As String, ByRef result As String, ByVal environmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar, 25)
            cmd.Parameters("@CLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_OWNER").Value = clientOwner
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATED_IF_MATERIAL_EXISTS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()

            dt.Load(reader)

            result = "OK"

            If dt.Rows(0).Item(0) = 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="LoadMaterialByXml")>
    Public Function LoadMaterialByXml(ByVal xmlDeMaterial As String, ByVal xmlDeUbicacion As String, ByVal xmlDeUnidadDeMedida As String, ByVal xmlDeMasterPack As String, ByVal xmlDePropiedades As String, ByVal login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim ds As DataSet = New DataSet()
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqldb_conexion.Open()
            Dim cmd As New SqlCommand

            If xmlDeMaterial <> "" Then
                cmd.Parameters.Add("@MATERIALS", SqlDbType.Xml)
                cmd.Parameters("@MATERIALS").Direction = ParameterDirection.Input
                cmd.Parameters("@MATERIALS").Value = xmlDeMaterial
            End If


            If xmlDeUbicacion <> "" Then
                cmd.Parameters.Add("@LOCATIONS", SqlDbType.Xml)
                cmd.Parameters("@LOCATIONS").Direction = ParameterDirection.Input
                cmd.Parameters("@LOCATIONS").Value = xmlDeUbicacion
            End If

            If xmlDeUnidadDeMedida <> "" Then
                cmd.Parameters.Add("@UNIT_MEASURE_BY_MATERIAL_XML", SqlDbType.Xml)
                cmd.Parameters("@UNIT_MEASURE_BY_MATERIAL_XML").Direction = ParameterDirection.Input
                cmd.Parameters("@UNIT_MEASURE_BY_MATERIAL_XML").Value = xmlDeUnidadDeMedida
            End If

            If xmlDeMasterPack <> "" Then
                cmd.Parameters.Add("@MASTER_PACKS", SqlDbType.Xml)
                cmd.Parameters("@MASTER_PACKS").Direction = ParameterDirection.Input
                cmd.Parameters("@MASTER_PACKS").Value = xmlDeMasterPack
            End If

            If xmlDePropiedades <> "" Then
                cmd.Parameters.Add("@PROPERTIES", SqlDbType.Xml)
                cmd.Parameters("@PROPERTIES").Direction = ParameterDirection.Input
                cmd.Parameters("@PROPERTIES").Value = xmlDePropiedades
            End If

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_LOAD_MATERIAL_BY_XML]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(cmd)

            miscDA.Fill(ds)

            If ds Is Nothing Or ds.Tables.Count < 1 Then
                pResult = "ERROR, al cargar realizar la carga"
                ds.Tables.Add(FormarObjetoOperacion(-1, "ERROR, al cargar realizar la carga", -1, ""))

            Else
                If ds.Tables.Count > 1 Then
                    pResult = ds.Tables(0).Rows(0)(1).ToString()
                Else
                    pResult = "OK"
                End If
            End If
            Return ds
        Catch ex As Exception
            ds.Tables.Add(FormarObjetoOperacion(-1, ex.Message, -1, ""))
            pResult = "ERROR," + ex.Message
            Return ds
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    Private Function FormarObjetoOperacion(ByVal resultado As Integer, ByVal mensaje As String, ByVal codigo As Integer, ByVal dbData As String) As DataTable
        Dim dt As DataTable = New DataTable("Operacion")
        dt.Columns.Add("Resultado", Type.GetType("System.Int"))
        dt.Columns.Add("Mensaje", Type.GetType("System.String"))
        dt.Columns.Add("Codigo", Type.GetType("System.Int"))
        dt.Columns.Add("DbData", Type.GetType("System.String"))
        dt.Rows.Add(resultado, mensaje, codigo, dbData)

        Return dt
    End Function

    <WebMethod(Description:="ObtenerClasesParaMaterial")>
    Public Function ObtenerClasesParaMaterial(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_CLASSES]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()

            Try
                miscDa.Fill(miscDs, "Clases")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If
            pResult = "OK"
            Return miscDs.Tables(0)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ObtenerClasePorNombre")>
    Public Function ObtenerClasePorNombre(ByRef pResult As String, ByRef ClassName As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_CLASSES_BY_NAME]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@NAME").Value = ClassName

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()
            Dim dt = New DataTable()

            Try
                miscDa.Fill(miscDs, "Clases")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            dt = miscDs.Tables(0)

            If dt Is Nothing Or dt.Rows.Count <= 0 Then
                pResult = "Empty"
                Return Nothing
            End If
            pResult = "OK"
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ObtenerSubClasesParaMaterial")>
    Public Function ObtenerSubClasesParaMaterial(ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_SUB_CLASSES]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()

            Try
                miscDa.Fill(miscDs, "Clases")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If
            pResult = "OK"
            Return miscDs.Tables(0)
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ObtenerSubClasePorNombre")>
    Public Function ObtenerSubClasePorNombre(ByRef pResult As String, ByRef SubClassName As String, ByVal pEnvironmentName As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_GET_SUB_CLASSES_BY_NAME]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@NAME", SqlDbType.VarChar, 50)
            cmd.Parameters("@NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@NAME").Value = SubClassName

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()
            Dim dt = New DataTable()

            Try
                miscDa.Fill(miscDs, "SubClases")
            Catch ex As Exception
                pResult = $"ERROR, {ex.Message}"
                Return Nothing
            End Try

            dt = miscDs.Tables(0)

            If dt Is Nothing Or dt.Rows.Count <= 0 Then
                pResult = "Empty"
                Return Nothing
            End If
            pResult = "OK"
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ValidarSiMaterialEsMasterPack")>
    Public Function ValidarSiMaterialEsMasterPack(ByVal ambiente As String, ByVal material As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim tabla = New DataTable("Operacion")

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_IS_MASTER_PACK]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@MATERIAL", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL").Value = material

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tabla)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ValidarInventarioDeImplosionDeMasterpack")>
    Public Function ValidarInventarioDeImplosionDeMasterpack(ByVal ambiente As String, ByVal codigoDeMaterial As String, ByVal codigoDeBodega As String, ByVal cantidad As Int32) As DataSet
        Dim tablas = New DataSet()
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_INVENTORY_FOR_MASTERPACK_IMPLOSION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = codigoDeMaterial

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = codigoDeBodega

            cmd.Parameters.Add("@QUANTITY", SqlDbType.Int)
            cmd.Parameters("@QUANTITY").Direction = ParameterDirection.Input
            cmd.Parameters("@QUANTITY").Value = cantidad

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tablas)
            Return tablas
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            tablas.Tables.Add(tablaDeError)
            Return tablas
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ValidarLicenciaEnImplosion")>
    Public Function ValidarLicenciaEnImplosion(ByVal ambiente As String, ByVal licencia As Int32, ByVal codigoDeBodega As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim tabla = New DataTable("Operacion")

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_LICENSE_IN_IMPLOSION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licencia

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = codigoDeBodega

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tabla)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="AgregarControlDeMasterPackEnImplosion")>
    Public Function AgregarControlDeMasterPackEnImplosion(ByVal ambiente As String, ByVal codigoDeMasterPack As String, ByVal cantidad As Decimal, ByVal usuario As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim tabla = New DataTable("Operacion")

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_INSERT_MASTER_PACK_IMPLOSION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@MASTER_PACK_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_CODE").Value = codigoDeMasterPack

            cmd.Parameters.Add("@QTY", SqlDbType.Decimal)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = cantidad

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tabla)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="AgregarParteDeImplosionATarea")>
    Public Function AgregarParteDeImplosionATarea(ByVal ambiente As String, ByVal licencia As Int32, ByVal codigoDeMaterial As String, ByVal cantidad As Decimal,
                                                   ByVal usuario As String, ByVal codigoDeMaterPack As String, ByVal licenciaDestino As Int32) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim tabla = New DataTable("Operacion")

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_INSERT_IMPLOSION_STEP_IN_TASK_LIST]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licencia

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = codigoDeMaterial

            cmd.Parameters.Add("@QTY", SqlDbType.Decimal)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = cantidad

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            cmd.Parameters.Add("@MASTER_PACK_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_ID").Value = codigoDeMaterPack

            cmd.Parameters.Add("@LICENSE_ID_TARGET", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID_TARGET").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID_TARGET").Value = licenciaDestino

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tabla)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="CancelarImplosionEnProgreso")>
    Public Function CancelarImplosionEnProgreso(ByVal ambiente As String, ByVal licencia As Int32, ByVal codigoDeMaterPack As String, ByVal usuario As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim tabla As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licencia

            cmd.Parameters.Add("@MASTER_PACK_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_CODE").Value = codigoDeMaterPack

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ROLLBACK_IMPLOSION_IN_PROGRESS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            tabla.Load(reader)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ObtenerInventarioDeMaterialPorLicencia")>
    Public Function ObtenerInventarioDeMaterialPorLicencia(ByVal ambiente As String, ByVal licenciaOrigen As Int32, ByVal licenciaDestino As Int32, ByVal codigoDeMaterPack As String, ByVal material As String, ByVal bodega As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim tabla As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@LICENSE_ID_SOURCE", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID_SOURCE").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID_SOURCE").Value = licenciaOrigen

            cmd.Parameters.Add("@LICENSE_ID_TARGET", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID_TARGET").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID_TARGET").Value = licenciaDestino

            cmd.Parameters.Add("@MASTER_PACK_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_ID").Value = codigoDeMaterPack

            cmd.Parameters.Add("@MATERIAL", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL").Value = material

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 25)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = bodega

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INVENTORY_BY_MATERIAL_AND_LICENSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            tabla.Load(reader)
            Return tabla
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            Return tablaDeError
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="ObtenerDetalleDeImplosionEnProceso")>
    Public Function ObtenerDetalleDeImplosionEnProceso(ByVal ambiente As String, ByRef resultado As String, ByVal licencia As Int32, ByVal codigoDeMaterial As String, ByVal cantidad As Decimal) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim tabla As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licencia

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = codigoDeMaterial

            cmd.Parameters.Add("@QTY ", SqlDbType.Decimal)
            cmd.Parameters("@QTY ").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY ").Value = cantidad

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_COMPONENTS_FOR_IMPLOSION_WITH_PROCESSED_DETAIL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            tabla.Load(reader)

            resultado = "OK"
            Return tabla
        Catch ex As Exception
            resultado = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="FinalizarImplosionDeMasterpack")>
    Public Function FinalizarImplosionDeMasterpack(ByVal ambiente As String, ByRef ubicacion As String, ByVal licencia As Int32, ByVal codigoDeMaterial As String, ByVal cantidad As Decimal, usuario As String) As DataSet
        Dim tablas = New DataSet()
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_FINISH_IMPLOSION]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = codigoDeMaterial

            cmd.Parameters.Add("@LOCATION_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOCATION_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOCATION_ID").Value = ubicacion

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licencia

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = cantidad

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tablas)
            Return tablas
        Catch ex As Exception
            Dim tablaDeError As DataTable = New DataTable("Operacion")

            tablaDeError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("Mensaje", Type.GetType("System.String"))
            tablaDeError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            tablaDeError.Columns.Add("DbData", Type.GetType("System.String"))

            tablaDeError.Rows.Add(-1, ex.Message, -1, "")
            tablas.Tables.Add(tablaDeError)
            Return tablas
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function
#Region "Manejo de Empaques"
    <WebMethod(Description:="Crea el empaque")>
    Public Function CreateMaterialUnitMesurement(ByVal clientId As String, ByVal materialId As String, ByVal measuremntUnit As String, ByVal qty As Int32, ByVal barcode As String, ByVal alternativeBarcode As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@CLIENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_ID").Value = clientId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@MEASUREMENT_UNIT", SqlDbType.VarChar, 50)
            cmd.Parameters("@MEASUREMENT_UNIT").Direction = ParameterDirection.Input
            cmd.Parameters("@MEASUREMENT_UNIT").Value = measuremntUnit

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = qty

            cmd.Parameters.Add("@BARCODE", SqlDbType.VarChar, 100)
            cmd.Parameters("@BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@BARCODE").Value = barcode

            cmd.Parameters.Add("@ALTERNATIVE_BARCODE", SqlDbType.VarChar, 100)
            cmd.Parameters("@ALTERNATIVE_BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@ALTERNATIVE_BARCODE").Value = alternativeBarcode

            cmd.CommandText = DefaultSchema + "[OP_WMS_INSERT_MEASUREMENT_UNIT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            While (Not reader.GetName(0).ToString().Equals("Resultado"))
                reader.NextResult()
            End While

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Actualiza el empaque")>
    Public Function UpdateMaterialUnitMesurement(ByVal measurementUnitId As Int32, ByVal clientId As String, ByVal materialId As String, ByVal measuremntUnit As String, ByVal qty As Int32, ByVal barcode As String, ByVal alternativeBarcode As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@MEASUREMENT_UNIT_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@MEASUREMENT_UNIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MEASUREMENT_UNIT_ID").Value = measurementUnitId

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@CLIENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_ID").Value = clientId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@MEASUREMENT_UNIT", SqlDbType.VarChar, 50)
            cmd.Parameters("@MEASUREMENT_UNIT").Direction = ParameterDirection.Input
            cmd.Parameters("@MEASUREMENT_UNIT").Value = measuremntUnit

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = qty

            cmd.Parameters.Add("@BARCODE", SqlDbType.VarChar, 100)
            cmd.Parameters("@BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@BARCODE").Value = barcode

            cmd.Parameters.Add("@ALTERNATIVE_BARCODE", SqlDbType.VarChar, 100)
            cmd.Parameters("@ALTERNATIVE_BARCODE").Direction = ParameterDirection.Input
            cmd.Parameters("@ALTERNATIVE_BARCODE").Value = alternativeBarcode

            cmd.CommandText = DefaultSchema + "[OP_WMS_UPDATE_MEASUREMENT_UNIT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            While (Not reader.GetName(0).ToString().Equals("Resultado"))
                reader.NextResult()
            End While

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Elimina el empaque")>
    Public Function DeleteMaterialUnitMesurement(ByVal measurementUnitId As Int32, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@MEASUREMENT_UNIT_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@MEASUREMENT_UNIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MEASUREMENT_UNIT_ID").Value = measurementUnitId

            cmd.CommandText = DefaultSchema + "[OP_WMS_DELETE_MEASUREMENT_UNIT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Obtiene el o los empaques segun el filtro")>
    Public Function GetUnitMesurement(ByVal clientId As String, ByVal materialId As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Resultado")

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@CLIENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_ID").Value = clientId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_GET_MEASUREMENT_UNIT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldb_conexion.Close()
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


    <WebMethod(Description:="Obtiene el o los empaques segun el filtro")>
    Public Function GetStoragePackaging(ByVal materialId As String, ByVal paramName As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim ds As New DataSet

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@PARAM_NAME", SqlDbType.NVarChar, 50)
            cmd.Parameters("@PARAM_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@PARAM_NAME").Value = paramName

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_STORAGE_PACKAGING]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="GetSuggestedLocations")>
    Public Function GetSuggestedLocations(ByVal LICENSE_ID As Integer, ByVal LOGIN_ID As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        Dim dataset As DataSet = New DataSet()
        Dim command As New SqlCommand
        pResult = "OK"
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()

            command.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            command.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            command.Parameters("@LICENSE_ID").Value = LICENSE_ID

            command.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 25)
            command.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            command.Parameters("@LOGIN_ID").Value = LOGIN_ID

            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_SUGGESTED_LOCATIONS]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldbConexion
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(dataset)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        If dataset.Tables.Count > 0 AndAlso dataset.Tables(0).Rows.Count > 0 Then
            Return dataset.Tables(0)
        Else
            pResult = "ERROR, No hay ubicaciones para sugerir"
            Return Nothing
        End If

    End Function

    <WebMethod(Description:="GetMaterialsReceptionDocumentByTask")>
    Public Function GetMaterialsReceptionDocumentByTask(ByVal SERIAL_NUMBER As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim dataset As DataSet = New DataSet()
        Dim command As New SqlCommand
        pResult = "OK"
        Try
            sqldbConexion.Open()

            command.Parameters.Add("@SERIAL_NUMBER", SqlDbType.Int)
            command.Parameters("@SERIAL_NUMBER").Direction = ParameterDirection.Input
            command.Parameters("@SERIAL_NUMBER").Value = SERIAL_NUMBER

            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_MATERIALS_RECEPTION_DOCUMENT_BY_TASK]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldbConexion
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            adapter.Fill(dataset)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
        End Try
        If dataset.Tables.Count > 0 AndAlso dataset.Tables(0).Rows.Count > 0 Then
            Return dataset.Tables(0)
        Else
            pResult = "OK"
            Return Nothing
        End If
    End Function

#End Region

#Region "Master Pack"
    <WebMethod(Description:="GetMaterialsForMasterPackComponentByClient")>
    Public Function GetMaterialsForMasterPackComponentByClient(ByVal pCLIENT_OWNER As String, masterPackMaterialId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@CLIENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_ID").Value = pCLIENT_OWNER

            cmd.Parameters.Add("@MASTER_PACK_MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_MATERIAL_ID").Value = masterPackMaterialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_GET_MATERIAL_FOR_MASTER_PACK_COMPONENT_BY_CLIENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDs As DataSet = New DataSet()

            Try
                miscDa.Fill(miscDs, "GetMaterials")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If

            pResult = "OK"
            Return miscDs.Tables(0)

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="GetMaterialsComponents")>
    Public Function GetMaterialsComponentsMasterPack(ByVal pMaterialId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = pMaterialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_MATERIALS_COMPONENTS_MASTER_PACK]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDs As DataSet = New DataSet()

            Try
                miscDa.Fill(miscDs, "ComponentMaterialsMasterPAck")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Tables.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If

            pResult = "OK"
            Return miscDs.Tables(0)

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="InsertMasterPackComponent")>
    Public Function InsertMasterPackComponent(ByVal pMasterPackCode As String, ByVal pComponentMaterialId As String, ByVal pQTY As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MASTER_PACK_CODE", SqlDbType.VarChar, 50)
            cmd.Parameters("@MASTER_PACK_CODE").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_CODE").Value = pMasterPackCode

            cmd.Parameters.Add("@COMPONENT_MATERIAL", SqlDbType.VarChar, 50)
            cmd.Parameters("@COMPONENT_MATERIAL").Direction = ParameterDirection.Input
            cmd.Parameters("@COMPONENT_MATERIAL").Value = pComponentMaterialId

            cmd.Parameters.Add("@QTY", SqlDbType.Decimal)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = pQTY

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_INSERT_MASTER_PACK_COMPONENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            pResult = "OK"
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="DeleteMasterPackComponent")>
    Public Function DeleteMasterPackComponent(ByVal pMasterPackComponentId As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@MASTER_PACK_COMPONENT_ID", SqlDbType.Int)
            cmd.Parameters("@MASTER_PACK_COMPONENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MASTER_PACK_COMPONENT_ID").Value = pMasterPackComponentId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_DELETE_MASTER_PACK_COMPONENT]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()
            pResult = "OK"
            Return True

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="MergeMasterPackComponentByLoad")>
    Public Function MergeMasterPackComponentByLoad(ByVal masterPackCode As String, ByVal componentMaterial As String, ByVal qty As Integer, ByRef result As String, ByVal environmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@CLIENT_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@CLIENT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_ID").Value = masterPackCode

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = componentMaterial

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = qty

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_MERGE_MASTER_PACK_COMPONENT_BY_LOAD]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()
            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function
#End Region

#Region "Propiedades por bodega"
    <WebMethod(Description:="Agregar propiedades por bodega")>
    Public Function AgregarPropiedadPorBodegaAMaterial(ByVal idPropiedadMaterial As Integer, ByVal materialId As String, ByVal bodega As String, ByVal valor As String,
                                                       ByVal usuario As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@MATERIAL_PROPERTY_ID", SqlDbType.Int)
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Value = idPropiedadMaterial

            cmd.Parameters.Add("@MATERIAL_ID ", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = bodega

            cmd.Parameters.Add("@VALUE", SqlDbType.VarChar, 250)
            cmd.Parameters("@VALUE").Direction = ParameterDirection.Input
            cmd.Parameters("@VALUE").Value = valor

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_CREATE_MATERIAL_PROPERTY_BY_WAREHOUSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")
            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Modificar propiedades por bodega")>
    Public Function ModificarPropiedadPorBodegaAMaterial(ByVal idPropiedadMaterial As Integer, ByVal materialId As String, ByVal bodega As String, ByVal valor As String,
                                                        ByVal usuario As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@MATERIAL_PROPERTY_ID", SqlDbType.Int)
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Value = idPropiedadMaterial

            cmd.Parameters.Add("@MATERIAL_ID ", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = bodega

            cmd.Parameters.Add("@VALUE", SqlDbType.VarChar, 250)
            cmd.Parameters("@VALUE").Direction = ParameterDirection.Input
            cmd.Parameters("@VALUE").Value = valor

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = usuario

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_MATERIAL_PROPERTY_BY_WAREHOUSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")
            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Eliminar propiedades por bodega")>
    Public Function EliminarPropiedadPorBodegaDeMaterial(ByVal idPropiedadMaterial As Integer, ByVal materialId As String, ByVal bodega As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Operacion")

            cmd.Parameters.Add("@MATERIAL_PROPERTY_ID", SqlDbType.Int)
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_PROPERTY_ID").Value = idPropiedadMaterial

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = bodega

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_DELETE_MATERIAL_PROPERTY_BY_WAREHOUSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int32"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int32"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")
            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene las propiedades de material por bodega, por material seleccionado")>
    Public Function ObtenerPropiedadesDeMaterialPorBodega(ByVal materialId As String, ByVal pEnvironmentName As String) As DataTable

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Resultado")

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_PROPERTY_BY_WAREHOUSE_FOR_MATERIAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt

        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")

            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function

    <WebMethod(Description:="Obtiene las propiedades posibles de material.")>
    Public Function ObtenerPropiedadesDeMateriales(ByVal pEnvironmentName As String) As DataTable
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As DataTable = New DataTable("Resultado")

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_PROPERTIES_OF_MATERIALS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt
        Catch ex As Exception
            Dim dtError As DataTable = New DataTable("Operacion")

            dtError.Columns.Add("Resultado", Type.GetType("System.Int"))
            dtError.Columns.Add("Mensaje", Type.GetType("System.String"))
            dtError.Columns.Add("Codigo", Type.GetType("System.Int"))
            dtError.Columns.Add("DbData", Type.GetType("System.String"))

            dtError.Rows.Add(-1, ex.Message, -1, "")
            Return dtError
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try

    End Function


#End Region
End Class