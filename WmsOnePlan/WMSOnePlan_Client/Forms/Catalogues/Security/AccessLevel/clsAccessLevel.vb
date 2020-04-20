﻿Imports System.ComponentModel
Public Class clsAccessLevel
    Public _ROLE_ID As String
    Public _ROLE_NAME As String
    Public _ROLE_DESCRIPTION As String
    <Category("Datos Generales"), Description("Codigo identificador del punto de control maximo 25 caracteres")> _
       Public Property Codigo() As String
        Get
            Return _ROLE_ID
        End Get
        Set(ByVal Value As String)
            _ROLE_ID = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Descripcion del punto de control maximo 50 caracteres")> _
       Public Property Nombre() As String
        Get
            Return _ROLE_NAME
        End Get
        Set(ByVal Value As String)
            _ROLE_NAME = Value
        End Set
    End Property
    <Category("Datos Generales"), Description("Descripcion del punto de control maximo 150 caracteres")> _
       Public Property Descripcion() As String
        Get
            Return _ROLE_DESCRIPTION
        End Get
        Set(ByVal Value As String)
            _ROLE_DESCRIPTION = Value
        End Set
    End Property

    Public Function Grabar(ByRef pResult As String) As Boolean
        Dim pLocalResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            xserv.SearchByKeyAccessLevel(Codigo, pLocalResult, PublicLoginInfo.Environment)
            If pLocalResult = "OK" Then 'Update the record
                If xserv.UpdateAccessLevel(Codigo, Nombre, Descripcion, pLocalResult, PublicLoginInfo.Environment) Then
                    Return True
                Else
                    pResult = pLocalResult
                    Return False
                End If
            Else 'Add new record
                If xserv.CreateAccessLevel(Codigo, Nombre, Descripcion, pLocalResult, PublicLoginInfo.Environment) Then
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
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            If xserv.DeleteAccessLevel(Codigo, pLocalResult, PublicLoginInfo.Environment) Then
                Return True
            Else
                pResult = pLocalResult
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

End Class
