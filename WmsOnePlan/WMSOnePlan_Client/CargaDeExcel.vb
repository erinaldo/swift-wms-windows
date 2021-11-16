Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic


Module CargaDeExcel

    Sub cargarExcel(ByVal tabla As DataGridView)
        Dim dialogFile As New OpenFileDialog  'PARA ABRIR UN NUEVO CUADRO DE DIALOGO'
        Dim sheet As String = ""  'ALMACENA EL NOMBRE DE LA HOJA '

        'CONFIGURACION DEL CUADRO DE DIALOGO'
        With dialogFile
            .Filter = "Excel Files | *.xlsx" 'filtra archivos excel'
            .Title = "Abrir Archivo"
            .ShowDialog() 'para visualizar el cuadro de dialogo'
        End With

        Dim path As String = dialogFile.FileName.ToString 'para almacenar path del archivo'

        If path <> "" Then
            'VARIABLES PARA REALIZAR LA CONEXION Y CARGA DEL ARCHIVO EXCEL'
            Dim dSet As New DataSet
            Dim adapter As New OleDbDataAdapter
            Dim data As New DataTable
            Dim connect As New OleDbConnection

            sheet = InputBox("Ingrese el numero de la hoja que importara", "complete")
            'GENERANDO NUEVA CONEXION'
            connect = New OleDbConnection(
                        "Provider=Microsoft.ACE.OLEDB.12.0;" &
                        "data source=" & path & "; " &
                        "Extended Properties= 'Excel 12.0 Xml;HDR=yes'")

            Try  'SELECCIONAR TODA LA INFORMACION DENTRO DE LA HOJA DE EXCEL'
                adapter = New OleDbDataAdapter("SELECTED * FROM [" & path & "]", connect)

                connect.Open()
                adapter.Fill(dSet, "MyData")
                data = dSet.Tables("MyData")
                tabla.DataSource = dSet
                tabla.DataMember = "MyData"
            Catch ex As Exception
                MsgBox("La hoja que desea importar no existe", MsgBoxStyle.Information, "Informacion")
            Finally
                connect.Close()
            End Try
        End If

    End Sub

End Module
