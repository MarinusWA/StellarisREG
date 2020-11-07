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

});

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
    $('#ps_ethic input:checkbox').each(function (idx, cb) {
        //console.log(cb.name + ": " + cb.checked);
        if (cb.checked) checkedEthics.push(cb.name);
    });
    //Get Authority
    var checkedAuthority = $("#ps_auth input[name='auth']:checked").val();

    //Get Civics
    var checkedCivics = [];
    $('#ps_civic input:checkbox').each(function (idx, cb) {
        //console.log(cb.name + ": " + cb.checked);
        if (cb.checked) checkedCivics.push(cb.name);
    });

    console.log(checkedDLC);

    var psdata = {
        selectedDLC: checkedDLC,
        selectedEthics: checkedEthics,
        selectedAuthority: checkedAuthority,
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