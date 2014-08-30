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
            { name: 'ID', index: 'ID', classes: 'remark' },
            { name: 'Description', index: 'Description' },
            { name: 'ProjectNumber', index: 'ProjectNumber', classes: 'remark' },
            { name: 'CreatedBy', index: 'CreatedBy', classes: 'remark' },
            { name: 'CreatedDate', index: 'CreatedDate', formatter: 'date', classes: 'remark' },
            { name: 'Status', index: 'Status' },
            { name: 'Priority', index: 'Priority' },
            {
                name: 'File',
                index: 'File',
                edittype: 'select',
                formatter: returnHyperLink, classes: 'remark'
            }
        ],
        hidegrid: false,
        autowidth: true,
        pager: jQuery('#ticketingPager'),
        sortname: 'CreatedDate',
        sortorder: 'desc',
        rowNum: 10,
        rowList: [10, 20, 50, 100],
        datatype: 'json', 
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
});

function returnHyperLink(cellValue, options, rowdata, action) 
{ 
    return "<a href='/Ticketing/DownloadTicketFile?fileName=" + rowdata.File + "'>" + rowdata.File + "</a>";
}

