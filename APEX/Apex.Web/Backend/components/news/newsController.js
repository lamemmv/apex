(function() {
    'use strict';

    // Google Analytics Collection APIs Reference:
    // https://developers.google.com/analytics/devguides/collection/analyticsjs/

    angular.module(modules.news, [])
        .controller(controllers.newsController, ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.translation = resources;

            initialize();

            function initialize() {
                $http.get("/news", { params: { 'Id': 1 } }).success(function (data, status, headers, config) {
                    console.log('successful');
                }).error(function (data, status, headers, config) {
                    console.log('error');
                });
            }
        }]);
})();
