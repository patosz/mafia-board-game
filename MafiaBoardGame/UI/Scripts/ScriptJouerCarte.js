var interval;

$(function () {
    interval = RefreshInterval;
    interval();
    AddPopoverDefausse();
    addPopoverCartesMain();
});

function checkVainqueur(){

}

function isMyTurn() {
    var joueurActif = $('.adversaire-actif').text();
    var moi = $('#votre-nom').text();
    if (moi.euals(joueurActif)) {
        startTurn();
    }
}

function startTurn() {
    alert("C'est votre tour.");

}

function DonnerDe() {
    /* version test */
    $(".de-en-main").click(function () {
        if ($(this).attr("data-valeur") === "D") {
            //popupSelectAdversaire();
            var cible = prompt("A qui voulez vous donner ce dé?");
            $.ajax({
                type: "GET",
                url: "/Plateau/DonnerDe",
                data: "?cible=" + cible,
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

function RefreshInterval() {
    setInterval(function () {
        $('.carte-en-main').load('/Plateau/RefreshPlateau');
        console.log("Refresh");
    }, 2000);
}

function addPopoverCartesMain() {
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
    $(".carte-en-main").dblclick(JouerCarte);
}

function DelJouerCarteCartesMain(){
    $(".carte-en-main").off("dblclick");
}

function JouerCarte() {
    //stop refresh
    clearInterval(interval);

    alert("hahaha");

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


    alert("YOLO");
    var aPasser = JSON.stringify(data);

    $.ajax({
        type: "POST",
        url: "/Plateau/JouerCarte",
        data: "json=" + aPasser,
        cache: false,
        success: interval(),
        error: function () {
            alert("FAIL");
        }
    })
}

function LancerDes() {
    $(this).hide();
    $.ajax({
        type: "GET",
        url: "/Plateau/LancerDes",
    }).done(function () {
        enableCards();
        RefreshInterval();
    }).fail(
        function (jqCHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    );
}
