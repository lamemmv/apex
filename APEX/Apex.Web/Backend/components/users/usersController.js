(function () {
    'use strict';

    angular.module(modules.users, [])
        .controller(controllers.usersController, ['$scope', '$http', function ($scope, $http) {
        $scope.translation = resources;
        var vm = this;
        vm.login = login;
        vm.formdata = { username: '', password: '' };

        function login() {
        	$http.post('/api/user/authenticate', vm.formdata).success(function (data, status, headers, config) {
        		console.log('authenticated');
        	}).error(function (data, status, headers, config) {
        		alert(data.message);
            });
        }
    }]);
})();
