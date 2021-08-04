$(document).ready(function () {
    
    $("#createButton").click(function () {
        var newcomerName = $("#nameField").val();



        
       

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            
            data: {
                "name": newcomerName
            

            },
            success: function (result){
                $("#teamList").append(`<li>${newcomerName}</li>`);


                    $("#nameField").val("");
            }

        })




       
    })
});