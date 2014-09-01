Imports System.Security.Authentication.ExtendedProtection
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Configuration
Imports IPSNorte.Portal.eXpertisObjects
Imports System.Runtime.Remoting

Public Class AlertServiceClient

    Dim _alertService As IAlertService

    Public Sub New()
        _alertService = New AlertService()
    End Sub

    Public Sub New(alertService As IAlertService)
        _alertService = alertService
    End Sub

    Public Sub CreateAlert(alert As Alert)

        _alertService.CreateAlert(alert)

    End Sub

    Public Function GetAlerts(ByVal projectNumber As String) As ICollection(Of Alert)
        Return _alertService.GetAlerts(projectNumber)
    End Function


End Class
