Imports Scrapper.Core
Imports Scrapper.Utils

Public Class TransportsFactory : Implements IFactory
    Private DefaultPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Files"

    Public Function ForFactory(guiSession As Object) As Boolean Implements IFactory.ForFactory
        Dim ListSites As New List(Of String)
        Dim ListTransports As List(Of String)

        ListTransports = New TxtToCsv().GetListDataOfColumn(String.Concat(DefaultPath, "\schedule.csv"), 0)
        Dim status As Boolean = False

        ListSites.Add("BR1D")
        ListSites.Add("BR3C")
        ListSites.Add("BR3A")
        ListSites.Add("BR1S")

        Dim FileManager As New FileManager("transports.txt", DefaultPath, "trasports.csv", DefaultPath, True)

        ' Create Scrapper
        Console.WriteLine("[TransportFactory] - start scraping {0} | {1}", "VL06O", Now)
        Dim transportsScraper As New Transportcrapper(guiSession, FileManager)
        transportsScraper.Scrape(New TransportScraperDTO(ListTransports, ListSites))
        Console.WriteLine("[TransportFactory] - end scraping {0} | {1}", "VL06O", Now)

        ' Generate File
        Dim transportService As New TransportsFileService(New TxtToCsv(FileManager.GetOrigin()), FileManager)
        status = transportService.Generate()
        Console.WriteLine("[TransportFactory] - Create CSV {0} | {1}", FileManager.DestinationName, Now)

        Return status
    End Function
End Class
