@ModelType ICollection(Of EventViewModel)

@For Each theEvent In Model

    @<div class="well">
         <h4>
             <span class=" glyphicon glyphicon-volume-up"></span>
             @theEvent.Title
         </h4> <span> @theEvent.EventDate.ToShortDateString </span> <span> @theEvent.Description </span>
    </div>
Next