@Code
    ViewData("Title") = "Index"
End Code


<script src="~/Scripts/ticketing.js"></script>



<h2>Ticketing</h2>

<input type="text" id="search-string" name="search-string" />


<a href="#" id="search-button">Search</a>
<br />
<br />
<br />
<table id="ticketingGrid">
    <tr>
        <td />
    </tr>
</table>

<div id="ticketingPager"></div>
<br /><br />
<a href="#" id="pdf-button">Export to pdf</a> <a href="#" id="xls-button">Export to xls</a>