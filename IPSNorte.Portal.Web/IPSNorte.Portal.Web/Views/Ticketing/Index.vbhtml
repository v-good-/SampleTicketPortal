@Imports IPSNorte.Portal.Web.Web.Resources
@ModelType List(Of UserViewModel)
@Code
    ViewData("Title") = PageTitle_TicketsIndex
End Code
<script src="~/Scripts/App/ticketing.js"></script>

<h2>@PageTitle_TicketsIndex</h2>
<br />
<br />

<div class="row">

    <div class="text-left col-md-1 hideOnSmall">
        <a class="btn btn-default" href="#" id="pdf-button">Export to pdf</a>
    </div>
    <div class="text-left col-md-1 hideOnSmall">
       <a class="btn btn-default" href="#" id="xls-button">Export to xls</a>
    </div>
    <div class="text-left col-md-5 hideOnSmall">
        <a class="btn btn-default" href="#" id="advancedSearch-menu-button">Advanced Search</a>
        <div id="advancedSearch-div" style="display:none;" class="well">
            <div class=" row form-group">
                <div class="col-md-3">Status</div>
                <div class="col-md-9">
                    <input type="radio" name="status" id="status" value="" checked>All &nbsp;    
                    <input type="radio" name="status" id="status" value="open" class="">Open &nbsp; 
                    <input type="radio" name="status" id="status" value="inprogress" class="">In Progress &nbsp; 
                    <input type="radio" name="status" id="status" value="resolved" class="">Resolved
            </div>
            </div>
            <div class=" row form-group">
                <div class="col-md-3">Priority</div>
                <div class="col-md-9">
                    <input type="radio" name="priority" id="priority" value="" checked>All &nbsp;
                    <input type="radio" name="priority" id="priority" value="low">Low &nbsp;
                    <input type="radio" name="priority" id="priority" value="medium">Medium &nbsp; 
                    <input type="radio" name="priority" id="priority" value="high">High &nbsp; 
                    <input type="radio" name="priority" id="priority" value="critical">Critical 
                </div>
            </div>
            <div class="row form-group">
                <div class="col-md-3">Created Date</div>
                <div class="col-md-9"><input type="date" id="createdDate" class="form-control" /></div>
            </div>
            <div class="row form-group">
                <div class="col-md-3">Created By</div>
                <div class="col-md-9">
                    <select id="createdBy" class="form-control">
                        <option value="" selected>Any user</option>
                        @Code
                            For Each item As UserViewModel In Model
                               
                                @<option value="@item.Id">@item.FullName</option>
                         
                            Next
                                
                        End Code
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-11 text-right"><a href="#" id="advancedSearch-button" class="btn btn-default">Search</a></div>
            </div>
        </div>
    </div>
    <div class="text-right col-md-5 ">
        <input type="text" id="search-string" name="search-string" class="form-control" style="display:inline !important" />
        <a href="#" id="search-button" class="btn btn-default">Search</a>
    </div>
</div>
<br />
<br />
<br />
<table id="ticketingGrid"></table>
<div id="ticketingPager"></div>
