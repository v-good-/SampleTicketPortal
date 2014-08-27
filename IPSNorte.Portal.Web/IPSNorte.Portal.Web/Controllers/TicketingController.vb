Imports System.Web.Mvc
Imports System.IO
Imports Microsoft.AspNet.Identity
Imports IPSNorte.Portal.eXpertisObjects
Imports IPSNorte.Portal.Lib
Imports Newtonsoft.Json



Public Class TicketingController
    Inherits Controller

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

        Dim _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
        Dim _userServiceClient As UserServiceClient = New UserServiceClient()
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
        Dim _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
        Dim _userServiceClient As UserServiceClient = New UserServiceClient()
        Dim projectNumber As String
        Dim searchTerms As SearchModel

        projectNumber = _userServiceClient.FindById(User.Identity.GetUserId()).ProjectNumber

        If (Not String.IsNullOrEmpty(filters)) Then
            searchTerms = JsonConvert.DeserializeObject(Of SearchModel)(filters)
        End If

        Dim ticketList As IEnumerable(Of TicketViewModel)
        ticketList = _ticketServiceClient.GetTickets(projectNumber, sidx, sord, searchString, searchTerms).ToTicketViewModel()

        Dim ps As New PrintService()
        Dim fileName As String = ps.ExportTicketsToPdf(ticketList)

        Return Json(fileName, JsonRequestBehavior.AllowGet)

    End Function
    Function PrintTicketsToXls(sidx As String, sord As String, searchString As String, filters As String) As ActionResult
        Dim _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
        Dim _userServiceClient As UserServiceClient = New UserServiceClient()
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


    Function DownloadFile(fileName As String) As ActionResult
        Dim WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) 
        Dim WorkingFile = Path.Combine(WorkingFolder, fileName)
        Return File(WorkingFile, "application/download", fileName)
    End Function
End Class