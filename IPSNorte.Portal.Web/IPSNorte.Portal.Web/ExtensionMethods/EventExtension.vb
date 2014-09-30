Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.eXpertisObjects

Module EventExtension
    <Extension()> _
    Public Function ToEventViewModel(ByVal events As ICollection(Of CustomEvent)) As EventsViewModel

        Dim result As New EventsViewModel

        Dim ret As New List(Of EventViewModel)

        For Each theEvent As CustomEvent In events
            Dim model As New EventViewModel

            model.Id = theEvent.Id
            model.EventDate = theEvent.EventDate
            model.Description = theEvent.Description
            model.Title = theEvent.Title
            ret.Add(model)
        Next

        result.Events = ret

        Return result

    End Function
End Module
