Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.eXpertisObjects

Module EventExtension
    <Extension()> _
    Public Function ToEventViewModel(ByVal events As ICollection(Of CustomEvent)) As ICollection(Of EventViewModel)
        Dim ret As New List(Of EventViewModel)

        For Each theEvent As CustomEvent In events
            Dim model As New EventViewModel

            model.EventDate = theEvent.EventDate
            model.Description = theEvent.Description
            model.Title = theEvent.Title
            ret.Add(model)
        Next

        Return ret
    End Function
End Module
