@Imports IPSNorte.Portal.Web.Web.Resources
@Code
    ViewData("Title") = PageTitle_TicketsIndex
End Code


<script src="~/Scripts/ticketing.js"></script>

<h2>@PageTitle_TicketsIndex</h2>
<br />
<br />

<div class="row">

    <div class="text-left col-md-5 remark">
        <a class="btn btn-default" href="#" id="pdf-button">Export to pdf</a>
        <a class="btn btn-default" href="#" id="xls-button">Export to xls</a>
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
