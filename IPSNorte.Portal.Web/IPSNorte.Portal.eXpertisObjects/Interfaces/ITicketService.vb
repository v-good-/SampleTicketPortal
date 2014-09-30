Public Interface ITicketService
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Sub CreateTicket(ticket As Ticket)

    ''' <summary>
    ''' Create a new comment in an existing ticket.
    ''' </summary>
    Sub AddComment(ticketEntry As TicketEntry, ticketId As String)

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Sub DeleteTicket(ticket As Ticket)

    Function GetTickets(projectNumber As String) As ICollection(Of Ticket)

    Function GetTicketsPaged(ByVal size As Integer,
                                    ByVal page As Integer,
                                    ByVal orderBy As String,
                                    ByVal orderByDirection As String,
                                    ByVal searchString As String,
                                    ByVal searchTerms As SearchModel,
                                    ByVal projectNumber As String,
                                    ByRef total As Integer) As ICollection(Of Ticket)

    Function GetTickets(ByVal projectNumber As String, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel) As ICollection(Of Ticket)
    Function GetTicket(ByVal id As String) As Ticket
End Interface