Public Interface IAlertService
    Function GetAlerts(ByVal projectNumber As String) As ICollection(Of Alert)

    Sub CreateAlert(ByVal alert As Alert)

End Interface