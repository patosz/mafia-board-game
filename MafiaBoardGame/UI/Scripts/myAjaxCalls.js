$(function () {
   
});

function rejoindrePartie() {
    $.ajax({
        url: 'Partie/Rejoindre',
        type: 'GET',
        data: ''+$('#pseudoUser').val(),
        success: function (rep) {
            if (rep !== null && rep.length !== 0)
                loggedIn(rep);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            error(errorThrown);
            loggedOut();
        }
    });
}