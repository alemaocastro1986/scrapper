Imports Scrapper.Core
Imports Scrapper.Utils

Public Class ScheduleFactory : Implements IFactory
    Private DefaultPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Files"
    Public Function ForFactory(guiSession As Object) As Boolean Implements IFactory.ForFactory
        Dim ListSites As New List(Of String)

        Dim ListTransports As List(Of String)

        ListTransports = New TxtToCsv().GetListDataOfColumn(String.Concat(DefaultPath, "\loads.csv"), 0)

        Dim status As Boolean = False

        ListSites.Add("BR1D")
        ListSites.Add("BR3C")
        ListSites.Add("BR3A")
        ListSites.Add("BR1S")

        Dim i = 1
        For Each site As String In ListSites
            Dim originFile As String = String.Concat("schedules", "_", site, ".txt")
            Dim append As Boolean
            append = IIf(ListSites.IndexOf(site) > 0, True, False)
            Dim FileManager As New FileManager(originFile, DefaultPath, "schedule.csv", DefaultPath, True, append)

            ' Create Scrapper
            Console.WriteLine("[ScheduleFactory] - start scraping {0} | {1}", "MONITRANS " & site, Now)
            Dim ScheduleScraper As New ScheduleScrapper(guiSession, FileManager)
            ScheduleScraper.Scrape(New ScheduleScraperDTO(site, Today, Today, ListTransports))
            Console.WriteLine("[ScheduleFactory] - end scraping {0} | {1}", "MONITRANS " & site, Now)


            ' Generate File
            Dim ScheduleService As New ScheduleFileService(New TxtToCsv(FileManager.GetOrigin()), FileManager)
            status = ScheduleService.Generate()
            Console.WriteLine("[ScheduleFactory] - Create CSV {0} {1}/{2} | {3}", FileManager.DestinationName, i, ListSites.Count, Now)
            i += 1
        Next


        Return status
    End Function


End Class
