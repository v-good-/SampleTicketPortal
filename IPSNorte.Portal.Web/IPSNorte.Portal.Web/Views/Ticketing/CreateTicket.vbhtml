@ModelType CreateTicketViewModel
@Scripts.Render("~/bundles/jqueryval")

<script src="~/Scripts/create-ticket.js"></script>

@Using (Html.BeginForm("CreateTicket", "Ticketing", FormMethod.Post, New With {.id = "createForm", .enctype = "multipart/form-data"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary()

    @<div class="row">
        @Html.ValidationSummary(True)
        <div class="col-md-12">
            @Html.LabelFor(Function(model) model.Description)
            <br />
            @Html.TextAreaFor(Function(model) model.Description)
            @Html.ValidationMessageFor(Function(model) model.Description)
        </div>
    </div>
@<br />
    @<div class="row">
        <div class="col-md-12">

            @Html.LabelFor(Function(model) model.ProjectNumber)
            <br />
            @Html.DisplayFor(Function(model) model.ProjectNumber)
            @Html.HiddenFor(Function(model) model.ProjectNumber)

        </div>
    </div>
@<br />
    @<div class="row">
        <div class="col-md-12">
            @Html.LabelFor(Function(model) model.Priority)
            <br />
            @Html.DropDownListFor(Function(model) model.Priority, Model.PriorityList)
            @Html.ValidationMessageFor(Function(model) model.Priority)

        </div>
    </div>
@<br />
    @<div class="row">
        <div class="col-md-12">
            <label for="fileToUpload">@IPSNorte.Portal.Web.Web.Resources.CreateTicketView_UploadFile</label>
            <br />
            <input type="file" id="fileToUpload" name="File" />
        </div>
    </div>
@<br />
@<br />
    @<div class="row">
        <div class="col-md-12">
            <input type="button" value="@IPSNorte.Portal.Web.Web.Resources.CreateTicketView_CreateTicket" id="btnCreate" class=" btn btn-default dialog" />
        </div>
    </div>
End Using


