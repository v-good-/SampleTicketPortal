@Imports IPSNorte.Portal.Web.Web.Resources
@Code
    ViewData("Title") = PageTitle_TicketsIndex
End Code
<script src="~/Scripts/App/ticketing.js"></script>

<h2>@PageTitle_TicketsIndex</h2>
<br />
<br />

<div class="row">

    <div class="text-left col-md-5 hideOnSmall">
        <a class="btn btn-default" href="#" id="pdf-button">Export to pdf</a>
        <a class="btn btn-default" href="#" id="xls-button">Export to xls</a>
        <a class="btn btn-default" href="#" id="advancedSearch-button">Advanced Search</a>
        <div id="advancedSearch-div" style="display:none;" class="table-bordered">
            <div class=" row">
                <div class="col-md-12"><h3>Advanced Search</h3></div>
            </div>
            <div class=" row">
                    <div class="col-md-6">Project Number</div>
                    <div class="col-md-6"></div>
                </div>
                <div class="row">
                    <div class="col-md-6">Created Date</div>
                    <div class="col-md-6"></div>

                </div>
                <div class="row">
                    <div class="col-md-6">Created By</div>
                    <div class="col-md-6"></div>

                </div>
            </div>
    </div>
    <div class="text-right col-md-7 ">
        <input type="text" id="search-string" name="search-string" class="form-control" style="display:inline !important" />
        <a href="#" id="search-button" class="btn btn-default">Search</a>
    </div>
</div>
<br />
<br />
<br />
<table id="ticketingGrid"></table>
<div id="ticketingPager"></div>
