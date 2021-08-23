﻿$(document).ready(function () {

    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();

    connection.on("NewTeamMemberAdded", function (member, memberId) {
        createNewLine(member, memberId);
    });

    connection.start().then(function () {
        console.log('Connection Started')
    }).catch(function (err) {
        return console.error(err.toString());
    });

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
               
                $("#nameField").val("");
                document.getElementById("createButton").disabled = true;
            },
            error: function (err) {
                console.log(err);
            }
        })

    });

    $("#clearButton").click(function ClearFields() {
        document.getElementById("nameField").value = "";
        document.getElementById("createButton").disabled = true;
    });

    $("#editClassmate").on("click", "#submit", function () {
        console.log('submit changes to server');
        const id = $('#editClassmate').attr('member-id');
        console.log(id);
        const newName = $('#classmateName').val();
        $.ajax({
            url: "/Home/UpdateMemberName",
            method: "POST",
            data: {
                memberId: id,
                name: newName
            },
            success: function (result) {
                location.reload();
            }
        })
    })

    $("#editClassmate").on("click", "#cancel", function () {
        console.log('cancel changes');
    })

    $("#teamList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');
        var id = targetMemberTag.attr('member-id');
        var currentName = targetMemberTag.find(".memberName").text();
        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal('show');
    })
});

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

function createNewComer(member) {
    // Remember string interpolation
    $("#teamList").append(
        `<li class="member" member-id="${member.id}">
        <span class="memberName">${member.name}</span>
        <span class="delete fa fa-remove" onclick="deleteMember("${member.id}")"></span>
        <span class="edit fa fa-pencil"> </span>
        </li>`);
}
//$("#clear").click(function () {
//    $("#newcomer").val("");
//})

function createNewLine(member, memberId) {
    $("#teamList").append(
        `<li class="member" member-id=${memberId}>
<span class="name" >${member}</span>
<span class="delete fa fa-remove" onclick="deleteMember(${memberId})"></span>
<span class="pencil fa fa-pencil"></span>
</li>`);
}