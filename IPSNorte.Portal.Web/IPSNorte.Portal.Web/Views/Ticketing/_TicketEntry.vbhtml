@ModelType TicketEntryViewModel


<div class="row">
    <div class="col-md-10 col-md-offset-1">
                

        <b>[@Model.CreatedDate] @Model.CreatedBy</b>
        @If Not String.IsNullOrEmpty(Model.FileName) Then
            
            @Html.ActionLink(Model.FileName, "DownloadFile", "Home", New With {.id = Model.FileId, .fileName=Model.FileName}, Nothing)
            
            @<span class="glyphicon glyphicon-paperclip">&nbsp;</span>
        End If
        <p>
            @Model.Comment
        </p>
    </div>
</div>


