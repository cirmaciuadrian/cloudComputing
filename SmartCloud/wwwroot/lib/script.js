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

    $web.on("click", ".btn-add-student", function () {
        var name = $web.find(".student-nume").val();
        var age = $web.find(".student-age").val();
        var classId = $web.find(".class-id").val();
        $.ajax({
            url: "/student/AddStudent",
            data: {
                name: name,
                age: age,
                classId: classId
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