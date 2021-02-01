Imports Scrapper.Core
Imports Scrapper.Utils

Public Class LoadFactory : Implements IFactory
    Private DefaultPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Files"

    Public Function ForFactory(guiSession As Object) As Boolean Implements IFactory.ForFactory
        Dim ListSites As New List(Of String)
        Dim status As Boolean = False

        ListSites.Add("BR1D")
        ListSites.Add("BR3C")
        ListSites.Add("BR3A")
        ListSites.Add("BR1S")

        Dim FileManager As New FileManager("loads.txt", DefaultPath, "loads.csv", DefaultPath, True)

        ' Create Scrapper
        Console.WriteLine("[LoadFactory] - start scraping {0} | {1}", " VT11", Now)
        Dim loadScraper As New LoadsScrapper(guiSession, FileManager)
        loadScraper.Scrape(New LoadScraperDTO(Today, Today, ListSites))
        Console.WriteLine("[LoadFactory] - end scraping {0} | {1}", " VT11", Now)


        ' Generate File
        Dim loadService As New LoadFileService(New TxtToCsv(FileManager.GetOrigin()), FileManager)
        status = loadService.Generate()
        Console.WriteLine("[LoadFactory] - Create CSV {0} | {1}", FileManager.DestinationName, Now)

        Return status
    End Function
End Class
