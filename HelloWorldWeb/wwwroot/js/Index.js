﻿$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();


        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMemeberHere",
            data: { name: newcomerName }
        })
            .done(function (msg) {
                alert("Data Saved: " + msg);
                $("#teamList").append(`<li>${newcomerName}</li>`);
                $("#nameField").val("");
            });


    })
});