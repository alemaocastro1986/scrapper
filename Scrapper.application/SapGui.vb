Imports System.IO
Imports Scrapper.Utils

Public Class SapGui
    Private defaultPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Files"

    Private GuiAuto As Object
    Private GUIapp As Object
    Private GUIcnn As Object
    Private GUIses As Object

    Public Sub New()
        GuiAuto = GetObject("SAPGUI")
        GUIapp = GuiAuto.GetScriptingEngine
        GUIcnn = GUIapp.Children(0)
        GUIses = GUIcnn.Children(0)


        Me.Bootstrap()


    End Sub


    Private Sub Bootstrap()
        If Not Directory.Exists(defaultPath) Then
            Directory.CreateDirectory(defaultPath)
            Console.WriteLine("App - Create a folders")
        End If

    End Sub

    Public Sub Build()
        Console.WriteLine("[App] - Start | {0}", Now)

        Dim LoadFactory = New LoadFactory().ForFactory(GUIses)
        Dim ScheduleFactory = New ScheduleFactory().ForFactory(GUIses)
        Dim TransportFactory = New TransportsFactory().ForFactory(GUIses)
        Dim ProducsFactory = New ProductsFactory().ForFactory(GUIses)

    End Sub

    Public Sub MoveFiles(toPath As String)
        Dim files() As String
        files = Directory.GetFiles(defaultPath, "*.csv", SearchOption.TopDirectoryOnly)

        For Each FileName As String In files
            Dim destination As String = String.Concat("C:\Users\CUNHACA\OneDrive - gpssa.com.br\basf\", Path.GetFileName(FileName))
            Dim rw As New ReaderAndWriter()

            rw.Reader(FileName)
            rw.Writer(destination)

            rw = Nothing
            Console.WriteLine("[App] - Move File {0} | {1}", destination, Now)

        Next
        Console.WriteLine("[App] - Done | {0}", Now)
        Clock.Sleep(10)
    End Sub
End Class
