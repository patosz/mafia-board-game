$(document).ready(function () {
    $("a").dblclick(function () {
        $.ajax({
            type: "GET",
            url: "/Plateau/JouerCarte",
            data: $("this").attr("idCarte"),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function (msg) {
                alert(msg+"");
            },
        })
        return true;
    })

});