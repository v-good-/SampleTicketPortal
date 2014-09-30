@Imports IPSNorte.Portal.Web.Web.Resources
@ModelType TicketViewModel
@Code
    ViewData("Title") = PageTitle_TicketDetails
End Code

<script src="~/Scripts/App/dialogs.js"></script>

<h2><span class="glyphicon glyphicon-zoom-in"></span>&nbsp; @PageTitle_TicketDetails:  # @Model.ProjectNumber / @Model.Number (    
@If Model.Status = "InProgress" Then
    @<span class="glyphicon glyphicon-wrench"></span>
ElseIf Model.Status = "Open" Then
    @<span class="glyphicon glyphicon-time"></span>
Else
    @<span class="glyphicon glyphicon-ok"></span>
End If
@Model.Status)</h2>

<div class="badge"> 
        Priority - @Model.Priority
</div>

<br />
    <div class="text-center">

        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <h3>
                    Description
                </h3>
                <p>@Model.Description</p>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-5 col-md-offset-1">
                <h4>
                    Created By
                </h4>
                <p>@Model.CreatedBy</p>
            </div>
            <div class="col-md-5 col-md-offset-1">
                <h4>
                    Created Date
                </h4>
                <p>@Model.CreatedDate</p>
            </div>
        </div>

    </div>
    <hr />
    <div class="row text-center">
        <div class="col-md-10 col-md-offset-1">
            <h3>
                Comments
            </h3>
            <a href="" class="btn btn-default" onclick="showAddCommentDialog('@Model.ID'); return false;">Add Comment</a> 
            
        </div>
    </div>

    @For Each ticketEntry As TicketEntryViewModel In Model.Entries
        
        @Html.Partial("_TicketEntry", ticketEntry)
        
    Next
              

