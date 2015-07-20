(function () {
    'use strict';

    angular.module(modules.users)
        .controller(controllers.loginController, ['$scope', '$http', '$modalInstance', function ($scope, $http, $modalInstance) {
            $scope.translation = resources;
            $scope.login = login;

            $scope.formdata = { username: '', password: '' };

            function login($event) {

                $http.post('/api/user/authenticate', $scope.formdata).success(function (data, status, headers, config) {
                    // TODO: should get user information and return for mainController. 
                    // mainController will store user information in the local storage.
                    $modalInstance.close(true);
                }).error(function (data, status, headers, config) {
                    $modalInstance.close(false);
                });
            }

        }]);
})();
