Public Class TransportScraperDTO
    Public Transports As List(Of String)
    Public Sites As List(Of String)

    Public Sub New(transports As List(Of String), sites As List(Of String))
        Me.Transports = transports
        Me.Sites = sites
    End Sub
End Class
