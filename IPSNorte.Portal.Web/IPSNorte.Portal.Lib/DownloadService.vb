
Imports System.Configuration
Imports System.IO
Imports System.Web

Public Class DownloadService

    Public Function GetFiles() As List(Of FileItem)

        Dim files = New List(Of FileItem)

        For i As Integer = 0 To 10

            files.Add(New FileItem With {.Description = "List of possible reaons to createa new ticket on this system.",
                                        .Id = i,
                                        .Name = "File number " + i.ToString(),
                                        .Size = 59345 * i})
        Next (i)

        Return files

    End Function

    Public Function DownloadFile(ByVal id As String) As Byte()

        'Log the fact that an item has been downloaded?

        'get file from wherever it is?

        Return System.IO.File.ReadAllBytes(Path.Combine(ConfigurationManager.AppSettings("TicketFilesFolder"), id))

    End Function

    Public Function SaveFile(file As HttpPostedFileBase) As String

        If (Not IsNothing(file)) Then

            Dim safeId = Guid.NewGuid().ToString()

            Dim workingFolder = ConfigurationManager.AppSettings("TicketFilesFolder")

            If (Not Directory.Exists(workingFolder)) Then
                Directory.CreateDirectory(workingFolder)
            End If

            Dim path As String = IO.Path.Combine(workingFolder, safeId)
            file.SaveAs(path)

            Return safeId

        End If

        Return String.Empty

    End Function
End Class
