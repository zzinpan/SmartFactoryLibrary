mergeInto(LibraryManager.library, {

    load: function( id ){
        
        window.dispatchEvent(new CustomEvent('loadSmartFactory', {
            detail: {
                id: id
            }
        }));

    }

});