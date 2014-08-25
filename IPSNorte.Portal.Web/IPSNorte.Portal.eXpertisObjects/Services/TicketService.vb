
Imports System.Reflection

Public Class TicketService
    Inherits MarshalByRefObject
    Implements ITicketService

    Shared ReadOnly Tickets As List(Of Ticket) = New List(Of Ticket)()

    Shared Sub New()
        LoadTickets()
    End Sub

    Private Shared Sub LoadTickets()
        Tickets.Clear()
        For i As Integer = 0 To 1020
            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now
            ticket.Id = New Guid().ToString()
            ticket.Description = "Sample ticket " + i.ToString() + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Number = i
            ticket.Priority = TicketPriorityEnum.High
            ticket.ProjectNumber = i * 2
            ticket.Status = TicketStatusEnum.Open
            Tickets.Add(ticket)
        Next (i)

    End Sub
    
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>

    Public Sub CreateTicket(ticket As Ticket) Implements ITicketService.CreateTicket

        ticket.Number = Tickets.Last().Number + 1
        Tickets.Add(ticket)

    End Sub

    ''' <summary>
    ''' Delete an existing ticket.
    ''' </summary>

    Public Sub DeleteTicket(ticket As Ticket) Implements ITicketService.DeleteTicket

        Tickets.Remove(ticket)

    End Sub

    Public Function GetTicketsPaged(size As Integer,
                               page As Integer,
                               orderBy As String,
                               orderByDirection As String,
                               searchString As String) As IList(Of Ticket) Implements ITicketService.GetTicketsPaged

        Dim currentPageRecords As ICollection(Of Ticket)

        Dim pageIndex As Integer = page - 1
        Dim pageSize As Integer = size
        Dim prop As PropertyInfo = New Ticket().GetType().GetProperty(orderBy)

        If (Not String.IsNullOrEmpty(searchString)) Then
            'Ensure it is at least an empty so that the where clause always works.
            searchString = String.Empty
        End If

        If (orderByDirection.ToLower().Equals("desc")) Then
            currentPageRecords = Tickets.Where(Function(m) m.Description.Contains(searchString)).OrderByDescending(Function(m) prop.GetValue(m)).Skip(pageIndex * pageSize).Take(pageSize).ToList()
        Else
            currentPageRecords = Tickets.Where(Function(m) m.Description.Contains(searchString)).OrderBy(Function(m) prop.GetValue(m)).Skip(pageIndex * pageSize).Take(pageSize).ToList()
        End If

        Return currentPageRecords

    End Function

    Public Function GetTickets() As IList(Of Ticket) Implements ITicketService.GetTickets
        Return Tickets
    End Function

End Class
