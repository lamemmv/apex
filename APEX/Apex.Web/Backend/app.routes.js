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
                data: {
                    requireLogin: false
                },
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