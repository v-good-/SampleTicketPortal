Imports IPSNorte.Portal.eXpertisObjects
Imports System.Runtime.Remoting.Messaging
Imports Moq
Imports NUnit.Framework

<TestFixture>
Public Class TicketServiceClientTests

    <Test()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub TicketServiceClient_CreateTicket_FailsIfIdAlreadySet()

        Dim ticketServiceClient = New TicketServiceClient()

        Dim ticket As New Ticket()

        ticket.Id = Guid.NewGuid().ToString()

        'Throws expected exception
        ticketServiceClient.CreateTicket(ticket)

    End Sub

    <Test()>
   Public Sub TicketServiceClient_CreateTicket_Ok()

        Dim ticket As New Ticket()
        
        'Mock Service and except call to createticket
        Dim ticketServiceMock = New Moq.Mock(Of ITicketService)(MockBehavior.Strict)
        ticketServiceMock.Setup(Sub(s) s.CreateTicket(ticket))
        
        Dim ticketServiceClient = New TicketServiceClient(ticketServiceMock.Object)
        ticketServiceClient.CreateTicket(ticket)

        ticketServiceMock.VerifyAll()

    End Sub

    <Test()>
    <ExpectedException(GetType(InvalidOperationException))>
    Public Sub TicketServiceClient_DeleteTicket_FailsIfDoesntExists()

        'Mock Service and force it to return an empty list.
        Dim ticketServiceMock = New Moq.Mock(Of ITicketService)(MockBehavior.Strict)
        ticketServiceMock.Setup(Function(s) s.GetTickets(It.IsAny(Of String))).Returns(New List(Of Ticket))

        Dim ticketServiceClient = New TicketServiceClient(ticketServiceMock.Object)

        Dim ticket As New Ticket()
        ticket.Id = Guid.NewGuid().ToString()

        'Throws expected exception
        ticketServiceClient.DeleteTicket(ticket)


    End Sub

End Class
