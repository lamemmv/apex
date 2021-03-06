﻿(function () {
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
            .state(states.dashboard, {
                url: '/dashboard',
                templateUrl: '/Backend/components/dashboard/index.html',
                controller: controllers.dashboardController,
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