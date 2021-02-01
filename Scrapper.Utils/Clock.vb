Public Class Clock
    Public Shared Sub Sleep(seconds As Integer)
        Console.Write(" Aguarde ")
        For x = 1 To seconds
            Console.Write(".")
            Threading.Thread.Sleep(1000)
        Next
        Console.WriteLine()
    End Sub

End Class
