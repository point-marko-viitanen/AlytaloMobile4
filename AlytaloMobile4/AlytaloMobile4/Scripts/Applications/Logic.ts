/// <reference path="../typings/jquery/jquery.d.ts" />


class AddRoomsModel {
    public Huone: string;
}

//function testaus() 
function Initroom() {
$("#Insertbutton").click(function () {
    alert("Toimii!");

    var huone: string = $("#Huone").val();
    var data: AddRoomsModel = new AddRoomsModel();
    data.Huone = huone;


    // Lähetetään Json-muotoista dataa palvelimelle 
    $.ajax({
        type: "POST",
        url: "/Hallinta/AddRooms",
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (data) {
            if (data.success == true) {
                alert("Uusi huone asetettu.");
// Päivitys testi
                $.ajax("/Hallinta/AddRooms").done(function (data) {
                    var huonelista = "";
                    for (var i = 0; i < data.lenght + 1; i++) {
                        huonelista += "<tr><td>" + data[i].HuoneNimi + "</td></tr> ";
                        $("#GetRoomList").html(huonelista);
                    }
                        $("GetRoomList").css("display", "block");

                    });
// Päivitys osio
            }
            else {
                alert("Ei onnnistunut: " + data.error);
            }
        },
        dataType: "json"
        });
    });
}


