Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports WMSOnePlan_BusinessServices.ModuleServices

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WMS_InfoInventory
    Inherits System.Web.Services.WebService
    <WebMethod(Description:="GetInvByLocation JSON Format")>
    Public Function GetInventory_ByLicense_JSON(ByVal pLICENSE_ID As String, ByVal pEnvironmentName As String) As String
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Dim pResult As String = ""
        Dim XSQL As String = ""
        XSQL = "select lic.REGIMEN, li.LICENSE_ID,lic.CLIENT_OWNER,cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE,"
        XSQL = XSQL & " lic.CURRENT_LOCATION,lic.LAST_UPDATED_BY,lic.LAST_LOCATION,li.MATERIAL_NAME,pl.FECHA_LLEGADA,pl.NUMERO_DUA,"
        XSQL = XSQL & " sum(li.QTY) QTY "
        XSQL = XSQL & " from  " & DefaultSchema & "OP_WMS_INV_X_LICENSE li "
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_LICENSES lic on li.LICENSE_ID = lic.LICENSE_ID"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_VIEW_CLIENTS  cl on lic.CLIENT_OWNER = cl.CLIENT_CODE COLLATE DATABASE_DEFAULT"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_POLIZA_HEADER pl on lic.CODIGO_POLIZA = pl.CODIGO_POLIZA where li.LICENSE_ID = " & pLICENSE_ID.ToString
        XSQL = XSQL & " group by lic.REGIMEN, li.LICENSE_ID,lic.CLIENT_OWNER, cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE, "
        XSQL = XSQL & " lic.CURRENT_LOCATION, lic.LAST_UPDATED_BY, lic.LAST_LOCATION, li.MATERIAL_NAME, pl.FECHA_LLEGADA, pl.NUMERO_DUA"
        XSQL = XSQL & " having SUM(li.QTY) <> 0 order by FECHA_LLEGADA desc"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByLicense_JSON")
        Catch ex As Exception
            Return "ERROR," + ex.Message
            Return Nothing
        End Try

        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existe inventario para licencia : " & pLICENSE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return GetJson(miscDS.Tables(0))
        End If


    End Function
    <WebMethod(Description:="Get Inventory by differents views")>
    Public Function GetInventory_View(ByVal Login As String, ByVal pViewName As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR, VIEW: " + pViewName + " : " + ex.Message
            Return Nothing
        End Try

        Dim command = New SqlCommand

        command.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = Login
        command.Parameters.Add(New SqlParameter("@VIEW", SqlDbType.VarChar, 25)).Value = pViewName
        command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INVENTORY_VIEWS]"
        command.CommandType = CommandType.StoredProcedure
        command.Connection = sqldb_conexion

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(command)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_View")
        Catch ex As Exception
            'LogSQLErrors("GetInventory_View_" + pViewName, XSQL, "")
            pResult = "ERROR, VIEW: " + pViewName + " : " + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay inventario para : " + pViewName
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by differents views")>
    Public Function GetInventory_ByClient(ByVal pClientCode As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection

        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR, " + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_INVENTORY_X_CLIENT('" + pClientCode + "') ORDER BY material_name"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByClient")
        Catch ex As Exception
            'LogSQLErrors("GetInventory_View_" + pViewName, XSQL, "")
            pResult = "ERROR, GetInventory_ByClient: " + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No hay inventario para cliente : " + pClientCode
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="GetInventory_ByLicense")>
    Public Function GetInventory_ByLicense(ByVal pLICENSE_ID As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "select lic.REGIMEN, li.LICENSE_ID,lic.CLIENT_OWNER,cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE,"
        XSQL = XSQL & " lic.CURRENT_LOCATION,lic.LAST_UPDATED_BY,lic.LAST_LOCATION,li.MATERIAL_NAME, FORMAT (pl.FECHA_LLEGADA,'dd/MM/YYYY') FECHA_LLEGADA,pl.NUMERO_DUA,"
        XSQL = XSQL & " sum(li.QTY) QTY "
        XSQL = XSQL & " from  " & DefaultSchema & "OP_WMS_INV_X_LICENSE li "
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_LICENSES lic on li.LICENSE_ID = lic.LICENSE_ID"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_VIEW_CLIENTS  cl on lic.CLIENT_OWNER = cl.CLIENT_CODE COLLATE DATABASE_DEFAULT"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_POLIZA_HEADER pl on lic.CODIGO_POLIZA = pl.CODIGO_POLIZA where li.LICENSE_ID = " & pLICENSE_ID.ToString
        XSQL = XSQL & " group by lic.REGIMEN, li.LICENSE_ID,lic.CLIENT_OWNER, cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE, "
        XSQL = XSQL & " lic.CURRENT_LOCATION, lic.LAST_UPDATED_BY, lic.LAST_LOCATION, li.MATERIAL_NAME, pl.FECHA_LLEGADA, pl.NUMERO_DUA"
        XSQL = XSQL & " having SUM(li.QTY) <> 0 order by FECHA_LLEGADA desc"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByLicense")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, No existe inventario para licencia : " & pLICENSE_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function GetInventory_ByWarehouse(Login As String, ByVal pWAREHOUSE As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim miscDS As DataSet = New DataSet()

        Try
            Dim sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
            Dim Dt As New DataTable("Inventario")
            Dim command = New SqlCommand

            command.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = Login
            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INVENTORY_ONLINE]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldb_conexion

            Dim miscDA = New SqlDataAdapter(command)

            miscDA.Fill(miscDS, "Inventario")
            sqldb_conexion.Close()

        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe inventario : " + pWAREHOUSE
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function GetInventory_ByWarehouseAndLocation(ByVal pWAREHOUSE As String, ByVal pSPOT_LOCATION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "select li.LICENSE_ID,lic.CLIENT_OWNER,cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE,"
        XSQL = XSQL & "lic.CURRENT_LOCATION,w.NAME,lic.LAST_UPDATED_BY,lic.LAST_LOCATION,li.MATERIAL_NAME, FORMAT (pl.FECHA_LLEGADA,dd/MM/yyyy) FECHA_LLEGADA ,pl.NUMERO_DUA,"
        XSQL = XSQL & "pl.NUMERO_ORDEN,pl.CODIGO_POLIZA,sum(li.QTY) QTY "
        XSQL = XSQL & "from  " & DefaultSchema & "OP_WMS_INV_X_LICENSE li"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_LICENSES lic on li.LICENSE_ID = lic.LICENSE_ID"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_VIEW_CLIENTS cl on lic.CLIENT_OWNER = cl.CLIENT_CODE COLLATE DATABASE_DEFAULT"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_WAREHOUSES w on lic.CURRENT_WAREHOUSE = w.WAREHOUSE_ID"
        XSQL = XSQL & " inner join  " & DefaultSchema & "OP_WMS_POLIZA_HEADER pl on lic.CODIGO_POLIZA = pl.CODIGO_POLIZA "
        If pWAREHOUSE.Length > 0 And pSPOT_LOCATION.Length > 0 Then
            XSQL = XSQL & "where w.WAREHOUSE_ID ='" & pWAREHOUSE & "' AND lic.CURRENT_LOCATION = '" & pSPOT_LOCATION.ToString & "'"
        End If
        XSQL = XSQL & " group by li.LICENSE_ID,lic.CLIENT_OWNER,cl.CLIENT_NAME,lic.CODIGO_POLIZA,li.BARCODE_ID,li.TERMS_OF_TRADE,"
        XSQL = XSQL & "lic.CURRENT_LOCATION, w.NAME, lic.LAST_UPDATED_BY, lic.LAST_LOCATION, li.MATERIAL_NAME, pl.FECHA_LLEGADA, pl.NUMERO_DUA,pl.NUMERO_ORDEN,pl.CODIGO_POLIZA"
        XSQL = XSQL & " having SUM(li.QTY) <> 0 order by FECHA_LLEGADA desc"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByWarehouseAndLocation")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe Ubicacion : " + pWAREHOUSE + " / " + pSPOT_LOCATION
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function GetInventory_GroupByMaterial(ByVal Login As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim command = New SqlCommand
        command.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = Login
        command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_CONSOLIDATE_INVENTORY]"
        command.CommandType = CommandType.StoredProcedure
        command.Connection = sqldb_conexion

        Dim miscDA = New SqlDataAdapter(command)
        Dim miscDS = New DataSet()
        sqldb_conexion.Close()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByWarehouseGroupBySKU")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe inventario"
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function
    <WebMethod(Description:="Get Inventory by Warehouse")>
    Public Function GetInventory_GroupByWarehouseMaterial(ByVal pMATERIAL_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT WAREHOUSE_ID, MATERIAL_ID, MATERIAL_DESCRIPTION, SUM(QUANTITY_UNITS) AS QUANTITY_UNITS FROM OP_WMS_INVENTORY"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + "MATERIAL_ID = '" + pMATERIAL_ID.ToUpper.Trim + "' "
        XSQL = XSQL + " GROUP BY WAREHOUSE_ID, MATERIAL_ID, MATERIAL_DESCRIPTION"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_GroupByWarehouseMaterial")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe inventario : " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by SKU")>
    Public Function GetInventory_ByMaterial(ByVal pMATERIAL_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Dim XSQL As String = ""
        XSQL = "SELECT * FROM  " + DefaultSchema + "OP_WMS_FUNC_GET_INVENTORY_DETAIL('" + pMATERIAL_ID.ToUpper.Trim + "') ORDER BY CURRENT_LOCATION"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetInventory_ByMaterial")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR,No existe inventario : " + pMATERIAL_ID
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If

    End Function

    <WebMethod(Description:="Get Inventory by Poliza")>
    Public Function GET_INV_X_POLIZA(ByVal pPOLIZA As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try

        Dim XSQL As String = ""
        XSQL = "SELECT A.*, B.*, (A.MATERIAL_ID+ ' '+A.MATERIAL_NAME) AS MATERIAL_NAME_EXTENDED "
        XSQL = XSQL + " ,CASE M.[IS_MASTER_PACK] WHEN 1 THEN 'Master Pack' ELSE '' END AS IS_MASTER_PACK "
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_INV_X_LICENSE A "
        XSQL = XSQL + " INNER JOIN " + DefaultSchema + "OP_WMS_LICENSES B ON (B.LICENSE_ID = A.LICENSE_ID)"
        XSQL = XSQL + " INNER JOIN " + DefaultSchema + "OP_WMS_MATERIALS M ON ([M].[MATERIAL_ID] = A.[MATERIAL_ID])"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " B.CODIGO_POLIZA = '" + pPOLIZA + "' AND A.QTY > 0"
        XSQL = XSQL + " ORDER BY isnull(a.DATE_EXPIRATION, cast('2099/01/01' as datetime)) ASC, A.LICENSE_ID, A.MATERIAL_ID"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GET_INV_X_POLIZA")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try



        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Poliza " & pPOLIZA & " no tiene inventario"
            Return Nothing
        Else

            XSQL = "SELECT [SN].[CORRELATIVE], [SN].[LICENSE_ID], [SN].[MATERIAL_ID], [SN].[SERIAL], [SN].[BATCH], [SN].[DATE_EXPIRATION] "
            XSQL = XSQL + " FROM " + DefaultSchema + "[OP_WMS_MATERIAL_X_SERIAL_NUMBER] [SN] "
            XSQL = XSQL + " INNER JOIN " + DefaultSchema + "[OP_WMS_LICENSES] [L] ON [SN].[LICENSE_ID] = [L].[LICENSE_ID] "
            XSQL = XSQL + " WHERE [L].[CODIGO_POLIZA] = '" + pPOLIZA + "'"

            miscDA = New SqlDataAdapter(XSQL, sqldb_conexion)

            Try
                miscDA.Fill(miscDS, "GET_SERIAL_NUMBER_X_MATERIAL")
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try


            If miscDS.Tables(1).Rows.Count <= 0 Then
                pResult = "ADVERTENCIA, Poliza " & pPOLIZA & " no tiene series"
                pResult = "OK"
                Return miscDS
            Else

                Dim parentColumns = New DataColumn() {miscDS.Tables("GET_INV_X_POLIZA").Columns("LICENSE_ID"), miscDS.Tables("GET_INV_X_POLIZA").Columns("MATERIAL_ID")}
                Dim childColumns = New DataColumn() {miscDS.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("LICENSE_ID"), miscDS.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("MATERIAL_ID")}
                miscDS.Relations.Add("SERIES_X_SKU", parentColumns, childColumns, False)


                pResult = "OK"
                Return miscDS
            End If


        End If

    End Function
    <WebMethod(Description:="Get Inventory by Poliza")>
    Public Function GET_INV_X_SKU(ByVal pSKU As String, ByVal pLogin As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbconexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            sqldbconexion.Open()
            Dim inventory As New DataTable("GET_INV_X_SKU")
            Dim series As New DataTable("GET_SERIAL_NUMBER_X_MATERIAL")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Parameters.Add("@BARCODE_ID", SqlDbType.VarChar, 100)
            cmd.Parameters("@BARCODE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@BARCODE_ID").Value = pSKU

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = pLogin


            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INV_X_SKU]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion

            reader = cmd.ExecuteReader()
            inventory.Load(reader)

            If inventory.Rows.Count <= 0 Then
                pResult = "ERROR, SKU " & pSKU & " no tiene inventario"
                Return Nothing
            End If

            Dim result As DataSet = New DataSet()
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_SERIAL_NUMBER_X_MATERIAL_INFO]"
            reader = cmd.ExecuteReader()
            series.Load(reader)
            result.Tables.Add(inventory)
            result.Tables.Add(series)

            Dim parentColumns = New DataColumn() {result.Tables("GET_INV_X_SKU").Columns("LICENSE_ID"), result.Tables("GET_INV_X_SKU").Columns("MATERIAL_ID")}
            Dim childColumns = New DataColumn() {result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("LICENSE_ID"), result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("MATERIAL_ID")}
            result.Relations.Add("SERIES_X_SKU", parentColumns, childColumns, False)
            pResult = "OK"
            Return result
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing
        End Try
    End Function
    <WebMethod(Description:="Get Inventory by Poliza")>
    Public Function GET_INV_X_LOC(ByVal pLOC As String, ByVal pLogin As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbconexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            sqldbconexion.Open()
            Dim inventory As New DataTable("GET_INV_X_LOC")
            Dim series As New DataTable("GET_SERIAL_NUMBER_X_MATERIAL")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar, 100)
            cmd.Parameters("@LOCATION").Direction = ParameterDirection.Input
            cmd.Parameters("@LOCATION").Value = pLOC

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = pLogin


            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INV_X_LOC]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion

            reader = cmd.ExecuteReader()
            inventory.Load(reader)

            If inventory.Rows.Count <= 0 Then
                pResult = "ERROR, Ubicación " & pLOC & " no tiene inventario"
                Return Nothing
            End If

            Dim result As DataSet = New DataSet()
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_SERIAL_NUMBER_X_MATERIAL_INFO_BY_LOCATION]"
            reader = cmd.ExecuteReader()
            series.Load(reader)
            result.Tables.Add(inventory)
            result.Tables.Add(series)

            Dim parentColumns = New DataColumn() {result.Tables("GET_INV_X_LOC").Columns("LICENSE_ID"), result.Tables("GET_INV_X_LOC").Columns("MATERIAL_ID")}
            Dim childColumns = New DataColumn() {result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("LICENSE_ID"), result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("MATERIAL_ID")}
            result.Relations.Add("SERIES_X_SKU", parentColumns, childColumns, False)
            pResult = "OK"
            Return result
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Get Location Information")>
    Public Function GetLocation(ByVal pLOC As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection
        Try
            sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing
        End Try
        Dim XSQL As String = ""
        XSQL = "SELECT * "
        XSQL = XSQL + " FROM  " + DefaultSchema + "OP_WMS_SHELF_SPOTS"
        XSQL = XSQL + " WHERE "
        XSQL = XSQL + " LOCATION_SPOT = '" + pLOC + "'"

        Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
        Dim miscDS As DataSet = New DataSet()
        Try
            miscDA.Fill(miscDS, "GetLocation")
        Catch ex As Exception
            pResult = "ERROR," + ex.Message
            Return Nothing
        End Try
        If miscDS.Tables(0).Rows.Count <= 0 Then
            pResult = "ERROR, Ubicacion " & pLOC & " no existe."
            Return Nothing
        Else
            pResult = "OK"
            Return miscDS
        End If
    End Function
    <WebMethod(Description:="Get Inventory by Poliza")>
    Public Function GET_INV_X_LIC(ByVal pLIC As Integer, ByVal pLogin As String, ByVal pSKU As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldbconexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim inventory As New DataTable("GET_INV_X_LIC")
            Dim series As New DataTable("GET_SERIAL_NUMBER_X_MATERIAL")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = pLIC

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = pLogin


            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INV_X_LIC]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion
            sqldbconexion.Open()
            reader = cmd.ExecuteReader()
            inventory.Load(reader)

            If inventory.Rows.Count <= 0 Then
                pResult = "ERROR, licencia " & pLIC & " no tiene inventario"
                Return Nothing
            End If

            Dim result As DataSet = New DataSet()
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_SERIAL_NUMBER_X_MATERIAL_INFO_BY_LICENSE]"
            reader = cmd.ExecuteReader()
            series.Load(reader)
            result.Tables.Add(inventory)
            result.Tables.Add(series)

            Dim parentColumns = New DataColumn() {result.Tables("GET_INV_X_LIC").Columns("LICENSE_ID"), result.Tables("GET_INV_X_LIC").Columns("MATERIAL_ID")}
            Dim childColumns = New DataColumn() {result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("LICENSE_ID"), result.Tables("GET_SERIAL_NUMBER_X_MATERIAL").Columns("MATERIAL_ID")}
            result.Relations.Add("SERIES_X_SKU", parentColumns, childColumns, False)
            pResult = "OK"
            Return result
        Catch ex As Exception
            pResult = "ERROR:" + ex.Message
            Return Nothing

        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing
        End Try
    End Function


    <WebMethod(Description:="ValidateLicenceAndSkuToRealloc")>
    Public Function ValidateLicenceAndSkuToRealloc(ByVal pLIC As Integer, ByVal pSKU As String, ByVal pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldbconexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbconexion.Open()

        Try
            Dim dt As New DataTable("ValidateLicenceAndSkuToRealloc")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            cmd.Parameters.Add("@SOURCE_LICENCE_ID", SqlDbType.Int)
            cmd.Parameters("@SOURCE_LICENCE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@SOURCE_LICENCE_ID").Value = pLIC

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = pSKU

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = "OK"

            cmd.CommandText = DefaultSchema + "[OP_WMS_VALIDATE_LICENCE_AND_MATERIAL_TO_REALLOC]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion

            reader = cmd.ExecuteReader()

            dt.Load(reader)

            'sqldbConexion.Close()


            pResult = cmd.Parameters("@pResult").Value.ToString
            sqldbconexion.Close()


            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing

        End Try
    End Function



    <WebMethod(Description:="ValidateLicenseLocationForRealloc")>
    Public Function ValidateLicenseLocationForRealloc(ByVal license As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand


            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = license

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = pResult

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_LICENSE_FOR_REALLOC_PARTIAL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()
            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pResult").Value.ToString

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

    <WebMethod(Description:="ACTUALIZA EL INVENTARIO EN LINEA")>
    Public Function UpdateInventoryOnline(XML As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand


            cmd.Parameters.Add("@XML", SqlDbType.Xml)
            cmd.Parameters("@XML").Direction = ParameterDirection.Input
            cmd.Parameters("@XML").Value = XML

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_INVENTORY_ONLINE]"
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
        End Try
    End Function

    <WebMethod(Description:="ValidateLocationForStorage")>
    Public Function ValidateLocationForStorage(ByVal location As String, ByVal login As String, ByVal taskId As String,ByVal licenseId As Integer, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt As New DataTable("Operacion")

            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOGIN").Direction = ParameterDirection.Input
            cmd.Parameters("@LOGIN").Value = login

            cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar, 50)
            cmd.Parameters("@LOCATION_SPOT").Direction = ParameterDirection.Input
            cmd.Parameters("@LOCATION_SPOT").Value = location

            cmd.Parameters.Add("@TASK_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@TASK_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@TASK_ID").Value = taskId

            if licenseId > 0 Then
                cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
                cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
                cmd.Parameters("@LICENSE_ID").Value = licenseId
            End If

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_LOCATION_FOR_STORAGE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return dt.Rows(0)("Resultado").ToString() = "1"
            End If

            pResult = "No se encontró información."
            Return False

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="ValidateLocationMaxWeigth")>
    Public Function ValidateLocationMaxWeigth(locationSpot As String, licenseId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldbconexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbconexion.Open()

        Try
            pResult = String.Empty
            Dim dt As New DataTable("ValidateLicenceAndSkuToRealloc")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar, 25).Value = locationSpot
            cmd.Parameters.Add("@LICENCE_ID", SqlDbType.Int).Value = licenseId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_LOCATION_MAX_WEIGTH]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion

            reader = cmd.ExecuteReader()

            dt.Load(reader)
            sqldbconexion.Close()
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing

        End Try
    End Function

      <WebMethod(Description:="ValidateIfStatusOfLicenseAllowsRealloc")>
    Public Function ValidateIfStatusOfLicenseAllowsRealloc(licenseId As Integer, codeSku As String, environmentName As String, ByRef result As String) As DataTable

        Dim sqldbconexion  = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbconexion.Open()

        Try

            Dim dataTable As New DataTable("ValidateIfStatusOfLicenseAllowsRealloc")
            Dim sqlCommand As New SqlCommand
            Dim reader As SqlDataReader

            sqlCommand.Parameters.Add("@LICENCE_ID", SqlDbType.Int)
            sqlCommand.Parameters("@LICENCE_ID").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@LICENCE_ID").Value = licenseId

            sqlCommand.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar, 50)
            sqlCommand.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@MATERIAL_ID").Value = codeSku

            sqlCommand.Parameters.Add("@RESULT", SqlDbType.VarChar, 250)
            sqlCommand.Parameters("@RESULT").Direction = ParameterDirection.Output
            sqlCommand.Parameters("@RESULT").Value = "OK"

            sqlCommand.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_IF_STATUS_OF_LICENSE_ALLOWS_REALLOC]"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Connection = sqldbconexion

            reader = sqlCommand.ExecuteReader()

            dataTable.Load(reader)

            If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
                result = dataTable.Rows(0)("Mensaje").ToString()              
                if result = "Proceso Exitoso" Then
                    result = "OK"
                End If
            End If
            
            Return dataTable
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()

        End Try
    End Function

       <WebMethod(Description:="Valida si la ubicación existe y es valida.")>
    Public Function ValidateIfLocationExists(enviroment As String, location as String) As boolean
        Dim tablas = New DataSet()
        Dim sqldbConexion = New SqlConnection(AppSettings(enviroment).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand        

            cmd.Parameters.Add("@LOCATION_SPOT", SqlDbType.VarChar,25)
            cmd.Parameters("@LOCATION_SPOT").Direction = ParameterDirection.Input
            cmd.Parameters("@LOCATION_SPOT").Value = location

            cmd.CommandText = $"{DefaultSchema}[OP_WMS_SP_VALIDATE_IF_LOCATION_EXISTS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            cmd.ExecuteNonQuery()

            Dim miscDa = New SqlDataAdapter(cmd)
            miscDa.Fill(tablas)
            If HasRows(tablas) Then
                return False
            End If
            Return True
        Catch ex As Exception
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    Private Shared Function HasRows(dataset As Dataset) As Boolean
        return dataset.Tables(0).Rows.Count = 0
    End Function

    <WebMethod(Description:="Obtiene la información principal de la etiqueta o caja.")>
    Public Function ObtenerInformacionDeLaEtiquetaOCaja(type as String, barcode as string, enviroment As String, ByRef result As String ) As DataTable
        Dim sqldbconexion  = New SqlConnection(AppSettings(enviroment).ToString)
        sqldbconexion.Open()

        Try

            Dim dataTable As New DataTable("InformacionDeLaEtiquetaOCaja")
            Dim sqlCommand As New SqlCommand
            Dim reader As SqlDataReader

            sqlCommand.Parameters.Add("@TYPE", SqlDbType.VarChar, 50)
            sqlCommand.Parameters("@TYPE").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@TYPE").Value = type

            sqlCommand.Parameters.Add("@BARCODE", SqlDbType.VarChar, 50)
            sqlCommand.Parameters("@BARCODE").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@BARCODE").Value = barcode

            sqlCommand.CommandText = DefaultSchema + "[OP_WMS_SP_GET_LABEL_INFORMATION]"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Connection = sqldbconexion

            reader = sqlCommand.ExecuteReader()

            dataTable.Load(reader)

            result = "OK"
            
            Return dataTable
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()

        End Try
    End Function

    <WebMethod(Description:="Obtiene los contenidos de la etiqueta o caja")>
    Public Function ObtenerDetalleDeLaEtiquetaOCaja(type as String, barcode as string, wave As integer, enviroment As String, ByRef result As String ) As DataTable
        Dim sqldbconexion  = New SqlConnection(AppSettings(enviroment).ToString)
        sqldbconexion.Open()

        Try

            Dim dataTable As New DataTable("DetalleDeLaEtiquetaOCaja")
            Dim sqlCommand As New SqlCommand
            Dim reader As SqlDataReader

            sqlCommand.Parameters.Add("@TYPE", SqlDbType.VarChar, 50)
            sqlCommand.Parameters("@TYPE").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@TYPE").Value = type

            sqlCommand.Parameters.Add("@BARCODE", SqlDbType.VarChar, 50)
            sqlCommand.Parameters("@BARCODE").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@BARCODE").Value = barcode

            sqlCommand.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int)
            sqlCommand.Parameters("@WAVE_PICKING_ID").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@WAVE_PICKING_ID").Value = wave

            sqlCommand.CommandText = DefaultSchema + "[OP_WMS_SP_GET_LABEL_DETAIL]"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Connection = sqldbconexion

            reader = sqlCommand.ExecuteReader()

            dataTable.Load(reader)

            result = "OK"
            
            Return dataTable
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()

        End Try
    End Function


    <WebMethod(Description:="Reubica una etiqueta de despacho y devuelve el resultado por medio de un objeto operación.")>
    Public Function ReubicarEtiquetaDeDespacho(labelId as String, targetLocation as string, enviroment As String, ByRef result As String ) As String

        Dim sqldbconexion  = New SqlConnection(AppSettings(enviroment).ToString)
        sqldbconexion.Open()
        Try
            Dim dataTable As New DataTable("Operacion")
            Dim sqlCommand As New SqlCommand
            Dim reader As SqlDataReader

            sqlCommand.Parameters.Add("@LABEL_ID", SqlDbType.Int)
            sqlCommand.Parameters("@LABEL_ID").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@LABEL_ID").Value = labelId

            sqlCommand.Parameters.Add("@TARGET_LOCATION", SqlDbType.VarChar, 25)
            sqlCommand.Parameters("@TARGET_LOCATION").Direction = ParameterDirection.Input
            sqlCommand.Parameters("@TARGET_LOCATION").Value = targetLocation

            sqlCommand.CommandText = $"{DefaultSchema}[OP_WMS_REALLOCATE_PICKING_LABEL]"
            sqlCommand.CommandType = CommandType.StoredProcedure
            sqlCommand.Connection = sqldbconexion

            reader = sqlCommand.ExecuteReader()

            dataTable.Load(reader)

            If dataTable IsNot Nothing AndAlso dataTable.Rows.Count > 0 Then
                result = dataTable.Rows(0)("Mensaje").ToString()
                Return dataTable.Rows(0)("Resultado").ToString()
            End If

            result = "No se encontró información."
            Return "-1"
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()

        End Try
    End Function

    <WebMethod(Description:="ValidateLocationVolume")>
    Public Function ValidateLocationVolume(locationSpot As String, licenseId As Integer, pEnvironmentName As String, ByRef pResult As String) As DataTable

        Dim sqldbconexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbconexion.Open()

        Try
            pResult = String.Empty
            Dim dt As New DataTable("ValidateLocationVolume")
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader

            cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar, 25).Value = locationSpot
            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_LOCATION_VOLUME]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbconexion

            reader = cmd.ExecuteReader()

            dt.Load(reader)
            Return dt
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbconexion.Close()
            sqldbconexion.Dispose()
            sqldbconexion = Nothing

        End Try
    End Function

    <WebMethod(Description:="Obtiene el inventario disponible por licencia")>
    Public Function getInventoryAvailable(ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim XSQL As String = ""
            XSQL = "SELECT * FROM " + DefaultSchema + "[OP_WMS_VW_AVAILABLE_LICENSES]"

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion)
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "GetInventoryAvailable")

            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Obtiene los proyectos activos, no han sido completados, finalizados o cancelados")>
    Public Function getProjectsActive(ByVal pOwner As String, ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet
        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim command = New SqlCommand
            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_PROJECTS_ACTIVE]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldb_conexion

            Dim miscDA As SqlDataAdapter = New SqlDataAdapter(command)
            Dim miscDS As DataSet = New DataSet()

            miscDA.Fill(miscDS, "GetProjectsActive")

            pResult = "OK"
            Return miscDS
        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
        End Try

    End Function


    <WebMethod(Description:="Obtiene el inventario reservado por proyecto")>
    Public Function getInventorybyProject(ByVal pProject As String, ByVal pWarehouse As String, ByVal pDiscretional As Boolean,
                                          ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim command = New SqlCommand
            command.Parameters.Add(New SqlParameter("@WAREHOUSE", SqlDbType.VarChar, 25)).Value = pWarehouse
            command.Parameters.Add(New SqlParameter("@PROJECT_ID", SqlDbType.VarChar, 36)).Value = pProject
            command.Parameters.Add(New SqlParameter("@DISCRETIONAL", SqlDbType.Bit)).Value = pDiscretional
            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_INVENTORY_RESERVED_BY_PROJECT]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldb_conexion

            Dim miscDA = New SqlDataAdapter(command)
            Dim miscDS = New DataSet()

            miscDA.Fill(miscDS, "InventoryByProject")

            pResult = "OK"
            Return miscDS

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
        End Try

    End Function

    <WebMethod(Description:="Obtiene las ubicaciones de salida")>
    Public Function getExitLocations( ByVal pDistributionCenterId As String,
                                          ByRef pResult As String, ByVal pEnvironmentName As String) As DataSet

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            Dim command = New SqlCommand
            command.Parameters.Add(New SqlParameter("@DISTRIBUTION_CENTER_ID", SqlDbType.VarChar, 25)).Value = pDistributionCenterId
            command.CommandText = DefaultSchema + "[OP_WMS_SP_GET_LOCATION_FOR_DISPATCH]"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = sqldb_conexion

            Dim miscDA = New SqlDataAdapter(command)
            Dim miscDS = New DataSet()

            miscDA.Fill(miscDS, "Locations")

            pResult = "OK"
            Return miscDS

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
        End Try

    End Function

End Class