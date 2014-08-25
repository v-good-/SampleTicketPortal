Public Interface IAlertService
    Function GetAlerts(user As User) As List(Of Alert)
End Interface