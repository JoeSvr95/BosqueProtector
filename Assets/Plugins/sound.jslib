var csharp = {
    StartAudio: function(station) {
        start_sound(station);
    },

    StopAudio: function() {
        stop_sound();
    }
}

mergeInto(LibraryManager.library, csharp);