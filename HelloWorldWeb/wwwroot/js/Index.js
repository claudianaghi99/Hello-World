﻿$(document).ready(function () {



    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();
        var length = $("#teamMembers").children().length;
        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "name": newcomerName
            },
            success: (result) => {
                console.log(result);
                $("#teamList").append(
                    `<li>
                <span class="memberName">
                        ${newcomerName}
                    </span >
                <span class="delete fa fa-remove" onclick="deleteMember(${length})">
                    </span>
                <span class="edit fa fa-pencil">
                    </span>
                </li>`);
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
            },
            error: function (err) {
                console.log(err);
            }
        })



    });
    $('#submit').click(function () {
        const id = $('#editClassmate').attr('member-id');
        console.log(id);
    });

    $("#teamList").on("click", ".pencil", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        var currentName = targetMemberTag.find(".name").text();
        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })

});

(function () {
    $("#clearButton").click(function () {
        document.getElementById("createButton").disabled = true;
        document.getElementById("nameField").value = "";
    });

}());

function deleteMember(index) {

    $.ajax({
        url: "/Home/RemoveMember",
        method: "DELETE",
        data: {
            memberIndex: index
        },
        success: function (result) {
            location.reload();
        }
    })
}

(function () {
    $('#nameField').on('change textInput input', function () {
        var inputVal = this.value;
        if (inputVal != "") {
            document.getElementById("createButton").disabled = false;
        } else {
            document.getElementById("createButton").disabled = true;
        }
    });
}());

