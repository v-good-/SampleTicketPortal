
Public Class AlertService
    Inherits MarshalByRefObject
    Implements IAlertService

    Shared ReadOnly _alerts As List(Of Alert) = New List(Of Alert)()
    
    Public Sub CreateAlert(ByVal alert As Alert) Implements IAlertService.CreateAlert

        alert.Id = Guid.NewGuid().ToString()
        _alerts.Add(alert)

    End Sub

    Public Function GetAlerts(ByVal projectNumber As String) As ICollection(Of Alert) Implements IAlertService.GetAlerts

        Return _alerts.Where(Function(m) m.ProjectNumber = projectNumber).ToList()

    End Function
End Class
