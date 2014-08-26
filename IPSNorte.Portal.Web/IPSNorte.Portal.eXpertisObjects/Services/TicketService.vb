
Imports System.Reflection

Public Class TicketService
    Inherits MarshalByRefObject
    Implements ITicketService

    ReadOnly _tickets As List(Of Ticket) = New List(Of Ticket)()


    Public Sub New()
        _tickets.Clear()

        Dim user As New User
        user.FirstName = "Juan"
        user.LastName = "Gomez"
         

        For i As Integer = 0 To 1020
            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now
            ticket.CreatedBy = User
            ticket.ID = System.Guid.NewGuid.ToString()
            ticket.Description = "Sample ticket " + i.ToString() + " . " + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Number = i
            ticket.Priority = CType(CInt(Math.Ceiling(Rnd() * 2)), TicketPriorityEnum)
            ticket.ProjectNumber = i * 2
            ticket.Status = CType(CInt(Math.Ceiling(Rnd() * 2)), TicketStatusEnum)
            _tickets.Add(ticket)
        Next (i)

    End Sub

    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Public Sub CreateTicket(ticket As Ticket) Implements ITicketService.CreateTicket

        ticket.Number = _tickets.Last().Number + 1
        _tickets.Add(ticket)

    End Sub

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>
    Public Sub DeleteTicket(ticket As Ticket) Implements ITicketService.DeleteTicket

        _tickets.Remove(ticket)

    End Sub

  

    Public Function GetTickets(ByVal rows As Integer, ByVal page As Integer, ByVal sortField As String, ByVal sortOrder As String, ByVal searchString As String, ByVal searchTerms As SearchModel, ByRef count As Integer) As ICollection(Of Ticket) Implements ITicketService.GetTickets
        Dim currentRecords As ICollection(Of Ticket)
        Dim pageIndex As Integer = page - 1
        Dim pageSize As Integer = rows
        Dim prop As PropertyInfo = New Ticket().GetType().GetProperty(sortField)

        If (sortOrder.Equals("desc")) Then
            currentRecords = _tickets.OrderByDescending(Function(m) prop.GetValue(m)).ToList()
        Else
            currentRecords = _tickets.OrderBy(Function(m) prop.GetValue(m)).ToList()
        End If

        If (Not String.IsNullOrEmpty(searchString)) Then
            currentRecords = currentRecords.Where(Function(m) m.Description.Contains(searchString)).ToList()
        End If

        If (Not searchTerms Is Nothing) Then
            For Each searchTerm As SearchRule In searchTerms.rules
                Dim searchProp As PropertyInfo = New Ticket().GetType().GetProperty(searchTerm.field)
                currentRecords = currentRecords.Where(Function(m) searchProp.GetValue(m).ToString().Contains(searchTerm.data)).ToList()
            Next
        End If

        count = currentRecords.Count
        currentRecords = currentRecords.Skip(pageIndex * pageSize).Take(pageSize).ToList()

        Return currentRecords
    End Function

    Public Function GetTickets() As Object Implements ITicketService.GetTickets
        Return _tickets
    End Function

End Class
