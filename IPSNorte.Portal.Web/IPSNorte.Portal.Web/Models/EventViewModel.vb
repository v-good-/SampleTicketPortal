
Public Class EventsViewModel

    Property Events As List(Of EventViewModel)

    Property SelectedEvent() As String

End Class

Public Class EventViewModel

    Property Id() As String

    Property Title() As String

    Property Description() As String

    Property EventDate() As DateTime

End Class
