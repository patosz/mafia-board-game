var interval;

$(function () {
    isMyTurn();
});

function PopoverCartesMain() {
    var content = "";
    content += '<img src="/Images/carte' + $(this).attr('data-code-effet') + '.svg"/>';
    content += '<p><strong>EffetComplet : </strong><br/>' + $(this).attr('data-effet-complet') + '</p>';
    content += '<p><strong>Cout : </strong>' + $(this).attr('data-cout') + ' M </p>';

    $('#defausse').popover({
        html: true,
        trigger: "click",
        placement: "top",
        title: "" + $(this).attr('data-effect'),
        content: content
    });
}

function PopoverDefausse() {
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

function enableCartesMain() {
    $('#vos-cartes').prop('disabled',false);
}

function disableCartesMain() {
    $('#vos-cartes').prop('disabled',true);
}

/*  methodes sequencement   */
function isMyTurn() {
    var joueurActif = $('.adversaire-actif').text();
    var moi = $('#votre-nom').text();
    if (moi === joueurActif) {
        clearInterval(interval);
        startTurn();
    } else {
        alert("C'est le tour de "+joueurActif);
        interval = RefreshInterval;
        interval();
    }
}

function startTurn() {
    $('#btn-lancer-des').show();
    alert("C'est votre tour");
}

function checkVainqueur() {
    var vainqueur = $('#vainqueur').text();
    if (vainqueur !== null && vainqueur !== 'undefined' && vainqueur.length > 0) {
        alert("Le vainqueur est : " + vainqueur);
        window.location = '/Partie/Index';
    }
}

function DonnerDe() {
    alert("in donner de");
    var nbDesADonner = $('.de-en-main[data-valeur = D]');

    for(var i =0; i < nbDesADonner;i++){
        var cible = prompt("A qui voulez vous donner ce dé?");
        $.ajax({
            type: "GET",
            async : false,
            url: "/Plateau/DonnerDe",
            data: "?cible=" + cible,
            success: function () {
                alert("SUCCESS");
            },
            error: function () {
                alert("FAIL");
            }
        });
    }

    $('.game-container').load('/Plateau/RefreshPlateau');
    enableCartesMain();
}

function RefreshInterval() {
    setInterval(function () {
        $('.game-container').load('/Plateau/RefreshPlateau');
        console.log("Refresh");
        checkVainqueur();
        RefreshActions();
     }, 2000);
}

function JouerCarte() {

    //get clicked object info
    var typeCarte = $(this).attr("data-code-effet");
    var typeCarteInt = Number.parseInt(typeCarte);
    var idCarte = $(this).attr("data-id");
    alert('Type : ' + typeCarte + ' // Id : ' + idCarte);

    //init JSON container        
    var data = {};
    data["typeCarte"] = typeCarte;
    data["carteChoisie"] = idCarte;
    //optional
    data["cible"] = "";
    data["sens"] = "";

    var nb = 0;
    ($(".de-en-main").attr("data-valeur") === "M").each(
        function () {
            nb++;
        }
    );

    if ($(this).attr("data-cout").val() < nb) {
        alert("Vous n'avez pas assez de dés mafia pour jouer cette carte!")
        return;
    }
    if (typeCarteInt === 4 || typeCarteInt === 5 || typeCarteInt === 6 || typeCarteInt === 9) {
        //selectAdversaire();
        var person = prompt("Entrez le nom de votre adversaire", "");
        if (person != null) {
            data["cible"] = person;
        }
    }

    if (typeCarteInt === 2) {
        //popupSelectSens();
        var sens = prompt("Entrez le sens choisi (G ou D)", "");
        if (sens != null) {
            data["sens"] = sens;
        }
    }
    
    var aPasser = JSON.stringify(data);

    $.ajax({
        type: "POST",
        url: "/Plateau/JouerCarte",
        data: "json=" + aPasser,
        cache: false,
        error: function () {
            alert("FAIL");
        }
    }).done(function () {
        DelJouerCarteCartesMain();
        location.reload(true);
        interval();
    });
}

function LancerDes() {
    $('#btn-lancer-des').hide();
    $.ajax({
        type: "GET",
        url: "/Plateau/LancerDes",
    }).done(function () {
        //peut poser pbs
        $('.game-container').load('/Plateau/RefreshPlateau');
        DonnerDe();
    }).fail(
        function (jqCHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    );
}
