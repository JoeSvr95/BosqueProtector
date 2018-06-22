var csharp = {
    StartAudio: function(server) {
        console.log("Reproduciendo");
        var audio = document.getElementById('audio');
        var source = document.getElementById('source');
        source.setAttribute('src', Pointer_stringify(server));
        audio.play();
        console.log("LIVE");
    },

    StopAudio: function() {
        var audio = document.getElementById('audio');
        audio.pause();
    }
}

mergeInto(LibraryManager.library, csharp);