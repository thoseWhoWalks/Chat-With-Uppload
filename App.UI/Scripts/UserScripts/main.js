var heap = $(".heap");
var navigation = $("nav");
var userData = [];
var currentUser;
var gallaryItems = $(".galaryItem");
var gallary = $(".gallary"); 

$(function () {
    new ScrollFlow(); 

    gallaryItems.each(function () {
        $(this).mouseenter(function () {
            $(this).animate({
                opacity: "1"
            }, 500)
        });
        $(this).mouseleave(function () {
            $(this).animate({
                opacity: "0.8"
            }, 500)
        });

    });

})
