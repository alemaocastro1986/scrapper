Imports Scrapper.Utils

Module Program

    Sub Main()

        Try
            OpenSap()

            Dim App As New SapGui()
            With App
                .Build()
                .MoveFiles("")
            End With


        Catch ex As Exception
            Using sw As IO.StreamWriter = New IO.StreamWriter(My.Computer.FileSystem.SpecialDirectories.Desktop & "/logs.txt")

                sw.WriteLine(ex.Message)
                sw.WriteLine(ex.StackTrace)
                sw.WriteLine(ex.Source)

            End Using

            If ex.Message = "Não é possível criar componente ActiveX." Then OpenSap()

        End Try
    End Sub

End Module
