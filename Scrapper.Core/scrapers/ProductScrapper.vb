Imports System.IO

Public Class ProductScrapper : Implements IScraper(Of ProductScraperDTO)
    Private GuiSession As Object
    Private FileManager As FileManager

    Public Sub New(guiGuiSession As Object, file As FileManager)
        Me.GuiSession = guiGuiSession
        Me.FileManager = file
    End Sub

    Public Sub Scrape(args As ProductScraperDTO) Implements IScraper(Of ProductScraperDTO).Scrape
        Dim materialList As New List(Of Material)

        GuiSession.SendCommand("/nlt22")

        GuiSession.FindById("wnd[0]").sendVKey(0)
        GuiSession.FindById("wnd[0]/usr/radT3_ALLTA").select
        GuiSession.FindById("wnd[0]/usr/chkT3_SEVON").selected = False
        GuiSession.FindById("wnd[0]/usr/chkT3_SENAC").selected = True
        GuiSession.FindById("wnd[0]/usr/ctxtT3_LGNUM").text = "BD1"
        GuiSession.FindById("wnd[0]/usr/ctxtT3_LGTYP-LOW").text = "916"
        GuiSession.FindById("wnd[0]/usr/ctxtLISTV").text = "IN-HAUS-SMP"

        GuiSession.FindById("wnd[0]/usr/btn%_T3_LGPLA_%_APP_%-VALU_PUSH").press

        Dim y As Integer = 1
        args.remittances.Sort()

        Dim strClip As String = ""
        For Each transp As String In args.remittances
            strClip += transp + vbNewLine
        Next

        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(strClip)


        GuiSession.FindById("wnd[1]/tbar[0]/btn[24]").press
        GuiSession.FindById("wnd[1]/tbar[0]/btn[8]").press

        GuiSession.FindById("wnd[0]/tbar[1]/btn[8]").press

        If File.Exists(Me.FileManager.GetOrigin()) Then

            File.Delete(Me.FileManager.GetOrigin())

        End If

        GuiSession.findById("wnd[0]/mbar/menu[0]/menu[1]/menu[2]").select
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").text = Me.FileManager.OriginPath
        GuiSession.findById("wnd[1]/usr/ctxtDY_FILENAME").text = Me.FileManager.OriginName
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").setFocus
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").caretPosition = 26
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
    End Sub
End Class
