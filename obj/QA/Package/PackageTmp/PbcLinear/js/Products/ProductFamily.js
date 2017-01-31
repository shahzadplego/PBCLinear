$(initializePage);

function initializePage() {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    toggleToolbarLinks(0);
}

function EndRequestHandler(sender, args) {
    setFilterSize();
    openCloseFilters();
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

function showSelectionLimitWarningMessage(productSelectionsCount) {
    $.magnificPopup.open({
        items: {
            src: $('.cart-message-wrap-modify-part').html()
        },
        type: 'inline'
    }, 0);
    toggleToolbarLinks(productSelectionsCount);
}

function toggleToolbarLinks(productSelectionsCount) {
    if (productSelectionsCount > 0) {
        $('.add-to-quote-button-inactive').hide();
        $('.add-to-quote-button-active').show();
    } else {
        $('.add-to-quote-button-inactive').show();
        $('.add-to-quote-button-active').hide();
    }

    if (productSelectionsCount > 1) {
        $('.compare-button-inactive').hide();
        $('.compare-button-active').show();
    } else {
        $('.compare-button-inactive').show();
        $('.compare-button-active').hide();
    }
}

