$(document).ready(function () {


    setInterval(function () {
        var html = $('#game-container').get('/Plateau/RefreshPlateau');
        if (html !== null || html !== 'undefined')
            $('#game-container').html(html);
    }, 2000);

    $(".carte-en-main").dblclick(function () {
        alert("hahaha");
        var typeid = $(this).attr("data-code-effet");
        var carteChoisie = $(this).attr("data-id");
        var cible = '';
        var sensChoisi = '';
        alert(typeid + '     ' + carteChoisie);
        var donnees = '';
        donnees += typeid + ':';
        donnees += carteChoisie + ':';
        if (typeid == 4 || typeid == 5 || typeid == 6 || typeid == 9) {
            var person = prompt("Entrez le nom de votre adversaire", "");
            if (person != null) {
                cible = person;
            }
        }
        donnees += cible + ':';
        if (typeid == 2) {
            var sens = prompt("Entrez le sens choisi (G ou D)", "");
            if (sens != null) {
                sensChoisi = sens;
            }
        }
        donnees += sensChoisi;
       

        $.ajax({
            type: "GET",
            url: "/Plateau/JouerCarte?json="+donnees.toString(),
            data: donnees,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function () {
                alert("SUCCESS");
            },
            error: function () {
                alert("FAIL");
            }
        })

    });

    $('#pioche').popover({
        html: true,
        trigger: "click",
        placement: "right",
        title: "Carte pioche",
        content: '<img src="/Images/dos_carte.svg"/>'
    });

    $('#defausse').popover({
        html: true,
        trigger: "click",
        placement: "left",
        title: "Carte pioche",
        content: '<img src="/Images/dos_carte.svg"/>'
    });

});