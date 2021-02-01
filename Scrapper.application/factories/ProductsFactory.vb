Imports Scrapper.Core
Imports Scrapper.Utils

Public Class ProductsFactory : Implements IFactory
    Private DefaultPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Files"

    Public Function ForFactory(guiSession As Object) As Boolean Implements IFactory.ForFactory
        Dim ListRemittances As New List(Of String)
        Dim status As Boolean = False

        ListRemittances = New TxtToCsv().GetListDataOfColumn(String.Concat(DefaultPath, "\trasports.csv"), 0)

        Dim FileManager As New FileManager("materials.txt", DefaultPath, "materials.csv", DefaultPath, True)

        ' Create Scrapper
        Console.WriteLine("[ProductFactory] - start scraping {0} | {1}", " LT22", Now)
        Dim productScraper As New ProductScrapper(guiSession, FileManager)
        productScraper.Scrape(New ProductScraperDTO(ListRemittances))
        Console.WriteLine("[ProductFactory] - end scraping {0} | {1}", " LT22", Now)


        ' Generate File
        Dim productService As New ProductFileService(New TxtToCsv(FileManager.GetOrigin()), FileManager)
        status = productService.Generate()
        Console.WriteLine("[ProductFactory] - Create CSV {0} | {1}", FileManager.DestinationName, Now)




        Return status
    End Function
End Class
