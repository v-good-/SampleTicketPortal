Imports System.Runtime.CompilerServices
Imports IPSNorte.Portal.Lib

Module DownladExtension
    <Extension()> _
    Public Function ToDownloadViewModel(ByVal files As ICollection(Of FileItem)) As ICollection(Of DownloadViewModel)

        Dim ret As New List(Of DownloadViewModel)

        For Each file As FileItem In files

            Dim model As New DownloadViewModel

            model.Description = file.Description
            model.FileId = file.Id
            model.FileName = file.Name
            model.SizeInBytes = file.Size

            ret.Add(model)

        Next

        Return ret
    End Function
End Module