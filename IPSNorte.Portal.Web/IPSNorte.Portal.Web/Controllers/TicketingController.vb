Imports System.Web.Mvc
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


    Function GetTickets(sidx As String, sord As String, page As Integer, rows As Integer, searchString As String, filters As String) As JsonResult
        Dim _ticketServiceClient As TicketServiceClient = New TicketServiceClient()
        Dim _userServiceClient As UserServiceClient = New UserServiceClient()
        Dim count As Integer
        Dim projectNumber As String
        Dim searchTerms As SearchModel

        projectNumber = _userServiceClient.FindById(User.Identity.GetUserId()).ProjectNumber

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
End Class