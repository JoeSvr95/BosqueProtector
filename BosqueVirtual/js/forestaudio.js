var server = "http://200.126.14.250:8000/station";
var extension = ".ogg";
var audio = document.getElementById("audio");
var source = document.getElementById("source");

function start_sound(station){
    var server_addr = server + station.toString() + extension;
    source.setAttribute('src', server_addr);
    audio.load();
    audio.play();
}

function stop_sound(){
    audio.pause();
}
function getTemp(id){
    var temperature = 0;
    $.ajax({
        url:"http://localhost:5000/api/Station/" + id + "/Data/lastData",
        type:"GET",
        crossDomain: true,
        async: true,
        contentType: "text/javascript",
        dataType:"json",
        success: function(data) {
            temperature = data[0].Temperature;
        },
        error: function(e){
            console.log(e);
        }
    });
    return temperature;
}
