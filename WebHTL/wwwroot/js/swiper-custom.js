define(['jquery', 'swiper'], function ($) {
    $(document).ready(function () {
        var mySwiper = new Swiper('.swiper-container', {
            slidesPreview: 3,
            spaceBetween: 30,
            slidesPergroup: 3,
            loop: true,
            loopFillGroupWithBlank: true,
            pagination: {
                el: ".swiper-pagination",
                clickable: true,
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });
    });
});