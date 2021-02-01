Imports System.IO

Public Class TxtToCsv
    Public FilePath As String
    Private DataArray As ArrayList

    Public HasHeader As Boolean

    Public Sub New()
        Me.HasHeader = True
    End Sub

    Public Sub New(filePath As String, Optional hasHeader As Boolean = True)
        Me.FilePath = filePath
        Me.DataArray = New ArrayList()
        Me.HasHeader = hasHeader
        Me.ReadFile()
    End Sub
    Private Sub ReadFile()
        Dim fluxoTexto As IO.StreamReader
        Dim linhaTexto As String

        If IO.File.Exists(Me.FilePath) Then

            fluxoTexto = New IO.StreamReader(Me.FilePath)


            While Not fluxoTexto.EndOfStream()
                linhaTexto = fluxoTexto.ReadLine()

                DataArray.Add(Trim(linhaTexto))

            End While

            fluxoTexto.Close()
        Else
            Throw New IO.FileNotFoundException("Arquivo não encontrado")
        End If

    End Sub
    Public Function RemoveLineWithIndex(lines As Array) As TxtToCsv

        For x = 0 To lines.Length - 1
            Dim inv = lines.Length - 1 - x
            Me.DataArray.RemoveAt(CInt(lines(inv)))
        Next
        Return Me
    End Function
    Public Function RemoveLineWithText(lines As Array) As TxtToCsv

        For x = 0 To lines.Length - 1
            If DataArray.Contains(Trim(lines(x))) Then
                Dim index = Me.DataArray.IndexOf(lines(x))
                Me.DataArray.RemoveAt(index)
            End If
        Next

        Return Me
    End Function
    Public Function AddHeader(header As String) As TxtToCsv

        Me.DataArray.Insert(0, header)

        Return Me
    End Function
    Public Function RemoveHeader() As TxtToCsv

        Me.DataArray.RemoveAt(0)

        Return Me
    End Function
    Public Function ReplaceDelimiter(Optional delimiter As String = ";") As TxtToCsv

        For x = 0 To Me.DataArray.Count() - 1
            Dim titles() = Split(Me.DataArray(x), delimiter)
            Dim title As String = ""
            For i = 0 To UBound(titles)

                If i < UBound(titles) Then title += Trim(titles(i)) & ";"
                If i >= UBound(titles) Then title += Trim(titles(i))

            Next i

            Me.DataArray(x) = Right(Left(title, Len(title) - 1), Len(Left(title, Len(title) - 1)) - 1)
        Next

        Return Me
    End Function
    Public Function RemoveLast(Optional rows As Integer = 1) As TxtToCsv

        For x = 1 To rows
            Dim index = Me.DataArray.Count() - x
            Me.DataArray.RemoveAt(index)
        Next

        Return Me
    End Function
    Public Function DataToCSV(destination As String, Optional append As Boolean = False) As TxtToCsv

        Using sw As IO.StreamWriter = New IO.StreamWriter(destination, append)
            For x = 0 To Me.DataArray.Count() - 1
                sw.WriteLine(DataArray(x))
            Next x
        End Using

        Return Me
    End Function
    Public Sub PrintData(Optional numberOfRows = 0)
        For x = 0 To Me.DataArray.Count() - 1
            If Len(Trim(Me.DataArray(x))) > 0 Then
                Console.WriteLine(DataArray(x))
            End If
            If numberOfRows > 0 And x = numberOfRows Then Exit For
        Next
    End Sub

    Public Function GetListDataOfColumn(filePath As String, coll As Integer) As List(Of String)
        Dim list As New List(Of String)

        ' Create new StreamReader instance with Using block.
        Using r As StreamReader = New StreamReader(filePath)
            Dim line As String

            ' Read first line.
            line = r.ReadLine

            ' Loop over each line in file, While list is Not Nothing.
            Do While (Not line Is Nothing)
                ' Add this line to list.
                Dim values() = Split(line, ";")
                Dim value As String = CType(values(coll), String)
                list.Add(value)

                line = r.ReadLine
            Loop
        End Using

        Return list
    End Function

End Class
