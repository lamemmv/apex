(function () {
    'use strict';
    angular.module(modules.home)
        .controller(controllers.dashboardController, ['$scope', function ($scope) {
            $scope.translation = resources;
            var vm = this;

            vm.initialize = function () {
            }
        }]);
})();
