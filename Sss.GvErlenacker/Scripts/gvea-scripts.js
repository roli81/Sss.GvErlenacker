$(document).ready(function() {

    if (!localStorage.getItem("popupShowed")) {
        $.magnificPopup.open({
            items: {
                src: '#cookie-banner'
            },
            type: 'inline'
        });
        localStorage.setItem("popupShowed", true);
    }

    $('.lightbox').magnificPopup({
        type: 'image'
    });


    $('.gallery').magnificPopup({
        type: 'image',
        gallery: {
            enabled: true
        }
    });

    $('.open-popup-link').magnificPopup({
        type: 'inline',
        midClick: true,
   
 
    }).click(function() {
        $('#SearchQuery').focus();
    });


    var lastTop = $('header').height();
    var toolBarPosition = $('div.tool-bar').position();
    $(window).scroll(function (e) {

        console.log($(this).scrollTop());

  

        if ($(this).scrollTop() > 0) {
            $('.tool-bar').hide();
            $('header').slideUp(200, function() {
                $('.tool-bar').css('top', 0).show();
            });
    
        } else {
            $('header').slideDown(200, function() {
                $('.tool-bar').css('top', lastTop);
            });

        }
    });


});