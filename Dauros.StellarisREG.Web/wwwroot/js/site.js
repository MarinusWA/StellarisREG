// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    //console.info("Document Ready");

    $('#dlcselect').multiselect({
        includeSelectAllOption: false,
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search DLC...',
        maxHeight: 400,
        buttonWidth: '100%',
        nonSelectedText: 'Select DLC',
        allSelectedText: 'All DLC selected',
        nSelectedText: 'DLC selected'
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

function getCookie(name) {
    const value = document.cookie
        .split('; ')
        .find(row => row.startsWith(name + '='));
    return value ? decodeURIComponent(value.split('=')[1]) : null;
}

function hookPreSelectEvents() {

    $('#originselect').multiselect({
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search...',
        maxHeight: 400,
        buttonWidth: '100%',
        nonSelectedText: 'Any', // Button text if nothing selected
        includeSelectAllOption: false,
        multiple: false,
        maxSelectable: 1,
        onChange: function (option, checked, select) {
            var selectedValue = $(option).val();
            // Now you can do something with this value
            refreshPreSelect(selectedValue);
        }
    });

    $('#ethicselect').multiselect({
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search...',
        maxHeight: 400,
        buttonWidth: '100%',
        nonSelectedText: 'Select Ethics',
        nSelectedText: 'Ethic selected',
        includeSelectAllOption: false,
    });

    $('#ps_ethics :checkbox').change(function () {
        refreshPreSelect($(this).val());
    });

    $('#authselect').multiselect({
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search...',
        maxHeight: 400,
        buttonWidth: '100%',
        nonSelectedText: 'Any', // Button text if nothing selected
        includeSelectAllOption: false,
        multiple: false,
        maxSelectable: 1,
        onChange: function (option, checked, select) {
            var selectedValue = $(option).val();
            // Now you can do something with this value
            refreshPreSelect(selectedValue);
        }
    });

        


    //Setup the multiselect for the species
    $('#phenotypeselect').multiselect({
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search...',
        maxHeight: 400,
        buttonWidth: '100%',
        nonSelectedText: 'Any', // Button text if nothing selected
        includeSelectAllOption: false,
        multiple: false,
        maxSelectable: 1,
        onChange: function (option, checked, select) {
            var selectedValue = $(option).val();
            // Now you can do something with this value
            refreshPreSelect(selectedValue);
        }
    });

    //Setup the multiselect for the civics
    $('#traitselect').multiselect({
        includeSelectAllOption: false,
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search Traits...',
        maxHeight: 900,
        buttonWidth: '100%',
        nonSelectedText: 'Select Traits',
        nSelectedText: 'Traits selected'
    });

    $('#ps_traits :checkbox').change(function () {
        refreshPreSelect($(this).val());
    });

    //Setup the multiselect for the civics
    $('#civicselect').multiselect({
        includeSelectAllOption: false,
        enableFiltering: true,
        enableCaseInsensitiveFiltering: true,
        filterPlaceholder: 'Search Civics...',
        maxHeight: 900,
        buttonWidth: '100%',
        nonSelectedText: 'Select Civics',
        nSelectedText: 'Civic selected'
    });

    $('#ps_civics :checkbox').change(function () {
        refreshPreSelect($(this).val());
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
        if (cb.checked) checkedEthics.push(cb.value);
    });

    //Get Authority
    var checkedAuthority = $("#authselect").val();
    var checkedOrigin = $("#originselect").val();
    var checkedPhenotype = $('#phenotypeselect').val();

    //Get Civics
    var checkedCivics = [];
    $('#ps_civics :checkbox').each(function (idx, cb) {
        //console.log(idx + " " + cb.value + ": " + cb.checked);
        if (cb.checked) checkedCivics.push(cb.value);
    });

    //Get Civics
    var checkedTraits = [];
    $('#ps_traits :checkbox').each(function (idx, cb) {
        //console.log(idx + " " + cb.value + ": " + cb.checked);
        if (cb.checked) checkedTraits.push(cb.value);
    });

    var psdata = {
        selectedDLC: checkedDLC,
        selectedEthics: checkedEthics,
        selectedAuthority: checkedAuthority,
        selectedPhenotype: checkedPhenotype,
        selectedOrigin: checkedOrigin,
        selectedCivics: checkedCivics,
        selectedTraits: checkedTraits
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