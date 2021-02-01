Public Class ScheduleScraperDTO
    Public Site As String
    Public StartDate As Date
    Public EndDate As Date
    Public transports As List(Of String)

    Public Sub New()
    End Sub

    Public Sub New(site As String, startDate As Date, endDate As Date, list As List(Of String))
        Me.Site = site
        Me.StartDate = startDate
        Me.EndDate = endDate
        Me.transports = list
    End Sub


End Class
