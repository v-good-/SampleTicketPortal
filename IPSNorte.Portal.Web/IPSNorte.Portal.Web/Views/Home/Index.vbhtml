@Imports IPSNorte.Portal.Web.Web.Resources
@Code    ViewData("Title") = "Home Page"

End Code

<script src="~/Scripts/App/dialogs.js"></script>

@ModelType MainViewModel

<script type="text/javascript">

    function CreateTicket() {

        var url = "/Ticketing/CreateTicket";

        $("#createTicketDialog").dialog(
        {
            open: function (event, ui) {
                $(this).load(url);
            },
        });
    }
</script>

@Html.Partial("_OpenTicketsCounter", Model.OpenTicketsCount)


<div class="jumbotron">
    <h1>@ApplicationName</h1>
    <p class="lead">@IndexPage_Intro</p>
</div>

<div id="createTicketDialog" title="Create ticket" style="display: none;"></div>


<div class="row">
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-plus-sign"></span> Open new ticket</h2>
        <p class="hideOnSmall">
            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.
        </p>
        <p>
            <a href="javascript:void(null);" onclick="CreateTicket()" class="btn btn-default dialog">@CreateTicketView_CreateTicket</a>
        </p>
    </div>
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-list-alt"></span> View Open Tickets</h2>
        <p class="hideOnSmall">
            Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.
        </p>

        @Html.ActionLink("View tickets", "Index", "Ticketing", vbNullString, New With {.class = "btn btn-default"})


    </div>
    <div class="col-md-4 hideOnSmall">
        <h2><span class="glyphicon glyphicon-calendar"></span> Alerts</h2>
        @Html.Partial("_Alerts", Model.Alerts)
    </div>
</div>
<div class="row">
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-signal"></span> By priority</h2>
        @Html.Partial("_TicketsBar")
    </div>
    <div class="col-md-4">
        <h2><span class="glyphicon glyphicon-tags"></span> By status</h2>
        @Html.Partial("_TicketsPie")
    </div>
    <div class="col-md-4 hideOnSmall text-nowrap">
        <h2><span class="glyphicon glyphicon-bullhorn"></span> Events <small>@Html.ActionLink("See all", "Events", "Home")</small> </h2>

        @Html.Partial("_Events", Model.Events)
    </div>
</div>
