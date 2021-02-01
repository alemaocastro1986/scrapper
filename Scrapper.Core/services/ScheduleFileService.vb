Imports Scrapper.Utils

Public Class ScheduleFileService : Implements IFileService
    Private _txtToCsv As TxtToCsv
    Private _fileManager As FileManager

    Public Sub New(txtToCsv As TxtToCsv, fileManager As FileManager)
        _txtToCsv = txtToCsv
        _fileManager = fileManager
    End Sub

    Public Function Generate() As Boolean Implements IFileService.Generate
        Dim status As Boolean = False

        Try
            Dim rmLines() = {0, 1, 2, 3, 4}

            With Me._txtToCsv
                .RemoveLineWithIndex(rmLines)
                .RemoveLast()
                .ReplaceDelimiter("|")
            End With

            If Not Me._fileManager.Append Then
                Me._txtToCsv.AddHeader("trasporte;dataProgramada;horaProgramda;Transportadora;TipoTransporte")
            Else
                'Me._txtToCsv.RemoveHeader()
                Me._txtToCsv.HasHeader = False
            End If

            If _fileManager.CanExport Then Me._txtToCsv.DataToCSV(Me._fileManager.GetDestination(), Me._fileManager.Append)
            status = True

            'TODO: Ajustar logs
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

        Return status
    End Function


End Class
