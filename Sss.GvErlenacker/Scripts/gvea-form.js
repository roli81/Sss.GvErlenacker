$(document).ready(function () {

    changeSponsorType();

    $('select#SponsorType').change(changeSponsorType);


    $('button#submitButton').click(function (e) {

        $('p.error-msg').fadeOut('slow');
        var valid = true;

        $('.mandatory').each(function (i, element) {
            if ($(element).val() === '') {
                valid &= false;
                $(element).next('p.error-msg').text('Bitte füllen sie dieses Feld aus').fadeIn('slow');
            }
        });


        $('.email').each(function (i, element) {

            if ($(element).val() !== '') {
                var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

                if (!regex.test($(element).val())) {
                    valid &= false;
                    $(element).next('p.error-msg').text('Bitte geben Sie eine gültige Email-Adresse ein.').fadeIn('slow');
                }
            }

        });

        if (!valid) {
            e.preventDefault();
        }


    });


});


function changeSponsorType() {
    let selection = $('select#SponsorType').val();


    switch (selection) {

        case 'Business':
            $('div#business-panel').fadeIn();
            $('input#Company').addClass('mandatory');
            $('div#webSite').hide();
            break;

        case 'Link':
            $('div#business-panel').fadeIn();
            $('input#Company').addClass('mandatory');
            $('input#Website').addClass('mandatory');
            $('div#webSite').fadeIn();
            break;

        default:
            $('div#business-panel').hide();
            $('input#Company').removeClass('mandatory');
            $('input#Website').removeClass('mandatory');
            $('div#webSite').hide();

            break;
    }

}