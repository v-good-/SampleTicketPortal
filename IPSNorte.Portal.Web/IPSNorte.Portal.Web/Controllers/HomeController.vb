Imports IPSNorte.Portal.eXpertisObjects
Imports Microsoft.AspNet.Identity
Imports IPSNorte.Portal.Lib

<Authorize()>
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    ReadOnly _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
    ReadOnly _userServiceClient As UserServiceClient = New UserServiceClient()
    ReadOnly _alertServiceClient As AlertServiceClient = New AlertServiceClient()
    ReadOnly _eventServiceClient As EventServiceClient = New EventServiceClient()

    Function Index() As ActionResult

        Dim projectNumber = _userServiceClient.FindByName(User.Identity.GetUserName()).ProjectNumber

        Dim model = New MainViewModel()

        model.Alerts = _alertServiceClient.GetAlerts(projectNumber).OrderByDescending(Function(i) i.AlertDate).Take(3).ToList().ToAlertViewModel()
        model.Events = _eventServiceClient.GetEvents().OrderByDescending(Function(i) i.EventDate).Take(3).ToList().ToEventViewModel()

        model.OpenTicketsCount = _ticketServiceClient.GetTickets(projectNumber).Where(Function(i) i.Status = TicketStatusEnum.Open Or i.Status = TicketStatusEnum.InProgress).Count()


        Return View(model)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
