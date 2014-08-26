function showGrid() {
    $('#ticketingGrid').jqGrid({
        caption: "Ticketing system",
        colNames: ['ID','Description','Number','ProjectNumber','CreatedBy','CreatedDate','Status','Priority'],
        colModel: [
                    { name: 'ID', index: 'ID' },

                    { name: 'Description', index: 'Description', width: 300 },
                    { name: 'Number', index: 'Number' },
                    { name: 'ProjectNumber', index: 'ProjectNumber' },
                    { name: 'CreatedBy', index: 'CreatedBy' },
                    { name: 'CreatedDate', index: 'CreatedDate', formatter: 'date' },
                    { name: 'Status', index: 'Status' },
                    { name: 'Priority', index: 'Priority' },
                    
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
       { multipleSearch: true },
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
});