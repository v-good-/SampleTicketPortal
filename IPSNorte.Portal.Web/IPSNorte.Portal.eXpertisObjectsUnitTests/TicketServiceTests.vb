Imports IPSNorte.Portal.eXpertisObjects
Imports Moq
Imports NUnit.Framework

<TestFixture>
Public Class TicketServiceTests

    <Test()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub TicketService_CreateTicket_FailsIfIdAlreadySet()

        Dim ticketService = New TicketService()

        Dim ticket As New Ticket()

        ticket.Id = Guid.NewGuid().ToString()

        'This one throws exception
        ticketService.CreateTicket(ticket)

    End Sub

    <Test()>
    <ExpectedException(GetType(ArgumentException))>
    Public Sub TicketService_CreateTicket_FailsIfAlreadyExists()

        Dim ticketService = New TicketService()

        Dim ticket As New Ticket()

        ticket.Id = Guid.NewGuid().ToString()

        'This one succeeds
        ticketService.CreateTicket(ticket)

        'This one throws exception
        ticketService.CreateTicket(ticket)

    End Sub

    <Test()>
    Public Sub TicketService_CreateTicket_Ok()

        Dim ticket As New Ticket()
        
        Dim ticketServiceClient = New TicketService()
        ticketServiceClient.CreateTicket(ticket)

        Assert.IsNotNull(ticket.Id)

    End Sub

End Class
