/// <reference path="../typings/jquery/jquery.d.ts" />
var AddRoomsModel = (function () {
    function AddRoomsModel() {
    }
    return AddRoomsModel;
}());
//function testaus() {
$("#Insertbutton").click(function () {
    alert("Toimii!");
    var huone = $("#Huone").val();
    var data = new AddRoomsModel();
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
            }
            else {
                alert("Ei onnnistunut: " + data.error);
            }
        },
        dataType: "json"
    });
});
