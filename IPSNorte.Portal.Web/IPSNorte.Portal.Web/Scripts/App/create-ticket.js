
$("#btnSubmit").button().click(function () { 

    return ValidateFile();

});


$("#btnCreate").button().click(function() {
    var form = $('#createForm');
    if (!(form).valid()) {
        return false;
    }

    var c = this;
    form.submit();
});