Imports System.IO

Public Class FileManager
    Private _originName As String
    Private _originPath As String
    Private _destinationName As String
    Private _destinationPath As String
    Private _canExport As Boolean = False
    Private _append As Boolean = False

    Public Sub New()
    End Sub
    Public Sub New(originalName As String, originPath As String, Optional append As Boolean = False)
        _originName = originalName
        _originPath = originPath
        _destinationName = ""
        _destinationPath = ""
        _append = append
    End Sub
    Public Sub New(originalName As String, originPath As String, destinationName As String, destinationPath As String, Optional canExport As Boolean = False, Optional append As Boolean = False)
        _originName = originalName
        _originPath = originPath
        _destinationName = destinationName
        _destinationPath = destinationPath
        _canExport = canExport
        _append = append
    End Sub

    Public Property OriginName As String
        Get
            Return _originName
        End Get
        Set(value As String)
            _originName = value
        End Set
    End Property

    Public Property OriginPath As String
        Get
            Return _originPath
        End Get
        Set(value As String)
            _originPath = value
        End Set
    End Property

    Public Property DestinationName As String
        Get
            Return _destinationName
        End Get
        Set(value As String)
            _destinationName = value
        End Set
    End Property

    Public Property DestinationPath As String
        Get
            Return _destinationPath
        End Get
        Set(value As String)
            _destinationPath = value
        End Set
    End Property

    Public Property Append As Boolean
        Get
            Return _append
        End Get
        Set(value As Boolean)
            _append = value
        End Set
    End Property

    Public Property CanExport As Boolean
        Get
            Return _canExport
        End Get
        Set(value As Boolean)
            _canExport = value
        End Set
    End Property

    Public Function GetOrigin() As String
        Return String.Concat(Me.OriginPath, "/", Me.OriginName)

    End Function

    Public Function GetDestination() As String
        Return String.Concat(Me.DestinationPath, "/", Me.DestinationName)
    End Function


End Class
