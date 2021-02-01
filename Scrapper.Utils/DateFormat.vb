Public Class DateFormat
    Public Shared Function DateSap(dt As Date) As String
        Dim d As String
        Dim m As String
        Dim y As Integer

        Dim strDate As String

        d = Day(dt)
        m = Month(dt)
        y = Year(dt)

        If dt.Day < 10 Then d = "0" & d
        If dt.Month < 10 Then m = "0" & m

        strDate = String.Format("{0}.{1}.{2}", d, m, y)

        Return strDate
    End Function

    Public Shared Function DateSub(dt As Date, Optional intDay As Integer = 0, Optional intMonth As Integer = 0, Optional intYear As Integer = 0) As Date
        DateSub = New Date(dt.Year - intYear, dt.Month - intMonth, dt.Day - intDay)

    End Function

    Public Shared Function DateSubDay(dt As Date, Optional intDay As Integer = -1) As Date
        DateSubDay = dt.AddDays(intDay * -1)

    End Function
    Public Shared Function DateSubMonth(dt As Date, Optional intMonth As Integer = 0) As Date

        DateSubMonth = dt.AddMonths(intMonth * -1)

    End Function
    Public Shared Function DateSubYear(dt As Date, Optional intYear As Integer = 0) As Date
        DateSubYear = dt.AddYears(intYear * -1)

    End Function
End Class
