@ModelType ICollection(Of AlertViewModel)

@Code
    Dim i As Integer = 0
End Code

@For Each alert In Model
    @<div class="truncate">
        <span>@alert.AlertDate.ToShortDateString</span>
        <text>-</text>
        @alert.Description
    </div>
    @<a href="" onclick="showAlertDialog('#alert-dialog-message_@i');  return false;">Read more</a>
    @<br />

    @<div id="alert-dialog-message_@i" title="Alert">
        <p>

            <h4><span class="glyphicon glyphicon-calendar"></span> - @alert.AlertDate.ToShortDateString</h4>
        </p>
        <p>
            @alert.Description
        </p>
    </div>
    @<script type="text/javascript">
        $("#alert-dialog-message_@i").hide();
    </script>

    @Code
        i = i + 1
    End Code
Next
