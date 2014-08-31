
Imports System.Reflection

Public Class TicketService
    Inherits MarshalByRefObject
    Implements ITicketService

    Shared ReadOnly Tickets As List(Of Ticket) = New List(Of Ticket)()
    
    ''' <summary>
    ''' Create a new ticket.
    ''' </summary>
    Public Sub CreateTicket(ticket As Ticket) Implements ITicketService.CreateTicket

        ticket.Id = Guid.NewGuid().ToString()
        Tickets.Add(ticket)

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

    Public Function GetTickets(ByVal projectNumber As String) As ICollection(Of Ticket) Implements ITicketService.GetTickets
        Return Tickets.Where(Function(m) m.ProjectNumber = projectNumber).ToList()
    End Function

End Class
