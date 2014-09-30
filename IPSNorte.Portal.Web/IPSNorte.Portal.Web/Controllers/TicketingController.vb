Imports System.Web.Mvc
Imports System.IO
Imports Microsoft.AspNet.Identity
Imports IPSNorte.Portal.eXpertisObjects
Imports IPSNorte.Portal.Lib
Imports Newtonsoft.Json

Public Class TicketingController
    Inherits Controller

    ReadOnly _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
    ReadOnly _userServiceClient As UserServiceClient = New UserServiceClient()
    ReadOnly _downloadServiceClient As DownloadService = New DownloadService()

    ' GET: /Ticketing
    Function Index() As ActionResult
        Return View()
    End Function

    Function GetTickets(sidx As String,
                        sord As String,
                        page As Integer,
                        rows As Integer,
                        searchString As String,
                        filters As String) As JsonResult

        Dim count As Integer
        Dim projectNumber As String
        Dim searchTerms As SearchModel

        projectNumber = _userServiceClient.FindByName(User.Identity.GetUserName()).ProjectNumber

        If (Not String.IsNullOrEmpty(filters)) Then
            searchTerms = JsonConvert.DeserializeObject(Of SearchModel)(filters)
        End If

        Dim jqGrid As New TicketGridModel()
        jqGrid.rows = _ticketServiceClient.GetTickets(rows, page, sidx, sord, searchString, searchTerms, projectNumber, count).ToTicketViewModel()
        jqGrid.page = page
        jqGrid.records = count
        jqGrid.total = CInt(Math.Ceiling(jqGrid.records / rows))

        Return Json(jqGrid, JsonRequestBehavior.AllowGet)


    End Function

    Function PrintTicketsToPdf(sidx As String, sord As String, searchString As String, filters As String) As ActionResult

        Dim projectNumber As String
        Dim searchTerms As SearchModel

        projectNumber = _userServiceClient.FindByName(User.Identity.Name).ProjectNumber

        If (Not String.IsNullOrEmpty(filters)) Then
            searchTerms = JsonConvert.DeserializeObject(Of SearchModel)(filters)
        End If

        Dim ticketList As IEnumerable(Of TicketViewModel)
        ticketList = _ticketServiceClient.GetTickets(projectNumber, sidx, sord, searchString, searchTerms).ToTicketViewModel()

        Dim ps As New PrintService()
        Dim fileName As String = ps.ExportTicketsToPdf(ticketList)

        Return Json(fileName, JsonRequestBehavior.AllowGet)

    End Function

    <HttpGet()>
    Function PrintTicketsToXls(sidx As String, sord As String, searchString As String, filters As String) As ActionResult

        Dim projectNumber As String
        Dim searchTerms As SearchModel

        projectNumber = _userServiceClient.FindById(User.Identity.GetUserId()).ProjectNumber

        If (Not String.IsNullOrEmpty(filters)) Then
            searchTerms = JsonConvert.DeserializeObject(Of SearchModel)(filters)
        End If

        Dim ticketList As IEnumerable(Of TicketViewModel)
        ticketList = _ticketServiceClient.GetTickets(projectNumber, sidx, sord, searchString, searchTerms).ToTicketViewModel()

        Dim ps As New PrintService()
        Dim fileName As String = ps.ExportTicketsToXLS(ticketList)

        Return Json(fileName, JsonRequestBehavior.AllowGet)

    End Function

    <HttpGet()>
    Function DownloadFile(fileName As String) As ActionResult

        Dim workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
        Dim WorkingFile = Path.Combine(workingFolder, fileName)

        Return File(WorkingFile, "application/download", fileName)

    End Function

    <HttpGet()>
    Function DownloadTicketFile(fileName As String) As ActionResult

        Dim workingFolder = ConfigurationManager.AppSettings("TicketFilesFolder")
        Dim workingFile = Path.Combine(workingFolder, fileName)

        Return File(workingFile, "application/download", fileName)

    End Function

    <HttpGet()>
    Function CreateTicket() As ActionResult

        Dim model = New CreateTicketViewModel()

        'project number same as current user.
        model.ProjectNumber = _userServiceClient.FindByName(User.Identity.GetUserName()).ProjectNumber

        Return PartialView(model)

    End Function

    <HttpPost()>
    <ValidateAntiForgeryToken>
    Function CreateTicket(model As CreateTicketViewModel) As ActionResult

        If ModelState.IsValid Then

            Dim ticket As New Ticket
            ticket.CreatedBy = _userServiceClient.FindByName(User.Identity.GetUserName())
            ticket.CreatedDate = DateTime.Now
            ticket.Description = model.Description
            ticket.Priority = model.Priority
            ticket.ProjectNumber = model.ProjectNumber
            ticket.Status = TicketStatusEnum.Open 'always open if creating.

            ticket.FileName = IO.Path.GetFileName(model.File.FileName)
            ticket.FileId = _downloadServiceClient.SaveFile(model.File)

            _ticketServiceClient.CreateTicket(ticket)

        End If

        Return RedirectToAction("Index", "Home")

    End Function

    <HttpGet()>
    Function AddComment(ByVal id As String) As ActionResult

        Dim model = New TicketCommentViewModel()
        model.TicketId = id

        Return PartialView(model)

    End Function

    <HttpPost()>
    <ValidateAntiForgeryToken>
    Function AddComment(model As TicketCommentViewModel) As ActionResult

        If ModelState.IsValid Then

            Dim ticketEntry = New TicketEntry()

            ticketEntry.Comment = model.Description
            ticketEntry.CreatedBy = _userServiceClient.FindByName(User.Identity.GetUserName())
            ticketEntry.CreatedDate = DateTime.Now

            ticketEntry.FileName = IO.Path.GetFileName(model.File.FileName)
            ticketEntry.FileId = _downloadServiceClient.SaveFile(model.File)

            _ticketServiceClient.AddComment(ticketEntry, model.TicketId)

        End If

        Return RedirectToAction("TicketDetails", "Ticketing", New With {.id = model.TicketId})

    End Function

    Function TicketDetails(id As String)

        Dim ticket = _ticketServiceClient.GetTicket(id).ToTicketViewModel()
        Return View(ticket)

    End Function

End Class