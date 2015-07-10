'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', []).service('translationService', '$resource', function ($resource) {
    this.getTranslation = function($scope, language) {
        var languageFilePath = 'somepath_' + language + '.json';
        $resource(languageFilePath).get(function (data) {
            $scope.translation = data;
        });
    };
});