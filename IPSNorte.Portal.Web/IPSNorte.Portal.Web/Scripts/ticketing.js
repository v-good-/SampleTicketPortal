function showGrid() {
    $('#ticketingGrid').jqGrid({
        caption: "Ticketing system",
        colNames: ['ID','Description','Number','ProjectNumber','CreatedBy','CreatedDate','Status','Priority','File'],
        colModel: [
                    { name: 'ID', index: 'ID' },

                    { name: 'Description', index: 'Description', width: 300 },
                    { name: 'Number', index: 'Number' },
                    { name: 'ProjectNumber', index: 'ProjectNumber' },
                    { name: 'CreatedBy', index: 'CreatedBy' },
                    { name: 'CreatedDate', index: 'CreatedDate', formatter: 'date' },
                    { name: 'Status', index: 'Status' },
                    { name: 'Priority', index: 'Priority' },
                    { name: 'File', index: 'File'  ,
                        edittype:'select', 
                        formatter: returnHyperLink  }
                     
                    
        ],
        hidegrid: false,
        pager: jQuery('#ticketingPager'),
        sortname: 'Description',
        rowNum: 5,
        rowList: [10, 20, 50, 100],
        sortorder: "desc", 
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