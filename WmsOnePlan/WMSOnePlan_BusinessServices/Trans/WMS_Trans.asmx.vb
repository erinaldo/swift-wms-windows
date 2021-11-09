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
Public Class WMS_Trans
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function RegisterOccupancy(ByVal pSOURCE_LOCATION As String, ByVal pLOGIN_ID As String, ByVal pOCCUPANCY_LEVEL As Double, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
            cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
            cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pOCCUPANCY_LEVEL", SqlDbType.Float)
            cmd.Parameters("@pOCCUPANCY_LEVEL").Direction = ParameterDirection.Input
            cmd.Parameters("@pOCCUPANCY_LEVEL").Value = pOCCUPANCY_LEVEL


            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_OCUPPACY_LEVEL]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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

    <WebMethod()>
    Public Function SetReceptionAuditSummary(ByVal pCODIGO_POLIZA As String, ByVal pQTY1 As Double, ByVal pQTY2 As Double, ByVal pQTY3 As Double, ByVal pQTY4 As Double, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
            cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

            cmd.Parameters.Add("@pMPC01", SqlDbType.Float)
            cmd.Parameters("@pMPC01").Direction = ParameterDirection.Input
            cmd.Parameters("@pMPC01").Value = pQTY1

            cmd.Parameters.Add("@pMPC02", SqlDbType.Float)
            cmd.Parameters("@pMPC02").Direction = ParameterDirection.Input
            cmd.Parameters("@pMPC02").Value = pQTY2

            cmd.Parameters.Add("@pMPC03", SqlDbType.Float)
            cmd.Parameters("@pMPC01").Direction = ParameterDirection.Input
            cmd.Parameters("@pMPC01").Value = pQTY3

            cmd.Parameters.Add("@pMPC04", SqlDbType.Float)
            cmd.Parameters("@pMPC01").Direction = ParameterDirection.Input
            cmd.Parameters("@pMPC01").Value = pQTY4

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_RECEPTION_SET_SUMMARY]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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
    <WebMethod()>
    Public Function SetTransWeigth(ByVal pSERIAL_NUMBER As Integer, ByVal pWEIGTH As Double, ByVal pLOGIN_ID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pSERIAL_NUMBER", SqlDbType.Int)
            cmd.Parameters("@pSERIAL_NUMBER").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERIAL_NUMBER").Value = pSERIAL_NUMBER

            cmd.Parameters.Add("@pWEIGTH", SqlDbType.Float)
            cmd.Parameters("@pWEIGTH").Direction = ParameterDirection.Input
            cmd.Parameters("@pWEIGTH").Value = pWEIGTH

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_SET_TRANS_WEIGTH]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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
    <WebMethod()>
    Public Function AuditCount(ByVal pAUDIT_ID As Integer, ByVal pMETHOD As String, ByVal pCODIGO_POLIZA As String,
                               ByVal pBARCODE_ID As String, ByVal pQTY_INPUTED As Integer, ByVal pSERIAL_ID As String, ByVal pLOGIN_ID As String,
                               ByVal pOPTION As String, ByVal pBatch As String, ByVal pDateExpirtacion As Date,
                               ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pAUDIT_ID", SqlDbType.Int)
            cmd.Parameters("@pAUDIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pAUDIT_ID").Value = pAUDIT_ID

            cmd.Parameters.Add("@pMETHOD", SqlDbType.VarChar, 25)
            cmd.Parameters("@pMETHOD").Direction = ParameterDirection.Input
            cmd.Parameters("@pMETHOD").Value = pMETHOD

            cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
            cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

            cmd.Parameters.Add("@pBARCODE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pBARCODE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pBARCODE_ID").Value = pBARCODE_ID

            cmd.Parameters.Add("@pQTY_INPUTED", SqlDbType.Int)
            cmd.Parameters("@pQTY_INPUTED").Direction = ParameterDirection.Input
            cmd.Parameters("@pQTY_INPUTED").Value = pQTY_INPUTED

            cmd.Parameters.Add("@pSERIAL_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pSERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pSERIAL_ID").Value = pSERIAL_ID

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID



            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            Select Case pOPTION
                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    cmd.Parameters.Add("@BATCH", SqlDbType.VarChar, 50)
                    cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
                    cmd.Parameters("@BATCH").Value = pBatch

                    cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.Date)
                    cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@DATE_EXPIRATION").Value = pDateExpirtacion

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_DISPATCH_COUNT]"
                Case "MMI_AUDIT_REC_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_RECEPTION_COUNT]"
            End Select

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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

    <WebMethod()>
    Public Function AuditStartCounting(ByVal pLOGIN_ID As String, ByVal pCODIGO_POLIZA As String, ByVal pCONTENEDOR As String, ByVal pMETHOD As String, ByRef pCREATED_AUDIT_ID As Integer, ByVal pOPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pCOUNTING_METHOD", SqlDbType.VarChar, 25)
            cmd.Parameters("@pCOUNTING_METHOD").Direction = ParameterDirection.Input
            cmd.Parameters("@pCOUNTING_METHOD").Value = pMETHOD

            cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 50)
            cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
            cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

            cmd.Parameters.Add("@pCONTENEDOR", SqlDbType.VarChar, 25)
            cmd.Parameters("@pCONTENEDOR").Direction = ParameterDirection.Input
            cmd.Parameters("@pCONTENEDOR").Value = pCONTENEDOR

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pCREATED_AUDIT_ID", SqlDbType.Int)
            cmd.Parameters("@pCREATED_AUDIT_ID").Direction = ParameterDirection.Output
            cmd.Parameters("@pCREATED_AUDIT_ID").Value = "0"

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            Select Case pOPTION
                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_DISPATCH_START]"
                Case "MMI_AUDIT_REC_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_RECEPTION_START]"
            End Select

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString
            pCREATED_AUDIT_ID = IIf(IsDBNull(cmd.Parameters("@pCREATED_AUDIT_ID").Value), 0, cmd.Parameters("@pCREATED_AUDIT_ID").Value)

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

    <WebMethod()>
    Public Function AuditFinishCounting(ByVal pAUDIT_ID As Integer, ByVal pLOGIN_ID As String, ByVal pOPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pAUDIT_ID", SqlDbType.Int)
            cmd.Parameters("@pAUDIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pAUDIT_ID").Value = pAUDIT_ID

            cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 15)
            cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@pSTATUS").Value = "FINISHED"

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            Select Case pOPTION
                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_DISPATCH_FINISH]"
                Case "MMI_AUDIT_REC_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_RECEPTION_FINISH]"
            End Select

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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

    <WebMethod()>
    Public Function LicenseReAlloc(ByVal pLICENSE_ID As Integer, ByVal pNEW_LOCATION As String, ByVal pLOGIN_ID As String,
                                   ByVal pMt2 As Decimal, ByRef pResult As String, ByVal pEnvironmentName As String, ByVal paramName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pLICENCIA_ID", SqlDbType.Int)
            cmd.Parameters("@pLICENCIA_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLICENCIA_ID").Value = pLICENSE_ID

            cmd.Parameters.Add("@pNEW_LOCATION_SPOT", SqlDbType.VarChar, 50)
            cmd.Parameters("@pNEW_LOCATION_SPOT").Direction = ParameterDirection.Input
            cmd.Parameters("@pNEW_LOCATION_SPOT").Value = pNEW_LOCATION

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

            cmd.Parameters.Add("@pMt2", SqlDbType.Decimal)
            cmd.Parameters("@pMt2").Direction = ParameterDirection.Input
            cmd.Parameters("@pMt2").Value = pMt2

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""

            cmd.Parameters.Add("@PARAM_NAME", SqlDbType.VarChar, 250)
            cmd.Parameters("@PARAM_NAME").Direction = ParameterDirection.Input
            cmd.Parameters("@PARAM_NAME").Value = paramName

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REALLOC_LICENSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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

    <WebMethod()>
    Public Function AuditResetCounting(ByVal pAUDIT_ID As Integer, ByVal pBARCODE_ID As String, ByVal pOPTION As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pAUDIT_ID", SqlDbType.Int)
            cmd.Parameters("@pAUDIT_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pAUDIT_ID").Value = pAUDIT_ID

            cmd.Parameters.Add("@pBARCODE_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pBARCODE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pBARCODE_ID").Value = pBARCODE_ID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""


            Select Case pOPTION
                Case "MMI_AUDIT_DISPATCH_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_DISPATCH_RESET]"
                Case "MMI_AUDIT_REC_FISCAL"
                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_AUDIT_RECEPTION_RESET]"
            End Select

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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
    <WebMethod()>
    Public Function AllocLicense(ByVal pLicenseID As Integer, ByVal pTargetLocation As String, ByVal pLoginID As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLICENSE_ID").Value = pLicenseID

            cmd.Parameters.Add("@pTARGET_LOCATION", SqlDbType.VarChar, 50)
            cmd.Parameters("@pTARGET_LOCATION").Direction = ParameterDirection.Input
            cmd.Parameters("@pTARGET_LOCATION").Value = pTargetLocation

            cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 50)
            cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@pLOGIN_ID").Value = pLoginID

            cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
            cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
            cmd.Parameters("@pRESULT").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ALLOC_LICENSE]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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


    <WebMethod()>
    Public Function RegisterTrans(ByVal pTRADE_AGREEMENT As String, ByVal pLOGIN_ID As String, ByVal pTRANS_TYPE As String,
                                  ByVal pTRANS_EXTRA_COMMENTS As String, ByVal pMATERIAL_BARCODE As String,
                                  ByVal pMATERIAL_ID As String, ByVal pSOURCE_LICENSE As Integer,
                                  ByVal pTARGET_LICENSE As Integer, ByVal pSOURCE_LOCATION As String,
                                  ByVal pTARGET_LOCATION As String, ByVal pCLIENT_OWNER As String,
                                  ByVal pQUANTITY_UNITS As Double, ByVal pSOURCE_WAREHOUSE As String,
                                  ByVal pTARGET_WAREHOUSE As String, ByVal pTRANS_SUBTYPE As String, ByRef pCODIGO_POLIZA As String,
                                  ByVal pLICENSE_ID As Integer, ByVal pSTATUS As String, ByVal pWAVE_PICKING_ID As Integer,
                                  ByVal pSERIAL_NUMBER As Integer, ByVal pTransMT2 As Decimal,
                                  ByVal pTipoUbicacion As String, ByVal pMt2 As Decimal, ByVal pVin As String,
                                  ByVal pTask_Id As String, ByVal pSerial As String, ByVal pLote As String, ByVal pFechaLote As Date,
                                  ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)

        Try
            sqldb_conexion.Open()

            Dim cmd As New SqlCommand

            Select Case pTRANS_TYPE

                Case "DESPACHO_FISCAL"

                    If pCLIENT_OWNER = "" Or IsDBNull(pCLIENT_OWNER) Then
                        pCLIENT_OWNER = "0"
                    End If
                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pMATERIAL_ID", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_ID").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pWAVE_PICKING_ID", SqlDbType.Int)
                    cmd.Parameters("@pWAVE_PICKING_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pWAVE_PICKING_ID").Value = pWAVE_PICKING_ID

                    cmd.Parameters.Add("@pSERIAL_NUMBER", SqlDbType.Int)
                    cmd.Parameters("@pSERIAL_NUMBER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSERIAL_NUMBER").Value = pSERIAL_NUMBER

                    cmd.Parameters.Add("@pTipoUbicacion", SqlDbType.VarChar)
                    cmd.Parameters("@pTipoUbicacion").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTipoUbicacion").Value = pTipoUbicacion

                    cmd.Parameters.Add("@pMt2", SqlDbType.Decimal)
                    cmd.Parameters("@pMt2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMt2").Value = pMt2


                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""



                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_DISPATCH_FISCAL]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion

                Case "DESPACHO_ALMGEN"
                    pCLIENT_OWNER = "0"

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pMATERIAL_ID", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_ID").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pWAVE_PICKING_ID", SqlDbType.Int)
                    cmd.Parameters("@pWAVE_PICKING_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pWAVE_PICKING_ID").Value = pWAVE_PICKING_ID

                    cmd.Parameters.Add("@pSERIAL_NUMBER", SqlDbType.Int)
                    cmd.Parameters("@pSERIAL_NUMBER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSERIAL_NUMBER").Value = pSERIAL_NUMBER

                    cmd.Parameters.Add("@pTipoUbicacion", SqlDbType.VarChar)
                    cmd.Parameters("@pTipoUbicacion").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTipoUbicacion").Value = pTipoUbicacion

                    cmd.Parameters.Add("@pMt2", SqlDbType.Decimal)
                    cmd.Parameters("@pMt2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMt2").Value = pMt2

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_DISPATCH_GENERAL]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion


                Case "TRASLADO_GENERAL"

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = "DUMMY"

                    cmd.Parameters.Add("@pMATERIAL_ID", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_ID").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pWAVE_PICKING_ID", SqlDbType.Int)
                    cmd.Parameters("@pWAVE_PICKING_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pWAVE_PICKING_ID").Value = pWAVE_PICKING_ID

                    cmd.Parameters.Add("@pSERIAL_NUMBER", SqlDbType.Int)
                    cmd.Parameters("@pSERIAL_NUMBER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSERIAL_NUMBER").Value = pSERIAL_NUMBER

                    cmd.Parameters.Add("@pTRANS_MT2", SqlDbType.Decimal)
                    cmd.Parameters("@pTRANS_MT2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_MT2").Value = pTransMT2

                    cmd.Parameters.Add("@pTipoUbicacion", SqlDbType.VarChar)
                    cmd.Parameters("@pTipoUbicacion").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTipoUbicacion").Value = pTipoUbicacion

                    cmd.Parameters.Add("@pMt2", SqlDbType.Decimal)
                    cmd.Parameters("@pMt2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMt2").Value = pMt2

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_TRASLADO_GENERAL]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion

                Case "RECEP_GENERAL_X_TRASLADO"

                    cmd.Parameters.Add("@pTRADE_AGREEMENT", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRADE_AGREEMENT").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRADE_AGREEMENT").Value = pTRADE_AGREEMENT

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pTRANS_TYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_TYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_TYPE").Value = pTRANS_TYPE

                    cmd.Parameters.Add("@pTRANS_EXTRA_COMMENTS", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Value = pTRANS_EXTRA_COMMENTS

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pMATERIAL_CODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_CODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_CODE").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pTARGET_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pTARGET_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LICENSE").Value = pTARGET_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pTARGET_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LOCATION").Value = pTARGET_LOCATION

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pSOURCE_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Value = pSOURCE_WAREHOUSE

                    cmd.Parameters.Add("@pTARGET_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_WAREHOUSE").Value = pTARGET_WAREHOUSE

                    cmd.Parameters.Add("@pTRANS_SUBTYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_SUBTYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_SUBTYPE").Value = pTRANS_SUBTYPE

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
                    cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLICENSE_ID").Value = pLICENSE_ID

                    cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSTATUS").Value = pSTATUS

                    cmd.Parameters.Add("@pWAVE_PICKING_ID", SqlDbType.Int)
                    cmd.Parameters("@pWAVE_PICKING_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pWAVE_PICKING_ID").Value = pWAVE_PICKING_ID

                    cmd.Parameters.Add("@pTRANS_MT2", SqlDbType.Decimal)
                    cmd.Parameters("@pTRANS_MT2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_MT2").Value = pTransMT2

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_RECEPTION_GENERAL_REALLOC]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion

                Case "REUBICACION_PARCIAL"

                    cmd.Parameters.Add("@pTRADE_AGREEMENT", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRADE_AGREEMENT").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRADE_AGREEMENT").Value = pTRADE_AGREEMENT

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pTRANS_TYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_TYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_TYPE").Value = pTRANS_TYPE

                    cmd.Parameters.Add("@pTRANS_EXTRA_COMMENTS", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Value = pTRANS_EXTRA_COMMENTS

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pMATERIAL_CODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_CODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_CODE").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pTARGET_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pTARGET_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LICENSE").Value = pTARGET_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pTARGET_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LOCATION").Value = pTARGET_LOCATION

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pSOURCE_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Value = pSOURCE_WAREHOUSE

                    cmd.Parameters.Add("@pTARGET_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_WAREHOUSE").Value = pTARGET_WAREHOUSE

                    cmd.Parameters.Add("@pTRANS_SUBTYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_SUBTYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_SUBTYPE").Value = pTRANS_SUBTYPE

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
                    cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLICENSE_ID").Value = pLICENSE_ID

                    cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSTATUS").Value = pSTATUS

                    cmd.Parameters.Add("@pWAVE_PICKING_ID", SqlDbType.Int)
                    cmd.Parameters("@pWAVE_PICKING_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pWAVE_PICKING_ID").Value = pWAVE_PICKING_ID

                    cmd.Parameters.Add("@pTRANS_MT2", SqlDbType.Decimal)
                    cmd.Parameters("@pTRANS_MT2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_MT2").Value = pTransMT2

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_REALLOC_PARTIAL]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion

                Case "INICIALIZACION_GENERAL"

                    cmd.Parameters.Add("@pTRADE_AGREEMENT", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRADE_AGREEMENT").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRADE_AGREEMENT").Value = pTRADE_AGREEMENT

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pTRANS_TYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_TYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_TYPE").Value = pTRANS_TYPE

                    cmd.Parameters.Add("@pTRANS_EXTRA_COMMENTS", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Value = pTRANS_EXTRA_COMMENTS

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pMATERIAL_CODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_CODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_CODE").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pTARGET_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pTARGET_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LICENSE").Value = pTARGET_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pTARGET_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LOCATION").Value = pTARGET_LOCATION

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pSOURCE_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Value = pSOURCE_WAREHOUSE

                    cmd.Parameters.Add("@pTARGET_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_WAREHOUSE").Value = pTARGET_WAREHOUSE

                    cmd.Parameters.Add("@pTRANS_SUBTYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_SUBTYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_SUBTYPE").Value = pTRANS_SUBTYPE

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.InputOutput
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
                    cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLICENSE_ID").Value = pLICENSE_ID

                    cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSTATUS").Value = pSTATUS

                    cmd.Parameters.Add("@pTransMT2", SqlDbType.Decimal)
                    cmd.Parameters("@pTransMT2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTransMT2").Value = pTransMT2

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar, 50)
                    cmd.Parameters("@SERIAL").Direction = ParameterDirection.Input
                    cmd.Parameters("@SERIAL").Value = pSerial

                    cmd.Parameters.Add("@BATCH", SqlDbType.VarChar, 50)
                    cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
                    cmd.Parameters("@BATCH").Value = pLote

                    cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.Date)
                    cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@DATE_EXPIRATION").Value = pFechaLote.Date

                    cmd.Parameters.Add("@VIN", SqlDbType.VarChar, 40)
                    cmd.Parameters("@VIN").Direction = ParameterDirection.Input
                    cmd.Parameters("@VIN").Value = pVin


                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_INIT_GENERAL]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion

                Case Else
                    cmd.Parameters.Add("@pTRADE_AGREEMENT", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRADE_AGREEMENT").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRADE_AGREEMENT").Value = pTRADE_AGREEMENT

                    cmd.Parameters.Add("@pLOGIN_ID", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pLOGIN_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLOGIN_ID").Value = pLOGIN_ID

                    cmd.Parameters.Add("@pTRANS_TYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_TYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_TYPE").Value = pTRANS_TYPE

                    cmd.Parameters.Add("@pTRANS_EXTRA_COMMENTS", SqlDbType.VarChar, 50)
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_EXTRA_COMMENTS").Value = pTRANS_EXTRA_COMMENTS

                    cmd.Parameters.Add("@pMATERIAL_BARCODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_BARCODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_BARCODE").Value = pMATERIAL_BARCODE

                    cmd.Parameters.Add("@pMATERIAL_CODE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pMATERIAL_CODE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pMATERIAL_CODE").Value = pMATERIAL_ID

                    cmd.Parameters.Add("@pSOURCE_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pSOURCE_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LICENSE").Value = pSOURCE_LICENSE

                    cmd.Parameters.Add("@pTARGET_LICENSE", SqlDbType.Int)
                    cmd.Parameters("@pTARGET_LICENSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LICENSE").Value = pTARGET_LICENSE

                    cmd.Parameters.Add("@pSOURCE_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_LOCATION").Value = pSOURCE_LOCATION

                    cmd.Parameters.Add("@pTARGET_LOCATION", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_LOCATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_LOCATION").Value = pTARGET_LOCATION

                    cmd.Parameters.Add("@pCLIENT_OWNER", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCLIENT_OWNER").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCLIENT_OWNER").Value = pCLIENT_OWNER

                    cmd.Parameters.Add("@pQUANTITY_UNITS", SqlDbType.Float)
                    cmd.Parameters("@pQUANTITY_UNITS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pQUANTITY_UNITS").Value = pQUANTITY_UNITS

                    cmd.Parameters.Add("@pSOURCE_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSOURCE_WAREHOUSE").Value = pSOURCE_WAREHOUSE

                    cmd.Parameters.Add("@pTARGET_WAREHOUSE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTARGET_WAREHOUSE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTARGET_WAREHOUSE").Value = pTARGET_WAREHOUSE

                    cmd.Parameters.Add("@pTRANS_SUBTYPE", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pTRANS_SUBTYPE").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_SUBTYPE").Value = pTRANS_SUBTYPE

                    cmd.Parameters.Add("@pCODIGO_POLIZA", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pCODIGO_POLIZA").Direction = ParameterDirection.Input
                    cmd.Parameters("@pCODIGO_POLIZA").Value = pCODIGO_POLIZA

                    cmd.Parameters.Add("@pLICENSE_ID", SqlDbType.Int)
                    cmd.Parameters("@pLICENSE_ID").Direction = ParameterDirection.Input
                    cmd.Parameters("@pLICENSE_ID").Value = pLICENSE_ID

                    cmd.Parameters.Add("@pSTATUS", SqlDbType.VarChar, 25)
                    cmd.Parameters("@pSTATUS").Direction = ParameterDirection.Input
                    cmd.Parameters("@pSTATUS").Value = pSTATUS

                    cmd.Parameters.Add("@pTRANS_MT2", SqlDbType.Decimal)
                    cmd.Parameters("@pTRANS_MT2").Direction = ParameterDirection.Input
                    cmd.Parameters("@pTRANS_MT2").Value = pTransMT2

                    cmd.Parameters.Add("@VIN", SqlDbType.VarChar, 40)
                    cmd.Parameters("@VIN").Direction = ParameterDirection.Input
                    cmd.Parameters("@VIN").Value = pVin

                    cmd.Parameters.Add("@SERIAL", SqlDbType.VarChar, 50)
                    cmd.Parameters("@SERIAL").Direction = ParameterDirection.Input
                    cmd.Parameters("@SERIAL").Value = pSerial

                    cmd.Parameters.Add("@BATCH", SqlDbType.VarChar, 50)
                    cmd.Parameters("@BATCH").Direction = ParameterDirection.Input
                    cmd.Parameters("@BATCH").Value = pLote

                    cmd.Parameters.Add("@DATE_EXPIRATION", SqlDbType.Date)
                    cmd.Parameters("@DATE_EXPIRATION").Direction = ParameterDirection.Input
                    cmd.Parameters("@DATE_EXPIRATION").Value = pFechaLote.Date

                    cmd.Parameters.Add("@pRESULT", SqlDbType.VarChar, 250)
                    cmd.Parameters("@pRESULT").Direction = ParameterDirection.Output
                    cmd.Parameters("@pRESULT").Value = ""

                    If (Not pTask_Id Is Nothing) AndAlso pTask_Id <> String.Empty Then
                        cmd.Parameters.Add("@pTASK_ID", SqlDbType.Decimal)
                        cmd.Parameters("@pTASK_ID").Direction = ParameterDirection.Input
                        cmd.Parameters("@pTASK_ID").Value = pTask_Id
                    End If

                    cmd.CommandText = DefaultSchema + "[OP_WMS_SP_REGISTER_INV_TRANS]"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Connection = sqldb_conexion
            End Select

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()

            Select Case pTRANS_TYPE
                Case "INICIALIZACION_GENERAL"
                    pCODIGO_POLIZA = cmd.Parameters("@pCODIGO_POLIZA").Value
            End Select


            pResult = cmd.Parameters("@pRESULT").Value.ToString
            If pResult <> "OK" Then
                pResult = pResult
            End If

            Return IIf(pResult = "OK", True, False)

        Catch ex As Exception
            pResult = "RegisterTrans: (" + pEnvironmentName + ")" + ex.Message
            Return False
        Finally
            sqldb_conexion.Close()
            sqldb_conexion.Dispose()
            sqldb_conexion = Nothing
        End Try
    End Function

    <WebMethod()>
    Public Function CreateTypeChangeXLicense(ByVal pLicenseID As Integer, ByVal pTypeCharge As Integer,
                                             ByVal pQty As Integer, ByVal pLastUpdatedBy As String, ByVal pTypeTrans As String,
                                             ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldb_conexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldb_conexion.Open()

        Try

            Dim cmd As New SqlCommand
            cmd.Parameters.Add("@LICENCESE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENCESE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENCESE_ID").Value = pLicenseID

            cmd.Parameters.Add("@TYPE_CHARGE_ID", SqlDbType.Int)
            cmd.Parameters("@TYPE_CHARGE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@TYPE_CHARGE_ID").Value = pTypeCharge

            cmd.Parameters.Add("@QTY", SqlDbType.Int)
            cmd.Parameters("@QTY").Direction = ParameterDirection.Input
            cmd.Parameters("@QTY").Value = pQty

            cmd.Parameters.Add("@LAST_UPDATED_BY", SqlDbType.VarChar)
            cmd.Parameters("@LAST_UPDATED_BY").Direction = ParameterDirection.Input
            cmd.Parameters("@LAST_UPDATED_BY").Value = pLastUpdatedBy

            cmd.Parameters.Add("@TYPE_TRANS", SqlDbType.VarChar)
            cmd.Parameters("@TYPE_TRANS").Direction = ParameterDirection.Input
            cmd.Parameters("@TYPE_TRANS").Value = pTypeTrans

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_CREATE_TYPE_CHANGE_X_LICENSE]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldb_conexion

            cmd.ExecuteNonQuery()

            sqldb_conexion.Close()
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

    <WebMethod()>
    Public Function UpdateStatusQuotaLetter(ByVal pDocId As Integer, ByVal pStatus As String, ByVal pUserId As String,
                                            ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@DOC_ID", SqlDbType.Int)
            cmd.Parameters("@DOC_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@DOC_ID").Value = pDocId

            cmd.Parameters.Add("@Status", SqlDbType.VarChar)
            cmd.Parameters("@Status").Direction = ParameterDirection.Input
            cmd.Parameters("@Status").Value = pStatus

            cmd.Parameters.Add("@UserId", SqlDbType.VarChar)
            cmd.Parameters("@UserId").Direction = ParameterDirection.Input
            cmd.Parameters("@UserId").Value = pUserId

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_QUOTA_LETTER_STATUS]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.ExecuteNonQuery()

            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString

            Return pResult = "OK"

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function CreateAcuseRecibo(ByVal pPoliza As String, ByVal pFob As String, ByVal pDate As DateTime,
                                      ByVal pCodigoTransportista As String, ByVal pPlacaTransportista As String, ByVal pNumeroContenedor As String,
                                      ByVal pNumeroMarchamo As String,
                                      ByVal pUserId As String, ByVal pFoto1 As Byte(), ByVal pFoto2 As Byte(), ByVal pFoto3 As Byte(),
                                      ByVal pStatus As String, ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@POLIZA", SqlDbType.VarChar)
            cmd.Parameters("@POLIZA").Direction = ParameterDirection.Input
            cmd.Parameters("@POLIZA").Value = pPoliza

            cmd.Parameters.Add("@FOB", SqlDbType.VarChar)
            cmd.Parameters("@FOB").Direction = ParameterDirection.Input
            cmd.Parameters("@FOB").Value = pFob

            cmd.Parameters.Add("@DATE", SqlDbType.DateTime)
            cmd.Parameters("@DATE").Direction = ParameterDirection.Input
            cmd.Parameters("@DATE").Value = pDate

            cmd.Parameters.Add("@CODIGO_TRASPORTISTA", SqlDbType.VarChar)
            cmd.Parameters("@CODIGO_TRASPORTISTA").Direction = ParameterDirection.Input
            cmd.Parameters("@CODIGO_TRASPORTISTA").Value = pCodigoTransportista

            cmd.Parameters.Add("@PLACA_TRASPORTISTA", SqlDbType.VarChar)
            cmd.Parameters("@PLACA_TRASPORTISTA").Direction = ParameterDirection.Input
            cmd.Parameters("@PLACA_TRASPORTISTA").Value = pPlacaTransportista

            cmd.Parameters.Add("@NUMERO_CONTENEDOR", SqlDbType.VarChar)
            cmd.Parameters("@NUMERO_CONTENEDOR").Direction = ParameterDirection.Input
            cmd.Parameters("@NUMERO_CONTENEDOR").Value = pNumeroContenedor

            cmd.Parameters.Add("@NUMERO_MARCHAMO", SqlDbType.VarChar)
            cmd.Parameters("@NUMERO_MARCHAMO").Direction = ParameterDirection.Input
            cmd.Parameters("@NUMERO_MARCHAMO").Value = pNumeroMarchamo

            cmd.Parameters.Add("@USER_ID", SqlDbType.VarChar)
            cmd.Parameters("@USER_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@USER_ID").Value = pUserId

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pStatus

            cmd.Parameters.Add("@FOTO1", SqlDbType.Image)
            cmd.Parameters("@FOTO1").Direction = ParameterDirection.Input
            cmd.Parameters("@FOTO1").Value = pFoto1

            cmd.Parameters.Add("@FOTO2", SqlDbType.Image)
            cmd.Parameters("@FOTO2").Direction = ParameterDirection.Input
            cmd.Parameters("@FOTO2").Value = pFoto2

            cmd.Parameters.Add("@FOTO3", SqlDbType.Image)
            cmd.Parameters("@FOTO3").Direction = ParameterDirection.Input
            cmd.Parameters("@FOTO3").Value = pFoto3


            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 200)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_CREATE_ACUSE_RECIBO]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.ExecuteNonQuery()

            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString

            Return pResult = "OK"

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function UpdateStatusSapService(ByVal pDocId As Integer, ByVal pStatus As String,
                                            ByRef pResult As String, ByVal pEnvironmentName As String) As Boolean

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@ACUSE_DOC_ID", SqlDbType.Int)
            cmd.Parameters("@ACUSE_DOC_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@ACUSE_DOC_ID").Value = pDocId

            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar)
            cmd.Parameters("@STATUS").Direction = ParameterDirection.Input
            cmd.Parameters("@STATUS").Value = pStatus

            cmd.Parameters.Add("@pResult", SqlDbType.VarChar, 250)
            cmd.Parameters("@pResult").Direction = ParameterDirection.Output
            cmd.Parameters("@pResult").Value = ""

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_SAT_SERVICE_STATUS]"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            cmd.ExecuteNonQuery()

            sqldbConexion.Close()
            pResult = cmd.Parameters("@pRESULT").Value.ToString

            Return pResult = "OK"

        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Actualiza Estado tarea de recepcion.")>
    Public Function ActualizarEstadoTareaDeRecepcion(ByVal CodigoPoliza As String, ByVal LogIn As String,
                                ByVal Regimen As String, ByVal Estatus As String,
                                ByVal TaskId As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_REGISTER_RECEPTION_STATUS", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            'creamos todos los parametros del sp            
            sqlCmd.Parameters.Add(New SqlParameter("@pTRANS_TYPE", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@pLOGIN_ID", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@pCODIGO_POLIZA", SqlDbType.VarChar, 25))
            sqlCmd.Parameters.Add(New SqlParameter("@pTASK_ID", SqlDbType.Int))
            sqlCmd.Parameters.Add(New SqlParameter("@pSTATUS", SqlDbType.VarChar, 25))

            sqlCmd.Parameters("@pTRANS_TYPE").Value = If(Regimen = "FISCAL", "INGRESO_FISCAL", "INGRESO_GENERAL")
            sqlCmd.Parameters("@pLOGIN_ID").Value = LogIn
            sqlCmd.Parameters("@pCODIGO_POLIZA").Value = CodigoPoliza
            sqlCmd.Parameters("@pTASK_ID").Value = TaskId
            sqlCmd.Parameters("@pSTATUS").Value = Estatus
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try
    End Function


    <WebMethod(Description:="Realiza un rollback a la licencia.")>
    Public Function RollBackALicencia(ByVal LicenceId As Integer, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_ROLLBACK_LICENCE", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            'creamos todos los parametros del sp            
            sqlCmd.Parameters.Add(New SqlParameter("@LICENCE_ID", SqlDbType.Int))
            sqlCmd.Parameters("@LICENCE_ID").Value = LicenceId
            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try
    End Function

    <WebMethod(Description:="Explota un master pack y genera un ExplodeIn y un ExplodeOut.")>
    Public Function ExplodeMasterPack(ByVal LicenceId As Integer, ByVal MaterialId As String, ByVal LastUpdateBy As String, ByVal pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldb_conexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldb_conexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_EXPLODE_MASTER_PACK", sqldb_conexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            'creamos todos los parametros del sp            
            sqlCmd.Parameters.Add(New SqlParameter("@LICENSE_ID", SqlDbType.Int))
            sqlCmd.Parameters("@LICENSE_ID").Value = LicenceId

            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar))
            sqlCmd.Parameters("@MATERIAL_ID").Value = MaterialId

            sqlCmd.Parameters.Add(New SqlParameter("@LAST_UPDATE_BY ", SqlDbType.VarChar))
            sqlCmd.Parameters("@LAST_UPDATE_BY ").Value = LastUpdateBy

            If sqldb_conexion.State = ConnectionState.Closed Then sqldb_conexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldb_conexion.State = ConnectionState.Open Then sqldb_conexion.Close()
        End Try
    End Function

    <WebMethod(Description:="Obtiene el master pack de la licencia.")>
    Public Function GetMasterPackByLicense(licenceId As Integer, ByVal MaterialId As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand


            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENSE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENSE_ID").Value = licenceId


            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = MaterialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_GET_MASTER_PACK_BY_LICENSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("MasterPackByLicense")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Rows.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If

            pResult = "OK"
            Return miscDs

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Obtiene el detalle del master pack de la licencia.")>
    Public Function GetDetailMasterPackByLicense(licenceId As Integer, materialId As String, pEnvironmentName As String, ByRef pResult As String) As DataTable
        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LICENCE_ID", SqlDbType.Int)
            cmd.Parameters("@LICENCE_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@LICENCE_ID").Value = licenceId

            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar)
            cmd.Parameters("@MATERIAL_ID").Direction = ParameterDirection.Input
            cmd.Parameters("@MATERIAL_ID").Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_MASTER_PACK_DETAIL_BY_LICENCE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("DetailMasterPackByLicense")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                pResult = "ERROR," + ex.Message
                Return Nothing
            End Try

            If miscDs Is Nothing Or miscDs.Rows.Count <= 0 Then
                pResult = "No se encontró información"
                Return Nothing
            End If

            pResult = "OK"
            Return miscDs

        Catch ex As Exception
            pResult = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Explota un master pack y genera un ExplodeIn y un ExplodeOut.")>
    Public Function UpdateLocationTargerTask(wevePickingId As Integer, login As String, locationSpotTarget As String, pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_UPDATE_LOCATION_TARGER_TASK", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure

            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wevePickingId
            sqlCmd.Parameters.Add(New SqlParameter("@LOGIN ", SqlDbType.VarChar)).Value = login
            sqlCmd.Parameters.Add(New SqlParameter("@LOCATION_SPOT_TARGET ", SqlDbType.VarChar)).Value = locationSpotTarget

            If sqldbConexion.State = ConnectionState.Closed Then sqldbConexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldbConexion.State = ConnectionState.Open Then sqldbConexion.Close()
        End Try
    End Function

    <WebMethod(Description:="Cancelar una linea de picking detalle")>
    Public Function CancelPickingDetailLine(wavePickingId As Integer, login As String, materialId As String, pEnvironmentName As String, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_CANCEL_PICKING_DETAIL_LINE", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@LOGIN_ID ", SqlDbType.VarChar)).Value = login
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID ", SqlDbType.VarChar)).Value = materialId

            If sqldbConexion.State = ConnectionState.Closed Then sqldbConexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = "OK"
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldbConexion.State = ConnectionState.Open Then sqldbConexion.Close()
        End Try
    End Function

    <WebMethod(Description:="Registra la trancsaccion de re-abastecimiento")>
    Public Function RegisterTransReallocForReplenishment(login As String, materialId As String, materialBarcode As String, sourceLicence As Integer,
                                                         sourceLocation As String, qty As Decimal, wavePickingId As Integer, mt2 As Decimal, typeLocation As String,
                                                         targetLocation As String, pEnvironmentName As String, ByRef newLiceceId As Integer, ByRef pResult As String) As Boolean
        Dim sqldbConexion As SqlConnection
        Dim sqlCmd As SqlCommand

        sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            sqlCmd = New SqlCommand(DefaultSchema & "OP_WMS_SP_REGISTER_REALLOC_FOR_REPLENISHMENT ", sqldbConexion)
            sqlCmd.CommandType = CommandType.StoredProcedure
            sqlCmd.Parameters.Add(New SqlParameter("@LOGIN_ID", SqlDbType.VarChar, 25)).Value = login
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 50)).Value = materialId
            sqlCmd.Parameters.Add(New SqlParameter("@MATERIAL_BARCODE", SqlDbType.VarChar, 25)).Value = materialBarcode
            sqlCmd.Parameters.Add(New SqlParameter("@SOURCE_LICENSE", SqlDbType.Int)).Value = sourceLicence
            sqlCmd.Parameters.Add(New SqlParameter("@SOURCE_LOCATION", SqlDbType.VarChar, 25)).Value = sourceLocation
            sqlCmd.Parameters.Add(New SqlParameter("@QUANTITY_UNITS", SqlDbType.Decimal)).Value = qty
            sqlCmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            sqlCmd.Parameters.Add(New SqlParameter("@MT2", SqlDbType.Int)).Value = mt2
            sqlCmd.Parameters.Add(New SqlParameter("@TYPE_LOCATION", SqlDbType.VarChar, 25)).Value = typeLocation
            sqlCmd.Parameters.Add(New SqlParameter("@TARGET_LOCATION", SqlDbType.VarChar, 25)).Value = targetLocation
            sqlCmd.Parameters.Add(New SqlParameter("@NEW_LICENSE_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            sqlCmd.Parameters("@NEW_LICENSE_ID").Value = newLiceceId
            sqlCmd.Parameters.Add(New SqlParameter("@RESULT", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output


            If sqldbConexion.State = ConnectionState.Closed Then sqldbConexion.Open()
            sqlCmd.ExecuteNonQuery()
            pResult = sqlCmd.Parameters("@RESULT").Value
            newLiceceId = sqlCmd.Parameters("@NEW_LICENSE_ID").Value

            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            If sqldbConexion.State = ConnectionState.Open Then sqldbConexion.Close()
        End Try
    End Function


    <WebMethod(Description:="Registra la transaccion por una tarea de reubicacion por entrega no inmediata.")>
    Public Function RegisterTransRelocateForNoImmediatePicking(login As String, materialId As String, materialBarcode As String, sourceLicence As Integer,
                                                         sourceLocation As String, qty As Decimal, wavePickingId As Integer, mt2 As Decimal, typeLocation As String,
                                                         targetLocation As String, environmentName As String, ByRef newLicenseId As Integer, ByRef result As String) As Boolean
        Dim connection As SqlConnection = New SqlConnection(AppSettings(environmentName).ToString)
        Try
            Dim command As SqlCommand = New SqlCommand(DefaultSchema & "OP_WMS_SP_REGISTER_REALLOC_FOR_NO_IMMEDIATE_PICKING ", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(New SqlParameter("@LOGIN_ID", SqlDbType.VarChar, 25)).Value = login
            command.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 50)).Value = materialId
            command.Parameters.Add(New SqlParameter("@MATERIAL_BARCODE", SqlDbType.VarChar, 25)).Value = materialBarcode
            command.Parameters.Add(New SqlParameter("@SOURCE_LICENSE", SqlDbType.Int)).Value = sourceLicence
            command.Parameters.Add(New SqlParameter("@SOURCE_LOCATION", SqlDbType.VarChar, 25)).Value = sourceLocation
            command.Parameters.Add(New SqlParameter("@QUANTITY_UNITS", SqlDbType.Decimal)).Value = qty
            command.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            command.Parameters.Add(New SqlParameter("@MT2", SqlDbType.Int)).Value = mt2
            command.Parameters.Add(New SqlParameter("@TYPE_LOCATION", SqlDbType.VarChar, 25)).Value = typeLocation
            command.Parameters.Add(New SqlParameter("@TARGET_LOCATION", SqlDbType.VarChar, 25)).Value = targetLocation
            command.Parameters.Add(New SqlParameter("@NEW_LICENSE_ID", SqlDbType.Int)).Direction = ParameterDirection.InputOutput
            command.Parameters("@NEW_LICENSE_ID").Value = newLicenseId
            command.Parameters.Add(New SqlParameter("@RESULT", SqlDbType.VarChar, 500)).Direction = ParameterDirection.Output

            connection.Open()
            command.ExecuteNonQuery()
            result = command.Parameters("@RESULT").Value
            newLicenseId = command.Parameters("@NEW_LICENSE_ID").Value

            Return True
        Catch ex As Exception
            result = ex.Message
            Return False
        Finally
            connection.Close()
            connection.Dispose()
        End Try
    End Function

    <WebMethod(Description:="UpdateScannedSerialNumberToProcess")>
    Public Function UpdateScannedSerialNumberToProcess(serialNumber As String, licenseId As Integer, wavePickingId As Integer, materialId As String, login As String, taskType As String, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = serialNumber
            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId
            cmd.Parameters.Add("@STATUS", SqlDbType.Int).Value = 0
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@TASK_TYPE", SqlDbType.VarChar).Value = taskType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_SCANNED_SERIAL_NUMBER_TO_PROCESS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("UpdateScannedSerialNumberToProcess")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="UpdateSetActiveSerialNumber")>
    Public Function UpdateSetActiveSerialNumber(serialNumber As String, licenseId As Integer, materialId As String, wavePickingId As Integer, login As String, taskType As String, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@SERIAL_NUMBER", SqlDbType.VarChar).Value = serialNumber
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@TASK_TYPE", SqlDbType.VarChar).Value = taskType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_SET_ACTIVE_SERIAL_NUMBER]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("UpdateSetActiveSerialNumber")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="GetRequestedSerialNumberDiscretionalPickingByLicense")>
    Public Function GetRequestedSerialNumberDiscretionalPickingByLicense(wavePickingId As Integer, licenseId As Integer, materialId As String, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GET_REQUESTED_SERIAL_NUMBERS_DISCRETIONAL_PICKING_BY_LICENSE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("GetRequestedSerialNumberDiscretionalPickingByLicense")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="RollbackSerialNumbersOnProcess")>
    Public Function RollbackSerialNumbersOnProcess(wavePickingId As Integer, licenseId As Integer, materialId As String, login As String, taskType As String, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId
            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@TASK_TYPE", SqlDbType.VarChar).Value = taskType

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_ROLLBACK_SERIAL_NUMBERS_ON_PROCESS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("RollbackSerialNumbersOnProcess")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Valida si el ID del documento ingresado es correcto")>
    Public Function ValidateScannedReceptionDocument(document As String, login As String, ByRef pResult As String, environmentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@DOCUMENT", SqlDbType.VarChar, 100)).Value = document
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 25)).Value = login

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_VALIDATE_SCANNED_DOCUMENT_FOR_RECEPTION]"
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

    <WebMethod(Description:="Procesa el documento escaneado desde la HH para recepcion.")>
    Public Function ProcessScannedDocument(type As String, document As String, login As String, ByRef pResult As String, enviromentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(enviromentName).ToString)
        sqldbConexion.Open()
        dim transaction = sqldbConexion.BeginTransaction()
        Try
            
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")
            cmd.Transaction = transaction
            cmd.Parameters.Add(New SqlParameter("@MANIFEST_ID", SqlDbType.Int)).Value = document
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar, 50)).Value = login
            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_GENERATE_RECEPTION_DOCUMENT_FROM_CARGO_MANIFEST]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                transaction.Rollback()
                pResult = dt.Rows(0)("Mensaje").ToString()
                
                Return False
            End If
            pResult = dt.Rows(0)("DbData").ToString()
            
            transaction.Commit()
            Return True
        Catch ex As Exception
            transaction.Rollback()
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Inserta la informacion de una etiqueta generada en un picking.")>
    Public Function InsertPickingLabel(loginId As String, wavePickingId As Integer, clientCode As String,ByRef pResult As String, enviromentName As String) As String
        Dim sqldbConexion = New SqlConnection(AppSettings(enviromentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@LOGIN_ID", SqlDbType.VarChar, 25)).Value = loginId
            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePickingId
            cmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar, 50)).Value = clientCode

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_INSERT_PICKING_LABELS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return ""
            End If
            pResult = dt.Rows(0)("Mensaje").ToString()
            Return dt.Rows(0)("DbData").ToString()
        Catch ex As Exception
            pResult = ex.Message
            Return ""
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Inserta la informacion de una etiqueta generada en un picking.")>
    Public Function UpdatePickingLabel(labelId As Integer, clientCode As string, licenseId As Integer, barcode As string, qty As Decimal, codigoPoliza As string, sourceLocation As string, targetLocation As String, 
                                       transitLocation as string, serialNumber As String, wavePicking As integer, ByRef pResult As String, enviromentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(enviromentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@LABEL_ID", SqlDbType.Int)).Value = labelId
            cmd.Parameters.Add(New SqlParameter("@CLIENT_CODE", SqlDbType.VarChar)).Value = clientCode
            cmd.Parameters.Add(New SqlParameter("@LICENSE_ID", SqlDbType.Int)).Value = licenseId
            cmd.Parameters.Add(New SqlParameter("@BARCODE", SqlDbType.VarChar)).Value = barcode
            cmd.Parameters.Add(New SqlParameter("@QTY", SqlDbType.Decimal)).Value = qty
            cmd.Parameters.Add(New SqlParameter("@CODIGO_POLIZA", SqlDbType.VarChar)).Value = codigoPoliza
            cmd.Parameters.Add(New SqlParameter("@SOURCE_LOCATION", SqlDbType.VarChar)).Value = sourceLocation
            cmd.Parameters.Add(New SqlParameter("@TARGET_LOCATION", SqlDbType.VarChar)).Value = targetLocation
            cmd.Parameters.Add(New SqlParameter("@TRANSIT_LOCATION", SqlDbType.VarChar)).Value = transitLocation
            cmd.Parameters.Add(New SqlParameter("@SERIAL_NUMBER", SqlDbType.VarChar)).Value = serialNumber
            cmd.Parameters.Add(New SqlParameter("@WAVE_PICKING_ID", SqlDbType.Int)).Value = wavePicking

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_PICKING_LABEL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return False
            End If
            pResult = dt.Rows(0)("Mensaje").ToString()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

     <WebMethod(Description:="Inserta la informacion de una etiqueta generada en un picking.")>
    Public Function DeletePickingLabel(labelId As Integer, ByRef pResult As String, enviromentName As String) As Boolean
        Dim sqldbConexion = New SqlConnection(AppSettings(enviromentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand
            Dim reader As SqlDataReader
            Dim dt = New DataTable("Operacion")

            cmd.Parameters.Add(New SqlParameter("@LABEL_ID", SqlDbType.Int)).Value = labelId           

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_DELETE_PICKING_LABEL]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            reader = cmd.ExecuteReader()

            dt.Load(reader)

            If dt.Rows(0)("Resultado") = -1 Then
                pResult = dt.Rows(0)("Mensaje").ToString()
                Return False
            End If
            pResult = dt.Rows(0)("Mensaje").ToString()
            Return True
        Catch ex As Exception
            pResult = ex.Message
            Return False
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

     <WebMethod(Description:="Valida si la licencia se puede utilizar para un picking")>
    Public Function ValidateIfPickingLicenseIsAvailable(wavePickingId As Integer, currentLocation As string, materialId As String, licenseId As Integer, login as string,ByRef result As String, pEnvironmentName As String) As DataTable

        Dim sqldbConexion As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()

        Try

            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@WAVE_PICKING_ID", SqlDbType.Int).Value = wavePickingId
            cmd.Parameters.Add("@CURRENT_LOCATION", SqlDbType.VarChar).Value = currentLocation
            cmd.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId
            if licenseId > 0 Then
                cmd.Parameters.Add("@LICENSE_ID", SqlDbType.Int).Value = licenseId    
            End If
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login

            cmd.CommandText = DefaultSchema & "OP_WMS_SP_VALIDATE_IF_PICKING_LICENSE_IS_AVAILABLE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion
            Dim miscDa As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim miscDt As DataTable = New DataTable("ValidateIfPickingLicenseIsAvailable")

            Try
                miscDa.Fill(miscDt)
                Return miscDt
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function
    
    <WebMethod(Description:="Consolida los productos de una ubicacion por material, lote y tono y calibre")>
    Public Function ObtenerMaterialesEnUnbicacionParaUnificar(currentLocation As string, materialId As String, ByRef result As String, pEnvironmentName As String) As DataSet
        Dim connection As SqlConnection = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        Try
            connection.Open()
            Dim command As New SqlCommand

            command.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = currentLocation
            command.Parameters.Add("@MATERIAL_ID", SqlDbType.VarChar).Value = materialId

            command.CommandText = DefaultSchema & "OP_WMS_SP_GET_MATERIAL_FOR_NEW_LICENSE_IN_LOCATION_MERGE"
            command.CommandType = CommandType.StoredProcedure
            command.Connection = connection
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(command)
            Dim dataSet As DataSet = New DataSet()

            Try
                adapter.Fill(dataSet)
                dataSet.Relations.Add("LICENCIA_A_MATERIAL", dataSet.Tables(0).Columns("LICENSE_ID"), dataSet.Tables(1).Columns("LICENSE_ID"), False)

                Dim parentColumns As DataColumn() = Nothing
                Dim childColumns As DataColumn() = Nothing
                parentColumns = New DataColumn() _
                {dataSet.Tables(1).Columns("LICENSE_ID"), dataSet.Tables(1).Columns("MATERIAL_ID")}
                childColumns = New DataColumn() _
                {dataSet.Tables(2).Columns("LICENSE_ID"), dataSet.Tables(2).Columns("MATERIAL_ID")}

                dataSet.Relations.Add("INFORMACION_MATERIAL", parentColumns, childColumns, False)

                result = "OK"
                Return dataSet
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            connection.Close()
            connection.Dispose()
            connection = Nothing
        End Try
    End Function

    <WebMethod(Description:="Unifica las licencias por ubicacion y material")>
    Public Function UnificarLicenciasPorUbicacionYMaterial(currentLocation As String, materialId As String, login As String, ByRef result As String, pEnvironmentName As String) As DataSet
        Dim sqldbConexion = New SqlConnection(AppSettings(pEnvironmentName).ToString)
        sqldbConexion.Open()
        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add(New SqlParameter("@LOCATION", SqlDbType.VarChar, 25)).Value = currentLocation
            If Not String.IsNullOrEmpty(materialId) Then
                cmd.Parameters.Add(New SqlParameter("@MATERIAL_ID", SqlDbType.VarChar, 50)).Value = materialId
            End If
            cmd.Parameters.Add(New SqlParameter("@LOGIN", SqlDbType.VarChar)).Value = login

            cmd.CommandText = DefaultSchema + "OP_WMS_SP_MERGE_LICENSE_IN_LOCATION"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataSet()
            miscDa.Fill(miscDs)

            For i = 0 To 3
                Try
                    If miscDs.Tables(i).Rows(0)("Resultado") = -1 Then
                        result = miscDs.Tables(i).Rows(0)("Mensaje").ToString()
                        Return Nothing
                    End If
                Catch ex As Exception
                    Continue For
                End Try
            Next


            result = "OK"

            miscDs.Relations.Add("LICENCIA_A_MATERIAL", miscDS.Tables(0).Columns("LICENSE_ID"), miscDS.Tables(1).Columns("LICENSE_ID"), False)

            Dim parentColumns As DataColumn() = Nothing
            Dim childColumns As DataColumn() = Nothing
            parentColumns = New DataColumn() _
                {miscDS.Tables(1).Columns("LICENSE_ID"), miscDS.Tables(1).Columns("MATERIAL_ID")}
            childColumns = New DataColumn() _
                {miscDS.Tables(2).Columns("LICENSE_ID"), miscDS.Tables(2).Columns("MATERIAL_ID")}

            miscDs.Relations.Add("INFORMACION_MATERIAL", parentColumns, childColumns, False)

            Return miscDs
        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
        End Try
    End Function

    <WebMethod(Description:="Actualizar Demanda de Despacho y Orden de Entrega en ERP")>
    Public Function UpdateDeliveryNoteERP(passId As Integer, status As String, login As String, environmentName As String, ByRef result As String) As DataTable
        Dim rst As String = ""
        Dim DocEntryTable = GetDraftDocEntry(passId, environmentName, rst)
        Dim DocEntryEcommerceTable = GetSODocEntry(passId, environmentName, rst)
        Dim DocNum = 0
        Dim CompletedWhitErrors = 0
        Dim PostedWhitError = New DataTable

        If (DocEntryTable.Rows.Count > 0) Then

            For i As Integer = 0 To DocEntryTable.Rows.Count - 1
                Dim DocEntry As String = DocEntryTable.Rows(i)(0)

                If Not String.IsNullOrEmpty(DocEntry) Then
                    Dim webClient As New System.Net.WebClient
                    Dim response As String = webClient.DownloadString(AppSettings("SAPBOAPI") + "/CloseDraft/" + DocEntry)

                    If response.Contains("Error") Then
                        result = "ERROR, (" + AppSettings("SAPBOAPI") + "/CloseDraft/" + DocEntry + ") ; " + response
                        CompletedWhitErrors = -1
                        PostedWhitError = MarkWavePickingAsFailed(DocEntry, environmentName, login, response, rst)
                    Else
                        DocNum = response
                    End If
                End If
            Next
        End If

        If (DocEntryEcommerceTable.Rows.Count > 0) Then

            For i As Integer = 0 To DocEntryEcommerceTable.Rows.Count - 1
                Dim DocEntry As String = DocEntryEcommerceTable.Rows(i)(0)

                If Not String.IsNullOrEmpty(DocEntry) Then
                    Dim webClient As New System.Net.WebClient
                    Dim response As String = webClient.DownloadString(AppSettings("SAPBOAPI") + "/ChangeStatusEcomm1/" + DocEntry + "/2")

                    If response.Contains("Error") Then
                        result = "ERRROR, (" + AppSettings("SAPBOAPI") + "/ChangeStatusEcomm1/" + DocEntry + "/2) ; " + response
                        CompletedWhitErrors = -1
                        PostedWhitError = MarkWavePickingAsFailed(DocEntry, environmentName, login, response, rst)
                    Else
                        DocNum = response
                    End If
                End If
            Next

        End If

        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@PASS_ID", SqlDbType.Int).Value = passId
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = status
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = login
            cmd.Parameters.Add("@ERP_REF", SqlDbType.VarChar).Value = DocNum
            cmd.Parameters.Add("@ATTEMPED_WHIT_ERROR", SqlDbType.Int).Value = CompletedWhitErrors

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_UPDATE_STATUS_BY_EXIT_PASS]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("UpdateDeliveryNoteReturn")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Get Draft DocEntry Reference by PassID")>
    Public Function GetDraftDocEntry(passId As Integer, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@PASS_ID", SqlDbType.Int).Value = passId

            cmd.CommandText = DefaultSchema + "[GETDRAFTDOCENTRY_BY_PASS_ID]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("DraftDocEntry")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Get SO DocEntry by pass id for ecommerce")>
    Public Function GetSODocEntry(passId As Integer, environmentName As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@PASS_ID", SqlDbType.Int).Value = passId

            cmd.CommandText = DefaultSchema + "[GETSODOCENTRY_BY_PASS_ID_ECOMMERCE]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("SalesOrderDocEntry")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function

    <WebMethod(Description:="Get Draft DocEntry Reference by PassID")>
    Public Function MarkWavePickingAsFailed(docEntry As Integer, environmentName As String, loginId As String, response As String, ByRef result As String) As DataTable
        Dim sqldbConexion = New SqlConnection(AppSettings(environmentName).ToString)
        sqldbConexion.Open()

        Try
            Dim cmd As New SqlCommand

            cmd.Parameters.Add("@DOC_ENTRY", SqlDbType.Int).Value = docEntry
            cmd.Parameters.Add("@SAP_ERROR", SqlDbType.VarChar).Value = response
            cmd.Parameters.Add("@LOGIN_ID", SqlDbType.VarChar).Value = loginId

            cmd.CommandText = DefaultSchema + "[OP_WMS_SP_MARK_PICKING_WHIT_ERROR]"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = sqldbConexion

            Dim miscDa = New SqlDataAdapter(cmd)
            Dim miscDs = New DataTable("MarkWhitErrorResponse")

            Try
                miscDa.Fill(miscDs)
            Catch ex As Exception
                result = "ERROR," + ex.Message
                Return Nothing
            End Try

            result = ""
            Return miscDs

        Catch ex As Exception
            result = ex.Message
            Return Nothing
        Finally
            sqldbConexion.Close()
            sqldbConexion.Dispose()
            sqldbConexion = Nothing
        End Try
    End Function
End Class