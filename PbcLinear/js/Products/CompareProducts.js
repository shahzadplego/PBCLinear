$(initializePage);

function initializePage() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    toggleToolbarLinks(0);
}

function EndRequestHandler(sender, args) {
    setRowHeight();
}

function showAddToQuoteSuccessMessage(productSelectionsCount) {
    $.magnificPopup.open({
        items: {
            src: $('.cart-message-wrap').html()
        },
        type: 'inline'
    }, 0);
    toggleToolbarLinks(productSelectionsCount);
}

function toggleToolbarLinks(productSelectionsCount) {
    if (productSelectionsCount > 0) {
        $('.reset-button-inactive').hide();
        $('.reset-button-active').show();
        $('.add-to-quote-button-inactive').hide();
        $('.add-to-quote-button-active').show();
    } else {
        $('.reset-button-inactive').show();
        $('.reset-button-active').hide();
        $('.add-to-quote-button-inactive').show();
        $('.add-to-quote-button-active').hide();
    }
}