Public Interface ITicketService
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Sub CreateTicket(ticket As Ticket)

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Sub DeleteTicket(ticket As Ticket)

    Function GetTickets(projectNumber As String) As IList(Of Ticket)

    Function GetTicketsPaged(ByVal size As Integer,
                                    ByVal page As Integer,
                                    ByVal orderBy As String,
                                    ByVal orderByDirection As String,
                                    ByVal searchString As String,
                                    ByVal searchTerms As SearchModel,
                                    ByVal projectNumber As String,
                                    ByRef total As Integer) As IList(Of Ticket)

    Function GetTickets(ByVal projectNumber As String, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel) As IList(Of Ticket)
End Interface