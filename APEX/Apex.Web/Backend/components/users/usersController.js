(function () {
    'use strict';

    // Google Analytics Collection APIs Reference:
    // https://developers.google.com/analytics/devguides/collection/analyticsjs/

    angular.module(modules.users, [])
        .controller(controllers.usersController, ['$scope', function ($scope) {
            $scope.$root.title = 'Apex | Login';

        }]);
})();
