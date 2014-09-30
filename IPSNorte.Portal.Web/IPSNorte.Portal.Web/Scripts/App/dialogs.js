function showAddCommentDialog(ticketId) {
    $('<div id="myDialog"></div>').appendTo('body').dialog({
        //autoOpen: false,
        modal: true,
        closeOnEscape: true,
        title: "Add comment",
        open: function () {
            $(this).html('').load('/Ticketing/AddComment/' + ticketId);
        },
        focus: function () {
            $(':input', this).keyup(function (event) {
                if (event.keyCode == 13) {
                    $('.ui-dialog-buttonpane button:first').click();
                }
            });
        }
    });
}

function showAlertDialog(dialogId) {

    $(dialogId).show();

    $(dialogId).dialog({
        modal: true,
        buttons: {
            Ok: function() {
                $(this).dialog("close");
            }
        }
    });
}
