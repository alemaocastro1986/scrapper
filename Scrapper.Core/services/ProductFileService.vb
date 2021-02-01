Imports Scrapper.Utils

Public Class ProductFileService : Implements IFileService
    Private _txtToCsv As TxtToCsv
    Private _fileManager As FileManager

    Public Sub New(txtToCsv As TxtToCsv, fileManager As FileManager)
        _txtToCsv = txtToCsv
        _fileManager = fileManager
    End Sub
    Public Function Generate() As Boolean Implements IFileService.Generate
        Dim status As Boolean = False
        Try
            Dim rmLines() = {0, 1, 2, 4}

            With Me._txtToCsv
                .RemoveLineWithIndex(rmLines)
                .RemoveLast()
                .ReplaceDelimiter("|")
                .DataToCSV(_fileManager.GetDestination())
            End With
            status = True
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
        Return status
    End Function
End Class
