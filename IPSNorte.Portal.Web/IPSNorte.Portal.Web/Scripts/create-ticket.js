function getNameFromPath(strFilepath) {
    var objRE = new RegExp(/([^\/\\]+)$/);
    var strName = objRE.exec(strFilepath);

    if (strName == null) {
        return null;
    }
    else {
        return strName[0];
    }
}
$("#btnSubmit").button().click(function () { 

    return ValidateFile();

});


$("#btnCreate").button().click(function () {
    var ret =  ValidateFile();

    if (!ret) {
        alert("Please upload file");

    } else { 
        var form = $('#createForm');
        if (!(form).valid()) {
            return false;
        }
        debugger

        var c = this;
        form.submit(); 
    }
    

});

function ValidateFile() {
    if ($('#fileToUpload').val() == "") {
        $("#spanfile").html("Please upload file");
        return false;
    }
    else {
        var file = getNameFromPath($("#fileToUpload").val());
        if (file != null) {
            return true;
        }
        return false;
    }
}