Imports System.IO

Public Class Transportcrapper : Implements IScraper(Of TransportScraperDTO)
    Private GuiSession As Object
    Private FileManager As FileManager

    Public Sub New(guiSession As Object, file As FileManager)
        Me.GuiSession = guiSession
        Me.FileManager = file
    End Sub

    Public Sub Scrape(args As TransportScraperDTO) Implements IScraper(Of TransportScraperDTO).Scrape

        Dim transportList As List(Of String)
        transportList = args.Transports

        GuiSession.SendCommand("/nVL06O")

        GuiSession.FindById("wnd[0]/usr/btnBUTTON6").press

        GuiSession.FindById("wnd[0]/usr/ctxtIT_VKORG-LOW").text = "BR01"

        'GuiSession.findById("wnd[0]/usr/btn%_IF_VSTEL_%_APP_%-VALU_PUSH").press
        'For Each site As String In args.Sites
        '    GuiSession.findById("wnd[1]/usr/tabsTAB_STRIP/tabpSIVA/ssubSCREEN_HEADER:SAPLALDB:3010/tblSAPLALDBSINGLE/ctxtRSCSEL_255-SLOW_I[1," & args.Sites.IndexOf(site) & "]").text = site.ToUpper()
        'Next
        'GuiSession.findById("wnd[1]/tbar[0]/btn[8]").press

        GuiSession.FindById("wnd[0]/usr/ctxtIT_WADAT-LOW").text = ""
        GuiSession.FindById("wnd[0]/usr/ctxtIT_WADAT-HIGH").text = ""


        GuiSession.FindById("wnd[0]/usr/btn%_IT_TKNUM_%_APP_%-VALU_PUSH").press
        Dim y As Integer = 1
        transportList.Sort()

        Dim strClip As String = ""
        For Each transp As String In transportList
            strClip += transp + vbNewLine
        Next


        My.Computer.Clipboard.Clear()
        My.Computer.Clipboard.SetText(strClip)


        GuiSession.FindById("wnd[1]/tbar[0]/btn[24]").press
        GuiSession.FindById("wnd[1]/tbar[0]/btn[8]").press


        GuiSession.FindById("wnd[0]/tbar[1]/btn[8]").press


        GuiSession.FindById("wnd[0]/tbar[1]/btn[33]").press
        GuiSession.FindById("wnd[1]/usr/lbl[1,4]").setFocus
        GuiSession.FindById("wnd[1]/usr/lbl[1,4]").caretPosition = 5
        GuiSession.FindById("wnd[1]").sendVKey(2)


        GuiSession.FindById("wnd[0]/usr/lbl[3,1]").setFocus
        GuiSession.FindById("wnd[0]/usr/lbl[3,1]").caretPosition = 7
        GuiSession.FindById("wnd[0]").sendVKey(2)
        GuiSession.FindById("wnd[0]/usr/lbl[14,1]").setFocus
        GuiSession.FindById("wnd[0]/usr/lbl[14,1]").caretPosition = 2
        GuiSession.FindById("wnd[0]").sendVKey(2)
        GuiSession.FindById("wnd[0]/usr/lbl[25,1]").setFocus
        GuiSession.FindById("wnd[0]/usr/lbl[25,1]").caretPosition = 20
        GuiSession.FindById("wnd[0]").sendVKey(2)
        GuiSession.FindById("wnd[0]/usr/lbl[61,1]").setFocus
        GuiSession.FindById("wnd[0]/usr/lbl[61,1]").caretPosition = 7
        GuiSession.FindById("wnd[0]").sendVKey(2)
        GuiSession.FindById("wnd[0]/tbar[1]/btn[29]").press
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN001-LOW").setFocus
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN001-LOW").caretPosition = 0
        GuiSession.FindById("wnd[1]").sendVKey(2)
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").setCurrentCell(5, "TEXT")
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").selectedRows = "5"
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").doubleClickCurrentCell
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN002-LOW").setFocus
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN002-LOW").caretPosition = 0
        GuiSession.FindById("wnd[1]").sendVKey(2)
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").setCurrentCell(5, "TEXT")
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").selectedRows = "5"
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").doubleClickCurrentCell
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN003-LOW").setFocus
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN003-LOW").caretPosition = 0
        GuiSession.FindById("wnd[1]").sendVKey(2)
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").setCurrentCell(5, "TEXT")
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").selectedRows = "5"
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").doubleClickCurrentCell
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN004-LOW").setFocus
        GuiSession.FindById("wnd[1]/usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN004-LOW").caretPosition = 0
        GuiSession.FindById("wnd[1]").sendVKey(2)
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").setCurrentCell(5, "TEXT")
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").selectedRows = "5"
        GuiSession.FindById("wnd[2]/usr/cntlOPTION_CONTAINER/shellcont/shell").doubleClickCurrentCell
        GuiSession.FindById("wnd[1]/tbar[0]/btn[0]").press

        If File.Exists(Me.FileManager.GetOrigin()) Then

            File.Delete(Me.FileManager.GetOrigin())

        End If

        GuiSession.findById("wnd[0]/mbar/menu[0]/menu[5]/menu[2]").select
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").text = Me.FileManager.OriginPath
        GuiSession.findById("wnd[1]/usr/ctxtDY_FILENAME").text = Me.FileManager.OriginName
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press

    End Sub
End Class
