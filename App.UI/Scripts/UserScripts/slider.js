var sliderImg = ['../images/heapBackgroung1.jpg', '../images/heapBackgroung2.jpg', '../images/heapBackgroung3.jpg'];

$(function () {

    var sliderButtons = $(".sliderButton");
    var sliderPointer = 0;

    var sliderId = setInterval(moveSlider, 3000);

    for (let i = 0; i < sliderButtons.length; i++) {
        sliderButtons[i].onclick = function (e) {
            heap.css('background', `url(${sliderImg[parseInt(e.target.id)-1]}) center no-repeat`);
            $("div.active").removeClass("active");
            $(this).addClass("active");
            sliderPointer = parseInt(e.target.id) - 1;
            clearInterval(sliderId);
            sliderId = setInterval(moveSlider, 3000);
        }
    }

    function moveSlider() {
        if (sliderPointer == sliderImg.length - 1)
            sliderPointer = 0;
        else
            sliderPointer++;

        heap.css('background', `url(${sliderImg[sliderPointer]}) no-repeat`);
        $("div.active").removeClass("active");
        $(`#${sliderPointer+1}index`).addClass("active");
    }

});
