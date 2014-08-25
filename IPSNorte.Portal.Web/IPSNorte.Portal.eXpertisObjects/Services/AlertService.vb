
Public Class AlertService
    Inherits MarshalByRefObject
    Implements IAlertService

    ReadOnly _alerts As List(Of Alert) = New List(Of Alert)()

    Public Sub New()

        'Generate a bunch of events for testing.
        For i As Integer = 0 To 100
            Dim alert As Alert = New Alert
            alert.Id = i
            alert.AlertDate = DateTime.Today.AddDays(-i)
            alert.Description = "Alert number " + i
            alert.ProjectNumber = i Mod 3

            _alerts.Add(alert)
        Next (i)

    End Sub


    Public Function GetAlerts(ByVal user As User) As List(Of Alert) Implements IAlertService.GetAlerts
        Return _alerts
    End Function
End Class
