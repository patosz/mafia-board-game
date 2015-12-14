$(function () {
   
});

function rejoindrePartie() {
    $.ajax({
        url: 'Partie/Rejoindre',
        type: 'GET',
        data: ''+$('#pseudoUser').val(),
        success: function (rep) {
            
        },
        error: function (jqXHR, textStatus, errorThrown) {
            error(errorThrown);
            loggedOut();
        }
    });
}