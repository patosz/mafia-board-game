$(document).ready(function () {
    $(".carte-en-main").dblclick(function () {
        alert("Alert");
        var typeid = $("this").attr("data-type-id");
         var cible;
         var deChoisi;
         if (typeid == 4 || typeid == 5 || typeid == 6 || typeid == 9 || true) {
             cible = GetCibleFunction();
         }
        
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

        //console.log($("this").attr("data-id"));
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
    
    function GetCibleFunction() {
        var retval;
        alert("Clickez sur le nom de l'adveraire pour le cibler")
        $("h3").click(function () {
            while(retval != undefined)
                retval = $("this").text();
        });
        alert("Adversaire choisi : " + retval.text());
        var retval;
    }
});