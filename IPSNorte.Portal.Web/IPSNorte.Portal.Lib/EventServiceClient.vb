Imports System.Security.Authentication.ExtendedProtection
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Configuration
Imports IPSNorte.Portal.eXpertisObjects
Imports System.Runtime.Remoting

Public Class EventServiceClient

    Dim _eventService As IEventService

    Public Sub New()
        _eventService = New EventService()
    End Sub
    Public Sub New(eventService As IEventService)
        _eventService = eventService
    End Sub

    Public Sub CreateEvent(theEvent As CustomEvent)

        _eventService.CreateEvent(theEvent)

    End Sub
    Public Function GetEvents() As ICollection(Of CustomEvent)
        Return _eventService.GetEvents()
    End Function

End Class
