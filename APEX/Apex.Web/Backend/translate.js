(function() {
    'use strict';
    angular.module('apex-app', []).config(['$translateProvider', translateConfig]);

    function translateConfig($translateProvider) {
        $translateProvider.translations('en', {
            hello_message: "Howdy",
            goodbye_message: "Goodbye"
        });
        $translateProvider.translations('es', {
            hello_message: "Hola",
            goodbye_message: "Adios"
        });
        $translateProvider.useSanitizeValueStrategy(null);
        $translateProvider.preferredLanguage("en");
    }
})();