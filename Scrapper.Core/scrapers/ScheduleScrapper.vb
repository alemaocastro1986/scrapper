Imports System.IO
Imports Scrapper.Utils

Public Class ScheduleScrapper : Implements IScraper(Of ScheduleScraperDTO)
    Private GuiSession As Object
    Private FileManager As FileManager

    Public Sub New(guiSession As Object, file As FileManager)
        Me.GuiSession = guiSession
        Me.FileManager = file
    End Sub

    Public Sub Scrape(args As ScheduleScraperDTO) Implements IScraper(Of ScheduleScraperDTO).Scrape
        Dim transportList As List(Of String)
        transportList = args.transports

        GuiSession.SendCommand("/nzbr_wmrf_monitrans")
        GuiSession.FindById("wnd[0]/usr/ctxtP_TPLST").text = args.Site
        GuiSession.FindById("wnd[0]/usr/ctxtS_DATUM-LOW").text = DateFormat.DateSap(DateFormat.DateSubDay(args.StartDate, 1))
        GuiSession.FindById("wnd[0]/usr/ctxtS_DATUM-HIGH").text = DateFormat.DateSap(DateAdd("d", 1, args.EndDate))
        GuiSession.FindById("wnd[0]/usr/ctxtS_UPREG-LOW").text = "00:00:00"
        GuiSession.FindById("wnd[0]/usr/ctxtS_UPREG-HIGH").text = "23:59:59"
        GuiSession.FindById("wnd[0]/usr/ctxtS_UPREG-HIGH").setFocus
        GuiSession.FindById("wnd[0]/usr/ctxtS_UPREG-HIGH").caretPosition = 8


        GuiSession.findById("wnd[0]/usr/btn%_S_TKNUM_%_APP_%-VALU_PUSH").press

        Dim y As Integer = 1
        transportList.Sort()

        Dim strClip As String = ""
        For Each transp As String In transportList
            strClip += transp + vbNewLine
        Next


        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(strClip)

        GuiSession.findById("wnd[1]/tbar[0]/btn[24]").press
        GuiSession.findById("wnd[1]/tbar[0]/btn[8]").press



        GuiSession.FindById("wnd[0]/tbar[1]/btn[8]").press

        GuiSession.FindById("wnd[0]/tbar[1]/btn[32]").press
        GuiSession.FindById("wnd[1]/usr/tabsG_TS_ALV/tabpALV_M_R1/ssubSUB_DYN0510:SAPLSKBH:0620/cntlCONTAINER2_LAYO/shellcont/shell").currentCellRow = 19
        GuiSession.FindById("wnd[1]/usr/tabsG_TS_ALV/tabpALV_M_R1/ssubSUB_DYN0510:SAPLSKBH:0620/cntlCONTAINER2_LAYO/shellcont/shell").firstVisibleRow = 8
        GuiSession.FindById("wnd[1]/usr/tabsG_TS_ALV/tabpALV_M_R1/ssubSUB_DYN0510:SAPLSKBH:0620/cntlCONTAINER2_LAYO/shellcont/shell").selectedRows = "4,6,7,8,9,10,11,12,13,14,15,16,17,18,19"
        GuiSession.FindById("wnd[1]/usr/tabsG_TS_ALV/tabpALV_M_R1/ssubSUB_DYN0510:SAPLSKBH:0620/btnAPP_FL_SING").press
        GuiSession.FindById("wnd[1]/tbar[0]/btn[0]").press

        If File.Exists(Me.FileManager.GetOrigin()) Then
            File.Delete(Me.FileManager.GetOrigin())
        End If

        GuiSession.findById("wnd[0]/mbar/menu[0]/menu[3]/menu[2]").select
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").setFocus
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").caretPosition = 39
        GuiSession.findById("wnd[1]").sendVKey(4)
        GuiSession.findById("wnd[2]/usr/ctxtDY_PATH").setFocus
        GuiSession.findById("wnd[2]/usr/ctxtDY_PATH").caretPosition = 0
        GuiSession.findById("wnd[2]").sendVKey(4)
        GuiSession.findById("wnd[3]/usr/ctxtDY_PATH").text = Me.FileManager.OriginPath
        GuiSession.findById("wnd[3]/usr/ctxtDY_FILENAME").text = Me.FileManager.OriginName
        GuiSession.findById("wnd[3]/usr/ctxtDY_FILENAME").caretPosition = 9
        GuiSession.findById("wnd[3]/tbar[0]/btn[0]").press
        GuiSession.findById("wnd[2]/tbar[0]/btn[0]").press
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
    End Sub
End Class
