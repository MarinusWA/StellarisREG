// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    console.info("Document Ready");

    $('#dlcselect').multiselect({
        buttonWidth: '100%',
        nonSelectedText: 'No DLC selected.',
        allSelectedText: 'All DLC selected.',

    });

    $('#ps_dlc :checkbox').change(function () {
        refreshPreSelect($(this).val());
    });

    $("#generate").click(function () {
        var jq_ps = $("#preselect");
        if (jq_ps.is(":visible")) {
            jq_ps.hide(400);
        }
        else {
            $([document.documentElement, document.body]).animate({
                scrollTop: $("#empirelist").offset().top
            }, 400);
        }
        generateEmpireList();
        
    });

    $("#showselect").click(function () {
        $("#preselect").show(400);
        $([document.documentElement, document.body]).animate({
            scrollTop: $("#preselect").offset().top
        }, 400);
    });

    hookPreSelectEvents();

});



function hookPreSelectEvents() {
    
    //Hook refresh on ethic or civic pick
    $('#preselect :checkbox').change(function () {
        var label = $(this).parent().children("label");
        refreshPreSelect(label.text());
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
        refreshPreSelect(label.text());
        
    });

    //Hook refresh on archetype pick
    $("#ps_archetype :radio").change(function () {
        var label = $(this).parent().children("label");
        refreshPreSelect(label.text());
    });

    //Hook refresh on origin pick
    $("#ps_origin :radio").change(function () {
        var label = $(this).parent().children("label");
        refreshPreSelect(label.text());
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
    var checkedArchetype = $("#ps_archetype :radio:checked").val();

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
        selectedArchetype: checkedArchetype,
        selectedOrigin: checkedOrigin,
        selectedCivics: checkedCivics
    };
    
    return psdata;
}

function generateEmpireList(amount) {
    var psdata = scanPreselect();
    renderGenerating();
    //console.log(psdata);
    $.ajax({
        type: 'POST',
        url: '/Index?handler=EmpireList',
        data: psdata,
        success: function (result) {
            renderEmpireList(result);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}

function renderGenerating() {
    var gen = '<div class="spinner-border" role="status"><span class="sr-only"> Loading...</span></div>';
    $('#empirelist').html(gen);
    $('#empirelist').fadeIn(100);
}


function renderEmpireList(htmldata) {
    
    $('#empirelist').html(htmldata);
    
}

function refreshPreSelect(ppick) {
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
}