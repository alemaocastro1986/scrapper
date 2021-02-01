Imports Scrapper.Utils

Module SapGuiHelpers
    Public Function IsOpen(Optional processName As String = "saplogon.exe") As Boolean

        Dim oServ As Object
        Dim cProc
        Dim oProc As Object
        Dim active As Boolean

        oServ = GetObject("winmgmts:")
        cProc = oServ.ExecQuery("Select * from Win32_Process")

        active = False

        For Each oProc In cProc
            If oProc.Name = processName Then
                active = True
            End If
        Next

        Return active

    End Function

    Public Function IsRunnung() As Boolean
        Dim SAPguiAuto As Object
        Dim SAPguiApp
        Dim SAPguiCnn As Object



        Dim running As Boolean

        running = False

        On Error Resume Next
        SAPguiAuto = GetObject("SAPGUI")
        If Err.Number <> 0 Then
            Console.WriteLine("SAPgui Object not found")

            On Error GoTo 0
        Else
            On Error GoTo 0
            SAPguiApp = SAPguiAuto.GetScriptingEngine

            If SAPguiApp.Connections.Count() > 0 Then running = True

        End If

        Return running

    End Function

    Public Sub StartSap()

        Dim SAPGUIPath As String = "C:\Program Files (x86)\SAP\FrontEnd\SAPgui"
        Dim SAPGUIexe As String = "sapgui.exe"
        Dim connString As String = "Cobalt - Z2L (Prod)"
        Dim SAPGUIfullpath As String = String.Format("{0}\{1} ""{2}""", SAPGUIPath, SAPGUIexe, connString)


        Shell(SAPGUIfullpath, AppWinStyle.NormalFocus)
    End Sub

    Public Sub CreateConection()

        Dim SAPguiAuto As Object
        Dim SAPguiApp As Object

        Dim connString As String = "Cobalt - Z2L (Prod)"

        SAPguiAuto = GetObject("SAPGUI")
        SAPguiApp = SAPguiAuto.GetScriptingEngine

        SAPguiApp.OpenConnection(connString)

    End Sub

    Sub OpenSap()
        Console.WriteLine("========================================================================================")
        Dim isCall
        Dim isRun
        isCall = False
        Do While Not IsOpen()
            If Not isCall Then
                StartSap()
                isCall = True
            End If
            Clock.Sleep(5)
        Loop
        isRun = False
        Do While Not IsRunnung()
            If Not isRun Then
                CreateConection()
                isRun = True
            End If
            Clock.Sleep(5)
        Loop
        Clock.Sleep(20)
        Console.WriteLine("========================================================================================")
    End Sub
End Module
