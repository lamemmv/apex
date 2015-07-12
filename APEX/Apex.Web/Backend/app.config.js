var configModule = angular.module(modules.config, []);
configModule.factory('loginRecoverer', ['$q', function ($q) {
    var loginRecoverer = {
        responseError: function (response) {
            if (response.status == 401) {
                console.log('redirect to login page');
                window.location = "/login";
            }
            console.log('reject response');
            return $q.reject(response);
        }
    };
    return loginRecoverer;
}]);

configModule.config([
    '$httpProvider', function($httpProvider) {
        $httpProvider.interceptors.push('loginRecoverer');
    }
]);

/*angular.module(modules.authentication, [])
  .factory('authProvider', function () {
      var user;
      return {
          setUser: function (aUser) {
              user = aUser;
          },
          isLoggedIn: function () {
              return (user) ? user : false;
          }
      };
  });*/