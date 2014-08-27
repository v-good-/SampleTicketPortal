@Code
    ViewData("Title") = "Index"
End Code
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.4/jquery-ui.min.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.10.4/themes/redmond/jquery-ui.css" media="screen" />



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