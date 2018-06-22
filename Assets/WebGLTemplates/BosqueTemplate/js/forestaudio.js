var server = "http://localhost:8000/station1.ogg";
var audio = document.getElementById("audio");
var source = document.getElementById("source");

function start_sound(){
    source.setAttribute('src', server);
    audio.load();
    audio.play();
}

function stop_sound(){
    audio.pause();
}
