$(document).ready(function () {

    updateButtons();

});

//page callback hook provided by ASP.NET
function pageLoad(sender, args) {
    if (args.get_isPartialLoad()) {
        updateButtons();
    }
}

function updateButtons() {

    //for each table row, find the td with Unprocessed, get the parent (tr) and find the cancel button on this row and disable it.
    $('tr').each(function () {
        $('.status:not(td[innerHTML="Unprocessed"])', this).parent().find('.cancel').attr("disabled", "disabled");
    });

    $('.next').removeAttr('disabled');

}

