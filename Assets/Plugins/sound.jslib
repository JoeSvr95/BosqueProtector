var csharp = {
    StartAudio: function() {
        start_sound();
    },

    StopAudio: function() {
        stop_sound();
    }
}

mergeInto(LibraryManager.library, csharp);