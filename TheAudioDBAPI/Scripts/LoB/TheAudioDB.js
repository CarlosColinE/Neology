$(document).ready(function () {

    $("#loaderDiv").hide();

})

$("#button1000").click(function (e) {

    debugger;

    var Artist = $("#inputArtist").val()

    debugger;
    $.ajax({
        type: "GET",
        url: "https://www.theaudiodb.com/api/v1/json/1/search.php?s=" + Artist,
        dataType: "json",
        success: function (result) {

            debugger;
        /*var aa = JSON.parse(result);*/
            var table1 = document.getElementById("mydata");
            table1 = document.getElementById("mydata");
            table1.innerHTML = "";
            table1.innerHTML = '<tr id="[[strArtist]]" onclick="recuperarFila(this.id)">' +
                '<td><center>[[strArtist]]</center></td>' +
                '<td><center>[[strGenre]]</center></td>' +
                '<td><center>[[strCountry]]</center></td>' +
                '<td><center><textarea class="form-control" aria-label="With textarea">[[strBiographyEN]]</textarea></center></td>' +
                '<td><center><img src="[[strArtistThumb]]" width="220" height="250" /></center></td>' +
                '<td><center><button type="button" class="btn-default" id="button1"><i class="fa fa-clipboard"></i></button></center></td>' +
                '<td class="ex1">[[strArtist]]</td>' +
                '</tr>';
            $("#mydata").mirandajs(result.artists[0])
            table = $('#example').DataTable(
                {
                    "responsive": true,
                    searching: false,
                    "deferRender": true
                }
            );

            $("#mydata").show

        }

    });

});


function recuperarFila(idfila) {
    /*debugger;*/
    var elTableRow = document.getElementById(idfila);
    /*debugger;*/
    var elTableCells = elTableRow.getElementsByTagName("td");
    /*debugger;*/
    for (var i = 0; i < elTableCells.length; i++) {
        if (i == elTableCells.length - 1) {
            debugger;
            
                var Artist = elTableCells[i].innerHTML
                                                   
        }
    }

    debugger;
    $.ajax({
        url: "https://theaudiodb.com/api/v1/json/1/discography.php?s=" + Artist,        
        type: "GET",        
        dataType: "json",
        beforeSend: function () {
            $("#loaderDiv").show();
        },
        success: function (result) {
            debugger;            

            var table1 = document.getElementById("mydata1");
            table1 = document.getElementById("mydata1");
            table1.innerHTML = "";
            table1.innerHTML = '<tr>' +
                '<td><center>[[strAlbum]]</center></td>' +
                '<td><center>[[intYearReleased]]</center></td>' +              
                '</tr>';
            $("#mydata1").mirandajs(result.album)  

            /*window.location.href = "/FullArtistInfo/FullInfo";*/
            $("#loaderDiv").hide();
        },
        error: function (errormessage) {
            debugger;
            alert(errormessage.respponseText);
        }
    });    

    //debugger;
    //$.ajax({
    //    url: "../FullArtistInfo/Artist",
    //    data: JSON.stringify(Monitor),
    //    type: "POST",
    //    contentType: "application/json;charset=utf-8",
    //    dataType: "json",
    //    /*contentType: "application/json;charset=utf-8",*/
    //    /*dataType: "json",*/
    //    //beforeSend: function () {
    //    //    $("#loaderDiv").show();
    //    //},
    //    success: function (result) {
    //        debugger;
    //    },
    //    error: function (errormessage) {
    //        debugger;
    //        alert(errormessage.respponseText);
    //    }
    //}); 

 

}