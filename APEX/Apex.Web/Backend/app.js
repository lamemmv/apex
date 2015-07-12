(function() {
    'use strict';

    // Declares how the application should be bootstrapped. See: http://docs.angularjs.org/guide/module
    angular.module('apex-app', ['ui.router', 'app.filters', 'app.services', 'app.directives', modules.config, modules.news, modules.users, modules.home])/*.run([
        '$rootScope', '$location', 'authProvider', function ($rootScope, $location, authProvider) {
            $rootScope.$on('$stateChangeStart', function (event, toState, toParams
                                                   , fromState, fromParams) {
                if (!authProvider.isLoggedIn()) {
                    console.log('DENY : Redirecting to Login');
                    event.preventDefault();
                    $location.path('/login');
                } else {
                    console.log('ALLOW');
                }
            });
        }
    ]);*/
})();

    
    


    