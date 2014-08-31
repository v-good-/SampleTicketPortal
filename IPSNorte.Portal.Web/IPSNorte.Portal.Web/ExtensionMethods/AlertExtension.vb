Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.eXpertisObjects

Module AlertExtension
    <Extension()> _
    Public Function ToAlertViewModel(ByVal alerts As ICollection(Of Alert)) As ICollection(Of AlertViewModel)
        Dim ret As New List(Of AlertViewModel)

        For Each alert As Alert In alerts
            Dim model As New AlertViewModel

            model.AlertDate = alert.AlertDate
            model.Description = alert.Description

            ret.Add(model)
        Next

        Return ret
    End Function
End Module
