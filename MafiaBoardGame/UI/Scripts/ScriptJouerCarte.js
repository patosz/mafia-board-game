$(document).ready(function () {


    setInterval(function () {
        var html = $('#game-container').get('/Plateau/RefreshPlateau');
        if (html !== null || html !== 'undefined')
            $('#game-container').html(html);
    }, 2000);


    $(".carte-en-main").dblclick(function () {
        var typeid = $("this").attr("data-type-id");
        var carteChoisie = $("this").attr("data-carte-id");
        var joueurPartie = $(".joueurCourant").val();
        var cible = "";
        var deChoisi = "";
        var sensChoisi = "";
        if (typeid == 4 || typeid == 5 || typeid == 6 || typeid == 9 || true) {
            var person = prompt("Entrez le nom de votre adversaire", "");
            if (person != null) {
                cible = person;
            }
        }

        if (typeid == 2) {
            var sens = prompt("Entrez le sens choisi (G ou D)", "");
            if (sens != null) {
                sensChoisi = sens;
            }
        }

        var data = {};
        data["carteId"] = carteChoisie;
        data["cible"] = cible;
        data["deChoisi"] = deChoisi;
        data["sensChoisi"] = sensChoisi;
        data["joueurCourant"] = joueurPartie;

        var dataStr = JSON.parse(data);

        $.ajax({
            type: "GET",
            url: "/Plateau/JouerCarte",
            data: dataStr,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function (msg) {
                alert(msg + "");
            },
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