Public Class ReaderAndWriter
    Public list As List(Of String)

    Public Sub New()
        Me.list = New List(Of String)
    End Sub

    Public Sub Reader(fromPAth As String)
        Dim fluxoTexto As IO.StreamReader
        Dim linhaTexto As String

        If IO.File.Exists(fromPAth) Then

            fluxoTexto = New IO.StreamReader(fromPAth)


            While Not fluxoTexto.EndOfStream()
                linhaTexto = fluxoTexto.ReadLine()

                list.Add(Trim(linhaTexto))

            End While

            fluxoTexto.Close()
        Else
            Throw New IO.FileNotFoundException("Arquivo não encontrado")

        End If
    End Sub

    Public Sub Writer(toPath As String)
        Using sw As IO.StreamWriter = New IO.StreamWriter(toPath)
            For Each data As String In list
                sw.WriteLine(data)
            Next
        End Using
    End Sub
End Class
