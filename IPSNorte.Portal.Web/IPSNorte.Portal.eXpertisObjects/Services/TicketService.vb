
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

        Dim user As New User
        user.FirstName = "Mike"
        user.LastName = "Tompkins"

        For i As Integer = 0 To 1020
            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now
            ticket.CreatedBy = user
            ticket.Id = New Guid().ToString()
            ticket.Description = "Sample ticket " + i.ToString() + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Number = i
            ticket.Priority = TicketPriorityEnum.High
            ticket.ProjectNumber = i Mod 4
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

    Public Function GetTicketsPaged(ByVal size As Integer,
                                    ByVal page As Integer,
                                    ByVal orderBy As String,
                                    ByVal orderByDirection As String,
                                    ByVal searchString As String,
                                    ByVal searchTerms As SearchModel,
                                    ByRef total As Integer) As IList(Of Ticket) Implements ITicketService.GetTicketsPaged

        Dim currentRecords As IEnumerable(Of Ticket)

        Dim pageIndex As Integer = page - 1
        Dim pageSize As Integer = size
        Dim prop As PropertyInfo = New Ticket().GetType().GetProperty(orderBy)

        If (orderByDirection.Equals("desc")) Then
            currentRecords = Tickets.OrderByDescending(Function(m) prop.GetValue(m))
        Else
            currentRecords = Tickets.OrderBy(Function(m) prop.GetValue(m))
        End If

        If (Not String.IsNullOrEmpty(searchString)) Then
            currentRecords = currentRecords.Where(Function(m) m.Description.Contains(searchString))
        End If

        If (Not searchTerms Is Nothing) Then
            For Each searchTerm As SearchRule In searchTerms.rules
                Dim searchProp As PropertyInfo = New Ticket().GetType().GetProperty(searchTerm.field)
                currentRecords = currentRecords.Where(Function(m) searchProp.GetValue(m).ToString().Contains(searchTerm.data))
            Next
        End If

        total = currentRecords.Count
        Return currentRecords.Skip(pageIndex * pageSize).Take(pageSize).ToList()

    End Function

    Public Function GetTickets() As IList(Of Ticket) Implements ITicketService.GetTickets
        Return Tickets
    End Function

End Class
