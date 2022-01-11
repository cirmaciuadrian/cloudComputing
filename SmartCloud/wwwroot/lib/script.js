$(document).ready(function () {
    var $web = $(".web-cointainer");
    $web.on("click", ".btn-add-clasa", function () {
        var maxCap = $web.find(".clasa-capacitate").val();
        var nume = $web.find(".clasa-nume").val();
       
        $.ajax({
            url: "/home/AddClass",
            data: {
                name: nume,
                capacity: maxCap
            },
            type: "POST",

        })


            .done(function (response) {
                alert(response.msg)
                location.reload();
            })
            .fail(function (response) {
                alert(response.msg)
            });
    });


})