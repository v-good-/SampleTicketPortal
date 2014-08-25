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
        <h2>Create a ticket</h2>
        <p>
            Lore ipsum.
        </p>
        <p><a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301865">Create Ticket &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>View Active Tickets</h2>
        <p>View currently active tickets.</p>
        <p>@Html.ActionLink("View tickets")
<a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301866">View Tickets &raquo;</a></p>
    </div>
    <div class="col-md-4">

        <h2>Alerts</h2>

        @Html.Partial("_Events", Model)
        <h2>Events</h2>
        @Html.Partial("_Events", Model)
    </div>
</div>
