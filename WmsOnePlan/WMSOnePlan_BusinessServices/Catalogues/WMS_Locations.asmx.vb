Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_Locations
    Inherits System.Web.Services.WebService

#Region "Ubicaciones"
    Private Function CheckZoneRelationship(ByVal pWAREHOUSE_PARENT As String, ByVal pZONA As String, ByVal pEnvironmentName As String) As Boolean
        Dim pResult As String = ""
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_ZONE "
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "WAREHOUSE_CODE = '" + pWAREHOUSE_PARENT.ToUpper + "' AND "
        XSQL = XSQL + "ZONE  = '" + pZONA.ToUpper + "'"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "CheckZoneRelationship")
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return False
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR:No existe ShelfSpots : " + pWAREHOUSE_PARENT
            Return False
        Else
            pResult = "OK"
            Return True
        End If

    End Function

    <WebMethod(Description:="Create Shelf Spot Location")>
    Public Function CreateShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByVal pSPOT_TYPE As String, ByVal pSPOT_ORDERBY As Integer, ByVal pSPOT_AISLE As String, ByVal pSPOT_COLUMN As String, ByVal pSPOT_LEVEL As String, ByVal pALLOW_PICKING As String, ByVal pALLOW_STORAGE As String, ByVal pALLOW_REALLOC As String, ByVal pAVAILABLE As String, ByVal pZONA As String, ByVal pPARTICION As String, ByVal pETIQUETA As String, ByVal pLINE_ID As String, ByVal pMAX_MT2 As Double, ByVal pMAX_WEIGHT As Double, ByRef resultado As String, ByVal ambiente As String, ByVal seccion As String, volume As Double, ByVal allowFastPicking As Integer, ByVal isWaste As Integer) As Boolean
        If CheckZoneRelationship(pWAREHOUSE_PARENT, pZONA, ambiente) Then
            Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
            sqldbConexion.Open()
            Try
                Dim cmd As New SqlCommand

                cmd.Parameters.Add("@WAREHOUSE_PARENT", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@ZONE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_TYPE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_ORDERBY", SqlDbType.Decimal)
                cmd.Parameters.Add("@SPOT_AISLE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_COLUMN", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_LEVEL", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_PARTITION", SqlDbType.Int)
                cmd.Parameters.Add("@SPOT_LABEL", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@ALLOW_PICKING", SqlDbType.Int)
                cmd.Parameters.Add("@ALLOW_STORAGE", SqlDbType.Int)
                cmd.Parameters.Add("@ALLOW_REALLOC", SqlDbType.Int)
                cmd.Parameters.Add("@AVAILABLE", SqlDbType.Int)
                cmd.Parameters.Add("@LINE_ID", SqlDbType.VarChar, 15)
                cmd.Parameters.Add("@SPOT_LINE", SqlDbType.VarChar, 15)
                cmd.Parameters.Add("@MAX_MT2_OCCUPANCY", SqlDbType.Int)
                cmd.Parameters.Add("@MAX_WEIGHT", SqlDbType.Decimal)
                cmd.Parameters.Add("@SECTION", SqlDbType.VarChar, 50)
                cmd.Parameters.Add("@VOLUME", SqlDbType.Decimal)
                cmd.Parameters.Add("@ALLOW_FAST_PICKING", SqlDbType.Int)
                cmd.Parameters.Add("@IS_WASTE", SqlDbType.Int)

                cmd.Parameters("@WAREHOUSE_PARENT").Direction = ParameterDirection.Input
                cmd.Parameters("@ZONE").Direction = ParameterDirection.Input
                cmd.Parameters("@LOCATION_SPOT").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_TYPE").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_ORDERBY").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_AISLE").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_COLUMN").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LEVEL").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_PARTITION").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LABEL").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_PICKING").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_STORAGE").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_REALLOC").Direction = ParameterDirection.Input
                cmd.Parameters("@AVAILABLE").Direction = ParameterDirection.Input
                cmd.Parameters("@LINE_ID").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LINE").Direction = ParameterDirection.Input
                cmd.Parameters("@MAX_MT2_OCCUPANCY").Direction = ParameterDirection.Input
                cmd.Parameters("@MAX_WEIGHT").Direction = ParameterDirection.Input
                cmd.Parameters("@SECTION").Direction = ParameterDirection.Input
                cmd.Parameters("@VOLUME").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_FAST_PICKING").Direction = ParameterDirection.Input
                cmd.Parameters("@IS_WASTE").Direction = ParameterDirection.Input

                cmd.Parameters("@WAREHOUSE_PARENT").Value = pWAREHOUSE_PARENT
                cmd.Parameters("@ZONE").Value = pZONA
                cmd.Parameters("@LOCATION_SPOT").Value = pLOCATION_SPOT
                cmd.Parameters("@SPOT_TYPE").Value = pSPOT_TYPE
                cmd.Parameters("@SPOT_ORDERBY").Value = pSPOT_ORDERBY
                cmd.Parameters("@SPOT_AISLE").Value = pSPOT_AISLE
                cmd.Parameters("@SPOT_COLUMN").Value = pSPOT_COLUMN
                cmd.Parameters("@SPOT_LEVEL").Value = pSPOT_LEVEL
                cmd.Parameters("@SPOT_PARTITION").Value = pPARTICION
                cmd.Parameters("@SPOT_LABEL").Value = pETIQUETA
                cmd.Parameters("@ALLOW_PICKING").Value = pALLOW_PICKING
                cmd.Parameters("@ALLOW_STORAGE").Value = pALLOW_STORAGE
                cmd.Parameters("@ALLOW_REALLOC").Value = pALLOW_REALLOC
                cmd.Parameters("@AVAILABLE").Value = pAVAILABLE
                cmd.Parameters("@LINE_ID").Value = pLINE_ID
                cmd.Parameters("@SPOT_LINE").Value = pLINE_ID
                cmd.Parameters("@MAX_MT2_OCCUPANCY").Value = pMAX_MT2
                cmd.Parameters("@MAX_WEIGHT").Value = pMAX_WEIGHT
                cmd.Parameters("@SECTION").Value = seccion
                cmd.Parameters("@VOLUME").Value = volume
                cmd.Parameters("@ALLOW_FAST_PICKING").Value = allowFastPicking
                cmd.Parameters("@IS_WASTE").Value = isWaste

                cmd.CommandText = DefaultSchema & "[OP_WMS_SP_INSERT_SHELF_SPOT]"
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
        Else
            resultado = "ERROR:Zona no relacionada con Bodega, verifique en parametros generales"
            Return False
        End If
    End Function

    <WebMethod(Description:="Update Shelf spot location")>
    Public Function UpdateShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByVal pSPOT_TYPE As String, ByVal pSPOT_ORDERBY As Integer, ByVal pSPOT_AISLE As String, ByVal pSPOT_COLUMN As String, ByVal pSPOT_LEVEL As String, ByVal pALLOW_PICKING As String, ByVal pALLOW_STORAGE As String, ByVal pALLOW_REALLOC As String, ByVal pAVAILABLE As String, ByVal pZONA As String, ByVal pPARTICION As String, ByVal pETIQUETA As String, ByVal pLINE_ID As String, ByVal pMAX_MT2 As Double, ByVal pMAX_WEIGHT As Double, ByRef resultado As String, ByVal ambiente As String, ByVal seccion As String, volume As Double, ByVal allowFastPicking As Integer, ByVal isWaste As Integer) As Boolean
        If CheckZoneRelationship(pWAREHOUSE_PARENT, pZONA, ambiente) Then
            Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(ambiente).ToString)
            sqldbConexion.Open()
            Try
                Dim cmd As New SqlCommand

                cmd.Parameters.Add("@WAREHOUSE_PARENT", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@ZONE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_TYPE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_ORDERBY", SqlDbType.Decimal)
                cmd.Parameters.Add("@SPOT_AISLE", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_COLUMN", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_LEVEL", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@SPOT_PARTITION", SqlDbType.VarChar)
                cmd.Parameters.Add("@SPOT_LABEL", SqlDbType.VarChar, 25)
                cmd.Parameters.Add("@ALLOW_PICKING", SqlDbType.Int)
                cmd.Parameters.Add("@ALLOW_STORAGE", SqlDbType.Int)
                cmd.Parameters.Add("@ALLOW_REALLOC", SqlDbType.Int)
                cmd.Parameters.Add("@AVAILABLE", SqlDbType.Int)
                cmd.Parameters.Add("@LINE_ID", SqlDbType.VarChar, 15)
                cmd.Parameters.Add("@SPOT_LINE", SqlDbType.VarChar, 15)
                cmd.Parameters.Add("@MAX_MT2_OCCUPANCY", SqlDbType.Int)
                cmd.Parameters.Add("@MAX_WEIGHT", SqlDbType.Decimal)
                cmd.Parameters.Add("@SECTION", SqlDbType.VarChar, 50)
                cmd.Parameters.Add("@VOLUME", SqlDbType.Decimal)
                cmd.Parameters.Add("@ALLOW_FAST_PICKING", SqlDbType.Int)
                cmd.Parameters.Add("@IS_WASTE", SqlDbType.Int)

                cmd.Parameters("@WAREHOUSE_PARENT").Direction = ParameterDirection.Input
                cmd.Parameters("@ZONE").Direction = ParameterDirection.Input
                cmd.Parameters("@LOCATION_SPOT").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_TYPE").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_ORDERBY").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_AISLE").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_COLUMN").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LEVEL").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_PARTITION").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LABEL").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_PICKING").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_STORAGE").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_REALLOC").Direction = ParameterDirection.Input
                cmd.Parameters("@AVAILABLE").Direction = ParameterDirection.Input
                cmd.Parameters("@LINE_ID").Direction = ParameterDirection.Input
                cmd.Parameters("@SPOT_LINE").Direction = ParameterDirection.Input
                cmd.Parameters("@MAX_MT2_OCCUPANCY").Direction = ParameterDirection.Input
                cmd.Parameters("@MAX_WEIGHT").Direction = ParameterDirection.Input
                cmd.Parameters("@SECTION").Direction = ParameterDirection.Input
                cmd.Parameters("@VOLUME").Direction = ParameterDirection.Input
                cmd.Parameters("@ALLOW_FAST_PICKING").Direction = ParameterDirection.Input
                cmd.Parameters("@IS_WASTE").Direction = ParameterDirection.Input

                cmd.Parameters("@WAREHOUSE_PARENT").Value = pWAREHOUSE_PARENT
                cmd.Parameters("@ZONE").Value = pZONA
                cmd.Parameters("@LOCATION_SPOT").Value = pLOCATION_SPOT
                cmd.Parameters("@SPOT_TYPE").Value = pSPOT_TYPE
                cmd.Parameters("@SPOT_ORDERBY").Value = pSPOT_ORDERBY
                cmd.Parameters("@SPOT_AISLE").Value = pSPOT_AISLE
                cmd.Parameters("@SPOT_COLUMN").Value = pSPOT_COLUMN
                cmd.Parameters("@SPOT_LEVEL").Value = pSPOT_LEVEL
                cmd.Parameters("@SPOT_PARTITION").Value = pPARTICION
                cmd.Parameters("@SPOT_LABEL").Value = pETIQUETA
                cmd.Parameters("@ALLOW_PICKING").Value = pALLOW_PICKING
                cmd.Parameters("@ALLOW_STORAGE").Value = pALLOW_STORAGE
                cmd.Parameters("@ALLOW_REALLOC").Value = pALLOW_REALLOC
                cmd.Parameters("@AVAILABLE").Value = pAVAILABLE
                cmd.Parameters("@LINE_ID").Value = pLINE_ID
                cmd.Parameters("@SPOT_LINE").Value = pLINE_ID
                cmd.Parameters("@MAX_MT2_OCCUPANCY").Value = pMAX_MT2
                cmd.Parameters("@MAX_WEIGHT").Value = pMAX_WEIGHT
                cmd.Parameters("@SECTION").Value = seccion
                cmd.Parameters("@VOLUME").Value = volume
                cmd.Parameters("@ALLOW_FAST_PICKING").Value = allowFastPicking
                cmd.Parameters("@IS_WASTE").Value = isWaste

                cmd.CommandText = DefaultSchema & "[OP_WMS_SP_UPDATE_SHELF_SPOT]"
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
        Else
            resultado = "ERROR:Zona no relacionada con Bodega, verifique en catálogo de zona"
            Return False
        End If
    End Function

    <WebMethod(Description:="Delete Shelf Spot Location")>
    Public Function DeleteShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByVal pLINE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "DELETE " & DefaultSchema & "OP_WMS_SHELF_SPOTS"
        XSQL = XSQL + " WHERE "
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

    <WebMethod(Description:="Select Partial")>
    Public Function SearchPartialShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(WAREHOUSE_PARENT) = '" + pWAREHOUSE_PARENT.ToUpper + "' OR "
        XSQL = XSQL + "UPPER(LOCATION_SPOT) = '" + pLOCATION_SPOT.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "WAREHOUSE_PARENT, "
        XSQL = XSQL + "LOCATION_SPOT"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_ShelfSpots")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe ShelfSpots : " + pWAREHOUSE_PARENT
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Select Partial")>
    Public Function EnabledShelfSpots(ByVal pWAREHOUSE_Id As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim strSql As New StringBuilder
        strSql.Append(" SELECT ( SELECT COUNT(*)")
        strSql.Append(String.Format(" FROM {0}OP_WMS_CERTIFICATES c", DefaultSchema))
        strSql.Append(String.Format(" WHERE c.[3PL_WAREHOUSE] = '{0}')", pWAREHOUSE_Id))
        strSql.Append(" + (SELECT COUNT(*) AS Numero")
        strSql.Append(String.Format(" FROM {0}OP_WMS_LOGINS l", DefaultSchema))
        strSql.Append(String.Format(" WHERE l.[3PL_WAREHOUSE] = '{0}')", pWAREHOUSE_Id))

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "EnabledShelfSpots")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        If miscDS.Tables(0).Rows(0)(0) = 0 Then
            pResult = "OK"
            Return True
        Else
            pResult = "ERROR, El almacén no se puede inhabilitar o borrar por que esta enlazado con un registro."
            Return False
        End If
    End Function

    <WebMethod(Description:="Distinct LinePicking")>
    Public Function GetPickingLines(ByVal pWAREHOUSE_PARENT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT 	DISTINCT(SPOT_LINE) AS PICKING_LINE"
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS "
        XSQL = XSQL + " WHERE WAREHOUSE_PARENT='" + pWAREHOUSE_PARENT + "' AND "
        XSQL = XSQL + " SPOT_LINE IS NOT NULL "
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + " SPOT_LINE "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetPickingLines")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen lineas de picking : " + pWAREHOUSE_PARENT
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function


    <WebMethod(Description:="Search specific spot location")>
    Public Function SearchByKeyShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION_SPOT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS"
        XSQL = XSQL & " WHERE "
        XSQL = XSQL & "UPPER(WAREHOUSE_PARENT) = '" & pWAREHOUSE_PARENT.ToUpper & "' AND "
        XSQL = XSQL & "UPPER(LOCATION_SPOT) = '" & pLOCATION_SPOT.ToUpper & "'"
        XSQL = XSQL & " ORDER BY "
        XSQL = XSQL & "WAREHOUSE_PARENT, "
        XSQL = XSQL & "LOCATION_SPOT"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_ShelfSpots")
        Catch ex As Exception
            pResult = "ERROR," & ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe ubicacion : " & pWAREHOUSE_PARENT & " / " & pLOCATION_SPOT
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific spot location")>
    Public Function SearchByHierarchyShelfSpots(ByVal pWAREHOUSE_PARENT As String, ByVal pZONE As String, ByVal pLOCATION_SPOT As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim pWhere As Boolean = False
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT *, CASE	WHEN ISNULL([ALLOW_FAST_PICKING],0) = 1
				THEN 'SI'
				ELSE 'NO'
			END [ALLOW_COLUMN_FAST_PICKING],
                CASE	WHEN ISNULL([IS_WASTE],0) = 1
				THEN 'SI'
				ELSE 'NO'
			END [IS_COLUMN_WASTE]
FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS "
        If pWAREHOUSE_PARENT <> "" Then
            XSQL = XSQL & " WHERE "
            XSQL = XSQL & "UPPER(WAREHOUSE_PARENT) LIKE '%" & pWAREHOUSE_PARENT.ToUpper & "%' " & IIf(pWhere, " OR ", "")
            pWhere = True
        End If
        If pZONE <> "" Then
            If Not pWhere Then
                XSQL = XSQL & " WHERE "
                pWhere = True
            End If
            XSQL = XSQL & IIf(pWhere, " AND ", "") & " UPPER(ZONE) LIKE '%" & pZONE.ToUpper & "%' "
        End If
        If pLOCATION_SPOT <> "" Then
            If Not pWhere Then
                XSQL = XSQL & " WHERE "
            End If

            XSQL = XSQL & IIf(pWhere, " AND ", "") & "UPPER(LOCATION_SPOT) LIKE '%" & pLOCATION_SPOT.ToUpper & "%' "
        End If
        XSQL = XSQL & " ORDER BY "
        XSQL = XSQL & "WAREHOUSE_PARENT, "
        XSQL = XSQL & "ZONE, "
        XSQL = XSQL & "LOCATION_SPOT"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_ShelfSpots")
        Catch ex As Exception
            pResult = "ERROR," & ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe ShelfSpots : " & pWAREHOUSE_PARENT
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific spot location")>
    Public Function SelectWarehousesGroup(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT WAREHOUSE_ID, NAME FROM " & DefaultSchema & "OP_WMS_WAREHOUSES"
        XSQL = XSQL + " GROUP BY "
        XSQL = XSQL + "WAREHOUSE_ID, NAME "


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectWarehousesGroup")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen bodegas "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search enabled spot location")>
    Public Function SelectWarehousesEnabled(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim strSql As New StringBuilder
        strSql.Append(" SELECT WAREHOUSE_ID, ")
        strSql.Append(" NAME")
        strSql.Append(String.Format(" FROM {0}OP_WMS_WAREHOUSES", DefaultSchema))
        strSql.Append(" WHERE IS_3PL_WAREHUESE = 1")
        strSql.Append(" GROUP BY WAREHOUSE_ID, NAME")

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(strSql.ToString, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectWarehousesGroup")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen bodegas "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific spot location")>
    Public Function SelectZonesGroup(ByVal pWarehouseParent As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT ZONE_ID,ZONE,DESCRIPTION,WAREHOUSE_CODE,RECEIVE_EXPLODED_MATERIALS,LINE_ID FROM " & DefaultSchema & "OP_WMS_ZONE "
        XSQL = XSQL + " WHERE WAREHOUSE_CODE = '" + pWarehouseParent + "' "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectZonesGroup")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen ZONAS PARA ESA BODEGA "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific spot location")>
    Public Function GetRelatedProd_ByLoc(ByVal pWarehouseParent As String, ByVal pLocation As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT "
        XSQL = XSQL + "A.MATERIAL_ID,   "
        XSQL = XSQL + "B.MATERIAL_NAME, "
        XSQL = XSQL + "A.MAX_QUANTITY,  "
        XSQL = XSQL + "A.MIN_QUANTITY   "
        XSQL = XSQL + "FROM " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS A, "
        XSQL = XSQL + "" & DefaultSchema & "OP_WMS_MATERIALS B "
        XSQL = XSQL + "WHERE A.WAREHOUSE_PARENT = '" + pWarehouseParent + "' AND "
        XSQL = XSQL + "A.LOCATION_SPOT = '" + pLocation + "' AND "
        XSQL = XSQL + "B.MATERIAL_ID = A.MATERIAL_ID "
        XSQL = XSQL + "ORDER BY "
        XSQL = XSQL + "A.MATERIAL_ID "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetRelatedProd_ByLoc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe producto asociado a esta ubicacion: " + pLocation
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '02-Ago-10 J.R. para buscar las ubicaciones donde esta relacionado cierto prod.
    <WebMethod(Description:="Search specific spot location")>
    Public Function GetRelatedProd_ByWarehouse(ByVal pWarehouseParent As String, ByVal pMaterialID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT "
        XSQL = XSQL + "A.LOCATION_SPOT,   "
        XSQL = XSQL + "A.MATERIAL_ID,   "
        XSQL = XSQL + "B.MATERIAL_NAME, "
        XSQL = XSQL + "A.MAX_QUANTITY,  "
        XSQL = XSQL + "A.MIN_QUANTITY   "
        XSQL = XSQL + "FROM " & DefaultSchema & "OP_WMS_MATERIALS_JOIN_SPOTS A, "
        XSQL = XSQL + "" & DefaultSchema & "OP_WMS_MATERIALS B "
        XSQL = XSQL + "WHERE A.WAREHOUSE_PARENT = '" + pWarehouseParent + "' AND "
        XSQL = XSQL + "A.MATERIAL_ID = '" + pMaterialID + "' AND "
        XSQL = XSQL + "B.MATERIAL_ID = A.MATERIAL_ID "
        XSQL = XSQL + "ORDER BY "
        XSQL = XSQL + "A.MATERIAL_ID "

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetRelatedProd_ByWarehouse")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Este producto no esta asociado a ninguna ubicacion en bodega " + pWarehouseParent
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific spot location")>
    Public Function SelectERPWarehouses(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT PARAM_NAME, PARAM_CAPTION FROM " & DefaultSchema & "OP_WMS_CONFIGURATIONS "
        XSQL = XSQL + " WHERE PARAM_TYPE = 'SISTEMA' AND PARAM_GROUP = 'SAP' AND PARAM_GROUP_CAPTION = 'BODEGAS' "
        XSQL = XSQL + " ORDER BY NUMERIC_VALUE"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectERPWarehouses")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen BODEGAS ERP "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Search specific Clima location")>
    Public Function SelectClimaWarehouses(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_FUNC_GET_WAREHOUSE_WEATHER() "
        XSQL = XSQL + " ORDER BY NUMERIC_VALUE "


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SelectClimaWarehouses")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen climas "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
    <WebMethod(Description:="Create Login x Location by Partial")>
    Public Function CreateLoginXLoc(ByVal pLOGIN_ID As String, ByVal pLOGIN_NAME As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLINE_ID As String, ByVal pLOCATION_SPOT As String, ByVal pTASK_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "INSERT INTO " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS("
            XSQL = XSQL + "LOGIN_ID,"
            XSQL = XSQL + "LOGIN_NAME,"
            XSQL = XSQL + "WAREHOUSE_PARENT,"
            XSQL = XSQL + "LINE_ID,"
            XSQL = XSQL + "LOCATION_SPOT,"
            XSQL = XSQL + "TASK_TYPE)"
            XSQL = XSQL + "VALUES ("
            XSQL = XSQL + "'" + pLOGIN_ID + "',"
            XSQL = XSQL + "'" + pLOGIN_NAME + "',"
            XSQL = XSQL + "'" + pWAREHOUSE_PARENT + "',"
            XSQL = XSQL + "'" + pLINE_ID + "',"
            XSQL = XSQL + "'" + pLOCATION_SPOT + "',"
            XSQL = XSQL + "'" + pTASK_TYPE + "')"
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

    '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
    <WebMethod(Description:="Update Login x Location by Partial")>
    Public Function UpdateLoginXLoc(ByVal pLOGIN_ID As String, ByVal pLAST_LOGIN_ID As String, ByVal pLOGIN_NAME As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLINE_ID As String, ByVal pLOCATION_SPOT As String, ByVal pTASK_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        Try
            XSQL = "UPDATE " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS SET "
            XSQL = XSQL + " LOGIN_ID = '" + pLOGIN_ID + "',"
            XSQL = XSQL + " LOGIN_NAME = '" + pLOGIN_NAME + "',"
            XSQL = XSQL + " WAREHOUSE_PARENT = '" + pWAREHOUSE_PARENT + "',"
            XSQL = XSQL + " LINE_ID = '" + pLINE_ID + "',"
            XSQL = XSQL + " LOCATION_SPOT = '" + pLOCATION_SPOT + "',"
            XSQL = XSQL + " TASK_TYPE = '" + pTASK_TYPE + "' "
            XSQL = XSQL + " WHERE "
            XSQL = XSQL + " LOGIN_ID = '" + pLAST_LOGIN_ID + "' AND "
            XSQL = XSQL + " WAREHOUSE_PARENT = '" + pWAREHOUSE_PARENT + "' AND "
            XSQL = XSQL + " LINE_ID = '" + pLINE_ID + "' AND "
            XSQL = XSQL + " LOCATION_SPOT = '" + pLOCATION_SPOT + "' AND "
            XSQL = XSQL + " TASK_TYPE = '" + pTASK_TYPE + "'"
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

    '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
    <WebMethod(Description:="Delete Login x Location")>
    Public Function DeleteLoginXLoc(ByVal pLOGIN_ID As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLINE_ID As String, ByVal pLOCATION_SPOT As String, ByVal pTASK_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "DELETE " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " WAREHOUSE_PARENT = '" + pWAREHOUSE_PARENT + "' AND "
        XSQL = XSQL + " LINE_ID = '" + pLINE_ID + "' AND "
        XSQL = XSQL + " LOCATION_SPOT = '" + pLOCATION_SPOT + "' AND "
        XSQL = XSQL + " TASK_TYPE = '" + pTASK_TYPE + "'"
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

    '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
    <WebMethod(Description:="Get Login x Location by Key")>
    Public Function SearchByKeyLoginXLoc(ByVal pLOGIN_ID As String, ByVal pWAREHOUSE_PARENT As String, ByVal pLINE_ID As String, ByVal pLOCATION_SPOT As String, ByVal pTASK_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(LOGIN_ID) = '" + pLOGIN_ID.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(WAREHOUSE_PARENT) = '" + pWAREHOUSE_PARENT.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(LINE_ID) = '" + pLINE_ID.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(LOCATION_SPOT) = '" + pLOCATION_SPOT.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(TASK_TYPE) = '" + pTASK_TYPE.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "LOGIN_ID, "
        XSQL = XSQL + "WAREHOUSE_PARENT, "
        XSQL = XSQL + "LOCATION_SPOT"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_LoginXLoc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe LoginXLoc : " + pLOGIN_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '21-Jul-10 J.R. se agrego tipo tarea para saber si son usuarios de Picking o de Replenishmet
    <WebMethod(Description:="Get Login x Location by Partial")>
    Public Function SearchPartialLoginXLoc(ByVal pWAREHOUSE_PARENT As String, ByVal pLOCATION As String, ByVal pTASK_TYPE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(WAREHOUSE_PARENT) = '" + pWAREHOUSE_PARENT.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(LOCATION_SPOT) = '" + pLOCATION.ToUpper + "' AND "
        XSQL = XSQL + "UPPER(TASK_TYPE) = '" + pTASK_TYPE.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "WAREHOUSE_PARENT"
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchPartial_LoginXLoc")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe LoginXLoc : " + pWAREHOUSE_PARENT
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '6-Sep-11 FRM Agregar consulta de modulo asignado x operador
    <WebMethod(Description:="Get Modules related with operator")>
    Public Function GetAvailable_Operators(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT LOGIN_ID, LOGIN_NAME "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_LOGINS "
        XSQL = XSQL + " WHERE (ROLE_ID IN('OPERADOR','OPERADOR_S1') AND (LOGIN_STATUS = 'ACTIVO') "
        XSQL = XSQL + " AND LOGIN_ID NOT IN "
        XSQL = XSQL + " (SELECT LOGIN_ID FROM " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS) "
        XSQL = XSQL + " ORDER BY LOGIN_NAME "


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAvailable_Operators")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    '6-Sep-11 FRM Agregar consulta de modulo asignado x operador
    <WebMethod(Description:="Get Modules related with operator")>
    Public Function GetModules_X_Operator(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT LOGIN_ID, LOGIN_NAME, LOCATION_SPOT, LINE_ID "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS "
        XSQL = XSQL + " ORDER BY LOCATION_SPOT"


        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetModules_X_Operator")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get all zones")>
    Public Function GetWmsZones(ByRef pResult As String, ByVal pEnvironmentName As String, ByVal warehouse As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT ZONE_ID,ZONE,DESCRIPTION,WAREHOUSE_CODE,RECEIVE_EXPLODED_MATERIALS,LINE_ID FROM " & DefaultSchema & "OP_WMS_ZONE "
        If Not String.IsNullOrEmpty(warehouse) Then
            XSQL = XSQL & "WHERE WAREHOUSE_CODE = '" & warehouse & "';"
        End If

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetWmsZones")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen ZONAS PARA ESA BODEGA "
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    '6-Sep-11 FRM Agregar consulta de modulo asignado x operador
    <WebMethod(Description:="Get Modules related with operator")>
    Public Function GetAvailable_Locations(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT DISTINCT SUBSTRING(LOCATION_SPOT, 1, 5) AS LOCATION_SPOT, LINE_ID "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS "
        XSQL = XSQL + " WHERE (SUBSTRING(LOCATION_SPOT, 1, 5) NOT IN "
        XSQL = XSQL + " (SELECT LOCATION_SPOT FROM " & DefaultSchema & "OP_WMS_LOGIN_JOIN_LOCATIONS)) "
        XSQL = XSQL + " GROUP BY SUBSTRING(LOCATION_SPOT, 1, 5), LINE_ID "
        XSQL = XSQL + " ORDER BY LOCATION_SPOT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAvailable_Locations")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get all locations by warehouse")>
    Public Function GetLocationsByWH(ByRef pWh As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT WAREHOUSE_PARENT ,LOCATION_SPOT "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_SHELF_SPOTS "
        XSQL = XSQL + " WHERE WAREHOUSE_PARENT = '" + pWh + "'"
        'XSQL = XSQL + " ORDER BY LOCATION_SPOT"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAvailable_Locations")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

    <WebMethod(Description:="TraePolizasDeSeguro")>
    Public Function GetPolizaInsurance(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT POLIZA_INSURANCE ,CLIENT_NAME "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_VIEW_INSURANCE_DOC "
        XSQL = XSQL + " ORDER BY CLIENT_NAME"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        miscDA.SelectCommand.CommandTimeout = 360
        Try
            miscDA.Fill(miscDS, "GetAvailable_Insurances")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="TraeLosTerminosComerciales")>
    Public Function GetTermsOfTrade(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT ACUERDO_COMERCIAL, DESCRIPCION "
        XSQL = XSQL + " FROM " & DefaultSchema & "OP_WMS_TERMS_OF_TRADE "
        XSQL = XSQL + " ORDER BY ACUERDO_COMERCIAL"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetAvailable_Terms")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existen registros"
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

            cmd.Parameters.Add("@CLIENT_OWNER", SqlDbType.VarChar,25)
            cmd.Parameters("@CLIENT_OWNER").Direction = ParameterDirection.Input
            cmd.Parameters("@CLIENT_OWNER").Value = clientOwner
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar,50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATED_IF_MATERIAL_EXISTS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion
            cmd.ExecuteNonQuery()

            dt.Load(reader)

            result = "OK"

            If dt.Rows(0).Item(0) = 0 then
                Return False
            end If

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

    <WebMethod(Description:="Valida si la ubicación existe en la bodega.")>
    Public Function ValidarUbicacionExisteEnBodega(ambiente As String, codigoBodega As String, codigoUbicacion As String) As Boolean
        Dim tablas = New DataSet()
        Dim sqldbConexion = New SqlConnection(AppSettings(ambiente).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            If (String.IsNullOrEmpty(codigoBodega)) Then
                cmd.Parameters.Add("@WAREHOUSE_PARENT", SqlDbType.VarChar, 25)
                cmd.Parameters("@WAREHOUSE_PARENT").Direction = ParameterDirection.Input
                cmd.Parameters("@WAREHOUSE_PARENT").Value = codigoBodega
            End If

            cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar, 25)
            cmd.Parameters("@LOCATION_SPOT").Direction = ParameterDirection.Input
            cmd.Parameters("@LOCATION_SPOT").Value = codigoUbicacion

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATED_IF_JOIN_SPOT_EXISTS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tablas)
            If tablas.Tables(0).Rows(0).Item(0) = 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function


#End Region

#Region "Bodegas"

    <WebMethod(Description:="Eleminar una bodega")>
    Public Function DeleteWarehouse(ByVal pWAREHOUSE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "DELETE " & DefaultSchema & "OP_WMS_WAREHOUSES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "WAREHOUSE_ID = '" + pWAREHOUSE_ID + "'"

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



    <WebMethod(Description:="Actualiza una bodega existente")>
    Public Function UpdateWarehouse( pWarehouseId As String,  pName As String,  pComments As String,  pErpWarehouse As String,
                                     pShuntName As String,  pWareHouseWeather As String,  pWareHouseStatus As Integer, pIs3PlWareHouse As Integer,  
                                     pWareHouseAddress As String,  pGpsUrl As String,  pDistributionCenterId As String, pPickingType as String,
                                     ByRef pResult As String,  pEnvironmentName As String) As Boolean

        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_ID", SqlDbType.VarChar, 25)).Value = pWarehouseId
            cmd.Parameters.Add(New SqlParameter("@NAME", SqlDbType.VarChar, 50)).Value = pName
            cmd.Parameters.Add(New SqlParameter("@COMMENTS", SqlDbType.VarChar, 150)).Value = pComments
            cmd.Parameters.Add(New SqlParameter("@ERP_WAREHOUSE", SqlDbType.VarChar, 50)).Value = pErpWarehouse
            cmd.Parameters.Add(New SqlParameter("@SHUNT_NAME", SqlDbType.VarChar, 25)).Value = pShuntName
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_WEATHER", SqlDbType.VarChar, 50)).Value = pWareHouseWeather
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_STATUS", SqlDbType.Int)).Value = pWareHouseStatus
            cmd.Parameters.Add(New SqlParameter("@IS_3PL_WAREHOUSE", SqlDbType.Int)).Value = pIs3PlWareHouse
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_ADDRESS", SqlDbType.VarChar, 250)).Value = pWareHouseAddress
            cmd.Parameters.Add(New SqlParameter("@GPS_URL", SqlDbType.VarChar, 100)).Value = pGpsUrl
            cmd.Parameters.Add(New SqlParameter("@DISTRIBUTION_CENTER_ID", SqlDbType.VarChar, 50)).Value = pDistributionCenterId
            cmd.Parameters.Add(New SqlParameter("@PICKING_TYPE", SqlDbType.VarChar, 50)).Value = pPickingType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_WAREHOUSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return False
            End If
            pResult = dt.Rows(0)("DbData").ToString()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function
    
    <WebMethod(Description:="Crea una nueva bodega")>
    Public Function CreateWarehouse( pWarehouseId As String,  pName As String,  pComments As String,  pErpWarehouse As String,
                                     pShuntName As String,  pWareHouseWeather As String,  pWareHouseStatus As Integer, pIs3PlWareHouse As Integer,  
                                     pWareHouseAddress As String,  pGpsUrl As String,  pDistributionCenterId As String, pPickingType as String,
                                     ByRef pResult As String,  pEnvironmentName As String) As Boolean

        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_ID", SqlDbType.VarChar, 25)).Value = pWarehouseId
            cmd.Parameters.Add(New SqlParameter("@NAME", SqlDbType.VarChar, 50)).Value = pName
            cmd.Parameters.Add(New SqlParameter("@COMMENTS", SqlDbType.VarChar, 150)).Value = pComments
            cmd.Parameters.Add(New SqlParameter("@ERP_WAREHOUSE", SqlDbType.VarChar, 50)).Value = pErpWarehouse
            cmd.Parameters.Add(New SqlParameter("@SHUNT_NAME", SqlDbType.VarChar, 25)).Value = pShuntName
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_WEATHER", SqlDbType.VarChar, 50)).Value = pWareHouseWeather
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_STATUS", SqlDbType.Int)).Value = pWareHouseStatus
            cmd.Parameters.Add(New SqlParameter("@IS_3PL_WAREHOUSE", SqlDbType.Int)).Value = pIs3PlWareHouse
            cmd.Parameters.Add(New SqlParameter("@WAREHOUSE_ADDRESS", SqlDbType.VarChar, 250)).Value = pWareHouseAddress
            cmd.Parameters.Add(New SqlParameter("@GPS_URL", SqlDbType.VarChar, 100)).Value = pGpsUrl
            cmd.Parameters.Add(New SqlParameter("@DISTRIBUTION_CENTER_ID", SqlDbType.VarChar, 50)).Value = pDistributionCenterId
            cmd.Parameters.Add(New SqlParameter("@PICKING_TYPE", SqlDbType.VarChar, 50)).Value = pPickingType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_CREATE_WAREHOUSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return False
            End If
            pResult = dt.Rows(0)("DbData").ToString()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Selecciona una bodega por su codigo")>
    Public Function SearchByKeyWarehouse(ByVal pWAREHOUSE_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_WAREHOUSES"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "UPPER(WAREHOUSE_ID) = '" + pWAREHOUSE_ID.ToUpper + "'"
        XSQL = XSQL + " ORDER BY "
        XSQL = XSQL + "WAREHOUSE_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "SearchByKey_Warehouse")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Warehouse : " + pWAREHOUSE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Obtiene las boldegas habilitadas")>
    Public Function GetWareHouseEnabled(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim XSQL As String = ""
        XSQL = "SELECT * FROM " & DefaultSchema & "OP_WMS_WAREHOUSES"
        XSQL = XSQL + " WHERE IS_3PL_WAREHUESE = 1"
        XSQL = XSQL + " ORDER BY WAREHOUSE_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetWareHouseEnabled")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No se encontraron bodegas habilitadas."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function

#End Region

#Region "Centros De Distribucion"
    <WebMethod(Description:="TraeLosCentrosDeDistribucion")>
    Public Function GetDistributionCenters(ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataSet = New DataSet()
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_DISTRIBUTION_CENTER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        Return miscDs
    End Function

#End Region

#Region "Asociación Bodegas a usuarios"
    <WebMethod(Description:="BodegasAsociadasAUsuario")>
    Public Function GetAssociatedWarehouseWithUser(ByVal LOGIN_ID As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataSet = New DataSet()
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)

            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = LOGIN_ID

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_WAREHOUSE_ASSOCIATED_WITH_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
            pResult = "OK"
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        Return miscDs
    End Function

    <WebMethod(Description:="ObtenerBodegasAsociadasACentroDistribucion")>
    Public Function GetWarehouseByDistributionCenter(ByVal LOGIN_ID As String, ByVal DISTRIBUTION_CENTER As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataSet
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataSet = New DataSet()
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            cmd.Parameters.Add("@DISTRIBUTION_CENTER", SqlDbType.VarChar, 50)
            cmd.Parameters("@DISTRIBUTION_CENTER").Direction = ParameterDirection.Input
            cmd.Parameters("@DISTRIBUTION_CENTER").Value = DISTRIBUTION_CENTER

            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = LOGIN_ID

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_WAREHOUSE_BY_DISTRIBUTION_CENTER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        Return miscDs
    End Function

    <WebMethod(Description:="DesAsociarBodegaAUsuario")>
    Public Function DisassociateWarehouseOfUser(ByVal WAREHOUSE_BY_USER_ID As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()
            cmd.Parameters.Add("@WAREHOUSE_BY_USER_ID", SqlDbType.Int)
            cmd.Parameters("@WAREHOUSE_BY_USER_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE_BY_USER_ID").Value = WAREHOUSE_BY_USER_ID

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_DISASSOCIATE_WAREHOUSE_OF_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        sqldbConexion.Close()
        pResult = "OK"
        Return True
    End Function

    <WebMethod(Description:="AsociarBodegaAUsuario")>
    Public Function AssociateWarehouseOfUser(ByVal LOGIN_ID As String, ByVal WAREHOUSE As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()
            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = LOGIN_ID


            cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar, 50)
            cmd.Parameters("@WAREHOUSE").Direction = ParameterDirection.Input
            cmd.Parameters("@WAREHOUSE").Value = WAREHOUSE

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ASSOCIATE_WAREHOUSE_WITH_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        sqldbConexion.Close()
        pResult = "OK"
        Return True
    End Function

    <WebMethod(Description:="AssociateDistributionCenterWithUser")>
    Public Function AssociateDistributionCenterWithUser(ByVal LOGIN_ID As String, ByVal DISTRIBUTION_CENTER As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim cmd As New SqlCommand
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()
            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN_ID").Value = LOGIN_ID

            cmd.Parameters.Add("@DISTRIBUTION_CENTER", SqlDbType.VarChar, 50)
            cmd.Parameters("@DISTRIBUTION_CENTER").Direction = ParameterDirection.Input
            cmd.Parameters("@DISTRIBUTION_CENTER").Value = DISTRIBUTION_CENTER

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ASSOCIATE_DISTRIBUTION_CENTER_WITH_USER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return False
        End Try
        sqldbConexion.Close()
        pResult = "OK"
        Return True
    End Function


    <WebMethod(Description:="AssociateDistributionCenterWithUser")>
    Public Function GetAvailableWarehouseByUser(ByVal LOGIN_ID As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection
        Dim miscDs As DataSet = New DataSet()
        Dim cmd As New SqlCommand
        pResult = "OK"
        Try
            sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            sqldbConexion.Open()
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = LOGIN_ID

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_WAREHOUSE_BY_USER_CD]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            miscDa.Fill(miscDs)
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        sqldbConexion.Close()
        If miscDs.Tables.Count > 0 AndAlso miscDs.Tables(0).Rows.Count > 0 Then
            Return miscDs.Tables(0)
        Else
            pResult = "ERROR, No se encontró información de bodegas"
            Return Nothing
        End If

    End Function
#End Region


End Class