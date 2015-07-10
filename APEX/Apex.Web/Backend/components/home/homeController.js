(function () {
    'use strict';

    // Google Analytics Collection APIs Reference:
    // https://developers.google.com/analytics/devguides/collection/analyticsjs/

    angular.module(modules.home, [])
        .controller(controllers.home, ['$scope', function ($scope) {
            $scope.$root.title = 'Apex | Home';
            
        }]);
})();
