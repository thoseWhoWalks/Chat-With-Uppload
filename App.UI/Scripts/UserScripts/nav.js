$(function () {
    if ($(this).scrollTop() >= heap.height())
        navigation.css('opacity', '1');
    else
        navigation.css('opacity', '0.8');

    $(window).scroll(function () {
        if ($(this).scrollTop() >= heap.height())
            navigation.css('opacity', '1');
        else
            navigation.css('opacity', '0.8');
    })

});
