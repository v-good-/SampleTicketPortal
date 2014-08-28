Public Class Ticket

    Property Id As String

    Property Description() As String

    Property Number() As Integer

    Property ProjectNumber() As String

    Property CreatedBy() As User

    Property CreatedDate() As DateTime

    Property Status() As TicketStatusEnum

    Property Priority() As TicketPriorityEnum

    Property FileName() As String


End Class
