﻿Imports System.Security.Authentication.ExtendedProtection
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


    Public Function GetTickets(ByVal size As Integer, ByVal page As Integer, ByVal orderBy As String, ByVal orderByDirection As String, ByVal searchString As String, ByVal searchTerms As SearchModel, ByVal projectNumber As String, ByRef total As Integer) As ICollection(Of Ticket)
        Return _ticketService.GetTicketsPaged(size, page, orderBy, orderByDirection, searchString, searchTerms, projectNumber, total)
    End Function

    Public Function GetTickets(ByVal projectNumber As String) As ICollection(Of Ticket)
        Return _ticketService.GetTickets(projectNumber)
    End Function
End Class
