(function () {
    'use strict';

    angular.module(modules.main, [])
        .controller(controllers.mainController, ['$scope', '$http', '$modal', function ($scope, $http, $modal) {
            $scope.translation = resources;
            var vm = this;
            vm.authenticated = false;
            vm.login = login;

            function login() {
                var modalInstance = $modal.open({
                    templateUrl: '/Backend/components/users/login.html',
                    controller: controllers.loginController,
                    size: 'sm',
                    resolve: {
                        
                    }
                });

                modalInstance.result.then(function (data) {
                    //vm.authenticated = data;
                    vm.authenticated = true; // For testing
                    // when authenticate = true, it should go to certain page that for logedin users ONLY.
                    // ANd might enabled/disable menus that avaible for user logedin ONLY.
                });
            }
    }]);
})();
