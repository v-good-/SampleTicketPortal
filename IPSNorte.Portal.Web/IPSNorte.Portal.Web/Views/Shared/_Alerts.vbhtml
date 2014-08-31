@ModelType ICollection(Of AlertViewModel)

@For Each alert In Model

    @<span>@alert.AlertDate.ToShortDateString</span> 
    @<text>-</text> 
    @<span>@alert.Description</span>
    @<br />

Next
