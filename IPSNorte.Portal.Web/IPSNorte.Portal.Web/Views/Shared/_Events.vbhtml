@ModelType ICollection(Of EventViewModel)

@For Each theEvent In Model

@<div class="truncate">
     <h4>
         <span class=" glyphicon glyphicon-volume-up"></span>
         @theEvent.Title
     </h4> 
     @theEvent.EventDate.ToShortDateString - @theEvent.Description 
</div>
    @Html.ActionLink("Read more", "Events", "Home", New With {.id = theEvent.Id}, Nothing)

@<br />

Next