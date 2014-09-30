//Takes css classes assigned to each column in the jqGrid colModel 
//and applies them to the associated header.
var applyClassesToHeaders = function (grid) {
    // Use the passed in grid as context, 
    // in case we have more than one table on the page.
    var trHead = jQuery("thead:first tr", grid.hdiv);
    var colModel = grid.getGridParam("colModel");

    for (var iCol = 0; iCol < colModel.length; iCol++) {
        var columnInfo = colModel[iCol];
        if (columnInfo.classes) {
            var headDiv = jQuery("th:eq(" + iCol + ")", trHead);
            headDiv.addClass(columnInfo.classes);
        }
    }
};

function showGrid() {
    var grid = $('#ticketingGrid');

    grid.jqGrid({
        colNames: ['ID', 'Description', 'ProjectNumber', 'CreatedBy', 'CreatedDate', 'Status', 'Priority', 'File'],
        colModel: [
            { name: 'ID', index: 'ID', hidden: true },
            { name: 'Description', index: 'Description', width: 400},
            { name: 'ProjectNumber', index: 'ProjectNumber', classes: 'hideOnSmall', width: 90 },
            { name: 'CreatedBy', index: 'CreatedBy', classes: 'hideOnSmall', width: 100 },
            { name: 'CreatedDate', index: 'CreatedDate', formatter: 'date', classes: 'hideOnSmall' , width: 100},
            { name: 'Status', index: 'Status' , width: 90},
            { name: 'Priority', index: 'Priority' , width: 90},
            {
                name: 'File',
                index: 'File',
                edittype: 'select',
                formatter: returnHyperLink, classes: 'hideOnSmall'
            }
        ],
        onSelectRow: function (id) {
            var row = $(this).getRowData(id);
            window.location.href = '/Ticketing/TicketDetails/' + row.ID;
        },
        hidegrid: false,
        pager: jQuery('#ticketingPager'),
        sortname: 'CreatedDate',
        sortorder: 'desc',
        rowNum: 10,
        rowList: [10, 20, 50, 100],
        datatype: 'json',
        height: 300,
        viewrecords: true,
        mtype: 'GET',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            userdata: "userdata"
        },
        url: "/Ticketing/GetTickets"
    }).navGrid('#ticketingPager', { view: false, del: false, add: false, edit: false, search: true },
       { width: 400 }, // default settings for edit
       {}, // default settings for add
       {}, // delete instead that del:false we need this
       { multipleSearch: true,afterRedraw: function($p) { 
            $("select.opsel").remove(); 
        } },
       {} /* view parameters*/
     );

    applyClassesToHeaders(grid);
};

$(document).ready(function () {
    showGrid();

    $("#search-button").button().click(function () {
        searchString = $.trim($("#search-string").val()); 
            $("#ticketingGrid").jqGrid('setGridParam', { url: '/Ticketing/GetTickets?searchString=' + searchString });  
            $("#ticketingGrid").jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid'); 
    });

    $("#pdf-button").button().click(function () {
        var myUrl = "/Ticketing/PrintTicketsToPdf";
        var sw = true;
         
        var postData = jQuery("#ticketingGrid").jqGrid('getGridParam', 'postData');
        $.each(postData, function (key, value) {
            if (sw) {
                sw = false;
                myUrl += "?" + key + "=" + encodeURIComponent(value);
            } else {
                myUrl += "&" + key + "=" + encodeURIComponent(value); 
            }
        });

        $.ajax({
            url: myUrl, 
            type: 'GET',
            dataType: "json",
            contentType: "application/json",
            success: function (returnValue) {
                window.location = '/Ticketing/DownloadFile?fileName=' + returnValue;
            }  
        });
    });

    $("#xls-button").button().click(function () {
        var myUrl = "/Ticketing/PrintTicketsToXls";
        var sw = true;

        var postData = jQuery("#ticketingGrid").jqGrid('getGridParam', 'postData');
        $.each(postData, function (key, value) {
            if (sw) {
                sw = false;
                myUrl += "?" + key + "=" + encodeURIComponent(value);
            } else {
                myUrl += "&" + key + "=" + encodeURIComponent(value);
            }
        });

        $.ajax({
            url: myUrl,
            type: 'GET',
            dataType: "json",
            contentType: "application/json",
            success: function (returnValue) {
                window.location = '/Ticketing/DownloadFile?fileName=' + returnValue;
            }
        });
    });

    $("#advancedSearch-button").button().click(function () {
        $("#advancedSearch-div").toggle();
    });
   
});

function returnHyperLink(cellValue, options, rowdata, action) 
{ 
    return "<a href='/Ticketing/DownloadTicketFile?fileName=" + rowdata.File + "'>" + rowdata.File + "</a>";
}
