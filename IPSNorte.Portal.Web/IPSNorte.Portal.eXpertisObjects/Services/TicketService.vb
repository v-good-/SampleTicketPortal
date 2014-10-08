
Imports System.Reflection

Public Class TicketService
    Inherits MarshalByRefObject
    Implements ITicketService

    Shared ReadOnly Tickets As List(Of Ticket) = New List(Of Ticket)()
    
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Public Sub CreateTicket(ticket As Ticket) Implements ITicketService.CreateTicket

        If (Not IsNothing(ticket.Id)) Then
            Throw new ArgumentException("Error upon creating a new ticket, the given ticket already has an Id")
        End If

        If (Tickets.Any(Function(i) i.Id = ticket.Id)) Then
            Throw New ArgumentException("Error upon creating a new ticket, a ticket with same Id already exists.")
        End If

        ticket.Id = Guid.NewGuid().ToString()

        For Each ticketEntry As TicketEntry In ticket.Entries
            ticketEntry.Id = Guid.NewGuid().ToString()
            ticketEntry.TicketId = ticket.Id
        Next

        Tickets.Add(ticket)

    End Sub

    Public Sub AddComment(ByVal ticketEntry As TicketEntry, ByVal ticketId As String) Implements ITicketService.AddComment

        Dim ticket = Me.GetTicket(ticketId)

        'TODO validate this user (ticketEntry.CreatedBy) can actually add comments to this ticket..

        ticketEntry.TicketId = ticket.Id
        ticketEntry.Id = Guid.NewGuid().ToString()

        ticket.Entries.Add(ticketEntry)

    End Sub

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>

    Public Sub DeleteTicket(ticket As Ticket) Implements ITicketService.DeleteTicket

        Tickets.Remove(ticket)

    End Sub

    Private Function FilterTickets(ByVal projectNumber As String, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel) As ICollection(Of Ticket)
        Dim currentRecords As IEnumerable(Of Ticket)
        Dim prop As PropertyInfo = New Ticket().GetType().GetProperty(orderBy)
        
        currentRecords = Tickets.Where(Function(m) m.ProjectNumber = projectNumber).ToList()

        If (orderByDirection.Equals("desc")) Then
            currentRecords = currentRecords.OrderByDescending(Function(m) prop.GetValue(m))
        Else
            currentRecords = currentRecords.OrderBy(Function(m) prop.GetValue(m))
        End If

        If (Not String.IsNullOrEmpty(searchString)) Then
            currentRecords = currentRecords.Where(Function(m) m.Description.Contains(searchString))
        End If

        If (Not searchModel Is Nothing) Then
            For Each searchTerm As SearchRule In searchModel.rules

                If (Not String.IsNullOrWhiteSpace(searchTerm.data)) Then
                    Select Case (searchTerm.field.ToLower())
                        Case "createdby"
                            currentRecords = currentRecords.Where(Function(m) m.CreatedBy.Id = searchTerm.data Or m.CreatedBy.LastName.Contains(searchTerm.data) Or m.CreatedBy.FirstName.Contains(searchTerm.data))
                        Case "priority"
                            currentRecords = currentRecords.Where(Function(m) m.Priority.ToString().ToLower().Contains(searchTerm.data.ToLower()))
                        Case "status"
                            currentRecords = currentRecords.Where(Function(m) m.Status.ToString().ToLower().Contains(searchTerm.data.ToLower()))
                        Case "createddate"
                            currentRecords = currentRecords.Where(Function(m) m.CreatedDate.Date = DateTime.Parse(searchTerm.data).Date)

                        Case Else
                            Dim searchProp As PropertyInfo = New Ticket().GetType().GetProperty(searchTerm.field)
                            currentRecords = currentRecords.Where(Function(m) searchProp.GetValue(m).ToString().Contains(searchTerm.data))
                    End Select
                End If
            Next
        End If

        Return currentRecords.ToList()
    End Function

    Public Function GetTicketsPaged(ByVal size As Integer, ByVal page As Integer, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel, ByVal projectNumber As String, ByRef total As Integer) As ICollection(Of Ticket) Implements ITicketService.GetTicketsPaged
        Dim currentRecords As IEnumerable(Of Ticket)
        Dim pageIndex As Integer = page - 1
        Dim pageSize As Integer = size

        currentRecords = FilterTickets(projectNumber, orderBy, orderByDirection, searchString, searchModel)
        total = currentRecords.Count
        Return currentRecords.Skip(pageIndex * pageSize).Take(pageSize).ToList()

    End Function

    Public Function GetTickets(ByVal projectNumber As String, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel) As ICollection(Of Ticket) Implements ITicketService.GetTickets
        Dim currentRecords As IEnumerable(Of Ticket)
        currentRecords = FilterTickets(projectNumber, orderBy, orderByDirection, searchString, searchModel)
        Return currentRecords
    End Function

    Public Function GetTicket(ByVal id As String) As Ticket Implements ITicketService.GetTicket
        Return Tickets.FirstOrDefault(Function(m) m.Id = id)

    End Function

    Public Function GetTickets(ByVal projectNumber As String) As ICollection(Of Ticket) Implements ITicketService.GetTickets
        Return Tickets.Where(Function(m) m.ProjectNumber = projectNumber).ToList()
    End Function

End Class
