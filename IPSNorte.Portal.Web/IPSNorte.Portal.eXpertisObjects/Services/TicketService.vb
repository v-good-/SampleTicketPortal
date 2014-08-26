
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

        For i As Integer = 0 To 1200
            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now
            ticket.CreatedBy = user
            ticket.Id = System.Guid.NewGuid.ToString()
            ticket.Description = "Sample ticket " + i.ToString() + " " + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Number = i
            ticket.Priority = CType(CInt(Math.Ceiling(Rnd() * 3)), TicketPriorityEnum)
            ticket.ProjectNumber = CInt(Math.Ceiling(Rnd() * 100))
            ticket.Status = CType(CInt(Math.Ceiling(Rnd() * 2)), TicketStatusEnum)
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

    Public Function GetTicketsPaged(ByVal size As Integer, ByVal page As Integer, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchModel As SearchModel, ByVal projectNumber As String, ByRef total As Integer) As IList(Of Ticket) Implements ITicketService.GetTicketsPaged
        Dim currentRecords As IEnumerable(Of Ticket)
        Dim pageIndex As Integer = page - 1
        Dim pageSize As Integer = size
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


                Select Case (searchTerm.field.ToLower())
                    Case "createdby"
                        currentRecords = currentRecords.Where(Function(m) m.CreatedBy.LastName.Contains(searchTerm.data) Or m.CreatedBy.FirstName.Contains(searchTerm.data))
                    Case "priority"
                        currentRecords = currentRecords.Where(Function(m) m.Priority.ToString().ToLower().Contains(searchTerm.data.ToLower()))
                    Case "status"
                        currentRecords = currentRecords.Where(Function(m) m.Status.ToString().ToLower().Contains(searchTerm.data.ToLower()))

                    Case Else
                        Dim searchProp As PropertyInfo = New Ticket().GetType().GetProperty(searchTerm.field)
                        currentRecords = currentRecords.Where(Function(m) searchProp.GetValue(m).ToString().Contains(searchTerm.data))
                End Select
            Next
        End If

        total = currentRecords.Count
        Return currentRecords.Skip(pageIndex * pageSize).Take(pageSize).ToList()

    End Function

    Public Function GetTickets(ByVal projectNumber As String) As IList(Of Ticket) Implements ITicketService.GetTickets
        Return Tickets.Where(Function(m) m.ProjectNumber = projectNumber)
    End Function

End Class
