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
    ReadOnly _downloadService As DownloadService = New DownloadService()
    
    Function Index() As ActionResult

        Dim projectNumber = _userServiceClient.FindByName(User.Identity.GetUserName()).ProjectNumber

        Dim model = New MainViewModel()

        model.Alerts = _alertServiceClient.GetAlerts(projectNumber).OrderByDescending(Function(i) i.AlertDate).Take(3).ToList().ToAlertViewModel()
        model.Events = _eventServiceClient.GetEvents().OrderByDescending(Function(i) i.EventDate).Take(3).ToList().ToEventViewModel().Events

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
    
    Function AcceptCookies() As ActionResult

        Dim theUser = _userServiceClient.FindByName(User.Identity.Name)
        theUser.AcceptCookies = True
        _userServiceClient.Update(theUser)

        Return RedirectToAction("Index")

    End Function

    Function Download() As ActionResult

        ViewData("Title") = "Downloads"

        Dim model = _downloadService.GetFiles().ToDownloadViewModel()

        Return View(model)

    End Function

    Function DownloadFile(id As String, fileName As String) As FileResult

        Dim fileBytes As Byte() = _downloadService.DownloadFile(id)

        Return File(fileBytes, Net.Mime.MediaTypeNames.Application.Octet, fileName)

    End Function

    Function Events(id As String) As ActionResult

        Dim model = _eventServiceClient.GetEvents().ToEventViewModel()
        model.SelectedEvent = id
        Return View(model)
    End Function
End Class
