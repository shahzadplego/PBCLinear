//check width for resize
var windowWidth;

//functions not dependent on window size
$(document).ready(function () {
    windowWidth = $(window).width();
    nameNav();
    addExpander();
    expanderNav();
    checkSize();
});

function nameNav() {
    $('.main-nav > ul').addClass('primary-nav').children('li').addClass('primary-nav__item');
    $('.primary-nav__item > ul').addClass('secondary-nav').children('li').addClass('secondary-nav__item');
    $('.secondary-nav__item > ul').addClass('tertiary-nav').children('li').addClass('tertiary-nav__item');
}

////run resize functions
$(window).resize(function () {
    if (windowWidth != $(window).width()) {
        windowWidth = $(window).width();
        checkSize();
    }
}).resize();

function checkSize() {
    if (Modernizr.mq('only screen and (min-width: 1025px)') || $(window).width() > 1024) {
        desktopNav();
    }
    else {
        mobileNav();
    }
}


//add expander element for secondary nav
function addExpander() {
    $('.primary-nav__item').each(function () {
        if ($(this).children('ul').length > 0) {
            //$(this).append('<div class=\"secondary-expander\"><img src=\"/PbcLinear/img/svg/grey_nav_arrow.svg\" class=\"nav-expander__image\" alt=\"Navigation Arrow\" /></div>');
            $(this).append('<div class=\"secondary-expander\"></div>');
        }
    })
    $('.secondary-nav__item').each(function () {
        if ($(this).children('ul').length > 0) {
            //$(this).append('<div class=\"tertiary-expander\"><img src=\"/PbcLinear/img/svg/grey_nav_arrow.svg\" class=\"nav-expander__image\" alt=\"Navigation Arrow\" /></div>');
            $(this).append('<div class=\"tertiary-expander\"></div>');
        }
    })
}


//open secondary nav when clicking expander
function expanderNav() {
    $('.secondary-expander').unbind('click').on('click', (function (e) {
        if ($(this).hasClass('expander-open')) {
            $(this).removeClass('expander-open').siblings('.secondary-nav').css({ height: '0' }).children().find('.tertiary-expander').removeClass('expander-open').siblings('.tertiary-nav').css({ height: '0' });
        }
        else {
            $('.secondary-expander').removeClass('expander-open').siblings('.secondary-nav').css({ height: '0' }).children().find('.tertiary-expander').removeClass('expander-open').siblings('.tertiary-nav').css({ height: '0' });
//            $('.secondary-expander').removeClass('expander-open').siblings('.secondary-nav').stop(true, true).animate({ height: '0' }, 100);
            //var subHeight = 0;
            //var allHeight = $(this).siblings('.secondary-nav').find('.secondary-nav__item').each(function () {
            //    var thisHeight = $(this).outerHeight();
            //    subHeight = thisHeight += subHeight;
            //});
            e.preventDefault();
            e.stopPropagation();
            $(this).addClass('expander-open').siblings('.secondary-nav').css({ height: "auto" });
            //$(this).addClass('expander-open').siblings('.secondary-nav').stop(true, true).delay(100).animate({ height: subHeight }, 250);
        }
    })
    );
    tertiaryExpander();
}

function tertiaryExpander() {
    $('.tertiary-expander').unbind('click').on('click', (function (e) {
        if ($(this).hasClass('expander-open')) {
            $(this).removeAttr('style').removeClass('expander-open').siblings('ul').stop(true, true).animate({ height: '0' }, 100);
        }
        else {
            $('.tertiary-expander').removeAttr('style').removeClass('expander-open').siblings('.tertiary-nav').removeAttr("style");
            //$('.tertiary-expander').removeClass('expander-open').siblings('.secondary-nav').stop(true, true).animate({ height: '0' }, 100);
            //var subHeight = 0;
            //var allHeight = $(this).siblings('.tertiary-nav').find('.tertiary-nav__item').each(function () {
            //    var thisHeight = $(this).outerHeight();
            //    subHeight = thisHeight += subHeight;
            //});
            e.preventDefault();
            e.stopPropagation();
            $(this).css({ content: "url(/PbcLinear/img/svg/circle-arrow-up.svg)" }).addClass('expander-open').siblings('.tertiary-nav').css({ height: "auto" });
            //$(this).addClass('expander-open').siblings('.tertiary-nav').stop(true, true).delay(100).animate({ height: subHeight }, 250);
        }
    })
    );
}


