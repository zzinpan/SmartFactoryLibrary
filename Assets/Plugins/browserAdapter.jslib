mergeInto(LibraryManager.library, {

    completeSetEventKey: function( responseJson ){
        
        window.dispatchEvent(new CustomEvent('completeSetEventKey', {
            detail: JSON.parse( responseJson )
        }));

    }

});