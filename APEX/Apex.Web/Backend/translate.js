(function() {
    'use strict';
    var apexApp = angular.module('app.translate', []);
    apexApp.config([
        '$translateProvider', translateConfig]);

    function translateConfig($translateProvider) {
        $translateProvider.translations('en', {
            hello_message: "Howdy",
            goodbye_message: "Goodbye"
        });
        $translateProvider.translations('es', {
            hello_message: "Hola",
            goodbye_message: "Adios"
        });
        $translateProvider.useSanitizeValueStrategy('sanitize');
        $translateProvider.preferredLanguage("en");
    }
});