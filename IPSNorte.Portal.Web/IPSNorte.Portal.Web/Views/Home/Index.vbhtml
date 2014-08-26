@Imports IPSNorte.Portal.Web.Web.Resources
@Code
    ViewData("Title") = "Home Page"
End Code

<div class="jumbotron">
    <h1>@ApplicationName</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="http://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>


<div class="row">
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-plus-sign"></span> Create a ticket</h2>
        <p>
            Lore ipsum.
        </p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301865">Create Ticket &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-list-alt"></span> View Active Tickets</h2>
        <p>View currently active tickets.</p>
        <p class="btn btn-default">
            @Html.ActionLink("View tickets", "Index", "Ticketing", vbNullString, New With {.class = "btn btn-default"})
            
            @Html.ActionLink("View tickets &raquo;", "ViewActiveTickets")
        </p>
    </div>
    <div class="col-md-4">

        <h2><span class="glyphicon glyphicon-calendar"></span> Events</h2>
        @Html.Partial("_Alerts")
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-signal"></span> By priority</h2>
        @Html.Partial("_TicketsBar", Model)
    </div>
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-tags"></span> Open vs Closed</h2>
        @Html.Partial("_TicketsPie", Model)
    </div>
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-bullhorn"></span> Alerts</h2>

        @Html.Partial("_Events")
    </div>
</div>
