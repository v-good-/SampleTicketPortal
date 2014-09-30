@ModelType List(Of DownloadViewModel)


<h2>@ViewData("Title").</h2>
<h3>@ViewData("Message")</h3>

<ul>
    @For Each file In Model
        @<li>
            @Html.ActionLink(file.FileName + "(" + Math.Round(file.SizeInBytes / 1024,2).ToString() + " Kb)", "DownloadFile", New With {.id = file.FileId})
            <p>@file.Description</p>
        </li>

    Next
</ul>