Public Class Ticket

    Property Id As String

    Property Number() As Integer

    Property Description() As String
    
    Property ProjectNumber() As String

    Property CreatedBy() As User

    Property CreatedDate() As DateTime

    Property Status() As TicketStatusEnum

    Property Priority() As TicketPriorityEnum

    Property FileName() As String

    Property FileId() As String

    Property Entries() As List(Of TicketEntry)

End Class
