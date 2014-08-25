Imports System.Security.Authentication.ExtendedProtection
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Configuration
Imports IPSNorte.Portal.eXpertisObjects
Imports System.Runtime.Remoting

Public Class TicketServiceClient

    Dim _ticketService As TicketService

    Public Sub New()
        
        _ticketService = New TicketService()

    End Sub

    Public Sub CreateTicket(ticket As Ticket)

        _ticketService.CreateTicket(ticket)

    End Sub

    Public Sub DeleteTicket(ticket As Ticket)

        _ticketService.DeleteTicket(ticket)

    End Sub

End Class