function desktopNav() {
    $('.secondary-expander').removeClass('expander-open').siblings('.secondary-nav').css({ height: '0' }).children().find('.tertiary-expander').removeAttr('style').removeClass('expander-open').siblings('.tertiary-nav').css({ height: '0' });

    $('.nav-wrap').removeClass('nav-open').removeAttr('style');
    $('.primary-nav__item').off('mouseenter mouseleave');
    $('.primary-nav__item').hover(function (e) {
        var secondaryHeight = 0,
        tertHeight = 0;

        secondaryItems = $(this).find('.secondary-nav__item').each(function () {
            var thisHeight = $(this).outerHeight();
            secondaryHeight = thisHeight += secondaryHeight;

            tertItems = $(this).children('.tertiary-nav').each(function () {
                var thisHeight = $(this).outerHeight();
                tertHeight = thisHeight += tertHeight;
            });

        });

        var subHeight = secondaryHeight + tertHeight;

        e.preventDefault();
        e.stopPropagation();
        //$(this).find('.secondary-nav').css("height", "auto").siblings('.nav-expander').addClass('expander-open');

        $(this).find('.secondary-nav').stop(true, true).delay(100).animate({ height: subHeight }, 250).siblings('.nav-expander').addClass('expander-open');
    },
    function (e) {
        e.preventDefault();
        e.stopPropagation();
        $(this).find('.secondary-nav').stop(true, true).animate({ height: '0' }, 100).siblings('.nav-expander').removeClass('expander-open');
    });
}

function tertiaryNav() {
    $('.tertiary-expander').removeClass('expander-open').siblings('ul').stop(true, true).animate({ height: '0' });
    $('.secondary-nav__item').off('mouseenter mouseleave');
    $('.secondary-nav__item').hover(function (e) {
        var subHeight = 0;
        var allHeight = $(this).find('.tertiary-nav__item').each(function () {
            var thisHeight = $(this).outerHeight();
            subHeight = thisHeight += subHeight;
        });

        e.preventDefault();
        e.stopPropagation();
        $(this).find('.tertiary-nav').stop(true, true).delay(100).animate({ height: subHeight }, 250).siblings('.nav-expander').addClass('expander-open');
    },
    function (e) {
        e.preventDefault();
        e.stopPropagation();
        $(this).find('.tertiary-nav').stop(true, true).animate({ height: '0' }, 100).siblings('.nav-expander').removeClass('expander-open');
    });
}



function mobileNav() {
    $('.primary-nav__item').unbind('mouseenter mouseleave');
    $('.nav-wrap').removeClass('nav-open').removeAttr('style');
    $(this).removeClass('nav-open');

    $('.secondary-expander').removeClass('expander-open').siblings('.secondary-nav').css({ height: '0' }).children().find('.tertiary-expander').removeClass('expander-open').siblings('.tertiary-nav').css({ height: '0' });

    $('.nav-launch').removeClass('nav-open').unbind('click').on('click', (function (e) {

        var mobileNavHeight = 0;
        var childrenHeight = $('.nav-consultant, .main-nav, .utility-nav').children().each(function () {
            var thisHeight = $(this).outerHeight();
            mobileNavHeight = thisHeight += mobileNavHeight;
        });

        e.preventDefault();
        e.stopPropagation();

        if ($(this).hasClass("nav-open")) {
            $(this).removeClass('nav-open');
            $('.nav-wrap').css('overflow', 'hidden').stop(true, true).animate({ height: 0 }, 100);
            $('.nav-expander').removeClass('expander-open').siblings('ul').stop(true, true).animate({ height: '0' }, 100);
        } else {
            $(this).addClass("nav-open");
            $('.nav-wrap').css('overflow', 'inherit').stop(true, true).animate({ height: mobileNavHeight }, 250);
        }
    })
    );
}