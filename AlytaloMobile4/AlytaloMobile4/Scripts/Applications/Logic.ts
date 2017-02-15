/// <reference path="../typings/jquery/jquery.d.ts" />


class AddRoomsModel {
    public Huone: string;

}

//function testaus() {
    //$("#Insertbutton").click(function () {
    //    alert("Toimii!");

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
                }
                else {
                    alert("Ei onnnistunut: " + data.error);
                }
            },
            dataType: "json"
        });
    


    
