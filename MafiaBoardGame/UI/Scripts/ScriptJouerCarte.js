$(document).ready(function () {
    $(".carte-en-main").dblclick(function () {
        /* $.ajax({
             type: "GET",
             url: "/Plateau/JouerCarte",
             data: $("this").attr("data-id"),
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             async: true,
             cache: false,
             success: function (msg) {
                 alert(msg+"");
             },
         })*/
        alert("Alert");
        console.log($("this").attr("data-id"));
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