// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    console.info("Document Ready");

    $('#dlcselect').multiselect({
        buttonWidth: '100%',
        nonSelectedText: 'Choose your DLC here.'
    });

    $('#ps_dlc :checkbox').change(function () {
        refreshPreSelect($(this).val());
    });

    hookPreSelectEvents();

});

function hookPreSelectEvents() {
    
    //Hook refresh on ethic or civic pick
    $('#preselect :checkbox').change(function () {
        var label = $(this).parent().children("label");
        if (label.hasClass("ps_prohibited")) {
            console.log("prohibited refresh");
            refreshPreSelect(label.text());
        }
        else {
            console.log("blank refresh");
            refreshPreSelect("");
        }
    });

    //Hook Deselect authority function
    $('#authds').click(function () {
        $('input[id^=auth]').each(function () {
            $(this).prop('checked', false);
        });
        refreshPreSelect();
    });
    //Hook refresh on authority pick
    $("#ps_auth :radio").change(function () {
        var label = $(this).parent().children("label");

        if (label.hasClass("ps_prohibited")) {
            refreshPreSelect(label.text());
        }
        else {
            refreshPreSelect("");
        }
    });

    //Hook refresh on origin pick
    $("#ps_origin :radio").change(function () {
        var label = $(this).parent().children("label");

        if (label.hasClass("ps_prohibited")) {
            refreshPreSelect(label.text());
        }
        else {
            refreshPreSelect("");
        }
    });
}
//
function scanPreselect() {
    //Get DLC
    var checkedDLC = [];
    $('#ps_dlc :checkbox').each(function (idx, cb) {
        //console.log(idx + " " + cb.value + ": " + cb.checked);
        if (cb.checked) checkedDLC.push(cb.value);
    });
    //Get Ethics
    var checkedEthics = [];
    $('#ps_ethics :checkbox').each(function (idx, cb) {
        //console.log(cb.name + ": " + cb.checked);
        if (cb.checked) checkedEthics.push(cb.name);
    });
    //Get Authority
    var checkedAuthority = $("#ps_auth :radio:checked").val();
    var checkedOrigin = $("#ps_origin :radio:checked").val();

    //Get Civics
    var checkedCivics = [];
    $('#ps_civics :checkbox').each(function (idx, cb) {
        //console.log(cb.name + ": " + cb.checked);
        if (cb.checked) checkedCivics.push(cb.name);
    });

    

    var psdata = {
        selectedDLC: checkedDLC,
        selectedEthics: checkedEthics,
        selectedAuthority: checkedAuthority,
        selectedOrigin: checkedOrigin,
        selectedCivics: checkedCivics
    };
    
    return psdata;
}

function generateEmpireList(amount) {
    var psdata = scanPreselect();
    psdata["amount"] = amount;
    
    $.ajax({
        type: 'POST',
        url: '/Home/EmpireList',
        data: psdata,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            renderEmpireList(result);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}

function renderEmpireList(htmldata) {
    $('#empirelist').html(htmldata);
}

function refreshPreSelect(ppick) {
    //$('#ps_dlc input:checkbox').prop("disabled", true);
    
    var psdata = scanPreselect();
    psdata["prohibitedPick"] = ppick;
    console.log(psdata);

    $.ajax({
        type: 'POST',
        url: '/Index?handler=PreSelect',
        data: psdata,
        success: function (result) {
            renderPreSelect(result);
            hookPreSelectEvents();
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}

function renderPreSelect(htmldata) {
    $('#preselect').html(htmldata);
    $('#ps_dlc input:checkbox').each(function () {
        $(this).prop("disabled", false);
    });
}