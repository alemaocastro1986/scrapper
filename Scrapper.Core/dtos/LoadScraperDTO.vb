Public Class LoadScraperDTO
    Public StartDate As Date
    Public EndDate As Date
    Public Sites As List(Of String)

    Public Sub New(startDate As Date, endDate As Date, sites As List(Of String))
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.Sites = sites
    End Sub
End Class
