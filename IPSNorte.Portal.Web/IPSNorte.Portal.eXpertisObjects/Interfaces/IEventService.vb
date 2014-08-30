Public Interface IEventService
    Function GetEvents() As ICollection(Of CustomEvent)
    Sub CreateEvent(ByVal theEvent As CustomEvent)

End Interface