﻿
Public Class EventService
    Inherits MarshalByRefObject
    Implements IEventService

    ReadOnly _events As List(Of CustomEvent) = New List(Of CustomEvent)()

    Public Sub New()

        'Generate a bunch of events for testing.

    End Sub

    Public Function GetEvents() As ICollection(Of CustomEvent) Implements IEventService.GetEvents
        Return _events
    End Function

    Public Sub CreateEvent(ByVal theEvent As CustomEvent) Implements IEventService.CreateEvent
        _events.Add(theEvent)
    End Sub
End Class
