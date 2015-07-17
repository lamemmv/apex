(function () {
    'use strict';

    angular.module(modules.main, [])
        .controller(controllers.mainController, ['$scope', '$http', function ($scope, $http) {
            $scope.translation = resources;
            var vm = this;
            
        }]);
})();
