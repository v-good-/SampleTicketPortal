Imports System.IO
Imports IPSNorte.Portal.eXpertisObjects
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class PrintService
    Public Function ExportTicketsToPdf(ByVal tickets As List(Of TicketViewModel)) As String
        Dim WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
        Dim fileName As String = String.Format("Tickets_{1}_{2}_{3}_{0}.pdf", Now.Millisecond, Now.Day, Now.Month, Now.Year)
        Dim WorkingFile = Path.Combine(WorkingFolder, fileName)

        Using FS As New FileStream(WorkingFile, FileMode.Create, FileAccess.Write, FileShare.None)
            Using Doc As New Document(PageSize.A4)
                Using Writer = PdfWriter.GetInstance(Doc, FS)

                    Doc.Open()
                    Doc.NewPage()

                    Dim table As New PdfPTable(8)

                    For Each ticketViewModel As TicketViewModel In tickets

                        table.AddCell(ticketViewModel.ID)
                        table.AddCell(ticketViewModel.ProjectNumber)
                        table.AddCell(ticketViewModel.CreatedDate)
                        table.AddCell(ticketViewModel.CreatedBy)
                        table.AddCell(ticketViewModel.Description)
                        table.AddCell(ticketViewModel.Number)
                        table.AddCell(ticketViewModel.Priority)
                        table.AddCell(ticketViewModel.Status)

                    Next

                    Doc.Add(table)

                    Doc.Close()
                End Using
            End Using
        End Using
        Return fileName
    End Function

    Public Function ExportTicketsToXLS(ByVal ticketViewModels As IEnumerable(Of TicketViewModel)) As String
        Dim sw As New StringWriter()
        Dim WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache)
        Dim fileName As String = String.Format("Tickets_{1}_{2}_{3}_{0}.csv", Now.Millisecond, Now.Day, Now.Month, Now.Year)
        Dim WorkingFile = Path.Combine(WorkingFolder, fileName)

        Using fs As New FileStream(WorkingFile, FileMode.Create, FileAccess.Write, FileShare.None)
            Using fw As New StreamWriter(fs)

                For Each ticketViewModel As TicketViewModel In ticketViewModels
                    fw.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                                               ticketViewModel.ID,
                                               ticketViewModel.ProjectNumber,
                                               ticketViewModel.CreatedDate,
                                               ticketViewModel.CreatedBy,
                                               ticketViewModel.Description,
                                               ticketViewModel.Number,
                                               ticketViewModel.Priority,
                                               ticketViewModel.Status))


                Next
            End Using
        End Using
        Return fileName 

    End Function


End Class
