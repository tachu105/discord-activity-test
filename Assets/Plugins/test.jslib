mergeInto(LibraryManager.library, {

  ChangeURL: function (url) {
    window.history.pushState({}, '', UTF8ToString(url))
  },

});