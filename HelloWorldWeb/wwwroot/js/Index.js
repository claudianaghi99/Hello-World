$(document).ready(function () {

    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();


        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMemeberHere",
            data: { name: newcomerName }
        })
            .done(function (msg) {
                alert("Data Saved: " + msg);
                $("#teamList").append(`
                <li class="member">

                <span class="memberName">
                    ${newcomerName}
                </span>
                <span class="delete fa fa-remove"></span>
                <span class="remove fa fa-pencil"></span>

                 </li>`);

                $("#nameField").val("");
            });
    })

    $("#clearButton").click(function ClearFields() {

        document.getElementById("nameField").value = "";
    });
});
