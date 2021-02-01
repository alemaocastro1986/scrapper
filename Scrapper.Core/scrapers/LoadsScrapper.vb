Imports System.IO
Imports Scrapper.Utils

Public Class LoadsScrapper : Implements IScraper(Of LoadScraperDTO)
    Private GuiSession As Object
    Private FileManager As FileManager

    Public Sub New(guiSession As Object, file As FileManager)
        Me.GuiSession = guiSession
        Me.FileManager = file
    End Sub
    Public Sub Scrape(args As LoadScraperDTO) Implements IScraper(Of LoadScraperDTO).Scrape
        GuiSession.findById("wnd[0]/tbar[0]/okcd").text = "vt11"
        GuiSession.findById("wnd[0]").sendVKey(0)
        GuiSession.findById("wnd[0]/usr/ctxtK_TNDRZT-HIGH").text = "23:59:00"
        GuiSession.findById("wnd[0]/usr/ctxtK_TNDRXT-HIGH").text = "23:59:00"
        GuiSession.findById("wnd[0]/usr/ctxtK_DPREG-LOW").text = DateFormat.DateSap(DateFormat.DateSubDay(args.StartDate, 1))
        GuiSession.findById("wnd[0]/usr/ctxtK_DPREG-HIGH").text = DateFormat.DateSap(DateAdd("d", 1, args.EndDate))
        GuiSession.findById("wnd[0]/usr/ctxtK_DPREG-HIGH").setFocus
        GuiSession.findById("wnd[0]/usr/ctxtK_DPREG-HIGH").caretPosition = 10
        GuiSession.findById("wnd[0]/usr/btn%_K_TPLST_%_APP_%-VALU_PUSH").press


        Dim i As Integer = 0
        For Each site As String In args.Sites
            GuiSession.findById("wnd[1]/usr/tabsTAB_STRIP/tabpSIVA/ssubSCREEN_HEADER:SAPLALDB:3010/tblSAPLALDBSINGLE/ctxtRSCSEL_255-SLOW_I[1," & i & "]").text = site
            i += 1
        Next


        GuiSession.findById("wnd[1]/usr/tabsTAB_STRIP/tabpSIVA/ssubSCREEN_HEADER:SAPLALDB:3010/tblSAPLALDBSINGLE/ctxtRSCSEL_255-SLOW_I[1,2]").setFocus
        GuiSession.findById("wnd[1]/usr/tabsTAB_STRIP/tabpSIVA/ssubSCREEN_HEADER:SAPLALDB:3010/tblSAPLALDBSINGLE/ctxtRSCSEL_255-SLOW_I[1,2]").caretPosition = 4
        GuiSession.findById("wnd[1]/tbar[0]/btn[8]").press
        GuiSession.findById("wnd[0]/tbar[1]/btn[8]").press
        GuiSession.findById("wnd[0]/mbar/menu[5]/menu[5]/menu[2]/menu[1]").select
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press


        If File.Exists(Me.FileManager.GetOrigin()) Then
            File.Delete(Me.FileManager.GetOrigin())
        End If

        GuiSession.findById("wnd[1]/usr/ctxtDY_PATH").text = Me.FileManager.OriginPath
        GuiSession.findById("wnd[1]/usr/ctxtDY_FILENAME").text = Me.FileManager.OriginName
        GuiSession.findById("wnd[1]/usr/ctxtDY_FILENAME").caretPosition = 6
        GuiSession.findById("wnd[1]/tbar[0]/btn[0]").press
    End Sub
End Class
