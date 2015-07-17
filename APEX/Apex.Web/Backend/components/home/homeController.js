(function () {
    'use strict';
    angular.module(modules.home, [])
        .controller(controllers.home, ['$scope', function ($scope) {
            $scope.$root.title = 'Apex | Home';
            $scope.translation = resources;
            var vm = this;

            vm.initialize = function () {
                vm.authenticated = false;
            }
        }]);
})();
