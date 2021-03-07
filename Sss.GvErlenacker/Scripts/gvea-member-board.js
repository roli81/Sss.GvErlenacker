$(document).ready(function() {

    $('.open-contact-popup').click(function () {
        $('input#Key').val($(this).data('key'));
    });


    $('.open-contact-popup').magnificPopup({
        type: 'inline',
        midClick: true,
    });

});