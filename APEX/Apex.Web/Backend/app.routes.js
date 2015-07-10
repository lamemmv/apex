(function () {
	'use strict';
	angular.module('apex-app')
           .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', routesConfig]);

	function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {

		// UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
		// ------------------------------------------------------------------------------------------------------------
		$locationProvider.hashPrefix('!');
		$locationProvider.html5Mode(true);

		$stateProvider
            .state('home', {
            	url: '/',
            	templateUrl: '/Backend/components/home/index.html',
            	controller: controllers.home,
                controllerAs: 'vm'
            })
            .state('news', {
            	url: '/news',
            	templateUrl: '/Backend/components/news/index.html',
            	controller: controllers.newsController,
            	controllerAs: 'vm'
            })
            .state('login', {
            	url: '/login',
            	layout: 'basic',
            	templateUrl: '/views/login',
            	controller: controllers.usersController,
            	controllerAs: 'vm'
            })
            .state('otherwise', {
            	url: '*path',
            	templateUrl: '/Backend/components/home/index.html',
            	controller: controllers.home,
            	controllerAs: 'vm'
            });

		$urlRouterProvider.otherwise('/');
	};
})();

// Gets executed after the injector is created and are used to kickstart the application. Only instances and constants
    // can be injected here. This is to prevent further system configuration during application run time.
    /*.run(['$templateCache', '$rootScope', '$state', '$stateParams', function ($templateCache, $rootScope, $state, $stateParams) {

        // <ui-view> contains a pre-rendered template for the current view
        // caching it will prevent a round-trip to a server at the first page load
        var view = angular.element('#ui-view');
        $templateCache.put(view.data('tmpl-url'), view.html());

        // Allows to retrieve UI Router state information from inside templates
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.$on('$stateChangeSuccess', function (event, toState) {

            // Sets the layout name, which can be used to display different layouts (header, footer etc.)
            // based on which page the user is located
            $rootScope.layout = toState.layout;
        });
    }]);*/