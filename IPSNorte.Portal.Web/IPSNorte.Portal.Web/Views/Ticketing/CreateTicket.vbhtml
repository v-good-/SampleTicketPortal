@ModelType CreateTicketViewModel
@Scripts.Render("~/bundles/jqueryval")
     
<script src="~/Scripts/create-ticket.js"></script>

 
@Using (Html.BeginForm("SaveTicket", "Ticketing",   FormMethod.Post, New With {.id ="createForm", .enctype = "multipart/form-data"}))
    
    @Html.AntiForgeryToken() 
      @Html.ValidationSummary()

    @<div class="well" style="width:100%">

        <input type="file" id="fileToUpload" name="File" />
    

        <span class="field-validation-error" id="spanfile"></span> 
    </div>
    @<div class="form-horizontal"> 
        <hr />
        @Html.ValidationSummary(true)
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.Description)
                @Html.ValidationMessageFor(Function(model) model.Description)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Number, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Number)
                @Html.ValidationMessageFor(Function(model) model.Number)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.ProjectNumber, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ProjectNumber)
                @Html.ValidationMessageFor(Function(model) model.ProjectNumber)
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CreatedDate, New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.CreatedDate)
                @Html.ValidationMessageFor(Function(model) model.CreatedDate)
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Priority, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.Priority, Model.PriorityList)
                 @Html.ValidationMessageFor(Function(model) model.Priority)
             </div>
         </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.Status, New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.DropDownListFor(Function(model) model.Status, Model.StatusList)
                 @Html.ValidationMessageFor(Function(model) model.Status)
             </div>
         </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="button" value="Create Ticket" id="btnCreate" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using 

    
 