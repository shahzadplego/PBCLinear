$(document).ready(function () {
    var addCustomPartMessage = $('.cart-message-wrap-modify-part').html();
    magnificPopup = $.magnificPopup.instance;

    $('.product-meta__links--add-custom-part').magnificPopup({
        items: {
            src: addCustomPartMessage,
            type: 'inline'
        }
    });
    $('.js-print').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        window.print();
    });
    $('.btn-add-to-quote-custom').on('click', function () {
        onAddToQuoteCustomClick();
    });
})

function onAddToQuoteCustomClick() {
    __doPostBack("btnAddToQuoteCustom", "AddCustomPart");
}


function showAddExistingPartDialog() {
    $.magnificPopup.open({
        items: {
            src: $('.cart-message-wrap').html()
        },
        type: 'inline'
    }, 0);
};
