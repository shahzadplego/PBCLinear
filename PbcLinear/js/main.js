//check width for resize
var windowWidthMain;

$(document).ready(function () {
    setIframeHeight();
    videoPopUp();
    printPage();
    appStoryLink();
    overlayLink();
    configureOverlayLink();
    productTypeLink();
});

$(window).resize(function () {
    if (windowWidthMain != $(window).width()) {
        windowWidthMain = $(window).width();
        setIframeHeight();
        appStoryLink();
    }
}).resize();

//link to application story when div is clicked
function appStoryLink() {
    if (Modernizr.mq('only screen and (min-width: 768px)') || $(window).width() >= 768) {
        $('.hovered-background__content').each(function () {
            var appLink = $(this).children('p').find('a').attr('href');

            $(this).unbind('click').click(function () {
                window.location.href = appLink;
            });
        })
    }
}

//link to product category when div is clicked
function productTypeLink() {
    $('.product-type__item').each(function () {
        var typeLink = $(this).children('a').attr('href');
        $(this).unbind('click').click(function () {
            window.location.href = typeLink;
        });
    })
}

//links for 4 card area when div is clicked
function overlayLink() {
    $('.overlay-parent').each(function () {
        var linkUrl = $(this).children('.overlay-content').children('.overlay-link').find('a').attr('href');
        $(this).unbind('click').click(function () {
            window.location.href = linkUrl;
        });
    })
}

//links for configurator card area when div is clicked open in new window
function configureOverlayLink() {
    $('.configurator-item').each(function () {
        var linkUrl = $(this).children('.overlay-content').children('.overlay-link').find('a').attr('href');
        $(this).unbind('click').click(function () {
            window.open(linkUrl, '_blank');
        });
    })
}


//product comparision, reset "add to quote"
function resetQuote() {
    var checkboxes = $('input:checkbox');

    checkboxes.click(function () {
        if (!checkboxes.is(":checked")) {
            $('.product-comparison__add').css('display', 'none');
        }
        else {
            $('.product-comparison__add').css('display', 'inline-block');
        }
    });
}

//print page from "print" link
function printPage() {
    $('.js-print').unbind('click').click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        window.print();
    });
}

//set iframe height equal to width
function setIframeHeight() {
    var iframeWidth = $('.external-iframe').width();
    $('.external-iframe').height(iframeWidth + 100);
}

//open videos in modal
function videoPopUp() {
    $('.magnific-video').magnificPopup({
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,
        fixedContentPos: false
    });
}



