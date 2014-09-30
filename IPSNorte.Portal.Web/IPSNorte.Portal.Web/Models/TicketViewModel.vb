Public Class TicketViewModel

    Property ID As String

    Property Description() As String

    Property Number() As Integer

    Property ProjectNumber() As String

    Property CreatedBy() As String

    Property CreatedDate() As DateTime

    Property Status() As String

    Property Priority() As String

    Property File() As String

    Property Entries() As List(Of TicketEntryViewModel)

End Class

Public Class TicketEntryViewModel

    Property Id As String

    Property TicketId As String

    Property Comment() As String

    Property CreatedBy() As String

    Property CreatedDate() As DateTime

    Property FileName() As String

    Property FileId() As String
End Class
