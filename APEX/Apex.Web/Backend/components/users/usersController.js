(function () {
    'use strict';

    angular.module(modules.users, [])
        .controller(controllers.usersController, ['$scope', '$http', function ($scope, $http) {
        $scope.translation = resources;
        var vm = this;
        vm.login = login;
        vm.username = '';
        vm.password = '';

        function login() {
            var data = {
                username: vm.username,
                password : vm.password
            };

            $http.post("/api/users", JSON.stringify(data),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                 .success(function (data, status, headers, config) {
                    console.log('authenticated');
                 }).error(function (data, status, headers, config) {
                    console.log('not authenticate');
                 });
        }
    }]);
})();
