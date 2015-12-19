var interval;

$(function () {
    interval = AddRefreshInterval();
    AddJouerCarteCartesMain();
    AddPopoverDefausse();
});

function DonnerDe() {
    /* version test */
    $(".de-en-main").click(function () {
        if ($(this).attr("data-valeur") === "D") {
            //popupSelectAdversaire();
            var cible = prompt("A qui voulez vous donner ce dé?");
            $.ajax({
                type: "GET",
                url: "/Plateau/DonnerDe?cible=" + cible,
                data: cible,
                contentType: "application/json",
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
        }
    });

    /*
    var select = $('<select>');
    var adversaires = $('.adversaire').text();
    for (var adv in adversaires) {
        var option = $('<option>');
        $(option).val(adv);
        $(select).append(option);
    }
    */
}

function AddRefreshInterval() {
    setInterval(function () {
        var html = $('#game-container').get('/Plateau/RefreshPlateau');
        if (html !== null || html !== 'undefined') {
            $('#game-container').html(html);
            AddJouerCarteCartesMain();
        }
    }, 2000);
}

function AddPopoverDefausse() {
    var content = "";
    content += '<img src="/Images/carte' + $(this).attr('data-code-effet') + '.svg"/>';
    content += '<p><strong>EffetComplet : </strong><br/>' + $(this).attr('data-effet-complet') + '</p>';
    content += '<p><strong>Cout : </strong>' + $(this).attr('data-cout') + ' M </p>';

    $('#defausse').popover({
        html: true,
        trigger: "click",
        placement: "left",
        title: "" + $(this).attr('data-effect'),
        content: content
    });
}

function AddJouerCarteCartesMain() {
    $(".carte-en-main").dblclick(function () {
        clearInterval(interval);
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
            //selectAdversaire();
            var person = prompt("Entrez le nom de votre adversaire", "");
            if (person != null) {
                cible = person;
            }
        }

        donnees += cible + ':';

        if (typeid == 2) {
            //popupSelectSens();
            var sens = prompt("Entrez le sens choisi (G ou D)", "");
            if (sens != null) {
                sensChoisi = sens;
            }
        }

        donnees += sensChoisi;


        $.ajax({
            type: "GET",
            url: "/Plateau/JouerCarte?donnees=" + donnees,
            data: {},
            contentType: "application/json",
            dataType: "json",
            success: function () {
                alert("SUCCESS");
                interval();
            },
            error: function () {
                alert("FAIL");
            }
        })

    });
}