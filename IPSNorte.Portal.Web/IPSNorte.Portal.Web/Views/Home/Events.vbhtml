@ModelType EventsViewModel

<h2>@ViewData("Title")</h2>
<h3>@ViewData("Message")</h3>

@Code
    Dim classToApply As String = ""
    Dim divId As String = "default"
End Code


<ol>
    @For Each evt In Model.Events

        @If (Model.SelectedEvent = evt.Id) Then
            classToApply = "well"
            divId = "selected-event"
        Else
            classToApply = ""
            divId = "default"
        End If

        @<li>
            <div id="@divId" class="@classToApply">
                <h3>@evt.Title</h3>
                <p>@evt.Description</p>
            </div>
        </li>
    Next
</ol>

<script type="text/javascript">

    $(function () {
        
        $('html,body').animate({
            scrollTop: $("#selected-event").offset().top - 100
        }, 1000);
    });
</script>
