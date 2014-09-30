Imports System.ComponentModel.DataAnnotations
Imports IPSNorte.Portal.Web.Web.Resources

Public Class DownloadViewModel

    Property FileId() As String

    <Display(ResourceType:=GetType(Resources), Name:="FileName")>
    Property FileName() As String
    
    <Display(ResourceType:=GetType(Resources), Name:="FileSize")>
    Property SizeInBytes() As Integer

    <Display(ResourceType:=GetType(Resources), Name:="FileDescription")>
    Property Description() As String

End Class
